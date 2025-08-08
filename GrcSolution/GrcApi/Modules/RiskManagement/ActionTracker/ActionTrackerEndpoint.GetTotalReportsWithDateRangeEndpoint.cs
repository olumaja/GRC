using Arm.GrcApi.Modules.RiskManagement.ActionTracker;
using Arm.GrcApi.Modules.RiskManagement.PRA;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Arm.GrcApi.Modules.RiskManagement.ActionTracker
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 11/12/2023
     * Development Group: GRCTools
     * This endpoint get total count of all the requests in each module with date range
    */
    public class GetTotalReportsWithDateRangeEndpoint
    {
        /// <summary>
        /// This endpoint get total count of all the requests in each module with date range
        /// </summary>
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="getPRA"></param>
        /// <param name="getBIA"></param>
        /// <param name="getRCSA"></param>
        /// <param name="getRE"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            DateTime startDate, DateTime endDate, ICurrentUserService currentUserService,
            IRepository<ProductRiskAssessment> getPRA, ClaimsPrincipal user, IRepository<BusinessImpactAnalysis> getBIA, 
            IRepository<RiskControlSelfAssessment> getRCSA, IRepository<RiskEvent> getRE
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                if (startDate == default || endDate == default)
                {
                    return TypedResults.BadRequest("Enter valid date format");
                }
                if (startDate > endDate)
                {
                    return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");
                }
                var fromDate = DateOnly.FromDateTime(startDate);
                var toDate = DateOnly.FromDateTime(endDate);
                var getAllRE = getRE.GetContextByConditon(x => x.DateOfIdentification >= fromDate && x.DateOfIdentification <= toDate).ToList();
                var getAllRCSA = getRCSA.GetContextByConditon(x => x.PeriodFrom >= fromDate && x.PeriodTo <= toDate).ToList();
                var getAllBIA = getBIA.GetContextByConditon(b => b.PeriodFrom >= fromDate && b.PeriodTo <= toDate).ToList();
                var getAllPRA = getPRA.GetContextByConditon(x => x.CreatedOnUtc >= startDate && x.CreatedOnUtc <= endDate).ToList();
                // var getAllPRA = getPRA.GetContextByConditon(x => x.CreatedOnUtc >= startDate && x.CreatedOnUtc <= endDate).ToList();

                var totalPRA = getAllPRA.Count();
                var totalBIA = getAllBIA.Count();
                var totalRCSA = getAllRCSA.Count();
                var totalRE = getAllRE.Count();

                GetTotalModuleRecords response = new GetTotalModuleRecords()
                {
                    BusinessImpactAnalysis = totalBIA,
                    ProductRiskAssessment = totalPRA,
                    RiskIdentification = totalRE,
                    RiskControlSelfAssessment = totalRCSA,
                };
                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {

                return TypedResults.NotFound("Record not found");
            }
        }

    }
}
