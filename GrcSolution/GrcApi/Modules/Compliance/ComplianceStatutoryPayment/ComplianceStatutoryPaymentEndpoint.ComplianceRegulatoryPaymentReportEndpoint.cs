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
* This endpoint View Compliance Regulatory Payment Reports
*/
    public class ComplianceRegulatoryPaymentReportEndpoint
    {
        /// <summary>
        /// View Compliance Regulatory Payment Reports
        /// </summary>
        /// <param name="planning"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<ComplianceRegulatoryPayment> report,
            ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var getReport = report.GetAll().OrderByDescending(x => x.CreatedOnUtc).ToList();
                
                List<ComplianceRegulatoryPaymentReport> resp = new List<ComplianceRegulatoryPaymentReport>();
                if (getReport == null)
                {
                    return TypedResults.NotFound();
                }

                var count = getReport.Count();
                
                foreach (var item in getReport)
                {
                    resp.Add(new ComplianceRegulatoryPaymentReport
                    {
                        ComplianceRegulatoryPaymentId = item.Id,
                        Regulator = item.Regulator,
                        BusinessEntity = item.BusinessEntity,
                        ReasonForRejection = item.ReasonForRejection,
                        MeansOfPaymentAmount = item.MeansOfPaymentAmount,
                        Amount = item.Amount,
                        AmountPaid = item.AmountPaid,
                        ProcessOfficer = item.ProcessOfficer,
                        ContactPerson = item.ContactPerson,
                        PaymentDetail = item.PaymentDetail,
                        TransactionReference = item.TransactionReference,
                        PaymentAttachmentCount = item.PaymentAttachmentCount,
                        DateOfPayment = item.DateOfPayment,
                        DeadLine = item.DeadLine,
                        DateCreated = item.CreatedOnUtc,
                        Status = item.Status.ToString(),
                        ComplianceLevel = item.ComplianceLevel.ToString()
                    });

                };
                var result = new ViewComplianceRegulatoryPaymentReportResp
                {
                    Count = count,
                    ComplianceRegulatoryPayment = resp
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
