using Arm.GrcApi.Modules.RiskManagement.ActionTracker;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GrcApi.Modules.RiskManagement.ActionTracker
{
    public class ActionTrackerEndpointGetBIAReportDateRange
    {
        public static async Task<IResult> HandleAsync(
            DateOnly startDate, DateOnly endDate, IRepository<BusinessImpactAnalysis> biaRepo, IRepository<BusinessImpactAnalysisUnit> biaUnitRepo,
            ClaimsPrincipal user, ICurrentUserService currentUserService
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
                    return TypedResults.BadRequest("Enter valid date range");
                }

                var biaReport = biaRepo.GetContextByConditon(b => b.PeriodFrom >= startDate && b.PeriodTo <= endDate)
                                       .Include(b => b.BusinessImpactAnalysisUnits)
                                       .Select(b => new BIAReportDto
                                       {
                                           DateStarted = DateOnly.FromDateTime(b.CreatedOnUtc),
                                           BusinessUnitCount = b.BusinessImpactAnalysisUnits.Count(),
                                           PeriodFrom = b.PeriodFrom,
                                           PeriodTo = b.PeriodTo,
                                           StartDate = b.StartDate,
                                           EndDate = b.EndDate,
                                           Status = b.BusinessImpactAnalysisUnits.FirstOrDefault()!.Status,
                                           BuinessUnitName = b.BusinessImpactAnalysisUnits.FirstOrDefault()!.Unit.Name

                                       }).ToList();

                return TypedResults.Ok(biaReport);
            }
            catch (Exception ex)
            {

                return TypedResults.NotFound("Record not found");
            }
        }
    }
}
