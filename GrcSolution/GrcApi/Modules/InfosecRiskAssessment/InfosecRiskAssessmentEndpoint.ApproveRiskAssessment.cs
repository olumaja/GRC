using Arm.GrcApi.Modules.InfosecRiskAssessment;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Data;

namespace GrcApi.Modules.InfosecRiskAssessment
{
    public class RiskAssessmentApprovalEndpoint
    {
        /// <summary>
        /// This endpoint enble unit head to approve or reject risk assessment
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="riskRepo"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            ApprovalDto payload, IRepository<InfosecRiskAssessmentModel> riskRepo, ICurrentUserService currentUserService
        )
        {
            var riskAssessment = await riskRepo.GetByIdAsync(payload.RiskId);

            if ( riskAssessment is null )
                return TypedResults.NotFound("No record found");

            if (riskAssessment.Unit != currentUserService.CurrentUserUnitName)
                return TypedResults.Forbid();

            var status = new Dictionary<string, RiskAssessmentStatus>
            {
                {"approved", RiskAssessmentStatus.Approved },
                {"rejected", RiskAssessmentStatus.Rejected }
            };
            var statusRequest = payload.Status.ToLower();

            if (!status.ContainsKey(statusRequest))
                return TypedResults.BadRequest("Status can only be Approved or Rejected");

            if (payload.Status.ToLower() == "rejected" && string.IsNullOrWhiteSpace(payload.ReasonForRejection))
                return TypedResults.BadRequest("Kindly provide reason for rejection");

            if (payload.Status.ToLower() == "approved")
                riskAssessment.UpdateStatus(status[statusRequest]);
            else
                riskAssessment.UpdateStatus(status[statusRequest], payload.ReasonForRejection);

            riskAssessment.SetApprovedBy(currentUserService.CurrentUserFullName);
            riskAssessment.SetModifiedBy(currentUserService.CurrentUserFullName);
            riskAssessment.SetModifiedOnUtc(DateTime.Now);
            riskRepo.SaveChanges();

            return TypedResults.Ok($"Assessment {payload.Status.ToUpper()} successfully");
        }
    }
}
