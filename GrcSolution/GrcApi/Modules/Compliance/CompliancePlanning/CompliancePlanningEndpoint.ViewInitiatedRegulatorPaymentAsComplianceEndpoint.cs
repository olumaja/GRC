using Arm.GrcTool.Infrastructure;
using DocumentFormat.OpenXml.Bibliography;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 07/28/2024
      * Development Group: GRCTools
      * Compliance Planning: Get all regulator payment initiated     
      */
    public class ViewInitiatedRegulatorPaymentAsComplianceEndpoint
    {
        /// <summary>
        /// This endpoint is the view for the compliance officer to see all regulator payment initiated
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
                query = query.Where(q => q.BusinessEntity == businessName);

            var response = query.OrderByDescending(q => q.CreatedOnUtc)
                                .Select(r => new GetComplianceRegulatorPayment {
                RegulatorPaymentId = r.Id,
                Regulator = r.Regulator,
                BusinessEntity = r.BusinessEntity,
                DeadLine = r.DeadLine,
                MeansOfPayment = r.MeansOfPaymentAmount,
                Amount = r.Amount,
                DateOfPayment = r.DateOfPayment,
                ProcessOfficer = r.ProcessOfficer,
                Status = r.Status.ToString(),
                DateCreated = r.CreatedOnUtc,
                CreatedBy = r.Initiator,
                ModifiedBy = r.LastUpdatedBy,
                LastModifiedDate = r.ModifiedOnUtc,
                ApprovedBy = r.ApprovedBy,
                ApprovalDate = r.ApprovalDate
            }).ToList();

            return TypedResults.Ok(response);
        }
    }
}
