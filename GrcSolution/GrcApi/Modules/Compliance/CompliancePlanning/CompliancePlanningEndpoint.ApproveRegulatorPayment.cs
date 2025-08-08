using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 05/08/2024
      * Development Group: GRCTools
      * Compliance Planning: Approve regulator payment Endpoint     
      */
    public class ApproveRegulatorPaymentEndpoint
    {
        /// <summary>
        /// The endpoint approve the regulator payment made by the bussiness units
        /// </summary>
        /// <param name="payment"></param>
        /// <param name="paymemtRepo"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(ApprovePaymentDto payment, IRepository<ComplianceRegulatoryPayment> paymemtRepo, ICurrentUserService currentUserService)
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                return TypedResults.Unauthorized();

            var query = await paymemtRepo.GetByIdAsync(payment.ComplianceRegulatoryPaymentId);

            if (query is null)
                return TypedResults.NotFound("Payment is yet to be initiated");

            bool isWithinDeadline = false;

            if(query.DeadLine >= DateTime.Now)
                isWithinDeadline = true;

            query.ApproveReportStatus(isWithinDeadline, currentUserService.CurrentUserFullName);
            paymemtRepo.SaveChanges();
            return TypedResults.Ok("Approved successfully");
        }
    }
}
