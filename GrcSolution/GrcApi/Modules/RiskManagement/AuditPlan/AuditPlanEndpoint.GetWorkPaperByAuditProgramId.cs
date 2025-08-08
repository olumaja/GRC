using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Migrations;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto;
using System.Diagnostics;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    public class GetWorkPaperByAuditIdEndpoint
    {
        public static async Task<IResult> HandleAsync(Guid auditProgramId, string team, IRepository<WorkPaper> workpaperRepo, IRepository<AuditProgramAuditExecution> programRepo, ClaimsPrincipal user, ICurrentUserService currentUserService)
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
                List<GetWorkpaperResponse> viewResp = new List<GetWorkpaperResponse>();

                var auditProgram = programRepo.GetContextByConditon(a => a.Id == auditProgramId && a.Team == team).FirstOrDefault();

                if (auditProgram is null)
                {
                    return TypedResults.NotFound("Record was not found");
                }
                var getWorkpaper = workpaperRepo.GetContextByConditon(a => a.CreatedOnUtc.Year == year && a.Team == team).OrderBy(x => x.CreatedOnUtc).ToList();                
                if (getWorkpaper == null)
                {
                    return TypedResults.NotFound($"Work paper has not been fully performed");
                }
                foreach (var item in getWorkpaper)
                {

                    viewResp.Add(new GetWorkpaperResponse
                    {
                       AuditProgramId =  item.AuditProgramId,
                       WorkPaperId = item.Id,
                       Team = team, 
                       Process = auditProgram.Title, 
                       SubProcess = auditProgram.SubProcess,
                       RiskDescription = auditProgram.RiskDescription, 
                       ControlDescription = auditProgram.ControlDescription,
                       ControlObjectives = auditProgram.ControlObjective, 
                       ReviewProcedure = auditProgram.ReviewProcedure,
                       InformationRequired = auditProgram.InformationRequired,
                       Comments = auditProgram.Comment,
                       IssueSummary = item.IssueSummary,
                       RootCause = item.RootCause, 
                       Impact = item.Impact,
                       Recommendation = item.Recommendation,
                       IssueRating = item.IssueRating.ToString(), 
                       ReviewResult = item.ReviewResult,
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
