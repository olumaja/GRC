using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Arm.GrcApi.Modules.BusinessEntities
{
    /*
     * Original Author: Olusegun Adaramaja
     * Date Created: 24/11/2023
     * Development Group: GRCTools
     * This endpoint fetch all processes link to the specified unit Id
     */
    public class BusinessEntitiesEndpointGetProcessByUnitId
    {
        /// <summary>
        /// Get process by unit Id
        /// </summary>
        /// <param name="unitId"></param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<RSCAProcess> repository, Guid unitId)
        {
            var processes = repository.GetContextByConditon(p => p.UnitId.Equals(unitId) && !p.IsDeleted).ToList();

            if (processes is null || processes.Count == 0)
                return TypedResults.NotFound();

            var result = processes.OrderBy(p => p.Name).Select(p => new ProcessDto(p.Name, p.Id)).ToList();

            return TypedResults.Ok(result);
        }
    }

    public record ProcessDto(string Name, Guid id);
}
