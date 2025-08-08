using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static Arm.GrcTool.Domain.BusinessImpactAnalysis.BusinessImpactAnalysisUnit;

namespace Arm.GrcApi.Modules.RiskManagement.BIA
{
    public class InitiateBusinessImpactAnalysisEndpoint
    {
        public static async Task<IResult> HandleAsync(
            [FromBody] InitiateBIADto initiateBIADto, IRepository<BusinessImpactAnalysisUnit> biaUnitRepo, IRepository<BIAUnitProcessDetails> biaProcessDetailRepo,
            IRepository<BusinessImpactAnalysisUnitLog> businessImpactAnalysisUnitLogRepo, IEmailService EmailService, IConfiguration config,
            ICurrentUserService currentUserService
        )
        {
            Guid businessImpactAnalysisUnitId = initiateBIADto.BusinessImpactAnalysisUnitId;

            // Get BusinessImpactAnalysisUnit
            var businessImpactAnalysisUnit = biaUnitRepo.GetContextByConditon(b => b.Id.Equals(businessImpactAnalysisUnitId))
                                                        .Include(b => b.BIAUnitProcessDetails).FirstOrDefault();

            if (businessImpactAnalysisUnit == null)
            {
                return TypedResults.BadRequest($"Business unit {businessImpactAnalysisUnitId} doesn't exist");
            }

            if (businessImpactAnalysisUnit.BIAUnitProcessDetails.Count > 0)
            {
                biaProcessDetailRepo.RemoveRange(businessImpactAnalysisUnit.BIAUnitProcessDetails);
            }

            // Create BIAUnitProcessDetails
            var initiateBIAProcessDetails = initiateBIADto.InitiateBIAProcessDetails
            .Select(p => BIAUnitProcessDetails
            .Create(
                businessImpactAnalysisUnitId: businessImpactAnalysisUnitId, processId: p.ProcessId,
                businessProcessDescriptionSummary: p.BusinessProcessDescriptionSummary, financialImpact: p.FinancialImpact,
                customerExperience: p.CustomerExperience, otherProcessesOrPeople: p.OtherProcessesOrPeople,
                regulatoryOrLegal: p.RegulatoryOrLegal, reputation: p.Reputation, thirdPartyImpact: p.ThirdPartyImpact,
                minimumBusinessContinuityObjective: p.MinimumBusinessContinuityObjective, maximumAllowableOutage: p.MaximumAllowableOutage,
                recoveryTimeObjective: p.RecoveryTimeObjective, recoveryPointObjective: p.RecoveryPointObjective,
                priority: p.Priority, applicationsUsedToRunProcess: p.ApplicationsUsedToRunProcess, keyVendors: p.KeyVendors,
                anyNonElectronicVitalRecords: p.AnyNonElectronicVitalRecords, alternativeWorkarounds: p.AlternativeWorkarounds,
                primaryRecoverStrategyAndSolution: p.PrimaryRecoverStrategyAndSolution, peakPeriod: p.PeakPeriod,
                remoteWorking: p.RemoteWorking
                , //responsibleBusinessUnits: p.ResponsibleBusinessUnits.Select(u => BIAUnitProcessDetailsResponsibleBusinessUnit.Create(u)).ToList(),
                businessUnitsToRunProcess: p.BusinessUnitsToRunProcess.Select(u => BIAUnitProcessDetailsBusinessUnitToRunProcess.Create(u)).ToList()
            )).ToList();


            biaProcessDetailRepo.AddRange(initiateBIAProcessDetails);

            // Update BusinessImpactAnalysisUnit
            businessImpactAnalysisUnit.AddRequester(currentUserService.CurrentUserFullName);
            businessImpactAnalysisUnit.UpdateStage(BIAStage.RiskChampionHeadInitiateBIA);
            businessImpactAnalysisUnitLogRepo.Add(businessImpactAnalysisUnit.CreateBusinessImpactAnalysisUnitLog());
            biaUnitRepo.Update(businessImpactAnalysisUnit);
            biaUnitRepo.SaveChanges();
            #region Log email request
            DateTime dateOfOccurrence = DateTime.Now;
            string subject = $"New BIA Exercise";
            string emailTo = config["EmailConfiguration:RiskChampionsUnitHeads"];
            string toCC = config["EmailConfiguration:RiskMgtUnit"];
            string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
            string body = $"Hello all, <br> Your Risk Champion has successfully submitted the BIA. <br> Kindly login to the GRC Tool for your review and approval:<br> <a href={linkToGRCTool}>GRC link</a>.";
            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.RiskManagement, businessImpactAnalysisUnitId, emailTo, toCC);
            if (logEmailRequest == false)
            {
                return TypedResults.Ok($"Request initiated successfully with bia ID: {businessImpactAnalysisUnitId}, but email message was not logged");
            }
            #endregion
            return TypedResults.Created($"/bia/{businessImpactAnalysisUnitId}", new InitiateBIAResponseDto(businessImpactAnalysisUnitId));
        }
    }
}