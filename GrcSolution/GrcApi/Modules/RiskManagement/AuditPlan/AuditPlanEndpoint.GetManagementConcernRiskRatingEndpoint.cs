using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 01/03/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 * This endpoint to get all management concern risk rating
 */
    public class GetManagementConcernRiskRatingEndpoint
    {
        /// <summary>
        /// Get get all management concern risk rating
        /// </summary>
        /// <param name="managementConcernRating"></param>
        /// <param name="armim"></param>
        /// <param name="armtrustee"></param>
        /// <param name="armsecurity"></param>
        /// <param name="armhill"></param>
        /// <param name="armagri"></param>
        /// <param name="dfs"></param>
        /// <param name="armCapital"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<ManagementConcernRiskRating> managementConcernRating,
            IRepository<ManagementConcernARMIM> armim, IRepository<ManagementConcernARMTrustee> armtrustee, IRepository<ManagementConcernARMSecurity> armsecurity, 
            IRepository<ManagementConcernARMHill> armhill, IRepository<ManagementConcernARMAgribusiness> armagri, IRepository<ManagementConcernDFS> dfs, 
            IRepository<ManagementConcernARMCapital> armCapital, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                List<GetMCConcernRatingResp> resp = new List<GetMCConcernRatingResp>();
                var getMCRatings = managementConcernRating.GetContextByConditon(c => c.Id != null).ToList();
                if (getMCRatings == null)
                {
                    return TypedResults.NotFound();
                }
                if (getMCRatings != null)
                {
                    foreach (var item2 in getMCRatings)
                    {
                        
                        var getMCConcern = dfs.GetContextByConditon(x => x.ManagementConcernRiskRatingId == item2.Id).FirstOrDefault();
                        var getarmCapitalRate = armCapital.GetContextByConditon(x => x.ManagementConcernRiskRatingId == item2.Id).FirstOrDefault();
                        var getarmhill = armhill.GetContextByConditon(x => x.ManagementConcernRiskRatingId == item2.Id).FirstOrDefault();
                        var getarmtrustee = armtrustee.GetContextByConditon(x => x.ManagementConcernRiskRatingId == item2.Id).FirstOrDefault();
                        var getarmsecurity = armsecurity.GetContextByConditon(x => x.ManagementConcernRiskRatingId == item2.Id).FirstOrDefault();
                        var getarmagri = armagri.GetContextByConditon(x => x.ManagementConcernRiskRatingId == item2.Id).FirstOrDefault();
                        var getarmim = armim.GetContextByConditon(x => x.ManagementConcernRiskRatingId == item2.Id).FirstOrDefault();

                        resp.Add(new GetMCConcernRatingResp
                        {
                            Id = item2.Id,
                            ARMIM = new MCSummary
                            {
                                MCRequesterName = getarmim.RequesterName,
                                Comment = getarmim.Comment,
                                DateCreated = getarmim.CreatedOnUtc
                            },
                            ARMCapital = new MCSummary
                            {
                                MCRequesterName = getarmCapitalRate.RequesterName,
                                Comment = getarmCapitalRate.Comment,
                                DateCreated = getarmCapitalRate.CreatedOnUtc
                            },
                            DigitalFinancialService = new MCSummary
                            {
                                MCRequesterName = getMCConcern.RequesterName,
                                Comment = getMCConcern.Comment,
                                DateCreated = getMCConcern.CreatedOnUtc
                            },
                            ARMHILL = new MCSummary
                            {
                                MCRequesterName = getarmhill.RequesterName,
                                Comment = getarmhill.Comment,
                                DateCreated = getarmhill.CreatedOnUtc
                            },
                            ARMTrustee = new MCSummary
                            {
                                MCRequesterName = getarmtrustee.RequesterName,
                                Comment = getarmtrustee.Comment,
                                DateCreated = getarmtrustee.CreatedOnUtc
                            },
                            ARMAgribusiness = new MCSummary
                            {
                                MCRequesterName = getarmagri.RequesterName,
                                Comment = getarmagri.Comment,
                                DateCreated = getarmagri.CreatedOnUtc
                            },
                            ARMSecurity = new MCSummary
                            {
                                MCRequesterName = getarmsecurity.RequesterName,
                                Comment = getarmsecurity.Comment,
                                DateCreated = getarmsecurity.CreatedOnUtc
                            }

                        });

                    }
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
