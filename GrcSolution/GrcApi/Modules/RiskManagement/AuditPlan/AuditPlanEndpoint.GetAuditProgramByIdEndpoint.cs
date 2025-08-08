using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
/*
* Original Author: Olusegun Adaramaja
* Date Created: 10/05/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* The endpoint get Audit program
*/
    public class GetAuditProgramByCommenceIdEndpoint
    {
        /// <summary>
        /// This endpoint get audit program by commence engagement audit execution id
        /// </summary>
        /// <param name="commenceEngagementId"></param>
        /// <param name="repoAuditProgram"></param>
        /// <param name="commenceEng"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            Guid commenceEngagementId, string team, IRepository<AuditProgramAuditExecution> repoAuditProgram, 
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

                if (getCommenceEng is null)
                {
                    return TypedResults.NotFound($"Commence Engagement Id {commenceEngagementId} was not found");
                }

                var auditprograms = repoAuditProgram.GetContextByConditon(a => a.CommenceEngagementAuditexecutionId == getCommenceEng.Id && a.Team == team).OrderBy(x => x.CreatedOnUtc);

                if (!auditprograms.Any())
                {
                    return TypedResults.NotFound($"Audit Program with the team {team} was not found");
                }

                var programs = auditprograms.Select(p => new GetAuditProgram
                {
                    AuditProgramId = p.Id,
                    Team = p.Team,
                    Process = p.Title,
                    SubProcess = p.SubProcess,
                    RiskDescription = p.RiskDescription,
                    ControlDescription = p.ControlDescription,
                    ControlObjectives = p.ControlObjective,
                    ReviewProcedure = p.ReviewProcedure,
                    InformationRequired = p.InformationRequired,
                    Comment = p.Comment,
                    ReasonForRejection = p.ReasonForRejection,
                    Status = p.Status.ToString(),
                    IsWorkPaperInitiated = p.IsWorkPaperInitiated
                }).ToList();

                var result = new GetAuditProgramResponse(
                    CommenceEngagementAuditexecutionId: getCommenceEng.Id,
                    AuditPrograms: programs
                );

                return TypedResults.Ok(result);
            }
            catch( Exception ex )
            {
                return TypedResults.NotFound("Record was not found");
            }
        }
    }
}
