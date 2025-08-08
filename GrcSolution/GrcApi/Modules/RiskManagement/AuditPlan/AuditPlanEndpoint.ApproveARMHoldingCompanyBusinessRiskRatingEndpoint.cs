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
* Endpoint to approve armholdingcompany business risk rating
*/
    public class ApproveARMHoldingCompanyBusinessRiskRatingEndpoint
    {

        /// <summary>
        /// Endpoint to approve armholdingcompany business risk rating
        /// </summary>
        /// <param name="businessriskratingId"></param>
        /// <param name="request"></param>
        /// <param name="armholdco"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="armHoldcorating"></param>
        /// <param name="strategylog"></param>
        /// <param name="strategyrating"></param>
        /// <param name="strategytreasurysale"></param>
        /// <param name="operationlog"></param>
        /// <param name="operationrating"></param>
        /// <param name="operationtreasurysale"></param>
        /// <param name="financelog"></param>
        /// <param name="financerating"></param>
        /// <param name="financeTreasurysale"></param>
        /// <param name="complianceRating"></param>
        /// <param name="compliancelog"></param>
        /// <param name="complianceTreasurysale"></param>
        /// <param name="timesinceaudit"></param>
        /// <param name="emcRating"></param>
        /// <param name="armholdcoEMCRating"></param>
        /// <param name="annualaudit"></param>
        /// <param name="armholdcoauditUniverse"></param>
        /// <param name="armholdcoUniverse"></param>
        /// <param name="armHoldCoTreasurySale"></param>
        /// <param name="currentUserService"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid businessriskratingId, [FromBody] ARMHoldingCompanyRatingReq request, IRepository<ARMHoldingCompanyBusinessRating> armholdco,
             IRepository<BusinessRiskRating> busnessRiskRating, IRepository<ARMHoldingCompanyBusinessRating> armHoldcorating, IRepository<StrategyBusinessRatingARMHoldCo> strategylog, IRepository<StrategyBusinessArmHoldCo> strategyrating,

            IRepository<StrategyBusinessTreasurySale> strategytreasurysale, IRepository<OperationBusinessRatingARMHoldCo> operationlog, IRepository<OperationBusinessArmHolco> operationrating, IRepository<OperationBusinessTreasurySale> operationtreasurysale,
            IRepository<FinancialReportingBusinessratingARMHoldCo> financelog, IRepository<FinacialRatingBusinessratingARMHoldCo> financerating, IRepository<FinacialRatingBusinessratingTreasurySale> financeTreasurysale,
            IRepository<ComplianceBusinessRatingARMHoldCo> complianceRating, IRepository<CompliancesBusinessRiskRatingARMHoldCo> compliancelog,
            IRepository<CompliancesBusinessTreasurySale> complianceTreasurysale, IRepository<TimeSinceLastAuditBusinessRatingARMHoldCo> timesinceaudit,
            IRepository<EMCConcernRiskRating> emcRating, IRepository<ARMHoldingCompanyEMCRating> armholdcoEMCRating,

            IRepository<AnualAuditUniverseRiskRating> annualaudit, IRepository<ARMHoldingCompanyAnnualAuditUniverse> armholdcoauditUniverse,
            IRepository<AuditUniverseARMHoldingCompany> armholdcoUniverse, IRepository<AuditUniverseARMHoldCoTreasurySale> armHoldCoTreasurySale,
            ICurrentUserService currentUserService,
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

                var getBusinessRiskRating = armholdco.GetContextByConditon(c => c.BusinessRiskRatingId == businessriskratingId && c.Status != BusinessRiskRatingStatus.Approved).FirstOrDefault();
                if (getBusinessRiskRating == null) { return TypedResults.NotFound("The record has been previouly approved"); }
                var getarmholdcoRating = busnessRiskRating.GetContextByConditon(x => x.Id == businessriskratingId).FirstOrDefault();
                var updatebusinessRiskRating = busnessRiskRating.GetContextByConditon(c => c.Id == businessriskratingId && c.Status != BusinessRiskRatingStatus.Approved).FirstOrDefault();
                var businesses = await armHoldcorating.GetAllAsync();
                if (getarmholdcoRating == null) { return TypedResults.NotFound(); }

                var gearmHoldcorating = businesses.Find(x => x.BusinessRiskRatingId.Equals(businessriskratingId));

                var getstrategylog = strategylog.GetContextByConditon(x => x.ARMHoldingCompanyBusinessRatingId == gearmHoldcorating.Id).FirstOrDefault();

                var getstrategyrating = strategyrating.GetContextByConditon(x => x.StrategyBusinessRatingARMHoldCoId == getstrategylog.Id).FirstOrDefault();
                var getstrategytreasurysale = strategytreasurysale.GetContextByConditon(x => x.StrategyBusinessRatingARMHoldCoId == getstrategylog.Id).FirstOrDefault();

                var getoperationlog = operationlog.GetContextByConditon(x => x.ARMHoldingCompanyBusinessRatingId == gearmHoldcorating.Id).FirstOrDefault();

                var getoperationrating = operationrating.GetContextByConditon(x => x.OperationBusinessRatingARMHoldCoId == getoperationlog.Id).FirstOrDefault();
                var getoperationtreasurysale = operationtreasurysale.GetContextByConditon(x => x.OperationBusinessRatingARMHoldCoId == getoperationlog.Id).FirstOrDefault();

                var getfinancelog = financelog.GetContextByConditon(x => x.ARMHoldingCompanyBusinessRatingId == gearmHoldcorating.Id).FirstOrDefault();

                var getfinancerating = financerating.GetContextByConditon(x => x.FinancialReportingBusinessratingARMHoldCoId == getfinancelog.Id).FirstOrDefault();
                var getfinanceTreasurysale = financeTreasurysale.GetContextByConditon(x => x.FinancialReportingBusinessratingARMHoldCoId == getfinancelog.Id).FirstOrDefault();

                var getcomplianceRating = complianceRating.GetContextByConditon(x => x.ARMHoldingCompanyBusinessRatingId == gearmHoldcorating.Id).FirstOrDefault();

                var getcompliancelog = compliancelog.GetContextByConditon(x => x.ComplianceBusinessRatingARMHoldCoId == getcomplianceRating.Id).FirstOrDefault();
                var getcomplianceTreasurysale = complianceTreasurysale.GetContextByConditon(x => x.ComplianceBusinessRatingARMHoldCoId == getcomplianceRating.Id).FirstOrDefault();

                ////emc rating
                //var getEMCRatingRating = emcRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                //var getEmcConcernarmholdcoRating = armholdcoEMCRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == getEMCRatingRating.Id).FirstOrDefault();

                var complianceARMHolcoTotal = getcompliancelog.Total;
                var complianceTreasurysaleTotal = getcomplianceTreasurysale.Total;

                var gettimesinceaudit = timesinceaudit.GetContextByConditon(x => x.ARMHoldingCompanyBusinessRatingId == gearmHoldcorating.Id).FirstOrDefault();

                var timesinceauditArmHoldCo = gettimesinceaudit.ARMHoldingCompany;
                var timesinceauditTreasurySale = gettimesinceaudit.TreasurySale;

                var maximumPossibleStrategyBusinessMgtRating = 3 * 32;
                var maximumPossibleOperationBusinessMgtRating = 3 * 20;
                var maximumPossibleFinanceBusinessMgtRating = 3 * 7;
                var maximumPossibleComplianceBusinessMgtRating = 3 * 11;
                var maximumPossibleTimeSinceLastAuditBusinessMgtRating = 3 * 1;
                var maximumPossibleEMCRating = 3 * 2;
                var strategyWeight = 0.20; // 0.25; 
                var operationWeight = 0.20; // 0.15;
                var financialReportWeight = 0.15; // 0.20;
                var complianceWeight = 0.15; // 0.20;
                var magtConcernWeight = 0.15m; // 0.075;
                var timeSinceLastAuditWeight = 0.15; // 0.05;

                #region MC and EMC Concern
                //  //EMC                             
                var getEMCRating = emcRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).ToList();
                var allEmcConcernARMHoldingCompany = new List<decimal>();
                var allEmcConcernTreasurySales = new List<decimal>();

                foreach (var item1 in getEMCRating)
                {
                    var getEmcConcernARMHoldingCompany = armholdcoEMCRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.ARMHoldingCompany).ToList();
                    allEmcConcernARMHoldingCompany.AddRange(getEmcConcernARMHoldingCompany);

                    var getEmcConcernTreasurySales = armholdcoEMCRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.TreasurySales).ToList();
                    allEmcConcernTreasurySales.AddRange(getEmcConcernTreasurySales);
                }
                // Calculate the sum and average for the first three records
                var recordARMHoldingCompany = allEmcConcernARMHoldingCompany.ToList();
                var recordTreasurySales = allEmcConcernTreasurySales.ToList();

                decimal sumARMHoldingCompany = recordARMHoldingCompany.Sum();
                decimal sumTreasurySales = recordTreasurySales.Sum();

                decimal averageEMCARMHoldingCompany = recordARMHoldingCompany.Any() ? recordARMHoldingCompany.Average() : 0;
                decimal averageEMCTreasurySales = recordTreasurySales.Any() ? recordTreasurySales.Average() : 0;

                var businessManagerConcernARmHoldCo = averageEMCARMHoldingCompany;
                var businessManagerConcernTreasurySale = averageEMCTreasurySales;

                var mgtConcernHolCo = businessManagerConcernARmHoldCo + businessManagerConcernARmHoldCo;
                var mgtConcernTreasales = businessManagerConcernTreasurySale + businessManagerConcernTreasurySale;

                #endregion


                #region Risk score Holdco
                // operation and time since last audit rating will not be added on the riskscore
                string riskRating = "";
                string recommentation = "";

                var RiskScoreStrategyHoldco = (getstrategyrating.Total / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                var RiskScoreFinanceHoldco = (getfinancerating.Total / (double)maximumPossibleFinanceBusinessMgtRating) * financialReportWeight;
                var RiskScoreComplianceHoldco = (getcompliancelog.Total / (double)maximumPossibleComplianceBusinessMgtRating) * complianceWeight;
                var RiskScoreEMCRatingHolco = (mgtConcernHolCo / (decimal)maximumPossibleEMCRating) * magtConcernWeight;

                var scoreHoldco = (decimal)RiskScoreStrategyHoldco + (decimal)RiskScoreFinanceHoldco + (decimal)RiskScoreComplianceHoldco + RiskScoreEMCRatingHolco;
                var riskScore = (scoreHoldco / 65) * 100;
                var oldscore = 0;
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

                #region Risk score TreasurySale

                var RiskScoreOperationTreasurySale = (getoperationtreasurysale.Total / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                var RiskScoreTimesinceLastauditTreasurySale = (gettimesinceaudit.TreasurySale / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                var RiskScoreEMCRatingTreasurySale = (mgtConcernTreasales / (decimal)maximumPossibleEMCRating) * magtConcernWeight;

                var score = (decimal)RiskScoreOperationTreasurySale + (decimal)RiskScoreTimesinceLastauditTreasurySale + RiskScoreEMCRatingTreasurySale;
                var riskScoreTreasurySale = (score / 50) * 100;

                var oldscoreTreasale = 0;
                var riskRatingTreasale = "";
                var recommentationTreasale = "";
                if (riskScoreTreasurySale > 0.4m)
                {
                    riskRatingTreasale = "Very Low";
                    recommentationTreasale = "Spot Check";
                }

                if (riskScoreTreasurySale >= 0.4m && riskScoreTreasurySale < 0.5m)
                {
                    riskRatingTreasale = "Low";
                    recommentationTreasale = "Spot Check";
                }
                if (riskScoreTreasurySale >= 0.5m && riskScoreTreasurySale < 0.65m)
                {
                    riskRatingTreasale = "Medium";
                    recommentationTreasale = "Partial Scope";
                }
                if (riskScoreTreasurySale >= 0.65m && riskScoreTreasurySale < 0.8m)
                {
                    riskRatingTreasale = "High";
                    recommentationTreasale = "Full Scope";
                }               
                if (riskScoreTreasurySale >= 0.8m)
                {
                    riskRatingTreasale = "Very High";
                    recommentationTreasale = "Full Scope";
                }
                #endregion
                

                #region log req
                var getannualauditId = annualaudit.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                if (getannualauditId == null)
                {
                    var logRequestId = AnualAuditUniverseRiskRating.Create(getarmholdcoRating.RequesterName, businessriskratingId);
                    await annualaudit.AddAsync(logRequestId);

                    var armHoldco = ARMHoldingCompanyAnnualAuditUniverse.Create(getarmholdcoRating.RequesterName, logRequestId.Id);
                    await armholdcoauditUniverse.AddAsync(armHoldco);

                    var logarmholdco = AuditUniverseARMHoldingCompany.Create(armHoldco.Id, oldscore.ToString("0.000"), businessManagerConcernARmHoldCo, businessManagerConcernARmHoldCo,
                                        riskScore.ToString("0.000"), riskRating, recommentation);
                    await armholdcoUniverse.AddAsync(logarmholdco);

                    var logarmHoldCoTreasurySale = AuditUniverseARMHoldCoTreasurySale.Create(armHoldco.Id, oldscoreTreasale.ToString("0.000"), businessManagerConcernTreasurySale, businessManagerConcernTreasurySale,
                                        riskScoreTreasurySale.ToString("0.000"), riskRatingTreasale, recommentationTreasale);
                    await armHoldCoTreasurySale.AddAsync(logarmHoldCoTreasurySale);

                    getBusinessRiskRating.ApproveARMHoldingCompanyBusinessRating();
                    await armholdco.SaveChangesAsync();
                    return TypedResults.Ok("Approved successfully");
                }
                if (getannualauditId != null)
                {
                    var getaudit = armholdcoauditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getannualauditId.Id).FirstOrDefault();
                    if (getaudit != null)
                    {
                        getBusinessRiskRating.ApproveARMHoldingCompanyBusinessRating();
                        await armholdco.SaveChangesAsync();
                        return TypedResults.Ok("Approved successfully");
                    }
                    if (getaudit == null)
                    {
                        var armHoldco2 = ARMHoldingCompanyAnnualAuditUniverse.Create(getarmholdcoRating.RequesterName, getannualauditId.Id);
                        await armholdcoauditUniverse.AddAsync(armHoldco2);

                        var logarmholdco2 = AuditUniverseARMHoldingCompany.Create(armHoldco2.Id, oldscore.ToString("0.000"), businessManagerConcernARmHoldCo, businessManagerConcernARmHoldCo,
                                            riskScore.ToString("0.000"), riskRating, recommentation);
                        await armholdcoUniverse.AddAsync(logarmholdco2);

                        var logarmHoldCoTreasurySale2 = AuditUniverseARMHoldCoTreasurySale.Create(armHoldco2.Id, oldscoreTreasale.ToString("0.000"), businessManagerConcernTreasurySale, businessManagerConcernTreasurySale,
                                            riskScoreTreasurySale.ToString("0.000"), riskRatingTreasale, recommentationTreasale);
                        await armHoldCoTreasurySale.AddAsync(logarmHoldCoTreasurySale2);
                        getBusinessRiskRating.ApproveARMHoldingCompanyBusinessRating();
                        await armholdco.SaveChangesAsync();
                        return TypedResults.Ok("Approved successfully");
                    }
                }
                #endregion

                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }


        }


    }
}
