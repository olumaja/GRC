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
    public class ApproveARMHillBusinessRiskRatingEndpoint
    {
        /// <summary>
        /// Endpoint to approve armhill business risk rating
        /// </summary>
        /// <param name="businessriskratingId"></param>
        /// <param name="armHillReq"></param>
        /// <param name="repo"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="hill"></param>
        /// <param name="strategy"></param>
        /// <param name="strategyArmhill"></param>
        /// <param name="operation"></param>
        /// <param name="operARMHill"></param>
        /// <param name="finance"></param>
        /// <param name="financeArmHill"></param>
        /// <param name="compliance"></param>
        /// <param name="complianceARMHill"></param>
        /// <param name="timeSinceLastHillAudit"></param>
        /// <param name="emcRating"></param>
        /// <param name="emcRiskRating"></param>
        /// <param name="managementConcernRating"></param>
        /// <param name="mgtConcern"></param>
        /// <param name="mgtRatingbusiness"></param>
        /// <param name="mgtSharedserviceRating"></param>
        /// <param name="annualaudit"></param>
        /// <param name="hillaudit"></param>
        /// <param name="hillannualaudit"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid businessriskratingId, [FromBody] ARMHillRatingReq armHillReq, IRepository<ARMHillRating> repo,
            IRepository<BusinessRiskRating> busnessRiskRating,
            IRepository<ARMHillRating> hill, IRepository<StrategyBusinessRatingARMHill> strategy, IRepository<StrategyHillRating> strategyArmhill,

            IRepository<OperationBusinessRatingHill> operation, IRepository<OperationHillRating> operARMHill,

            IRepository<FinancialHillReporting> finance, IRepository<FinacialHillRating> financeArmHill,

            IRepository<ComplianceBusinessRatingHill> compliance,
            IRepository<ComplianceHillRating> complianceARMHill, IRepository<TimeSinceLastHillAudit> timeSinceLastHillAudit,
            IRepository<EMCConcernRiskRating> emcRating, IRepository<ARMHILLEMCRating> emcRiskRating,
            IRepository<ManagementConcernRiskRating> managementConcernRating, IRepository<ManagementConcernARMHill> mgtConcern, IRepository<ManagementConcernBusinessUnitARMHillRating> mgtRatingbusiness, IRepository<ManagementConcernSharedServiceARMHillRating> mgtSharedserviceRating,

            IRepository<AnualAuditUniverseRiskRating> annualaudit, IRepository<ARMHillAuditUniverse> hillaudit, IRepository<AuditUniverseARMHill> hillannualaudit,
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
                var businesses = await hill.GetAllAsync();
                if (getRating != null)
                {
                    var gethill = businesses.Find(x => x.BusinessRiskRatingId.Equals(businessriskratingId));

                    var getstrategylog = strategy.GetContextByConditon(x => x.ARMHillRatingId == gethill.Id).FirstOrDefault();

                    var getstrategyArmhill = strategyArmhill.GetContextByConditon(x => x.StrategyBusinessRatingARMHillId == getstrategylog.Id).Select(x => x.Total).FirstOrDefault();

                    var getoperation = operation.GetContextByConditon(x => x.ARMHillRatingId == gethill.Id).FirstOrDefault();

                    var getoperARMHill = operARMHill.GetContextByConditon(x => x.OperationBusinessRatingHillId == getoperation.Id).Select(x => x.Total).FirstOrDefault();

                    var getfinance = finance.GetContextByConditon(x => x.ARMHillRatingId == gethill.Id).FirstOrDefault();

                    var getfinanceArmHill = financeArmHill.GetContextByConditon(x => x.FinancialHillReportingId == getfinance.Id).Select(x => x.Total).FirstOrDefault();

                    var getcompliance = compliance.GetContextByConditon(x => x.ARMHillRatingId == gethill.Id).FirstOrDefault();

                    var getcomplianceARMHill = complianceARMHill.GetContextByConditon(x => x.ComplianceBusinessRatingHillId == getcompliance.Id).Select(x => x.Total).FirstOrDefault();

                    var gettimesinceaudit = timeSinceLastHillAudit.GetContextByConditon(x => x.ARMHillRatingId == gethill.Id).FirstOrDefault();
                    ////emc rating
                    //var getEMCRatingRating = emcRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                    //var getEmcConcernRating = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == getEMCRatingRating.Id).FirstOrDefault();

                    ////mc concern rating
                    //var getMCRatingRating = managementConcernRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                    //var getMCConcernRating = mgtConcern.GetContextByConditon(x => x.ManagementConcernRiskRatingId == getMCRatingRating.Id).FirstOrDefault();
                    //var getMgtRatingbusiness = mgtRatingbusiness.GetContextByConditon(x => x.ManagementConcernARMHillId == getMCConcernRating.Id).FirstOrDefault();
                    //var getMgtSharedService = mgtSharedserviceRating.GetContextByConditon(x => x.ManagementConcernARMHillId == getMCConcernRating.Id).FirstOrDefault();

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

                   // var businessManagerConcernARMHill = getMgtRatingbusiness.ARMHill;

                    // individual director Concern
                   // var directorARMHILL = getEmcConcernRating.ARMHILL + getMgtRatingbusiness.ARMHill;

                  //  var directorConcernARMHILL = getEmcConcernRating.ARMHILL + getMgtRatingbusiness.ARMHill;

                    #region MC and EMC Concern
                    //  //EMC                             
                    var getEMCRating = emcRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).ToList();
                    var allEmcConcern = new List<decimal>();

                    foreach (var item1 in getEMCRating)
                    {
                        var getEmcConcernStock = emcRiskRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.ARMHILL).ToList();
                        allEmcConcern.AddRange(getEmcConcernStock);
                    }
                    // Calculate the sum and average for the first three records
                    var records = allEmcConcern.ToList();
                    decimal sum = records.Sum();
                    decimal averageEMC = records.Any() ? records.Average() : 0;

                    //  //emc rating

                    var getMCRating = managementConcernRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).ToList();
                    var allMCConcernHill = new List<decimal>();
                    foreach (var item2 in getMCRating)
                    {
                        var getMCConcernDFS = mgtConcern.GetContextByConditon(x => x.ManagementConcernRiskRatingId == item2.Id).ToList();
                        if (getMCConcernDFS.Any())
                        {
                            var getbusMCRating = mgtRatingbusiness.GetContextByConditon(x => getMCConcernDFS.Select(y => y.Id).Contains(x.ManagementConcernARMHillId)).Select(x => x.ARMHill).ToList();
                            allMCConcernHill.AddRange(getbusMCRating);
                        }
                    }
                    var recordMC = allMCConcernHill.ToList();
                    decimal sumMC = recordMC.Sum();
                    decimal averageMC = recordMC.Any() ? recordMC.Average() : 0;

                    var businessManagerConcernARMHill = averageMC;
                    var directorARMHILL = averageEMC;

                    var mgtDirectorConcernARMHILL = businessManagerConcernARMHill + directorARMHILL;

                    #endregion




                    #region ARMHill

                    string riskRating = "";
                    string recommentation = "";
                    var RiskScoreStrategy = (getstrategyArmhill / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                    var RiskScoreOperation = (getoperARMHill / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                    var RiskScoreFinance = (getfinanceArmHill / (double)maximumPossibleFinanceBusinessMgtRating) * financialReportWeight;
                    var RiskScoreCompliance = (getcomplianceARMHill / (double)maximumPossibleComplianceBusinessMgtRating) * complianceWeight;
                    var RiskScoreTimesinceLastaudit = (gettimesinceaudit.ARMHill / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                    var RiskScoredirectorConcern = (mgtDirectorConcernARMHILL / (decimal)maximumPossibleEMCRating) * magtConcernWeight;

                    var riskScore = (decimal)RiskScoreStrategy + (decimal)RiskScoreOperation + (decimal)RiskScoreFinance + (decimal)RiskScoreCompliance + (decimal)RiskScoreTimesinceLastaudit + RiskScoredirectorConcern;
                    var oldRiskScore = 0;
                   
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

                    #region                       
                    var getannualauditId = annualaudit.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                    if (getannualauditId == null)
                    {
                        var logRequestId = AnualAuditUniverseRiskRating.Create(getRating.RequesterName, businessriskratingId);
                        await annualaudit.AddAsync(logRequestId);

                        var auditUnive = ARMHillAuditUniverse.Create(getRating.RequesterName, logRequestId.Id);
                        await hillaudit.AddAsync(auditUnive);

                        var loghillReq = AuditUniverseARMHill.Create(auditUnive.Id, oldRiskScore.ToString("0.000"), businessManagerConcernARMHill, directorARMHILL,
                                            riskScore.ToString("0.000"), riskRating, recommentation);
                        await hillannualaudit.AddAsync(loghillReq);

                        getBusinessRiskRating.ApproveBusinessRating();
                        await repo.SaveChangesAsync();

                        return TypedResults.Ok("Approved successfully");
                    }
                    if (getannualauditId != null)
                    {
                        var getaudit = hillaudit.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getannualauditId.Id).FirstOrDefault();
                        if (getaudit != null)
                        {
                            getBusinessRiskRating.ApproveBusinessRating();
                            await repo.SaveChangesAsync();
                            return TypedResults.Ok("Approved successfully");
                        }
                        if (getaudit == null)
                        {
                            var auditUnive2 = ARMHillAuditUniverse.Create(getRating.RequesterName, getannualauditId.Id);
                            await hillaudit.AddAsync(auditUnive2);

                            var loghillReq2 = AuditUniverseARMHill.Create(auditUnive2.Id, oldRiskScore.ToString("0.000"), businessManagerConcernARMHill, directorARMHILL,
                                                riskScore.ToString("0.000"), riskRating, recommentation);
                            await hillannualaudit.AddAsync(loghillReq2);

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
