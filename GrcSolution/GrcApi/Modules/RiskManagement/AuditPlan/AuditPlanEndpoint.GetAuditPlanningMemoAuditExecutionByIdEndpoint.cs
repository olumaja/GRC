using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 08/05/2024
* Development Group: Audit plan Risk Assessment - GRCTools
*/
    public class GetAuditPlanningMemoAuditExecutionByIdEndpoint
    {
        /// <summary>
        /// Endpoint to Get Audit Planning Memo detail  By Id
        /// </summary>
        /// <param name="commenceEngagementId"></param>
        /// <param name="auditmemo"></param>
        /// <param name="commenceEng"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            Guid commenceEngagementId, string team,  IRepository<AuditPlanningMemoAuditExecution> auditmemo, IRepository<AuditPlanningMemoPlanningTimeline> planningTime,
            IRepository<CommenceEngagementAuditexecution> commenceEng, ClaimsPrincipal user, ICurrentUserService currentUserService
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
                var getCommenceEng = commenceEng.GetContextByConditon(x => x.Id == commenceEngagementId).FirstOrDefault();
                if (getCommenceEng == null)
                {
                    return TypedResults.NotFound($"Commence Engagement Id '{commenceEngagementId}' was not found");
                }
                var getAuditAnnouncementMemo = auditmemo.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == getCommenceEng.Id && x.Team == team).FirstOrDefault();
                if (getAuditAnnouncementMemo == null)
                {
                    return TypedResults.NotFound($"Audit Planning Memo with the team {team} was not found");
                }
                var getPlanning = planningTime.GetContextByConditon(x => x.AuditPlanningMemoAuditExecutionId == getAuditAnnouncementMemo.Id).OrderBy(x => x.CreatedOnUtc);

                var getdurationResp = getPlanning.Select(p => new PlanningTimeline
                {
                    Tasks = p.Tasks,
                    PlannedDate = p.PlannedDate,
                    CompletedDate = p.CompletedDate,
                    Responsibility = p.Responsibility,

                }).ToList();

                GetAuditPlanningMemoAuditExecutionResp resp = new GetAuditPlanningMemoAuditExecutionResp
                {
                    CommenceEngagementId = getCommenceEng.Id,
                    Team = getAuditAnnouncementMemo.Team,
                    AuditPlanningMemoId = getAuditAnnouncementMemo.Id,
                    Status = getAuditAnnouncementMemo.Status.ToString(),
                    BusinessDescription = getAuditAnnouncementMemo.BusinessDescription,
                    StrategicObjective = getAuditAnnouncementMemo.StrategicObjective,
                    ImplementationPlan = getAuditAnnouncementMemo.ImplementationPlan,
                    ScopeAndControlTesting = getAuditAnnouncementMemo.ScopeAndControlTesting,
                    PriorAuditObservation = getAuditAnnouncementMemo.PriorAuditObservation,
                    RiskIdentified = getAuditAnnouncementMemo.RiskIdentified,
                    RegulatoryConsideration = getAuditAnnouncementMemo.RegulatoryConsideration,
                    PlanningTimeline = getdurationResp,
                    ReasonForRejection = getAuditAnnouncementMemo.ReasonForRejection
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
