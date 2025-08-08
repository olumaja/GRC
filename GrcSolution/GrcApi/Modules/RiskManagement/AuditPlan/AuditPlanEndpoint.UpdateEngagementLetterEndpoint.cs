using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;
using System.Web.Http;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
  * Original Author: Sodiq Quadre
  * Date Created: 06/05/2024
  * Development Group: Audit plan Risk Assessment - GRCTools
  */
    public class UpdateEngagementLetterEndpoint
    {
        /// <summary>
        /// Commence Engagement- Update Engagement Letter   
        /// </summary>
        /// <param name="request"></param>
        /// <param name="anualAuditUniverse"></param>
        /// <param name="engagementLetter"></param>
        /// <param name="commenceEng"></param>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] UpdateEngagementLetterAuditExecutionReq request, IRepository<AnualAuditUniverseRiskRating> anualAuditUniverse,
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
                string requesterUnit = user.Claims.FirstOrDefault(c => c.Type == "unit").Value;
                if (requesterUnit != "Internal Audit")
                { return TypedResults.Forbid(); }

                var checkIfItHasBeenrated = engagementLetter.GetContextByConditon(c => c.CommenceEngagementAuditexecutionId == request.CommenceEngagementId && c.Status != BusinessRiskRatingStatus.Approved).FirstOrDefault();
                if (checkIfItHasBeenrated == null) { return TypedResults.NotFound($"Record was not found or it has been previously approved"); }

                //log request               
                checkIfItHasBeenrated.UpdateEngagementLetterAuditExecution(checkIfItHasBeenrated.Id, checkIfItHasBeenrated.CommenceEngagementAuditexecutionId, request);
                checkIfItHasBeenrated.SetModifiedBy(checkIfItHasBeenrated.Id);
                checkIfItHasBeenrated.SetModifiedOnUtc(DateTime.Now);
                engagementLetter.SaveChanges();

                //log Engagement Letter Audit Execution Duration
                foreach (var item in request.EngagementLetterAuditExecutionDuration) 
                {
                    var getDuration = duration.GetContextByConditon(c => c.EngagementLetterAuditExecutionId == checkIfItHasBeenrated.Id).FirstOrDefault();
                    if(getDuration == null)
                    { return TypedResults.NotFound("Engagement Letter Report Distribution List was not found"); }

                    getDuration.UpdateEngagementLetterAuditExecutionDuration(getDuration.Id, getDuration.EngagementLetterAuditExecutionId, item.Action, item.Timing);
                    getDuration.SetModifiedBy(getDuration.Id);
                    getDuration.SetModifiedOnUtc(DateTime.Now);
                    
                }
                duration.SaveChanges();
                //log Engagement Letter Report Distribution List
                foreach (var item in request.EngagementLetterReportDistributionList)
                {
                    var getreportDistributionList = reportDistributionList.GetContextByConditon(c => c.EngagementLetterAuditExecutionId == checkIfItHasBeenrated.Id).FirstOrDefault();
                    if (getreportDistributionList == null)
                    { return TypedResults.NotFound("Engagement Letter Report Distribution List was not found");  }

                    getreportDistributionList.UpdateEngagementLetterReportDistributionList(getreportDistributionList.Id, getreportDistributionList.EngagementLetterAuditExecutionId, item.Name, item.Title, item.BusinessUnit);
                    getreportDistributionList.SetModifiedBy(getreportDistributionList.Id);
                    getreportDistributionList.SetModifiedOnUtc(DateTime.Now);                   

                }
                reportDistributionList.SaveChanges();
                return TypedResults.Ok("Engagement Letter updated successfully");

            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }

        }
    }
}
