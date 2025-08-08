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
* This endpoint get armagribusness management concern risk rating by id
*/
    public class GetARMAgribusinessManagementConcernRiskRatingByIdEndpoint
    {
        /// <summary>
        /// Get armagribusiness management concern risk rating by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="managementConcernRating"></param>
        /// <param name="armagri"></param>
        /// <param name="armagribusiness"></param>
        /// <param name="armargrishareservice"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid id, IRepository<ManagementConcernRiskRating> managementConcernRating,
            IRepository<ManagementConcernARMAgribusiness> armagri, IRepository<ManagementConcernBusinessUnitARMAgribusinessRating> armagribusiness, IRepository<ManagementConcernSharedServiceARMAgribusinessRating> armargrishareservice,
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

                    var getarmagriRating = armagri.GetContextByConditon(x => x.ManagementConcernRiskRatingId == id).FirstOrDefault();
                    var getarmagriBusinessRating = armagribusiness.GetContextByConditon(x => x.ManagementConcernARMAgribusinessId == getarmagriRating.Id).FirstOrDefault();
                    var getarmagriSharedserviceRating = armargrishareservice.GetContextByConditon(x => x.ManagementConcernARMAgribusinessId == getarmagriRating.Id).FirstOrDefault();

                    GetArmAgribusinessManagementConcernRatingById resp = new GetArmAgribusinessManagementConcernRatingById
                    {
                        BusinessAndBusinessUnit = new BusinessAndBusinessUnitARMAgribusinessRatingARMAgribusinessResp
                        {
                            RFL = getarmagriBusinessRating.RFL,
                            AAFML = getarmagriBusinessRating.AAFML
                        },
                        SharedService = new SharedServiceARMAgribusinessRatingArmAgribusinessResp
                        {
                            HCM = getarmagriSharedserviceRating.HCM,
                            IT = getarmagriSharedserviceRating.IT,
                            CTO = getarmagriSharedserviceRating.CTO,
                            ProcurementAndAdmin = getarmagriSharedserviceRating.ProcurementAndAdmin,
                            CorporateStrategy = getarmagriSharedserviceRating.CorporateStrategy,
                            CustomerExperience = getarmagriSharedserviceRating.CustomerExperience,
                            InformationSecurity = getarmagriSharedserviceRating.InformationSecurity,
                            Legal = getarmagriSharedserviceRating.Legal,
                            InternalControl = getarmagriSharedserviceRating.InternalControl,
                            MCC = getarmagriSharedserviceRating.MCC,
                            RiskManagement = getarmagriSharedserviceRating.RiskManagement,
                            Treasury = getarmagriSharedserviceRating.Treasury,
                            DataAnalytic = getarmagriSharedserviceRating.DataAnalytic,
                            FinancialControl = getarmagriSharedserviceRating.FinancialControl,
                            Compliance = getarmagriSharedserviceRating.Compliance,
                            Academy = getarmagriSharedserviceRating.Academy
                        },
                        Comment = getarmagriRating.Comment
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
