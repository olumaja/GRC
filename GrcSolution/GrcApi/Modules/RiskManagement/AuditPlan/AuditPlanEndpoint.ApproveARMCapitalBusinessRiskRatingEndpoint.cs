using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;
using System.Web.Http;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 20/03/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 * Endpoint to approve business risk rating
 */
    public class ApproveARMCapitalBusinessRiskRatingEndpoint
    {

        /// <summary>
        /// Endpoint to approve ARMCapital business risk rating
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
        public static async Task<IResult> HandleAsync(Guid businessriskratingId, [FromBody] ARMCapitalBusinessRiskRatingReq request,
            IRepository<BusinessRiskRating> busnessRiskRating, IRepository<ARMCapitalBusinessRiskRating> armDFS, IRepository<StrategyARMCapital> strategy,
            IRepository<StrategyARMCapitalRating> strategyDFS,
            IRepository<OperationARMCapital> operation, IRepository<OperationARMCapitalRating> operDFS,
            IRepository<FinancialARMCapital> finance, IRepository<FinacialBusinessARMCapitalRating> financeDFS,
            IRepository<ComplianceARMCapital> compliance, IRepository<ComplianceBusinessARMCapitalRating> complianceDFS,
            IRepository<TimeSinceLastAuditARMCapital> timeSinceLastARMTAMAudit,
            IRepository<AnualAuditUniverseRiskRating> annualaudit, IRepository<ARMCapitalAuditUniverse> armtamauditUniverse,
            IRepository<AuditUniverseARMCapitalRating> logTamaudit, ICurrentUserService currentUserService,
            IRepository<EMCConcernRiskRating> emcRating, IRepository<ARMCapitalEMCRating> dfsEMCRating, IRepository<ManagementConcernRiskRating> managementConcernRating,
            IRepository<ManagementConcernARMCapital> mcRating, IRepository<ManagementConcernBusinessUnitARMCapitalRating> busdfsMCRating, IRepository<ManagementConcernSharedServiceARMCapitalRating> sharedfsMCRating,
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
                var getBusinessRiskRating = armDFS.GetContextByConditon(c => c.BusinessRiskRatingId == businessriskratingId && c.Status != BusinessRiskRatingStatus.Approved).FirstOrDefault();
                if (getBusinessRiskRating == null) { return TypedResults.NotFound("The record has been previouly approved"); }
                var getTAMRating = busnessRiskRating.GetContextByConditon(x => x.Id == businessriskratingId).FirstOrDefault();
                var updatebusinessRiskRating = busnessRiskRating.GetContextByConditon(c => c.Id == businessriskratingId && c.Status != BusinessRiskRatingStatus.Approved).FirstOrDefault();
                var getDFSList = await armDFS.GetAllAsync();
                if (getTAMRating == null) { return TypedResults.NotFound(); }

                var gebusinessRating = getDFSList.Find(x => x.BusinessRiskRatingId.Equals(businessriskratingId));

                var getstrategylog = strategy.GetContextByConditon(x => x.ARMCapitalBusinessRiskRatingId == gebusinessRating.Id).FirstOrDefault();

                var getstrategyDFS = strategyDFS.GetContextByConditon(x => x.StrategyARMCapitalId == getstrategylog.Id).FirstOrDefault();

                var strategyDFSTotal = getstrategyDFS.Total;

                var getoperation = operation.GetContextByConditon(x => x.ARMCapitalBusinessRiskRatingId == gebusinessRating.Id).FirstOrDefault();

                var getoperDFS = operDFS.GetContextByConditon(x => x.OperationARMCapitalId == getoperation.Id).FirstOrDefault();

                var operationDFSTotal = getoperDFS.Total;

                var getfinance = finance.GetContextByConditon(x => x.ARMCapitalBusinessRiskRatingId == gebusinessRating.Id).FirstOrDefault();

                var getfinanceDFS = financeDFS.GetContextByConditon(x => x.FinancialARMCapitalId == getfinance.Id).FirstOrDefault();

                var financeARMDFSTotal = getfinanceDFS.Total;

                var getcompliance = compliance.GetContextByConditon(x => x.ARMCapitalBusinessRiskRatingId == gebusinessRating.Id).FirstOrDefault();

                var getcomplianceDFS = complianceDFS.GetContextByConditon(x => x.ComplianceARMCapitalId == getcompliance.Id).FirstOrDefault();

                var complianceARMDFSTotal = getcomplianceDFS.Total;

                ////emc rating
                //var getEMCRatingRating = emcRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                //var getEmcConcernDFSRating = dfsEMCRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == getEMCRatingRating.Id).FirstOrDefault();

                ////mc concern rating
                //var getMCRatingRating = managementConcernRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                //var getMCConcernRating = mcRating.GetContextByConditon(x => x.ManagementConcernRiskRatingId == getMCRatingRating.Id).FirstOrDefault();
                //var getMgtRatingbusiness = busdfsMCRating.GetContextByConditon(x => x.ManagementConcernARMCapitalId == getMCConcernRating.Id).FirstOrDefault();
                //var getMgtSharedService = sharedfsMCRating.GetContextByConditon(x => x.ManagementConcernARMCapitalId == getMCConcernRating.Id).FirstOrDefault();


                var gettimeSinceLastARMTAMAudit = timeSinceLastARMTAMAudit.GetContextByConditon(x => x.ARMCapitalBusinessRiskRatingId == gebusinessRating.Id).FirstOrDefault();
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

               // var businessManagerConcerndfs = getEmcConcernDFSRating.ARMCapital;
               // var directorManagerConcernDFS = getMgtRatingbusiness.ARMCapital;

               // var mgtConcern = businessManagerConcerndfs + directorManagerConcernDFS;

                #region MC and EMC Concern
                //  //EMC                             
                var getEMCRating = emcRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).ToList();
                var allEmcConcernDFS = new List<decimal>(); // To collect all values for further calculations

                foreach (var item1 in getEMCRating)
                {
                    var getEmcConcernDFS = dfsEMCRating.GetContextByConditon(x => x.EMCConcernRiskRatingId == item1.Id).Select(x => x.ARMCapital).ToList();
                    allEmcConcernDFS.AddRange(getEmcConcernDFS); // Collect values for aggregation
                }
                // Calculate the sum and average for the first three records
                var records = allEmcConcernDFS.ToList();
                decimal sum = records.Sum();
                decimal averageEMC = records.Any() ? records.Average() : 0;
                              

                //  //emc rating

                var getMCRating = managementConcernRating.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).ToList();
                var allMCConcernDFS = new List<decimal>();
                foreach (var item2 in getMCRating)
                {
                    var getMCConcernDFS = mcRating.GetContextByConditon(x => x.ManagementConcernRiskRatingId == item2.Id).ToList();
                    if (getMCConcernDFS.Any())
                    {
                        var getbusdfsMCRating = busdfsMCRating.GetContextByConditon(x => getMCConcernDFS.Select(y => y.Id).Contains(x.ManagementConcernARMCapitalId)).Select(x => x.ARMCapital).ToList();
                        allMCConcernDFS.AddRange(getbusdfsMCRating);
                    }
                }
                var recordMC = allMCConcernDFS.ToList();
                decimal sumMC = recordMC.Sum();
                decimal averageMC = recordMC.Any() ? recordMC.Average() : 0;              

                var businessManagerConcerndfs = averageMC;
                var directorManagerConcernDFS = averageEMC; 

                var mgtConcern = businessManagerConcerndfs + directorManagerConcernDFS;

                #endregion

                #region riskScoreDFS
                string riskRatingdfs = "";
                string recommentationdfs = "";
                var oldRiskScoredfs = 0;
                var RiskScoreStrategyDFS = (getstrategyDFS.Total / (double)maximumPossibleStrategyBusinessMgtRating) * strategyWeight;
                var RiskScoreOperationDFS = (getoperDFS.Total / (double)maximumPossibleOperationBusinessMgtRating) * operationWeight;
                var RiskScoreFinanceDFS = (getfinanceDFS.Total / (double)maximumPossibleFinanceBusinessMgtRating) * financialReportWeight;
                var RiskScoreComplianceDFS = (getcomplianceDFS.Total / (double)maximumPossibleComplianceBusinessMgtRating) * complianceWeight;
                var RiskScoreTimesinceLastauditDFS = (gettimeSinceLastARMTAMAudit.ARMCapital / (double)maximumPossibleTimeSinceLastAuditBusinessMgtRating) * timeSinceLastAuditWeight;
                var RiskScoreMgtConcernRating = (mgtConcern / (decimal)maximumPossibleEMCRating) * magtConcernWeight;

                var riskScoredfs = (decimal)RiskScoreStrategyDFS + (decimal)RiskScoreOperationDFS + (decimal)RiskScoreFinanceDFS + (decimal)RiskScoreComplianceDFS + (decimal)RiskScoreTimesinceLastauditDFS + RiskScoreMgtConcernRating;

                if (riskScoredfs < 0.4m)
                {
                    riskRatingdfs = "Very Low";
                    recommentationdfs = "Spot Check";
                }
                if (riskScoredfs >= 0.4m && riskScoredfs < 0.5m)
                {
                    riskRatingdfs = "Low";
                    recommentationdfs = "Spot Check";
                }
                if (riskScoredfs >= 0.5m && riskScoredfs < 0.65m)
                {
                    riskRatingdfs = "Medium";
                    recommentationdfs = "Partial Scope";
                }
                if (riskScoredfs >= 0.65m && riskScoredfs < 0.8m)
                {
                    riskRatingdfs = "High";
                    recommentationdfs = "Full Scope";
                }
                if (riskScoredfs >= 0.8m)
                {
                    riskRatingdfs = "Very High";
                    recommentationdfs = "Full Scope";
                }
                #endregion

                #region
                var getannualauditId = annualaudit.GetContextByConditon(x => x.BusinessRiskRatingId == businessriskratingId).FirstOrDefault();
                if (getannualauditId == null)
                {
                    var logRequestId = AnualAuditUniverseRiskRating.Create(getTAMRating.RequesterName, businessriskratingId);
                    await annualaudit.AddAsync(logRequestId);

                    var dfs = ARMCapitalAuditUniverse.Create(getTAMRating.RequesterName, logRequestId.Id);
                    await armtamauditUniverse.AddAsync(dfs);

                    var logdfsReq = AuditUniverseARMCapitalRating.Create(dfs.Id, oldRiskScoredfs.ToString("0.000"), businessManagerConcerndfs, directorManagerConcernDFS,
                                        riskScoredfs.ToString("0.000"), riskRatingdfs, recommentationdfs);
                    await logTamaudit.AddAsync(logdfsReq);

                    getBusinessRiskRating.ApproveBusinessRating();
                    await armDFS.SaveChangesAsync();
                    return TypedResults.Ok("Approved successfully");
                }
                if (getannualauditId != null)
                {
                    var getTAM = armtamauditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getannualauditId.Id).FirstOrDefault();
                    if (getTAM != null)
                    {
                        getBusinessRiskRating.ApproveBusinessRating();
                        await armDFS.SaveChangesAsync();
                        return TypedResults.Ok("Approved successfully");
                    }
                    if (getTAM == null)
                    {
                        var armtam2 = ARMCapitalAuditUniverse.Create(getTAMRating.RequesterName, getannualauditId.Id);
                        await armtamauditUniverse.AddAsync(armtam2);

                        var logdfsReq2 = AuditUniverseARMCapitalRating.Create(armtam2.Id, oldRiskScoredfs.ToString("0.000"), businessManagerConcerndfs, directorManagerConcernDFS,
                                        riskScoredfs.ToString("0.000"), riskRatingdfs, recommentationdfs);
                        await logTamaudit.AddAsync(logdfsReq2);

                        getBusinessRiskRating.ApproveBusinessRating();
                        await armDFS.SaveChangesAsync();
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
