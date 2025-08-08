using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
/*
* Original Author: Olusegun Adaramaja
* Date Created: 10/05/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* The endpoint Initiate work paper
*/
    public class InitiateWorkPaperEndpoint
    {
        /// <summary>
        /// The endoint initiate work paper
        /// </summary>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            PostWorkPaperRequest payload, IRepository<WorkPaper> workpaperRepo, IRepository<AuditProgramAuditExecution> auditProgramRepo,
            IRepository<CommenceEngagementAuditexecution> repoComenceRepo, IConfiguration config, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
               
                var auditprogam = auditProgramRepo.GetContextByConditon(a => a.Id == payload.AuditProgramId && a.Team == payload.Team)
                    .FirstOrDefault();
                if (auditprogam is null)
                {
                    return TypedResults.NotFound($"Audit program has not been completed");
                }

                var commenceEngagement = repoComenceRepo.GetContextByConditon(c => c.Id == auditprogam.CommenceEngagementAuditexecutionId && c.Team == payload.Team)
                  .Include(c => c.AuditProgramAuditExecution).FirstOrDefault();

                if (commenceEngagement is null)
                {
                    return TypedResults.NotFound($"Commence engagement does not exist");
                }

                commenceEngagement.WorkPaper = BusinessRiskRatingStatus.Completed;
                repoComenceRepo.Update(commenceEngagement);


                auditprogam.IsWorkPaperInitiated = true;
                auditProgramRepo.Update(auditprogam);

                var checkworkPaper = workpaperRepo.GetContextByConditon(a => a.AuditProgramId == auditprogam.Id && a.Team == payload.Team).FirstOrDefault();
                if (checkworkPaper != null) { return TypedResults.Ok($"Work paper has been previously submited with the Id: {checkworkPaper.Id}"); }

                var workPaper = WorkPaper.Create(
                    auditprogam.Id, payload.Team, payload.Reference, payload.Reoccurence, payload.ExceptionNoted,
                    payload.IssueSummary, payload.RootCause, payload.Impact, payload.Recommendation, payload.IssueRating, payload.ReviewResult
                    );
                workpaperRepo.Add(workPaper);

                await workpaperRepo.SaveChangesAsync();
                WorkPaperResponse response = new WorkPaperResponse
                (
                    WorkpaperId: workPaper.Id
                );
               
                return TypedResults.Created($"aep/{response}", response);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }
        }
    }
}
