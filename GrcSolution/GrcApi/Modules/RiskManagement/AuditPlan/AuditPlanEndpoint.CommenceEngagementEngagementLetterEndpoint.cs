using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 06/05/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 */
    public class CommenceEngagementEngagementLetterEndpoint
    {
        /// <summary>
        /// Commence Engagement- Engagement Letter   
        /// </summary>
        /// <param name="request"></param>
        /// <param name="anualAuditUniverse"></param>
        /// <param name="engagementLetter"></param>
        /// <param name="commenceEng"></param>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] EngagementLetterAuditExecutionReq request, IRepository<AnualAuditUniverseRiskRating> anualAuditUniverse,
            IRepository<EngagementLetterAuditExecution> engagementLetter, IRepository<CommenceEngagementAuditexecution> commenceEng, 
            IRepository<EngagementLetterReportDistributionList> reportDistributionList, IRepository<EngagementLetterAuditExecutionDuration> duration,
            IRepository<AuditAnnouncementMemoAuditExecution> auditmemo, IEmailService EmailService, IConfiguration config, ClaimsPrincipal user,
            ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                string requesterName = user.Claims.FirstOrDefault(c => c.Type == "name").Value;
               // var year = DateTime.Now.Year;
                List<EngagementLetterAuditExecutionDuration> durationReq = new List<EngagementLetterAuditExecutionDuration>();
                List<EngagementLetterReportDistributionList> reportListReq = new List<EngagementLetterReportDistributionList>();
                var checkIiAnualAuditUniverseIdExist = anualAuditUniverse.GetContextByConditon(c => c.Id == request.AnualAuditUniverseRiskRatingId).FirstOrDefault();
                if (checkIiAnualAuditUniverseIdExist == null) { return TypedResults.NotFound("No record found"); }

                var checkCommenceEngagementAuditexecution = commenceEng.GetContextByConditon(c => c.AnualAuditUniverseRiskRatingId == request.AnualAuditUniverseRiskRatingId && c.Team == request.Team).FirstOrDefault();
                if (checkCommenceEngagementAuditexecution == null) { return TypedResults.NotFound("Commence Engagement has not been performed"); }

                //var checkIfItHasBeenrated = engagementLetter.GetContextByConditon(c => c.RequesterName == requesterName  && c.Team == request.Team).FirstOrDefault();
                //if (checkIfItHasBeenrated != null) { return TypedResults.Ok($"Engagement Letter has been previously submited with the Id: {checkIfItHasBeenrated.Id}"); }
                
                var getUnit = auditmemo.GetContextByConditon(c => c.CommenceEngagementAuditexecutionId == checkCommenceEngagementAuditexecution.Id).FirstOrDefault();
                               
                               
                //log req
                var logRequest = EngagementLetterAuditExecution.Create(request.Team, requesterName, checkCommenceEngagementAuditexecution.Id, request);
                await engagementLetter.AddAsync(logRequest);

                //log Engagement Letter Audit Execution Duration
                foreach (var item in request.EngagementLetterAuditExecutionDuration)
                {
                    durationReq.Add(EngagementLetterAuditExecutionDuration.Create(logRequest.Id, item.Action, item.Timing));
                }
                await duration.AddRangeAsync(durationReq);

                //log Engagement Letter Report Distribution List
                foreach (var item in request.EngagementLetterReportDistributionList)
                {
                    reportListReq.Add(EngagementLetterReportDistributionList.Create(logRequest.Id, item.Name, item.Title, item.BusinessUnit));
                }
                await reportDistributionList.AddRangeAsync(reportListReq);
                await reportDistributionList.SaveChangesAsync();

                #region Send email to the InternalAudit-HQ                
               
                string subject = $"Engagement Letter - {getUnit.Unit}";
                string emailTo = config["EmailConfiguration:InternalAuditSupervisor"];
                //string emailTo = getUnit.Recipient;
                string toCC = config["EmailConfiguration:ToCCInternalAudit"];
                string supervisorName = config["EmailConfiguration:InternalAudirSupervisorName"];
                string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string body = $"Dear {supervisorName}, <br><br> {requesterName} has submitted the engagement Letter for {getUnit.Unit}, {getUnit.Recommendation} for your review and approval. <br><br>Please click the following link <a href={linkToGRCTool}>GRC link</a> to view the assessment.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalAudit, checkCommenceEngagementAuditexecution.Id, emailTo, toCC);
               
                #endregion
                CommenceEngagementAuditexecutionResp response = new CommenceEngagementAuditexecutionResp
                {
                    CommenceEngagementId = checkCommenceEngagementAuditexecution.Id
                };

                return TypedResults.Created($"aep/{response}", response);

            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }

        }
    }
}
