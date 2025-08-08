using Arm.GrcApi.Modules.IncidentManagement;
using Arm.GrcTool.Domain;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using Arm.GrcTool.Infrastructure.Data;
using DocumentFormat.OpenXml.Office.CustomUI;
using GrcApi.Modules.Shared.Helpers;
using System.Linq;
using System.ServiceModel.Channels;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    /*
       * Original Author: Sodiq Quadre
       * Date Created: 07/10/2025
       * Development Group: GRCTools
       * Notify ISO Champion endpoint
       */
    public class NotifyISOChampionEndpoint
    {
        /// <summary>
        /// Notify ISO Champion endpoint
        /// </summary>
        /// <param name="payload"></param>
        /// <param name="riskAss"></param>
        /// <param name="docRepo"></param>
        /// <param name="repoEmail"></param>
        /// <param name="config"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>       
        public static async Task<IResult> HandleAsync(NotifyISOChampionRequest payload, IRepository<NotifyISORiskAssessmentModel> riskAss, IRepository<Document> docRepo, 
                           IRepository<Email> repoEmail, IConfiguration config, ICurrentUserService currentUserService)
        {
            try
            { 
                if (payload.Units == null || payload.Units.Count == 0)
                    return TypedResults.BadRequest($"Units cannot be null or empty.");                
                var createdBy = currentUserService.CurrentUserFullName;
                var createdOn = DateTime.UtcNow;
                var riskAssessments = payload.Units.Select(unit =>
                {
                    var risk = NotifyISORiskAssessmentModel.Create(unit, payload.Objective, currentUserService.CurrentUserFullName, currentUserService.CurrentUserEmail);
                    risk.SetCreatedBy(createdBy);
                    risk.SetModifiedBy(createdBy);
                    risk.SetModifiedOnUtc(createdOn);
                    return risk;
                }).ToList();
                riskAss.AddRange(riskAssessments);
                await riskAss.SaveChangesAsync();

                //#region Email Notification Placeholder
                //List<Email> emails = new List<Email>();
                //foreach (var unit in payload.Units)
                //{
                //    string? emailTo2 = config["EmailConfiguration:InformationSecurityGroupEmail"];
                //    if (unit == "Customer Onboarding & DataMgtTeam" || unit == "CustomerOnboarding&DataMgtTeam")
                //    {
                //        emailTo2 = config["EmailConfiguration:CustomerOnboarding&DataMgtTeamGroupEmailToCC"];
                //    }
                //    if (unit == "Institutional Asset" || unit == "Institutional Asset Management")
                //    {
                //        emailTo2 = config["EmailConfiguration:InstitutionalAssetGroupEmailToCC"];
                //    }
                //    if (unit == "Internal Audit")
                //    {
                //        emailTo2 = config["EmailConfiguration:InternalAudit"];
                //    }
                //    if (unit == "Compliance")
                //    {
                //        emailTo2 = config["EmailConfiguration:ComplianceRegulatoryEmailToCC"];
                //    }
                //    if (unit == "Internal Control")
                //    {
                //        emailTo2 = config["EmailConfiguration:InternalControlEmailTo"];
                //    }
                //    if (unit == "LagosRM" || unit == "WRM (Lagos)")
                //    {
                //        emailTo2 = config["EmailConfiguration:LagosRMGroupEmailToCC"];
                //    }
                //    if (unit == "Operations Settlement")
                //    {
                //        emailTo2 = config["EmailConfiguration:OperationsSettlementGroupEmail"];
                //    }
                //    if (unit == "AbujaRM" || unit == "WRM (Abuja)")
                //    {
                //        emailTo2 = config["EmailConfiguration:AbujaRMGroupEmailToCC"];
                //    }
                //    if (unit == "PHRM" || unit == "WRM (PortHarcourt)")
                //    {
                //        emailTo2 = config["EmailConfiguration:PHRMGroupEmailToCC"];
                //    }
                //    if (unit == "Account Executives")
                //    {
                //        emailTo2 = config["EmailConfiguration:AccountExecutivesGroupEmailToCC"];
                //    }
                //    if (unit == "Relationship Managers")
                //    {
                //        emailTo2 = config["EmailConfiguration:RelationshipManagersGroupEmailToCC"];
                //    }
                //    if (unit == "Fund Account")
                //    {
                //        emailTo2 = config["EmailConfiguration:FundAccountGroupEmail"];
                //    }
                //    if (unit == "Securities Operations" || unit == "ARM Securities" || unit == "ARM Securities" || unit == "Information Security")
                //    {
                //        emailTo2 = config["EmailConfiguration:ARMSecuritiesGroupEmail"];
                //    }
                //    if (unit == "Customer Experience" || unit == "Call Centre" || unit == "Customer Service")
                //    {
                //        emailTo2 = config["EmailConfiguration:CustomerServiceGroupEmailToCC"];
                //    }
                //    if (unit == "Financial Control")
                //    {
                //        emailTo2 = config["EmailConfiguration:FinancialControlGroupEmailToCC"];
                //    }
                //    if (unit == "Fund Admin" || unit == "Administration")
                //    {
                //        emailTo2 = config["EmailConfiguration:FundAdminGroupEmail"];
                //    }
                //    if (unit == "Retail Operations" || unit == "Retail Sales")
                //    {
                //        emailTo2 = config["EmailConfiguration:RetailOperationsGroupEmail"];
                //    }
                //    if (unit == "IMUnit" || unit == "ARM IM" || unit == "Investment Management" || unit == "ARMIM")
                //    {
                //        emailTo2 = config["EmailConfiguration:InvestmentManagementGroupEmail"];
                //    }
                //    if (unit == "ARM Registrars" || unit == "Registrars")
                //    {
                //        emailTo2 = config["EmailConfiguration:RegistrarsGroupEmail"];
                //    }
                //    if (unit == "Treasury" || unit == "Treasury Sales" || unit == "Treasury Operations")
                //    {
                //        emailTo2 = config["EmailConfiguration:TreasuryGroupEmailToCC"];
                //    }
                //    if (unit == "Private Trust" || unit == "ARM Private Trust" || unit == "Commercial Trust")
                //    {
                //        emailTo2 = config["EmailConfiguration:CallOverEmailToPrivateTrust"];
                //    }
                //    if (unit == "RFL" || unit == "AAFML" || unit == "ARM Agric Fund")
                //    {
                //        emailTo2 = config["EmailConfiguration:RFLGroupEmailToCC"];
                //    }
                //    if (unit == "Digital Financial Services" || unit == "DFS")
                //    {
                //        emailTo2 = config["EmailConfiguration:DigitalFinancialServicesGroupEmailToCC"];
                //    }
                //    if (unit == "Information Technology" || unit == "IT")
                //    {
                //        emailTo2 = config["EmailConfiguration:InformationTechnologyGroupEmailToCC"];
                //    }
                //    if (unit == "Internal Control")
                //    {
                //        emailTo2 = config["EmailConfiguration:InternalControlEmailTo"];
                //    }
                //    if (unit == "Legal")
                //    {
                //        emailTo2 = config["EmailConfiguration:LegalGroupEmail"];
                //    }
                //    if (unit == "Corporate Transformation")
                //    {
                //        emailTo2 = config["EmailConfiguration:CorporateTransformationGroupEmail"];
                //    }
                //    if (unit == "Risk Management")
                //    {
                //        emailTo2 = config["EmailConfiguration:RiskChampionsUnitHeads"];
                //    }
                //    if (unit == "Corporate Strategy")
                //    {
                //        emailTo2 = config["EmailConfiguration:CorporateTransformationGroupEmail"];
                //    }
                    
                //    if (unit == "Relationship Manager")
                //    {
                //        emailTo2 = config["EmailConfiguration:RelationshipManagersUnitHeadEmailToCC"];
                //    }
                //    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                //    DateTime currentMonth = riskAssessments.Last().CreatedOnUtc;
                //    string currentMonthFormatted = currentMonth.ToString("MMMM yyyy");
                //    string subject = $"{unit} ISO Champions -  {currentMonthFormatted}";                                      
                //    string emailTo = emailTo2;
                //    string toCC = $"{currentUserService.CurrentUserEmail}," + config["EmailConfiguration:InformationSecurityGroupEmail"];
                //    string body = $"Dear Colleagues <br><br>You are receiving this email because your Team Lead/Business Manager has nominated you to represent {unit} in sustaining the Company’s ISO 27001 standard - Ethics and Values.<br><br>Who are the ISO Champions? <br><br>The ISO champion is a Subject Matter Expert within each unit/business who represents that unit/business for the implementation, sustainability and improvement of our ISO 27001 certification by providing required information, documents or feedback to and from their respective teams. The ISO Champions motivate their teams to understand and adhere to this standard and also promote the ISO 27001 benefits and advantages within their respective teams.<br><br> The ISO champions are typically characterised as:<br><br>->Knowledgeable of the unit’s/business’ procedures and processes.<br>->Motivated and able to inspire their team to be actively interested and engaged in the sustainance of ISO 27001 standard.<br>->Resourceful and capable of addressing challenges that may impact the Information Security Management System (ISMS) objectives as it applies to their team/business.<br><br>In the next few days/weeks, my team will be working with you to review and ensure your business assets are updated in line with the ISO 27001 requirements. They will also work with you to identify, assess and evaluate the cybersecurity risks associated with your unit and provide relevant mitigating controls (or review existing ones).<br><br>I look forward to a fruitful and rewarding exercise with you.<br><br>Regards, <br><br> Click here for more detail: <a href={linkToGRCTool}>GRC link</a>.";               

                //    Guid guid = Guid.NewGuid();
                //    Email email = new Email();
                //    emails.Add(email.Create(emailId: guid, to: emailTo, cc: toCC, subject: subject, message: body, moduleItemType: ModuleType.InfoSecISORiskChampionAssessment, moduleItemId: riskAssessments.Last().Id, createdAt: DateTime.Now, deliveryDate: null));
                //}

                //await repoEmail.AddRangeAsync(emails);
                //await repoEmail.SaveChangesAsync();

                //#endregion

                var response = new NotifyISOChampionResp(NotifyISOId: riskAssessments.Last().Id);
                return TypedResults.Created($"lm/{response.NotifyISOId}", response);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("An error occurred while processing your request.");
            }
        }

    }
}
