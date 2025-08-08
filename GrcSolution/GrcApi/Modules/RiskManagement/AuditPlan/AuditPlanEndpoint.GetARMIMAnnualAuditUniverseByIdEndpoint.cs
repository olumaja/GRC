using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 02/04/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 * This endpoint get Annual Audit Universe By anualAuditUniverseId
 */
    public class GetARMIMAnnualAuditUniverseByIdEndpoint
    {
        /// <summary>
        /// Endpoint to get ARMIM Annual Audit Universe By Id
        /// </summary>
        /// <param name="anualAuditUniverseId"></param>
        /// <param name="annualaudit"></param>
        /// <param name="armimauditUniverse"></param>
        /// <param name="imunit"></param>
        /// <param name="operationControl"></param>
        /// <param name="fundAdmin"></param>
        /// <param name="registrar"></param>
        /// <param name="bDPWMIAMIMRetail"></param>
        /// <param name="operationSettlement"></param>
        /// <param name="retailOperation"></param>
        /// <param name="fundAccount"></param>
        /// <param name="currentUserService"></param>
        /// <param name="armIM"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid anualAuditUniverseId, IRepository<AnualAuditUniverseRiskRating> annualaudit,
            IRepository<ARMIMAuditUniverse> armimauditUniverse, IRepository<AuditUniverseARMIMIMUnit> imunit,
            IRepository<AuditUniverseARMIMOperationControl> operationControl, IRepository<AuditUniverseARMIMFundAdmin> fundAdmin,
            IRepository<AuditUniverseARMIMRegistrar> registrar, IRepository<AuditUniverseARMIMBDPWMIAMIMRetail> bDPWMIAMIMRetail,
            IRepository<AuditUniverseARMIMOperationSettlement> operationSettlement, IRepository<AuditUniverseARMIMRetailOperation> retailOperation,
            IRepository<AuditUniverseARMIMResearch> research, IRepository<AuditUniverseARMIMFundAccount> fundAccount, ICurrentUserService currentUserService,            
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
                var getRating = annualaudit.GetContextByConditon(x => x.Id == anualAuditUniverseId).FirstOrDefault();
                if (getRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe Id '{anualAuditUniverseId}' was not found");
                }
                var getAuditRating = armimauditUniverse.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getRating.Id).FirstOrDefault();
                if (getAuditRating == null)
                {
                    return TypedResults.NotFound($"Annual Audit Universe has not been fully performed on ARMIM");
                }
                var getimunit = imunit.GetContextByConditon(x => x.ARMIMAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getoperationControl = operationControl.GetContextByConditon(x => x.ARMIMAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getregistrar = registrar.GetContextByConditon(x => x.ARMIMAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getbDPWMIAMIMRetail = bDPWMIAMIMRetail.GetContextByConditon(x => x.ARMIMAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getoperationSettlement = operationSettlement.GetContextByConditon(x => x.ARMIMAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getfundAdmin = fundAdmin.GetContextByConditon(x => x.ARMIMAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getfundAccount = fundAccount.GetContextByConditon(x => x.ARMIMAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getretailOperation = retailOperation.GetContextByConditon(x => x.ARMIMAuditUniverseId == getAuditRating.Id).FirstOrDefault();
                var getresearch = research.GetContextByConditon(x => x.ARMIMAuditUniverseId == getAuditRating.Id).FirstOrDefault();

                GetARMIMAuditUniverseSummary resp = new GetARMIMAuditUniverseSummary
                {
                    AnualAuditUniverseId = anualAuditUniverseId,
                    IMUnit = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getimunit.BusinessManagerConcern,
                        DirectorConcern = getimunit.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getimunit.Recommentation,
                        RiskScore2 = getimunit.RiskScore,
                        RiskRating = getimunit.RiskRating,
                        Recommentation = getimunit.Recommentation,
                        January = getimunit.January,
                        February = getimunit.February,
                        March = getimunit.March,
                        April = getimunit.April,
                        May = getimunit.May,
                        June = getimunit.June,
                        July = getimunit.July,
                        August = getimunit.August,
                        September = getimunit.September,
                        October = getimunit.October,
                        November = getimunit.November,
                        December = getimunit.December
                    },
                    OperationControl = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getoperationControl.BusinessManagerConcern,
                        DirectorConcern = getoperationControl.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getoperationControl.Recommentation,
                        RiskScore2 = getoperationControl.RiskScore,
                        RiskRating = getoperationControl.RiskRating,
                        Recommentation = getoperationControl.Recommentation,
                        January = getoperationControl.January,
                        February = getoperationControl.February,
                        March = getoperationControl.March,
                        April = getoperationControl.April,
                        May = getoperationControl.May,
                        June = getoperationControl.June,
                        July = getoperationControl.July,
                        August = getoperationControl.August,
                        September = getoperationControl.September,
                        October = getoperationControl.October,
                        November = getoperationControl.November,
                        December = getoperationControl.December
                    },
                    Registrar = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getregistrar.BusinessManagerConcern,
                        DirectorConcern = getregistrar.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getregistrar.Recommentation,
                        RiskScore2 = getregistrar.RiskScore,
                        RiskRating = getregistrar.RiskRating,
                        Recommentation = getregistrar.Recommentation,
                        January = getregistrar.January,
                        February = getregistrar.February,
                        March = getregistrar.March,
                        April = getregistrar.April,
                        May = getregistrar.May,
                        June = getregistrar.June,
                        July = getregistrar.July,
                        August = getregistrar.August,
                        September = getregistrar.September,
                        October = getregistrar.October,
                        November = getregistrar.November,
                        December = getregistrar.December
                    },
                    BDPWMIAMIMRetail = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getbDPWMIAMIMRetail.BusinessManagerConcern,
                        DirectorConcern = getbDPWMIAMIMRetail.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getbDPWMIAMIMRetail.Recommentation,
                        RiskScore2 = getbDPWMIAMIMRetail.RiskScore,
                        RiskRating = getbDPWMIAMIMRetail.RiskRating,
                        Recommentation = getbDPWMIAMIMRetail.Recommentation,
                        January = getbDPWMIAMIMRetail.January,
                        February = getbDPWMIAMIMRetail.February,
                        March = getbDPWMIAMIMRetail.March,
                        April = getbDPWMIAMIMRetail.April,
                        May = getbDPWMIAMIMRetail.May,
                        June = getbDPWMIAMIMRetail.June,
                        July = getbDPWMIAMIMRetail.July,
                        August = getbDPWMIAMIMRetail.August,
                        September = getbDPWMIAMIMRetail.September,
                        October = getbDPWMIAMIMRetail.October,
                        November = getbDPWMIAMIMRetail.November,
                        December = getbDPWMIAMIMRetail.December
                    },
                    OperationSettlement = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getoperationSettlement.BusinessManagerConcern,
                        DirectorConcern = getoperationSettlement.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getoperationSettlement.Recommentation,
                        RiskScore2 = getoperationSettlement.RiskScore,
                        RiskRating = getoperationSettlement.RiskRating,
                        Recommentation = getoperationSettlement.Recommentation,
                        January = getoperationSettlement.January,
                        February = getoperationSettlement.February,
                        March = getoperationSettlement.March,
                        April = getoperationSettlement.April,
                        May = getoperationSettlement.May,
                        June = getoperationSettlement.June,
                        July = getoperationSettlement.July,
                        August = getoperationSettlement.August,
                        September = getoperationSettlement.September,
                        October = getoperationSettlement.October,
                        November = getoperationSettlement.November,
                        December = getoperationSettlement.December
                    },
                    FundAdmin = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getfundAdmin.BusinessManagerConcern,
                        DirectorConcern = getfundAdmin.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getfundAdmin.Recommentation,
                        RiskScore2 = getfundAdmin.RiskScore,
                        RiskRating = getfundAdmin.RiskRating,
                        Recommentation = getfundAdmin.Recommentation,
                        January = getfundAdmin.January,
                        February = getfundAdmin.February,
                        March = getfundAdmin.March,
                        April = getfundAdmin.April,
                        May = getfundAdmin.May,
                        June = getfundAdmin.June,
                        July = getfundAdmin.July,
                        August = getfundAdmin.August,
                        September = getfundAdmin.September,
                        October = getfundAdmin.October,
                        November = getfundAdmin.November,
                        December = getfundAdmin.December
                    },
                    FundAccount = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getfundAccount.BusinessManagerConcern,
                        DirectorConcern = getfundAccount.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getfundAccount.Recommentation,
                        RiskScore2 = getfundAccount.RiskScore,
                        RiskRating = getfundAccount.RiskRating,
                        Recommentation = getfundAccount.Recommentation,
                        January = getfundAccount.January,
                        February = getfundAccount.February,
                        March = getfundAccount.March,
                        April = getfundAccount.April,
                        May = getfundAccount.May,
                        June = getfundAccount.June,
                        July = getfundAccount.July,
                        August = getfundAccount.August,
                        September = getfundAccount.September,
                        October = getfundAccount.October,
                        November = getfundAccount.November,
                        December = getfundAccount.December
                    },
                    RetailOperation = new AuditUniverseSummary
                    {
                        BusinessManagerConcern = getretailOperation.BusinessManagerConcern,
                        DirectorConcern = getretailOperation.DirectorConcern,
                        OldRiskScore = "Low",
                        RiskScore = getretailOperation.Recommentation,
                        RiskScore2 = getretailOperation.RiskScore,
                        RiskRating = getretailOperation.RiskRating,
                        Recommentation = getretailOperation.Recommentation,
                        January = getretailOperation.January,
                        February = getretailOperation.February,
                        March = getretailOperation.March,
                        April = getretailOperation.April,
                        May = getretailOperation.May,
                        June = getretailOperation.June,
                        July = getretailOperation.July,
                        August = getretailOperation.August,
                        September = getretailOperation.September,
                        October = getretailOperation.October,
                        November = getretailOperation.November,
                        December = getretailOperation.December
                    },
                    Research = new AuditUniverseSummary
                     {
                         BusinessManagerConcern = getresearch.BusinessManagerConcern,
                         DirectorConcern = getresearch.DirectorConcern,
                         OldRiskScore = "Low",
                         RiskScore = getresearch.Recommentation,
                         RiskScore2 = getresearch.RiskScore,
                         RiskRating = getresearch.RiskRating,
                         Recommentation = getresearch.Recommentation,
                         January = getresearch.January,
                         February = getresearch.February,
                         March = getresearch.March,
                         April = getresearch.April,
                         May = getresearch.May,
                         June = getresearch.June,
                         July = getresearch.July,
                         August = getresearch.August,
                         September = getresearch.September,
                         October = getresearch.October,
                         November = getresearch.November,
                         December = getresearch.December
                     }

                };

                return TypedResults.Ok(resp);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }


        }
    }
}
