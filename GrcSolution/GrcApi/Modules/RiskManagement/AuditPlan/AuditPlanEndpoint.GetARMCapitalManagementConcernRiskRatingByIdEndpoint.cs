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
 * This endpoint get DFS management concern risk rating by id
 */
    public class GetARMCapitalManagementConcernRiskRatingByIdEndpoint
    {
        /// <summary>
        /// Get DFS management concern risk rating by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="managementConcernRating"></param>
        /// <param name="dfs"></param>
        /// <param name="dfsbusiness"></param>
        /// <param name="dfsshareservice"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid id, IRepository<ManagementConcernRiskRating> managementConcernRating,
            IRepository<ManagementConcernARMCapital> dfs, IRepository<ManagementConcernBusinessUnitARMCapitalRating> dfsbusiness, IRepository<ManagementConcernSharedServiceARMCapitalRating> dfsshareservice,
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
                    var getDFSRating = dfs.GetContextByConditon(x => x.ManagementConcernRiskRatingId == id).FirstOrDefault();
                    var getDFSBusinessRating = dfsbusiness.GetContextByConditon(x => x.ManagementConcernARMCapitalId == getDFSRating.Id).FirstOrDefault();
                    var getDFSSharedserviceRating = dfsshareservice.GetContextByConditon(x => x.ManagementConcernARMCapitalId == getDFSRating.Id).FirstOrDefault();

                    GetARMCapitalManagementConcernRatingById resp = new GetARMCapitalManagementConcernRatingById
                    {
                        BusinessAndBusinessUnit = new BusinessAndBusinessUnitARMCapitalResp
                        {
                            ARMCapital = getDFSBusinessRating.ARMCapital
                        },
                        SharedService = new SharedServiceARMCapitalResp
                        {
                            HCM = getDFSSharedserviceRating.HCM,
                            IT = getDFSSharedserviceRating.IT,
                            CTO = getDFSSharedserviceRating.CTO,
                            ProcurementAndAdmin = getDFSSharedserviceRating.ProcurementAndAdmin,
                            CorporateStrategy = getDFSSharedserviceRating.CorporateStrategy,
                            CustomerExperience = getDFSSharedserviceRating.CustomerExperience,
                            InformationSecurity = getDFSSharedserviceRating.InformationSecurity,
                            Legal = getDFSSharedserviceRating.Legal,
                            InternalControl = getDFSSharedserviceRating.InternalControl,
                            MCC = getDFSSharedserviceRating.MCC,
                            RiskManagement = getDFSSharedserviceRating.RiskManagement,
                            Treasury = getDFSSharedserviceRating.Treasury,
                            Compliance = getDFSSharedserviceRating.Compliance,
                            DataAnalytic = getDFSSharedserviceRating.DataAnalytic,
                            FinancialControl = getDFSSharedserviceRating.FinancialControl,
                            Academy = getDFSSharedserviceRating.Academy
                        },
                        Comment = getDFSRating.Comment
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
