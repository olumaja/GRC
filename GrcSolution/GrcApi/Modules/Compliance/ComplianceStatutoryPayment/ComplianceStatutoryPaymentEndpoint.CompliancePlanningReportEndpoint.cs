using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 13/09/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* This endpoint View Compliance Planning Reports
*/
    public class CompliancePlanningReportEndpoint
    {
        /// <summary>
        /// View Compliance Planning Reports
        /// </summary>
        /// <param name="planning"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<ComplianceCalendar> planning, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var year = DateTime.Now.Year;
                var getPlanning = planning.GetContextByConditon(c => c.CreatedOnUtc.Year == year).OrderByDescending(x => x.CreatedOnUtc).ToList();
                var count = getPlanning.Count();
                List<CompliancePlanningReport> resp = new List<CompliancePlanningReport>();
                if (getPlanning == null)
                {
                    return TypedResults.NotFound();
                }
                if (getPlanning is not null)
                {
                    foreach (var item in getPlanning)
                    {
                        resp.Add(new CompliancePlanningReport
                        {
                            CompliancePlanningId = item.Id,
                            ReportName = item.Name,
                            Frequency = item.Frequency,
                            BusinessUnit = item.FirmToSubmit,
                            ReasonForRejection = item.ReasonForRejection,
                            AttachmentCount = item.AttachmentCount,
                            DeadLine = item.DeadLine,
                            ResponseStatus = item.ResponseStatus.ToString(),
                            ReportStatus = item.ReportStatus.ToString(),
                            ComplianceLevelStatus = item.LevelStatus.ToString(),
                            DateCreated = item.CreatedOnUtc,
                            ProcessOfficer = item.ProcessOfficer,
                            ApprovalName = item.ApprovedBy,
                            ApprovalDate = item.ApprovalDate,
                        });

                    };
                    var result = new ViewCompliancePlanningReportResp
                    {
                        Count = count,
                        CompliancePlanning = resp
                    };
                    return TypedResults.Ok(result);
                }
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                //logger.Error(ex, ex.Message);
                return TypedResults.Problem(ex.Message);
            }

        }
    }
}
