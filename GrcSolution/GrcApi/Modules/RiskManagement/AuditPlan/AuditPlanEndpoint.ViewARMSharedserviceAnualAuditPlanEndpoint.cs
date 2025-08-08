using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using static Arm.GrcApi.Modules.RiskManagement.AuditPlan.AuditUniverseResponse;
using System.Security.Claims;
using GrcApi.Modules.Shared.Helpers;
using Arm.GrcTool.Infrastructure;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
  * Original Author: Sodiq Quadre
  * Date Created: 28/03/2024
  * Development Group: Audit plan Risk Assessment - GRCTools
  * This endpoint get all business and management concern risk rating
  */
    public class ViewARMSharedServiceAnualAuditPlanEndpoint
    {
        /// <summary>
        /// View ARMSharedService Anual Audit Universe
        /// </summary>
        /// <param name="sharedService"></param>
        /// <param name="anualAuditUniverse"></param>
        /// <param name="aRMSharedAudit"></param>
        /// <param name="finCtrl"></param>
        /// <param name="it"></param>
        /// <param name="hcm"></param>
        /// <param name="mcc"></param>
        /// <param name="comp"></param>
        /// <param name="academy"></param>
        /// <param name="infosec"></param>
        /// <param name="treasury"></param>
        /// <param name="dataAna"></param>
        /// <param name="legal"></param>
        /// <param name="corporatestrategy"></param>
        /// <param name="ctoRate"></param>
        /// <param name="internalControl"></param>
        /// <param name="customerExperience"></param>
        /// <param name="procurementAndAdmin"></param>
        /// <param name="riskManagement"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<ARMSharedServiceRating> sharedService,
            IRepository<AnualAuditUniverseRiskRating> anualAuditUniverse, IRepository<ARMSharedAuditUniverse> aRMSharedAudit, IRepository<ARMSharedAuditUniverseFinancialControl> finCtrl,
            IRepository<ARMSharedAuditUniverseIT> it, IRepository<ARMSharedAuditUniverseHCM> hcm, IRepository<ARMSharedAuditUniverseMCC> mcc, IRepository<ARMSharedAuditUniverseCompliance> comp,
            IRepository<ARMSharedAuditUniverseAcademy> academy, IRepository<ARMSharedAuditUniverseInformationSecurity> infosec, IRepository<ARMSharedAuditUniverseTreasury> treasury,
            IRepository<ARMSharedAuditUniverseDataAnalytic> dataAna, IRepository<ARMSharedAuditUniverseLegal> legal, IRepository<ARMSharedAuditUniverseCorporatestrategy> corporatestrategy,
            IRepository<ARMSharedAuditUniverseCTO> ctoRate, IRepository<ARMSharedAuditUniverseInternalControl> internalControl, IRepository<ARMSharedAuditUniverseCustomerExperience> customerExperience,
            IRepository<ARMSharedAuditUniverseProcurementAndAdmin> procurementAndAdmin, IRepository<ARMSharedAuditUniverseRiskManagement> riskManagement,
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
                var getRating = sharedService.GetContextByConditon(x => x.Status == BusinessRiskRatingStatus.Approved).ToList();

                var businesses = await anualAuditUniverse.GetAllAsync();
                if (getRating != null)
                {
                    foreach (var item in getRating)
                    {
                        var getanualAuditUniverseResp = businesses.Find(x => x.BusinessRiskRatingId.Equals(item.BusinessRiskRatingId));
                        var getaRMSharedAudit = aRMSharedAudit.GetContextByConditon(x => x.AnualAuditUniverseRiskRatingId == getanualAuditUniverseResp.Id).FirstOrDefault();

                        var getshareddataAna = dataAna.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getaRMSharedAudit.Id).FirstOrDefault();
                        var getIT = it.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getaRMSharedAudit.Id).FirstOrDefault();
                        var getacademy = academy.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getaRMSharedAudit.Id).FirstOrDefault();
                        var gethcm = hcm.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getaRMSharedAudit.Id).FirstOrDefault();
                        var getinfosec = infosec.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getaRMSharedAudit.Id).FirstOrDefault();
                        var getmcc = mcc.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getaRMSharedAudit.Id).FirstOrDefault();
                        var gettreasury = treasury.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getaRMSharedAudit.Id).FirstOrDefault();
                        var getlegal = legal.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getaRMSharedAudit.Id).FirstOrDefault();
                        var getfinCtrl = finCtrl.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getaRMSharedAudit.Id).FirstOrDefault();
                        var getcorporatestrategy = corporatestrategy.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getaRMSharedAudit.Id).FirstOrDefault();
                        var getCTO = ctoRate.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getaRMSharedAudit.Id).FirstOrDefault();
                        var getinternalControl = internalControl.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getaRMSharedAudit.Id).FirstOrDefault();
                        var getcustomerExperience = customerExperience.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getaRMSharedAudit.Id).FirstOrDefault();
                        var getprocurementAndAdmin = procurementAndAdmin.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getaRMSharedAudit.Id).FirstOrDefault();
                        var getriskManagement = riskManagement.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getaRMSharedAudit.Id).FirstOrDefault();
                        var getcomp = comp.GetContextByConditon(x => x.ARMSharedAuditUniverseId == getaRMSharedAudit.Id).FirstOrDefault();

                        var auditUniverse = new ARMSharedServiceAuditUniverseResp
                        {
                            BusinessName = "ARMSharedService",
                            busnessRiskRatingId = item.BusinessRiskRatingId,
                            HCM = new AuditUniverseResp
                            {
                                BusinessManagerConcern = gethcm.BusinessManagerConcern,
                                DirectorConcern = gethcm.DirectorConcern,
                                RiskScore = gethcm.RiskScore,
                                OldRiskScore = gethcm.OldRiskScore,
                                RiskRating = gethcm.RiskRating,
                                Recommentation = gethcm.Recommentation
                            },
                            DataAnalytic = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getshareddataAna.BusinessManagerConcern,
                                DirectorConcern = getshareddataAna.DirectorConcern,
                                RiskScore = getshareddataAna.RiskScore,
                                OldRiskScore = getshareddataAna.OldRiskScore,
                                RiskRating = getshareddataAna.RiskRating,
                                Recommentation = getshareddataAna.Recommentation
                            },
                            Compliance = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getcomp.BusinessManagerConcern,
                                DirectorConcern = getcomp.DirectorConcern,
                                RiskScore = getcomp.RiskScore,
                                OldRiskScore = getcomp.OldRiskScore,
                                RiskRating = getcomp.RiskRating,
                                Recommentation = getcomp.Recommentation
                            },
                            InformationSecurity = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getinfosec.BusinessManagerConcern,
                                DirectorConcern = getinfosec.DirectorConcern,
                                RiskScore = getinfosec.RiskScore,
                                OldRiskScore = getinfosec.OldRiskScore,
                                RiskRating = getinfosec.RiskRating,
                                Recommentation = getinfosec.Recommentation
                            },
                            Treasury = new AuditUniverseResp
                            {
                                BusinessManagerConcern = gettreasury.BusinessManagerConcern,
                                DirectorConcern = gettreasury.DirectorConcern,
                                RiskScore = gettreasury.RiskScore,
                                OldRiskScore = gettreasury.OldRiskScore,
                                RiskRating = gettreasury.RiskRating,
                                Recommentation = gettreasury.Recommentation
                            },
                            FinancialControl = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getfinCtrl.BusinessManagerConcern,
                                DirectorConcern = getfinCtrl.DirectorConcern,
                                RiskScore = getfinCtrl.RiskScore,
                                OldRiskScore = getfinCtrl.OldRiskScore,
                                RiskRating = getfinCtrl.RiskRating,
                                Recommentation = getfinCtrl.Recommentation
                            },
                            Corporatestrategy = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getcorporatestrategy.BusinessManagerConcern,
                                DirectorConcern = getcorporatestrategy.DirectorConcern,
                                RiskScore = getcorporatestrategy.RiskScore,
                                OldRiskScore = getcorporatestrategy.OldRiskScore,
                                RiskRating = getcorporatestrategy.RiskRating,
                                Recommentation = getcorporatestrategy.Recommentation
                            },
                            InternalControl = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getinternalControl.BusinessManagerConcern,
                                DirectorConcern = getinternalControl.DirectorConcern,
                                RiskScore = getinternalControl.RiskScore,
                                OldRiskScore = getinternalControl.OldRiskScore,
                                RiskRating = getinternalControl.RiskRating,
                                Recommentation = getinternalControl.Recommentation
                            },
                            Academy = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getacademy.BusinessManagerConcern,
                                DirectorConcern = getacademy.DirectorConcern,
                                RiskScore = getacademy.RiskScore,
                                OldRiskScore = getacademy.OldRiskScore,
                                RiskRating = getacademy.RiskRating,
                                Recommentation = getacademy.Recommentation
                            },
                            Customerexperience = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getcustomerExperience.BusinessManagerConcern,
                                DirectorConcern = getcustomerExperience.DirectorConcern,
                                RiskScore = getcustomerExperience.RiskScore,
                                OldRiskScore = getcustomerExperience.OldRiskScore,
                                RiskRating = getcustomerExperience.RiskRating,
                                Recommentation = getcustomerExperience.Recommentation
                            },
                            CTO = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getCTO.BusinessManagerConcern,
                                DirectorConcern = getCTO.DirectorConcern,
                                RiskScore = getCTO.RiskScore,
                                OldRiskScore = getCTO.OldRiskScore,
                                RiskRating = getCTO.RiskRating,
                                Recommentation = getCTO.Recommentation
                            },
                            MCC = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getmcc.BusinessManagerConcern,
                                DirectorConcern = getmcc.DirectorConcern,
                                RiskScore = getmcc.RiskScore,
                                OldRiskScore = getmcc.OldRiskScore,
                                RiskRating = getmcc.RiskRating,
                                Recommentation = getmcc.Recommentation
                            },
                            Legal = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getlegal.BusinessManagerConcern,
                                DirectorConcern = getlegal.DirectorConcern,
                                RiskScore = getlegal.RiskScore,
                                OldRiskScore = getlegal.OldRiskScore,
                                RiskRating = getlegal.RiskRating,
                                Recommentation = getlegal.Recommentation
                            },
                            ProcurementAndAdmind = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getprocurementAndAdmin.BusinessManagerConcern,
                                DirectorConcern = getprocurementAndAdmin.DirectorConcern,
                                RiskScore = getprocurementAndAdmin.RiskScore,
                                OldRiskScore = getprocurementAndAdmin.OldRiskScore,
                                RiskRating = getprocurementAndAdmin.RiskRating,
                                Recommentation = getprocurementAndAdmin.Recommentation
                            },
                            IT = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getIT.BusinessManagerConcern,
                                DirectorConcern = getIT.DirectorConcern,
                                RiskScore = getIT.RiskScore,
                                OldRiskScore = getIT.OldRiskScore,
                                RiskRating = getIT.RiskRating,
                                Recommentation = getIT.Recommentation
                            },
                            RiskManagement = new AuditUniverseResp
                            {
                                BusinessManagerConcern = getriskManagement.BusinessManagerConcern,
                                DirectorConcern = getriskManagement.DirectorConcern,
                                RiskScore = getriskManagement.RiskScore,
                                OldRiskScore = getriskManagement.OldRiskScore,
                                RiskRating = getriskManagement.RiskRating,
                                Recommentation = getriskManagement.Recommentation
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
