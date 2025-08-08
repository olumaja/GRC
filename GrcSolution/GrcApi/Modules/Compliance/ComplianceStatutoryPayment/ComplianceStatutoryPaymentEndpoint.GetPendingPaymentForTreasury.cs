using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared;

namespace Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 23/08/2024
      * Development Group: GRCTools
      * Compliance Statutory Payment: The endoint fetch all pending payment    
      */
    public class GetPendingPaymentForTreasury
    {
        /// <summary>
        /// The endoint fetch all pending payment
        /// </summary>
        /// <param name="repository"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(IRepository<ComplianceStatutoryPayment> repository, ICurrentUserService currentUserService)
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
