using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{

    /*
       * Original Author: Sodiq Quadre
       * Date Created: 2/08/2024
       * Development Group: GRCTools
       * Compliance Planning:  Get all pending approval compliance regulatory payment     
       */
    public class ViewPendingApprovalComplianceRegulatoryPaymentEndpoint
    {
        /// <summary>
        /// Get all pending approval compliance regulatory payment
        /// </summary>
        /// <param name="currentUserService"></param>
        /// <param name="calendarRepo"></param>
        /// <returns>List<OverdueComplianceRegulatoryPaymentRes></returns>
        public static async Task<IResult> HandleAsync(
            string? businessEntity, ICurrentUserService currentUserService, IRepository<ComplianceRegulatoryPayment> calendarRepo
        )
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                return TypedResults.Unauthorized();

            var response = new List<OverdueComplianceRegulatoryPaymentRes>();
            IQueryable<ComplianceRegulatoryPayment> reports;

            if (string.IsNullOrWhiteSpace(businessEntity))
                reports = calendarRepo.GetContextByConditon(x => x.Status != ComplianceStatus.Approved);
            else
            {
                reports = calendarRepo.GetContextByConditon(x => x.BusinessEntity == businessEntity && x.Status != ComplianceStatus.Approved);
            }
                        
            response = reports.Select(x => new OverdueComplianceRegulatoryPaymentRes
            {
                ComplianceRegulatoryPaymentId = x.Id,
                Amount = x.Amount,
                BusinessEntity = x.BusinessEntity,
                ContactPerson = x.ContactPerson,
                PaymentDetail = x.PaymentDetail,
                DeadLine = x.DeadLine,
                MeansOfPaymentAmount = x.MeansOfPaymentAmount,
                ProcessOfficer = x.ProcessOfficer,
                Regulator = x.Regulator,
                Status = x.Status.ToString()
            }).ToList();

            return TypedResults.Ok(response);
        }
    }
}
