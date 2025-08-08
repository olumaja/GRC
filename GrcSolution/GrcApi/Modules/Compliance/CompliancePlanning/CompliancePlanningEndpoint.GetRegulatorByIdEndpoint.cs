using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
    * Original Author: Sodiq Quadre
    * Date Created: 07/06/2024
    * Development Group: GRCTools
    * Compliance Planning: Get Created Regulator by Id Endpoint     
    */
    public class GetRegulatorByIdEndpoint
    {
        /// <summary>
        /// Get Created Regulator by Id Endpoint  
        /// </summary>
        /// <param name="ruleid"></param>
        /// <param name="rule"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid regulatorid, IRepository<ComplianceRegulator> regulator, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                var getreg = regulator.GetContextByConditon(x => x.Id == regulatorid).FirstOrDefault();
                if (getreg == null)
                {
                    return TypedResults.NotFound($"Regulator was not found");
                }

                if (getreg != null)
                {
                    GetComplianceRegulatorById resp = new GetComplianceRegulatorById
                    {
                        RegulatorId = getreg.Id,
                        RegulatorTitle = getreg.RegulatorTitle,
                        Description = getreg.Description,
                        DateCreated = getreg.CreatedOnUtc,
                        CreatedBy = getreg.InitiatedBy,
                        ModifiedBy = getreg.UpdatedBy,
                        DateModified = getreg.ModifiedOnUtc,
                    };
                    return TypedResults.Ok(resp);
                }
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }


        }
    }
}
