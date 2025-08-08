using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 22/05/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* This endpoint View UnResolved Consolidated Audit Finding Summary 
*/
    public class UnResolvedConsolidatedAuditFindingSummaryEndpoint
    {
        /// <summary>
        /// View UnResolved Consolidated Audit Finding Summary 
        /// </summary>
        /// <param name="finding"></param>
        /// <param name="findingActionDetail"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<ConsolidatedAuditFinding> finding,
            IRepository<ConsolidatedAuditFindingActionDetail> findingActionDetail, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                string requesterUnit = user.Claims.FirstOrDefault(c => c.Type == "unit").Value;
                if (requesterUnit != "Internal Audit")
                { return TypedResults.Forbid(); }
                var getFinding = finding.GetContextByConditon(c => c.Status != BusinessRiskRatingStatus.Resolved).OrderBy(x => x.CreatedOnUtc).ToList();
                var count = getFinding.Count();
                List<FindingDetail> resp = new List<FindingDetail>();
                if (getFinding == null)
                {
                    return TypedResults.NotFound();
                }
                if (getFinding is not null)
                {
                    foreach (var item in getFinding)
                    {
                        resp.Add(new FindingDetail
                        {
                            ConsolidatedAuditFindingId = item.Id,
                            RequesterName = item.RequesterName,
                            ReviewType = item.ReviewType,
                            DetailFinding = item.DetailedFindings,
                            ResolutionDate = item.ResolutionDate,
                            RevisedDuedate = item.RevisedDueDate,
                            Business = item.Business,
                            ReportingQuarter = item.ReportingQuater,
                            Recommendation = item.Recommendation,
                            DescriptionOfFinding = item.DescriptionOfFinding,
                            Status = item.Status.ToString(),
                            StatusLevel = item.StatusLevel.ToString(),
                            OPRStatus = item.OPRStatus.ToString()
                        });
                    }
                    var result = new ViewResolvedFindingResp
                    {
                        Count = count,
                        FindingDetail = resp
                    };
                    return TypedResults.Ok(result);

                }
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }

        }
    }
}
