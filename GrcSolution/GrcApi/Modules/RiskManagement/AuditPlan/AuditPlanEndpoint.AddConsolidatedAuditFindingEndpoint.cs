using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Domain;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Migrations;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using PdfSharp.Drawing;
using System.Security.Claims;
using static Arm.GrcTool.Domain.RiskEvent.ActionManagement;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
      * Original Author: Sodiq Quadre
      * Date Created: 22/05/2024
      * Development Group: GRCTools
      * Initiate Consolidated Ausit Finding.     
      */
    public class AddConsolidatedAuditFindingEndpoint
    {
        /// <summary>
        /// Initiate Consolidated Audit finding. 
        /// </summary> 
        /// <param name="request"></param>
        /// <param name="auditreport"></param>
        /// <param name="auditFinding"></param>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>      
        public static async Task<IResult> HandleAsync([FromBody] ConsolidatedAuditFindingRequest request, IRepository<InternalAuditReport> auditreport, IRepository<ConsolidatedAuditFinding> auditFinding,
            IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                string requesterName = user.Claims.FirstOrDefault(c => c.Type == "name").Value;
                var newFindings = new List<ConsolidatedAuditFinding>();

                var getauditreport = auditreport.GetContextByConditon(c => c.Id == request.AuditReportId).FirstOrDefault();
                if (getauditreport == null) { return TypedResults.NotFound("Internal Audit Report was not found"); }

                foreach (var findings in request.Findings)
                {

                    //update OPR status
                    BusinessRiskRatingStatus oprStatus = BusinessRiskRatingStatus.Not_Yet_Due;
                    DateTime dateTime = DateTime.Now;
                    if (findings.ActionDueDate.Value.Date == dateTime.Date)
                    {
                        oprStatus = BusinessRiskRatingStatus.Due;
                    }
                    if (findings.ActionDueDate.Value.Date < dateTime.Date)
                    {
                        oprStatus = BusinessRiskRatingStatus.Past_Due;
                    }
                    if (findings.ActionDueDate.Value.Date > dateTime.Date)
                    {
                        oprStatus = BusinessRiskRatingStatus.Not_Yet_Due;
                    }

                    //update OPR status level
                    BusinessRiskRatingStatus statuslevel = BusinessRiskRatingStatus.Not_Yet_Due;
                    DateTime dateTime2 = DateTime.Now;
                    if (findings.RevisedDueDate.Value.Date == dateTime2.Date)
                    {
                        statuslevel = BusinessRiskRatingStatus.Due;
                    }
                    if (findings.RevisedDueDate.Value.Date < dateTime2.Date)
                    {
                        statuslevel = BusinessRiskRatingStatus.Past_Due;
                    }
                    if (findings.RevisedDueDate.Value.Date > dateTime2.Date)
                    {
                        statuslevel = BusinessRiskRatingStatus.Not_Yet_Due;
                    }

                    newFindings.Add(
                        ConsolidatedAuditFinding.Create(                            
                           request.AuditReportId, requesterName, findings.ReviewType, findings.DateFindingRaised, findings.DetailedFindings,
                           findings.AuditArea, request.Business, findings.Level1, findings.Level2, findings.RevisedDueDate, findings.Recommendation,
                           findings.ImpactRating, findings.WorkStream, findings.ReportingQuater, findings.ActionDueDate, findings.UpdatedComment,
                           findings.ManagmentResponseAsAtTimeOfEngagement, findings.DescriptionOfIssue, findings.ActionOwner, findings.EngagementName, findings.Unit, findings.Entity,
                           oprStatus, statuslevel

                         ));
                }
                auditFinding.AddRange(newFindings);
                auditFinding.SaveChanges();

                var response = new ConsolidatedAuditFindingResp
                {
                    ConsolidatedAuditFindingId = request.AuditReportId
                };
                return TypedResults.Created($"caf/{response}", response);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }

        }
    }
}
