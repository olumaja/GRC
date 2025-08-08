using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 23/08/2024
      * Development Group: GRCTools
      * Compliance Statutory Payment: View all initiated statutory Payment Endpoint.     
      */
    public class ComplianceStatutoryPaymentEndpoint
    {
        /// <summary>
        /// View all initiated statutory payment
        /// </summary>
        /// <param name="businessEntity"></param>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(string? businessEntity, IRepository<ComplianceStatutoryPayment> repository, ICurrentUserService currentUserService
)
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
            {
                return TypedResults.Unauthorized();
            }
            var query = repository.GetAll();

            if (!string.IsNullOrWhiteSpace(businessEntity))
                query = query.Where(q => q.BusinessEntity == businessEntity)
                            .OrderByDescending(r => r.CreatedOnUtc);

            var response = query.Select(q => new ComplianceStatutoryPaymentResponse {
                Id = q.Id,
                BusinessEntity = q.BusinessEntity,
                PayingUnit = q.PayingUnit,
                StatutoryPayment = q.StatutoryPayment,
                Purpose = q.Purpose,
                Status = q.Status == StatutoryStatus.Processed ? StatutoryStatus.Not_Paid.ToString() : q.Status.ToString(),
                PeriodFrom = q.PeriodFrom,
                PeriodTo = q.PeriodTo,
                DateCreated = q.CreatedOnUtc,
                CreatedBy = q.Initiator,
                ProcessOfficer = q.ProcessOfficer,
                ProcessedDate = q.ProcessedDate,
                ModifiedBy = q.LastUpdatedBy,
                ModifiedDate = q.ModifiedOnUtc,
                ApprovedBy = q.ApprovedBy,
                ApprovalDate = q.ApprovalDate
            }).ToList();

            return TypedResults.Ok(response);
        }
    }
}
