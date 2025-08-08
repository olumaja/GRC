using Arm.GrcApi.Modules.OperationControl;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Linq;
using System.Security.Claims;
using Arm.GrcTool.Domain;
using Org.BouncyCastle.Ocsp;
//using DocumentFormat.OpenXml.Drawing;



namespace Arm.GrcApi.Modules.OperationControl
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 16/10/2024
     * Development Group: GRCTools
     * The endpoint update action owner feedback
     */
    public class UpdateActionOwnerFeedbackEndpoint
    {
        /// <summary>
        /// The endpoint update action owner feedback
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="repoControl"></param>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <param name="docRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
           UpdateActionownerReq payload, IRepository<OperationControl> repoControl, IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService, IRepository<Document> docRepo
        )
        {
            string requesterName = currentUserService.CurrentUserFullName;
            var fileTypeAllow = new List<string> { "pdf", "xlsx", "xls", "docx", "jpeg", "png", "jpg" };

            foreach (var attachment in payload.Attachments)
            {
                var fileExtension = Path.GetExtension(attachment.FileName).Trim('.').ToLower();

                if (!fileTypeAllow.Contains(fileExtension))
                    return TypedResults.BadRequest($"File types allowed are {string.Join(",", fileTypeAllow)}");
            }

            var exception = repoControl.GetContextByConditon(r => r.Id == payload.OperationExceptionId).FirstOrDefault();
            if (exception is null) return TypedResults.NotFound("Record was not found");

            if (exception.ActionOwnerEmail.ToLower() == currentUserService.CurrentUserEmail.ToLower())
            {
                exception.UpdateActionownerResponse(payload.Comment, payload.TransactionDate, payload.TransactionAmount, payload.DateResolved);
                exception.SetModifiedBy(requesterName);
                exception.SetModifiedOnUtc(DateTime.Now);
                repoControl.SaveChanges();

                //Remove previous attachments if exist, this endpoint also serve as update for make regulator payment
                docRepo.BulkDelete(x => x.ModuleItemId == exception.Id && x.ModuleItemType == ModuleType.ActionOwnerOperationControl);

                //Add attachments
                List<Document> attachedFiles = new();
                foreach (var attachment in payload.Attachments)
                {
                    attachedFiles.Add(DocumentExtensions.ConvertFormFileToDocument(attachment, ModuleType.ActionOwnerOperationControl, exception.Id));
                }
                await docRepo.AddRangeAsync(attachedFiles);
                await docRepo.SaveChangesAsync();

                //Send Email notification
                #region Send email notification                

                string? emailTo2 = exception.ActionOwnerEmail;
                if (exception.Unit == "Customer Onboarding & DataMgtTeam" || exception.Unit == "CustomerOnboarding&DataMgtTeam")
                {
                    emailTo2 = config["EmailConfiguration:CustomerOnboarding&DataMgtTeamGroupEmailToCC"];
                }
                if (exception.Unit == "Institutional Asset" || exception.Unit == "Institutional Asset Management")
                {
                    emailTo2 = config["EmailConfiguration:InstitutionalAssetGroupEmailToCC"];
                }
                if (exception.Unit == "LagosRM" || exception.Unit == "WRM (Lagos)")
                {
                    emailTo2 = config["EmailConfiguration:LagosRMGroupEmailToCC"];
                }
                if (exception.Unit == "Operations Settlement")
                {
                    emailTo2 = config["EmailConfiguration:OperationsSettlementGroupEmail"];
                }
                if (exception.Unit == "AbujaRM" || exception.Unit == "WRM (Abuja)")
                {
                    emailTo2 = config["EmailConfiguration:AbujaRMGroupEmailToCC"];
                }
                if (exception.Unit == "PHRM" || exception.Unit == "WRM (PortHarcourt)")
                {
                    emailTo2 = config["EmailConfiguration:PHRMGroupEmailToCC"];
                }
                if (exception.Unit == "Account Executives")
                {
                    emailTo2 = config["EmailConfiguration:AccountExecutivesGroupEmailToCC"];
                }
                if (exception.Unit == "Relationship Managers")
                {
                    emailTo2 = config["EmailConfiguration:RelationshipManagersGroupEmailToCC"];
                }
                if (exception.Unit == "Fund Account")
                {
                    emailTo2 = config["EmailConfiguration:FundAccountGroupEmail"];
                }
                if (exception.Unit == "Securities Operations" || exception.Unit == "ARM Securities")
                {
                    emailTo2 = config["EmailConfiguration:ARMSecuritiesGroupEmail"];
                }
                if (exception.Unit == "Customer Experience")
                {
                    emailTo2 = config["EmailConfiguration:CustomerServiceGroupEmailToCC"];
                }
                if (exception.Unit == "Financial Control")
                {
                    emailTo2 = config["EmailConfiguration:FinancialControlGroupEmailToCC"];
                }
                if (exception.Unit == "Fund Admin" || exception.Unit == "Administration")
                {
                    emailTo2 = config["EmailConfiguration:FundAdminGroupEmail"];
                }
                if (exception.Unit == "Retail Operations")
                {
                    emailTo2 = config["EmailConfiguration:RetailOperationsGroupEmail"];
                }
                if (exception.Unit == "IMUnit" || exception.Unit == "ARM IM" || exception.Unit == "Investment Management" || exception.Unit == "ARMIM")
                {
                    emailTo2 = config["EmailConfiguration:InvestmentManagementGroupEmail"];
                }
                if (exception.Unit == "ARM Registrars")
                {
                    emailTo2 = config["EmailConfiguration:RegistrarsGroupEmail"];
                }
                if (exception.Unit == "Treasury")
                {
                    emailTo2 = config["EmailConfiguration:TreasuryGroupEmailToCC"];
                }
                if (exception.Unit == "Private Trust")
                {
                    emailTo2 = config["EmailConfiguration:CallOverEmailToPrivateTrust"];
                }
                if (exception.Unit == "RFL" || exception.Unit == "AAFML")
                {
                    emailTo2 = config["EmailConfiguration:RFLGroupEmailToCC"];
                }
                if (exception.Unit == "Digital Financial Services" || exception.Unit == "DFS")
                {
                    emailTo2 = config["EmailConfiguration:DigitalFinancialServicesGroupEmailToCC"];
                }
                if (exception.Unit == "Information Technology" || exception.Unit == "IT")
                {
                    emailTo2 = config["EmailConfiguration:InformationTechnologyGroupEmailToCC"];
                }
                if (exception.Unit == "Internal Control")
                {
                    emailTo2 = config["EmailConfiguration:InternalControlEmailTo"];
                }
                if (exception.Unit == "Legal")
                {
                    emailTo2 = config["EmailConfiguration:LegalGroupEmail"];
                }
                if (exception.Unit == "Corporate Transformation")
                {
                    emailTo2 = config["EmailConfiguration:CorporateTransformationGroupEmail"];
                }

                string subject = $"Operation Control Exception Action Owner Response";
                string emailTo = config["EmailConfiguration:OperationControlGroupEmailToCC"] + exception.RequestedEmailAddress;
                string toCC = $"{exception.ActionOwnerEmail}," + emailTo2;
                var linkToGRCTool = string.Format(config["EmailConfiguration:LogExceptionLink"], exception.Id);
                string body = $"Dear {exception.CreatedBy}, <br><br> {currentUserService.CurrentUserFullName} has responded to your request. <br><br>Feedback =>  {payload.Comment}. <br><br>Please access the request with the following link <a href={linkToGRCTool}>GRC link</a><br><br> Thank you.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.OperationControl, exception.Id, emailTo, toCC);

                #endregion
                return TypedResults.Ok("Record updated successfully");
            }

           return TypedResults.NotFound("Record not found or the exception is not for you");
        }
    }

}
