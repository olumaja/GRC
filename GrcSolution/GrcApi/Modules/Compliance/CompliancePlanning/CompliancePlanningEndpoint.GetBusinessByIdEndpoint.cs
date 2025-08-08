using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
     * Original Author: Olusegun Adaramaja
     * Date Created: 15/08/2024
     * Development Group: GRCTools
     * Compliance Planning: Get Business by Id.     
     */
    public class GetBusinessByIdEndpoint
    {
        /// <summary>
        /// Get business by Id
        /// </summary>
        /// <param name="businessId"></param>
        /// <param name="businessRepo"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid businessId, IRepository<ComplianceBusines> businessRepo, ICurrentUserService currentUserService)
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                return TypedResults.Unauthorized();

            var business = businessRepo.GetContextByConditon(b => b.Id == businessId)
                                        .Include(b => b.ComplianceBusinessDepartment)
                                        .ThenInclude(d => d.ComplianceDepartment)
                                        .FirstOrDefault();

            if (business is null)
                return TypedResults.BadRequest("Business does not exist");

            var result = new GetComplianceBusinesByIdResponse
            {
                Id = business.Id,
                BusinessName = business.BusinessName,
                BusinessPhoneNumber = business.BusinessPhoneNumber,
                RCNumber = business.RCNumber,
                Description = business.Description,
                Address = business.Address,
                NameOfManagerOrMD = business.NameOfManagerOrMD,
                CTO = business.CTO,
                DateCreated = business.CreatedOnUtc,
                CreatedBy = business.InitiatedBy,
                ModifiedBy = business.UpdatedBy,
                DateModified = business.ModifiedOnUtc,
                Departments = business.ComplianceBusinessDepartment
                                .Select(d => new GetComplianceDeparment(
                                    Id: d.ComplianceDepartment.Id,
                                    Name: d.ComplianceDepartment.Name
                                ))
                                .ToList()
            };
            
            return TypedResults.Ok(result);
        }
    }


}
