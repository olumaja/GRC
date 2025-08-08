using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.RCSA
{
    public class RiskControlSelfAssessmentEndpointGetDocumentedProcess
    {
        public static async Task<IResult> HandleAsync(
            Guid riskControlSelfAssessmentUnitId, IRepository<DocumentRSCAProcess> docRepo, IRepository<RSCAProcess> processRepo,
            IRepository<RiskControlSelfAssessmentUnit> rcsaUnitRepo, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var processes = await processRepo.GetAllAsync();
                var docProcess = docRepo.GetContextByConditon(d => d.RiskControlSelfAssessmentUnitId.Equals(riskControlSelfAssessmentUnitId))
                    .Include(d => d.ProcessInherentRiskControls).Include(d => d.DocumentRSCAProcessLogs).FirstOrDefault();

                if (docProcess == null)
                {
                    return TypedResults.NotFound();
                }

                var processInherentRisks = new List<ProcessInherentRiskControlDto>();

                foreach (var item in docProcess.ProcessInherentRiskControls)
                {
                    var processObj = processes.FirstOrDefault(p => p.Id.Equals(item.ProcessId));
                    if (processObj != null)
                    {
                        var processName = processObj.Name;
                        processInherentRisks.Add(new ProcessInherentRiskControlDto(item.Id, item.ProcessId, item.InherentRisk, item.Control, item.TestToApply, processName));
                    }
                }

                var rcsaUnit = await rcsaUnitRepo.GetByIdAsync(riskControlSelfAssessmentUnitId);

                GetDocumentedProcessDto documentedProcesses = new(
                    docProcess.Id,
                    docProcess.RiskControlSelfAssessmentUnitId,
                    docProcess.RCSAStage,
                    docProcess.Status,
                    docProcess.Comment,
                    rcsaUnit.Requester,
                    rcsaUnit.Approval,
                    rcsaUnit.ApprovalDate,
                    processInherentRisks
                );

                return TypedResults.Ok(documentedProcesses);
            }
            catch (Exception ex)
            {

                return TypedResults.NotFound("Record not found");
            }
        }
    }
}
