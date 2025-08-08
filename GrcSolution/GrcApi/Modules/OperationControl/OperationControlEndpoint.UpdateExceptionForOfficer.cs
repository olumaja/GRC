using Arm.GrcApi.Modules.OperationControl;
using Arm.GrcTool.Domain;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using Azure;
using GrcApi.Modules.Shared.Helpers;
using System.Linq;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.OperationControl
{
    /*
     * Original Author: Olusegun Adaramaja
     * Date Created: 16/10/2024
     * Development Group: GRCTools
     * Update Exception and send notification
     */
    public class UpdateExceptionForOfficerEndpoint
    {
        /// <summary>
        /// The endpoint update new operation exception
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="repoControl"></param>
        /// <param name="currentUserService"></param>
        /// <param name="docRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            UpdateOperationControlDto payload, IRepository<OperationControl> repoControl, IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, 
            ICurrentUserService currentUserService, IRepository<Document> docRepo
        )
        {
            if (!currentUserService.CurrentUserRoles.Contains("OperationControlOfficer") && !currentUserService.CurrentUserRoles.Contains("OperationControlSupervisor"))
            {
                return TypedResults.Unauthorized();
            }
            var fileTypeAllow = new List<string> { "pdf", "xlsx", "xls", "docx", "jpeg", "png", "jpg" };

            foreach (var attachment in payload.Attachments)
            {
                var fileExtension = Path.GetExtension(attachment.FileName).Trim('.').ToLower();

                if (!fileTypeAllow.Contains(fileExtension))
                    return TypedResults.BadRequest($"File types allowed are {string.Join(",", fileTypeAllow)}");
            }
            var exceptionCategory = payload.ExceptionCategory.ToLower();
            var category = new Dictionary<string, ExceptionCategory> { { "minor", ExceptionCategory.Minor }, { "medium", ExceptionCategory.Medium }, { "major", ExceptionCategory.Major } };

            if (!category.ContainsKey(exceptionCategory))
                return TypedResults.BadRequest("Categories allowed are Minor, Medium and Major");

            var exception = await repoControl.GetByIdAsync(payload.OperationId);
            if (currentUserService.CurrentUserRoles.Contains("OperationControlOfficer") && exception.RequestedEmailAddress.ToLower() != currentUserService.CurrentUserEmail.ToLower())
            {
                return TypedResults.Unauthorized();
            }

            if (exception is null)
                return TypedResults.NotFound("Record not found");
                       
            exception.UpdateException(payload.OperationActivity, payload.TransactionCallOverType, payload.ExceptionDescription, payload.ActionPoint, payload.ActionOwner, payload.ActionOwnerEmail, payload.Unit, category[exceptionCategory], payload.CompletionDate);
            exception.SetModifiedBy(currentUserService.CurrentUserFullName);
            exception.SetModifiedOnUtc(DateTime.Now);
            repoControl.SaveChanges();

            //Remove previous attachments if exist, this endpoint also serve as update for make regulator payment
            docRepo.BulkDelete(x => x.ModuleItemId == exception.Id && x.ModuleItemType == ModuleType.OperationControl);

            //Add attachments
            List<Document> attachedFiles = new();
            foreach (var attachment in payload.Attachments)
            {
                attachedFiles.Add(DocumentExtensions.ConvertFormFileToDocument(attachment, ModuleType.OperationControl, exception.Id));
            }

            await docRepo.AddRangeAsync(attachedFiles);
            await docRepo.SaveChangesAsync();

            //Send Email notification
            #region Send email to the InternalAudit-HQ 

            string? emailTo2 = payload.ActionOwnerEmail;
            if (payload.Unit == "Customer Onboarding & DataMgtTeam" || payload.Unit == "CustomerOnboarding&DataMgtTeam")
            {
                emailTo2 = config["EmailConfiguration:CustomerOnboarding&DataMgtTeamGroupEmailToCC"];
            }
            if (payload.Unit == "Institutional Asset" || payload.Unit == "Institutional Asset Management")
            {
                emailTo2 = config["EmailConfiguration:InstitutionalAssetGroupEmailToCC"];
            }
            if (payload.Unit == "LagosRM" || payload.Unit == "WRM (Lagos)")
            {
                emailTo2 = config["EmailConfiguration:LagosRMGroupEmailToCC"];
            }
            if (payload.Unit == "Operations Settlement")
            {
                emailTo2 = config["EmailConfiguration:OperationsSettlementGroupEmail"];
            }
            if (payload.Unit == "AbujaRM" || payload.Unit == "WRM (Abuja)")
            {
                emailTo2 = config["EmailConfiguration:AbujaRMGroupEmailToCC"];
            }
            if (payload.Unit == "PHRM" || payload.Unit == "WRM (PortHarcourt)")
            {
                emailTo2 = config["EmailConfiguration:PHRMGroupEmailToCC"];
            }
            if (payload.Unit == "Account Executives")
            {
                emailTo2 = config["EmailConfiguration:AccountExecutivesGroupEmailToCC"];
            }
            if (payload.Unit == "Relationship Managers")
            {
                emailTo2 = config["EmailConfiguration:RelationshipManagersGroupEmailToCC"];
            }
            if (payload.Unit == "Fund Account")
            {
                emailTo2 = config["EmailConfiguration:FundAccountGroupEmail"];
            }
            if (payload.Unit == "Securities Operations" || payload.Unit == "ARM Securities")
            {
                emailTo2 = config["EmailConfiguration:ARMSecuritiesGroupEmail"];
            }
            if (payload.Unit == "Customer Experience")
            {
                emailTo2 = config["EmailConfiguration:CustomerServiceGroupEmailToCC"];
            }
            if (payload.Unit == "Financial Control")
            {
                emailTo2 = config["EmailConfiguration:FinancialControlGroupEmailToCC"];
            }
            if (payload.Unit == "Fund Admin" || payload.Unit == "Administration")
            {
                emailTo2 = config["EmailConfiguration:FundAdminGroupEmail"];
            }
            if (payload.Unit == "Retail Operations")
            {
                emailTo2 = config["EmailConfiguration:RetailOperationsGroupEmail"];
            }
            if (payload.Unit == "IMUnit" || payload.Unit == "ARM IM" || payload.Unit == "Investment Management" || payload.Unit == "ARMIM")
            {
                emailTo2 = config["EmailConfiguration:InvestmentManagementGroupEmail"];
            }
            if (payload.Unit == "ARM Registrars")
            {
                emailTo2 = config["EmailConfiguration:RegistrarsGroupEmail"];
            }
            if (payload.Unit == "Treasury")
            {
                emailTo2 = config["EmailConfiguration:TreasuryGroupEmailToCC"];
            }
            if (payload.Unit == "Private Trust")
            {
                emailTo2 = config["EmailConfiguration:CallOverEmailToPrivateTrust"];
            }
            if (payload.Unit == "RFL" || payload.Unit == "AAFML")
            {
                emailTo2 = config["EmailConfiguration:RFLGroupEmailToCC"];
            }
            if (payload.Unit == "Digital Financial Services" || payload.Unit == "DFS")
            {
                emailTo2 = config["EmailConfiguration:DigitalFinancialServicesGroupEmailToCC"];
            }
            if (payload.Unit == "Information Technology" || payload.Unit == "IT")
            {
                emailTo2 = config["EmailConfiguration:InformationTechnologyGroupEmailToCC"];
            }
            if (payload.Unit == "Internal Control")
            {
                emailTo2 = config["EmailConfiguration:InternalControlEmailTo"];
            }
            if (payload.Unit == "Legal")
            {
                emailTo2 = config["EmailConfiguration:LegalGroupEmail"];
            }
            if (payload.Unit == "Corporate Transformation")
            {
                emailTo2 = config["EmailConfiguration:CorporateTransformationGroupEmail"];
            }
            string subject = $"{payload.OperationActivity} exception.";
            string emailTo = payload.ActionOwnerEmail; 
            string toCC = $"{emailTo2}," + config["EmailConfiguration:OperationControlGroupEmailToCC"];
            var linkToGRCTool = string.Format(config["EmailConfiguration:LogExceptionLink"], exception.Id);
            string body = $"Dear {payload.ActionOwner}, <br><br> {currentUserService.CurrentUserFullName} has updated an exception. <br><br>Description => {payload.ExceptionDescription}. <br><br>Please access the request with the following link <a href={linkToGRCTool}>GRC link</a><br><br> Thank you.";
            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.OperationControl, exception.Id, emailTo, toCC);

            #endregion
            return TypedResults.Ok("Record updated successfully");
        }
    }
}
