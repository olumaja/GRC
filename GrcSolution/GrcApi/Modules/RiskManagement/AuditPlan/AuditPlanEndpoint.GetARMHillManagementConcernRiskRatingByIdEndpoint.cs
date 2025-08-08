using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 01/03/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* This endpoint get armhill management concern risk rating by id
*/
    public class GetARMHillManagementConcernRiskRatingByIdEndpoint
    {
        /// <summary>
        /// Get armhill management concern risk rating by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="managementConcernRating"></param>
        /// <param name="armhill"></param>
        /// <param name="armhillbusiness"></param>
        /// <param name="armhillshareservice"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid id, IRepository<ManagementConcernRiskRating> managementConcernRating,
            IRepository<ManagementConcernARMHill> armhill, IRepository<ManagementConcernBusinessUnitARMHillRating> armhillbusiness, IRepository<ManagementConcernSharedServiceARMHillRating> armhillshareservice,
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
                    var getarmhillRating = armhill.GetContextByConditon(x => x.ManagementConcernRiskRatingId == id).FirstOrDefault();
                    var getarmhillBusinessRating = armhillbusiness.GetContextByConditon(x => x.ManagementConcernARMHillId == getarmhillRating.Id).FirstOrDefault();
                    var getarmhillSharedserviceRating = armhillshareservice.GetContextByConditon(x => x.ManagementConcernARMHillId == getarmhillRating.Id).FirstOrDefault();

                    GetARMHillManagementConcernRatingById resp = new GetARMHillManagementConcernRatingById
                    {
                        BusinessAndBusinessUnit = new BusinessAndBusinessUnitARMHillRatingARMHillResp
                        {
                            ARMHill = getarmhillBusinessRating.ARMHill
                        },
                        SharedService = new SharedServiceARMHillRatingARMHillResp
                        {
                            HCM = getarmhillSharedserviceRating.HCM,
                            IT = getarmhillSharedserviceRating.IT,
                            CTO = getarmhillSharedserviceRating.CTO,
                            ProcurementAndAdmin = getarmhillSharedserviceRating.ProcurementAndAdmin,
                            CorporateStrategy = getarmhillSharedserviceRating.CorporateStrategy,
                            CustomerExperience = getarmhillSharedserviceRating.CustomerExperience,
                            InformationSecurity = getarmhillSharedserviceRating.InformationSecurity,
                            Legal = getarmhillSharedserviceRating.Legal,
                            InternalControl = getarmhillSharedserviceRating.InternalControl,
                            MCC = getarmhillSharedserviceRating.MCC,
                            RiskManagement = getarmhillSharedserviceRating.RiskManagement,
                            Treasury = getarmhillSharedserviceRating.Treasury,
                            Compliance = getarmhillSharedserviceRating.Compliance,
                            DataAnalytic = getarmhillSharedserviceRating.DataAnalytic,
                            FinancialControl = getarmhillSharedserviceRating.FinancialControl,
                            Academy = getarmhillSharedserviceRating.Academy
                        },
                        Comment = getarmhillRating.Comment
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
