using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using Azure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Olusegun Adaramaja
* Date Created: 10/05/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* The endpoint Initiate audit findings
*/
    public class InitiateAuditFindsEndpoint
    {
        /// <summary>
        /// This endpoint create audit findings
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="workpaperRepo"></param>
        /// <param name="findingsRepo"></param>
        /// <param name="auditProgramRepo"></param>
        /// <param name="repoComenceRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            PostAuditFindingsRequest payload, IRepository<WorkPaper> workpaperRepo, IRepository<AuditFindings> findingsRepo, 
            IRepository<AuditProgramAuditExecution> auditProgramRepo, ICurrentUserService currentUserService,
            IRepository<CommenceEngagementAuditexecution> repoComenceRepo
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
                auditprogam.IsAuditFindingInitiated = true;
                auditProgramRepo.Update(auditprogam);
                var commenceEngagement = await repoComenceRepo.FirstOrDefaultAsync(c => c.Id == auditprogam.CommenceEngagementAuditexecutionId && c.Team == payload.Team);

                if (commenceEngagement is null)
                {
                    return TypedResults.NotFound($"Commence engagement does not exist");
                }

                commenceEngagement.Findingstatus = BusinessRiskRatingStatus.Completed;
                repoComenceRepo.Update(commenceEngagement);
                var workpaper = await workpaperRepo.FirstOrDefaultAsync(w => w.AuditProgramId == auditprogam.Id);
                if (workpaper is null)
                {
                    return TypedResults.BadRequest("work paper does not exist");
                }
                workpaper.IsAuditFindingInitiated = true;
                workpaperRepo.Update(workpaper);

                var findings = AuditFindings.Create(
                    workpaper.Id, payload.Team, payload.ActionToResolve, payload.ActionToPreventReoccurence, payload.ActionDueDate, payload.ActionOwner,
                    payload.ActionOwnerUnit
                );
                findingsRepo.Add(findings);
                findingsRepo.SaveChanges();

                var response = new AuditFindingsResponse(AuditFindingsId: findings.Id);
                return TypedResults.Created($"aep/{response}", response);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Unable to submit the request");
            }
        }
    }
}
