using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.BIA;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared.RestHelper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Arm.GrcTool.Domain.BusinessImpactAnalysis.BusinessImpactAnalysisUnit;

namespace Arm.GrcApi.Modules.RiskManagement.BIA
{
    public class ApproveInitiateBusinessImpactAnalysisEndpoint
    {
        public static async Task<IResult> HandleAsync([FromBody] ApproveInitiateBIADto approveInitiateBIA, IRepository<BusinessImpactAnalysisUnit> biaUnitRepo, 
            IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            var biaUnit = await biaUnitRepo.GetByIdAsync(approveInitiateBIA.BusinessImpactAnalysisUnitId);

            if(biaUnit == null )
            {
                return TypedResults.BadRequest($"Business impact assessment unit {approveInitiateBIA.BusinessImpactAnalysisUnitId} doesn't exist");
            }

            biaUnit.AddApproval(currentUserService.CurrentUserFullName);
            biaUnit.UpdateStatus(BIAStatus.Approved);
            biaUnit.UpdateStage(BIAStage.RiskManagementFinal);
            biaUnitRepo.SaveChanges();
            #region Log email request
            string subject = $"Review BIA";
            string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
            string emailTo = config["EmailConfiguration:RiskMgtUnit"];
            string toCC = config["EmailConfiguration:toCC"];
            string body = $"Hello all, <br> BIA has been successfully submitted and approved by the Risk Champion and Unit Head.<br>Kindly login to the GRC Tool for your review:<br> <a href={linkToGRCTool}>GRC link</a>.";
            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.RiskManagement, approveInitiateBIA.BusinessImpactAnalysisUnitId, emailTo, toCC);
            if (logEmailRequest == false)
            {
                return TypedResults.Ok($"Review BIA was successfully but email message was not logged");
            }
            #endregion

            return TypedResults.Ok();
        }
    }
}
