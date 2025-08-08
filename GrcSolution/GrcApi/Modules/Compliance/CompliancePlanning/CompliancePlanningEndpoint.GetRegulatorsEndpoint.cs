using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 07/06/2024
     * Development Group: GRCTools
     * Compliance Planning: Get Regulator details with Rules Endpoint     
     */
    public class GetRegulatorsEndpoint
    {
        /// <summary>
        /// Get Regulator details with Rules Endpoint  
        /// </summary>
        /// <param name="regulator"></param>
        /// <param name="rule"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<ComplianceRegulator> regulator,
           ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var getregulator = regulator.GetAll()
                                            .Include(g => g.ComplianceRules)
                                            .OrderByDescending(g => g.CreatedOnUtc);

                var resp = getregulator.Select(r => new GetRegulatorDetailsResponse
                {
                    RegulatorId = r.Id,
                    RegulatorTitle = r.RegulatorTitle,
                    Description = r.Description,
                    NoOfRules = r.ComplianceRules.Count,
                    CreatedBy = r.InitiatedBy,
                    DateCreated = r.CreatedOnUtc,
                    ModifiedBy = r.UpdatedBy,
                    DateModified = r.ModifiedOnUtc,
                }).ToList();

                return TypedResults.Ok(resp);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }

        }
    }
}
