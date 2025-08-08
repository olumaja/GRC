using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 05/07/2024
      * Development Group: GRCTools
      * Compliance Planning: Get all regulator payment compliance level   
      */
    public class ViewRegulatorPaymentComplianceLevelEndpoint
    {
        /// <summary>
        /// The endpoint get all regulator payment compliance level
        /// </summary>
        /// <param name="businessName"></param>
        /// <param name="comPayment"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(string? businessName, IRepository<ComplianceRegulatoryPayment> comPayment, ICurrentUserService currentUserService)
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                return TypedResults.Unauthorized();

            var query = comPayment.GetAll();

            if (!string.IsNullOrWhiteSpace(businessName))
                query = query.Where(q => q.BusinessEntity == businessName).OrderByDescending(r => r.CreatedOnUtc);

            var response = query.OrderByDescending(r => r.CreatedOnUtc).Select(r => new GetComplianceRegulatorPayment
            {
                RegulatorPaymentId = r.Id,
                Regulator = r.Regulator,
                BusinessEntity = r.BusinessEntity,
                DeadLine = r.DeadLine,
                MeansOfPayment = r.MeansOfPaymentAmount,
                Amount = r.Amount,
                ProcessOfficer = r.ProcessOfficer,
                Status = r.Status.ToString(),
                ComplianceLevel = r.ComplianceLevel.ToString(),
                DateOfPayment = r.DateOfPayment,
                DateCreated = r.CreatedOnUtc,
                CreatedBy = r.Initiator,
                ApprovedBy = r.ApprovedBy,
                ApprovalDate = r.ApprovalDate,
                ModifiedBy = r.LastUpdatedBy,
                LastModifiedDate = r.ModifiedOnUtc
            }).ToList();

            return TypedResults.Ok(response);
        }
    }
}
