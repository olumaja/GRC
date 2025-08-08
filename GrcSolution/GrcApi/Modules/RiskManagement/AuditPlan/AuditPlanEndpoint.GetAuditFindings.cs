using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using Azure;
using GrcApi.Migrations;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto;
using System.Diagnostics;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    public class GetAuditFindingsEndpoint
    {
        public static async Task<IResult> HandleAsync(Guid auditProgramId, string team, IRepository<AuditProgramAuditExecution> programRepo, IRepository<WorkPaper> workpaperRepo, IRepository<AuditFindings> findings, ClaimsPrincipal user, ICurrentUserService currentUserService)
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
                var year = DateTime.Now.Year;
                List<GetAduitFindingsResponse> viewResp = new List<GetAduitFindingsResponse>();
                               
                var checkifWorkPaperExist = workpaperRepo.GetContextByConditon(a => a.AuditProgramId == auditProgramId && a.Team == team).FirstOrDefault();
                if (checkifWorkPaperExist is null) return TypedResults.NotFound("Work Paper does not exist");
                var getFinding = findings.GetContextByConditon(a => a.CreatedOnUtc.Year == year && a.Team == team).OrderBy(x => x.CreatedOnUtc).ToList();
                if (getFinding == null)
                {
                    return TypedResults.NotFound($"Work paper has not been fully performed");
                }
                foreach (var item in getFinding)
                {
                    var getWorkPaper = workpaperRepo.GetContextByConditon(a => a.Id == item.WorkerPaperId && a.Team == team).FirstOrDefault();
                    if (getWorkPaper is null) return TypedResults.NotFound("Work Paper does not exist");
                    var getAuditProgramdetail = programRepo.GetContextByConditon(a => a.Id == getWorkPaper.AuditProgramId && a.Team == team).FirstOrDefault();
                    if (getAuditProgramdetail is null) return TypedResults.NotFound("Audit Program detail was not found");


                    viewResp.Add(new GetAduitFindingsResponse
                    {
                        AuditProgramId = getWorkPaper.AuditProgramId, 
                        WorkpaperId = item.WorkerPaperId,
                        AuditFindingsId = item.Id,
                        Team = item.Team,
                        Process = getAuditProgramdetail.Title,
                        IssueSummary = getWorkPaper.IssueSummary,
                        RootCause = getWorkPaper.RootCause,
                        Impact = getWorkPaper.Impact,
                        Recommendation = getWorkPaper.Recommendation,
                        IssueRating = getWorkPaper.IssueRating.ToString(), 
                        ActionToResolve = item.ActionToResolve,
                        ActionToPreventReOccurrence = item.ActionToPreventReoccurrence,
                        ActionDueDate = item.ActionDueDate, 
                        ActionOwner = item.ActionOwner,
                        ActionOwnerUnit = item.ActionOwnerUnit, 
                        DateCreated = item.CreatedOnUtc,
                        ReasonForRejection = item.ReasonForRejection,
                        Status = item.Status.ToString()
                    });

                }
                return TypedResults.Ok(viewResp);

            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }
        }
    }
}
