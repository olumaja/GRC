using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;

namespace GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
       * Original Author: Sodiq Quadre
       * Date Created: 2/07/2024
       * Development Group: GRCTools
       * Compliance Planning:  Get all over due compliance regulatory payment     
       */
    public class ViewOverdueComplianceRegulatoryPaymentEndpoint
    {
        /// <summary>
        /// Get all over due compliance regulatory payment
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
                reports = calendarRepo.GetContextByConditon(x => x.Status != ComplianceStatus.Approved && x.DeadLine <= DateTime.Now);
            else
            {
                reports = calendarRepo.GetContextByConditon(x => x.BusinessEntity == businessEntity && x. Status != ComplianceStatus.Approved && x.DeadLine <= DateTime.Now).OrderByDescending(x => x.CreatedOnUtc);
            }

            response = reports.OrderByDescending(x => x.CreatedOnUtc).Select(x => new OverdueComplianceRegulatoryPaymentRes
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
                DateCreated = x.CreatedOnUtc,
                DateOfPayment = x.DateOfPayment,
                Status = x.Status.ToString(),
                CreatedBy = x.Initiator,
                ModifiedBy = x.LastUpdatedBy,
                ModifiedDate = x.ModifiedOnUtc,
                ApprovedBy = x.ApprovedBy,
                ApprovalDate = x.ApprovalDate
            }).ToList();

            return TypedResults.Ok(response);
        }
    }
}
