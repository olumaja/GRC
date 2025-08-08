using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Web.Http;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
     * Original Author: Olusegun Adaramaja
     * Date Created: 15/08/2024
     * Development Group: GRCTools
     * Compliance Planning: Update Business Endpoint.     
     */
    public class UpdateBusinessEndpoint
    {
        /// <summary>
        /// The endpoint update business
        /// </summary>
        /// <param name="request"></param>
        /// <param name="business"></param>
        /// <param name="businessDeptRepo"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] UpdateComplianceBusinesDto request, IRepository<ComplianceBusines> business,
            IRepository<ComplianceBusinessDepartment> businessDeptRepo, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                var checkIfBusinessExist = business.GetContextByConditon(b => b.Id == request.BusinessId)
                                                  .Include(b => b.ComplianceBusinessDepartment)
                                                  .FirstOrDefault();

                if (checkIfBusinessExist is null)
                    return TypedResults.Ok($"Business does not exist");

                checkIfBusinessExist.UpdateBusiness(new UpdateComplianceBusiness
                {
                    BusinessName = request.BusinessName,
                    BusinessPhoneNumber = request.BusinessPhoneNumber,
                    RCNumber = request.RCNumber,
                    Address = request.Address,
                    Description = request.Description,
                    NameOfManagerOrMD = request.NameOfManagerOrMD,
                    CTO = request.CTO,
                    UpdatedBy = currentUserService.CurrentUserFullName
                });

                checkIfBusinessExist.SetModifiedOnUtc(DateTime.Now);
                business.Update(checkIfBusinessExist);

                //Remove previous departments
                var businessDepts = checkIfBusinessExist.ComplianceBusinessDepartment.ToList();
                businessDeptRepo.RemoveRange(businessDepts);

                //Add new departments
                var businessDept = request.DepartmentIds.Select(deptId => ComplianceBusinessDepartment.Create(checkIfBusinessExist.Id, deptId))
                                                        .ToList();
                businessDeptRepo.AddRange(businessDept);
                await businessDeptRepo.SaveChangesAsync();
                return TypedResults.Ok("Update successful");
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }
    }
}
