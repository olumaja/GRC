using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
    * Original Author: Sodiq Quadre
    * Date Created: 07/06/2024
    * Development Group: GRCTools
    * Compliance Planning: Get Created Business Unit Endpoint     
    */
    public class GetCreatedBusinessUnitEndpoint
    {
        /// <summary>
        /// Get Created Business Unit Endpoint   
        /// </summary>
        /// <param name="busines"></param>
        /// <param name="rules"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<ComplianceBusines> busines,
            ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                var getBusiness = busines.GetAll().Include(b => b.ComplianceBusinessDepartment).OrderByDescending(r => r.CreatedOnUtc);

                if (getBusiness == null) { return TypedResults.NotFound("No Business has been created"); }

                List<GetComplianceBusinesResponse> resp = new List<GetComplianceBusinesResponse>();
                foreach (var item in getBusiness)
                {

                    resp.Add(new GetComplianceBusinesResponse
                    {
                        Id = item.Id,
                        BusinessName = item.BusinessName,
                        RCNumber = item.RCNumber,
                        Description = item.Description,
                        Address = item.Address,
                        CTO = item.CTO,
                        BusinessPhoneNumber = item.BusinessPhoneNumber,
                        NameOfManagerOrMD = item.NameOfManagerOrMD,
                        DateCreated = item.CreatedOnUtc,
                        NumberOfDepartment = item.ComplianceBusinessDepartment.Count,
                        CreatedBy = item.InitiatedBy,
                        ModifiedBy = item.UpdatedBy,
                        DateModified = item.ModifiedOnUtc,
                    });
                }

                return TypedResults.Ok(resp);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }

        }
    }
}
