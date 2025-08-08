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
* This endpoint View Compliance Statutory Payment Reports
*/
    public class ComplianceStatutoryPaymentReportEndpoint
    {
        /// <summary>
        /// View Compliance Statutory Payment Reports
        /// </summary>
        /// <param name="report"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<ComplianceStatutoryPayment> report,
            ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var getReport = report.GetAll().OrderByDescending(x => x.CreatedOnUtc).ToList();
                var count = getReport.Count();
                List<ComplianceStatutoryPaymentReport> resp = new List<ComplianceStatutoryPaymentReport>();
                if (getReport == null)
                {
                    return TypedResults.NotFound();
                }
                if (getReport is not null)
                {
                    foreach (var item in getReport)
                    {
                        resp.Add(new ComplianceStatutoryPaymentReport
                        {
                            ComplianceStatutoryPaymentId = item.Id,
                            BusinessEntity = item.BusinessEntity,
                            PayingUnit = item.PayingUnit,
                            Regulator = item.Regulator,
                            StatutoryPayment = item.StatutoryPayment,
                            ReasonForRejection = item.ReasonForRejection,
                            PaymentFrequency = item.PaymentFrequency,
                            PeriodFrom = item.PeriodFrom,
                            PeriodTo = item.PeriodTo,
                            Purpose = item.Purpose,
                            Comments = item.Comments,
                            CashRemittanceStatus = item.CashRemittanceStatus,
                            SubmissionToStatutoryBody = item.SubmissionToStatutoryBody,
                            DateOfPayment = item.DateOfPayment,
                            DateCreated = item.CreatedOnUtc,
                            ProcessOfficer = item.ProcessOfficer,
                            Status = item.Status.ToString(),
                            ComplianceLevel = item.ComplianceLevel.ToString()
                        });
                    }
                };

                var result = new ViewComplianceStatutoryPaymentReportReportResp
                {
                    Count = count,
                    ComplianceStatutoryPayment = resp
                };

                return TypedResults.Ok(result);
            }
            catch (Exception ex)
            {
                //logger.Error(ex, ex.Message);
                return TypedResults.Problem(ex.Message);
            }

        }
    }
}
