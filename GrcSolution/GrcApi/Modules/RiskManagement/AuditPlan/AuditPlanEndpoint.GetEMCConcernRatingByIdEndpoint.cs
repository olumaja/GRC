using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 01/03/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* This endpoint get emc's concern risk rating by Id or get all emc's concern risk rating
*/
    public class GetEMCConcernRatingByIdEndpoint
    {

        /// <summary>
        /// Get EMC's concern risk rating by Id or get all emc's concern risk rating
        /// </summary>
        /// <param name="id"></param>
        /// <param name="getEmcConcern"></param>
        /// <param name="armholdco"></param>
        /// <param name="armim"></param>
        /// <param name="armsecurity"></param>
        /// <param name="armtrustee"></param>
        /// <param name="armhill"></param>
        /// <param name="armtarmagri"></param>
        /// <param name="armshareservice"></param>
        /// <param name="user"></param>   
        /// <returns></returns>        
        public static async Task<IResult> HandleAsync(Guid id, IRepository<EMCConcernRiskRating> getEmcConcern, IRepository<ARMHoldingCompanyEMCRating> armholdco, IRepository<ARMIMEMCRating> armim,
            IRepository<ARMSecurityEMCRating> armsecurity, IRepository<ARMTrusteeEMCRating> armtrustee, IRepository<ARMHILLEMCRating> armhill, IRepository<ARMAgribusinessEMCRating> armtarmagri,
            IRepository<DigitalFinancialServiceEMCRating> dfs, IRepository<ARMCapitalEMCRating> armCapital, IRepository<ARMTAMEMCRating> tam,
            IRepository<ARMSharedServiceEMCRating> armshareservice, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                //var year = DateTime.Now.Year;
                var getEmcConcernRating = getEmcConcern.GetContextByConditon(x => x.Id == id).FirstOrDefault();
                if (getEmcConcernRating == null)
                {
                    return TypedResults.NotFound();
                }
                if (id != default && getEmcConcernRating != null)
                {
                    var getEmcConcernarmholdcoRating = armholdco.GetContextByConditon(x => x.EMCConcernRiskRatingId == id).FirstOrDefault();
                    var getEmcConcernarmimRating = armim.GetContextByConditon(x => x.EMCConcernRiskRatingId == id).FirstOrDefault();                    
                    var getEmcConcernarmTAMRating = tam.GetContextByConditon(x => x.EMCConcernRiskRatingId == id).FirstOrDefault();
                    var getEmcConcernarmDFSRating = dfs.GetContextByConditon(x => x.EMCConcernRiskRatingId == id).FirstOrDefault();                  
                    var getEmcConcernARMCapitalRating = armCapital.GetContextByConditon(x => x.EMCConcernRiskRatingId == id).FirstOrDefault();                  
                    var getEmcConcernarmsecurityRating = armsecurity.GetContextByConditon(x => x.EMCConcernRiskRatingId == id).FirstOrDefault();
                    var getEmcConcernarmtrusteeRating = armtrustee.GetContextByConditon(x => x.EMCConcernRiskRatingId == id).FirstOrDefault();
                    var getEmcConcernarmhillRating = armhill.GetContextByConditon(x => x.EMCConcernRiskRatingId == id).FirstOrDefault();
                    var getEmcConcernarmtarmagriRating = armtarmagri.GetContextByConditon(x => x.EMCConcernRiskRatingId == id).FirstOrDefault();
                    var getEmcConcernarmshareserviceRating = armshareservice.GetContextByConditon(x => x.EMCConcernRiskRatingId == id).FirstOrDefault();

                    GetEmcConcernRatingResp resp = new GetEmcConcernRatingResp
                    {
                        Id = id,
                        ARMHoldingCompany = new ARMHoldingCompanyResponse
                        {
                            ARMHoldingCompany = getEmcConcernarmholdcoRating.ARMHoldingCompany,
                            TreasurySales = getEmcConcernarmholdcoRating.TreasurySales
                        },
                        ARMTAM = new EMCARMTAMResponse
                        {
                            ARMTAM = getEmcConcernarmTAMRating.ARMTAM
                        },
                        DigitalFinancialService = new EMCDigitalFinancialServiceResponse
                         {
                             DigitalFinancialService = getEmcConcernarmDFSRating.DigitalFinancialService
                         },
                        ARMCapital = new EMCARMCapitalResponse
                        {
                            ARMCapital = getEmcConcernARMCapitalRating.ARMCapital
                        },
                        ARMIM = new ARMIMResponse
                        {
                            ARMIM = getEmcConcernarmimRating.ARMIM,
                            ARMRegisterar = getEmcConcernarmimRating.ARMRegisterar,
                            FundAdmin = getEmcConcernarmimRating.FundAdmin,
                            IMUnit = getEmcConcernarmimRating.IMUnit,
                            BDOrIMRetail = getEmcConcernarmimRating.BDOrIMRetail,
                            Fundaccount = getEmcConcernarmimRating.Fundaccount,
                            OperationControl = getEmcConcernarmimRating.OperationControl,
                            OperationSetlement = getEmcConcernarmimRating.OperationSetlement,
                            RetailOperations = getEmcConcernarmimRating.RetailOperations,
                            Research = getEmcConcernarmimRating.Research,
                        },
                        ARMHILL = new ARMHILLResponse
                        {
                            ARMHILL = getEmcConcernarmhillRating.ARMHILL
                        },
                        ARMTrustee = new ARMTrusteeResponse
                        {
                            CommercialTrust = getEmcConcernarmtrusteeRating.CommercialTrust,
                            PrivateTrust = getEmcConcernarmtrusteeRating.PrivateTrust
                        },
                        ARMSecurity = new ARMSecurityResponse
                        {
                            StockBroking = getEmcConcernarmsecurityRating.StockBroking,
                        },
                        ARMAgribusiness = new ARMAgribusinessResponse
                        {
                            AAFML = getEmcConcernarmtarmagriRating.AAFML,
                            RFL = getEmcConcernarmtarmagriRating.RFL
                        },
                        ARMSharedService = new ARMSharedServiceResponse
                        {                           
                            HCM = getEmcConcernarmshareserviceRating.HCM,
                            CorporateStrategy = getEmcConcernarmshareserviceRating.CorporateStrategy,
                            CTO = getEmcConcernarmshareserviceRating.CTO,
                            IT = getEmcConcernarmshareserviceRating.IT,
                            Academy = getEmcConcernarmshareserviceRating.Academy,
                            ProcurementAndAdmin = getEmcConcernarmshareserviceRating.ProcurementAndAdmin,
                            Legal = getEmcConcernarmshareserviceRating.Legal,
                            MCC = getEmcConcernarmshareserviceRating.MCC,
                            CustomerExperience = getEmcConcernarmshareserviceRating.CustomerExperience,
                            InfoSecurity = getEmcConcernarmshareserviceRating.InfoSecurity,
                            InternalControl = getEmcConcernarmshareserviceRating.InternalControl,
                            RiskManagement = getEmcConcernarmshareserviceRating.RiskManagement,
                            Treasury = getEmcConcernarmshareserviceRating.Treasury,
                            FinancialControl = getEmcConcernarmshareserviceRating.FinancialControl,
                            Compliance = getEmcConcernarmshareserviceRating.Compliance,
                            DataAnalytic = getEmcConcernarmshareserviceRating.DataAnalytic,
                        },
                        Comment = getEmcConcernRating.Comment
                    };
                    return TypedResults.Ok(resp);

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
