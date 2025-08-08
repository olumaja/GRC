using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.BIA;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.BIA
{
    public class GetBusinessImpactAnalysisEndpoint
    {
        /// <summary>
        /// This endpoint fetch details of selected Business Analysis Impact
        /// </summary>
        /// <param name="biaUnitId"></param>
        /// <param name="biaUnitRepo"></param>
        /// <param name="biaProcessDetailsRepo"></param>
        /// <param name="processRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid biaUnitId, IRepository<BusinessImpactAnalysisUnit> biaUnitRepo, 
            IRepository<BIAUnitProcessDetails> biaProcessDetailsRepo, IRepository<RSCAProcess> processRepo, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            //var email = user.Claims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", StringComparison.OrdinalIgnoreCase));
            var email = currentUserService.CurrentUserEmail;

            if (string.IsNullOrWhiteSpace(email))
            {
                return TypedResults.Unauthorized();
            }

            var unitIdValue = user.Claims.FirstOrDefault(c => c.Type.Equals("unitId", StringComparison.OrdinalIgnoreCase));

            if (unitIdValue is null)
            {
                return TypedResults.Ok("Unit was not found");
            }

            Guid unitId = new Guid(unitIdValue.Value);
            var biaUnitProcessDetails = biaProcessDetailsRepo.GetContextByConditon(b => b.BusinessImpactAnalysisUnitId.Equals(biaUnitId))
                //.Include(b => b.ResponsibleBusinessUnits).ThenInclude(r => r.Unit)
                .Include(b => b.BusinessUnitsToRunProcess).ThenInclude(r => r.Unit).ToList();

            if (biaUnitProcessDetails is null)
            {
                return TypedResults.NotFound();
            }

            var processes = await processRepo.GetAllAsync();
            var biaUnit = biaUnitRepo.GetContextByConditon(b => b.Id.Equals(biaUnitId)).Include(b => b.Unit).FirstOrDefault();

            var biaUnitDetail = new GetBIAUnitDto(
                biaUnitId, biaUnit.Unit.Name, biaUnit.Requester, biaUnit.Approval, biaUnit.ApprovalDate, biaUnit.Comment, biaUnit.Status, biaUnit.Stage,
               biaUnitProcessDetails.Select(b => new GetBIAProcessDetailsDto(
                   b.BusinessProcessDescriptionSummary, b.ProcessId, processes.Find(p => p.Id.Equals(b.ProcessId)).Name, b.FinancialImpact, b.CustomerExperience, b.OtherProcessesOrPeople, b.RegulatoryOrLegal,
                   b.Reputation, b.ThirdPartyImpact, b.MinimumBusinessContinuityObjective, b.MaximumAllowableOutage, b.RecoveryPointObjective, b.RecoveryPointObjective,
                   b.Priority, b.ApplicationsUsedToRunProcess, b.KeyVendors, b.AnyNonElectronicVitalRecords, b.AlternativeWorkarounds, b.PrimaryRecoverStrategyAndSolution,
                   b.PeakPeriod, b.RemoteWorking,
                   //b.ResponsibleBusinessUnits.Select(r => new ResponsibleBusinessUnit(r.Unit.Id, r.Unit.Name)).ToList(),
                   b.BusinessUnitsToRunProcess.Select(p => new BusinessUnitsToRunProcess(p.Unit.Id, p.Unit.Name)).ToList()
                )).ToList()
            );

            return TypedResults.Ok(biaUnitDetail);
        }
    }
}
