using Arm.GrcApi.Modules.RiskManagement.ActionTracker;
using Arm.GrcApi.Modules.RiskManagement.PRA;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.ActionTracker
{
    /*
  * Original Author: Sodiq Quadre
  * Date Created: 15/12/2023
  * Development Group: GRCTools
  * This endpoint fetches list of Product risk assessment by date range and unitId
  */
    public class GetPRAReportByDateEndpoint
    {
        /// <summary>
        /// This endpoint fetches list Product Risk Assessment by date range
        /// </summary>      
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="getPRA"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(DateTime startDate, DateTime endDate, IRepository<ProductRiskAssessment> getPRA,
            IRepository<Unit> unitRepo, ClaimsPrincipal user, ICurrentUserService currentUserService
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

                var units = await unitRepo.GetAllAsync();
                var praList = new List<PRAListReports>();
                var praListRes = new List<PRAListReports>();

                var praReport = getPRA.GetContextByConditon(x => x.CreatedOnUtc >= startDate && x.CreatedOnUtc <= endDate)
                                                    .Include(p => p.ProductAssessRisks)
                                                    .OrderByDescending(x => x.CreatedOnUtc).ToList();

                foreach (var res in praReport)
                {
                    praList.Add(new PRAListReports
                    {
                        Id = res.Id,
                        ProductName = res.ProductName,
                        ProductDescription = res.ProductDescription,
                        QuestionOrRecomendation = res.QuestionOrRecomendation,
                        ReseasonForRejection = res.ReseasonForRejection,
                        Status = res.Status,
                        Stage = res.Stage,
                        BusinessId = res.BusinessId,
                        DepartmentId = res.DepartmentId,
                        UnitId = res.UnitId,
                        Requester = res.Requester,
                        Approval = res.Approval,
                        ApprovalDate = res.ApprovalDate,
                    });
                }

                GetPRAListReports response = new GetPRAListReports()
                {
                    ProductRiskAssessment = praList,

                };
                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem("Record was not found", null, 500);
            }
        }

    }
}
