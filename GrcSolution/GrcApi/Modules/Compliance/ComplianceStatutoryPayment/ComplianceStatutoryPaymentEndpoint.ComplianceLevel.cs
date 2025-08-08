using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment
{
    public class ComplianceLevelEndpoint
    {
        public static async Task<IResult> HandleAsync(string? businessEntity, IRepository<ComplianceStatutoryPayment> repository, ICurrentUserService currentUserService)
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
            {
                return TypedResults.Unauthorized();
            }
            var query = repository.GetAll();

            if (!string.IsNullOrWhiteSpace(businessEntity))
                query = query.Where(q => q.BusinessEntity == businessEntity);

            var response = query.OrderByDescending(q => q.CreatedOnUtc).Select(q => new ComplianceLevelResponse
            {
                Id = q.Id,
                BusinessEntity = q.BusinessEntity,
                PayingUnit = q.PayingUnit,
                StatutoryPayment = q.StatutoryPayment,
                Purpose = q.Purpose,
                Status = q.Status.ToString(),
                ComplianceLevel = q.ComplianceLevel.ToString(),
                PeriodFrom = q.PeriodFrom,
                PeriodTo = q.PeriodTo,
                DateOfPayment = q.DateOfPayment,
                DateCreated = q.CreatedOnUtc,
                CreatedBy = q.Initiator,
                ProcessOfficer = q.ProcessOfficer,
                ProcessedDate = q.ProcessedDate,
                ApprovedBy = q.ApprovedBy,
                ApprovalDate = q.ApprovalDate,
                ModifiedBy = q.LastUpdatedBy,
                ModifiedDate = q.ModifiedOnUtc
            });

            return TypedResults.Ok(response);
        }
    }
}
