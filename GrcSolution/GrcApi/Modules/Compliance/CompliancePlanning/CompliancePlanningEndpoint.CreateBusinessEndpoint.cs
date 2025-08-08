using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;
using System.Web.Http;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 07/06/2024
     * Development Group: GRCTools
     * Compliance Planning: Create Business Endpoint.     
     */
    public class CreateBusinessEndpoint
    {
        /// <summary>
        /// Create New Business Endpoint.  
        /// </summary> 
        /// <param name="request"></param>
        /// <param name="business"></param>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <returns></returns>

        public static async Task<IResult> HandleAsync([FromBody] ComplianceBusinesDto request, IRepository<ComplianceBusines> business,
            IRepository<ComplianceBusinessDepartment> businessDeptRepo, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                var checkIfBusinessExist = business.GetContextByConditon(c => c.BusinessName == request.BusinessName).FirstOrDefault();

                if (checkIfBusinessExist != null)  
                    return TypedResults.BadRequest($"Business with the name {request.BusinessName} has been previously created");

                var logRequest = ComplianceBusines.Create(request, currentUserService.CurrentUserFullName);
                await business.AddAsync(logRequest);
                var businessDept = request.DepartmentIds.Select(deptId => ComplianceBusinessDepartment.Create(logRequest.Id, deptId))
                                                        .ToList();

                businessDeptRepo.AddRange(businessDept);
                await businessDeptRepo.SaveChangesAsync();
                var response = new AddNewBusinessResp
                {
                    NewBusinessId = logRequest.Id
                };

                return TypedResults.Created($"ar/{response}", response);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }

        }
    }
}
