using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.PRA;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.PRA
{
    /*
     * Original Author: Olusegun Adaramaja
     * Date Created: 24/11/2023
     * Development Group: GRCTools
     * This endpoint fetch all product risk assessment
     */
    public class GetAllProductRiskAssessmentEndpoint
    {
        /// <summary>
        /// The endpoint fetch all the product risk assessment
        /// </summary>
        /// <param name="user"></param>
        /// <param name="productRiskRepo"></param>
        /// <param name="businessRepo"></param>
        /// <param name="deptRepo"></param>
        /// <param name="unitRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            IRepository<ProductRiskAssessment> productRiskRepo, IRepository<BusinessEntity> businessRepo, IRepository<Department> deptRepo,
            IRepository<Unit> unitRepo, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            try
            {
                //var email = user.Claims.FirstOrDefault(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress", StringComparison.OrdinalIgnoreCase));

                var email = currentUserService.CurrentUserEmail;

                if (string.IsNullOrWhiteSpace(email))
                {
                    return TypedResults.Unauthorized();
                }

                var businesses = await businessRepo.GetAllAsync();
                var departments = await deptRepo.GetAllAsync();
                var units = await unitRepo.GetAllAsync();

                var unitIdValue = user.Claims.FirstOrDefault(c => c.Type.Equals("unitId", StringComparison.OrdinalIgnoreCase));
                var products = new List<GetAllProductRiskAssessentDto>();

                if (unitIdValue is null)
                {
                    return TypedResults.Ok(products);
                }
                Guid unitId = new Guid(unitIdValue.Value);

                var productQuery = productRiskRepo.GetContextByConditon(r => r.Stage.Equals(PRAStage.RiskManagement)).Select(r => new ProductRiskAssessentDto(
                        r.Id,
                        r.BusinessId,
                        r.DepartmentId,
                        r.UnitId,
                        r.Status,
                        r.Stage,
                        r.CreatedOnUtc
                    )).ToList();

                foreach (var item in productQuery)
                {
                    var businessName = "";
                    var deptName = "";
                    var unitName = "";
                    var business = businesses.Find(b => b.Id.Equals(item.BusinessId));
                    var depart = departments.Find(d => d.Id.Equals(item.DepartmentId));
                    var unit = units.Find(u => u.Id.Equals(item.UnitId));

                    if (business is not null) businessName = business.Name;
                    if (depart is not null) deptName = depart.Name;
                    if (unit is not null) unitName = unit.Name;

                    products.Add(
                        new GetAllProductRiskAssessentDto(
                            ProductRiskAssessmentId: item.ProductRiskAssessmentId,
                            BusinessName: businessName,
                            DepartmentName: deptName,
                            UnitName: unitName,
                            Status: item.Status,
                            Stage: item.Stage,
                            DateInitiated: item.DateInitiated
                        )
                    );
                }

                return TypedResults.Ok(products);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record not found");
            }
        }
    }
}
