using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 01/03/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* This endpoint get armsecurity management concern risk rating by id
*/
    public class GetARMSecurityManagementConcernRiskRatingByIdEndpoint
    {

        /// <summary>
        /// Get armsecurity management concern risk rating by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="managementConcernRating"></param>
        /// <param name="armsecurity"></param>
        /// <param name="armsecuritybusiness"></param>
        /// <param name="armsecurityshareservice"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid id, IRepository<ManagementConcernRiskRating> managementConcernRating,
            IRepository<ManagementConcernARMSecurity> armsecurity, IRepository<ManagementConcernBusinessUnitARMSecurityRating> armsecuritybusiness, IRepository<ManagementConcernSharedServiceARMSecurityRating> armsecurityshareservice,
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

                    var getarmsecurityRating = armsecurity.GetContextByConditon(x => x.ManagementConcernRiskRatingId == id).FirstOrDefault();
                    var getarmsecurityBusinessRating = armsecuritybusiness.GetContextByConditon(x => x.ManagementConcernARMSecurityId == getarmsecurityRating.Id).FirstOrDefault();
                    var getarmsecuritysharedserviceRating = armsecurityshareservice.GetContextByConditon(x => x.ManagementConcernARMSecurityId == getarmsecurityRating.Id).FirstOrDefault();

                    GetARMSecurityManagementConcernRatingById resp = new GetARMSecurityManagementConcernRatingById
                    {
                        BusinessAndBusinessUnit = new BusinessAndBusinessUnitARMSecurityRatingARMSecurityResp
                        {
                            StockBroking = getarmsecurityBusinessRating.StockBroking,
                        },
                        SharedService = new SharedServiceARMSecurityRatingARMSecurityResp
                        {
                            HCM = getarmsecuritysharedserviceRating.HCM,
                            IT = getarmsecuritysharedserviceRating.IT,
                            CTO = getarmsecuritysharedserviceRating.CTO,
                            ProcurementAndAdmin = getarmsecuritysharedserviceRating.ProcurementAndAdmin,
                            CorporateStrategy = getarmsecuritysharedserviceRating.CorporateStrategy,
                            CustomerExperience = getarmsecuritysharedserviceRating.CustomerExperience,
                            InformationSecurity = getarmsecuritysharedserviceRating.InformationSecurity,
                            Legal = getarmsecuritysharedserviceRating.Legal,
                            InternalControl = getarmsecuritysharedserviceRating.InternalControl,
                            MCC = getarmsecuritysharedserviceRating.MCC,
                            RiskManagement = getarmsecuritysharedserviceRating.RiskManagement,
                            Treasury = getarmsecuritysharedserviceRating.Treasury,
                            DataAnalytic = getarmsecuritysharedserviceRating.DataAnalytic,
                            FinancialControl = getarmsecuritysharedserviceRating.FinancialControl,
                            Compliance = getarmsecuritysharedserviceRating.Compliance,
                            Academy = getarmsecuritysharedserviceRating.Academy
                        },
                        Comment = getarmsecurityRating.Comment
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
