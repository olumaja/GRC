using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
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
    public class CommenceEngagementInformationRequiremenEndpoint
    {
        /// <summary>
        /// Commence Engagement- Information Requirement   
        /// </summary>
        /// <param name="request"></param>
        /// <param name="anualAuditUniverse"></param>
        /// <param name="inforRequirement"></param>
        /// <param name="commenceEng"></param>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] InformationRequirementRequest request, IRepository<AnualAuditUniverseRiskRating> anualAuditUniverse, 
            IRepository<AuditAnnouncementMemoAuditExecution> auditmemo, IRepository<InformationRequirementAuditExecution> inforRequirement,
             IRepository<CommenceEngagementAuditexecution> commenceEng, 
            IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService)
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

                string requesterName = user.Claims.FirstOrDefault(c => c.Type == "name").Value;
               List<InformationRequirementAuditExecution> req = new List<InformationRequirementAuditExecution>();

                var checkIiAnualAuditUniverseIdExist = anualAuditUniverse.GetContextByConditon(c => c.Id == request.AnualAuditUniverseRiskRatingId).FirstOrDefault();
                if (checkIiAnualAuditUniverseIdExist == null) { return TypedResults.NotFound("No record found"); }
               
                var checkInformationRequirement = commenceEng.GetContextByConditon(c => c.AnualAuditUniverseRiskRatingId == request.AnualAuditUniverseRiskRatingId && c.Team == request.Team).FirstOrDefault();
                if (checkInformationRequirement == null) { return TypedResults.NotFound("Commence Engagement has not been performed"); }

                var getUnit = auditmemo.GetContextByConditon(c => c.CommenceEngagementAuditexecutionId == checkInformationRequirement.Id).FirstOrDefault();

                //var checkIfItHasBeenrated = inforRequirement.GetContextByConditon(c => c.RequesterName == requesterName && c.Team == request.Team).FirstOrDefault();
                //if (checkIfItHasBeenrated != null) { return TypedResults.Ok($"Information Requirement has been previously submited with the Id: {checkInformationRequirement.Id}"); }

                foreach (var item in request.InformationRequirement)
                {
                    req.Add(InformationRequirementAuditExecution.Create(request.Team, requesterName, checkInformationRequirement.Id, item.InformationRequest, item.ResponsibleOfficer, item.RequestDate, item.DateProvided));
                }
                await inforRequirement.AddRangeAsync(req);
                await inforRequirement.SaveChangesAsync();
                              
                #region Send email to the InternalAudit-HQ 
               
                string subject = $"Information Requirement - {getUnit.Unit}";
                string emailTo = config["EmailConfiguration:InternalAuditSupervisor"];
                //  string emailTo = getUnit.Recipient;
                string toCC = config["EmailConfiguration:ToCCInternalAudit"];
                string supervisorName = config["EmailConfiguration:InternalAudirSupervisorName"];
                string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string body = $"Dear {supervisorName}, <br><br> {requesterName} has submitted the information requirements for {getUnit.Unit}, {getUnit.Recommendation}, for your review and approval.<br><br>Please click the following link <a href={linkToGRCTool}>GRC link</a> to view the assessment.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalAudit, checkInformationRequirement.Id, emailTo, toCC);
               
                #endregion

                CommenceEngagementAuditexecutionResp response = new CommenceEngagementAuditexecutionResp
                {
                    CommenceEngagementId = checkInformationRequirement.Id
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
