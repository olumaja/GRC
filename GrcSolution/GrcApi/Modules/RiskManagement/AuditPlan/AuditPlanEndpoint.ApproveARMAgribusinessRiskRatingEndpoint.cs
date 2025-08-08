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
    public class ApproveARMAgribusinessRiskRatingEndpoint
    {
        /// <summary>
        /// Endpoint to approve armagribusiness business risk rating
        /// </summary>
        /// <param name="businessriskratingId"></param>
        /// <param name="armAgri"></param>
        /// <param name="repo"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="agri"></param>
        /// <param name="strategy"></param>
        /// <param name="strategyAAFML"></param>
        /// <param name="strategyRFL"></param>
        /// <param name="operation"></param>
        /// <param name="operationAAFML"></param>
        /// <param name="operRFL"></param>
        /// <param name="finance"></param>
        /// <param name="financeAAFML"></param>
        /// <param name="financeRFL"></param>
        /// <param name="compliance"></param>
        /// <param name="complianceAAFML"></param>
        /// <param name="complianceRFL"></param>
        /// <param name="timeSinceLastAgriAudit"></param>
        /// <param name="emcRating"></param>
        /// <param name="emcRiskRating"></param>
        /// <param name="managementConcernRating"></param>
        /// <param name="mgtConcern"></param>
        /// <param name="mgtRatingbusiness"></param>
        /// <param name="mgtSharedserviceRating"></param>
        /// <param name="annualaudit"></param>
        /// <param name="agriannualaudit"></param>
        /// <param name="rflAudit"></param>
        /// <param name="aafmlAudit"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid businessriskratingId, [FromBody] ARMAgribusinessRatingReq armAgri, IRepository<ARMAgribusinessRating> repo,
            IRepository<BusinessRiskRating> busnessRiskRating, IRepository<ARMAgribusinessRating> agri, IRepository<StrategyAgribusiness> strategy,
            IRepository<StrategyAgribusinessRatingAAFML> strategyAAFML, IRepository<StrategyAgribusinessRatingRFl> strategyRFL,

            IRepository<OperationAgribusiness> operation, IRepository<OperationAgribusinessRatingAAFML> operationAAFML, IRepository<OperationAgribusinessRatingRFl> operRFL,

            IRepository<FinancialAgribusinessReporting> finance, IRepository<FinacialAgribusinessRatingAAFML> financeAAFML,
            IRepository<FinacialAgribusinessRatingRFl> financeRFL,

            IRepository<ComplianceAgribusiness> compliance, IRepository<ComplianceAgribusinessRatingAAFML> complianceAAFML,
            IRepository<ComplianceAgribusinessRatingRFl> complianceRFL, IRepository<TimeSinceLastAgribusinessAudit> timeSinceLastAgriAudit,
            IRepository<EMCConcernRiskRating> emcRating, IRepository<ARMAgribusinessEMCRating> emcRiskRating,
            IRepository<ManagementConcernRiskRating> managementConcernRating, IRepository<ManagementConcernARMAgribusiness> mgtConcern, IRepository<ManagementConcernBusinessUnitARMAgribusinessRating> mgtRatingbusiness, IRepository<ManagementConcernSharedServiceARMAgribusinessRating> mgtSharedserviceRating,

            IRepository<AnualAuditUniverseRiskRating> annualaudit, IRepository<ARMAgribusinessAuditUniverse> agriannualaudit, IRepository<AuditUniverseARMAgribusinessRFL> rflAudit, IRepository<AuditUniverseARMAgribusinessAAFML> aafmlAudit,
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
                var businesses = await agri.GetAllAsync();
                if (getRating == null) { return TypedResults.NotFound(); }
                var getagri = businesses.Find(x => x.BusinessRiskRatingId.Equals(businessriskratingId));
                var getstrategy = strategy.GetContextByConditon(x => x.ARMAgribusinessRatingId == getagri.Id).FirstOrDefault();

                var getstrategyAAFML = strategyAAFML.GetContextByConditon(x => x.StrategyAgribusinessId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();
                var getstrategyRFL = strategyRFL.GetContextByConditon(x => x.StrategyAgribusinessId == getstrategy.Id).Select(x => x.Total).FirstOrDefault();

                var getoperation = operation.GetContextByConditon(x => x.ARMAgribusinessRatingId == getagri.Id).FirstOrDefault();

                var getoperationAAFML = operationAAFML.GetContextByConditon(x => x.OperationAgribusinessId == getoperation.Id).Select(x => x.Total).FirstOrDefault();
                var getoperRFL = operRFL.GetContextByConditon(x => x.OperationAgribusinessId == getoperation.Id).Select(x => x.Total).FirstOrDefault();

                var getfinance = finance.GetContextByConditon(x => x.ARMAgribusinessRatingId == getagri.Id).FirstOrDefault();

                var getfinanceAAFML = financeAAFML.GetContextByConditon(x => x.FinancialAgribusinessReportingId == getfinance.Id).Select(x => x.Total).FirstOrDefault();
                var getfinanceRFL = financeRFL.GetContextByConditon(x => x.FinancialAgribusinessReportingId == getfinance.Id).Select(x => x.Total).FirstOrDefault();

                var getcompliance = compliance.GetContextByConditon(x => x.ARMAgribusinessRatingId == getagri.Id).FirstOrDefault();

                var getcomplianceAAFML = complianceAAFML.GetContextByConditon(x => x.ComplianceAgribusinessId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();
                var getcomplianceRFL = complianceRFL.GetContextByConditon(x => x.ComplianceAgribusinessId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();

                var gettimeSinceLastAgriAudit = timeSinceLastAgriAudit.GetContextByConditon(x => x.ARMAgribusinessRatingId == getagri.Id).FirstOrDefault();

                ////emc rating
                //var getEMCRatingRating = emcRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                //var getEmcConcernRating = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == getEMCRatingRating.Id).FirstOrDefault();

                ////mc concern rating
                //var getMCRatingRating = managementConcernRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                //var getMCConcernRating = mgtConcern.GetContextByConditon(x => x.ManagementConcernRiskRatingId == getMCRatingRating.Id).FirstOrDefault();
                //var getMgtRatingbusiness = mgtRatingbusiness.GetContextByConditon(x => x.ManagementConcernARMAgribusinessId == getMCConcernRating.Id).FirstOrDefault();
                //var getMgtSharedService = mgtSharedserviceRating.GetContextByConditon(x => x.ManagementConcernARMAgribusinessId == getMCConcernRating.Id).FirstOrDefault();

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

               // var businessManagerConcernARL = getMgtRatingbusiness.RFL;
               // var businessManagerConcernAAFML = getMgtRatingbusiness.AAFML;
                // individual director Concern
                //var directorRFL = getEmcConcernRating.RFL + getMgtRatingbusiness.RFL;
                //var directorAAFML = getEmcConcernRating.AAFML + getMgtRatingbusiness.AAFML;

                //var directorConcernRFL = getEmcConcernRating.RFL + getMgtRatingbusiness.RFL;
                //var directorConcernAAFML = getEmcConcernRating.AAFML + getMgtRatingbusiness.AAFML;

                #region MC and EMC Concern
                //  //EMC                             
                var getEMCRating = emcRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).ToList();
                var allEmcConcernRFL = new List<decimal>();
                var allEmcConcernAAFML = new List<decimal>();

                foreach (var item1 in getEMCRating)
                {
                    var getEmcConcernRFL = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.RFL).ToList();
                    allEmcConcernRFL.AddRange(getEmcConcernRFL);

                    var getEmcConcernAAFML = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.AAFML).ToList();
                    allEmcConcernAAFML.AddRange(getEmcConcernAAFML);
                }
                // Calculate the sum and average for the first three records
                var recordRFL = allEmcConcernRFL.ToList();
                var recordAAFM = allEmcConcernAAFML.ToList();

                decimal sumRFL = recordRFL.Sum();
                decimal sumAAFM = recordAAFM.Sum();

                decimal averageEMCRFL = recordRFL.Any() ? recordRFL.Average() : 0;
                decimal averageEMCAAFM = recordAAFM.Any() ? recordAAFM.Average() : 0;

                //  //mc rating

                var getMCRating = managementConcernRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).ToList();
                var allMCConcernRFL = new List<decimal>();
                var allMCConcernAAFML = new List<decimal>();
                foreach (var item2 in getMCRating)
                {
                    var getMCConcern = mgtConcern.GetContextByConditon(x => x.ManagementConcernRiskRatingId == item2.Id).ToList();
                    if (getMCConcern.Any())
                    {
                        var getbusMCRatingRFL = mgtRatingbusiness.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernARMAgribusinessId)).Select(x => x.RFL).ToList();
                        allMCConcernRFL.AddRange(getbusMCRatingRFL);

                        var getbusMCRatingAAFML = mgtRatingbusiness.GetContextByConditon(x => getMCConcern.Select(y => y.Id).Contains(x.ManagementConcernARMAgribusinessId)).Select(x => x.AAFML).ToList();
                        allMCConcernAAFML.AddRange(getbusMCRatingAAFML);
                    }
                }
                var recordMCRFL = allMCConcernRFL.ToList();
                var recordMCAAFML = allMCConcernAAFML.ToList();
                //  decimal sumMC = recordMC.Sum();
                decimal averageMCRFL = recordMCRFL.Any() ? recordMCRFL.Average() : 0;
                decimal averageMCAAFML = recordMCAAFML.Any() ? recordMCAAFML.Average() : 0;

                var businessManagerConcernARL = averageMCRFL;
                var businessManagerConcernAAFML = averageMCAAFML;

                var directorRFL = averageEMCRFL;
                var directorAAFML = averageEMCAAFM;

                var directorConcernRFL = businessManagerConcernARL + directorRFL;
                var directorConcernAAFML = businessManagerConcernAAFML + directorAAFML;

                #endregion

                #region Agri RFL

                string riskRating = "";
                string recommentation = "";
                var oldRiskScore = 0;
                var RiskScoreStrategy = (getstrategyRFL / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                var RiskScoreOperation = (getoperRFL / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                var RiskScoreFinance = (getfinanceRFL / (double)maximumPossibleFinanceBusinessMgtRating) * financialReportWeight;
                var RiskScoreCompliance = (getcomplianceRFL / (double)maximumPossibleComplianceBusinessMgtRating) * complianceWeight;
                var RiskScoreTimesinceLastaudit = (gettimeSinceLastAgriAudit.RFl / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                var RiskScoredirectorConcern = (directorConcernRFL / (decimal)maximumPossibleEMCRating) * magtConcernWeight;

                var riskScore = (decimal)RiskScoreStrategy + (decimal)RiskScoreOperation + (decimal)RiskScoreFinance + (decimal)RiskScoreCompliance + (decimal)RiskScoreTimesinceLastaudit + RiskScoredirectorConcern;
               
                if (riskScore < 0.4m)
                {
                    riskRating = "Very Low";
                    recommentation = "Spot Check";
                }
                if (riskScore >= 0.4m && riskScore < 0.5m)
                {
                    riskRating = "Low";
                    recommentation = "Spot Check";
                }
                if (riskScore >= 0.5m && riskScore < 0.65m)
                {
                    riskRating = "Medium";
                    recommentation = "Partial Scope";
                }
                if (riskScore >= 0.65m && riskScore < 0.8m)
                {
                    riskRating = "High";
                    recommentation = "Full Scope";
                }
                if (riskScore >= 0.8m)
                {
                    riskRating = "Very High";
                    recommentation = "Full Scope";
                }
                #endregion

                #region Agri AAFML

                string riskRatingAAFML = "";
                string recommentationAAFML = "";
                var oldRiskScoreAAFML = 0;
                var RiskScoreStrategyAAFML = (getstrategyAAFML / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                var RiskScoreOperationAAFML = (getoperationAAFML / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                var RiskScoreFinanceAAFML = (getfinanceAAFML / (double)maximumPossibleFinanceBusinessMgtRating) * financialReportWeight;
                var RiskScoreComplianceAAFML = (getcomplianceAAFML / (double)maximumPossibleComplianceBusinessMgtRating) * complianceWeight;
                var RiskScoreTimesinceLastauditAAFML = (gettimeSinceLastAgriAudit.AAFML / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                var RiskScoredirectorConcernAAFML = (directorConcernAAFML / (decimal)maximumPossibleEMCRating) * magtConcernWeight;

                var riskScoreAAFML = (decimal)RiskScoreStrategyAAFML + (decimal)RiskScoreOperationAAFML + (decimal)RiskScoreFinanceAAFML + (decimal)RiskScoreComplianceAAFML + (decimal)RiskScoreTimesinceLastauditAAFML + RiskScoredirectorConcernAAFML;
               
                if (riskScoreAAFML < 0.4m)
                {
                    riskRatingAAFML = "Very Low";
                    recommentationAAFML = "Spot Check";
                }
                if (riskScoreAAFML >= 0.4m && riskScoreAAFML < 0.5m)
                {
                    riskRatingAAFML = "Low";
                    recommentationAAFML = "Spot Check";
                }
                if (riskScoreAAFML >= 0.5m && riskScoreAAFML < 0.65m)
                {
                    riskRatingAAFML = "Medium";
                    recommentationAAFML = "Partial Scope";
                }
                if (riskScoreAAFML >= 0.65m && riskScoreAAFML < 0.8m)
                {
                    riskRatingAAFML = "High";
                    recommentationAAFML = "Full Scope";
                }
                if (riskScoreAAFML >= 0.8m)
                {
                    riskRatingAAFML = "Very High";
                    recommentationAAFML = "Full Scope";
                }
                #endregion

                #region  log audit universe  

                var getannualauditId = annualaudit.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                if (getannualauditId == null)
                {
                    var logRequestId = AnualAuditUniverseRiskRating.Create(getRating.RequesterName, businessriskratingId);
                    await annualaudit.AddAsync(logRequestId);

                    var logagriannualaudit = ARMAgribusinessAuditUniverse.Create(getRating.RequesterName, logRequestId.Id);
                    await agriannualaudit.AddAsync(logagriannualaudit);

                    var logrflAudit = AuditUniverseARMAgribusinessRFL.Create(logagriannualaudit.Id, oldRiskScore.ToString("0.000"), businessManagerConcernARL, directorRFL,
                                        riskScore.ToString("0.000"), riskRating, recommentation);
                    await rflAudit.AddAsync(logrflAudit);

                    var logaafmlAudit = AuditUniverseARMAgribusinessAAFML.Create(logagriannualaudit.Id, oldRiskScoreAAFML.ToString("0.000"), businessManagerConcernAAFML, directorAAFML,
                                       riskScoreAAFML.ToString("0.000"), riskRatingAAFML, recommentationAAFML);
                    await aafmlAudit.AddAsync(logaafmlAudit);

                    getBusinessRiskRating.ApproveBusinessRating();
                    await repo.SaveChangesAsync();
                    return TypedResults.Ok("Approved successfully");
                }
                if (getannualauditId != null)
                {
                    var getaudit = agriannualaudit.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getannualauditId.Id).FirstOrDefault();
                    if (getaudit != null)
                    {
                        getBusinessRiskRating.ApproveBusinessRating();
                        await repo.SaveChangesAsync();
                        return TypedResults.Ok("Approved successfully");
                    }
                    if (getaudit == null)
                    {
                        var logagriannualaudit2 = ARMAgribusinessAuditUniverse.Create(getRating.RequesterName, getannualauditId.Id);
                        await agriannualaudit.AddAsync(logagriannualaudit2);

                        var logrflAudit2 = AuditUniverseARMAgribusinessRFL.Create(logagriannualaudit2.Id, oldRiskScore.ToString("0.000"), businessManagerConcernARL, directorRFL,
                                            riskScore.ToString("0.000"), riskRating, recommentation);
                        await rflAudit.AddAsync(logrflAudit2);

                        var logaafmlAudit2 = AuditUniverseARMAgribusinessAAFML.Create(logagriannualaudit2.Id, oldRiskScoreAAFML.ToString("0.000"), businessManagerConcernAAFML, directorAAFML,
                                           riskScoreAAFML.ToString("0.000"), riskRatingAAFML, recommentationAAFML);
                        await aafmlAudit.AddAsync(logaafmlAudit2);

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
