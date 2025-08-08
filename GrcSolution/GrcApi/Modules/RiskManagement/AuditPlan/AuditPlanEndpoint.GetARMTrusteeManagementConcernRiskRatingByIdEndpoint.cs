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
* This endpoint get armtrustee management concern risk rating by id
*/
    public class GetARMTrusteeManagementConcernRiskRatingByIdEndpoint
    {
        /// <summary>
        /// Get armtrustee management concern risk rating by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="managementConcernRating"></param>
        /// <param name="armtrustee"></param>
        /// <param name="armtrusteebusiness"></param>
        /// <param name="armtrusteeshareservice"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid id, IRepository<ManagementConcernRiskRating> managementConcernRating,
            IRepository<ManagementConcernARMTrustee> armtrustee, IRepository<ManagementConcernBusinessUnitARMTrusteeRating> armtrusteebusiness, IRepository<ManagementConcernSharedServiceARTrusteeRating> armtrusteeshareservice,
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
                    var getarmtrusteeRating = armtrustee.GetContextByConditon(x => x.ManagementConcernRiskRatingId == id).FirstOrDefault();
                    var getarmtrusteebusinessRating = armtrusteebusiness.GetContextByConditon(x => x.ManagementConcernARMTrusteeId == getarmtrusteeRating.Id).FirstOrDefault();
                    var getarmtrusteeShareserviceRating = armtrusteeshareservice.GetContextByConditon(x => x.ManagementConcernARMTrusteeId == getarmtrusteeRating.Id).FirstOrDefault();

                    GetARMTrusteeManagementConcernRatingById resp = new GetARMTrusteeManagementConcernRatingById
                    {
                        BusinessAndBusinessUnit = new BusinessAndBusinessUnitARMTrusteeRatingARMTrusteeResp
                        {
                            CommercialTrust = getarmtrusteebusinessRating.CommercialTrust,
                            PrivateTrust = getarmtrusteebusinessRating.PrivateTrust
                        },
                        SharedService = new SharedServiceARTrusteeRatingARMTrusteeResp
                        {
                            HCM = getarmtrusteeShareserviceRating.HCM,
                            IT = getarmtrusteeShareserviceRating.IT,
                            CTO = getarmtrusteeShareserviceRating.CTO,
                            ProcurementAndAdmin = getarmtrusteeShareserviceRating.ProcurementAndAdmin,
                            CorporateStrategy = getarmtrusteeShareserviceRating.CorporateStrategy,
                            CustomerExperience = getarmtrusteeShareserviceRating.CustomerExperience,
                            InformationSecurity = getarmtrusteeShareserviceRating.InformationSecurity,
                            Legal = getarmtrusteeShareserviceRating.Legal,
                            InternalControl = getarmtrusteeShareserviceRating.InternalControl,
                            MCC = getarmtrusteeShareserviceRating.MCC,
                            RiskManagement = getarmtrusteeShareserviceRating.RiskManagement,
                            Treasury = getarmtrusteeShareserviceRating.Treasury,
                            FinancialControl = getarmtrusteeShareserviceRating.FinancialControl,
                            DataAnalytic = getarmtrusteeShareserviceRating.DataAnalytic,
                            Compliance = getarmtrusteeShareserviceRating.Compliance,
                            Academy = getarmtrusteeShareserviceRating.Academy
                        },
                        Comment = getarmtrusteeRating.Comment
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
