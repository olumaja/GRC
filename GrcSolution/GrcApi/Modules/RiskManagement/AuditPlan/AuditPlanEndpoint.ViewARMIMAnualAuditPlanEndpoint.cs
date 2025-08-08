using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using static Arm.GrcApi.Modules.RiskManagement.AuditPlan.AuditUniverseResponse;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 28/03/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 * This endpoint get all business and management concern risk rating
 */
    public class ViewARMIMAnualAuditPlanEndpoint
    {
        ///<summary>
        /// View ARMIM Anual Audit Universe
        /// </summary>
        /// <param name="busnessRiskRating"></param>
        /// <param name="anualAuditUniverse"></param>
        /// <param name="aRMIMAudit"></param>
        /// <param name="aRMIMIMUnit"></param>
        /// <param name="aRMIMBDPWMIAMIMRetail"></param>
        /// <param name="aRMIMFundAccount"></param>
        /// <param name="aRMIMFundAdmin"></param>
        /// <param name="aRMIMRetailOperation"></param>
        /// <param name="aRMIMRegistrar"></param>
        /// <param name="aRMIMFinancialControl"></param>
        /// <param name="aRMIMCompliance"></param>
        /// <param name="aRMIMTreasuryInvestment"></param>
        /// <param name="aRMIMOperationSettlement"></param>
        /// <param name="aRMIMOperationControl"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<ARMIMBusinessRiskRating> armim,

            IRepository<AnualAuditUniverseRiskRating> anualAuditUniverse, IRepository<ARMIMAuditUniverse> aRMIMAudit, IRepository<AuditUniverseARMIMIMUnit> aRMIMIMUnit,
            IRepository<AuditUniverseARMIMBDPWMIAMIMRetail> aRMIMBDPWMIAMIMRetail, IRepository<AuditUniverseARMIMFundAccount> aRMIMFundAccount, IRepository<AuditUniverseARMIMFundAdmin> aRMIMFundAdmin,
            IRepository<AuditUniverseARMIMRetailOperation> aRMIMRetailOperation, IRepository<AuditUniverseARMIMRegistrar> aRMIMRegistrar, IRepository<AuditUniverseARMIMOperationSettlement> aRMIMOperationSettlement,
            IRepository<AuditUniverseARMIMResearch> armIMResearch, IRepository<AuditUniverseARMIMRating> armIMRate, IRepository<AuditUniverseARMIMOperationControl> aRMIMOperationControl, ClaimsPrincipal user, ICurrentUserService currentUserService
            )
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
                var getRating = armim.GetContextByConditon(x => x.Status == BusinessRiskRatingStatus.Approved).ToList();

                var getanualAuditUniverse = await anualAuditUniverse.GetAllAsync();
                if (getRating != null)
                {
                    foreach (var item in getRating)
                    {

                        var getanualAuditUniverseResp = getanualAuditUniverse.Find(x => x.BusinessRiskRatingId.Equals(item.BusinessRiskRatingId));
                        var getaRMIMAudit = aRMIMAudit.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getanualAuditUniverseResp.Id).FirstOrDefault();

                        var getaRMIMIM = armIMRate.GetContextByConditon(x => x.ARMIMAuditUniverseId == getaRMIMAudit.Id).FirstOrDefault();
                        var getaRMIMIMUnit = aRMIMIMUnit.GetContextByConditon(x => x.ARMIMAuditUniverseId == getaRMIMAudit.Id).FirstOrDefault();
                        var getaRMIMBDPWMIAMIMRetail = aRMIMBDPWMIAMIMRetail.GetContextByConditon(x => x.ARMIMAuditUniverseId == getaRMIMAudit.Id).FirstOrDefault();
                        var getaRMIMFundAccount = aRMIMFundAccount.GetContextByConditon(x => x.ARMIMAuditUniverseId == getaRMIMAudit.Id).FirstOrDefault();
                        var getaRMIMFundAdmin = aRMIMFundAdmin.GetContextByConditon(x => x.ARMIMAuditUniverseId == getaRMIMAudit.Id).FirstOrDefault();
                        var getaRMIMRetailOperation = aRMIMRetailOperation.GetContextByConditon(x => x.ARMIMAuditUniverseId == getaRMIMAudit.Id).FirstOrDefault();
                        var getarmIMResearch = armIMResearch.GetContextByConditon(x => x.ARMIMAuditUniverseId == getaRMIMAudit.Id).FirstOrDefault();
                        var getaRMIMRegistrar = aRMIMRegistrar.GetContextByConditon(x => x.ARMIMAuditUniverseId == getaRMIMAudit.Id).FirstOrDefault();
                        var getaRMIMOperationSettlement = aRMIMOperationSettlement.GetContextByConditon(x => x.ARMIMAuditUniverseId == getaRMIMAudit.Id).FirstOrDefault();
                        var getaRMIMOperationControl = aRMIMOperationControl.GetContextByConditon(x => x.ARMIMAuditUniverseId == getaRMIMAudit.Id).FirstOrDefault();

                        var auditUniverse = new ARMIMAuditUniverseResp
                        {
                            BusinessName = "ARMIM",
                            busnessRiskRatingId = item.BusinessRiskRatingId,
                            ARMIM = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getaRMIMIM.BusinessManagerConcern,
                                DirectorConcern = getaRMIMIM.DirectorConcern,
                                RiskScore = getaRMIMIM.RiskScore,
                                OldRiskScore = getaRMIMIM.OldRiskScore,
                                RiskRating = getaRMIMIM.RiskRating,
                                Recommentation = getaRMIMIM.Recommentation
                            },
                            IMUnit = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getaRMIMIMUnit.BusinessManagerConcern,
                                DirectorConcern = getaRMIMIMUnit.DirectorConcern,
                                RiskScore = getaRMIMIMUnit.RiskScore,
                                OldRiskScore = getaRMIMIMUnit.OldRiskScore,
                                RiskRating = getaRMIMIMUnit.RiskRating,
                                Recommentation = getaRMIMIMUnit.Recommentation
                            },
                            OperationControl = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getaRMIMOperationControl.BusinessManagerConcern,
                                DirectorConcern = getaRMIMOperationControl.DirectorConcern,
                                RiskScore = getaRMIMOperationControl.RiskScore,
                                OldRiskScore = getaRMIMOperationControl.OldRiskScore,
                                RiskRating = getaRMIMOperationControl.RiskRating,
                                Recommentation = getaRMIMOperationControl.Recommentation
                            },
                            OperationSettlement = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getaRMIMOperationSettlement.BusinessManagerConcern,
                                DirectorConcern = getaRMIMOperationSettlement.DirectorConcern,
                                RiskScore = getaRMIMOperationSettlement.RiskScore,
                                OldRiskScore = getaRMIMOperationSettlement.OldRiskScore,
                                RiskRating = getaRMIMOperationSettlement.RiskRating,
                                Recommentation = getaRMIMOperationSettlement.Recommentation
                            },
                            ARMRegistrar = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getaRMIMRegistrar.BusinessManagerConcern,
                                DirectorConcern = getaRMIMRegistrar.DirectorConcern,
                                RiskScore = getaRMIMRegistrar.RiskScore,
                                OldRiskScore = getaRMIMRegistrar.OldRiskScore,
                                RiskRating = getaRMIMRegistrar.RiskRating,
                                Recommentation = getaRMIMRegistrar.Recommentation
                            },
                            FundAdmin = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getaRMIMFundAdmin.BusinessManagerConcern,
                                DirectorConcern = getaRMIMFundAdmin.DirectorConcern,
                                RiskScore = getaRMIMFundAdmin.RiskScore,
                                OldRiskScore = getaRMIMFundAdmin.OldRiskScore,
                                RiskRating = getaRMIMFundAdmin.RiskRating,
                                Recommentation = getaRMIMFundAdmin.Recommentation
                            },
                            FundAccount = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getaRMIMFundAccount.BusinessManagerConcern,
                                DirectorConcern = getaRMIMFundAccount.DirectorConcern,
                                RiskScore = getaRMIMFundAccount.RiskScore,
                                OldRiskScore = getaRMIMFundAccount.OldRiskScore,
                                RiskRating = getaRMIMFundAccount.RiskRating,
                                Recommentation = getaRMIMFundAccount.Recommentation
                            },
                            BDPWMIAMIMRetail = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getaRMIMBDPWMIAMIMRetail.BusinessManagerConcern,
                                DirectorConcern = getaRMIMBDPWMIAMIMRetail.DirectorConcern,
                                RiskScore = getaRMIMBDPWMIAMIMRetail.RiskScore,
                                OldRiskScore = getaRMIMBDPWMIAMIMRetail.OldRiskScore,
                                RiskRating = getaRMIMBDPWMIAMIMRetail.RiskRating,
                                Recommentation = getaRMIMBDPWMIAMIMRetail.Recommentation
                            },
                            RetailOperation = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getaRMIMRetailOperation.BusinessManagerConcern,
                                DirectorConcern = getaRMIMRetailOperation.DirectorConcern,
                                RiskScore = getaRMIMRetailOperation.RiskScore,
                                OldRiskScore = getaRMIMRetailOperation.OldRiskScore,
                                RiskRating = getaRMIMRetailOperation.RiskRating,
                                Recommentation = getaRMIMRetailOperation.Recommentation
                            },

                            Research= new AuditUniverseResp
                            {
                                BusinessManagerConcern = getarmIMResearch.BusinessManagerConcern,
                                DirectorConcern = getarmIMResearch.DirectorConcern,
                                RiskScore = getarmIMResearch.RiskScore,
                                OldRiskScore = getarmIMResearch.OldRiskScore,
                                RiskRating = getarmIMResearch.RiskRating,
                                Recommentation = getarmIMResearch.Recommentation
                            }
                        };

                        return TypedResults.Ok(auditUniverse);
                    }

                }
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }

        }
    }

}
