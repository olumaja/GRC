using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.BIA;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Arm.GrcTool.Domain.BusinessImpactAnalysis.BusinessImpactAnalysisUnit;

namespace Arm.GrcApi.Modules.RiskManagement.BIA
{
    public class RejectInitiateBusinessImpactAnalysisEndpoint
    {
        public static async Task<IResult> HandleAsync([FromBody] RejectInitiateBIADto rejectInitiatedBIA, IRepository<BusinessImpactAnalysisUnit> biaUnitRepo, 
            IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            var biaUnit = await biaUnitRepo.GetByIdAsync(rejectInitiatedBIA.BusinessImpactAnalysisUnitId);

            if (biaUnit == null)
            {
                return TypedResults.BadRequest($"Business impact assessmet unit {rejectInitiatedBIA.BusinessImpactAnalysisUnitId} doesn't exist");
            }

            biaUnit.AddApproval(currentUserService.CurrentUserFullName);
            biaUnit.UpdateStatus(BIAStatus.Rejected, rejectInitiatedBIA.Comment);
            biaUnit.UpdateStage(BIAStage.RiskChampionInitiateBIA);
            biaUnitRepo.SaveChanges();
            #region Log email request
            string subject = $"Review BIA";
            string emailTo = config["EmailConfiguration:RiskMgtUnit"];
            string toCC = config["EmailConfiguration:toCC"];
            string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
            string body = $"Hello all, <br> BIA has been successfully submitted and rejected by the Risk Champion and Unit Head.<br>Kindly login to the GRC Tool for your review:<br> <a href={linkToGRCTool}>GRC link</a>.";
            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.RiskManagement, rejectInitiatedBIA.BusinessImpactAnalysisUnitId, emailTo, toCC);
            if (logEmailRequest == false)
            {
                return TypedResults.Ok($"Review BIA was successfully but email message was not logged");
            }
            #endregion
            return TypedResults.Ok();
        }
    }
}
