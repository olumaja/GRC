using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 05/08/2024
      * Development Group: GRCTools
      * Compliance Planning: Reject regulator payment Endpoint     
      */
    public class RejectRegulatorPaymentEndpoint
    {
        /// <summary>
        /// The endpoint reject the regulator payment made by the bussiness units
        /// </summary>
        /// <param name="rejectPayment"></param>
        /// <param name="paymemtRepo"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(RejectPaymentDto rejectPayment, IRepository<ComplianceRegulatoryPayment> paymemtRepo, ICurrentUserService currentUserService)
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                return TypedResults.Unauthorized();

            var query = await paymemtRepo.GetByIdAsync(rejectPayment.ComplianceRegulatoryPaymentId);

            if (query is null)
                return TypedResults.NotFound("Payment is yet to be initiated");

            query.RejectPaymentStatus(rejectPayment.Reason, currentUserService.CurrentUserFullName);
            paymemtRepo.SaveChanges();
            return TypedResults.Ok("Payment Rejected");
        }
    }
}
