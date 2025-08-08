using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcApi.Modules.OperationControl;
using Arm.GrcTool.Domain;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Linq;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.OperationControl
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 22/01/2025
      * Development Group: GRCTools
      * The endpoint create new operation exception    
      */
    public class OperationControlEndpoint
    {
        /// <summary>
        /// The endpoint create new operation exception
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="repoControl"></param>
        /// <param name="currentUserService"></param>
        /// <param name="docRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            OperationControlDto payload, IRepository<OperationControl> repoControl, IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService, IRepository<Document> docRepo
        )
        {
            if(!currentUserService.CurrentUserRoles.Contains("OperationControlOfficer") && !currentUserService.CurrentUserRoles.Contains("OperationControlSupervisor"))
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
            var category = new Dictionary<string, ExceptionCategory> { { "minor", ExceptionCategory.Minor }, { "medium", ExceptionCategory.Medium }, {"major", ExceptionCategory.Major } };

            if(!category.ContainsKey(exceptionCategory))
                return TypedResults.BadRequest("Categories allowed are Minor, Medium and Major");

            var operation = OperationControl.Create(
                new CreateOperationControl(
                    OperationActivity: payload.OperationActivity,
                    TransactionCallOverType: payload.TransactionCallOverType,
                    ExceptionDescription: payload.ExceptionDescription,
                    ActionPoint: payload.ActionPoint,
                    ActionOwner: payload.ActionOwner,
                    ActionOwnerEmail: payload.ActionOwnerEmail,
                    Unit: payload.Unit,
                    ExceptionCategory: category[exceptionCategory],
                    CompletionDate: payload.CompletionDate,
                    RequestedEmailAddress: currentUserService.CurrentUserEmail
                )
            );

            operation.SetCreatedBy(currentUserService.CurrentUserFullName);
            operation.SetModifiedBy(currentUserService.CurrentUserFullName);
            operation.SetModifiedOnUtc(DateTime.Now);
            repoControl.Add(operation);

            //Add attachments
            List<Document> attachedFiles = new();
            foreach (var attachment in payload.Attachments)
            {
                attachedFiles.Add(DocumentExtensions.ConvertFormFileToDocument(attachment, ModuleType.OperationControl, operation.Id));
            }

            await docRepo.AddRangeAsync(attachedFiles);
            await docRepo.SaveChangesAsync();
            var response = new OperationControlResponse(Id: operation.Id);

            //Send Email notification
            #region Send email to the InternalAudit-HQ 
           
            string actionOwnerUnitEmail = string.Empty;
            var unitEmails = new Dictionary<string, string>
            {
                { "fund admin", config["EmailConfiguration:FundAdminGroupEmail"]},
                { "administration", config["EmailConfiguration:FundAdminGroupEmail"]},
                { "fund account", config["EmailConfiguration:FundAccountGroupEmail"]},
                { "retail operations", config["EmailConfiguration:RetailOperationsGroupEmail"]},
                { "operations settlement", config["EmailConfiguration:OperationsSettlementGroupEmail"]},
                { "arm securities", config["EmailConfiguration:ARMSecuritiesGroupEmail"]},
                { "securities operations", config["EmailConfiguration:ARMSecuritiesGroupEmail"]},
                { "registrars", config["EmailConfiguration:RegistrarsGroupEmail"]},
                { "arm registrars", config["EmailConfiguration:RegistrarsGroupEmail"]},
                { "investment management", config["EmailConfiguration:InvestmentManagementGroupEmail"]},
                { "imunit", config["EmailConfiguration:InvestmentManagementGroupEmail"]},
                { "armim", config["EmailConfiguration:InvestmentManagementGroupEmail"]},
                { "arm im", config["EmailConfiguration:InvestmentManagementGroupEmail"]},
                { "customerOnboarding&DataMgtTeam", config["EmailConfiguration:CustomerOnboarding&DataMgtTeamGroupEmailToCC"]},
                { "CustomerOnboarding&DataMgtTeam", config["EmailConfiguration:CustomerOnboarding&DataMgtTeamGroupEmailToCC"]},
                { "institutional", config["EmailConfiguration:InstitutionalAssetGroupEmailToCC"]},
                { "institutional asset", config["EmailConfiguration:InstitutionalAssetGroupEmailToCC"]},
                { "wealth & relationship management -lagos", config["EmailConfiguration:LagosRMGroupEmailToCC"]},
                { "wealth & relationship management -abuja", config["EmailConfiguration:AbujaRMGroupEmailToCC"]},
                { "wealth & relationship management -port harcourt", config["EmailConfiguration:PHRMGroupEmailToCC"]},
                { "account executives", config["EmailConfiguration:AccountExecutivesGroupEmailToCC"]},
                { "relationship managers", config["EmailConfiguration:RelationshipManagersGroupEmailToCC"]},
                { "business development", config["EmailConfiguration:BusinessDevelopmentGroupEmail"]},
                { "customer experience", config["EmailConfiguration:CustomerServiceGroupEmailToCC"]},
                { "financial control", config["EmailConfiguration:FinancialControlGroupEmailToCC"]},
                { "treasury", config["EmailConfiguration:TreasuryGroupEmailToCC"]},
                { "private trust", config["EmailConfiguration:CallOverEmailToPrivateTrust"]},
                { "rfl", config["EmailConfiguration:RFLGroupEmailToCC"]},
                { "aafml", config["EmailConfiguration:RFLGroupEmailToCC"]},
                { "digital financial services", config["EmailConfiguration:DigitalFinancialServicesGroupEmailToCC"]},
                { "dfs", config["EmailConfiguration:DigitalFinancialServicesGroupEmailToCC"]},
                { "information technology", config["EmailConfiguration:InformationTechnologyGroupEmailToCC"]},
                { "it", config["EmailConfiguration:InformationTechnologyGroupEmailToCC"]},
                { "internal control", config["EmailConfiguration:InternalControlEmailTo"]},
                { "corporate transformation", config["EmailConfiguration:CorporateTransformationGroupEmail"]},
                { "legal", config["EmailConfiguration:LegalGroupEmail"]}
                    
            };
                      
            var unit = payload.Unit.ToLower();
            if (unitEmails.ContainsKey(unit))
            {
                actionOwnerUnitEmail = unitEmails[unit];
            }

            string subject = $"{payload.OperationActivity} exception.";
            string emailTo = payload.ActionOwnerEmail; 
            string toCC = string.IsNullOrWhiteSpace(actionOwnerUnitEmail) ? config["EmailConfiguration:OperationControlGroupEmailToCC"] : $"{actionOwnerUnitEmail}," + config["EmailConfiguration:OperationControlGroupEmailToCC"];
            var linkToGRCTool = string.Format(config["EmailConfiguration:LogExceptionLink"], operation.Id);
            string body = $"Dear {payload.ActionOwner}, <br><br> {currentUserService.CurrentUserFullName} has submitted an exception. <br><br>Description => {payload.ExceptionDescription}. <br><br>Please access the request with the following link <a href={linkToGRCTool}>GRC link</a><br><br> Thank you.";
            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.OperationControl, operation.Id, emailTo, toCC);

            #endregion
            return TypedResults.Created($"ar/{response}", response);
        }
    }
}
