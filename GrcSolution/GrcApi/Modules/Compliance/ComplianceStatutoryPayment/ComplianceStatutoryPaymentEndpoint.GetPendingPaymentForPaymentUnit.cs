using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;
using Azure;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 23/08/2024
      * Development Group: GRCTools
      * Compliance Statutory Payment: View all initiated statutory Payment Endpoint for paymentunit.     
      */
    public class GetPendingPaymentForPaymentUnit
    {
        /// <summary>
        /// Get all initiated statutory Payment Endpoint for FINCON
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="currentUserService"></param>
        /// <param name="userRoleRepo"></param>
        /// <param name="userRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<ComplianceStatutoryPayment> repository, ICurrentUserService currentUserService
)
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
            {
                return TypedResults.Unauthorized();
            }
            var query = repository.GetAll()
                                  .OrderByDescending(r => r.CreatedOnUtc);

            var response = query.Select(q => new ComplianceStatutoryPaymentResponse
            {
                Id = q.Id,
                BusinessEntity = q.BusinessEntity,
                PayingUnit = q.PayingUnit,
                StatutoryPayment = q.StatutoryPayment,
                Purpose = q.Purpose,
                Status = q.Status.ToString(),
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
