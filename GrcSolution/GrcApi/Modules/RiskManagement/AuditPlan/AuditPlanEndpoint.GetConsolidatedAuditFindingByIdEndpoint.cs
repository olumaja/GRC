using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.VisualBasic;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 22/05/2024
* Development Group: Audit plan Risk Assessment - GRCTools
*/
    public class GetConsolidatedAuditFindingByIdEndpoint
    {
        /// <summary>
        /// Endpoint to Get Consolidated Audit Finding By Id 
        /// </summary>
        /// <param name="consolidatedauditfindingid"></param>
        /// <param name="finding"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid consolidatedauditfindingid, IRepository<ConsolidatedAuditFinding> finding,
            ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                string requesterUnit = user.Claims.FirstOrDefault(c => c.Type == "unit").Value;
                if (requesterUnit != "Internal Audit")
                { return TypedResults.Forbid(); }
                var getfinding = finding.GetContextByConditon(x => x.Id == consolidatedauditfindingid).FirstOrDefault();
                                
                if (getfinding == null)
                {
                    return TypedResults.NotFound($"Audit Report Id '{consolidatedauditfindingid}' was not found");
                }
                DateTime date = DateTime.Now.Date;
                DateTime? dueDate = getfinding.ActionDueDate.Value.Date;
                var dueday = (dueDate - date).ToString();
                BusinessRiskRatingStatus oprStatus = BusinessRiskRatingStatus.Not_Yet_Due;
                bool findingExpectedToBeClosed = true;
                if (getfinding.OPRStatus == BusinessRiskRatingStatus.Due)
                {
                    oprStatus = BusinessRiskRatingStatus.Due;
                    findingExpectedToBeClosed = true;
                    dueday = dueday.Count().ToString();
                }
                if (getfinding.OPRStatus == BusinessRiskRatingStatus.Not_Yet_Due)
                {
                    oprStatus = BusinessRiskRatingStatus.Not_Yet_Due;
                    findingExpectedToBeClosed = false;
                    dueday = "NA";
                }
                if (getfinding.OPRStatus == BusinessRiskRatingStatus.Past_Due)
                {
                    oprStatus = BusinessRiskRatingStatus.Past_Due;
                    findingExpectedToBeClosed = true;
                    dueday = dueday.Count().ToString();
                }

                GetConsolidatedAuditFindingById resp = new GetConsolidatedAuditFindingById
                {
                    ConsolidatedAuditFindingId = consolidatedauditfindingid,
                    Business = getfinding.Business,
                    RequesterName = getfinding.RequesterName,
                    AuditArea = getfinding.AuditArea,
                    WorkStream = getfinding.WorkStream,
                    ImpactRating = getfinding.ImpactRating,
                    Level1 = getfinding.Level1,
                    Level2 = getfinding.Level2,
                    ReportingQuater = getfinding.ReportingQuater,
                    ReviewType = getfinding.ReviewType,
                    ResolutionDate = getfinding.ResolutionDate,
                    UpdatedComment = getfinding.UpdatedComment,
                    ManagmentResponseAsAtTimeOfEngagement = getfinding.ManagmentResponseAsAtTimeOfEngagement,
                    RevisedDueDate = getfinding.RevisedDueDate,
                    Recommendation = getfinding.Recommendation,
                    ActionDueDate = getfinding.ActionDueDate,
                    DateFindingRaised = getfinding.DateFindingRaised,
                    DetailedFindings = getfinding.DetailedFindings,
                    DueDay = dueday,
                    FindingRaisedYear = DateTime.Now.Year.ToString(),
                    PriorYearFinding = true,
                    CurrentYearFinding = true,
                    Status = getfinding.Status.ToString(),
                    StatusLevel = getfinding.StatusLevel.ToString(),
                    OPRStatus = getfinding.OPRStatus.ToString(),
                    FindingExpectedToBeClosed = findingExpectedToBeClosed,
                    DescriptionOfIssue = getfinding.DescriptionOfFinding,
                    DateCreated = getfinding.CreatedOnUtc,
                    ActionOwner = getfinding.ActionOwner,
                    Entity = getfinding.Entity,
                    Unit = getfinding.Unit,
                    EngagementName = getfinding.EngagementName
                };
                return TypedResults.Ok(resp);               
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }


        }
    }
}
