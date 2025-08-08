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
    public class ApproveARMSecurityBusinessRiskRatingEndpoint
    {

        /// <summary>
        /// Endpoint to approve armsecurity business risk rating
        /// </summary>
        /// <param name="businessriskratingId"></param>
        /// <param name="armsecurityReq"></param>
        /// <param name="repo"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="security"></param>
        /// <param name="strategy"></param>
        /// <param name="strategyStockBro"></param>
        /// <param name="operation"></param>
        /// <param name="operStockBro"></param>
        /// <param name="finance"></param>
        /// <param name="financeStockbro"></param>
        /// <param name="compliance"></param>
        /// <param name="compliancestockbro"></param>
        /// <param name="timeSinceLastSecurityAudit"></param>
        /// <param name="emcRating"></param>
        /// <param name="emcRiskRating"></param>
        /// <param name="managementConcernRating"></param>
        /// <param name="mgtConcern"></param>
        /// <param name="mgtRatingbusiness"></param>
        /// <param name="mgtSharedserviceRating"></param>
        /// <param name="annualaudit"></param>
        /// <param name="securityannualAudit"></param>
        /// <param name="InvestmentBankingAudit"></param>
        /// <param name="StockBrokingaudit"></param>
        /// <param name="researchaudit"></param>
        /// <param name="currentUserService"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid businessriskratingId, [FromBody] ARMSecurityRatingReq armsecurityReq, IRepository<ARMSecurityRating> repo,
            IRepository<BusinessRiskRating> busnessRiskRating,
            IRepository<ARMSecurityRating> security, IRepository<StrategySecurityBusinessRating> strategy, IRepository<StrategySecurityRatingStockBroking> strategyStockBro, 

            IRepository<OperationSecurityBusinessRating> operation, IRepository<OperationSecurityRatingStockBroking> operStockBro, 

            IRepository<FinancialSecurityReporting> finance, IRepository<FinacialSecurityRatingStockBroking> financeStockbro, IRepository<ComplianceSecurity> compliance,
            IRepository<ComplianceSecurityRatingStockBroking> compliancestockbro,
            IRepository<TimeSinceLastSecurityAudit> timeSinceLastSecurityAudit, IRepository<EMCConcernRiskRating> emcRating, IRepository<ARMSecurityEMCRating> emcRiskRating,
            IRepository<ManagementConcernRiskRating> managementConcernRating, IRepository<ManagementConcernARMSecurity> mgtConcern, IRepository<ManagementConcernBusinessUnitARMSecurityRating> mgtRatingbusiness, 
            IRepository<ManagementConcernSharedServiceARMSecurityRating> mgtSharedserviceRating,

            IRepository<AnualAuditUniverseRiskRating> annualaudit, IRepository<ARMSecurityAnnualAuditUniverse> securityannualAudit, IRepository<AuditUniverseARMSecurityStockBroking> StockBrokingaudit, ICurrentUserService currentUserService,

            ClaimsPrincipal user)
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
                var getsecurity = security.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();

                var getstrategy = strategy.GetContextByConditon(x => x.ARMSecurityRatingId == getsecurity.Id).FirstOrDefault();

                var getstrategyStockBro = strategyStockBro.GetContextByConditon(x => x.StrategySecurityBusinessRatingId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();

                var getoperation = operation.GetContextByConditon(x => x.ARMSecurityRatingId == getsecurity.Id).FirstOrDefault();

                var getoperStockBro = operStockBro.GetContextByConditon(x => x.OperationSecurityBusinessRatingId == getoperation.Id).Select(x => x.Total).FirstOrDefault();

                var getfinance = finance.GetContextByConditon(x => x.ARMSecurityRatingId == getsecurity.Id).FirstOrDefault();

                var getfinanceStockbro = financeStockbro.GetContextByConditon(x => x.FinancialSecurityReportingId == getfinance.Id).Select(x => x.Total).FirstOrDefault();

                var getcompliance = compliance.GetContextByConditon(x => x.ARMSecurityRatingId == getsecurity.Id).FirstOrDefault();

                var getcompliancestockbro = compliancestockbro.GetContextByConditon(x => x.ComplianceSecurityId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();

                var gettimeSinceLastSecurityAudit = timeSinceLastSecurityAudit.GetContextByConditon(x => x.ARMSecurityRatingId == getsecurity.Id).FirstOrDefault();

                ////emc rating
                //var getEMCRatingRating = emcRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                //var getEmcConcernRating = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == getEMCRatingRating.Id).FirstOrDefault();

                ////mc concern rating
                //var getMCRatingRating = managementConcernRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                //var getMCConcernRating = mgtConcern.GetContextByConditon(x => x.ManagementConcernRiskRatingId == getMCRatingRating.Id).FirstOrDefault();
                //var getMgtRatingbusiness = mgtRatingbusiness.GetContextByConditon(x => x.ManagementConcernARMSecurityId == getMCConcernRating.Id).FirstOrDefault();
                //var getMgtSharedService = mgtSharedserviceRating.GetContextByConditon(x => x.ManagementConcernARMSecurityId == getMCConcernRating.Id).FirstOrDefault();

                var maximumPossibleStrategyBusinessMgtRating = 3 * 32;
                var maximumPossibleOperationBusinessMgtRating = 3 * 20;
                var maximumPossibleFinanceBusinessMgtRating = 3 * 7;
                var maximumPossibleComplianceBusinessMgtRating = 3 * 11;
                var maximumPossibleTimeSinceLastAuditBusinessMgtRating = 3 * 1;
                var maximumPossibledirectorConcernRating = 3 * 2;

                var strategyWeight = 0.20; // 0.25; 
                var operationWeight = 0.20; // 0.15;
                var financialReportWeight = 0.15; // 0.20;
                var complianceWeight = 0.15; // 0.20;
                var magtConcernWeight = 0.15m; // 0.075;
                var timeSinceLastAuditWeight = 0.15; // 0.05;


                // individual director Concern
                // var businessManagerConcernStockBroking = getMgtRatingbusiness.StockBroking;
                // var directorStockBroking = getEmcConcernRating.StockBroking;
                // var directorConcernStockBroking = getEmcConcernRating.StockBroking + getMgtRatingbusiness.StockBroking;

                #region MC and EMC Concern
                //  //EMC                             
                var getEMCRating = emcRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).ToList();
                var allEmcConcern = new List<decimal>(); 

                foreach (var item1 in getEMCRating)
                {
                    var getEmcConcernStock = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.StockBroking).ToList();
                    allEmcConcern.AddRange(getEmcConcernStock); 
                }
                // Calculate the sum and average for the first three records
                var records = allEmcConcern.ToList();
                decimal sum = records.Sum();
                decimal averageEMC = records.Any() ? records.Average() : 0;

                //  //emc rating

                var getMCRating = managementConcernRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).ToList();
                var allMCConcernStock = new List<decimal>();
                foreach (var item2 in getMCRating)
                {
                    var getMCConcernDFS = mgtConcern.GetContextByConditon(x => x.ManagementConcernRiskRatingId == item2.Id).ToList();
                    if (getMCConcernDFS.Any())
                    {
                        var getbusdfsMCRating = mgtRatingbusiness.GetContextByConditon(x => getMCConcernDFS.Select(y => y.Id).Contains(x.ManagementConcernARMSecurityId)).Select(x => x.StockBroking).ToList();
                        allMCConcernStock.AddRange(getbusdfsMCRating);
                    }
                }
                var recordMC = allMCConcernStock.ToList();
                decimal sumMC = recordMC.Sum();
                decimal averageMC = recordMC.Any() ? recordMC.Average() : 0;

                var businessManagerConcernStockBroking = averageMC;
                var directorStockBroking = averageEMC; 

                var directorConcernStockBroking = businessManagerConcernStockBroking + directorStockBroking;

                #endregion



                #region StockBroking

                string riskRatingSBrock = "";
                string recommentationSBrock = "";
                var RiskScoreStrategySBrock = (getstrategyStockBro / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                var RiskScoreOperationSBrock = (getoperStockBro / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                var RiskScoreFinanceSBrock = (getfinanceStockbro / (double)maximumPossibleFinanceBusinessMgtRating) * financialReportWeight;
                var RiskScoreComplianceSBrock = (getcompliancestockbro / (double)maximumPossibleComplianceBusinessMgtRating) * complianceWeight;
                var RiskScoreTimesinceLastauditSBrock = (gettimeSinceLastSecurityAudit.StockBroking / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                var RiskScoredirectorConcernSBrock = (directorConcernStockBroking / (decimal)maximumPossibledirectorConcernRating) * magtConcernWeight;

                var riskScoreSBrock = (decimal)RiskScoreStrategySBrock + (decimal)RiskScoreOperationSBrock + (decimal)RiskScoreFinanceSBrock + (decimal)RiskScoreComplianceSBrock + (decimal)RiskScoreTimesinceLastauditSBrock + RiskScoredirectorConcernSBrock;
                var oldRiskScoreSBrock = 0;
               
                if (riskScoreSBrock < 0.4m)
                {
                    riskRatingSBrock = "Very Low";
                    recommentationSBrock = "Spot Check";
                }
                if (riskScoreSBrock >= 0.4m && riskScoreSBrock < 0.5m)
                {
                    riskRatingSBrock = "Low";
                    recommentationSBrock = "Spot Check";
                }
                if (riskScoreSBrock >= 0.5m && riskScoreSBrock < 0.65m)
                {
                    riskRatingSBrock = "Medium";
                    recommentationSBrock = "Partial Scope";
                }
                if (riskScoreSBrock >= 0.65m && riskScoreSBrock < 0.8m)
                {
                    riskRatingSBrock = "High";
                    recommentationSBrock = "Full Scope";
                }
                if (riskScoreSBrock >= 0.8m)
                {
                    riskRatingSBrock = "Very High";
                    recommentationSBrock = "Full Scope";
                }

                #endregion
                           
                #region  Log audit universe   

                var getannualauditId = annualaudit.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                if (getannualauditId == null)
                {
                    var logRequestId = AnualAuditUniverseRiskRating.Create(getRating.RequesterName, businessriskratingId);
                    await annualaudit.AddAsync(logRequestId);

                    var logsecurityannualAudit = ARMSecurityAnnualAuditUniverse.Create(getRating.RequesterName, logRequestId.Id);
                    await securityannualAudit.AddAsync(logsecurityannualAudit);

                    var logStockBrokingaudit = AuditUniverseARMSecurityStockBroking.Create(logsecurityannualAudit.Id, oldRiskScoreSBrock.ToString("0.000"), businessManagerConcernStockBroking, directorStockBroking,
                                       riskScoreSBrock.ToString("0.000"), riskRatingSBrock, recommentationSBrock);
                    await StockBrokingaudit.AddAsync(logStockBrokingaudit);
                                       
                    getBusinessRiskRating.ApproveBusinessRating();
                    await repo.SaveChangesAsync();

                    return TypedResults.Ok("Approved successfully");
                }
                if (getannualauditId != null)
                {
                    var getaudit = securityannualAudit.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getannualauditId.Id).FirstOrDefault();
                    if (getaudit != null)
                    {
                        getBusinessRiskRating.ApproveBusinessRating();
                        await repo.SaveChangesAsync();

                        return TypedResults.Ok("Approved successfully");
                    }
                    if (getaudit == null)
                    {
                        var logsecurityannualAudit2 = ARMSecurityAnnualAuditUniverse.Create(getRating.RequesterName, getannualauditId.Id);
                        await securityannualAudit.AddAsync(logsecurityannualAudit2);
                                               
                        var logStockBrokingaudit2 = AuditUniverseARMSecurityStockBroking.Create(logsecurityannualAudit2.Id, oldRiskScoreSBrock.ToString("0.000"), businessManagerConcernStockBroking, directorStockBroking,
                                           riskScoreSBrock.ToString("0.000"), riskRatingSBrock, recommentationSBrock);
                        await StockBrokingaudit.AddAsync(logStockBrokingaudit2);
                                                
                        getBusinessRiskRating.ApproveBusinessRating();
                        await repo.SaveChangesAsync();

                        return TypedResults.Ok("Approved successfully");
                    }
                }
                #endregion
                getBusinessRiskRating.ApproveBusinessRating();
                await repo.SaveChangesAsync();
                return TypedResults.Ok("Approved successfully");

            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }

        }

    }
}
