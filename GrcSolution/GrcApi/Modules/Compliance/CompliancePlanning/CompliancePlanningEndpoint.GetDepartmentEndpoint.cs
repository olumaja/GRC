using Arm.GrcTool.Infrastructure;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
    * Original Author: Olusegun Adaramaja
    * Date Created: 15/08/2024
    * Development Group: GRCTools
    * Compliance Planning: Get all departments Endpoint     
    */
    public class GetDepartmentEndpoint
    {
        /// <summary>
        /// Get list of all departments under compliance module
        /// </summary>
        /// <param name="deptRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<ComplianceDepartment> deptRepo)
        {
            var query = await deptRepo.GetAllAsync();
            var response = query.Select(r => new GetComplianceDeparment(
                Id: r.Id,
                Name: r.Name
            ));
            return TypedResults.Ok(response);
        }
    }

    public record GetComplianceDeparment(Guid Id, string Name);
}
