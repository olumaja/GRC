using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Ocsp;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 06/05/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 */
    public class CommenceEngagementAuditPlanningMemoEndpoint
    {
        /// <summary>
        /// Commence Engagement- Audit Planning Memo   
        /// </summary>
        /// <param name="request"></param>
        /// <param name="anualAuditUniverse"></param>
        /// <param name="auditmemo"></param>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] AuditPlanningMemoAuditExecutionReq request, IRepository<AuditPlanningMemoPlanningTimeline> planningTime,
            IRepository<AnualAuditUniverseRiskRating> anualAuditUniverse, IRepository<AuditAnnouncementMemoAuditExecution> auditmemo,
            IRepository<AuditPlanningMemoAuditExecution> auditPlanning, IRepository<CommenceEngagementAuditexecution> commenceEng, IEmailService EmailService, 
            IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                string requesterName = user.Claims.FirstOrDefault(c => c.Type == "name").Value;
                List<AuditPlanningMemoPlanningTimeline> req = new List<AuditPlanningMemoPlanningTimeline>();

                var checkIiAnualAuditUniverseIdExist = anualAuditUniverse.GetContextByConditon(c => c.Id == request.AnualAuditUniverseRiskRatingId).FirstOrDefault();
                if (checkIiAnualAuditUniverseIdExist == null) { return TypedResults.NotFound("No record found"); }

                //var checkIfItHasBeenrated = auditPlanning.GetContextByConditon(c => c.RequesterName == requesterName && c.Team == request.Team).FirstOrDefault();
                //if (checkIfItHasBeenrated != null) { return TypedResults.Ok($"Audit AnnouncementMemo has been previously submited with the Id: {checkIfItHasBeenrated.Id}"); }

                var checkCommenceEngagementAuditexecution = commenceEng.GetContextByConditon(c => c.AnualAuditUniverseRiskRatingId == request.AnualAuditUniverseRiskRatingId && c.Team == request.Team).FirstOrDefault();
                if (checkCommenceEngagementAuditexecution == null) { return TypedResults.NotFound("Commence Engagement has not been performed"); }

                var getUnit = auditmemo.GetContextByConditon(c => c.CommenceEngagementAuditexecutionId == checkCommenceEngagementAuditexecution.Id).FirstOrDefault();

                var logRequest = AuditPlanningMemoAuditExecution.Create(request.Team, requesterName, checkCommenceEngagementAuditexecution.Id, request.BusinessDescription, request.StrategicObjective, request.ImplementationPlan,
                    request.RiskIdentified, request.ScopeAndControlTesting, request.PriorAuditObservation, request.SystemOverview, request.Policies, request.RegulatoryConsideration);
                   await auditPlanning.AddAsync(logRequest);


                foreach (var item in request.PlanningTimeline)
                {
                    req.Add(AuditPlanningMemoPlanningTimeline.Create(item.Tasks, item.PlannedDate, item.CompletedDate, item.Responsibility));
                }
                await planningTime.AddRangeAsync(req);
                await planningTime.SaveChangesAsync();
               
                #region Send email to the InternalAudit-HQ 
                
                string subject = $"Audit Planning Memo - {getUnit.Unit}";
                string emailTo = config["EmailConfiguration:InternalAuditSupervisor"];
                string toCC = config["EmailConfiguration:ToCCInternalAudit"];
                string supervisorName = config["EmailConfiguration:InternalAudirSupervisorName"];
                string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string body = $"Dear {supervisorName}, <br> {requesterName} has submitted the audit planning memo for {getUnit.Unit}, {getUnit.Recommendation} for your review and approval. <br>Please click the following link <a href={linkToGRCTool}>GRC link</a> to view the assessment.";
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
