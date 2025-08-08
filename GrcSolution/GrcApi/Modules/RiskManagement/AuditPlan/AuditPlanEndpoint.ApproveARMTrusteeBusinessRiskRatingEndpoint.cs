using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 20/03/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* Endpoint to approve business risk rating
*/
    public class ApproveARMTrusteeBusinessRiskRatingEndpoint
    {
        /// <summary>
        /// Endpoint to approve armtrustee business risk rating
        /// </summary>
        /// <param name="businessriskratingId"></param>
        /// <param name="armTrustee"></param>
        /// <param name="repo"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="trustee"></param>
        /// <param name="strategy"></param>
        /// <param name="stracompliance"></param>
        /// <param name="straCommercialTru"></param>
        /// <param name="strategyFinContrl"></param>
        /// <param name="straPrivate"></param>
        /// <param name="strategyArmTrustee"></param>
        /// <param name="operation"></param>
        /// <param name="operCommercialtrus"></param>
        /// <param name="operCompliance"></param>
        /// <param name="operFundContrl"></param>
        /// <param name="operationPrivateTru"></param>
        /// <param name="operARMTRustee"></param>
        /// <param name="finance"></param>
        /// <param name="financeCompliance"></param>
        /// <param name="financeCtrl"></param>
        /// <param name="financePrivate"></param>
        /// <param name="financecommercialTru"></param>
        /// <param name="financeARMTrustee"></param>
        /// <param name="compliance"></param>
        /// <param name="complianceFinCtrl"></param>
        /// <param name="complianceComercial"></param>
        /// <param name="complianceComp"></param>
        /// <param name="compliancePrivate"></param>
        /// <param name="complianceArmTrustee"></param>
        /// <param name="timeSinceLastTrusteeAudit"></param>
        /// <param name="emcRating"></param>
        /// <param name="emcRiskRating"></param>
        /// <param name="managementConcernRating"></param>
        /// <param name="mgtConcern"></param>
        /// <param name="mgtRatingbusiness"></param>
        /// <param name="mgtSharedserviceRating"></param>
        /// <param name="annualaudit"></param>
        /// <param name="trusteeAnnualAudit"></param>
        /// <param name="trusteeAudit"></param>
        /// <param name="complianceAudit"></param>
        /// <param name="finalCtrlAudit"></param>
        /// <param name="commercialTrustaudit"></param>
        /// <param name="privateTrustAudit"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid businessriskratingId, [FromBody] ARMTrusteeRatingReq armTrustee, IRepository<ARMTrusteeRating> repo,
            IRepository<BusinessRiskRating> busnessRiskRating, IRepository<ARMTrusteeRating> trustee, IRepository<StrategyBusinessRatingTrustee> strategy,
            IRepository<StrategyTrusteeRatingCommercialTrust> straCommercialTru, IRepository<StrategyTrusteeRatingPrivateTrust> straPrivate,

            IRepository<OperationTrustee> operation, IRepository<OperationTrusteeRatingCommercialTrust> operCommercialtrus,
            IRepository<OperationTrusteeRatingPrivateTrust> operationPrivateTru,

            IRepository<FinancialTrusteeReporting> finance,
            IRepository<FinacialTrusteeRatingPrivateTrust> financePrivate, IRepository<FinacialTrusteeRatingCommercialTrust> financecommercialTru,

            IRepository<ComplianceBusinessRatingTrustee> compliance, IRepository<ComplianceTrusteeRatingCommercialTrust> complianceComercial,
            IRepository<ComplianceTrusteeRatingPrivateTrust> compliancePrivate, IRepository<TimeSinceLastTrusteeAudit> timeSinceLastTrusteeAudit,
            IRepository<EMCConcernRiskRating> emcRating, IRepository<ARMTrusteeEMCRating> emcRiskRating,
            IRepository<ManagementConcernRiskRating> managementConcernRating, IRepository<ManagementConcernARMTrustee> mgtConcern, IRepository<ManagementConcernBusinessUnitARMTrusteeRating> mgtRatingbusiness, IRepository<ManagementConcernSharedServiceARTrusteeRating> mgtSharedserviceRating,

            IRepository<AnualAuditUniverseRiskRating> annualaudit, IRepository<ARMTrusteeAuditUniverse> trusteeAnnualAudit, IRepository<AuditUniverseARMTrusteeCommercialTrust> commercialTrustaudit, IRepository<AuditUniverseARMTrusteePrivateTrust> privateTrustAudit,

            ClaimsPrincipal user, ICurrentUserService currentUserService)
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
                var getBusinessRiskRating = repo.GetContextByConditon(c => c.BusinessRiskRatingId == businessriskratingId && c.Status != BusinessRiskRatingStatus.Approved).FirstOrDefault();
                if (getBusinessRiskRating == null) { return TypedResults.NotFound("The record has been previouly approved"); }
                var getRating = busnessRiskRating.GetContextByConditon(x => x.Id == businessriskratingId).FirstOrDefault();
                if (getRating == null) { return TypedResults.NotFound(); }
                var businesses = await trustee.GetAllAsync();
                if (getRating != null)
                {
                    var gettrustee = businesses.Find(x => x.BusinessRiskRatingId.Equals(businessriskratingId));

                    var getstrategy = strategy.GetContextByConditon(x => x.ARMTrusteeRatingId == gettrustee.Id).FirstOrDefault();

                    var getstraCommercialTru = straCommercialTru.GetContextByConditon(x => x.StrategyBusinessRatingTrusteeId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();
                    var getstraPrivate = straPrivate.GetContextByConditon(x => x.StrategyBusinessRatingTrusteeId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();

                    var getoperation = operation.GetContextByConditon(x => x.ARMTrusteeRatingId == gettrustee.Id).FirstOrDefault();

                    var getoperCommercialtrus = operCommercialtrus.GetContextByConditon(x => x.OperationTrusteeId == getoperation.Id).Select(x => x.Total).FirstOrDefault();
                    var getoperationPrivateTru = operationPrivateTru.GetContextByConditon(x => x.OperationTrusteeId == getoperation.Id).Select(x => x.Total).FirstOrDefault();

                    var getfinance = finance.GetContextByConditon(x => x.ARMTrusteeRatingId == gettrustee.Id).FirstOrDefault();

                    var getfinancePrivate = financePrivate.GetContextByConditon(x => x.FinancialTrusteeReportingId == getfinance.Id).Select(x => x.Total).FirstOrDefault();
                    var getfinancecommercialTru = financecommercialTru.GetContextByConditon(x => x.FinancialTrusteeReportingId == getfinance.Id).Select(x => x.Total).FirstOrDefault();

                    var getcompliance = compliance.GetContextByConditon(x => x.ARMTrusteeRatingId == gettrustee.Id).FirstOrDefault();

                    var getcomplianceComercial = complianceComercial.GetContextByConditon(x => x.ComplianceBusinessRatingTrusteeId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();
                    var getcompliancePrivate = compliancePrivate.GetContextByConditon(x => x.ComplianceBusinessRatingTrusteeId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();

                    var gettimeSinceLastTrusteeAudit = timeSinceLastTrusteeAudit.GetContextByConditon(x => x.ARMTrusteeRatingId == gettrustee.Id).FirstOrDefault();

                    ////emc rating
                    //var getEMCRatingRating = emcRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                    //var getEmcConcernRating = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == getEMCRatingRating.Id).FirstOrDefault();

                    ////mc concern rating
                    //var getMCRatingRating = managementConcernRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                    //var getMCConcernRating = mgtConcern.GetContextByConditon(x => x.ManagementConcernRiskRatingId == getMCRatingRating.Id).FirstOrDefault();
                    //var getMgtRatingbusiness = mgtRatingbusiness.GetContextByConditon(x => x.ManagementConcernARMTrusteeId == getMCConcernRating.Id).FirstOrDefault();
                    //var getMgtSharedService = mgtSharedserviceRating.GetContextByConditon(x => x.ManagementConcernARMTrusteeId == getMCConcernRating.Id).FirstOrDefault();

                    var maximumPossibleStrategyBusinessMgtRating = 3 * 32;
                    var maximumPossibleOperationBusinessMgtRating = 3 * 20;
                    var maximumPossibleFinanceBusinessMgtRating = 3 * 7;
                    var maximumPossibleComplianceBusinessMgtRating = 3 * 11;
                    var maximumPossibleTimeSinceLastAuditBusinessMgtRating = 3 * 1;
                    var maximumPossibleEMCRating = 3 * 2;

                    var strategyWeight = 0.20; 
                    var operationWeight = 0.20; 
                    var financialReportWeight = 0.15; 
                    var complianceWeight = 0.15; 
                    var magtConcernWeight = 0.15m; 
                    var timeSinceLastAuditWeight = 0.15; 

                    //var businessManagerConcernPrivateTrust = getMgtRatingbusiness.PrivateTrust;
                    //var businessManagerConcernCommercialTrust = getMgtRatingbusiness.CommercialTrust;

                    // individual director Concern
                    //var directorConcernCommercialTrust = getEmcConcernRating.CommercialTrust + getMgtRatingbusiness.CommercialTrust;
                    //var directorConcernPrivateTrust = getEmcConcernRating.PrivateTrust + getMgtRatingbusiness.PrivateTrust;

                    #region MC and EMC Concern
                    //  //EMC                             
                    var getEMCRating = emcRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).ToList();
                    var allEmcConcernCommercialTrust = new List<decimal>();
                    var allEmcConcernPrivateTrust = new List<decimal>();

                    foreach (var item1 in getEMCRating)
                    {
                        var getEmcConcernCommercialTrust = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.CommercialTrust).ToList();
                        allEmcConcernCommercialTrust.AddRange(getEmcConcernCommercialTrust);

                        var getEmcConcernPrivateTrust = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.PrivateTrust).ToList();
                        allEmcConcernPrivateTrust.AddRange(getEmcConcernPrivateTrust);
                    }
                    // Calculate the sum and average for the first three records
                    var recordCommercialTrust = allEmcConcernCommercialTrust.ToList();
                    var recordPrivateTrust = allEmcConcernPrivateTrust.ToList();

                    decimal sumCommercialTrust = recordCommercialTrust.Sum();
                    decimal sumPrivateTrust = recordPrivateTrust.Sum();

                    decimal averageEMCCommercialTrust = recordCommercialTrust.Any() ? recordCommercialTrust.Average() : 0;
                    decimal averageEMCPrivateTrust = recordPrivateTrust.Any() ? recordPrivateTrust.Average() : 0;

                    //  //emc rating

                    var getMCRating = managementConcernRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).ToList();
                    var allMCConcernCommercialTrust = new List<decimal>();
                    var allMCConcernPrivateTrust = new List<decimal>();
                    foreach (var item2 in getMCRating)
                    {
                        var getMCConcernDFS = mgtConcern.GetContextByConditon(x => x.ManagementConcernRiskRatingId == item2.Id).ToList();
                        if (getMCConcernDFS.Any())
                        {
                            var getbusMCRatingCommercialTrust = mgtRatingbusiness.GetContextByConditon(x => getMCConcernDFS.Select(y => y.Id).Contains(x.ManagementConcernARMTrusteeId)).Select(x => x.CommercialTrust).ToList();
                            allMCConcernCommercialTrust.AddRange(getbusMCRatingCommercialTrust);

                            var getbusMCRatingPrivateTrust = mgtRatingbusiness.GetContextByConditon(x => getMCConcernDFS.Select(y => y.Id).Contains(x.ManagementConcernARMTrusteeId)).Select(x => x.PrivateTrust).ToList();
                            allMCConcernPrivateTrust.AddRange(getbusMCRatingPrivateTrust);
                        }
                    }
                    var recordMCCommercialTrust = allMCConcernCommercialTrust.ToList();
                    var recordMCPrivateTrust = allMCConcernPrivateTrust.ToList();
                  //  decimal sumMC = recordMC.Sum();
                    decimal averageMCCommercialTrust = recordMCCommercialTrust.Any() ? recordMCCommercialTrust.Average() : 0;
                    decimal averageMCPrivateTrust = recordMCPrivateTrust.Any() ? recordMCPrivateTrust.Average() : 0;

                    var businessManagerConcernCommercialTrust = averageMCCommercialTrust;
                    var businessManagerConcernPrivateTrust = averageMCPrivateTrust;

                    var directorCCommercialTrust = averageEMCCommercialTrust;
                    var directorPrivateTrust = averageEMCPrivateTrust;

                    var directorConcernCommercialTrust = businessManagerConcernCommercialTrust + directorCCommercialTrust;
                    var directorConcernPrivateTrust = businessManagerConcernPrivateTrust + directorPrivateTrust;

                    #endregion

                    #region CommercialTrust

                    string riskRatingComTrust = "";
                    string recommentationComTrust = "";
                    var RiskScoreStrategyComTrust = (getstraCommercialTru / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                    var RiskScoreOperationComTrust = (getoperCommercialtrus / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                    var RiskScoreFinanceComTrust = (getfinancecommercialTru / (double)maximumPossibleFinanceBusinessMgtRating) * financialReportWeight;
                    var RiskScoreComplianceComTrust = (getcomplianceComercial / (double)maximumPossibleComplianceBusinessMgtRating) * complianceWeight;
                    var RiskScoreTimesinceLastauditComTrust = (gettimeSinceLastTrusteeAudit.CommercialTrust / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                    var RiskScoredirectorConcernComTrust = (directorConcernCommercialTrust / (decimal)maximumPossibleEMCRating) * magtConcernWeight;

                    var riskScoreComTrust = (decimal)RiskScoreStrategyComTrust + (decimal)RiskScoreOperationComTrust + (decimal)RiskScoreFinanceComTrust + (decimal)RiskScoreComplianceComTrust + (decimal)RiskScoreTimesinceLastauditComTrust + RiskScoredirectorConcernComTrust;
                    var oldRiskScoreComTrust = 0;
                   
                    if (riskScoreComTrust < 0.4m)
                    {
                        riskRatingComTrust = "Very Low";
                        recommentationComTrust = "Spot Check";
                    }
                    if (riskScoreComTrust >= 0.4m && riskScoreComTrust < 0.5m)
                    {
                        riskRatingComTrust = "Low";
                        recommentationComTrust = "Spot Check";
                    }
                    if (riskScoreComTrust >= 0.5m && riskScoreComTrust < 0.65m)
                    {
                        riskRatingComTrust = "Medium";
                        recommentationComTrust = "Partial Scope";
                    }
                    if (riskScoreComTrust >= 0.65m && riskScoreComTrust < 0.8m)
                    {
                        riskRatingComTrust = "High";
                        recommentationComTrust = "Full Scope";
                    }
                    if (riskScoreComTrust >= 0.8m)
                    {
                        riskRatingComTrust = "Very High";
                        recommentationComTrust = "Full Scope";
                    }

                    #endregion

                    #region PrivateTrust

                    string riskRatingPriTrust = "";
                    string recommentationPriTrust = "";
                    var RiskScoreStrategyPriTrust = (getstraPrivate / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                    var RiskScoreOperationPriTrust = (getoperationPrivateTru / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                    var RiskScoreFinancePriTrust = (getfinancePrivate / (double)maximumPossibleFinanceBusinessMgtRating) * financialReportWeight;
                    var RiskScoreCompliancePriTrust = (getcompliancePrivate / (double)maximumPossibleComplianceBusinessMgtRating) * complianceWeight;
                    var RiskScoreTimesinceLastauditPriTrust = (gettimeSinceLastTrusteeAudit.PrivateTrust / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                    var RiskScoredirectorConcernPriTrust = (directorConcernPrivateTrust / (decimal)maximumPossibleEMCRating) * magtConcernWeight;

                    var riskScorePriTrust = (decimal)RiskScoreStrategyPriTrust + (decimal)RiskScoreOperationPriTrust + (decimal)RiskScoreFinancePriTrust + (decimal)RiskScoreCompliancePriTrust + (decimal)RiskScoreTimesinceLastauditPriTrust + RiskScoredirectorConcernPriTrust;
                    var oldRiskScorePriTrust = 0;
                   
                    if (riskScorePriTrust < 0.4m)
                    {
                        riskRatingPriTrust = "Very Low";
                        recommentationPriTrust = "Spot Check";
                    }
                    if (riskScorePriTrust >= 0.4m && riskScorePriTrust < 0.5m)
                    {
                        riskRatingPriTrust = "Low";
                        recommentationPriTrust = "Spot Check";
                    }
                    if (riskScorePriTrust >= 0.5m && riskScorePriTrust < 0.65m)
                    {
                        riskRatingPriTrust = "Medium";
                        recommentationPriTrust = "Partial Scope";
                    }
                    if (riskScorePriTrust >= 0.65m && riskScorePriTrust < 0.8m)
                    {
                        riskRatingPriTrust = "High";
                        recommentationPriTrust = "Full Scope";
                    }
                    if (riskScorePriTrust >= 0.8m)
                    {
                        riskRatingPriTrust = "Very High";
                        recommentationPriTrust = "Full Scope";
                    }
                    #endregion

                    #region  Log audit universe   

                    var getannualauditId = annualaudit.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                    if (getannualauditId == null)
                    {
                        var logRequestId = AnualAuditUniverseRiskRating.Create(getRating.RequesterName, businessriskratingId);
                        await annualaudit.AddAsync(logRequestId);

                        var logtrusteeAnnualAudit = ARMTrusteeAuditUniverse.Create(getRating.RequesterName, logRequestId.Id);
                        await trusteeAnnualAudit.AddAsync(logtrusteeAnnualAudit);

                        var logcommercialTrustaudit = AuditUniverseARMTrusteeCommercialTrust.Create(logtrusteeAnnualAudit.Id, oldRiskScoreComTrust.ToString("0.000"), businessManagerConcernCommercialTrust, directorCCommercialTrust,
                                           riskScoreComTrust.ToString("0.000"), riskRatingComTrust, recommentationComTrust);
                        await commercialTrustaudit.AddAsync(logcommercialTrustaudit);

                        var logprivateTrustAudit = AuditUniverseARMTrusteePrivateTrust.Create(logtrusteeAnnualAudit.Id, oldRiskScorePriTrust.ToString("0.000"), businessManagerConcernPrivateTrust, directorPrivateTrust,
                                           riskScorePriTrust.ToString("0.000"), riskRatingPriTrust, recommentationPriTrust);
                        await privateTrustAudit.AddAsync(logprivateTrustAudit);
                        getBusinessRiskRating.ApproveBusinessRating();
                        await repo.SaveChangesAsync();

                        return TypedResults.Ok("Approved successfully");
                    }
                    if (getannualauditId != null)
                    {
                        var getaudit = trusteeAnnualAudit.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getannualauditId.Id).FirstOrDefault();
                        if (getaudit != null)
                        {
                            getBusinessRiskRating.ApproveBusinessRating();
                            await repo.SaveChangesAsync();

                            return TypedResults.Ok("Approved successfully");
                        }
                        if (getaudit == null)
                        {
                            var logtrusteeAnnualAudit2 = ARMTrusteeAuditUniverse.Create(getRating.RequesterName, getannualauditId.Id);
                            await trusteeAnnualAudit.AddAsync(logtrusteeAnnualAudit2);

                            var logcommercialTrustaudit2 = AuditUniverseARMTrusteeCommercialTrust.Create(logtrusteeAnnualAudit2.Id, oldRiskScoreComTrust.ToString("0.000"), businessManagerConcernCommercialTrust, directorCCommercialTrust,
                                               riskScoreComTrust.ToString("0.000"), riskRatingComTrust, recommentationComTrust);
                            await commercialTrustaudit.AddAsync(logcommercialTrustaudit2);

                            var logprivateTrustAudit2 = AuditUniverseARMTrusteePrivateTrust.Create(logtrusteeAnnualAudit2.Id, oldRiskScorePriTrust.ToString("0.000"), businessManagerConcernPrivateTrust, directorPrivateTrust,
                                               riskScorePriTrust.ToString("0.000"), riskRatingPriTrust, recommentationPriTrust);
                            await privateTrustAudit.AddAsync(logprivateTrustAudit2);
                            getBusinessRiskRating.ApproveBusinessRating();
                            await repo.SaveChangesAsync();

                            return TypedResults.Ok("Approved successfully");
                        }
                    }
                    #endregion
                    return TypedResults.Ok("Approved successfully");
                }
                return TypedResults.NotFound();

            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }

        }

    }
}
