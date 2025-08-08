using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Arm.GrcApi.Modules.RiskManagement.AuditPlan.AuditUniverseResponse;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 20/03/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* Endpoint to approve business risk rating
*/
    public class ApproveARMTAMBusinessRiskRatingEndpoint
    {

        /// <summary>
        /// Endpoint to approve armtam business risk rating
        /// </summary>
        /// <param name="businessriskratingId"></param>
        /// <param name="request"></param>
        /// <param name="repo"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="armTAM"></param>
        /// <param name="strategy"></param>
        /// <param name="strategyTAM"></param>
        /// <param name="operation"></param>
        /// <param name="operTAM"></param>
        /// <param name="finance"></param>
        /// <param name="financeTAM"></param>
        /// <param name="compliance"></param>
        /// <param name="complianceTAM"></param>
        /// <param name="timeSinceLastARMTAMAudit"></param>
        /// <param name="annualaudit"></param>
        /// <param name="armtamauditUniverse"></param>
        /// <param name="logTamaudit"></param>
        /// <param name="financialControlARMTAMAudit"></param>
        /// <param name="treasuryOperationaudit"></param>
        /// <param name="currentUserService"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid businessriskratingId, [FromBody] ARMTAMBusinessRiskRatingReq request, IRepository<ARMTAMBusinessRiskRating> repo,
            IRepository<BusinessRiskRating> busnessRiskRating, IRepository<ARMTAMBusinessRiskRating> armTAM, IRepository<StrategyBusinessARMTAM> strategy,
            IRepository<StrategyBusinessTAMRating> strategyTAM,
            IRepository<OperationBusinessARMTAM> operation, IRepository<OperationBusinessTAMRating> operTAM,
            IRepository<FinancialBusinessARMTAM> finance, IRepository<FinacialBusinessTAMRating> financeTAM,
            IRepository<ComplianceBusinessARMTAM> compliance, IRepository<ComplianceBusinessTAMRating> complianceTAM,
            IRepository<TimeSinceLastBusinessARMTAMAudit> timeSinceLastARMTAMAudit,
            IRepository<AnualAuditUniverseRiskRating> annualaudit, IRepository<ARMTAMAuditUniverse> armtamauditUniverse,
            IRepository<AuditUniverseARMTAM> logTamaudit, ICurrentUserService currentUserService,
            IRepository<EMCConcernRiskRating> emcRating, IRepository<ARMTAMEMCRating> armTamEMCRating,
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
                var getTAMRating = busnessRiskRating.GetContextByConditon(x => x.Id == businessriskratingId).FirstOrDefault();
                var updatebusinessRiskRating = busnessRiskRating.GetContextByConditon(c => c.Id == businessriskratingId && c.Status != BusinessRiskRatingStatus.Approved).FirstOrDefault();
                var getTAMList = await repo.GetAllAsync();
                if (getTAMRating == null) { return TypedResults.NotFound(); }

                var gebusinessRating = getTAMList.Find(x => x.BusinessRiskRatingId.Equals(businessriskratingId));

                var getstrategylog = strategy.GetContextByConditon(x => x.ARMTAMBusinessRiskRatingId == gebusinessRating.Id).FirstOrDefault();

                var getstrategyTAM = strategyTAM.GetContextByConditon(x => x.StrategyBusinessARMTAMId == getstrategylog.Id).FirstOrDefault();

                var strategyTAMTotal = getstrategyTAM.Total;

                var getoperation = operation.GetContextByConditon(x => x.ARMTAMBusinessRiskRatingId == gebusinessRating.Id).FirstOrDefault();

                var getoperTAM = operTAM.GetContextByConditon(x => x.OperationBusinessARMTAMId == getoperation.Id).FirstOrDefault();

                var operationTAMTotal = getoperTAM.Total;

                var getfinance = finance.GetContextByConditon(x => x.ARMTAMBusinessRiskRatingId == gebusinessRating.Id).FirstOrDefault();

                var getfinanceTAM = financeTAM.GetContextByConditon(x => x.FinancialBusinessARMTAMId == getfinance.Id).FirstOrDefault();

                var financeARMTAMTotal = getfinanceTAM.Total;

                var getcompliance = compliance.GetContextByConditon(x => x.ARMTAMBusinessRiskRatingId == gebusinessRating.Id).FirstOrDefault();

                var getcomplianceTAM = complianceTAM.GetContextByConditon(x => x.ComplianceBusinessARMTAMId == getcompliance.Id).FirstOrDefault();

                var complianceARMTAMTotal = getcomplianceTAM.Total;

                ////emc rating
                //var getEMCRatingRating = emcRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                //var getEmcConcernarmTAMRating = armTamEMCRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == getEMCRatingRating.Id).FirstOrDefault();
                                
                var gettimeSinceLastARMTAMAudit = timeSinceLastARMTAMAudit.GetContextByConditon(x => x.ARMTAMBusinessRiskRatingId == gebusinessRating.Id).FirstOrDefault();

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

               // var businessManagerConcernTAM = getEmcConcernarmTAMRating.ARMTAM;
               // var directorManagerConcernTAM = getEmcConcernarmTAMRating.ARMTAM;

                //var mgtConcern = businessManagerConcernTAM + directorManagerConcernTAM;

                #region MC and EMC Concern
                //  //EMC                             
                var getEMCRating = emcRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).ToList();
                var allEmcConcern = new List<decimal>();

                foreach (var item1 in getEMCRating)
                {
                    var getEmcConcern = armTamEMCRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.ARMTAM).ToList();
                    allEmcConcern.AddRange(getEmcConcern);
                }
                // Calculate the sum and average for the first three records
                var records = allEmcConcern.ToList();
                decimal sum = records.Sum();
                decimal averageEMC = records.Any() ? records.Average() : 0;
                var businessManagerConcernTAM = averageEMC;
                var directorManagerConcernTAM = averageEMC;
                var mgtConcern = businessManagerConcernTAM + directorManagerConcernTAM;

                #endregion

                #region riskScoreTAM
                string riskRatingTAM = "";
                string recommentationTAM = "";
                var oldRiskScoreTAM = 0;
                var RiskScoreStrategyTAM = (getstrategyTAM.Total / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                var RiskScoreFinanceTAM = (getfinanceTAM.Total / (double)maximumPossibleFinanceBusinessMgtRating) * financialReportWeight;
                var RiskScoreComplianceTAM = (getcomplianceTAM.Total / (double)maximumPossibleComplianceBusinessMgtRating) * complianceWeight;
                var RiskScoreMgtConcernRating = (mgtConcern / (decimal)maximumPossibleEMCRating) * magtConcernWeight;

                var scoreHoldco = (decimal)RiskScoreStrategyTAM + (decimal)RiskScoreFinanceTAM + (decimal)RiskScoreComplianceTAM + RiskScoreMgtConcernRating;
                var riskScoreStrategyTAM = (scoreHoldco / 65) * 100;
               
                if (riskScoreStrategyTAM < 0.4m)
                {
                    riskRatingTAM = "Very Low";
                    recommentationTAM = "Spot Check";
                }
                if (riskScoreStrategyTAM >= 0.4m && riskScoreStrategyTAM < 0.5m)
                {
                    riskRatingTAM = "Low";
                    recommentationTAM = "Spot Check";
                }
                if (riskScoreStrategyTAM >= 0.5m && riskScoreStrategyTAM < 0.65m)
                {
                    riskRatingTAM = "Medium";
                    recommentationTAM = "Partial Scope";
                }
                if (riskScoreStrategyTAM >= 0.65m && riskScoreStrategyTAM < 0.8m)
                {
                    riskRatingTAM = "High";
                    recommentationTAM = "Full Scope";
                }
                if (riskScoreStrategyTAM >= 0.8m)
                {
                    riskRatingTAM = "Very High";
                    recommentationTAM = "Full Scope";
                }

                #endregion

                #region
                var getannualauditId = annualaudit.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                if (getannualauditId == null)
                {
                    var logRequestId = AnualAuditUniverseRiskRating.Create(getTAMRating.RequesterName, businessriskratingId);
                    await annualaudit.AddAsync(logRequestId);
                    var armtam = ARMTAMAuditUniverse.Create(getTAMRating.RequesterName, logRequestId.Id);
                    await armtamauditUniverse.AddAsync(armtam);

                    var logTamReq = AuditUniverseARMTAM.Create(armtam.Id, oldRiskScoreTAM.ToString("0.000"), businessManagerConcernTAM, directorManagerConcernTAM,
                                        riskScoreStrategyTAM.ToString("0.000"), riskRatingTAM, recommentationTAM); 
                    await logTamaudit.AddAsync(logTamReq);

                    getBusinessRiskRating.ApproveBusinessRating();
                    await repo.SaveChangesAsync();
                    return TypedResults.Ok("Approved successfully");
                }
                if (getannualauditId != null)
                {
                    var getTAM = armtamauditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getannualauditId.Id).FirstOrDefault();
                    if (getTAM != null)
                    {
                        getBusinessRiskRating.ApproveBusinessRating();
                        await repo.SaveChangesAsync();
                        return TypedResults.Ok("Approved successfully");
                    }
                    if (getTAM == null)
                    {
                        var armtam2 = ARMTAMAuditUniverse.Create(getTAMRating.RequesterName, getannualauditId.Id);
                        await armtamauditUniverse.AddAsync(armtam2);

                        var logTamReq2 = AuditUniverseARMTAM.Create(armtam2.Id, oldRiskScoreTAM.ToString("0.000"), businessManagerConcernTAM, directorManagerConcernTAM,
                                            riskScoreStrategyTAM.ToString("0.000"), riskRatingTAM, recommentationTAM);
                        await logTamaudit.AddAsync(logTamReq2);

                        getBusinessRiskRating.ApproveBusinessRating();
                        await repo.SaveChangesAsync();
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
