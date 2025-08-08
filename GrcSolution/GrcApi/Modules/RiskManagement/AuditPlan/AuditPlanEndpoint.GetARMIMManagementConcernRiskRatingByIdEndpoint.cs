using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 10/03/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* This endpoint get armim management concern risk rating by id
*/
    public class GetARMIMManagementConcernRiskRatingByIdEndpoint
    {
        /// <summary>
        /// Get armim management concern risk rating by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="managementConcernRating"></param>
        /// <param name="armim"></param>
        /// <param name="armimbusiness"></param>
        /// <param name="arminshareservice"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid id, IRepository<ManagementConcernRiskRating> managementConcernRating,
            IRepository<ManagementConcernARMIM> armim, IRepository<ManagementConcernBusinessUnitARMIMRating> armimbusiness, IRepository<ManagementConcernSharedServiceARMIMRating> arminshareservice,

            ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var getmanagementoncernRating = managementConcernRating.GetContextByConditon(x => x.Id == id).FirstOrDefault();
                if (id != default && getmanagementoncernRating != null)
                {
                    var getarmimRating = armim.GetContextByConditon(x => x.ManagementConcernRiskRatingId == id).FirstOrDefault();
                    var getarmimBusinessRating = armimbusiness.GetContextByConditon(x => x.ManagementConcernARMIMId == getarmimRating.Id).FirstOrDefault();
                    var getarmimShareserviceRating = arminshareservice.GetContextByConditon(x => x.ManagementConcernARMIMId == getarmimRating.Id).FirstOrDefault();

                    GetARMIMManagementConcernById resp = new GetARMIMManagementConcernById
                    {
                        BusinessAndBusinessUnit = new BusinessAndBusinessUnitARMIMRatingARMIMResp
                        {
                            ARMIM = getarmimBusinessRating.ARMIM,
                            IMUnit = getarmimBusinessRating.IMUnit,
                            ARMRegistrar = getarmimBusinessRating.ARMRegistrar,
                            FundAccount = getarmimBusinessRating.FundAccount,
                            FundAdmin = getarmimBusinessRating.FundAdmin,
                            BDOrIMRetail = getarmimBusinessRating.BDOrIMRetail,
                            OperationControl = getarmimBusinessRating.OperationControl,
                            OperationSettlement = getarmimBusinessRating.OperationSettlement,
                            RetailOperation = getarmimBusinessRating.RetailOperation,
                            Research = getarmimBusinessRating.Research,
                        },
                        SharedService = new SharedServiceARMIMRatingARMIMResp
                        {
                            HCM = getarmimShareserviceRating.HCM,
                            IT = getarmimShareserviceRating.IT,
                            CTO = getarmimShareserviceRating.CTO,
                            ProcurementAndAdmin = getarmimShareserviceRating.ProcurementAndAdmin,
                            CorporateStrategy = getarmimShareserviceRating.CorporateStrategy,
                            CustomerExperience = getarmimShareserviceRating.CustomerExperience,
                            InformationSecurity = getarmimShareserviceRating.InformationSecurity,
                            Legal = getarmimShareserviceRating.Legal,
                            InternalControl = getarmimShareserviceRating.InternalControl,
                            MCC = getarmimShareserviceRating.MCC,
                            RiskManagement = getarmimShareserviceRating.RiskManagement,
                            Treasury = getarmimShareserviceRating.Treasury,
                            FinancialControl = getarmimShareserviceRating.FinancialControl,
                            DataAnalytic = getarmimShareserviceRating.DataAnalytic,
                            Compliance = getarmimShareserviceRating.Compliance,
                            Academy = getarmimShareserviceRating.Academy

                        },
                        Comment = getarmimRating.Comment
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
