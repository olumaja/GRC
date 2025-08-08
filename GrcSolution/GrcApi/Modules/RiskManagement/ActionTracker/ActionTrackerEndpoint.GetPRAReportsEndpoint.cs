using Arm.GrcApi.Modules.RiskManagement.ActionTracker;
using Arm.GrcApi.Modules.RiskManagement.PRA;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.ActionTracker
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 15/12/2023
 * Development Group: GRCTools
 * This endpoint fetches list of Product risk assessment by date range and unitId
 */
    public class GetPRAReportsEndpoint
    {
        /// <summary>
        /// This endpoint fetches list Product Risk Assessment by date range and business unit
        /// </summary>
        /// <param name="unitId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="getPRA"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            Guid unitId, DateTime startDate, DateTime endDate, IRepository<ProductRiskAssessment> getPRA, 
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
                    return TypedResults.BadRequest("Oops, EndDate cannot be earlier than StartDate");
                }

                var praList = new List<PRAListReports>();
                var praListRes = new List<PRAListReports>();

                if (unitId != default)
                {
                    var reportRiskIdentResult = getPRA.GetContextByConditon(x => x.CreatedOnUtc >= startDate && x.CreatedOnUtc <= endDate && x.UnitId == unitId);
                    var result = reportRiskIdentResult.OrderByDescending(x => x.CreatedOnUtc).ToList();
                    foreach (var res in result)
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

                if (unitId == default)
                {
                    //var pralists = getPRA.GetContextByConditon(x => x.Id != null);
                    var pralists = getPRA.GetContextByConditon(x => x.CreatedOnUtc >= startDate && x.CreatedOnUtc <= endDate);
                    var results = pralists.OrderByDescending(x => x.CreatedOnUtc).ToList();
                    foreach (var res in results)
                    {
                        praListRes.Add(new PRAListReports
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
                            UnitId = res.UnitId

                        });
                    }
                    GetPRAListReports respon = new GetPRAListReports()
                    {
                        ProductRiskAssessment = praListRes,

                    };
                    return TypedResults.Ok(respon);
                }
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem("Record not found", null, 500);
            }
        }

    }
}
