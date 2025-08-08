using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcApi.Modules.Shared.EmailNotification;
using Arm.GrcTool.Infrastructure.Data;
using Arm.GrcTool.Infrastructure;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using System.Linq.Expressions;
using ILogger = Serilog.ILogger;
using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcApi.Modules.OperationControl;
using Arm.GrcApi.Modules.IncidentManagement;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Globalization;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using System.ServiceModel.Channels;
using Arm.GrcTool.Domain;

namespace Arm.GrcTool.InfrastruCTOre
{
    public class EmailService : IEmailService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IRepository<Email> repoEmail;
        private readonly IRepository<InternalControlActionOwner> investigation;
        private readonly IRepository<InternalControlDashboard> icDashboard;
        private readonly IRepository<ComplianceCalendar> compliancerepoEmail;
        private readonly IRepository<ComplianceRegulatoryPayment> complianceRegPayment;
        private readonly IRepository<InternalControlCallOver> callOverEmail;
        private readonly IRepository<InternalControlCallOverReport> callOverReportsEmail;
        private readonly IRepository<InternalControlExceptionTracker> exceptionTracker;
        private readonly IRepository<OperationControl> repoControl;
        private readonly IRepository<LogManagement> logMgt;
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration config;
        private readonly ILogger logger;
        private Timer _timer;
        private readonly TimeSpan _11amrunTime;
        private readonly TimeSpan _11amrunTime2;
        private readonly TimeSpan _8amrunTime;
        private readonly TimeSpan _9amrunTime;
        private readonly TimeSpan _9amrunTimeAll;
        private readonly TimeSpan _9amrunTimeAll2;
        private readonly TimeSpan _12pmrunTime;
        private readonly TimeSpan _12pmrunTimeTransReport;
        private readonly TimeSpan _2pmrunTime;
        private readonly TimeSpan _1pmrunTime;
        private readonly TimeSpan _2pmrunTimeAll;
        private readonly TimeSpan _5pmrunTime;
        private readonly TimeSpan _4pmrunTime;
        private readonly TimeSpan _11pmrunTime;
        private readonly TimeSpan _7amrunTime;
        private readonly DayOfWeek _runDay;
        private readonly int _run4DayInMonth;
        private readonly int _run6DayInMonth;
        private readonly int _run1DayInMonth;
        private readonly int _run2DayInMonth;
        private readonly int _run20DayInMonth;
        private readonly int _run10DayInMonth;
        private readonly int _run15DayInMonth;
        private readonly int _run27DayInMonth;
        private readonly DateTime _target15Nov = new DateTime(DateTime.Now.Year, 11, 15, 9, 0, 0);
        private readonly DateTime _target1Nov = new DateTime(DateTime.Now.Year, 11, 1, 9, 0, 0);
        private readonly DateTime _target30Nov = new DateTime(DateTime.Now.Year, 11, 30, 9, 0, 0);
        private readonly DateTime _target10Dec = new DateTime(DateTime.Now.Year, 12, 10, 9, 0, 0);
        private readonly DateTime _target15Dec = new DateTime(DateTime.Now.Year, 12, 15, 9, 0, 0);
        private readonly DateTime _target20Dec = new DateTime(DateTime.Now.Year, 12, 20, 9, 0, 0);
        private readonly DateTime _target30Dec = new DateTime(DateTime.Now.Year, 12, 20, 12, 0, 0);
        private readonly DateTime _target1Feb = new DateTime(DateTime.Now.Year, 2, 1, 9, 0, 0);
        private readonly DateTime _target10Mar = new DateTime(DateTime.Now.Year, 3, 10, 9, 0, 0);
        private readonly DateTime _target25Mar = new DateTime(DateTime.Now.Year, 3, 25, 12, 0, 0);
        private readonly DateTime _target15Mar = new DateTime(DateTime.Now.Year, 3, 15, 12, 0, 0);

        private readonly DateTime _target11Dec = new DateTime(DateTime.Now.Year, 12, 11);
        private readonly DateTime _target5Dec = new DateTime(DateTime.Now.Year, 12, 5, 9, 0, 0);
        private readonly DateTime _target20Janu = new DateTime(DateTime.Now.Year, 1, 20, 9, 0, 0);
        private readonly DateTime _target28Janu = new DateTime(DateTime.Now.Year, 1, 28, 9, 0, 0);
        private readonly DateTime _target20March = new DateTime(DateTime.Now.Year, 3, 20, 9, 0, 0);
        private readonly DateTime _target28March = new DateTime(DateTime.Now.Year, 3, 28, 9, 0, 0);
        private readonly DateTime _target20April = new DateTime(DateTime.Now.Year, 4, 20, 9, 0, 0);
        private readonly DateTime _target28April = new DateTime(DateTime.Now.Year, 4, 28, 9, 0, 0);
        private readonly DateTime _target28June = new DateTime(DateTime.Now.Year, 6, 28, 9, 0, 0);
        private readonly DateTime _target20Feb = new DateTime(DateTime.Now.Year, 2, 20, 9, 0, 0);

        private readonly DateTime _target13July = new DateTime(DateTime.Now.Year, 7, 13, 9, 0, 0);
        private readonly DateTime _target13October = new DateTime(DateTime.Now.Year, 10, 13, 9, 0, 0);

        private readonly DateTime occurrenceDay = new DateTime(DateTime.Now.Year, 11, 30);


        public EmailService(IHttpClientFactory httpClientFactory, IRepository<Email> repoEmail, IRepository<ComplianceCalendar> compliancerepoEmail, IRepository<InternalControlActionOwner> investigation, IRepository<InternalControlExceptionTracker> exceptionTracker, IRepository<InternalControlDashboard> icDashboard, IRepository<OperationControl> repoControl, IRepository<LogManagement> logMgt, IRepository<InternalControlCallOver> callOverEmail, IRepository<InternalControlCallOverReport> callOverReportsEmail, IRepository<ComplianceRegulatoryPayment> complianceRegPayment, IUnitOfWork unitOfWork, IConfiguration config, ILogger logger)
        {
            _httpClientFactory = httpClientFactory;
            this.icDashboard = icDashboard;
            this.investigation = investigation;
            this.repoEmail = repoEmail;
            this.callOverEmail = callOverEmail; 
            this.callOverReportsEmail = callOverReportsEmail; 
            this.compliancerepoEmail = compliancerepoEmail; 
            this.complianceRegPayment = complianceRegPayment;
            this.exceptionTracker = exceptionTracker;
            this.repoControl = repoControl;
            this.unitOfWork = unitOfWork;
            this.config = config;
            this.logger = logger;
            this.logMgt = logMgt;
            _11amrunTime = new TimeSpan(11, 20, 0); //7am
            _11amrunTime2 = new TimeSpan(11, 20, 3); //7am
            _7amrunTime = new TimeSpan(7, 0, 0); //7am
            _11pmrunTime = new TimeSpan(22, 0, 0); //11pm
            _5pmrunTime = new TimeSpan(16, 0, 0); //4pm
            _4pmrunTime = new TimeSpan(16, 0, 0); //4pm
            _2pmrunTime = new TimeSpan(14, 0, 0); //2pm
            _1pmrunTime = new TimeSpan(12, 0, 0); //12pm
            _2pmrunTimeAll = new TimeSpan(14, 0, 0); //2pm
            _8amrunTime = new TimeSpan(8, 30, 0); //8:30am
            _9amrunTime = new TimeSpan(9, 0, 0); //9am
            _9amrunTimeAll = new TimeSpan(9, 0, 0); //9am
            _9amrunTimeAll2 = new TimeSpan(9, 0, 0); //9am
            _12pmrunTime = new TimeSpan(12, 0, 0); //12pm
            _12pmrunTimeTransReport = new TimeSpan(12, 0, 0); //12pm
            _runDay = DayOfWeek.Monday; //every monday
            _run4DayInMonth = 4; //4th day
            _run6DayInMonth = 6; //3rd day
            _run2DayInMonth = 2; //2nd day
            _run1DayInMonth = 1; //2th day
            _run20DayInMonth = 20; //10th day
            _run10DayInMonth = 10; //10th day
            _run15DayInMonth = 15; //15th day
            _run27DayInMonth = 27; //27th day
        } 

        #region Operation Control Reminder Email Notification
        public async Task TwoDaysReminderAfterLoggedExceptionSendEmailAsync()
        {
            try
            {
                var emailObj = repoControl.GetContextByConditon(e => e.CompletionDate.Date.AddDays(-2) == DateTime.Now.Date && e.Status != ExceptionStatus.Submitted && e.Status != ExceptionStatus.Approved && e.IsReminderSent1 == false).FirstOrDefault();
                if (emailObj != null)
                {                    
                    string? emailTo2 = emailObj.ActionOwnerEmail;
                    string? lineMgr = emailObj.ActionOwnerEmail;
                    if (emailObj.Unit == "Customer Onboarding & DataMgtTeam" || emailObj.Unit == "CustomerOnboarding&DataMgtTeam")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerOnboarding&DataMgtTeamGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:DataMgtTeamLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Institutional Asset" || emailObj.Unit == "Institutional Asset Management")
                    {
                        emailTo2 = config["EmailConfiguration:InstitutionalAssetGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:InstitutionalAssetLineMgrEmail"];
                    }
                    if (emailObj.Unit == "LagosRM" || emailObj.Unit == "WRM (Lagos)")
                    {
                        emailTo2 = config["EmailConfiguration:LagosRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Operations Settlement")
                    {
                        emailTo2 = config["EmailConfiguration:OperationsSettlementGroupEmail"];
                        lineMgr = config["EmailConfiguration:OperationsSettlementLineMgrEmail"];
                    }
                    if (emailObj.Unit == "AbujaRM" || emailObj.Unit == "WRM (Abuja)")
                    {
                        emailTo2 = config["EmailConfiguration:AbujaRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "PHRM" || emailObj.Unit == "WRM (PortHarcourt)")
                    {
                        emailTo2 = config["EmailConfiguration:PHRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Account Executives")
                    {
                        emailTo2 = config["EmailConfiguration:AccountExecutivesGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Relationship Managers")
                    {
                        emailTo2 = config["EmailConfiguration:RelationshipManagersGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:RelationshipManagersUnitHeadEmailToCC"];
                    }
                    if (emailObj.Unit == "Fund Account")
                    {
                        emailTo2 = config["EmailConfiguration:FundAccountGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAccountLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Securities Operations" || emailObj.Unit == "ARM Securities")
                    {
                        emailTo2 = config["EmailConfiguration:ARMSecuritiesGroupEmail"];
                        lineMgr = config["EmailConfiguration:ARMSecuritiesLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Customer Experience" || emailObj.Unit == "Call Centre" || emailObj.Unit == "Customer Service")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerServiceGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Financial Control")
                    {
                        emailTo2 = config["EmailConfiguration:FinancialControlGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Fund Admin" || emailObj.Unit == "Administration")
                    {
                        emailTo2 = config["EmailConfiguration:FundAdminGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAdminLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Retail Operations")
                    {
                        emailTo2 = config["EmailConfiguration:RetailOperationsGroupEmail"];
                        lineMgr = config["EmailConfiguration:RetailOperationsLineMgrEmail"];
                    }
                    if (emailObj.Unit == "IMUnit" || emailObj.Unit == "ARM IM" || emailObj.Unit == "Investment Management" || emailObj.Unit == "ARMIM")
                    {
                        emailTo2 = config["EmailConfiguration:InvestmentManagementGroupEmail"];
                        lineMgr = config["EmailConfiguration:InvestmentManagementLineMgrEmail"];
                    }
                    if (emailObj.Unit == "ARM Registrars")
                    {
                        emailTo2 = config["EmailConfiguration:RegistrarsGroupEmail"];
                        lineMgr = config["EmailConfiguration:RegistrarsLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Treasury")
                    {
                        emailTo2 = config["EmailConfiguration:TreasuryGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:TreasuryUnitHeadEmailToCC"]; 
                    }
                    if (emailObj.Unit == "Private Trust" || emailObj.Unit == "ARM Private Trust")
                    {
                        emailTo2 = config["EmailConfiguration:CallOverEmailToPrivateTrust"];
                    }
                    if (emailObj.Unit == "RFL" || emailObj.Unit == "AAFML")
                    {
                        emailTo2 = config["EmailConfiguration:RFLGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Digital Financial Services" || emailObj.Unit == "DFS")
                    {
                        emailTo2 = config["EmailConfiguration:DigitalFinancialServicesGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:DigitalFinancialServicesUnitHeadEmailToCC"];
                    }
                    if (emailObj.Unit == "Information Technology" || emailObj.Unit == "IT")
                    {
                        emailTo2 = config["EmailConfiguration:InformationTechnologyGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Internal Control")
                    {
                        emailTo2 = config["EmailConfiguration:InternalControlEmailTo"];
                        lineMgr = config["EmailConfiguration:InternalControlUnitHeadEmailTo"];
                    }
                    if (emailObj.Unit == "Legal")
                    {
                        emailTo2 = config["EmailConfiguration:LegalGroupEmail"];
                    }
                    if (emailObj.Unit == "Corporate Transformation")
                    {
                        emailTo2 = config["EmailConfiguration:CorporateTransformationGroupEmail"];
                    }
                    
                    var emailSender = new MimeMessage();
                    string filePath = config["EmailConfiguration:filePath"];
                    string subject = $"{emailObj.OperationActivity} exception.";
                    string emailTo = $"{lineMgr}," + emailObj.ActionOwnerEmail;
                    string emailToCC = $"{emailTo2}," + config["EmailConfiguration:OperationControlGroupEmailToCC"];
                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string message = $"Dear {emailObj.ActionOwner},<br><br>This email serves as a reminder regarding the outstanding response requiring your attention.<br><br>Description => {emailObj.ExceptionDescription}.<br><br>Please submit your response promptly through the GRC tool via the link below.<br><br><a href={linkToGRCTool}>GRC Link</a>";
                    
                    var result = await SendEmailNotificationAsyncV1(subject: subject, emailTo: emailTo, toCC: emailToCC, body: message, filePath: filePath, config: config);
                    emailObj.UpdateIsReminderSent1(result);
                    await repoControl.SaveChangesAsync();
                }
                
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        public async Task OneDaysReminderAfterLoggedExceptionSendEmailAsync()
        {
            try
            {
                var emailObj = repoControl.GetContextByConditon(e => e.CompletionDate.Date.AddDays(-1) == DateTime.Now.Date && e.Status != ExceptionStatus.Submitted && e.Status != ExceptionStatus.Approved && e.IsReminderSent2 == false).FirstOrDefault();
                if (emailObj != null)
                {
                    string? emailTo2 = emailObj.ActionOwnerEmail;
                    string? lineMgr = emailObj.ActionOwnerEmail;
                    if (emailObj.Unit == "Customer Onboarding & DataMgtTeam" || emailObj.Unit == "CustomerOnboarding&DataMgtTeam")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerOnboarding&DataMgtTeamGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:DataMgtTeamLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Institutional Asset" || emailObj.Unit == "Institutional Asset Management")
                    {
                        emailTo2 = config["EmailConfiguration:InstitutionalAssetGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:InstitutionalAssetLineMgrEmail"];
                    }
                    if (emailObj.Unit == "LagosRM" || emailObj.Unit == "WRM (Lagos)")
                    {
                        emailTo2 = config["EmailConfiguration:LagosRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Operations Settlement")
                    {
                        emailTo2 = config["EmailConfiguration:OperationsSettlementGroupEmail"];
                        lineMgr = config["EmailConfiguration:OperationsSettlementLineMgrEmail"];
                    }
                    if (emailObj.Unit == "AbujaRM" || emailObj.Unit == "WRM (Abuja)")
                    {
                        emailTo2 = config["EmailConfiguration:AbujaRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "PHRM" || emailObj.Unit == "WRM (PortHarcourt)")
                    {
                        emailTo2 = config["EmailConfiguration:PHRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Account Executives")
                    {
                        emailTo2 = config["EmailConfiguration:AccountExecutivesGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Relationship Managers")
                    {
                        emailTo2 = config["EmailConfiguration:RelationshipManagersGroupEmailToCC"];                        
                        lineMgr = config["EmailConfiguration:RelationshipManagersUnitHeadEmailToCC"];
                    }
                    if (emailObj.Unit == "Fund Account")
                    {
                        emailTo2 = config["EmailConfiguration:FundAccountGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAccountLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Securities Operations" || emailObj.Unit == "ARM Securities")
                    {
                        emailTo2 = config["EmailConfiguration:ARMSecuritiesGroupEmail"];
                        lineMgr = config["EmailConfiguration:ARMSecuritiesLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Customer Experience" || emailObj.Unit == "Call Centre" || emailObj.Unit == "Customer Service")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerServiceGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Financial Control")
                    {
                        emailTo2 = config["EmailConfiguration:FinancialControlGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Fund Admin" || emailObj.Unit == "Administration")
                    {
                        emailTo2 = config["EmailConfiguration:FundAdminGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAdminLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Retail Operations")
                    {
                        emailTo2 = config["EmailConfiguration:RetailOperationsGroupEmail"];
                        lineMgr = config["EmailConfiguration:RetailOperationsLineMgrEmail"];
                    }
                    if (emailObj.Unit == "IMUnit" || emailObj.Unit == "ARM IM" || emailObj.Unit == "Investment Management" || emailObj.Unit == "ARMIM")
                    {
                        emailTo2 = config["EmailConfiguration:InvestmentManagementGroupEmail"];
                        lineMgr = config["EmailConfiguration:InvestmentManagementLineMgrEmail"];
                    }
                    if (emailObj.Unit == "ARM Registrars")
                    {
                        emailTo2 = config["EmailConfiguration:RegistrarsGroupEmail"];
                        lineMgr = config["EmailConfiguration:RegistrarsLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Treasury")
                    {
                        emailTo2 = config["EmailConfiguration:TreasuryGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:TreasuryUnitHeadEmailToCC"];
                     }
                    if (emailObj.Unit == "Private Trust" || emailObj.Unit == "ARM Private Trust")
                    {
                        emailTo2 = config["EmailConfiguration:CallOverEmailToPrivateTrust"];
                    }
                    if (emailObj.Unit == "RFL" || emailObj.Unit == "AAFML")
                    {
                        emailTo2 = config["EmailConfiguration:RFLGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Digital Financial Services" || emailObj.Unit == "DFS")
                    {
                        emailTo2 = config["EmailConfiguration:DigitalFinancialServicesGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:DigitalFinancialServicesUnitHeadEmailToCC"];
                    }
                    if (emailObj.Unit == "Information Technology" || emailObj.Unit == "IT")
                    {
                        emailTo2 = config["EmailConfiguration:InformationTechnologyGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Internal Control")
                    {
                        emailTo2 = config["EmailConfiguration:InternalControlEmailTo"];
                        lineMgr = config["EmailConfiguration:InternalControlUnitHeadEmailTo"];
                    }
                    if (emailObj.Unit == "Legal")
                    {
                        emailTo2 = config["EmailConfiguration:LegalGroupEmail"];
                    }
                    if (emailObj.Unit == "Corporate Transformation")
                    {
                        emailTo2 = config["EmailConfiguration:CorporateTransformationGroupEmail"];
                    }
                    var emailSender = new MimeMessage();
                    string filePath = config["EmailConfiguration:filePath"];
                    string subject = $"{emailObj.OperationActivity} exception.";
                    string emailTo = lineMgr;
                    string name = GetNameFromEmail(emailTo);
                    string emailToCC = $"{emailTo2},{config["EmailConfiguration:OperationControlGroupEmailToCC"]},{emailObj.ActionOwnerEmail}";
                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string message = $"Dear {name},<br><br>This email serves as a reminder regarding the outstanding response requiring the attention of {emailObj.ActionOwner}.<br><br>Description => {emailObj.ExceptionDescription}.<br><br>You can access the GRC Tool here:<br><br><a href={linkToGRCTool}>GRC Link</a>";
                   
                    var result = await SendEmailNotificationAsyncV1(subject: subject, emailTo: emailTo, toCC: emailToCC, body: message, filePath: filePath, config: config);
                    emailObj.UpdateIsReminderSent2(result);
                    await repoControl.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        public async Task DueExceptionReminderAfterLoggedExceptionSendEmailAsync()
        {
            try
            {
                var emailObj = repoControl.GetContextByConditon(e => e.CompletionDate.Date == DateTime.Now.Date && e.Status != ExceptionStatus.Submitted && e.Status != ExceptionStatus.Approved && e.IsReminderSent3 == false).FirstOrDefault();
                if (emailObj != null)
                {                    
                    string? emailTo2 = emailObj.ActionOwnerEmail;
                    string? lineMgr = emailObj.ActionOwnerEmail;
                    if (emailObj.Unit == "Customer Onboarding & DataMgtTeam" || emailObj.Unit == "CustomerOnboarding&DataMgtTeam")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerOnboarding&DataMgtTeamGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:DataMgtTeamLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Institutional Asset" || emailObj.Unit == "Institutional Asset Management")
                    {
                        emailTo2 = config["EmailConfiguration:InstitutionalAssetGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:InstitutionalAssetLineMgrEmail"];
                    }
                    if (emailObj.Unit == "LagosRM" || emailObj.Unit == "WRM (Lagos)")
                    {
                        emailTo2 = config["EmailConfiguration:LagosRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Operations Settlement")
                    {
                        emailTo2 = config["EmailConfiguration:OperationsSettlementGroupEmail"];
                        lineMgr = config["EmailConfiguration:OperationsSettlementLineMgrEmail"];
                    }
                    if (emailObj.Unit == "AbujaRM" || emailObj.Unit == "WRM (Abuja)")
                    {
                        emailTo2 = config["EmailConfiguration:AbujaRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "PHRM" || emailObj.Unit == "WRM (PortHarcourt)")
                    {
                        emailTo2 = config["EmailConfiguration:PHRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Account Executives")
                    {
                        emailTo2 = config["EmailConfiguration:AccountExecutivesGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Relationship Managers")
                    {
                        emailTo2 = config["EmailConfiguration:RelationshipManagersGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Fund Account")
                    {
                        emailTo2 = config["EmailConfiguration:FundAccountGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAccountLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Securities Operations" || emailObj.Unit == "ARM Securities")
                    {
                        emailTo2 = config["EmailConfiguration:ARMSecuritiesGroupEmail"];
                        lineMgr = config["EmailConfiguration:ARMSecuritiesLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Customer Experience" || emailObj.Unit == "Call Centre" || emailObj.Unit == "Customer Service")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerServiceGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Financial Control")
                    {
                        emailTo2 = config["EmailConfiguration:FinancialControlGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Fund Admin" || emailObj.Unit == "Administration")
                    {
                        emailTo2 = config["EmailConfiguration:FundAdminGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAdminLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Retail Operations")
                    {
                        emailTo2 = config["EmailConfiguration:RetailOperationsGroupEmail"];
                        lineMgr = config["EmailConfiguration:RetailOperationsLineMgrEmail"];
                    }
                    if (emailObj.Unit == "IMUnit" || emailObj.Unit == "ARM IM" || emailObj.Unit == "Investment Management" || emailObj.Unit == "ARMIM")
                    {
                        emailTo2 = config["EmailConfiguration:InvestmentManagementGroupEmail"];
                        lineMgr = config["EmailConfiguration:InvestmentManagementLineMgrEmail"];
                    }
                    if (emailObj.Unit == "ARM Registrars")
                    {
                        emailTo2 = config["EmailConfiguration:RegistrarsGroupEmail"];
                        lineMgr = config["EmailConfiguration:RegistrarsLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Treasury")
                    {
                        emailTo2 = config["EmailConfiguration:TreasuryGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:TreasuryUnitHeadEmailToCC"];                       
                    }
                    if (emailObj.Unit == "Private Trust" || emailObj.Unit == "ARM Private Trust")
                    {
                        emailTo2 = config["EmailConfiguration:CallOverEmailToPrivateTrust"];
                    }
                    if (emailObj.Unit == "RFL" || emailObj.Unit == "AAFML")
                    {
                        emailTo2 = config["EmailConfiguration:RFLGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Digital Financial Services" || emailObj.Unit == "DFS")
                    {
                        emailTo2 = config["EmailConfiguration:DigitalFinancialServicesGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:DigitalFinancialServicesUnitHeadEmailToCC"];
                    }
                    if (emailObj.Unit == "Information Technology" || emailObj.Unit == "IT")
                    {
                        emailTo2 = config["EmailConfiguration:InformationTechnologyGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Internal Control")
                    {
                        emailTo2 = config["EmailConfiguration:InternalControlEmailTo"];
                        lineMgr = config["EmailConfiguration:InternalControlUnitHeadEmailTo"];
                    }
                    if (emailObj.Unit == "Legal")
                    {
                        emailTo2 = config["EmailConfiguration:LegalGroupEmail"];
                    }
                    if (emailObj.Unit == "Corporate Transformation")
                    {
                        emailTo2 = config["EmailConfiguration:CorporateTransformationGroupEmail"];
                    }
                    var emailSender = new MimeMessage();
                    string filePath = config["EmailConfiguration:filePath"];
                    string subject = $"{emailObj.OperationActivity} exception.";
                    string emailTo = lineMgr; 
                    string name = GetNameFromEmail(emailTo);
                    string emailToCC = $"{emailTo2},{config["EmailConfiguration:OperationControlGroupEmailToCC"]},{config["EmailConfiguration:GroupHeadOfOperationEmail"]},{config["EmailConfiguration:ChiefRiskOfficerEmail"]},{emailObj.ActionOwnerEmail}";
                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string message = $"Dear {name},<br><br>This email serves as a reminder regarding the outstanding response requiring the attention of {emailObj.ActionOwner}.<br><br>Description => {emailObj.ExceptionDescription}.<br><br>You can access the GRC Tool here:<br><br><a href={linkToGRCTool}>GRC Link</a>";
                    
                    var result = await SendEmailNotificationAsyncV1(subject: subject, emailTo: emailTo, toCC: emailToCC, body: message, filePath: filePath, config: config);
                    emailObj.UpdateIsReminderSent3(result);
                    await repoControl.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        #endregion
      
        #region Send email notification - Infosec

        public async Task OneWeekToProposedEndDateSendEmailAsync()
        {
            try
            {
                var emailObj = logMgt.GetContextByConditon(e => e.ProposeEndDate.Value.Date.AddDays(-7) == DateTime.Now.Date && e.Status != LogMgtStatus.Closed && e.IsReminderSent1WkToProposedEndDate == false).FirstOrDefault();
                if (emailObj != null)
                {
                    string? emailTo2 = emailObj.ActionownerEmailAddress;
                    if (emailObj.ActionOwnerUnit == "Customer Onboarding & DataMgtTeam" || emailObj.ActionOwnerUnit == "CustomerOnboarding&DataMgtTeam")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerOnboarding&DataMgtTeamGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Institutional Asset" || emailObj.ActionOwnerUnit == "Institutional Asset Management")
                    {
                        emailTo2 = config["EmailConfiguration:InstitutionalAssetGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "LagosRM" || emailObj.ActionOwnerUnit == "WRM (Lagos)")
                    {
                        emailTo2 = config["EmailConfiguration:LagosRMGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Operations Settlement")
                    {
                        emailTo2 = config["EmailConfiguration:OperationsSettlementGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "AbujaRM" || emailObj.ActionOwnerUnit == "WRM (Abuja)")
                    {
                        emailTo2 = config["EmailConfiguration:AbujaRMGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "PHRM" || emailObj.ActionOwnerUnit == "WRM (PortHarcourt)")
                    {
                        emailTo2 = config["EmailConfiguration:PHRMGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Account Executives")
                    {
                        emailTo2 = config["EmailConfiguration:AccountExecutivesGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Relationship Managers")
                    {
                        emailTo2 = config["EmailConfiguration:RelationshipManagersGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Fund Account")
                    {
                        emailTo2 = config["EmailConfiguration:FundAccountGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "Securities Operations" || emailObj.ActionOwnerUnit == "ARM Securities")
                    {
                        emailTo2 = config["EmailConfiguration:ARMSecuritiesGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "Customer Experience" || emailObj.ActionOwnerUnit == "Call Centre" || emailObj.ActionOwnerUnit == "Customer Service")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerServiceGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Financial Control")
                    {
                        emailTo2 = config["EmailConfiguration:FinancialControlGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Fund Admin" || emailObj.ActionOwnerUnit == "Administration")
                    {
                        emailTo2 = config["EmailConfiguration:FundAdminGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "Retail Operations")
                    {
                        emailTo2 = config["EmailConfiguration:RetailOperationsGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "IMUnit" || emailObj.ActionOwnerUnit == "ARM IM" || emailObj.ActionOwnerUnit == "Investment Management" || emailObj.ActionOwnerUnit == "ARMIM")
                    {
                        emailTo2 = config["EmailConfiguration:InvestmentManagementGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "ARM Registrars")
                    {
                        emailTo2 = config["EmailConfiguration:RegistrarsGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "Treasury")
                    {
                        emailTo2 = config["EmailConfiguration:TreasuryGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Private Trust")
                    {
                        emailTo2 = config["EmailConfiguration:CallOverEmailToPrivateTrust"];
                    }
                    if (emailObj.ActionOwnerUnit == "RFL" || emailObj.ActionOwnerUnit == "AAFML")
                    {
                        emailTo2 = config["EmailConfiguration:RFLGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Digital Financial Services" || emailObj.ActionOwnerUnit == "DFS")
                    {
                        emailTo2 = config["EmailConfiguration:DigitalFinancialServicesGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Information Technology" || emailObj.ActionOwnerUnit == "IT")
                    {
                        emailTo2 = config["EmailConfiguration:InformationTechnologyGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Internal Control")
                    {
                        emailTo2 = config["EmailConfiguration:InternalControlEmailTo"];
                    }
                    if (emailObj.ActionOwnerUnit == "Legal")
                    {
                        emailTo2 = config["EmailConfiguration:LegalGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "Corporate Transformation")
                    {
                        emailTo2 = config["EmailConfiguration:CorporateTransformationGroupEmail"];
                    }

                    var emailSender = new MimeMessage();
                    string filePath = config["EmailConfiguration:filePath"];
                    string subject = $"{emailObj.LogType.ToString()} New Log Assigned - Action Required"; 
                    string emailTo = $"{emailObj.ActionownerEmailAddress}";
                    string emailToCC = $"{emailTo2},{config["EmailConfiguration:InformationSecurityGroupEmail"]},{emailObj.RequesterEmailAddress}";
                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string message = $"Dear {emailObj.ActionownerName},<br><br>This is a reminder that there is a pending action assigned to you that requires your attention.<br><br>Event Name => {emailObj.EventName}<br><br> Description => {emailObj.InfoSecRemarks}<br><br>Due Date => {emailObj.ProposeEndDate}.<br><br>To ensure timely closure and avoid delays, kindly complete the required action on or before the due date. You can access the task and update its status through the following link:<br><br><a href={linkToGRCTool}>GRC Link</a><br><br>If you’ve already taken steps or completed the task, please update the status in the system accordingly.<br><br>Feel free to reach out if you have any questions or need further clarification.<br><br>Thank you for your prompt attention.<br><br>Best regards.";
                    
                    var result = await SendEmailNotificationAsyncV1(subject: subject, emailTo: emailTo, toCC: emailToCC, body: message, filePath: filePath, config: config);
                    emailObj.UpdateIsReminderSent1WkToProposedEndDate(result);
                    await repoControl.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        public async Task ThreeDaysToProposedEndDateSendEmailAsync()
        {
            try
            {
                var emailObj = logMgt.GetContextByConditon(e => e.ProposeEndDate.Value.Date.AddDays(-3) == DateTime.Now.Date && e.Status != LogMgtStatus.Closed && e.IsReminderSent3DaysToProposedEndDate == false).FirstOrDefault();
                if (emailObj != null)
                {
                    string? emailTo2 = emailObj.ActionownerEmailAddress;
                    if (emailObj.ActionOwnerUnit == "Customer Onboarding & DataMgtTeam" || emailObj.ActionOwnerUnit == "CustomerOnboarding&DataMgtTeam")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerOnboarding&DataMgtTeamGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Institutional Asset" || emailObj.ActionOwnerUnit == "Institutional Asset Management")
                    {
                        emailTo2 = config["EmailConfiguration:InstitutionalAssetGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "LagosRM" || emailObj.ActionOwnerUnit == "WRM (Lagos)")
                    {
                        emailTo2 = config["EmailConfiguration:LagosRMGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Operations Settlement")
                    {
                        emailTo2 = config["EmailConfiguration:OperationsSettlementGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "AbujaRM" || emailObj.ActionOwnerUnit == "WRM (Abuja)")
                    {
                        emailTo2 = config["EmailConfiguration:AbujaRMGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "PHRM" || emailObj.ActionOwnerUnit == "WRM (PortHarcourt)")
                    {
                        emailTo2 = config["EmailConfiguration:PHRMGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Account Executives")
                    {
                        emailTo2 = config["EmailConfiguration:AccountExecutivesGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Relationship Managers")
                    {
                        emailTo2 = config["EmailConfiguration:RelationshipManagersGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Fund Account")
                    {
                        emailTo2 = config["EmailConfiguration:FundAccountGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "Securities Operations" || emailObj.ActionOwnerUnit == "ARM Securities")
                    {
                        emailTo2 = config["EmailConfiguration:ARMSecuritiesGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "Customer Experience" || emailObj.ActionOwnerUnit == "Call Centre" || emailObj.ActionOwnerUnit == "Customer Service")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerServiceGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Financial Control")
                    {
                        emailTo2 = config["EmailConfiguration:FinancialControlGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Fund Admin" || emailObj.ActionOwnerUnit == "Administration")
                    {
                        emailTo2 = config["EmailConfiguration:FundAdminGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "Retail Operations")
                    {
                        emailTo2 = config["EmailConfiguration:RetailOperationsGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "IMUnit" || emailObj.ActionOwnerUnit == "ARM IM" || emailObj.ActionOwnerUnit == "Investment Management" || emailObj.ActionOwnerUnit == "ARMIM")
                    {
                        emailTo2 = config["EmailConfiguration:InvestmentManagementGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "ARM Registrars")
                    {
                        emailTo2 = config["EmailConfiguration:RegistrarsGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "Treasury")
                    {
                        emailTo2 = config["EmailConfiguration:TreasuryGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Private Trust")
                    {
                        emailTo2 = config["EmailConfiguration:CallOverEmailToPrivateTrust"];
                    }
                    if (emailObj.ActionOwnerUnit == "RFL" || emailObj.ActionOwnerUnit == "AAFML")
                    {
                        emailTo2 = config["EmailConfiguration:RFLGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Digital Financial Services" || emailObj.ActionOwnerUnit == "DFS")
                    {
                        emailTo2 = config["EmailConfiguration:DigitalFinancialServicesGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Information Technology" || emailObj.ActionOwnerUnit == "IT")
                    {
                        emailTo2 = config["EmailConfiguration:InformationTechnologyGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Internal Control")
                    {
                        emailTo2 = config["EmailConfiguration:InternalControlEmailTo"];
                    }
                    if (emailObj.ActionOwnerUnit == "Legal")
                    {
                        emailTo2 = config["EmailConfiguration:LegalGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "Corporate Transformation")
                    {
                        emailTo2 = config["EmailConfiguration:CorporateTransformationGroupEmail"];
                    }
                    var emailSender = new MimeMessage();
                    string filePath = config["EmailConfiguration:filePath"];
                    string subject = $"{emailObj.LogType.ToString()} New Log Assigned - Action Required";
                    string emailTo = $"{emailObj.ActionownerEmailAddress}";
                    string emailToCC = $"{emailTo2},{config["EmailConfiguration:InformationSecurityGroupEmail"]},{emailObj.RequesterEmailAddress}";
                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string message = $"Dear {emailObj.ActionownerName},<br><br>This is a reminder that there is a pending action assigned to you that requires your attention.<br><br>Event Name => {emailObj.EventName}<br><br> Description => {emailObj.InfoSecRemarks}<br><br>Due Date => {emailObj.ProposeEndDate}.<br><br>To ensure timely closure and avoid delays, kindly complete the required action on or before the due date. You can access the task and update its status through the following link:<br><br><a href={linkToGRCTool}>GRC Link</a><br><br>If you’ve already taken steps or completed the task, please update the status in the system accordingly.<br><br>Feel free to reach out if you have any questions or need further clarification.<br><br>Thank you for your prompt attention.<br><br>Best regards.";
                   
                    var result = await SendEmailNotificationAsyncV1(subject: subject, emailTo: emailTo, toCC: emailToCC, body: message, filePath: filePath, config: config);
                    emailObj.UpdateIsReminderSent3DaysToProposedEndDate(result);
                    await repoControl.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        public async Task ADayToProposedEndDateSendEmailAsync()
        {
            try
            {
                var emailObj = logMgt.GetContextByConditon(e => e.ProposeEndDate.Value.Date.AddDays(-1) == DateTime.Now.Date && e.Status != LogMgtStatus.Closed && e.IsReminderSent1DayToProposedEndDate == false).FirstOrDefault();
                if (emailObj != null)
                {
                    string? emailTo2 = emailObj.ActionownerEmailAddress;
                    if (emailObj.ActionOwnerUnit == "Customer Onboarding & DataMgtTeam" || emailObj.ActionOwnerUnit == "CustomerOnboarding&DataMgtTeam")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerOnboarding&DataMgtTeamGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Institutional Asset" || emailObj.ActionOwnerUnit == "Institutional Asset Management")
                    {
                        emailTo2 = config["EmailConfiguration:InstitutionalAssetGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "LagosRM" || emailObj.ActionOwnerUnit == "WRM (Lagos)")
                    {
                        emailTo2 = config["EmailConfiguration:LagosRMGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Operations Settlement")
                    {
                        emailTo2 = config["EmailConfiguration:OperationsSettlementGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "AbujaRM" || emailObj.ActionOwnerUnit == "WRM (Abuja)")
                    {
                        emailTo2 = config["EmailConfiguration:AbujaRMGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "PHRM" || emailObj.ActionOwnerUnit == "WRM (PortHarcourt)")
                    {
                        emailTo2 = config["EmailConfiguration:PHRMGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Account Executives")
                    {
                        emailTo2 = config["EmailConfiguration:AccountExecutivesGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Relationship Managers")
                    {
                        emailTo2 = config["EmailConfiguration:RelationshipManagersGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Fund Account")
                    {
                        emailTo2 = config["EmailConfiguration:FundAccountGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "Securities Operations" || emailObj.ActionOwnerUnit == "ARM Securities")
                    {
                        emailTo2 = config["EmailConfiguration:ARMSecuritiesGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "Customer Experience" || emailObj.ActionOwnerUnit == "Call Centre" || emailObj.ActionOwnerUnit == "Customer Service")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerServiceGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Financial Control")
                    {
                        emailTo2 = config["EmailConfiguration:FinancialControlGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Fund Admin" || emailObj.ActionOwnerUnit == "Administration")
                    {
                        emailTo2 = config["EmailConfiguration:FundAdminGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "Retail Operations")
                    {
                        emailTo2 = config["EmailConfiguration:RetailOperationsGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "IMUnit" || emailObj.ActionOwnerUnit == "ARM IM" || emailObj.ActionOwnerUnit == "Investment Management" || emailObj.ActionOwnerUnit == "ARMIM")
                    {
                        emailTo2 = config["EmailConfiguration:InvestmentManagementGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "ARM Registrars")
                    {
                        emailTo2 = config["EmailConfiguration:RegistrarsGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "Treasury")
                    {
                        emailTo2 = config["EmailConfiguration:TreasuryGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Private Trust")
                    {
                        emailTo2 = config["EmailConfiguration:CallOverEmailToPrivateTrust"];
                    }
                    if (emailObj.ActionOwnerUnit == "RFL" || emailObj.ActionOwnerUnit == "AAFML")
                    {
                        emailTo2 = config["EmailConfiguration:RFLGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Digital Financial Services" || emailObj.ActionOwnerUnit == "DFS")
                    {
                        emailTo2 = config["EmailConfiguration:DigitalFinancialServicesGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Information Technology" || emailObj.ActionOwnerUnit == "IT")
                    {
                        emailTo2 = config["EmailConfiguration:InformationTechnologyGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Internal Control")
                    {
                        emailTo2 = config["EmailConfiguration:InternalControlEmailTo"];
                    }
                    if (emailObj.ActionOwnerUnit == "Legal")
                    {
                        emailTo2 = config["EmailConfiguration:LegalGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "Corporate Transformation")
                    {
                        emailTo2 = config["EmailConfiguration:CorporateTransformationGroupEmail"];
                    }
                    var emailSender = new MimeMessage();
                    string filePath = config["EmailConfiguration:filePath"];
                    string subject = $"{emailObj.LogType.ToString()} New Log Assigned - Action Required";
                    string emailTo = $"{emailObj.ActionownerEmailAddress}";
                    string emailToCC = $"{emailTo2},{config["EmailConfiguration:InformationSecurityGroupEmail"]},{emailObj.RequesterEmailAddress}";
                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string message = $"Dear {emailObj.ActionownerName},<br><br>This is a reminder that there is a pending action assigned to you that requires your attention.<br><br>Event Name => {emailObj.EventName}<br><br> Description => {emailObj.InfoSecRemarks}<br><br>Due Date => {emailObj.ProposeEndDate}.<br><br>To ensure timely closure and avoid delays, kindly complete the required action on or before the due date. You can access the task and update its status through the following link:<br><br><a href={linkToGRCTool}>GRC Link</a><br><br>If you’ve already taken steps or completed the task, please update the status in the system accordingly.<br><br>Feel free to reach out if you have any questions or need further clarification.<br><br>Thank you for your prompt attention.<br><br>Best regards.";
                   
                    var result = await SendEmailNotificationAsyncV1(subject: subject, emailTo: emailTo, toCC: emailToCC, body: message, filePath: filePath, config: config);
                    emailObj.UpdateIsReminderSent1DayToProposedEndDate(result);
                    await repoControl.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        public async Task OnTheProposedEndDateSendEmailAsync()
        {
            try
            {
                var emailObj = logMgt.GetContextByConditon(e => e.ProposeEndDate.Value.Date == DateTime.Now.Date && e.Status != LogMgtStatus.Closed && e.IsReminderSentOnTheProposedEndDate == false).FirstOrDefault();
                if (emailObj != null)
                {
                    string? emailTo2 = emailObj.ActionownerEmailAddress;
                    if (emailObj.ActionOwnerUnit == "Customer Onboarding & DataMgtTeam" || emailObj.ActionOwnerUnit == "CustomerOnboarding&DataMgtTeam")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerOnboarding&DataMgtTeamGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Institutional Asset" || emailObj.ActionOwnerUnit == "Institutional Asset Management")
                    {
                        emailTo2 = config["EmailConfiguration:InstitutionalAssetGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "LagosRM" || emailObj.ActionOwnerUnit == "WRM (Lagos)")
                    {
                        emailTo2 = config["EmailConfiguration:LagosRMGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Operations Settlement")
                    {
                        emailTo2 = config["EmailConfiguration:OperationsSettlementGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "AbujaRM" || emailObj.ActionOwnerUnit == "WRM (Abuja)")
                    {
                        emailTo2 = config["EmailConfiguration:AbujaRMGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "PHRM" || emailObj.ActionOwnerUnit == "WRM (PortHarcourt)")
                    {
                        emailTo2 = config["EmailConfiguration:PHRMGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Account Executives")
                    {
                        emailTo2 = config["EmailConfiguration:AccountExecutivesGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Relationship Managers")
                    {
                        emailTo2 = config["EmailConfiguration:RelationshipManagersGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Fund Account")
                    {
                        emailTo2 = config["EmailConfiguration:FundAccountGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "Securities Operations" || emailObj.ActionOwnerUnit == "ARM Securities")
                    {
                        emailTo2 = config["EmailConfiguration:ARMSecuritiesGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "Customer Experience" || emailObj.ActionOwnerUnit == "Call Centre" || emailObj.ActionOwnerUnit == "Customer Service")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerServiceGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Financial Control")
                    {
                        emailTo2 = config["EmailConfiguration:FinancialControlGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Fund Admin" || emailObj.ActionOwnerUnit == "Administration")
                    {
                        emailTo2 = config["EmailConfiguration:FundAdminGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "Retail Operations")
                    {
                        emailTo2 = config["EmailConfiguration:RetailOperationsGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "IMUnit" || emailObj.ActionOwnerUnit == "ARM IM" || emailObj.ActionOwnerUnit == "Investment Management" || emailObj.ActionOwnerUnit == "ARMIM")
                    {
                        emailTo2 = config["EmailConfiguration:InvestmentManagementGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "ARM Registrars")
                    {
                        emailTo2 = config["EmailConfiguration:RegistrarsGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "Treasury")
                    {
                        emailTo2 = config["EmailConfiguration:TreasuryGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Private Trust")
                    {
                        emailTo2 = config["EmailConfiguration:CallOverEmailToPrivateTrust"];
                    }
                    if (emailObj.ActionOwnerUnit == "RFL" || emailObj.ActionOwnerUnit == "AAFML")
                    {
                        emailTo2 = config["EmailConfiguration:RFLGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Digital Financial Services" || emailObj.ActionOwnerUnit == "DFS")
                    {
                        emailTo2 = config["EmailConfiguration:DigitalFinancialServicesGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Information Technology" || emailObj.ActionOwnerUnit == "IT")
                    {
                        emailTo2 = config["EmailConfiguration:InformationTechnologyGroupEmailToCC"];
                    }
                    if (emailObj.ActionOwnerUnit == "Internal Control")
                    {
                        emailTo2 = config["EmailConfiguration:InternalControlEmailTo"];
                    }
                    if (emailObj.ActionOwnerUnit == "Legal")
                    {
                        emailTo2 = config["EmailConfiguration:LegalGroupEmail"];
                    }
                    if (emailObj.ActionOwnerUnit == "Corporate Transformation")
                    {
                        emailTo2 = config["EmailConfiguration:CorporateTransformationGroupEmail"];
                    }
                    var emailSender = new MimeMessage();
                    string filePath = config["EmailConfiguration:filePath"];
                    string subject = $"{emailObj.LogType.ToString()} New Log Assigned - Action Required";
                    string emailTo = $"{emailObj.ActionownerEmailAddress}";
                    string emailToCC = $"{emailTo2},{config["EmailConfiguration:InformationSecurityGroupEmail"]},{emailObj.RequesterEmailAddress}";
                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string message = $"Dear {emailObj.ActionownerName},<br><br>This is a reminder that there is a pending action assigned to you that requires your attention.<br><br>Event Name => {emailObj.EventName}<br><br> Description => {emailObj.InfoSecRemarks}<br><br>Due Date => {emailObj.ProposeEndDate}.<br><br>To ensure timely closure and avoid delays, kindly complete the required action on or before the due date. You can access the task and update its status through the following link:<br><br><a href={linkToGRCTool}>GRC Link</a><br><br>If you’ve already taken steps or completed the task, please update the status in the system accordingly.<br><br>Feel free to reach out if you have any questions or need further clarification.<br><br>Thank you for your prompt attention.<br><br>Best regards.";
                    
                    var result = await SendEmailNotificationAsyncV1(subject: subject, emailTo: emailTo, toCC: emailToCC, body: message, filePath: filePath, config: config);
                    emailObj.UpdateIsReminderSentOnTheProposedEndDate(result);
                    await repoControl.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        #endregion

        #region Internal Control Exception Email reminder
        public async Task Exception48HoursReminderSendEmailAsync()
        {
            try
            {
                var emailObj = exceptionTracker.GetContextByConditon(e => e.Deadline.Value.Date.AddDays(-4) == DateTime.Now.Date && e.ExceptionTrackerStatus != ExceptionTrackerStatus.Resolved && e.IsReminderSent48Hrs == false).FirstOrDefault();
                if (emailObj != null)
                {
                    string? emailTo2 = emailObj.ResponsibleOfficerEmail;
                    string? lineMgr = emailObj.ResponsibleOfficerEmail;
                    if (emailObj.Unit == "Customer Onboarding & DataMgtTeam" || emailObj.Unit == "CustomerOnboarding&DataMgtTeam")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerOnboarding&DataMgtTeamGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:DataMgtTeamLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Institutional Asset" || emailObj.Unit == "Institutional Asset Management")
                    {
                        emailTo2 = config["EmailConfiguration:InstitutionalAssetGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:InstitutionalAssetLineMgrEmail"];
                    }
                    if (emailObj.Unit == "LagosRM" || emailObj.Unit == "WRM (Lagos)")
                    {
                        emailTo2 = config["EmailConfiguration:LagosRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Operations Settlement")
                    {
                        emailTo2 = config["EmailConfiguration:OperationsSettlementGroupEmail"];
                        lineMgr = config["EmailConfiguration:OperationsSettlementLineMgrEmail"];
                    }
                    if (emailObj.Unit == "AbujaRM" || emailObj.Unit == "WRM (Abuja)")
                    {
                        emailTo2 = config["EmailConfiguration:AbujaRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "PHRM" || emailObj.Unit == "WRM (PortHarcourt)")
                    {
                        emailTo2 = config["EmailConfiguration:PHRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Account Executives")
                    {
                        emailTo2 = config["EmailConfiguration:AccountExecutivesGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Relationship Managers")
                    {
                        emailTo2 = config["EmailConfiguration:RelationshipManagersGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:RelationshipManagersUnitHeadEmailToCC"];
                    }
                    if (emailObj.Unit == "Fund Account")
                    {
                        emailTo2 = config["EmailConfiguration:FundAccountGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAccountLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Securities Operations" || emailObj.Unit == "ARM Securities")
                    {
                        emailTo2 = config["EmailConfiguration:ARMSecuritiesGroupEmail"];
                        lineMgr = config["EmailConfiguration:ARMSecuritiesLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Customer Experience" || emailObj.Unit == "Call Centre" || emailObj.Unit == "Customer Service")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerServiceGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Financial Control")
                    {
                        emailTo2 = config["EmailConfiguration:FinancialControlGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Fund Admin" || emailObj.Unit == "Administration")
                    {
                        emailTo2 = config["EmailConfiguration:FundAdminGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAdminLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Retail Operations")
                    {
                        emailTo2 = config["EmailConfiguration:RetailOperationsGroupEmail"];
                        lineMgr = config["EmailConfiguration:RetailOperationsLineMgrEmail"];
                    }
                    if (emailObj.Unit == "IMUnit" || emailObj.Unit == "ARM IM" || emailObj.Unit == "Investment Management" || emailObj.Unit == "ARMIM")
                    {
                        emailTo2 = config["EmailConfiguration:InvestmentManagementGroupEmail"];
                        lineMgr = config["EmailConfiguration:InvestmentManagementLineMgrEmail"];
                    }
                    if (emailObj.Unit == "ARM Registrars")
                    {
                        emailTo2 = config["EmailConfiguration:RegistrarsGroupEmail"];
                        lineMgr = config["EmailConfiguration:RegistrarsLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Treasury")
                    {
                        emailTo2 = config["EmailConfiguration:TreasuryGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:TreasuryUnitHeadEmailToCC"];
                    }
                    if (emailObj.Unit == "Private Trust" || emailObj.Unit == "ARM Private Trust")
                    {
                        emailTo2 = config["EmailConfiguration:CallOverEmailToPrivateTrust"];
                    }
                    if (emailObj.Unit == "RFL" || emailObj.Unit == "AAFML")
                    {
                        emailTo2 = config["EmailConfiguration:RFLGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Digital Financial Services" || emailObj.Unit == "DFS")
                    {
                        emailTo2 = config["EmailConfiguration:DigitalFinancialServicesGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:DigitalFinancialServicesUnitHeadEmailToCC"];
                    }
                    if (emailObj.Unit == "Information Technology" || emailObj.Unit == "IT")
                    {
                        emailTo2 = config["EmailConfiguration:InformationTechnologyGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Internal Control")
                    {
                        emailTo2 = config["EmailConfiguration:InternalControlEmailTo"];
                        lineMgr = config["EmailConfiguration:InternalControlUnitHeadEmailTo"];
                    }
                    if (emailObj.Unit == "Legal")
                    {
                        emailTo2 = config["EmailConfiguration:LegalGroupEmail"];
                    }
                    if (emailObj.Unit == "Corporate Transformation")
                    {
                        emailTo2 = config["EmailConfiguration:CorporateTransformationGroupEmail"];
                    }
                    var emailSender = new MimeMessage();
                    string filePath = config["EmailConfiguration:filePath"];
                    string subject = "Action Required: Outstanding Management Response for Exception";
                    string emailTo = emailObj.ResponsibleOfficerEmail;
                    string emailToCC = $"{emailTo2},{config["EmailConfiguration:InternalControlEmailTo"]},{lineMgr}";
                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string message = $"Dear {emailObj.ResponsibleOfficer},<br><br>This email serves as a reminder to an outstanding management response for your attention.<br><br>Please submit your management response promptly through the GRC tool via the link below.<br><br><a href={linkToGRCTool}>GRC Link</a>";

                    var result = await SendEmailNotificationAsyncV1(subject: subject, emailTo: emailTo, toCC: emailToCC, body: message, filePath: filePath, config: config);
                    emailObj.UpdateException48HoursReminder(result);
                    await exceptionTracker.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        public async Task Exception36HoursReminderSendEmailAsync()
        {
            try
            {
                var emailObj = exceptionTracker.GetContextByConditon(e => e.Deadline.Value.Date.AddDays(-3) == DateTime.Now.Date && e.ExceptionTrackerStatus != ExceptionTrackerStatus.Resolved && e.IsReminderSent36Hrs == false).FirstOrDefault();
                if (emailObj != null)
                {
                    string? emailTo2 = emailObj.ResponsibleOfficerEmail;
                    string? lineMgr = emailObj.ResponsibleOfficerEmail;
                    if (emailObj.Unit == "Customer Onboarding & DataMgtTeam" || emailObj.Unit == "CustomerOnboarding&DataMgtTeam")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerOnboarding&DataMgtTeamGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:DataMgtTeamLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Institutional Asset" || emailObj.Unit == "Institutional Asset Management")
                    {
                        emailTo2 = config["EmailConfiguration:InstitutionalAssetGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:InstitutionalAssetLineMgrEmail"];
                    }
                    if (emailObj.Unit == "LagosRM" || emailObj.Unit == "WRM (Lagos)")
                    {
                        emailTo2 = config["EmailConfiguration:LagosRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Operations Settlement")
                    {
                        emailTo2 = config["EmailConfiguration:OperationsSettlementGroupEmail"];
                        lineMgr = config["EmailConfiguration:OperationsSettlementLineMgrEmail"];
                    }
                    if (emailObj.Unit == "AbujaRM" || emailObj.Unit == "WRM (Abuja)")
                    {
                        emailTo2 = config["EmailConfiguration:AbujaRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "PHRM" || emailObj.Unit == "WRM (PortHarcourt)")
                    {
                        emailTo2 = config["EmailConfiguration:PHRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Account Executives")
                    {
                        emailTo2 = config["EmailConfiguration:AccountExecutivesGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Relationship Managers")
                    {
                        emailTo2 = config["EmailConfiguration:RelationshipManagersGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:RelationshipManagersUnitHeadEmailToCC"];
                    }
                    if (emailObj.Unit == "Fund Account")
                    {
                        emailTo2 = config["EmailConfiguration:FundAccountGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAccountLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Securities Operations" || emailObj.Unit == "ARM Securities")
                    {
                        emailTo2 = config["EmailConfiguration:ARMSecuritiesGroupEmail"];
                        lineMgr = config["EmailConfiguration:ARMSecuritiesLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Customer Experience" || emailObj.Unit == "Call Centre" || emailObj.Unit == "Customer Service")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerServiceGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Financial Control")
                    {
                        emailTo2 = config["EmailConfiguration:FinancialControlGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Fund Admin" || emailObj.Unit == "Administration")
                    {
                        emailTo2 = config["EmailConfiguration:FundAdminGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAdminLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Retail Operations")
                    {
                        emailTo2 = config["EmailConfiguration:RetailOperationsGroupEmail"];
                        lineMgr = config["EmailConfiguration:RetailOperationsLineMgrEmail"];
                    }
                    if (emailObj.Unit == "IMUnit" || emailObj.Unit == "ARM IM" || emailObj.Unit == "Investment Management" || emailObj.Unit == "ARMIM")
                    {
                        emailTo2 = config["EmailConfiguration:InvestmentManagementGroupEmail"];
                        lineMgr = config["EmailConfiguration:InvestmentManagementLineMgrEmail"];
                    }
                    if (emailObj.Unit == "ARM Registrars")
                    {
                        emailTo2 = config["EmailConfiguration:RegistrarsGroupEmail"];
                        lineMgr = config["EmailConfiguration:RegistrarsLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Treasury")
                    {
                        emailTo2 = config["EmailConfiguration:TreasuryGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:TreasuryUnitHeadEmailToCC"];
                    }
                    if (emailObj.Unit == "Private Trust" || emailObj.Unit == "ARM Private Trust")
                    {
                        emailTo2 = config["EmailConfiguration:CallOverEmailToPrivateTrust"];
                    }
                    if (emailObj.Unit == "RFL" || emailObj.Unit == "AAFML")
                    {
                        emailTo2 = config["EmailConfiguration:RFLGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Digital Financial Services" || emailObj.Unit == "DFS")
                    {
                        emailTo2 = config["EmailConfiguration:DigitalFinancialServicesGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:DigitalFinancialServicesUnitHeadEmailToCC"];
                    }
                    if (emailObj.Unit == "Information Technology" || emailObj.Unit == "IT")
                    {
                        emailTo2 = config["EmailConfiguration:InformationTechnologyGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Internal Control")
                    {
                        emailTo2 = config["EmailConfiguration:InternalControlEmailTo"];
                        lineMgr = config["EmailConfiguration:InternalControlUnitHeadEmailTo"];
                    }
                    if (emailObj.Unit == "Legal")
                    {
                        emailTo2 = config["EmailConfiguration:LegalGroupEmail"];
                    }
                    if (emailObj.Unit == "Corporate Transformation")
                    {
                        emailTo2 = config["EmailConfiguration:CorporateTransformationGroupEmail"];
                    }
                    var emailSender = new MimeMessage();
                    string filePath = config["EmailConfiguration:filePath"];
                    string subject = "Action Required: Outstanding Management Response for Exception";
                    string emailTo = emailObj.ResponsibleOfficerEmail;
                    string emailToCC = $"{emailTo2},{config["EmailConfiguration:InternalControlEmailTo"]},{lineMgr}";
                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string message = $"Dear {emailObj.ResponsibleOfficer},<br><br>This email serves as a reminder to an outstanding management response for your attention.<br><br>Please submit your management response promptly through the GRC tool via the link below.<br><br><a href={linkToGRCTool}>GRC Link</a>";

                    var result = await SendEmailNotificationAsyncV1(subject: subject, emailTo: emailTo, toCC: emailToCC, body: message, filePath: filePath, config: config);
                    emailObj.UpdateException36HoursReminder(result);
                    await exceptionTracker.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        public async Task Exception24HoursReminderSendEmailAsync()
        {
            try
            {
                var emailObj = exceptionTracker.GetContextByConditon(e => e.Deadline.Value.Date.AddDays(-2) == DateTime.Now.Date && e.ExceptionTrackerStatus != ExceptionTrackerStatus.Resolved && e.IsReminderSent24Hrs == false).FirstOrDefault();
                if (emailObj != null)
                {
                    string? emailTo2 = emailObj.ResponsibleOfficerEmail;
                    string? lineMgr = emailObj.ResponsibleOfficerEmail;
                    if (emailObj.Unit == "Fund Admin")
                    {
                        emailTo2 = config["EmailConfiguration:FundAdminGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAdminLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Retail Operations")
                    {
                        emailTo2 = config["EmailConfiguration:RetailOperationsGroupEmail"];
                    }
                    if (emailObj.Unit == "Operations Settlement")
                    {
                        emailTo2 = config["EmailConfiguration:OperationsSettlementGroupEmail"];
                    }
                    if (emailObj.Unit == "Financial Control")
                    {
                        emailTo2 = config["EmailConfiguration:FinancialControlGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Information Technology" || emailObj.Unit == "IT")
                    {
                        emailTo2 = config["EmailConfiguration:InformationTechnologyGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "RFL" || emailObj.Unit == "AAFML")
                    {
                        emailTo2 = config["EmailConfiguration:RFLGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Treasury")
                    {
                        emailTo2 = config["EmailConfiguration:TreasuryGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Private Trust" || emailObj.Unit == "ARM Private Trust")
                    {
                        emailTo2 = config["EmailConfiguration:CallOverEmailToPrivateTrust"];
                    }
                    if (emailObj.Unit == "Digital Financial Services (DFS)" || emailObj.Unit == "Digital Financial Services" || emailObj.Unit == "DFS")
                    {
                        emailTo2 = config["EmailConfiguration:DigitalFinancialServicesGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "ARM Securities" || emailObj.Unit == "Securities Operations")
                    {
                        emailTo2 = config["EmailConfiguration:ARMSecuritiesGroupEmail"];
                    }
                    if (emailObj.Unit == "Business Development")
                    {
                        emailTo2 = config["EmailConfiguration:BusinessDevelopmentGroupEmail"];
                    }
                    if (emailObj.Unit == "Registrars" || emailObj.Unit == "ARM Registrars")
                    {
                        emailTo2 = config["EmailConfiguration:RegistrarsGroupEmail"];
                    }
                    if (emailObj.Unit == "IMUnit" || emailObj.Unit == "ARM IM" || emailObj.Unit == "Research" || emailObj.Unit == "ARMIM" || emailObj.Unit == "Investment Management")
                    {
                        emailTo2 = config["EmailConfiguration:InvestmentManagementGroupEmail"];
                    }
                    if (emailObj.Unit == "Fund Account")
                    {
                        emailTo2 = config["EmailConfiguration:FundAccountGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAccountLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Customer Experience" || emailObj.Unit == "Call Centre" || emailObj.Unit == "Customer Service")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerServiceGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Relationship Managers")
                    {
                        emailTo2 = config["EmailConfiguration:RelationshipManagersGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Account Executives")
                    {
                        emailTo2 = config["EmailConfiguration:AccountExecutivesGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Customer Onboarding & DataMgtTeam")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerOnboarding&DataMgtTeamGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Institutional Asset")
                    {
                        emailTo2 = config["EmailConfiguration:InstitutionalAssetGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "LagosRM" || emailObj.Unit == "WRM (Lagos)")
                    {
                        emailTo2 = config["EmailConfiguration:LagosRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "AbujaRM" || emailObj.Unit == "WRM (Abuja)")
                    {
                        emailTo2 = config["EmailConfiguration:AbujaRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "PHRM" || emailObj.Unit == "WRM (PortHarcourt)")
                    {
                        emailTo2 = config["EmailConfiguration:PHRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Legal")
                    {
                        emailTo2 = config["EmailConfiguration:LegalGroupEmail"];
                    }
                    if (emailObj.Unit == "Corporate Transformation")
                    {
                        emailTo2 = config["EmailConfiguration:CorporateTransformationGroupEmail"];
                    }
                    var emailSender = new MimeMessage();
                    string filePath = config["EmailConfiguration:filePath"];
                    string subject = "Action Required: Outstanding Management Response for Exception";
                    string emailTo = emailObj.ResponsibleOfficerEmail;
                    string emailToCC = $"{emailTo2},{config["EmailConfiguration:InternalControlEmailTo"]},{lineMgr}";
                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string message = $"Dear {emailObj.ResponsibleOfficer},<br><br>This email serves as a reminder to an outstanding management response for your attention.<br><br>Please submit your management response promptly through the GRC tool via the link below.<br><br><a href={linkToGRCTool}>GRC Link</a>";

                    var result = await SendEmailNotificationAsyncV1(subject: subject, emailTo: emailTo, toCC: emailToCC, body: message, filePath: filePath, config: config);
                    emailObj.UpdateException24HoursReminder(result);
                    await exceptionTracker.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        public async Task Exception12HoursReminderSendEmailAsync()
        {
            try
            {
                var emailObj = exceptionTracker.GetContextByConditon(e => e.Deadline.Value.Date.AddDays(-1) == DateTime.Now.Date && e.ExceptionTrackerStatus != ExceptionTrackerStatus.Resolved && e.IsReminderSent12Hrs == false).FirstOrDefault();
                if (emailObj != null)
                {
                    string? emailTo2 = emailObj.ResponsibleOfficerEmail;
                    string? lineMgr = emailObj.ResponsibleOfficerEmail;
                    if (emailObj.Unit == "Fund Admin")
                    {
                        emailTo2 = config["EmailConfiguration:FundAdminGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAdminLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Retail Operations")
                    {
                        emailTo2 = config["EmailConfiguration:RetailOperationsGroupEmail"];
                    }
                    if (emailObj.Unit == "Operations Settlement")
                    {
                        emailTo2 = config["EmailConfiguration:OperationsSettlementGroupEmail"];
                    }
                    if (emailObj.Unit == "Financial Control")
                    {
                        emailTo2 = config["EmailConfiguration:FinancialControlGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Information Technology" || emailObj.Unit == "IT")
                    {
                        emailTo2 = config["EmailConfiguration:InformationTechnologyGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "RFL" || emailObj.Unit == "AAFML")
                    {
                        emailTo2 = config["EmailConfiguration:RFLGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Treasury")
                    {
                        emailTo2 = config["EmailConfiguration:TreasuryGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Private Trust" || emailObj.Unit == "ARM Private Trust")
                    {
                        emailTo2 = config["EmailConfiguration:CallOverEmailToPrivateTrust"];
                    }
                    if (emailObj.Unit == "Digital Financial Services (DFS)" || emailObj.Unit == "Digital Financial Services" || emailObj.Unit == "DFS")
                    {
                        emailTo2 = config["EmailConfiguration:DigitalFinancialServicesGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "ARM Securities" || emailObj.Unit == "Securities Operations")
                    {
                        emailTo2 = config["EmailConfiguration:ARMSecuritiesGroupEmail"];
                    }
                    if (emailObj.Unit == "Business Development")
                    {
                        emailTo2 = config["EmailConfiguration:BusinessDevelopmentGroupEmail"];
                    }
                    if (emailObj.Unit == "Registrars" || emailObj.Unit == "ARM Registrars")
                    {
                        emailTo2 = config["EmailConfiguration:RegistrarsGroupEmail"];
                    }
                    if (emailObj.Unit == "IMUnit" || emailObj.Unit == "ARM IM" || emailObj.Unit == "Research" || emailObj.Unit == "ARMIM" || emailObj.Unit == "Investment Management")
                    {
                        emailTo2 = config["EmailConfiguration:InvestmentManagementGroupEmail"];
                    }
                    if (emailObj.Unit == "Fund Account")
                    {
                        emailTo2 = config["EmailConfiguration:FundAccountGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAccountLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Customer Experience" || emailObj.Unit == "Call Centre" || emailObj.Unit == "Customer Service")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerServiceGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Relationship Managers")
                    {
                        emailTo2 = config["EmailConfiguration:RelationshipManagersGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Account Executives")
                    {
                        emailTo2 = config["EmailConfiguration:AccountExecutivesGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Customer Onboarding & DataMgtTeam")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerOnboarding&DataMgtTeamGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Institutional Asset")
                    {
                        emailTo2 = config["EmailConfiguration:InstitutionalAssetGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "LagosRM" || emailObj.Unit == "WRM (Lagos)")
                    {
                        emailTo2 = config["EmailConfiguration:LagosRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "AbujaRM" || emailObj.Unit == "WRM (Abuja)")
                    {
                        emailTo2 = config["EmailConfiguration:AbujaRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "PHRM" || emailObj.Unit == "WRM (PortHarcourt)")
                    {
                        emailTo2 = config["EmailConfiguration:PHRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Legal")
                    {
                        emailTo2 = config["EmailConfiguration:LegalGroupEmail"];
                    }
                    if (emailObj.Unit == "Corporate Transformation")
                    {
                        emailTo2 = config["EmailConfiguration:CorporateTransformationGroupEmail"];
                    }
                    var emailSender = new MimeMessage();
                    string filePath = config["EmailConfiguration:filePath"];
                    string subject = "Action Required: Outstanding Management Response for Exception";
                    string emailTo = emailObj.ResponsibleOfficerEmail;
                    string emailToCC = $"{emailTo2},{config["EmailConfiguration:InternalControlEmailTo"]},{lineMgr}";
                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string message = $"Dear {emailObj.ResponsibleOfficer},<br><br>This email serves as a reminder to an outstanding management response for your attention.<br><br>Please submit your management response promptly through the GRC tool via the link below.<br><br><a href={linkToGRCTool}>GRC Link</a>";

                    var result = await SendEmailNotificationAsyncV1(subject: subject, emailTo: emailTo, toCC: emailToCC, body: message, filePath: filePath, config: config);
                    emailObj.UpdateException12HoursReminder(result);
                    await exceptionTracker.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        #endregion


        #region Internal Control Investigation Email reminder
        public async Task Investigation48HoursReminderSendEmailAsync()
        {
            try
            {
                var emailObj = investigation.GetContextByConditon(e => e.Deadline.Date.AddDays(-4) == DateTime.Now.Date && e.ActionOwnerStatus == InternalControlStatus.Pending && e.IsReminderSent48Hrs == false).FirstOrDefault();
                if (emailObj != null)
                {
                    string? emailTo2 = emailObj.ActionOwnerEmail;
                    string? lineMgr = emailObj.ActionOwnerEmail;
                    if (emailObj.Unit == "Customer Onboarding & DataMgtTeam" || emailObj.Unit == "CustomerOnboarding&DataMgtTeam")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerOnboarding&DataMgtTeamGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:DataMgtTeamLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Institutional Asset" || emailObj.Unit == "Institutional Asset Management")
                    {
                        emailTo2 = config["EmailConfiguration:InstitutionalAssetGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:InstitutionalAssetLineMgrEmail"];
                    }
                    if (emailObj.Unit == "LagosRM" || emailObj.Unit == "WRM (Lagos)")
                    {
                        emailTo2 = config["EmailConfiguration:LagosRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Operations Settlement")
                    {
                        emailTo2 = config["EmailConfiguration:OperationsSettlementGroupEmail"];
                        lineMgr = config["EmailConfiguration:OperationsSettlementLineMgrEmail"];
                    }
                    if (emailObj.Unit == "AbujaRM" || emailObj.Unit == "WRM (Abuja)")
                    {
                        emailTo2 = config["EmailConfiguration:AbujaRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "PHRM" || emailObj.Unit == "WRM (PortHarcourt)")
                    {
                        emailTo2 = config["EmailConfiguration:PHRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Account Executives")
                    {
                        emailTo2 = config["EmailConfiguration:AccountExecutivesGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Relationship Managers")
                    {
                        emailTo2 = config["EmailConfiguration:RelationshipManagersGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:RelationshipManagersUnitHeadEmailToCC"];
                    }
                    if (emailObj.Unit == "Fund Account")
                    {
                        emailTo2 = config["EmailConfiguration:FundAccountGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAccountLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Securities Operations" || emailObj.Unit == "ARM Securities")
                    {
                        emailTo2 = config["EmailConfiguration:ARMSecuritiesGroupEmail"];
                        lineMgr = config["EmailConfiguration:ARMSecuritiesLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Customer Experience" || emailObj.Unit == "Call Centre" || emailObj.Unit == "Customer Service")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerServiceGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Financial Control")
                    {
                        emailTo2 = config["EmailConfiguration:FinancialControlGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Fund Admin" || emailObj.Unit == "Administration")
                    {
                        emailTo2 = config["EmailConfiguration:FundAdminGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAdminLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Retail Operations")
                    {
                        emailTo2 = config["EmailConfiguration:RetailOperationsGroupEmail"];
                        lineMgr = config["EmailConfiguration:RetailOperationsLineMgrEmail"];
                    }
                    if (emailObj.Unit == "IMUnit" || emailObj.Unit == "ARM IM" || emailObj.Unit == "Investment Management" || emailObj.Unit == "ARMIM")
                    {
                        emailTo2 = config["EmailConfiguration:InvestmentManagementGroupEmail"];
                        lineMgr = config["EmailConfiguration:InvestmentManagementLineMgrEmail"];
                    }
                    if (emailObj.Unit == "ARM Registrars")
                    {
                        emailTo2 = config["EmailConfiguration:RegistrarsGroupEmail"];
                        lineMgr = config["EmailConfiguration:RegistrarsLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Treasury")
                    {
                        emailTo2 = config["EmailConfiguration:TreasuryGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:TreasuryUnitHeadEmailToCC"];
                    }
                    if (emailObj.Unit == "Private Trust" || emailObj.Unit == "ARM Private Trust")
                    {
                        emailTo2 = config["EmailConfiguration:CallOverEmailToPrivateTrust"];
                    }
                    if (emailObj.Unit == "RFL" || emailObj.Unit == "AAFML")
                    {
                        emailTo2 = config["EmailConfiguration:RFLGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Digital Financial Services" || emailObj.Unit == "DFS")
                    {
                        emailTo2 = config["EmailConfiguration:DigitalFinancialServicesGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:DigitalFinancialServicesUnitHeadEmailToCC"];
                    }
                    if (emailObj.Unit == "Information Technology" || emailObj.Unit == "IT")
                    {
                        emailTo2 = config["EmailConfiguration:InformationTechnologyGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Internal Control")
                    {
                        emailTo2 = config["EmailConfiguration:InternalControlEmailTo"];
                        lineMgr = config["EmailConfiguration:InternalControlUnitHeadEmailTo"];
                    }
                    if (emailObj.Unit == "Legal")
                    {
                        emailTo2 = config["EmailConfiguration:LegalGroupEmail"];
                    }
                    if (emailObj.Unit == "Corporate Transformation")
                    {
                        emailTo2 = config["EmailConfiguration:CorporateTransformationGroupEmail"];
                    }
                    var emailSender = new MimeMessage();
                    string filePath = config["EmailConfiguration:filePath"];
                    string subject = "Action Required: Outstanding Management Response for Exception";
                    string emailTo = emailObj.ActionOwnerEmail;
                    string emailToCC = $"{emailTo2},{config["EmailConfiguration:InternalControlEmailTo"]},{lineMgr}";
                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string message = $"Dear {emailObj.ActionOwner},<br><br>This email serves as a reminder to an outstanding management response for your attention.<br><br>Please submit your management response promptly through the GRC tool via the link below.<br><br><a href={linkToGRCTool}>GRC Link</a>";

                    var result = await SendEmailNotificationAsyncV1(subject: subject, emailTo: emailTo, toCC: emailToCC, body: message, filePath: filePath, config: config);
                    emailObj.UpdateException48HoursReminder(result);
                    await exceptionTracker.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        public async Task Investgation36HoursReminderSendEmailAsync()
        {
            try
            {
                var emailObj = investigation.GetContextByConditon(e => e.Deadline.Date.AddDays(-3) == DateTime.Now.Date && e.ActionOwnerStatus == InternalControlStatus.Pending && e.IsReminderSent36Hrs == false).FirstOrDefault();
                if (emailObj != null)
                {
                    string? emailTo2 = emailObj.ActionOwnerEmail;
                    string? lineMgr = emailObj.ActionOwnerEmail;
                    if (emailObj.Unit == "Customer Onboarding & DataMgtTeam" || emailObj.Unit == "CustomerOnboarding&DataMgtTeam")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerOnboarding&DataMgtTeamGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:DataMgtTeamLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Institutional Asset" || emailObj.Unit == "Institutional Asset Management")
                    {
                        emailTo2 = config["EmailConfiguration:InstitutionalAssetGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:InstitutionalAssetLineMgrEmail"];
                    }
                    if (emailObj.Unit == "LagosRM" || emailObj.Unit == "WRM (Lagos)")
                    {
                        emailTo2 = config["EmailConfiguration:LagosRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Operations Settlement")
                    {
                        emailTo2 = config["EmailConfiguration:OperationsSettlementGroupEmail"];
                        lineMgr = config["EmailConfiguration:OperationsSettlementLineMgrEmail"];
                    }
                    if (emailObj.Unit == "AbujaRM" || emailObj.Unit == "WRM (Abuja)")
                    {
                        emailTo2 = config["EmailConfiguration:AbujaRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "PHRM" || emailObj.Unit == "WRM (PortHarcourt)")
                    {
                        emailTo2 = config["EmailConfiguration:PHRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Account Executives")
                    {
                        emailTo2 = config["EmailConfiguration:AccountExecutivesGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Relationship Managers")
                    {
                        emailTo2 = config["EmailConfiguration:RelationshipManagersGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:RelationshipManagersUnitHeadEmailToCC"];
                    }
                    if (emailObj.Unit == "Fund Account")
                    {
                        emailTo2 = config["EmailConfiguration:FundAccountGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAccountLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Securities Operations" || emailObj.Unit == "ARM Securities")
                    {
                        emailTo2 = config["EmailConfiguration:ARMSecuritiesGroupEmail"];
                        lineMgr = config["EmailConfiguration:ARMSecuritiesLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Customer Experience" || emailObj.Unit == "Call Centre" || emailObj.Unit == "Customer Service")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerServiceGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Financial Control")
                    {
                        emailTo2 = config["EmailConfiguration:FinancialControlGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Fund Admin" || emailObj.Unit == "Administration")
                    {
                        emailTo2 = config["EmailConfiguration:FundAdminGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAdminLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Retail Operations")
                    {
                        emailTo2 = config["EmailConfiguration:RetailOperationsGroupEmail"];
                        lineMgr = config["EmailConfiguration:RetailOperationsLineMgrEmail"];
                    }
                    if (emailObj.Unit == "IMUnit" || emailObj.Unit == "ARM IM" || emailObj.Unit == "Investment Management" || emailObj.Unit == "ARMIM")
                    {
                        emailTo2 = config["EmailConfiguration:InvestmentManagementGroupEmail"];
                        lineMgr = config["EmailConfiguration:InvestmentManagementLineMgrEmail"];
                    }
                    if (emailObj.Unit == "ARM Registrars")
                    {
                        emailTo2 = config["EmailConfiguration:RegistrarsGroupEmail"];
                        lineMgr = config["EmailConfiguration:RegistrarsLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Treasury")
                    {
                        emailTo2 = config["EmailConfiguration:TreasuryGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:TreasuryUnitHeadEmailToCC"];
                    }
                    if (emailObj.Unit == "Private Trust" || emailObj.Unit == "ARM Private Trust")
                    {
                        emailTo2 = config["EmailConfiguration:CallOverEmailToPrivateTrust"];
                    }
                    if (emailObj.Unit == "RFL" || emailObj.Unit == "AAFML")
                    {
                        emailTo2 = config["EmailConfiguration:RFLGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Digital Financial Services" || emailObj.Unit == "DFS")
                    {
                        emailTo2 = config["EmailConfiguration:DigitalFinancialServicesGroupEmailToCC"];
                        lineMgr = config["EmailConfiguration:DigitalFinancialServicesUnitHeadEmailToCC"];
                    }
                    if (emailObj.Unit == "Information Technology" || emailObj.Unit == "IT")
                    {
                        emailTo2 = config["EmailConfiguration:InformationTechnologyGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Internal Control")
                    {
                        emailTo2 = config["EmailConfiguration:InternalControlEmailTo"];
                        lineMgr = config["EmailConfiguration:InternalControlUnitHeadEmailTo"];
                    }
                    if (emailObj.Unit == "Legal")
                    {
                        emailTo2 = config["EmailConfiguration:LegalGroupEmail"];
                    }
                    if (emailObj.Unit == "Corporate Transformation")
                    {
                        emailTo2 = config["EmailConfiguration:CorporateTransformationGroupEmail"];
                    }
                    var emailSender = new MimeMessage();
                    string filePath = config["EmailConfiguration:filePath"];
                    string subject = "Action Required: Outstanding Management Response for Exception";
                    string emailTo = emailObj.ActionOwnerEmail;
                    string emailToCC = $"{emailTo2},{config["EmailConfiguration:InternalControlEmailTo"]},{lineMgr}";
                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string message = $"Dear {emailObj.ActionOwner},<br><br>This email serves as a reminder to an outstanding management response for your attention.<br><br>Please submit your management response promptly through the GRC tool via the link below.<br><br><a href={linkToGRCTool}>GRC Link</a>";

                    var result = await SendEmailNotificationAsyncV1(subject: subject, emailTo: emailTo, toCC: emailToCC, body: message, filePath: filePath, config: config);
                    emailObj.UpdateException36HoursReminder(result);
                    await exceptionTracker.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        public async Task Investgation24HoursReminderSendEmailAsync()
        {
            try
            {
                var emailObj = investigation.GetContextByConditon(e => e.Deadline.Date.AddDays(-2) == DateTime.Now.Date && e.ActionOwnerStatus == InternalControlStatus.Pending && e.IsReminderSent24Hrs == false).FirstOrDefault();
                if (emailObj != null)
                {
                    string? emailTo2 = emailObj.ActionOwnerEmail;
                    string? lineMgr = emailObj.ActionOwnerEmail;
                    if (emailObj.Unit == "Fund Admin")
                    {
                        emailTo2 = config["EmailConfiguration:FundAdminGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAdminLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Retail Operations")
                    {
                        emailTo2 = config["EmailConfiguration:RetailOperationsGroupEmail"];
                    }
                    if (emailObj.Unit == "Operations Settlement")
                    {
                        emailTo2 = config["EmailConfiguration:OperationsSettlementGroupEmail"];
                    }
                    if (emailObj.Unit == "Financial Control")
                    {
                        emailTo2 = config["EmailConfiguration:FinancialControlGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Information Technology" || emailObj.Unit == "IT")
                    {
                        emailTo2 = config["EmailConfiguration:InformationTechnologyGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "RFL" || emailObj.Unit == "AAFML")
                    {
                        emailTo2 = config["EmailConfiguration:RFLGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Treasury")
                    {
                        emailTo2 = config["EmailConfiguration:TreasuryGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Private Trust" || emailObj.Unit == "ARM Private Trust")
                    {
                        emailTo2 = config["EmailConfiguration:CallOverEmailToPrivateTrust"];
                    }
                    if (emailObj.Unit == "Digital Financial Services (DFS)" || emailObj.Unit == "Digital Financial Services" || emailObj.Unit == "DFS")
                    {
                        emailTo2 = config["EmailConfiguration:DigitalFinancialServicesGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "ARM Securities" || emailObj.Unit == "Securities Operations")
                    {
                        emailTo2 = config["EmailConfiguration:ARMSecuritiesGroupEmail"];
                    }
                    if (emailObj.Unit == "Business Development")
                    {
                        emailTo2 = config["EmailConfiguration:BusinessDevelopmentGroupEmail"];
                    }
                    if (emailObj.Unit == "Registrars" || emailObj.Unit == "ARM Registrars")
                    {
                        emailTo2 = config["EmailConfiguration:RegistrarsGroupEmail"];
                    }
                    if (emailObj.Unit == "IMUnit" || emailObj.Unit == "ARM IM" || emailObj.Unit == "Research" || emailObj.Unit == "ARMIM" || emailObj.Unit == "Investment Management")
                    {
                        emailTo2 = config["EmailConfiguration:InvestmentManagementGroupEmail"];
                    }
                    if (emailObj.Unit == "Fund Account")
                    {
                        emailTo2 = config["EmailConfiguration:FundAccountGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAccountLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Customer Experience" || emailObj.Unit == "Call Centre" || emailObj.Unit == "Customer Service")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerServiceGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Relationship Managers")
                    {
                        emailTo2 = config["EmailConfiguration:RelationshipManagersGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Account Executives")
                    {
                        emailTo2 = config["EmailConfiguration:AccountExecutivesGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Customer Onboarding & DataMgtTeam")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerOnboarding&DataMgtTeamGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Institutional Asset")
                    {
                        emailTo2 = config["EmailConfiguration:InstitutionalAssetGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "LagosRM" || emailObj.Unit == "WRM (Lagos)")
                    {
                        emailTo2 = config["EmailConfiguration:LagosRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "AbujaRM" || emailObj.Unit == "WRM (Abuja)")
                    {
                        emailTo2 = config["EmailConfiguration:AbujaRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "PHRM" || emailObj.Unit == "WRM (PortHarcourt)")
                    {
                        emailTo2 = config["EmailConfiguration:PHRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Legal")
                    {
                        emailTo2 = config["EmailConfiguration:LegalGroupEmail"];
                    }
                    if (emailObj.Unit == "Corporate Transformation")
                    {
                        emailTo2 = config["EmailConfiguration:CorporateTransformationGroupEmail"];
                    }
                    var emailSender = new MimeMessage();
                    string filePath = config["EmailConfiguration:filePath"];
                    string subject = "Action Required: Outstanding Management Response for Exception";
                    string emailTo = emailObj.ActionOwnerEmail;
                    string emailToCC = $"{emailTo2},{config["EmailConfiguration:InternalControlEmailTo"]},{lineMgr}";
                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string message = $"Dear {emailObj.ActionOwnerEmail},<br><br>This email serves as a reminder to an outstanding management response for your attention.<br><br>Please submit your management response promptly through the GRC tool via the link below.<br><br><a href={linkToGRCTool}>GRC Link</a>";

                    var result = await SendEmailNotificationAsyncV1(subject: subject, emailTo: emailTo, toCC: emailToCC, body: message, filePath: filePath, config: config);
                    emailObj.UpdateException24HoursReminder(result);
                    await exceptionTracker.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        public async Task Investgation12HoursReminderSendEmailAsync()
        {
            try
            {
                var emailObj = investigation.GetContextByConditon(e => e.Deadline.Date.AddDays(-1) == DateTime.Now.Date && e.ActionOwnerStatus == InternalControlStatus.Pending && e.IsReminderSent12Hrs == false).FirstOrDefault();
                if (emailObj != null)
                {
                    string? emailTo2 = emailObj.ActionOwnerEmail;
                    string? lineMgr = emailObj.ActionOwnerEmail;
                    if (emailObj.Unit == "Fund Admin")
                    {
                        emailTo2 = config["EmailConfiguration:FundAdminGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAdminLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Retail Operations")
                    {
                        emailTo2 = config["EmailConfiguration:RetailOperationsGroupEmail"];
                    }
                    if (emailObj.Unit == "Operations Settlement")
                    {
                        emailTo2 = config["EmailConfiguration:OperationsSettlementGroupEmail"];
                    }
                    if (emailObj.Unit == "Financial Control")
                    {
                        emailTo2 = config["EmailConfiguration:FinancialControlGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Information Technology" || emailObj.Unit == "IT")
                    {
                        emailTo2 = config["EmailConfiguration:InformationTechnologyGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "RFL" || emailObj.Unit == "AAFML")
                    {
                        emailTo2 = config["EmailConfiguration:RFLGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Treasury")
                    {
                        emailTo2 = config["EmailConfiguration:TreasuryGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Private Trust" || emailObj.Unit == "ARM Private Trust")
                    {
                        emailTo2 = config["EmailConfiguration:CallOverEmailToPrivateTrust"];
                    }
                    if (emailObj.Unit == "Digital Financial Services (DFS)" || emailObj.Unit == "Digital Financial Services" || emailObj.Unit == "DFS")
                    {
                        emailTo2 = config["EmailConfiguration:DigitalFinancialServicesGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "ARM Securities" || emailObj.Unit == "Securities Operations")
                    {
                        emailTo2 = config["EmailConfiguration:ARMSecuritiesGroupEmail"];
                    }
                    if (emailObj.Unit == "Business Development")
                    {
                        emailTo2 = config["EmailConfiguration:BusinessDevelopmentGroupEmail"];
                    }
                    if (emailObj.Unit == "Registrars" || emailObj.Unit == "ARM Registrars")
                    {
                        emailTo2 = config["EmailConfiguration:RegistrarsGroupEmail"];
                    }
                    if (emailObj.Unit == "IMUnit" || emailObj.Unit == "ARM IM" || emailObj.Unit == "Research" || emailObj.Unit == "ARMIM" || emailObj.Unit == "Investment Management")
                    {
                        emailTo2 = config["EmailConfiguration:InvestmentManagementGroupEmail"];
                    }
                    if (emailObj.Unit == "Fund Account")
                    {
                        emailTo2 = config["EmailConfiguration:FundAccountGroupEmail"];
                        lineMgr = config["EmailConfiguration:FundAccountLineMgrEmail"];
                    }
                    if (emailObj.Unit == "Customer Experience" || emailObj.Unit == "Call Centre" || emailObj.Unit == "Customer Service")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerServiceGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Relationship Managers")
                    {
                        emailTo2 = config["EmailConfiguration:RelationshipManagersGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Account Executives")
                    {
                        emailTo2 = config["EmailConfiguration:AccountExecutivesGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Customer Onboarding & DataMgtTeam")
                    {
                        emailTo2 = config["EmailConfiguration:CustomerOnboarding&DataMgtTeamGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Institutional Asset")
                    {
                        emailTo2 = config["EmailConfiguration:InstitutionalAssetGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "LagosRM" || emailObj.Unit == "WRM (Lagos)")
                    {
                        emailTo2 = config["EmailConfiguration:LagosRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "AbujaRM" || emailObj.Unit == "WRM (Abuja)")
                    {
                        emailTo2 = config["EmailConfiguration:AbujaRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "PHRM" || emailObj.Unit == "WRM (PortHarcourt)")
                    {
                        emailTo2 = config["EmailConfiguration:PHRMGroupEmailToCC"];
                    }
                    if (emailObj.Unit == "Legal")
                    {
                        emailTo2 = config["EmailConfiguration:LegalGroupEmail"];
                    }
                    if (emailObj.Unit == "Corporate Transformation")
                    {
                        emailTo2 = config["EmailConfiguration:CorporateTransformationGroupEmail"];
                    }
                    var emailSender = new MimeMessage();
                    string filePath = config["EmailConfiguration:filePath"];
                    string subject = "Action Required: Outstanding Management Response for Exception";
                    string emailTo = emailObj.ActionOwnerEmail;
                    string emailToCC = $"{emailTo2},{config["EmailConfiguration:InternalControlEmailTo"]},{lineMgr}";
                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string message = $"Dear {emailObj.ActionOwner},<br><br>This email serves as a reminder to an outstanding management response for your attention.<br><br>Please submit your management response promptly through the GRC tool via the link below.<br><br><a href={linkToGRCTool}>GRC Link</a>";

                    var result = await SendEmailNotificationAsyncV1(subject: subject, emailTo: emailTo, toCC: emailToCC, body: message, filePath: filePath, config: config);
                    emailObj.UpdateException12HoursReminder(result);
                    await exceptionTracker.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        #endregion


        #region Internal Control Dashboard reminder
        public async Task InternalControlDashboardSendEmailAsync()
        {
            try
            {
                var emailObj = icDashboard.GetContextByConditon(e => e.ProposedCompletionDate.Date < DateTime.Now.Date && e.Status != InternalControlDashboardStatus.Completed && e.IsDailyReminderSent == false).FirstOrDefault();
                if (emailObj != null)
                {
                    var emailSender = new MimeMessage();
                    string filePath = config["EmailConfiguration:filePath"];
                    string subject = "Internal Control Task Reminder";
                    string emailTo = emailObj.ActionOwnerEmail;
                    string emailToCC = config["EmailConfiguration:InternalControlEmailTo"];
                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string message = $"Dear {emailObj.ActionOwner},<br><br>This is a reminder that the task {emailObj.Activity} is due for completion on {emailObj.ProposedCompletionDate}.<br><br>Please click the link below to update the status.<br><br><a href={linkToGRCTool}>GRC Link</a>";
                    var result = await SendEmailNotificationAsyncV1(subject: subject, emailTo: emailTo, toCC: emailToCC, body: message, filePath: filePath, config: config);
                    emailObj.UpdateDailyReminder(result);
                    await icDashboard.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        public async Task InternalControlDashboardSendWeekEmailAsync()
        {
            try
            {
                var emailObj = icDashboard.GetContextByConditon(e => e.ActivityIntervals == InternalControlDashboardActivityInterval.Weekly && e.Status != InternalControlDashboardStatus.Completed && e.ProposedCompletionDate.Date < DateTime.Now.Date && e.IsWeeklyReminderSent == false).FirstOrDefault();
                if (emailObj != null)
                {
                    var emailSender = new MimeMessage();
                    string filePath = config["EmailConfiguration:filePath"];
                    string subject = "Internal Control Task Reminder";
                    string emailTo = emailObj.ActionOwnerEmail;
                    string emailToCC = config["EmailConfiguration:InternalControlEmailToCC"];
                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string message = $"Dear {emailObj.ActionOwner},<br><br>This is a reminder that the task {emailObj.Activity} is due for completion on {emailObj.ProposedCompletionDate}.<br><br>Please click the link below to update the status.<br><br><a href={linkToGRCTool}>Grc Link</a>";
                    var result = await SendEmailNotificationAsyncV1(subject: subject, emailTo: emailTo, toCC: emailToCC, body: message, filePath: filePath, config: config);
                    emailObj.UpdateWeeklyReminder(result);
                    await icDashboard.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        public async Task InternalControlDashboardSendMonthlyEmailAsync()
        {
            try
            {
                var emailObj = icDashboard.GetContextByConditon(e => (e.ActivityIntervals == InternalControlDashboardActivityInterval.Bi_Monthly || e.ActivityIntervals == InternalControlDashboardActivityInterval.Monthly || e.ActivityIntervals == InternalControlDashboardActivityInterval.Quarterly) && e.Status != InternalControlDashboardStatus.Completed && e.ProposedCompletionDate.Date < DateTime.Now.Date && e.IsMonthlyReminderSent == false).FirstOrDefault();
                if (emailObj != null)
                {
                    var emailSender = new MimeMessage();
                    string filePath = config["EmailConfiguration:filePath"];
                    string subject = "Internal Control Task Reminder";
                    string emailTo = emailObj.ActionOwnerEmail;
                    string emailToCC = config["EmailConfiguration:InternalControlEmailToCC"];
                    string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                    string message = $"Dear {emailObj.ActionOwner},<br><br>This is a reminder that the task {emailObj.Activity} is due for completion on {emailObj.ProposedCompletionDate}.<br><br>Please click the link below to update the status.<br><br><a href={linkToGRCTool}>Grc Link</a>";
                    
                    var result = await SendEmailNotificationAsyncV1(subject: subject, emailTo: emailTo, toCC: emailToCC, body: message, filePath: filePath, config: config);
                    emailObj.UpdateMonthlyReminder(result);
                    await icDashboard.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        #endregion

        #region Internal Control Call Over

        /// <summary>
        /// Call Over Reports Daily Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task CallOverReportsDailyEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getCallOver = callOverEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate).FirstOrDefault();
                if (getCallOver == null && requestDate.DayOfWeek != DayOfWeek.Saturday && requestDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    string subject = "Upload Call Over Reports Timely";
                    string cc = config["EmailConfiguration:InternalControlEmailTo"]; 
                    string filePath = config["EmailConfiguration:filePath"];
                    TimeOnly expectedUploadTime7 = TimeOnly.FromDateTime(DateTime.Today.AddHours(11));
                    TimeOnly expectedUploadTime9 = TimeOnly.FromDateTime(DateTime.Today.AddHours(10));

                    #region Securities
                    string unitSec = "Securities Operations";             
                    string toSec = config["EmailConfiguration:CallOverEmailToSecurities"];
                    var reqSecurities = InternalControlCallOver.LogEmail(unitSec, 1, expectedUploadTime7);
                    await callOverEmail.AddAsync(reqSecurities);
                    var linkToGRCToolSecOp = string.Format(config["EmailConfiguration:linkToGRCToolCallOverReportSec"], reqSecurities.Id);
                    string messageSec = $"Dear {unitSec},<br><br>Please be informed that you are expected to upload the team daily call over for today on the GRC Tool.<br><br><a href={linkToGRCToolSecOp}>GRC Link</a><br><br>Note that the timeline for completion of upload is 7am tomorrow. Kindly ensure your supervisor reviews and approves on the GRC tool before the stipulated timeline.<br><br>Thank you.";

                    //report
                    var reqSecuritiesReport = InternalControlCallOverReport.Create(reqSecurities.Id, "Trade reconciliation");
                    await callOverReportsEmail.AddAsync(reqSecuritiesReport);
                    
                   
                    #endregion

                    #region Customer Experience
                    string unitCustexp = "Customer Experience";
                    string toCustexp = config["EmailConfiguration:CallOverEmailToCustomerExp"];
                    var reqCustexp = InternalControlCallOver.LogEmail(unitCustexp, 5, expectedUploadTime7);
                    await callOverEmail.AddAsync(reqCustexp);
                    var linkToGRCToolCusExp = string.Format(config["EmailConfiguration:linkToGRCToolCallOverReportCUSExp"], reqCustexp.Id);
                    string messageCustexp = $"Dear {unitCustexp},<br><br>Please be informed that you are expected to upload the team daily call over for today on the GRC Tool.<br><br><a href={linkToGRCToolCusExp}>GRC Link</a><br><br>Note that the timeline for completion of upload is 7am tomorrow. Kindly ensure your supervisor reviews and approves on the GRC tool before the stipulated timeline.<br><br>Thank you.";

                    //report
                    var reqReportBranch = InternalControlCallOverReport.Create(reqCustexp.Id, "Branch");
                    await callOverReportsEmail.AddAsync(reqReportBranch);
                    var reqReportEmail = InternalControlCallOverReport.Create(reqCustexp.Id, "Email Team");
                    await callOverReportsEmail.AddAsync(reqReportEmail);
                    var reqReportContact = InternalControlCallOverReport.Create(reqCustexp.Id, "Contact Center");
                    await callOverReportsEmail.AddAsync(reqReportContact);
                    var reqReportCX = InternalControlCallOverReport.Create(reqCustexp.Id, "CX Securities");
                    await callOverReportsEmail.AddAsync(reqReportCX);
                    var reqReportComplaints = InternalControlCallOverReport.Create(reqCustexp.Id, "Complaints Management");
                    await callOverReportsEmail.AddAsync(reqReportComplaints);                   
                    #endregion

                    #region FINCON 
                    string unitFINCON = "Financial Control";
                    string toFINCON = config["EmailConfiguration:CallOverEmailToFINCON"];
                    var reqFINCON = InternalControlCallOver.LogEmail(unitFINCON, 2, expectedUploadTime7);
                    await callOverEmail.AddAsync(reqFINCON);
                    var linkToGRCToolFINCON = string.Format(config["EmailConfiguration:linkToGRCToolCallOverReportFINCON"], reqFINCON.Id);
                    string messageFINCON = $"Dear {unitFINCON},<br><br>Please be informed that you are expected to upload the team daily call over for today on the GRC Tool.<br><br><a href={linkToGRCToolFINCON}>GRC Link</a><br><br>Note that the timeline for completion of upload is 7am tomorrow. Kindly ensure your supervisor reviews and approves on the GRC tool before the stipulated timeline.<br><br>Thank you.";

                    //report
                    var reqReportReconciliation = InternalControlCallOverReport.Create(reqFINCON.Id, "Securities Reconciliation");
                    await callOverReportsEmail.AddAsync(reqReportReconciliation);
                    var reqReportHoldco = InternalControlCallOverReport.Create(reqFINCON.Id, "Holdco Reconciliation");
                    await callOverReportsEmail.AddAsync(reqReportHoldco);

                    #endregion

                    #region Fund Account 
                    string unitFundAccount = "Fund Account";
                    string toFundAccount = config["EmailConfiguration:CallOverEmailToFundAccount"];
                    var reqFundAccount = InternalControlCallOver.LogEmail(unitFundAccount, 5, expectedUploadTime9);
                    await callOverEmail.AddAsync(reqFundAccount);
                    var linkToGRCToolFundAcct = string.Format(config["EmailConfiguration:linkToGRCToolCallOverReportFundAcct"], reqFundAccount.Id);
                    string messageFundAccount = $"Dear {unitFundAccount},<br><br>Please be informed that you are expected to upload the team daily call over for today on the GRC Tool.<br><br><a href={linkToGRCToolFundAcct}>GRC Link</a><br><br>Note that the timeline for completion of upload is 9am tomorrow. Kindly ensure your supervisor reviews and approves on the GRC tool before the stipulated timeline.<br><br>Thank you.";

                    //report
                    var reqReportPrice = InternalControlCallOverReport.Create(reqFundAccount.Id, "Price and Rates");
                    await callOverReportsEmail.AddAsync(reqReportPrice);

                    var reqReportInjections = InternalControlCallOverReport.Create(reqFundAccount.Id, "Client Injections");
                    await callOverReportsEmail.AddAsync(reqReportInjections);

                    var reqReportWithdrawals = InternalControlCallOverReport.Create(reqFundAccount.Id, "Client Withdrawals");
                    await callOverReportsEmail.AddAsync(reqReportWithdrawals);

                    var reqReportMapping = InternalControlCallOverReport.Create(reqFundAccount.Id, "Portfolio Creation and Bank Fees Mapping");
                    await callOverReportsEmail.AddAsync(reqReportMapping);

                    var reqReportValuation = InternalControlCallOverReport.Create(reqFundAccount.Id, "Valuation and Pricing Prerequisites");
                    await callOverReportsEmail.AddAsync(reqReportValuation);
                    #endregion

                    #region ARM IM 
                    string unitARMIM = "Investment Management";
                    string toARMIM = config["EmailConfiguration:CallOverEmailToARMIM"];
                    var reqARMIM = InternalControlCallOver.LogEmail(unitARMIM, 1, expectedUploadTime9);
                    await callOverEmail.AddAsync(reqARMIM);
                    var linkToGRCToolARMIM = string.Format(config["EmailConfiguration:linkToGRCToolCallOverReportARMIM"], reqARMIM.Id);
                    string messageARMIM = $"Dear {unitARMIM},<br><br>Please be informed that you are expected to upload the team daily call over for today on the GRC Tool.<br><br><a href={linkToGRCToolARMIM}>GRC Link</a><br><br>Note that the timeline for completion of upload is 9am tomorrow. Kindly ensure your supervisor reviews and approves on the GRC tool before the stipulated timeline.<br><br>Thank you.";

                    // reports
                    var reqReportIMDaily = InternalControlCallOverReport.Create(reqARMIM.Id, "Daily Callover");
                    await callOverReportsEmail.AddAsync(reqReportIMDaily);  
                    
                    #endregion

                    #region Fund Administration 
                    string unitFundAdmin = "Fund Admin";
                    string toFundAdmin = config["EmailConfiguration:CallOverEmailToFundAdmin"];
                    var reqFundAdmin = InternalControlCallOver.LogEmail(unitFundAdmin, 1, expectedUploadTime9);
                    await callOverEmail.AddAsync(reqFundAdmin);
                    var linkToGRCToolFundAdmin = string.Format(config["EmailConfiguration:linkToGRCToolCallOverReportFundAdmin"], reqFundAdmin.Id);
                    string messageFundAdmin = $"Dear {unitFundAdmin},<br><br>Please be informed that you are expected to upload the team daily call over for today on the GRC Tool.<br><br><a href={linkToGRCToolFundAdmin}>GRC Link</a><br><br>Note that the timeline for completion of upload is 9am tomorrow. Kindly ensure your supervisor reviews and approves on the GRC tool before the stipulated timeline.<br><br>Thank you.";

                    //reports
                    var reqReportAdminDaily = InternalControlCallOverReport.Create(reqFundAdmin.Id, "Daily Callover");
                    await callOverReportsEmail.AddAsync(reqReportAdminDaily);

                   
                    #endregion

                    #region Registrars 
                    string unitRegistrars = "Registrars";
                    string toRegistrars = config["EmailConfiguration:CallOverEmailToRegistrars"];
                    var reqRegistrars = InternalControlCallOver.LogEmail(unitRegistrars, 1, expectedUploadTime9);
                    await callOverEmail.AddAsync(reqRegistrars);
                    var linkToGRCToolRegist = string.Format(config["EmailConfiguration:linkToGRCToolCallOverReportRegist"], reqRegistrars.Id);
                    string messageRegistrars = $"Dear {unitRegistrars},<br><br>Please be informed that you are expected to upload the team daily call over for today on the GRC Tool.<br><br><a href={linkToGRCToolRegist}>Grc Link</a><br><br>Note that the timeline for completion of upload is 9am tomorrow. Kindly ensure your supervisor reviews and approves on the GRC tool before the stipulated timeline.<br><br>Thank you.";

                    //report
                    var reqReportRegDaily = InternalControlCallOverReport.Create(reqRegistrars.Id, "Daily Callover");
                    await callOverReportsEmail.AddAsync(reqReportRegDaily);
                    #endregion

                    #region Retails Operations 
                    string unitRetailsOp = "Retail Operations";
                    string toRetailsOp = config["EmailConfiguration:CallOverEmailToRetailsOp"];
                    var reqRetailsOp = InternalControlCallOver.LogEmail(unitRetailsOp, 2, expectedUploadTime9);
                    await callOverEmail.AddAsync(reqRetailsOp);
                    var linkToGRCToolRetailOps = string.Format(config["EmailConfiguration:linkToGRCToolCallOverReportRetailOps"], reqRetailsOp.Id);
                    string messageRetailsOp = $"Dear {unitRetailsOp},<br><br>Please be informed that you are expected to upload the team daily call over for today on the GRC Tool.<br><br><a href={linkToGRCToolRetailOps}>GRC Link</a><br><br>Note that the timeline for completion of upload is 9am tomorrow. Kindly ensure your supervisor reviews and approves on the GRC tool before the stipulated timeline.<br><br>Thank you.";
                    //report                    
                    var reqReportRed = InternalControlCallOverReport.Create(reqRetailsOp.Id, "Redemption Schedule");
                    await callOverReportsEmail.AddAsync(reqReportRed);                  
                    var reqReportSubscription = InternalControlCallOverReport.Create(reqRetailsOp.Id, "Subscription Call over");
                    await callOverReportsEmail.AddAsync(reqReportSubscription);

                    #endregion

                    #region Treasury 
                    string unitTreasury = "Treasury";
                    string toTreasury = config["EmailConfiguration:CallOverEmailToTreasury"];
                    var reqTreasury = InternalControlCallOver.LogEmail(unitTreasury, 1, expectedUploadTime9);
                    await callOverEmail.AddAsync(reqTreasury);
                    var linkToGRCToolTreasury = string.Format(config["EmailConfiguration:linkToGRCToolCallOverReportTreasury"], reqTreasury.Id);
                    string messageTreasury = $"Dear {unitTreasury},<br><br>Please be informed that you are expected to upload the team daily call over for today on the GRC Tool.<br><br><a href={linkToGRCToolTreasury}>GRC Link</a><br><br>Note that the timeline for completion of upload is 9am tomorrow. Kindly ensure your supervisor reviews and approves on the GRC tool before the stipulated timeline.<br><br>Thank you.";

                    //report
                    var reqReportTresuryDaily = InternalControlCallOverReport.Create(reqTreasury.Id, "Daily Callover");
                    await callOverReportsEmail.AddAsync(reqReportTresuryDaily);
                    #endregion

                    #region Operations Settlement
                    string unitOpSet = "Operations Settlement";
                    string toOpSet = config["EmailConfiguration:OperationsSettlementLineMgrEmail"];
                    var reqOpSet = InternalControlCallOver.LogEmail(unitOpSet, 10, expectedUploadTime9);
                    await callOverEmail.AddAsync(reqOpSet);
                    var linkToGRCToolOpSet = string.Format(config["EmailConfiguration:linkToGRCToolCallOverReportOpSettle"], reqOpSet.Id);
                    string messageOpSet = $"Dear {unitOpSet},<br><br>Please be informed that you are expected to upload the team daily call over for today on the GRC Tool.<br><br><a href={linkToGRCToolOpSet}>GRC Link</a><br><br>Note that the timeline for completion of upload is 9am tomorrow. Kindly ensure your supervisor reviews and approves on the GRC tool before the stipulated timeline.<br><br>Thank you.";

                    //report
                    var reqReportIMBlotter = InternalControlCallOverReport.Create(reqOpSet.Id, "IM Blotter");
                    await callOverReportsEmail.AddAsync(reqReportIMBlotter);
                    var reqReportCashSweep = InternalControlCallOverReport.Create(reqOpSet.Id, "Cash Sweep Blotter");
                    await callOverReportsEmail.AddAsync(reqReportCashSweep);
                    var reqReportDatabase = InternalControlCallOverReport.Create(reqOpSet.Id, "FI Database");
                    await callOverReportsEmail.AddAsync(reqReportDatabase);
                    var reqReportCoupon = InternalControlCallOverReport.Create(reqOpSet.Id, "Coupon Payments");
                    await callOverReportsEmail.AddAsync(reqReportCoupon);
                    var reqReportTradeInvestment = InternalControlCallOverReport.Create(reqOpSet.Id, "Trade Investment Certificates for Portfolios");
                    await callOverReportsEmail.AddAsync(reqReportTradeInvestment);
                    var reqReportCertificates = InternalControlCallOverReport.Create(reqOpSet.Id, "Trade Investment Certificates for Mutual Funds");
                    await callOverReportsEmail.AddAsync(reqReportCertificates);
                    var reqReportDocuments = InternalControlCallOverReport.Create(reqOpSet.Id, "Trade Settlement Documents");
                    await callOverReportsEmail.AddAsync(reqReportDocuments);
                    var reqReportTransNGN = InternalControlCallOverReport.Create(reqOpSet.Id, "Trans NGN");
                    await callOverReportsEmail.AddAsync(reqReportTransNGN);
                    var reqReportReprocessed = InternalControlCallOverReport.Create(reqOpSet.Id, "Reprocessed Items");
                    await callOverReportsEmail.AddAsync(reqReportReprocessed);
                    var reqReportSTPRed = InternalControlCallOverReport.Create(reqOpSet.Id, " STP Redemptions");
                    await callOverReportsEmail.AddAsync(reqReportSTPRed);

                    #endregion

                    #region Private Trust 
                    string unitPrivateTrust = "ARM Private Trust";
                    string toPrivateTrust = config["EmailConfiguration:CallOverEmailToPrivateTrust"];
                    var reqPrivateTrust = InternalControlCallOver.LogEmail(unitPrivateTrust, 1, expectedUploadTime9);
                    await callOverEmail.AddAsync(reqPrivateTrust);
                    var linkToGRCToolPrivateTrust = string.Format(config["EmailConfiguration:linkToGRCToolCallOverReportPrivateTrust"], reqPrivateTrust.Id);
                    string messagePrivateTrust = $"Dear {unitPrivateTrust},<br><br>Please be informed that you are expected to upload the team daily call over for today on the GRC Tool.<br><br><a href={linkToGRCToolPrivateTrust}>GRC Link</a><br><br>Note that the timeline for completion of upload is 9am tomorrow. Kindly ensure your supervisor reviews and approves on the GRC tool before the stipulated timeline.<br><br>Thank you.";

                    //report
                    var reqReportPrivateTrustDaily = InternalControlCallOverReport.Create(reqPrivateTrust.Id, "Daily Callover");
                    await callOverReportsEmail.AddAsync(reqReportPrivateTrustDaily);
                    await callOverReportsEmail.SaveChangesAsync();
                   
                    var result = await SendEmailNotificationAsyncV1(subject, toSec, cc, messageSec, filePath, config: config);
                    var result1 = await SendEmailNotificationAsyncV1(subject, toCustexp, cc, messageCustexp, filePath, config: config);
                    var result2 = await SendEmailNotificationAsyncV1(subject, toFINCON, cc, messageFINCON, filePath, config: config);
                    var result3 = await SendEmailNotificationAsyncV1(subject, toFundAccount, cc, messageFundAccount, filePath, config: config);
                    var result4 = await SendEmailNotificationAsyncV1(subject, toARMIM, cc, messageARMIM, filePath, config: config);
                    var result5 = await SendEmailNotificationAsyncV1(subject, toFundAdmin, cc, messageFundAdmin, filePath, config: config);
                    var result6 = await SendEmailNotificationAsyncV1(subject, toRegistrars, cc, messageRegistrars, filePath, config: config);
                    var result7 = await SendEmailNotificationAsyncV1(subject, toRetailsOp, cc, messageRetailsOp, filePath, config: config);
                    var result8 = await SendEmailNotificationAsyncV1(subject, toTreasury, cc, messageTreasury, filePath, config: config);
                    var result9 = await SendEmailNotificationAsyncV1(subject, toOpSet, cc, messageOpSet, filePath, config: config);
                    var result10 = await SendEmailNotificationAsyncV1(subject, toPrivateTrust, cc, messagePrivateTrust, filePath, config: config);

                    #endregion
                                       
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        #endregion

        #region Compliance Calendar Service
        /// <summary>
        /// Major Deal Reports Daily Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task MajorDealReportsDailyEmail()
        {
            try
            {               
               var requestDate = DateTime.Now.Date;
               var getMajorDeal = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Major Deals Report" && e.FirmToSubmit == "ARM Securities").FirstOrDefault();
               if (getMajorDeal == null && requestDate.DayOfWeek != DayOfWeek.Saturday && requestDate.DayOfWeek != DayOfWeek.Sunday)
               {
                    var deadLine = DateTime.Today.Add(_5pmrunTime);
                    string nameOfReport = "Major Deals Report";
                    string frequency = "Daily";
                    string firmToSubmit = "ARM Securities";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:MajorDealReportsDailyEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for today in the link below.<br><br>The deadline is => {deadLine}.<br><br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];

                    //log request
                    var req = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit, deadLine);
                    await compliancerepoEmail.AddAsync(req);
                    await compliancerepoEmail.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: req.Id, emailTo: to, toCC: cc);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Foreign Transaction Report Daily  Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task ForeignTransactionReportDailyEmail()
        {
            try
            {              
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Foreign Transaction Report (FTR)").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.DayOfWeek != DayOfWeek.Saturday && requestDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var deadLine = requestDate.AddDays(1).Add(_12pmrunTime);
                    string nameOfReport = "Foreign Transaction Report (FTR)";
                    string frequency = "Daily";
                    string firmToSubmitSec = "ARM Securities";
                    string firmToSubmitIm = "ARM IM";
                    string firmToSubmitTrustee = "ARM Trustee";
                    string firmToSubmitCap = "ARM Capital Partner";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:ForeignTransactionReportDailyEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for today in the link below. <br><br>The deadline is ==> {deadLine}.<br><br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var req = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmitSec, deadLine);
                    await compliancerepoEmail.AddAsync(req);

                    var reqim = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmitIm, deadLine);
                    await compliancerepoEmail.AddAsync(reqim);

                    var reqTrus = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmitTrustee, deadLine);
                    await compliancerepoEmail.AddAsync(reqTrus);

                    var reqCap = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmitCap, deadLine);
                    await compliancerepoEmail.AddAsync(reqCap);
                    await compliancerepoEmail.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: req.Id, emailTo: to, toCC: cc);
                    
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// NAV Price Money Market Fund Weekly Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task NAVPriceMoneyMarketFundWeeklyEmail()
        {
            try
            {                
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "NAV Price for the Money Market Fund").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.DayOfWeek == DayOfWeek.Friday)
                {
                    var deadLine = requestDate.AddDays(3);
                    string nameOfReport = "NAV Price for the Money Market Fund";
                    string frequency = "Weekly";
                    string firmToSubmit = "ARM IM";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:NAVPriceMoneyMarketFundWeeklyEmailTo"];
                    string cc = config["EmailConfiguration:NAVPriceMoneyMarketFundWeeklyEmailToCC"];
                    string message = $"Kindly send your report for the week in the link below.<br><br>The deadline is ==> {deadLine}.<br><br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var req = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit, deadLine);
                    await compliancerepoEmail.AddAsync(req);
                    await compliancerepoEmail.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: req.Id, emailTo: to, toCC: cc);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Currency Transaction Report Weekly Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task CurrencyTransactionReportWeeklyEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Currency Transaction Report (CTR)").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.DayOfWeek == DayOfWeek.Friday)
                {
                    var deadLine = requestDate.AddDays(3);
                    string nameOfReport = "Currency Transaction Report (CTR)";
                    string frequency = "Weekly";
                    string firmToSubmitSec = "ARM Securities";
                    string firmToSubmitIm = "ARM IM";
                    string firmToSubmitTrustee = "ARM Trustee";
                    string firmToSubmitCap = "ARM Capital Partner";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:CurrencyTransactionReportWeeklyEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the week in the link below. <br><br>The deadline is ==> {deadLine}.<br><br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var req = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmitSec, deadLine);
                    await compliancerepoEmail.AddAsync(req);

                    var reqim = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmitIm, deadLine);
                    await compliancerepoEmail.AddAsync(reqim);

                    var reqtrust = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmitTrustee, deadLine);
                    await compliancerepoEmail.AddAsync(reqtrust);

                    var reqcap = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmitCap, deadLine);
                    await compliancerepoEmail.AddAsync(reqcap);
                    await compliancerepoEmail.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: req.Id, emailTo: to, toCC: cc);
                    
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Net Capital Position Weekly Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task NetCapitalPositionWeeklyEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Net Capital Position").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.DayOfWeek == DayOfWeek.Friday)
                {
                    var deadLine = requestDate.AddDays(3);
                    string nameOfReport = "Net Capital Position";
                    string frequency = "Weekly";
                    string firmToSubmit = "ARM Securities";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:NetCapitalPositionWeklyEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the week in the link below.<br><br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var req = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit, deadLine);
                    await compliancerepoEmail.AddAsync(req);
                    await compliancerepoEmail.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: req.Id, emailTo: to, toCC: cc);
                   
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Suspicious Transactions Report Weekly Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task SuspiciousTransactionsReportWeeklyEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Suspicious Transactions Report").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.DayOfWeek == DayOfWeek.Friday)
                {
                    var deadLine = requestDate.AddDays(3);
                    string nameOfReport = "Suspicious Transactions Report";
                    string frequency = "Weekly";
                    string firmToSubmit = "ARM Securities";
                    string firmToSubmit1 = "ARM IM";
                    string firmToSubmit2 = "ARM Trustee";
                    string firmToSubmit3 = "ARM Capital Partner";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:SuspiciousTransactionsReportWeeklyEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the week in the link below.<br><br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var req = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit, deadLine);
                    await compliancerepoEmail.AddAsync(req);
                    var req1 = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit1, deadLine);
                    await compliancerepoEmail.AddAsync(req1);
                    var req2 = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit2, deadLine);
                    await compliancerepoEmail.AddAsync(req2);
                    var req3 = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit3, deadLine); await compliancerepoEmail.AddAsync(req3);

                    await compliancerepoEmail.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: req.Id, emailTo: to, toCC: cc);
                   
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Net Capital Position Monthly Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task NetCapitalPositionMonthlyEmail()
        {
            try
            {                
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Net Capital Position" && e.Frequency == "Monthly").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Day == 4)
                {
                    var deadline = requestDate.AddDays(1);
                    string nameOfReport = "Net Capital Position";
                    string frequency = "Monthly";
                    string firmToSubmit = "ARM Securities";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:NetCapitalPositionMonthlyEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the month in the link below. <br><br>The deadline is => {deadline}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var req = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit, deadline);
                    await compliancerepoEmail.AddAsync(req);
                    await compliancerepoEmail.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: req.Id, emailTo: to, toCC: cc);
                   
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder Net Capital Position Monthly Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task ReminderNetCapitalPositionMonthlyEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Net Capital Position" && e.Frequency == "Monthly" && e.ResponseStatus != ComplianceStatus.Available).FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Day == 6 && requestDate.Hour == 10 && requestDate.Minute == 1)
                {
                    var deadline = requestDate.AddDays(1);
                    string nameOfReport = "Net Capital Position";
                    string frequency = "Monthly";
                    string firmToSubmit = "ARM Securities";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:NetCapitalPositionMonthlyEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the month in the link below. <br><br>The deadline is => {deadline}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                   
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Politically Exposed Persons Returns Monthly Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task PoliticallyExposedPersonsReturnsMonthlyEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Politically Exposed Persons (PEP) Returns" && e.Frequency == "Monthly").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Day == 4)
                {
                    var deadline = requestDate.AddDays(1);
                    string nameOfReport = "Politically Exposed Persons (PEP) Returns";
                    string frequency = "Monthly";
                    string firmToSubmit = "ARM Securities";
                    string firmToSubmit1 = "ARM IM";
                    string firmToSubmit2 = "ARM Trustee";
                    string firmToSubmit3 = "ARM Capital Partner";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:PoliticallyExposedPersonsReturnsMonthlyEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the month in the link below. <br><br>The deadline is => {deadline}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var req = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit, deadline);
                    await compliancerepoEmail.AddAsync(req);
                    var req1 = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit1, deadline);
                    await compliancerepoEmail.AddAsync(req1);
                    var req2 = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit2, deadline);
                    await compliancerepoEmail.AddAsync(req2);
                    var req3 = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit3, deadline);
                    await compliancerepoEmail.AddAsync(req3);
                    await compliancerepoEmail.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: req.Id, emailTo: to, toCC: cc);
                    
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Monthly Reports For Mutual Fund Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task MonthlyReportsForMutualFundEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Monthly Reports for Mutual Fund" && e.Frequency == "Monthly").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Day == 2)
                {
                    var deadline = requestDate.AddDays(1);
                    string nameOfReport = "Monthly Reports for Mutual Fund";
                    string frequency = "Monthly";
                    string firmToSubmit = "Asset Management Firm with Mutual Fund(s)";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:MonthlyReportsForMutualFundEmailTo"];
                    string cc = config["EmailConfiguration:MonthlyReportsForMutualFundEmailToCC"];
                    string message = $"Kindly send your report for the month in the link below.<br><br>The deadline is => {deadline}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var req = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit, deadline);
                    await compliancerepoEmail.AddAsync(req);
                    await compliancerepoEmail.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: req.Id, emailTo: to, toCC: cc);
                    
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Monthly Reports For Mutual Fund Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task ReminderMonthlyReportsForMutualFundEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Monthly Reports for Mutual Fund" && e.Frequency == "Monthly").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Day == 4 && requestDate.Hour == 10 && requestDate.Minute == 2)
                {
                    var deadline = requestDate.AddDays(1);
                    string nameOfReport = "Monthly Reports for Mutual Fund";
                    string frequency = "Monthly";
                    string firmToSubmit = "Asset Management Firm with Mutual Fund(s)";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:MonthlyReportsForMutualFundEmailTo"];
                    string cc = config["EmailConfiguration:MonthlyReportsForMutualFundEmailToCC"];
                    string message = $"Kindly send your report for the month in the link below.<br><br>The deadline is => {deadline}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];

                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                    
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }


        /// <summary>
        /// Monthly Transactions Report Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task MonthlyTransactionsReportEmail()
        {
            try
            {
               
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Monthly Transactions Report" && e.Frequency == "Monthly").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 4 && requestDate.Day == 4)
                {
                    var deadline = requestDate.AddDays(1);
                    string nameOfReport = "Monthly Transactions Report";
                    string frequency = "Monthly";
                    string firmToSubmit = "ARM Securities";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:MonthlyTransactionsReportEmailToCC"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the month in the link below.<br><br>The deadline is => {deadline}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var req = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit, deadline);
                    await compliancerepoEmail.AddAsync(req);
                    await compliancerepoEmail.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: req.Id, emailTo: to, toCC: cc);
                   
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder Monthly Transactions Report Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task ReminderMonthlyTransactionsReportEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Monthly Transactions Report" && e.Frequency == "Monthly").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 4 && requestDate.Day == 10 && requestDate.Hour == 10 && requestDate.Minute == 3)
                {
                    var deadline = DateTime.Now.AddDays(1);
                    string nameOfReport = "Monthly Transactions Report";
                    string frequency = "Monthly";
                    string firmToSubmit = "ARM Securities";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:MonthlyTransactionsReportEmailToCC"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the month in the link below. <br><br>The deadline is => {deadline}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];

                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 1st November Mitigant Or Contingency Plans Annually Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task MitigantOrContingencyPlansAnnuallyEmail()
        {
            try
            {                
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "MitigantOrContingency Plans (R.28 AML-CFT SEC Regulations)" && e.Frequency == "Annually").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 11 && requestDate.Day == 4)
                {
                    var deadline = requestDate.AddDays(1);
                    var deadLine = _target30Dec;
                    string nameOfReport = "MitigantOrContingency Plans (R.28 AML-CFT SEC Regulations)";
                    string frequency = "Annually";
                    string firmToSubmit = "ARM Securities";
                    string firmToSubmit1 = "ARM IM";
                    string firmToSubmit2 = "ARM Trustee";
                    string firmToSubmit3 = "ARM Capital Partner";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:MitigantOrContingencyPlansEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br><br>The deadline is on => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var req = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit, deadLine);
                    await compliancerepoEmail.AddAsync(req);
                    var req1 = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit1, deadLine);
                    await compliancerepoEmail.AddAsync(req1);
                    var req2 = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit2, deadLine);
                    await compliancerepoEmail.AddAsync(req2);
                    var req3 = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit3, deadLine);
                    await compliancerepoEmail.AddAsync(req3);
                    await compliancerepoEmail.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: req.Id, emailTo: to, toCC: cc);
                    
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 15th November Mitigant Or Contingency Plans Annually Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder15thMitigantOrContingencyPlansAnnuallyEmail()
        {
            try
            {                
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "MitigantOrContingency Plans (R.28 AML-CFT SEC Regulations)").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 11 && requestDate.Day == 15 && requestDate.Hour == 10 && requestDate.Minute == 4)
                {
                    var deadLine = _target30Dec;
                    string nameOfReport = "MitigantOrContingency Plans (R.28 AML-CFT SEC Regulations)";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:MitigantOrContingencyPlansEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br><br>The deadline is => {deadLine}.<br><br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];

                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 30th November Mitigant Or Contingency Plans Annually Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder30thMitigantOrContingencyPlansAnnuallyEmail()
        {
            try
            {
                var requestDate = DateTime.Now;
                if (requestDate.Month == 11 && requestDate.Day == 30 && requestDate.Hour == 10 && requestDate.Minute == 5 && requestDate.DayOfWeek != DayOfWeek.Saturday && requestDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var deadLine = _target30Dec;
                    string nameOfReport = "MitigantOrContingency Plans (R.28 AML-CFT SEC Regulations)";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:MitigantOrContingencyPlansEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];

                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 5th December Mitigant Or Contingency Plans Annually Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder5thDecMitigantOrContingencyPlansAnnuallyEmail()
        {
            try
            {
                var requestDate = DateTime.Now;
               // var occurenceDate = _target5Dec;
                if (requestDate.Month == 12 && requestDate.Day == 5 && requestDate.Hour == 10 && requestDate.Minute == 6 && requestDate.DayOfWeek != DayOfWeek.Saturday && requestDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var deadLine = _target30Dec;
                    string nameOfReport = "MitigantOrContingency Plans (R.28 AML-CFT SEC Regulations)";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:MitigantOrContingencyPlansEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br><br>The deadline is => {deadLine}.<br><br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];

                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 10th December Mitigant Or Contingency Plans Annually Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder10thDecMitigantOrContingencyPlansAnnuallyEmail()
        {
            try
            {
                var requestDate = DateTime.Now;
                var occurrenceDate = _target10Dec;
                if (requestDate.Month == 12 && requestDate.Day == 10 && requestDate.Hour == 10 && requestDate.Minute == 7 && requestDate.DayOfWeek != DayOfWeek.Saturday && requestDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var deadLine = _target30Dec;
                    string nameOfReport = "MitigantOrContingency Plans (R.28 AML-CFT SEC Regulations)";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:MitigantOrContingencyPlansEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br><br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];

                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 15th December Mitigant Or Contingency Plans Annually Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder15thDecMitigantOrContingencyPlansAnnuallyEmail()
        {
            try
            {
                var requestDate = DateTime.Now;
                var occurrenceDate = _target15Dec;
                if (requestDate.Month == 12 && requestDate.Day == 15 && requestDate.Hour == 10 && requestDate.Minute == 8 && requestDate.DayOfWeek != DayOfWeek.Saturday && requestDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var deadLine = _target30Dec;
                    string nameOfReport = "MitigantOrContingency Plans (R.28 AML-CFT SEC Regulations)";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:MitigantOrContingencyPlansEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below.<br><br>The deadline is => {deadLine}.<br><br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];

                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 20th December Mitigant Or Contingency Plans Annually Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder20thDecMitigantOrContingencyPlansAnnuallyEmail()
        {
            try
            {
                var requestDate = DateTime.Now;
                if (requestDate.Month == 12 && requestDate.Day == 20 && requestDate.DayOfWeek != DayOfWeek.Saturday && requestDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var deadLine = _target30Dec;
                    string nameOfReport = "MitigantOrContingency Plans (R.28 AML-CFT SEC Regulations)";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:MitigantOrContingencyPlansEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => '{deadLine}'.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];

                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 1st November Independent Testing Compliance Programme Annually Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task IndependentTestingComplianceProgrammeAnnuallyEmail()
        {
            try
            {               
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Independent Testing of AML/CFT Compliance Programme Report (R.29 AML-CFT SEC Regulations)" && e.Frequency == "Annually").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 11 && requestDate.Day == 4)
                {
                    var deadLine = _target30Dec;
                    string nameOfReport = "Independent Testing of AML/CFT Compliance Programme Report (R.29 AML-CFT SEC Regulations)";
                    string frequency = "Annually";
                    string firmToSubmit = "ARM Securities";
                    string firmToSubmit1 = "ARM IM";
                    string firmToSubmit2 = "ARM Trustee";
                    string firmToSubmit3 = "ARM Capital Partner";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:IndependentTestingComplianceProgrammeAnnualyEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var req = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit, deadLine);
                    await compliancerepoEmail.AddAsync(req);
                    var req1 = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit1, deadLine);
                    await compliancerepoEmail.AddAsync(req1);
                    var req2 = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit2, deadLine);
                    await compliancerepoEmail.AddAsync(req2);
                    var req3 = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit3, deadLine);
                    await compliancerepoEmail.AddAsync(req3);
                    await compliancerepoEmail.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: req.Id, emailTo: to, toCC: cc);
                    
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 15th of November Independent Testing Compliance Programme Annually Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder15NovIndependentTestingComplianceProgrammeAnnuallyEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Independent Testing of AML/CFT Compliance Programme Report (R.29 AML-CFT SEC Regulations)" && e.Frequency == "Annually").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 11 && requestDate.Day == 15 && requestDate.Hour == 10 && requestDate.Minute == 8)
                {
                    var deadLine = _target30Dec;
                    string nameOfReport = "Independent Testing of AML/CFT Compliance Programme Report (R.29 AML-CFT SEC Regulations)";
                    string frequency = "Annually";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:IndependentTestingComplianceProgrammeAnnualyEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];

                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 30th of November Independent Testing Compliance Programme Annually Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder30NovIndependentTestingComplianceProgrammeAnnuallyEmail()
        {
            try
            {
                var requestDate = DateTime.Now;
                var occurDate = _target30Nov;
                if (requestDate.Month == 11 && requestDate.Day == 30 && requestDate.Hour == 10 && requestDate.Minute == 9 && requestDate.DayOfWeek != DayOfWeek.Saturday && requestDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var deadLine = _target30Dec;
                    string nameOfReport = "Independent Testing of AML/CFT Compliance Programme Report (R.29 AML-CFT SEC Regulations)";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:IndependentTestingComplianceProgrammeAnnualyEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 5th of December Independent Testing Compliance Programme Annually Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder5thDecIndependentTestingComplianceProgrammeAnnuallyEmail()
        {
            try
            {
                var requestDate = DateTime.Now;
                if (requestDate.Month == 12 && requestDate.Day == 5 && requestDate.Hour == 10 && requestDate.Minute == 10 && requestDate.DayOfWeek != DayOfWeek.Saturday && requestDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var deadLine = _target30Dec;
                    string nameOfReport = "Independent Testing of AML/CFT Compliance Programme Report (R.29 AML-CFT SEC Regulations)";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:IndependentTestingComplianceProgrammeAnnualyEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 10th of December Independent Testing Compliance Programme Annually Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder10thDecIndependentTestingComplianceProgrammeAnnuallyEmail()
        {
            try
            {
                var requestDate = DateTime.Now;
                if (requestDate.Month == 12 && requestDate.Day == 10 && requestDate.Hour == 10 && requestDate.Minute == 10 && requestDate.DayOfWeek != DayOfWeek.Saturday && requestDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var deadLine = _target30Dec;
                    string nameOfReport = "Independent Testing of AML/CFT Compliance Programme Report (R.29 AML-CFT SEC Regulations)";
                    string frequency = "Annually";
                    string firmToSubmit = "ALL";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:IndependentTestingComplianceProgrammeAnnualyEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 15th of December Independent Testing Compliance Programme Annually Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder15thDecIndependentTestingComplianceProgrammeAnnuallyEmail()
        {
            try
            {
                var requestDate = DateTime.Now;
                if (requestDate.Month == 12 && requestDate.Day == 15 && requestDate.Hour == 10 && requestDate.Minute == 10 && requestDate.DayOfWeek != DayOfWeek.Saturday && requestDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var deadLine = _target30Dec;
                    string nameOfReport = "Independent Testing of AML/CFT Compliance Programme Report (R.29 AML-CFT SEC Regulations)";
                    string frequency = "Annually";
                    string firmToSubmit = "ALL";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:IndependentTestingComplianceProgrammeAnnualyEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 20th of December Independent Testing Compliance Programme Annually Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder20thDecIndependentTestingComplianceProgrammeAnnuallyEmail()
        {
            try
            {
                var requestDate = DateTime.Now;
                if (requestDate.Month == 12 && requestDate.Day == 20 && requestDate.Hour == 10 && requestDate.Minute == 1 && requestDate.DayOfWeek != DayOfWeek.Saturday && requestDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var deadLine = _target30Dec;
                    string nameOfReport = "Independent Testing of AML/CFT Compliance Programme Report (R.29 AML-CFT SEC Regulations)";
                    string frequency = "Annually";
                    string firmToSubmit = "ALL";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:IndependentTestingComplianceProgrammeAnnualyEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 1st February Annual Financial Report SEC Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task AnnualFinancialReportSECEmail()
        {
            try
            {                
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Annual Financial Report to the SEC" && e.Frequency == "Annually").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 2 && requestDate.Day == 2)
                {
                    var deadLine = _target25Mar;
                    string nameOfReport = "Annual Financial Report to the SEC";
                    string frequency = "Annually";
                    string firmToSubmit = "ARM Securities";
                    string firmToSubmit1 = "ARM IM";
                    string firmToSubmit2 = "ARM Trustee";
                    string firmToSubmit3 = "ARM Capital Partner";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialReportSECEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>Grc link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var req = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit, deadLine);
                    await compliancerepoEmail.AddAsync(req);
                    var req1 = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit1, deadLine);
                    await compliancerepoEmail.AddAsync(req1);
                    var req2 = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit2, deadLine);
                    await compliancerepoEmail.AddAsync(req2);
                    var req3 = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit3, deadLine);
                    await compliancerepoEmail.AddAsync(req3);
                    await compliancerepoEmail.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: req.Id, emailTo: to, toCC: cc);
                   
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 10th February Annual Financial Report SEC Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder10AnnualFinancialReportSECEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Annual Financial Report to the SEC" && e.Frequency == "Annually").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 2 && requestDate.Day == 15 && requestDate.Hour == 10 && requestDate.Minute == 1)
                {
                    var deadLine = _target25Mar;
                    string nameOfReport = "Annual Financial Report to the SEC";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialReportSECEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 15th February Annual Financial Report SEC Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder15AnnualFinancialReportSECEmail()
        {
            try
            {
                var reqdate = DateTime.Now;
                if (reqdate.Month == 2 && reqdate.Day == 16 && reqdate.Hour == 10 && reqdate.Minute == 1 && reqdate.DayOfWeek != DayOfWeek.Saturday && reqdate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var deadLine = _target25Mar;
                    string nameOfReport = "Annual Financial Report to the SEC";
                    string frequency = "Annually";
                    string firmToSubmit = "ALL";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialReportSECEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 10th March Annual Financial Report SEC Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder10MarAnnualFinancialReportSECEmail()
        {
            try
            {
                var reqDate = DateTime.Now;
                var requestDate = _target10Mar;
                if (reqDate.Month == 3 && reqDate.Day == 10 && requestDate.Hour == 10 && requestDate.Minute == 1 && reqDate.DayOfWeek != DayOfWeek.Saturday && reqDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var deadLine = _target25Mar;
                    string nameOfReport = "Annual Financial Report to the SEC";
                    string frequency = "Annually";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialReportSECEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 15th March Annual Financial Report SEC Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder15MarAnnualFinancialReportSECEmail()
        {
            try
            {
                var reqDate = DateTime.Now;
                if (reqDate.Month == 3 && reqDate.Day == 15 && reqDate.Hour == 10 && reqDate.Minute == 1 && reqDate.DayOfWeek != DayOfWeek.Saturday && reqDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var deadLine = _target25Mar;
                    string nameOfReport = "Annual Financial Report to the SEC";
                    string frequency = "Annually";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialReportSECEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 1th Feb Annual Financial Report Securities NGXC Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task AnnualFinancialReportSecuritiesNGXCEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Annual Financial Report for Securities to the NGX" && e.Frequency == "Annually" && e.FirmToSubmit == "ARM Securities").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 2 && requestDate.Day == 6)
                {
                    var deadLine = _target25Mar;
                    string nameOfReport = "Annual Financial Report for Securities to the NGX";
                    string frequency = "Annually";
                    string firmToSubmit = "ARM Securities";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialReportSecuritiesNGXCEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var req = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit, deadLine);
                    await compliancerepoEmail.AddAsync(req);
                    await compliancerepoEmail.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: req.Id, emailTo: to, toCC: cc);
                    
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 10th Feb Annual Financial Report Securities NGXC Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder10AnnualFinancialReportSecuritiesNGXCEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Annual Financial Report for Securities to the NGX" && e.Frequency == "Annually" && e.FirmToSubmit == "ARM Securities").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 2 && requestDate.Day == 10 && requestDate.Hour == 10 && requestDate.Minute == 1)
                {
                    var deadLine = _target25Mar;
                    string nameOfReport = "Annual Financial Report for Securities to the NGX";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialReportSecuritiesNGXCEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 15th Feb Annual Financial Report Securities NGXC Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder15AnnualFinancialReportSecuritiesNGXCEmail()
        {
            try
            {
                var reqDate = DateTime.Now;
                var requestDate = _target1Feb.AddDays(14);
                if (reqDate.Month == 2 && reqDate.Day == 15 && reqDate.Hour == 9 && reqDate.Minute == 46 && reqDate.DayOfWeek != DayOfWeek.Saturday && reqDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var deadLine = _target25Mar;
                    string nameOfReport = "Annual Financial Report for Securities to the NGX";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialReportSecuritiesNGXCEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 10th Mar Annual Financial Report Securities NGXC Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder10MarAnnualFinancialReportSecuritiesNGXCEmail()
        {
            try
            {
                var reqDate = DateTime.Now;
                var requestDate = _target10Mar;
                if (reqDate.Month == 3 && reqDate.Day == 10 && reqDate.Hour == 9 && reqDate.Minute == 47 && reqDate.DayOfWeek != DayOfWeek.Saturday && reqDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var deadLine = _target25Mar;
                    string nameOfReport = "Annual Financial Report for Securities to the NGX";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialReportSecuritiesNGXCEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 15th Mar Annual Financial Report Securities NGXC Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder15MarAnnualFinancialReportSecuritiesNGXCEmail()
        {
            try
            {
                var reqDate = DateTime.Now;
                var requestDate = _target10Mar.AddDays(5);
                if (reqDate.Month == 3 && reqDate.Day == 15 && reqDate.Hour == 9 && reqDate.Minute == 47 && reqDate.DayOfWeek != DayOfWeek.Saturday && reqDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var deadLine = _target25Mar;
                    string nameOfReport = "Annual Financial Report for Securities to the NGX";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialReportSecuritiesNGXCEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 1st Feb Annual Financial Report Securities NASD Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task AnnualFinancialReportSecuritiesNASDEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Annual Financial Report for Securities to the NASD" && e.Frequency == "Annually" && e.FirmToSubmit == "ARM Securities").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 2 && requestDate.Day == 1)
                {
                    var deadLine = _target25Mar;
                    string nameOfReport = "Annual Financial Report for Securities to the NASD";
                    string frequency = "Annually";
                    string firmToSubmit = "ARM Securities";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialReportSecuritiesNASDEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var req = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit, deadLine);
                    await compliancerepoEmail.AddAsync(req);
                    await compliancerepoEmail.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: req.Id, emailTo: to, toCC: cc);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 10th Feb Annual Financial Report Securities NASD Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder10AnnualFinancialReportSecuritiesNASDEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Annual Financial Report for Securities to the NASD" && e.Frequency == "Annually" && e.FirmToSubmit == "ARM Securities").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 2 && requestDate.Day == 10 && requestDate.Hour == 10 && requestDate.Minute == 1)
                {
                    var deadLine = _target25Mar;
                    string nameOfReport = "Annual Financial Report for Securities to the NASD";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialReportSecuritiesNASDEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 15th Feb Annual Financial Report Securities NASD Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder15AnnualFinancialReportSecuritiesNASDEmail()
        {
            try
            {               
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Annual Financial Report for Securities to the NASD" && e.Frequency == "Annually" && e.FirmToSubmit == "ARM Securities").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 2 && requestDate.Day == 15 && requestDate.Hour == 10 && requestDate.Minute == 1)
                {
                    var deadLine = _target25Mar;
                    string nameOfReport = "Annual Financial Report for Securities to the NASD";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialReportSecuritiesNASDEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>Grc Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
                logger.Information("AnnualFinancialReportSecuritiesNASDEmail: send email for the year");
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 10th Mar Annual Financial Report Securities NASD Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder10MarAnnualFinancialReportSecuritiesNASDEmail()
        {
            try
            {
                var reqDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == reqDate && e.Name == "Annual Financial Report for Securities to the NASD" && e.Frequency == "Annually" && e.FirmToSubmit == "ARM Securities").FirstOrDefault();
                if (getForeignTransaction != null && reqDate.Month == 3 && reqDate.Day == 10 && reqDate.Hour == 10 && reqDate.Minute == 2 && reqDate.DayOfWeek != DayOfWeek.Saturday && reqDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    string nameOfReport = "Annual Financial Report for Securities to the NASD";
                    var deadLine = _target25Mar;
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialReportSecuritiesNASDEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>Grc Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
                logger.Information("AnnualFinancialReportSecuritiesNASDEmail: send email for the year");
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 15th Mar Annual Financial Report Securities NASD Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder15MarAnnualFinancialReportSecuritiesNASDEmail()
        {
            try
            {
                var reqDate = DateTime.Now;
                if (reqDate.Month == 3 && reqDate.Day == 15 && reqDate.Hour == 10 && reqDate.Minute == 46 && reqDate.DayOfWeek != DayOfWeek.Saturday && reqDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    var deadLine = _target25Mar;
                    string nameOfReport = "Annual Financial Report for Securities to the NASD ";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialReportSecuritiesNASDEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 1st Feb Annual Financial Reports Mutual Fund Submission SEC Email Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task AnnualFinancialReportsMutualFundSubmissionSECEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Annual Financial Reports for Mutual Fund Submission to SEC and Publication in 2 Newspapers" && e.Frequency == "Annually" && e.FirmToSubmit == "ARM Securities").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 2 && requestDate.Day == 4)
                {
                    var deadLine = _target25Mar;
                    string nameOfReport = "Annual Financial Reports for Mutual Fund Submission to SEC and Publication in 2 Newspapers";
                    string frequency = "Annually";
                    string firmToSubmit = "ARM Securities";
                    string firmToSubmit1 = "ARM IM";
                    string firmToSubmit2 = "ARM Trustee";
                    string firmToSubmit3 = "ARM Capital Partner";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialReportsMutualFundSubmissionSECEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var req = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit, deadLine);
                    await compliancerepoEmail.AddAsync(req);
                    var req1 = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit1, deadLine);
                    await compliancerepoEmail.AddAsync(req1);
                    var req2 = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit2, deadLine);
                    await compliancerepoEmail.AddAsync(req2);
                    var req3 = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit3, deadLine);
                    await compliancerepoEmail.AddAsync(req3);
                    await compliancerepoEmail.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: req.Id, emailTo: to, toCC: cc);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 10th Feb Annual Financial Reports Mutual Fund Submission SEC Email Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder10AnnualFinancialReportsMutualFundSubmissionSECEmail()
        {
            try
            {                
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Annual Financial Reports for Mutual Fund Submission to SEC and Publication in 2 Newspapers" && e.Frequency == "Annually" && e.FirmToSubmit == "ARM Securities").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 2 && requestDate.Day == 10 && requestDate.Hour == 10 && requestDate.Minute == 2)
                {
                    var deadLine = _target25Mar;
                    string nameOfReport = "Annual Financial Reports for Mutual Fund Submission to SEC and Publication in 2 Newspapers";
                    string frequency = "Annually";
                    string firmToSubmit = "ALL";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialReportsMutualFundSubmissionSECEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>Grc link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 15th Feb Annual Financial Reports Mutual Fund Submission SEC Email Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder15AnnualFinancialReportsMutualFundSubmissionSECEmail()
        {
            try
            {               
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Annual Financial Reports for Mutual Fund Submission to SEC and Publication in 2 Newspapers" && e.Frequency == "Annually" && e.FirmToSubmit == "ARM Securities").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 2 && requestDate.Day == 15 && requestDate.Hour == 10 && requestDate.Minute == 2)
                {
                    var deadLine = _target25Mar;
                    string nameOfReport = "Annual Financial Reports for Mutual Fund Submission to SEC and Publication in 2 Newspapers";

                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialReportsMutualFundSubmissionSECEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>Grc Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 10th March Annual Financial Reports Mutual Fund Submission SEC Email Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder10MarAnnualFinancialReportsMutualFundSubmissionSECEmail()
        {
            try
            {
                var reqDate = DateTime.Now.Date;
                if (reqDate.Month == 3 && reqDate.Day == 10 && reqDate.Hour == 9 && reqDate.Hour == 10 && reqDate.Minute == 2 && reqDate.DayOfWeek != DayOfWeek.Saturday && reqDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    string nameOfReport = "Annual Financial Reports for Mutual Fund Submission to SEC and Publication in 2 Newspapers";
                    var deadLine = _target25Mar;
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialReportsMutualFundSubmissionSECEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>Grc link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 15th March Annual Financial Reports Mutual Fund Submission SEC Email Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder15MarAnnualFinancialReportsMutualFundSubmissionSECEmail()
        {
            try
            {
                var reqDate = DateTime.Now;
                var deadLine = _target25Mar;
                if (reqDate.Month == 3 && reqDate.Day == 15 && reqDate.Hour == 12 && reqDate.Hour == 10 && reqDate.Minute == 2 && reqDate.DayOfWeek != DayOfWeek.Saturday && reqDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    string nameOfReport = "Annual Financial Reports for Mutual Fund Submission to SEC and Publication in 2 Newspapers";

                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialReportsMutualFundSubmissionSECEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>Grc Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 1st Feb Annual Audit of Privacy and Data Protection Practices Email Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task AnnualAuditPrivacyAndDataProtectionPracticesEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Annual Audit of Privacy and Data Protection Practices" && e.Frequency == "Annually" && e.FirmToSubmit == "ARM Securities").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 2 && requestDate.Day == 2)
                {
                    var deadLine = _target15Mar;
                    string nameOfReport = "Annual Audit of Privacy and Data Protection Practices";
                    string frequency = "Annually";
                    string firmToSubmit = "ARM Securities";
                    string firmToSubmitIm = "ARM IM";
                    string firmToSubmitTrustee = "ARM Trustee";
                    string firmToSubmitCP = "ARM Capital Partner";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualAuditPrivacyAndDataProtectionPracticesEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is on => {deadLine}.<br><a href={complianceReportLink}>Grc Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request for sec
                    var req = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit, deadLine);
                    await compliancerepoEmail.AddAsync(req);
                    //log request for im
                    var reqIm = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmitIm, deadLine);
                    await compliancerepoEmail.AddAsync(reqIm);
                    //log request for im
                    var reqTrustee = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmitTrustee, deadLine);
                    await compliancerepoEmail.AddAsync(reqTrustee);
                    //log request for im
                    var reqCP = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmitCP, deadLine);
                    await compliancerepoEmail.AddAsync(reqCP);

                    await compliancerepoEmail.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: req.Id, emailTo: to, toCC: cc);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }


        /// <summary>
        /// Reminder 10th Feb Annual Audit of Privacy and Data Protection Practices Email Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder10AnnualAuditPrivacyAndDataProtectionPracticesEmail()
        {
            try
            {                
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Annual Audit of Privacy and Data Protection Practices" && e.Frequency == "Annually" && e.FirmToSubmit == "ARM Securities").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 2 && requestDate.Day == 10 && requestDate.Hour == 10 && requestDate.Minute == 2)
                {
                    var deadLine = _target15Mar;
                    string nameOfReport = "Annual Audit of Privacy and Data Protection Practices";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualAuditPrivacyAndDataProtectionPracticesEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>Grc Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 15th Feb Annual Audit of Privacy and Data Protection Practices Email Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder15AnnualAuditPrivacyAndDataProtectionPracticesEmail()
        {
            try
            {                              
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Annual Audit of Privacy and Data Protection Practices" && e.Frequency == "Annually" && e.FirmToSubmit == "ARM Securities").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 2 && requestDate.Day == 15 && requestDate.Hour == 10 && requestDate.Minute == 2)
                {
                    var deadLine = _target15Mar;
                    string nameOfReport = "Annual Audit of Privacy and Data Protection Practices";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualAuditPrivacyAndDataProtectionPracticesEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>Grc link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 10th Mar Annual Audit of Privacy and Data Protection Practices Email Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder10MarAnnualAuditPrivacyAndDataProtectionPracticesEmail()
        {
            try
            {
                var reqDate = DateTime.Now.Date;
                var deadLine = _target15Mar;
                if (reqDate.Month == 3 && reqDate.Day == 10 && reqDate.Hour == 9 && reqDate.Hour == 10 && reqDate.Minute == 2 && reqDate.DayOfWeek != DayOfWeek.Saturday && reqDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    string nameOfReport = "Annual Audit of Privacy and Data Protection Practices";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualAuditPrivacyAndDataProtectionPracticesEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>Grc Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 15h Mar Annual Audit of Privacy and Data Protection Practices Email Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task Reminder15MarAnnualAuditPrivacyAndDataProtectionPracticesEmail()
        {
            try
            {
                var reqDate = DateTime.Now;
                var deadLine = _target15Mar;
                if (reqDate.Month == 3 && reqDate.Day == 15 && reqDate.Hour == 12 && reqDate.Minute == 44 && reqDate.DayOfWeek != DayOfWeek.Saturday && reqDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    string nameOfReport = "Annual Audit of Privacy and Data Protection Practices";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualAuditPrivacyAndDataProtectionPracticesEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>Grc Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 1th Feb Annual Audit of Privacy and Data Protection Practices Email Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task AnnualFinancialStatementFRCNEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = compliancerepoEmail.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.Name == "Annual Financial Statements to the FRCN" && e.Frequency == "Annually" && e.FirmToSubmit == "Public Interest Entity").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 2 && requestDate.Day == 2)
                {
                    var deadLine = _target25Mar;
                    string nameOfReport = "Annual Financial Statements to the FRCN";
                    string frequency = "Annually";
                    string firmToSubmit = "Public Interest Entity";
                    string complianceReportLink = config["EmailConfiguration:ComplianceReportLink"];
                    string to = config["EmailConfiguration:AnnualFinancialStatementFRCNEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Kindly send your report for the year in the link below. <br>The deadline is => {deadLine}.<br><a href={complianceReportLink}>Grc Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request for sec
                    var req = ComplianceCalendar.CreateEmail(nameOfReport, frequency, firmToSubmit, deadLine);
                    await compliancerepoEmail.AddAsync(req);

                    await compliancerepoEmail.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: req.Id, emailTo: to, toCC: cc);
                    
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }


        #endregion

        #region Initiate Compliance Payment
        /// <summary>
        /// Reminder 20th Jan Annual Registration Renewal Fee Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task AnnualRegistrationRenewalFeeEmail()
        {
            try
            {
                
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.CreatedOnUtc.Date.Year == requestDate.Year && e.PaymentDetail == "Annual Registration Renewal Fee" && e.MeansOfPaymentAmount == "SEC E-portal/Remita").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 1 && requestDate.Day == 20)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target28Janu,
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "Annual Registration Renewal Fee",
                        BusinessEntity = "ARM Trustee"
                    };
                    var reqARMSec = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target28Janu,
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:CompliancePaymentSecurityEmailTo"],
                        PaymentDetail = "Annual Registration Renewal Fee",
                        BusinessEntity = "ARM Securities"
                    };
                    var reqARMIm = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target28Janu,
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = "Temitope Akinola, Evelyn Nwogu",
                        PaymentDetail = "Annual Registration Renewal Fee",
                        BusinessEntity = "ARM IM"
                    };

                    string nameOfReport = "Annual Registration Renewal Fee";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFinConEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {req.DeadLine},<br> Contact Person => Mohammed Anakwada - anakwada@sec.gov.ng <br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string toSec = config["EmailConfiguration:CompliancePaymentSecurityEmailTo"];
                    string toIm = config["EmailConfiguration:CompliancePaymentARMIMEmailTo"];
                    string messageSec = $"Hello, <br>Kindly see the {reqARMSec.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {req.DeadLine},<br> Contact Person => SEC Registration Dept<br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string messageIm = $"Hello, <br>Kindly see the {reqARMIm.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {req.DeadLine},<br> Contact Person => SEC Registration Dept<br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var logReq = ComplianceRegulatoryPayment.InitiatePayment(req);
                    await complianceRegPayment.AddAsync(logReq);
                    //log request Sec
                    var logReqSec = ComplianceRegulatoryPayment.InitiatePayment(reqARMSec);
                    await complianceRegPayment.AddAsync(logReqSec);
                    //log request IM
                    var logReqIm = ComplianceRegulatoryPayment.InitiatePayment(reqARMIm);
                    await complianceRegPayment.AddAsync(logReqIm);
                    await complianceRegPayment.SaveChangesAsync();

                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: logReq.Id, emailTo: to, toCC: cc);
                    var logEmailRequestSec = await LogEmailRequestAssync(subject: nameOfReport, message: messageSec, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqSec.Id, emailTo: toSec, toCC: cc);
                    var logEmailRequestIM = await LogEmailRequestAssync(subject: nameOfReport, message: messageIm, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqIm.Id, emailTo: toIm, toCC: cc);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        public async Task AnnualRegulatoryFeeEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.CreatedOnUtc.Date.Year == requestDate.Year && e.PaymentDetail == "Annual Regulatory Fee" && e.MeansOfPaymentAmount == "SEC E-portal/Remita").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 1 && requestDate.Day == 20)
                {
                    var reqARMIm = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target28Janu,
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = "Temitope Akinola, Evelyn Nwogu",
                        PaymentDetail = "Annual Regulatory Fee",
                        BusinessEntity = "ARM IM"
                    };
                    var reqSec = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target28Janu,
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = "Temitope Akinola, Evelyn Nwogu",
                        PaymentDetail = "Annual Regulatory Fee",
                        BusinessEntity = "ARM IM"
                    };

                    string nameOfReport = "Annual Regulatory Fee";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string toIm = config["EmailConfiguration:CompliancePaymentARMIMEmailTo"];
                    string toSec = config["EmailConfiguration:ComplianceRegulatoryEmailToCC"];
                    string messageIm = $"Hello All, <br>Kindly see the {reqARMIm.BusinessEntity} payment details.<br> Regulatory body => {reqARMIm.Regulator},<br>Detail => {reqARMIm.PaymentDetail},<br> Means of payment => {reqARMIm.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {reqARMIm.DeadLine},<br> Contact Person => SEC Fund Supervision Dept<br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string messageSec = $"Hello All, <br>Kindly see the {reqSec.BusinessEntity} payment details.<br> Regulatory body => {reqSec.Regulator},<br>Detail => {reqSec.PaymentDetail},<br> Means of payment => {reqSec.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {reqSec.DeadLine},<br> Contact Person => SEC Registration Dept<br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];

                    //log request IM
                    var logReqIm = ComplianceRegulatoryPayment.InitiatePayment(reqARMIm);
                    await complianceRegPayment.AddAsync(logReqIm);
                    await complianceRegPayment.SaveChangesAsync();
                    //log request Sec
                    var logReqSec = ComplianceRegulatoryPayment.InitiatePayment(reqARMIm);
                    await complianceRegPayment.AddAsync(logReqSec);
                    await complianceRegPayment.SaveChangesAsync();
                    var logEmailRequestIM = await LogEmailRequestAssync(subject: nameOfReport, message: messageIm, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqIm.Id, emailTo: toIm, toCC: cc);
                    var logEmailRequestSec = await LogEmailRequestAssync(subject: nameOfReport, message: messageSec, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqSec.Id, emailTo: toSec, toCC: cc);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        public async Task AnnualFilingFeeEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.CreatedOnUtc.Date.Year == requestDate.Year && e.PaymentDetail == "Annual Filing Fee" && e.MeansOfPaymentAmount == "SEC E-portal/Remita").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 1 && requestDate.Day == 20)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target28Janu,
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:CompliancePaymentSecurityEmailTo"],
                        PaymentDetail = "Annual Filing Fee",
                        BusinessEntity = "ARM Securities"
                    };
                    var reqIm = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target28Janu,
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = "Temitope Akinola, Evelyn Nwogu",
                        PaymentDetail = "Annual Filing Fee",
                        BusinessEntity = "ARM IM"
                    };

                    string nameOfReport = "Annual Filing Fee";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string toSec = config["EmailConfiguration:CompliancePaymentSecurityEmailTo"];
                    string toIm = config["EmailConfiguration:CompliancePaymentARMIMEmailTo"];
                    string messageSec = $"Hello, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {req.DeadLine},<br> Contact Person => SEC Registration Dept<br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string messageIm = $"Hello, <br>Kindly see the {reqIm.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {req.DeadLine},<br> Contact Person => SEC Registration Dept<br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request Sec
                    var logReqSec = ComplianceRegulatoryPayment.InitiatePayment(req);
                    await complianceRegPayment.AddAsync(logReqSec);
                    //log request Im
                    var logReqIm = ComplianceRegulatoryPayment.InitiatePayment(reqIm);
                    await complianceRegPayment.AddAsync(logReqIm);
                    await complianceRegPayment.SaveChangesAsync();

                    var logEmailRequestSec = await LogEmailRequestAssync(subject: nameOfReport, message: messageSec, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqSec.Id, emailTo: toSec, toCC: cc);
                    var logEmailRequestIm = await LogEmailRequestAssync(subject: nameOfReport, message: messageIm, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqIm.Id, emailTo: toIm, toCC: cc);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        public async Task ReminderAnnualFilingFeeEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.PaymentDetail == "Annual Filing Fee" && e.MeansOfPaymentAmount == "SEC E-portal/Remita").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 1 && requestDate.Day == 27 && requestDate.Hour == 10 && requestDate.Minute == 2)
                {

                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target28Janu,
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:CompliancePaymentSecurityEmailTo"],
                        PaymentDetail = "Annual Filing Fee",
                        BusinessEntity = "ARM Securities"
                    };
                    var reqIm = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target28Janu,
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = "Temitope Akinola, Evelyn Nwogu",
                        PaymentDetail = "Annual Filing Fee",
                        BusinessEntity = "ARM IM"
                    };

                    string nameOfReport = "Annual Filing Fee";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string to = config["EmailConfiguration:CompliancePaymentSecurityEmailTo"];
                    string toIm = config["EmailConfiguration:CompliancePaymentARMIMEmailTo"];
                    string message = $"Hello, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {req.DeadLine},<br> Contact Person => SEC Registration Dept<br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string messageIm = $"Hello, <br>Kindly see the {reqIm.BusinessEntity} payment details.<br> Regulatory body => {reqIm.Regulator},<br>Detail => {reqIm.PaymentDetail},<br> Means of payment => {reqIm.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {reqIm.DeadLine},<br> Contact Person => SEC Registration Dept<br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                    var result2 = await SendEmailNotificationAsyncV1(nameOfReport, toIm, cc, messageIm, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 27th Jan Annual Registration Renewal Fee Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task ReminderAnnualRegistrationRenewalFeeEmail()
        {
            try
            {
                var date = DateTime.Now;
                if (date.Month == 1 && date.Day == 27 && date.Hour == 7 && date.Minute == 2&& date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target28Janu,
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "Annual Registration Renewal Fee",
                        BusinessEntity = "ARM Trustee"
                    };
                    var reqARMSec = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target28Janu,
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:CompliancePaymentSecurityEmailTo"],
                        PaymentDetail = "Annual Registration Renewal Fee",
                        BusinessEntity = "ARM Securities"
                    };

                    string nameOfReport = "Annual Registration Renewal Fee";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFinConEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello All, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {req.DeadLine},<br> Contact Person => Mohammed Anakwada - anakwada@sec.gov.ng<br>Kindly ignore if this has been treated. <br> Click below link for more detail. <br><a href={complianceReportLink}>Annual Registration Renewal Fee</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    string toSec = config["EmailConfiguration:CompliancePaymentSecurityEmailTo"];
                    string messageSec = $"Hello, <br>Kindly see the {reqARMSec.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {req.DeadLine},<br> Contact Person => SEC Registration Dept<br>Kindly ignore if this has been treated.<br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";

                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                    var result2 = await SendEmailNotificationAsyncV1(nameOfReport, toSec, cc, messageSec, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 21th Jan Annual Subscription Renewal ACT  Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task AnnualSubscriptionRenewalACTEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.CreatedOnUtc.Date.Year == requestDate.Year && e.PaymentDetail == "ANNUAL SUBSCRIPTION RENEWAL" && e.MeansOfPaymentAmount == "Bank transfer").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 1 && requestDate.Day == 20)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "ACT",
                        DeadLine = _target28Janu,
                        MeansOfPaymentAmount = "Bank transfer",
                        Amount = 300000,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "ANNUAL SUBSCRIPTION RENEWAL",
                        BusinessEntity = "ARM Trustee"
                    };
                    var reqIm = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "FMAN",
                        DeadLine = _target28Janu,
                        MeansOfPaymentAmount = "Bank transfer",
                        Amount = 400000,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "ANNUAL SUBSCRIPTION RENEWAL",
                        BusinessEntity = "ARM IM"
                    };
                    string nameOfReport = "ANNUAL SUBSCRIPTION RENEWAL (ACT)";
                    string nameOfReportIm = "ANNUAL SUBSCRIPTION RENEWAL (FMAN)";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFinConEmailTo"];
                    string toIm = config["EmailConfiguration:CompliancePaymentARMIMEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello All, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => N300,000.00,<br> Deadline => {req.DeadLine},<br> Contact Person => Paul Bakare - info@corporatetrustees.org.ng <br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string messageIm = $"Hello, <br>Kindly see the {reqIm.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {reqIm.PaymentDetail},<br> Means of payment => {reqIm.MeansOfPaymentAmount},<br> Amount => N400,000.00,<br> Deadline => {req.DeadLine},<br> Contact Person => Oludare Moses (FMAN) <br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var logReq = ComplianceRegulatoryPayment.InitiatePayment(req);
                    await complianceRegPayment.AddAsync(logReq);
                    //log request Im
                    var logReqIm = ComplianceRegulatoryPayment.InitiatePayment(reqIm);
                    await complianceRegPayment.AddAsync(logReqIm);
                    await complianceRegPayment.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: logReq.Id, emailTo: to, toCC: cc);
                    var logEmailRequestIm = await LogEmailRequestAssync(subject: nameOfReportIm, message: messageIm, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqIm.Id, emailTo: to, toCC: cc);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 27th Jan Annual Subscription Renewal ACT Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task ReminderAnnualSubscriptionRenewalACTEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.PaymentDetail == "ANNUAL SUBSCRIPTION RENEWAL" && e.MeansOfPaymentAmount == "Bank transfer").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 1 && requestDate.Day == 27 && requestDate.Hour == 10 && requestDate.Minute == 2)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "ACT",
                        DeadLine = _target28Janu,
                        MeansOfPaymentAmount = "Bank transfer",
                        Amount = 300000,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "ANNUAL SUBSCRIPTION RENEWAL (ACT)",
                        BusinessEntity = "ARM Trustee"
                    };
                    string nameOfReport = "ANNUAL SUBSCRIPTION RENEWAL (ACT)";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFinConEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello All, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => N300,000.00,<br> Deadline => {req.DeadLine},<br> Contact Person => Paul Bakare - info@corporatetrustees.org.ng <br> Click below link for more detail. <br><a href={complianceReportLink}>Annual Subscription Renewal (ACT)</a>";
                    string filePath = config["EmailConfiguration:filePath"];

                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
                logger.Information("ReminderAnnualSubscriptionRenewalACTEmail: send email for the year");
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 20th March Annual Filing Fee Corporate Governance Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task AnnualFilingFeeCorporateGovernanceEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.CreatedOnUtc.Date.Year == requestDate.Year && e.PaymentDetail == "Annual Filing Fee (Corporate Governance)" && e.MeansOfPaymentAmount == "FRCN E-portal/Remita").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 3 && requestDate.Day == 20)
                {

                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "FRCN",
                        DeadLine = _target28March,
                        MeansOfPaymentAmount = "FRCN E-portal/Remita",
                        Amount = 10000,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "Annual Filing Fee (Corporate Governance)",
                        BusinessEntity = "ARM Trustee"
                    };
                    var reqIm = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "NCCG",
                        DeadLine = _target28March,
                        MeansOfPaymentAmount = "FRCN E-portal/Remita",
                        Amount = 10000,
                        ProcessOfficer = "Temitope, Evelyn",
                        PaymentDetail = "Annual Filing Fee (Corporate Governance) ",
                        BusinessEntity = "ARM IM"
                    };
                    var reqSecurity = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "CSCS",
                        DeadLine = _target28March,
                        MeansOfPaymentAmount = "CSCS Bank account and email notification for confirmation",
                        Amount = 275000,
                        ProcessOfficer = "Temitope, Evelyn",
                        PaymentDetail = "Annual Fees",
                        BusinessEntity = "ARM Securities"
                    };
                    var reqSecurityNASD = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "NASD",
                        DeadLine = _target28March,
                        MeansOfPaymentAmount = "NASD Bank account and email notification for confirmation",
                        Amount = 275000,
                        ProcessOfficer = "Temitope, Evelyn",
                        PaymentDetail = "Annual Fees",
                        BusinessEntity = "ARM Securities"
                    };

                    string nameOfReportSecurity = "Annual Fees";
                    string nameOfReport = "Annual Filing Fee (Corporate Governance)";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFinConEmailTo"];
                    string toIm = config["EmailConfiguration:CompliancePaymentARMIMEmailTo"];
                    string toSec = config["EmailConfiguration:CompliancePaymentSecurityEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello All, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => N10,000,<br> Deadline => {req.DeadLine},<br> Contact Person => FRCN <br> Click below link for more detail.<a href={complianceReportLink}>GRC Link</a>";
                    string messageIm = $"Hello All, <br>Kindly see the {reqIm.BusinessEntity} payment details.<br> Regulatory body => {reqIm.Regulator},<br>Detail => {reqIm.PaymentDetail},<br> Means of payment => {reqIm.MeansOfPaymentAmount},<br> Amount => N10,000,<br> Deadline => {reqIm.DeadLine},<br> Contact Person => FRCN <br> Click below link for more detail.<a href={complianceReportLink}>GRC Link</a>";
                    string messageSec = $"Hello All, <br>Kindly see the {reqSecurity.BusinessEntity} payment details.<br> Regulatory body => {reqSecurity.Regulator},<br>Detail => {reqSecurity.PaymentDetail},<br> Means of payment => {reqSecurity.MeansOfPaymentAmount},<br> Amount => N275,000,<br> Deadline => {reqSecurity.DeadLine},<br> Contact Person => fabba@nasdng.com <br> Click below link for more detail.<a href={complianceReportLink}>GRC Link</a>";
                    string messageSecurityNASD = $"Hello All, <br>Kindly see the {reqSecurityNASD.BusinessEntity} payment details.<br> Regulatory body => {reqSecurityNASD.Regulator},<br>Detail => {reqSecurityNASD.PaymentDetail},<br> Means of payment => {reqSecurityNASD.MeansOfPaymentAmount},<br> Amount => N275,000,<br> Deadline => {reqSecurityNASD.DeadLine},<br> Contact Person => fabba@nasdng.com <br> Click below link for more detail.<a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var logReq = ComplianceRegulatoryPayment.InitiatePayment(req);
                    await complianceRegPayment.AddAsync(logReq);
                    //log request IM
                    var logReqIm = ComplianceRegulatoryPayment.InitiatePayment(reqIm);
                    await complianceRegPayment.AddAsync(logReqIm);
                    await complianceRegPayment.SaveChangesAsync();

                    //log request Securities CSCS
                    var logReqSec = ComplianceRegulatoryPayment.InitiatePayment(reqSecurity);
                    await complianceRegPayment.AddAsync(logReqSec);
                    await complianceRegPayment.SaveChangesAsync();

                    //log request Securities NASD
                    var logReqSecNASD = ComplianceRegulatoryPayment.InitiatePayment(reqSecurityNASD);
                    await complianceRegPayment.AddAsync(logReqSecNASD);
                    await complianceRegPayment.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: logReq.Id, emailTo: to, toCC: cc);
                    var logEmailRequestIm = await LogEmailRequestAssync(subject: nameOfReport, message: messageIm, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqIm.Id, emailTo: toIm, toCC: cc);
                    var logEmailRequestSec = await LogEmailRequestAssync(subject: nameOfReportSecurity, message: messageSec, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqSec.Id, emailTo: toSec, toCC: cc);
                    var logEmailRequestSecNASD = await LogEmailRequestAssync(subject: nameOfReportSecurity, message: messageSecurityNASD, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqSecNASD.Id, emailTo: toSec, toCC: cc);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 27th March Annual Filing Fee Corporate Governance Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task ReminderAnnualFilingFeeCorporateGovernanceEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.PaymentDetail == "Annual Filing Fee (Corporate Governance)" && e.MeansOfPaymentAmount == "FRCN E-portal/Remita").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 3 && requestDate.Day == 27 && requestDate.Hour == 10 && requestDate.Minute == 2)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "FRCN",
                        DeadLine = _target28March,
                        MeansOfPaymentAmount = "FRCN E-portal/Remita",
                        Amount = 10000,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "Annual Filing Fee (Corporate Governance) ",
                        BusinessEntity = "ARM Trustee"
                    };
                    var reqIm = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "NCCG",
                        DeadLine = _target28March,
                        MeansOfPaymentAmount = "FRCN E-portal/Remita",
                        Amount = 10000,
                        ProcessOfficer = "Temitope, Evelyn",
                        PaymentDetail = "Annual Filing Fee (Corporate Governance) ",
                        BusinessEntity = "ARM IM"
                    };
                    string nameOfReport = "Annual Filing Fee (Corporate Governance) ";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFinConEmailTo"];
                    string toIm = config["EmailConfiguration:CompliancePaymentARMIMEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello All, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => N10,000,<br> Deadline => {req.DeadLine},<br> Contact Person => FRCN <br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string messageIm = $"Hello All, <br>Kindly see the {reqIm.BusinessEntity} payment details.<br> Regulatory body => {reqIm.Regulator},<br>Detail => {reqIm.PaymentDetail},<br> Means of payment => {reqIm.MeansOfPaymentAmount},<br> Amount => N10,000,<br> Deadline => {reqIm.DeadLine},<br> Contact Person => FRCN <br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";

                    string filePath = config["EmailConfiguration:filePath"];

                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                    var result2 = await SendEmailNotificationAsyncV1(nameOfReport, toIm, cc, messageIm, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }


        /// <summary>
        /// Reminder 20th March Filing Fee Audited Financial Statemente Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task FilingFeeAuditedFinancialStatementeEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.CreatedOnUtc.Date.Year == requestDate.Year && e.PaymentDetail == "Filing Fee for Audited Financial Statement" && e.MeansOfPaymentAmount == "SEC E-portal/Remita").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 3 && requestDate.Day == 20)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target28March,
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "Filing Fee for Audited Financial Statement",
                        BusinessEntity = "ARM Trustee"
                    };
                    var reqIMCAC = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "CAC",
                        DeadLine = _target28April,
                        MeansOfPaymentAmount = "CAC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = "Temitope Akinola/Evelyn Nwogu",
                        PaymentDetail = "Filing Fee for Audited Financial Statement",
                        BusinessEntity = "ARM IM"
                    };
                    var reqIm = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "FRCN",
                        DeadLine = _target28March,
                        MeansOfPaymentAmount = "FRCN E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = "Temitope Akinola, Evelyn Nwogu",
                        PaymentDetail = "Filing Fee for Audited Financial Statement",
                        BusinessEntity = "ARM IM"
                    };
                    string nameOfReport = "Filing Fee for Audited Financial Statement";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFinConEmailTo"];
                    string toIm = config["EmailConfiguration:CompliancePaymentARMIMEmailTo"];
                    string toImCAC = config["EmailConfiguration:CompliancePaymentARMIMEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello All, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {req.DeadLine},<br> Contact Person => FRCN <br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string messageIm = $"Hello All, <br>Kindly see the {reqIm.BusinessEntity} payment details.<br> Regulatory body => {reqIm.Regulator},<br>Detail => {reqIm.PaymentDetail},<br> Means of payment => {reqIm.MeansOfPaymentAmount},<br> Amount => As prescribed by FRCN,<br> Deadline => {reqIm.DeadLine},<br> Contact Person => FRCN <br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string messageImCAC = $"Hello All, <br>Kindly see the {reqIMCAC.BusinessEntity} payment details.<br> Regulatory body => {reqIMCAC.Regulator},<br>Detail => {reqIMCAC.PaymentDetail},<br> Means of payment => {reqIMCAC.MeansOfPaymentAmount},<br> Amount => As prescribed by CAC,<br> Deadline => {reqIMCAC.DeadLine},<br> Contact Person => FRCN <br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var logReq = ComplianceRegulatoryPayment.InitiatePayment(req);
                    await complianceRegPayment.AddAsync(logReq);
                    //log IM request
                    var logReqIM = ComplianceRegulatoryPayment.InitiatePayment(reqIm);
                    await complianceRegPayment.AddAsync(logReqIM);
                    //log IM CAC request
                    var logReqIMCAC = ComplianceRegulatoryPayment.InitiatePayment(reqIMCAC);
                    await complianceRegPayment.AddAsync(logReqIMCAC);
                    await complianceRegPayment.SaveChangesAsync();

                    //SendRiskMgtUnitEmail.SendRiskMgtUnitEmailAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: logReq.Id, emailTo: to, toCC: cc);
                    var logEmailIM = await LogEmailRequestAssync(subject: nameOfReport, message: messageIm, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqIM.Id, emailTo: toIm, toCC: cc);
                    var logEmailIMCAC = await LogEmailRequestAssync(subject: nameOfReport, message: messageImCAC, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqIMCAC.Id, emailTo: toImCAC, toCC: cc);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// Reminder 20th March Publication Of AFS Mutual Funds Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task PublicationOfAFSMutualFundsEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.CreatedOnUtc.Date.Year == requestDate.Year && e.PaymentDetail == "Newspaper Publication" && e.MeansOfPaymentAmount == "Newspaper Houses").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 3 && requestDate.Day == 20)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "Newspaper Publication",
                        DeadLine = _target28March,
                        MeansOfPaymentAmount = "Newspaper Houses",
                        Amount = 0,
                        ProcessOfficer = "Oluwatobi Oyebiyi, Patrick Ayele",
                        PaymentDetail = "Newspaper Publication",
                        BusinessEntity = "ARM IM"
                    };

                    string nameOfReport = "Newspaper Publication";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:PublicationOfAFSMutualFundsEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello All, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by Newspaper Houses,<br> Deadline => {req.DeadLine},<br> Contact Person => FRCN <br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var logReq = ComplianceRegulatoryPayment.InitiatePayment(req);
                    await complianceRegPayment.AddAsync(logReq);
                    await complianceRegPayment.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: logReq.Id, emailTo: to, toCC: cc);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }


        /// <summary>
        /// Reminder 27th March Filing Fee Audited Financial Statemente Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task ReminderFilingFeeAuditedFinancialStatementeEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.PaymentDetail == "Filing Fee for Audited Financial Statement" && e.MeansOfPaymentAmount == "SEC E-portal/Remita").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 3 && requestDate.Day == 27 && requestDate.Hour == 10 && requestDate.Minute == 2)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target28March,
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "Filing Fee for Audited Financial Statement",
                        BusinessEntity = "ARM Trustee"
                    };
                    string nameOfReport = "Filing Fee for Audited Financial Statement";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFinConEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello All, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {req.DeadLine},<br> Contact Person => FRCN <br> Click below link for more detail. <br><a href={complianceReportLink}>Filing Fee for Audited Financial Statemente</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 20th April Filing Fee Audited Financial Statemente Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task FilingFeeAuditedFinancialStatementeCACEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.CreatedOnUtc.Date.Year == requestDate.Year && e.PaymentDetail == "Filing Fee for Audited Financial Statement - CAC" && e.MeansOfPaymentAmount == "CAC E-portal/Remita").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 4 && requestDate.Day == 20)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "CAC",
                        DeadLine = _target28April,
                        MeansOfPaymentAmount = "CAC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "Filing Fee for Audited Financial Statement - CAC",
                        BusinessEntity = "ARM Trustee"
                    };
                    string nameOfReport = "Filing Fee for Audited Financial Statement - CAC";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFinConEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello All, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by CAC,<br> Deadline => {req.DeadLine},<br> Contact Person => FRCN <br> Click below link for more detail. <br><a href={complianceReportLink}>Filing Fee for Audited Financial Statemente - CAC</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var logReq = ComplianceRegulatoryPayment.InitiatePayment(req);
                    await complianceRegPayment.AddAsync(logReq);
                    await complianceRegPayment.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: logReq.Id, emailTo: to, toCC: cc);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 20th March Filing Fee Audited Financial Statemente Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task ReminderFilingFeeAuditedFinancialStatementeCACEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.PaymentDetail == "Filing Fee for Audited Financial Statement - CAC" && e.MeansOfPaymentAmount == "CAC E-portal/Remita").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 4 && requestDate.Day == 27 && requestDate.Hour == 10 && requestDate.Minute == 2)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "CAC",
                        DeadLine = _target28April,
                        MeansOfPaymentAmount = "CAC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "Filing Fee for Audited Financial Statement - CAC",
                        BusinessEntity = "ARM Trustee"
                    };
                    string nameOfReport = "Filing Fee for Audited Financial Statement - CAC";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFinConEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello All, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by CAC,<br> Deadline => {req.DeadLine},<br> Contact Person => FRCN <br> Click below link for more detail. <br><a href={complianceReportLink}>Filing Fee for Audited Financial Statemente - CAC</a>";
                    string filePath = config["EmailConfiguration:filePath"];

                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 5th Dec Fidelity Bond Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task FidelityBondEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.CreatedOnUtc.Date.Year == requestDate.Year && e.PaymentDetail == "Fidelity Bond" && e.MeansOfPaymentAmount == "HCM will pay Insurance Broker").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 12 && requestDate.Day == 4)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "Custodian & Allied Insurance",
                        DeadLine = _target10Dec,
                        MeansOfPaymentAmount = "HCM will pay Insurance Broker",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFidelityBondEmailTo"],
                        PaymentDetail = "Fidelity Bond",
                        BusinessEntity = "ARM Trustee"
                    };
                    var reqIM = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "Custodian & Allied Insurance",
                        DeadLine = _target10Dec,
                        MeansOfPaymentAmount = "HCM will pay Insurance Broker",
                        Amount = 0,
                        ProcessOfficer = "Jide Adeleke",
                        PaymentDetail = "Fidelity Bond",
                        BusinessEntity = "ARM IM"
                    };
                    var reqSec = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "Custodian & Allied Insurance",
                        DeadLine = _target10Dec,
                        MeansOfPaymentAmount = "HCM will pay Insurance Broker",
                        Amount = 0,
                        ProcessOfficer = "Jide Adeleke",
                        PaymentDetail = "Fidelity Bond",
                        BusinessEntity = "ARM Securities"
                    };
                    string nameOfReport = "Fidelity Bond";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFidelityBondEmailTo"];
                    string toIM = config["EmailConfiguration:ARMSEcurityInsurranceRegulatoryEmailTo"];
                    string toSec = config["EmailConfiguration:ARMSecurityFidelityBondEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello HCM, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by HCM,<br> Deadline => {req.DeadLine},<br> Contact Person => Jide Adeleke - jadeleke@custodianinsurance.com <br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string messageIM = $"Hello HCM, <br>Kindly see the {reqIM.BusinessEntity} payment details.<br> Regulatory body => {reqIM.Regulator},<br>Detail => {reqIM.PaymentDetail},<br> Means of payment => {reqIM.MeansOfPaymentAmount},<br> Amount => As prescribed by HCM,<br> Deadline => {reqIM.DeadLine},<br> Contact Person => Jide Adeleke - jadeleke@custodianinsurance.com <br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string messageSec = $"Hello HCM, <br>Kindly see the {reqSec.BusinessEntity} payment details.<br> Regulatory body => {reqSec.Regulator},<br>Detail => {reqSec.PaymentDetail},<br> Means of payment => {reqSec.MeansOfPaymentAmount},<br> Amount => As prescribed by HCM,<br> Deadline => {reqSec.DeadLine},<br> Contact Person => Jide Adeleke - jadeleke@custodianinsurance.com <br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var logReq = ComplianceRegulatoryPayment.InitiatePayment(req);
                    await complianceRegPayment.AddAsync(logReq);
                    //log IM request
                    var logReqIM = ComplianceRegulatoryPayment.InitiatePayment(reqIM);
                    await complianceRegPayment.AddAsync(logReqIM);
                    await complianceRegPayment.SaveChangesAsync();

                    //log Sec request
                    var logReqSec = ComplianceRegulatoryPayment.InitiatePayment(reqSec);
                    await complianceRegPayment.AddAsync(logReqSec);
                    await complianceRegPayment.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: logReq.Id, emailTo: to, toCC: cc);
                    var logEmailRequestIM = await LogEmailRequestAssync(subject: nameOfReport, message: messageIM, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqIM.Id, emailTo: toIM, toCC: cc);
                    var logEmailRequestSec = await LogEmailRequestAssync(subject: nameOfReport, message: messageSec, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqSec.Id, emailTo: toSec, toCC: cc);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 9th Dec Fidelity Bond Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task ReminderFidelityBondEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.PaymentDetail == "Fidelity Bond" && e.MeansOfPaymentAmount == "HCM will pay Insurance Broker").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 12 && requestDate.Day == 10 && requestDate.Hour == 10 && requestDate.Minute == 2)
                {

                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "Custodian & Allied Insurance",
                        DeadLine = _target10Dec,
                        MeansOfPaymentAmount = "HCM will pay Insurance Broker",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFidelityBondEmailTo"],
                        PaymentDetail = "Fidelity Bond",
                        BusinessEntity = "ARM Trustee"
                    };
                    string nameOfReport = "Fidelity Bond";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFidelityBondEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello HCM, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by HCM,<br> Deadline => {req.DeadLine},<br> Contact Person => Jide Adeleke - jadeleke@custodianinsurance.com <br> Click below link for more detail. <br><a href={complianceReportLink}>Fidelity Bond</a>";
                    string filePath = config["EmailConfiguration:filePath"];

                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 20th Feb Director Liability Insurance Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task DirectorLiabilityInsuranceEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.CreatedOnUtc.Date.Year == requestDate.Year && e.PaymentDetail == "Director's Liability Insurance" && e.MeansOfPaymentAmount == "HCM will pay Insurance Broker").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 2 && requestDate.Day == 20)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "Custodian & Allied Insurance",
                        DeadLine = _target20Feb.AddDays(5),
                        MeansOfPaymentAmount = "HCM will pay Insurance Broker",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFidelityBondEmailTo"],
                        PaymentDetail = "Director's Liability Insurance",
                        BusinessEntity = "ARM Trustee"
                    };
                    var reqIM = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "Custodian & Allied Insurance",
                        DeadLine = _target20Feb.AddDays(5),
                        MeansOfPaymentAmount = "HCM will pay Insurance Broker",
                        Amount = 0,
                        ProcessOfficer = "Jide Adeleke",
                        PaymentDetail = "Director's Liability Insurance",
                        BusinessEntity = "ARM IM"
                    };
                    var reqSec = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "Custodian & Allied Insurance",
                        DeadLine = _target20Feb.AddDays(5),
                        MeansOfPaymentAmount = "HCM will pay Insurance Broker",
                        Amount = 0,
                        ProcessOfficer = "Jide Adeleke",
                        PaymentDetail = "Director's Liability Insurance",
                        BusinessEntity = "ARM Securities"
                    };
                    string nameOfReport = "Director's Liability Insurance";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFidelityBondEmailTo"];
                    string toIM = config["EmailConfiguration:ARMCPInsurranceRegulatoryEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello HCM, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by HCM,<br> Deadline => {req.DeadLine},<br> Contact Person => Jide Adeleke - jadeleke@custodianinsurance.com <br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string messageIM = $"Hello HCM, <br>Kindly see the {reqIM.BusinessEntity} payment details.<br> Regulatory body => {reqIM.Regulator},<br>Detail => {reqIM.PaymentDetail},<br> Means of payment => {reqIM.MeansOfPaymentAmount},<br> Amount => As prescribed by HCM,<br> Deadline => {reqIM.DeadLine},<br> Contact Person => Jide Adeleke - jadeleke@custodianinsurance.com <br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string messageSec = $"Hello HCM, <br>Kindly see the {reqSec.BusinessEntity} payment details.<br> Regulatory body => {reqSec.Regulator},<br>Detail => {reqSec.PaymentDetail},<br> Means of payment => {reqSec.MeansOfPaymentAmount},<br> Amount => As prescribed by HCM,<br> Deadline => {reqSec.DeadLine},<br> Contact Person => Jide Adeleke - jadeleke@custodianinsurance.com <br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var logReq = ComplianceRegulatoryPayment.InitiatePayment(req);
                    await complianceRegPayment.AddAsync(logReq);
                    //log IMrequest
                    var logReqIM = ComplianceRegulatoryPayment.InitiatePayment(reqIM);
                    await complianceRegPayment.AddAsync(logReqIM);
                    await complianceRegPayment.SaveChangesAsync();
                    //log  Sec request
                    var logReqSec = ComplianceRegulatoryPayment.InitiatePayment(reqSec);
                    await complianceRegPayment.AddAsync(logReqSec);
                    await complianceRegPayment.SaveChangesAsync();

                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: logReq.Id, emailTo: to, toCC: cc);
                    var logEmailRequestIM = await LogEmailRequestAssync(subject: nameOfReport, message: messageIM, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqIM.Id, emailTo: toIM, toCC: cc);
                    var logEmailRequestSec = await LogEmailRequestAssync(subject: nameOfReport, message: messageSec, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqSec.Id, emailTo: toIM, toCC: cc);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 24th Feb Director Liability Insurance Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task ReminderDirectorLiabilityInsuranceEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.PaymentDetail == "Director's Liability Insurance" && e.MeansOfPaymentAmount == "HCM will pay Insurance Broker").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 2 && requestDate.Day == 27 && requestDate.Hour == 10 && requestDate.Minute == 2)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "Custodian & Allied Insurance",
                        DeadLine = _target20Feb.AddDays(5),
                        MeansOfPaymentAmount = "HCM will pay Insurance Broker",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFidelityBondEmailTo"],
                        PaymentDetail = "Director's Liability Insurance",
                        BusinessEntity = "ARM Trustee"
                    };
                    string nameOfReport = "Director's Liability Insurance";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFidelityBondEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello HCM, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by HCM,<br> Deadline => {req.DeadLine},<br> Contact Person => Jide Adeleke - jadeleke@custodianinsurance.com <br> Click below link for more detail. <br><a href={complianceReportLink}>Director's Liability Insurance</a>";
                    string filePath = config["EmailConfiguration:filePath"];

                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 20th June Accuity License Renewal Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task AccuityLicenseRenewalEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.CreatedOnUtc.Date.Year == requestDate.Year && e.PaymentDetail == "Accuity License Renewal" && e.MeansOfPaymentAmount == "Wire Transfer").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 6 && requestDate.Day == 20)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "LexisNexis",
                        DeadLine = _target28June,
                        MeansOfPaymentAmount = "Wire Transfer",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFidelityBondEmailTo"],
                        PaymentDetail = "Accuity License Renewal",
                        BusinessEntity = "ARM Trustee"
                    };
                    var reqIM = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SYSTEMS and APP SUBSCRIPTIONS",
                        DeadLine = _target28June,
                        MeansOfPaymentAmount = "Wire Transfer",
                        Amount = 0,
                        ProcessOfficer = "Fincon or Treasury",
                        PaymentDetail = "Accuity License Renewal",
                        BusinessEntity = "ARM IM"
                    };
                    var reqSec = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SYSTEMS and APP SUBSCRIPTIONS",
                        DeadLine = _target28June,
                        MeansOfPaymentAmount = "Wire Transfer",
                        Amount = 0,
                        ProcessOfficer = "Fincon or Treasury",
                        PaymentDetail = "Accuity License Renewal",
                        BusinessEntity = "ARM Securities"
                    };
                    string nameOfReport = "Accuity License Renewal";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFidelityBondEmailTo"];
                    string toIM = config["EmailConfiguration:AccuityLicenseRenewalIMEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello All, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by FinCon/Treasury,<br> Deadline => {req.DeadLine},<br> Contact Person => FinCon/Treasury <br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string messageIM = $"Hello All, <br>Kindly see the {reqIM.BusinessEntity} payment details.<br> Regulatory body => {reqIM.Regulator},<br>Detail => {reqIM.PaymentDetail},<br> Means of payment => {reqIM.MeansOfPaymentAmount},<br> Amount => As prescribed by FinCon/Treasury,<br> Deadline => {req.DeadLine},<br> Contact Person => FinCon/Treasury <br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string messageSec = $"Hello All, <br>Kindly see the {reqSec.BusinessEntity} payment details.<br> Regulatory body => {reqSec.Regulator},<br>Detail => {reqSec.PaymentDetail},<br> Means of payment => {reqSec.MeansOfPaymentAmount},<br> Amount => $5,000,<br> Deadline => {reqSec.DeadLine},<br> Contact Person => FinCon/Treasury <br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var logReq = ComplianceRegulatoryPayment.InitiatePayment(req);
                    await complianceRegPayment.AddAsync(logReq);

                    var logReqIM = ComplianceRegulatoryPayment.InitiatePayment(reqIM);
                    await complianceRegPayment.AddAsync(logReqIM);
                    await complianceRegPayment.SaveChangesAsync();

                    var logReqSec = ComplianceRegulatoryPayment.InitiatePayment(reqSec);
                    await complianceRegPayment.AddAsync(logReqSec);
                    await complianceRegPayment.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: logReq.Id, emailTo: to, toCC: cc);
                    var logEmailRequestIM = await LogEmailRequestAssync(subject: nameOfReport, message: messageIM, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqIM.Id, emailTo: toIM, toCC: cc);
                    var logEmailRequestSec = await LogEmailRequestAssync(subject: nameOfReport, message: messageSec, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqSec.Id, emailTo: toIM, toCC: cc);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 27th June Accuity License Renewal Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task ReminderAccuityLicenseRenewalEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.PaymentDetail == "Accuity License Renewal" && e.MeansOfPaymentAmount == "Wire Transfer").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 6 && requestDate.Day == 27 && requestDate.Hour == 10 && requestDate.Minute == 2)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "LexisNexis",
                        DeadLine = _target28June,
                        MeansOfPaymentAmount = "Wire Transfer",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFidelityBondEmailTo"],
                        PaymentDetail = "Accuity License Renewal",
                        BusinessEntity = "ARM Trustee"
                    };
                    var reqIM = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SYSTEMS and APP SUBSCRIPTIONS",
                        DeadLine = _target28June,
                        MeansOfPaymentAmount = "Wire Transfer",
                        Amount = 0,
                        ProcessOfficer = "Fincon or Treasury",
                        PaymentDetail = "Accuity License Renewal",
                        BusinessEntity = "ARM IM"
                    };
                    string nameOfReport = "Accuity License Renewal";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFidelityBondEmailTo"];
                    string toIM = config["EmailConfiguration:AccuityLicenseRenewalIMEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by FinCon/Treasury,<br> Deadline => {req.DeadLine},<br> Contact Person => FinCon/Treasury <br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string messageIM = $"Hello, <br>Kindly see the {reqIM.BusinessEntity} payment details.<br> Regulatory body => {reqIM.Regulator},<br>Detail => {reqIM.PaymentDetail},<br> Means of payment => {reqIM.MeansOfPaymentAmount},<br> Amount => As prescribed by FinCon/Treasury,<br> Deadline => {reqIM.DeadLine},<br> Contact Person => FinCon/Treasury <br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];

                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                    var result2 = await SendEmailNotificationAsyncV1(nameOfReport, toIM, cc, messageIM, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 20th March Annual Filing Fee Corporate Governance NCC Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task AnnualFilingFeeCorporateGovernanceNCCGEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.CreatedOnUtc.Date.Year == requestDate.Year && e.PaymentDetail == "Annual Filing Fee (Corporate Governance) - NCCG" && e.MeansOfPaymentAmount == "FRCN E-portal/Remita").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 3 && requestDate.Day == 20)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "NCCG",
                        DeadLine = _target28March,
                        MeansOfPaymentAmount = "FRCN E-portal/Remita",
                        Amount = 10000,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFidelityBondEmailTo"],
                        PaymentDetail = "Annual Filing Fee (Corporate Governance) - NCCG",
                        BusinessEntity = "ARM Trustee"
                    };

                    var reqSecNCCG = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "NCCG",
                        DeadLine = _target28March,
                        MeansOfPaymentAmount = "FRCN E-portal/Remita",
                        Amount = 10000,
                        ProcessOfficer = "Kingsley Ottah",
                        PaymentDetail = "Annual Filing Fee (Corporate Governance) - NCCG",
                        BusinessEntity = "ARM Securities"
                    };

                    var reqSecFMDQ = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "FMDQ",
                        DeadLine = _target28March,
                        MeansOfPaymentAmount = "FMDQ Bank Account and email notification for confirmation",
                        Amount = 336000,
                        ProcessOfficer = "Kingsley Ottah",
                        PaymentDetail = "Annual Subscription for our Associate Membership",
                        BusinessEntity = "ARM Securities"
                    };
                    var reqSecFMDQPrivate = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "FMDQ",
                        DeadLine = _target28March,
                        MeansOfPaymentAmount = "FMDQ Bank Account and email notification for confirmation",
                        Amount = 1800000,
                        ProcessOfficer = "Kingsley Ottah",
                        PaymentDetail = "FMDQ Private Markets Transaction Sponsorship Eligibility Fee and Annual Sponsorship Due",
                        BusinessEntity = "ARM Securities"
                    };
                    var reqSecFMDQRenewal = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "FMDQ",
                        DeadLine = _target28March,
                        MeansOfPaymentAmount = "FMDQ Bank Account and email notification for confirmation",
                        Amount = 25000,
                        ProcessOfficer = "Kingsley Ottah",
                        PaymentDetail = "Renewal of eligibility fee for participant",
                        BusinessEntity = "ARM Securities"
                    };
                    var reqSecFMDQAnnual = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "FMDQ",
                        DeadLine = _target28March,
                        MeansOfPaymentAmount = "FMDQ Bank Account and email notification for confirmation",
                        Amount = 750000,
                        ProcessOfficer = "Kingsley Ottah",
                        PaymentDetail = " Annual subscription fees",
                        BusinessEntity = "ARM Securities"
                    };

                    string nameOfReportFMDQAnnual = " Annual subscription fees";
                    string nameOfReportFMDQ = "Annual Subscription for our Associate Membership";
                    string nameOfReportPrivate = "FMDQ Private Markets Transaction Sponsorship Eligibility Fee and Annual Sponsorship Due";
                    string nameOfReportRenewal = "Renewal of eligibility fee for participant";
                    string nameOfReport = "Annual Filing Fee (Corporate Governance) - NCCG";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFidelityBondEmailTo"];
                    string toSec = config["EmailConfiguration:ComplianceRegulatoryEmailToCC"];
                    string toSecFMDQ = config["EmailConfiguration:CompliancePaymentSecurityEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => N10,000,<br> Deadline => {req.DeadLine},<br> Contact Person => FRCN<br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string messageSec = $"Hello Kingsley, <br>Kindly see the {reqSecNCCG.BusinessEntity} payment details.<br> Regulatory body => {reqSecNCCG.Regulator},<br>Detail => {reqSecNCCG.PaymentDetail},<br> Means of payment => {reqSecNCCG.MeansOfPaymentAmount},<br> Amount => N10,000,<br> Deadline => {reqSecNCCG.DeadLine},<br> Contact Person => FRCN<br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string messageSecFMDQ = $"Hello Kingsley, <br>Kindly see the {reqSecFMDQ.BusinessEntity} payment details.<br> Regulatory body => {reqSecFMDQ.Regulator},<br>Detail => {reqSecFMDQ.PaymentDetail},<br> Means of payment => {reqSecFMDQ.MeansOfPaymentAmount},<br> Amount => N336,000.00,<br> Deadline => {reqSecFMDQ.DeadLine},<br> Contact Person => mbg@fmdqgroup.com<br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string messageSecFMDQPrivate = $"Hello All, <br>Kindly see the {reqSecFMDQPrivate.BusinessEntity} payment details.<br> Regulatory body => {reqSecFMDQPrivate.Regulator},<br>Detail => {reqSecFMDQPrivate.PaymentDetail},<br> Means of payment => {reqSecFMDQPrivate.MeansOfPaymentAmount},<br> Amount => N1,800,000.00,<br> Deadline => {reqSecFMDQPrivate.DeadLine},<br> Contact Person => Adanna Onuigbo - Adanna.Onuigbo@fmdqgroup.com <br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string messageSecFMDQRenewal = $"Hello All, <br>Kindly see the {reqSecFMDQRenewal.BusinessEntity} payment details.<br> Regulatory body => {reqSecFMDQRenewal.Regulator},<br>Detail => {reqSecFMDQRenewal.PaymentDetail},<br> Means of payment => {reqSecFMDQRenewal.MeansOfPaymentAmount},<br> Amount => N25,000.00,<br> Deadline => {reqSecFMDQRenewal.DeadLine},<br> Contact Person => dsd@fmdqgroup.com <br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string messageSecFMDQAnnual = $"Hello All, <br>Kindly see the {reqSecFMDQAnnual.BusinessEntity} payment details.<br> Regulatory body => {reqSecFMDQAnnual.Regulator},<br>Detail => {reqSecFMDQAnnual.PaymentDetail},<br> Means of payment => {reqSecFMDQAnnual.MeansOfPaymentAmount},<br> Amount => N750,000.00,<br> Deadline => {reqSecFMDQAnnual.DeadLine},<br> Contact Person => Adanna Onuigbo <Adanna.Onuigbo@fmdqgroup.com> <br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var logReq = ComplianceRegulatoryPayment.InitiatePayment(req);
                    await complianceRegPayment.AddAsync(logReq);
                    await complianceRegPayment.SaveChangesAsync();

                    //log request Sec
                    var logReqSec = ComplianceRegulatoryPayment.InitiatePayment(reqSecNCCG);
                    await complianceRegPayment.AddAsync(logReqSec);
                    await complianceRegPayment.SaveChangesAsync();
                    //log request Sec FMDQ
                    var logReqSecFMDQ = ComplianceRegulatoryPayment.InitiatePayment(reqSecFMDQ);
                    await complianceRegPayment.AddAsync(logReqSecFMDQ);
                    await complianceRegPayment.SaveChangesAsync();
                    //log request Sec FMDQ private
                    var logReqSecFMDQPrivate = ComplianceRegulatoryPayment.InitiatePayment(reqSecFMDQPrivate);
                    await complianceRegPayment.AddAsync(logReqSecFMDQPrivate);
                    await complianceRegPayment.SaveChangesAsync();
                    //log request Sec FMDQ renewal
                    var logReqSecFMDQRenewal = ComplianceRegulatoryPayment.InitiatePayment(reqSecFMDQRenewal);
                    await complianceRegPayment.AddAsync(logReqSecFMDQRenewal);
                    await complianceRegPayment.SaveChangesAsync();
                    //log request Sec FMDQ annual
                    var logReqSecFMDQAnnual = ComplianceRegulatoryPayment.InitiatePayment(reqSecFMDQAnnual);
                    await complianceRegPayment.AddAsync(logReqSecFMDQRenewal);
                    await complianceRegPayment.SaveChangesAsync();

                    //SendRiskMgtUnitEmail.SendRiskMgtUnitEmailAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: logReq.Id, emailTo: to, toCC: cc);
                    var logEmailRequestSec = await LogEmailRequestAssync(subject: nameOfReport, message: messageSec, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqSec.Id, emailTo: toSec, toCC: cc);
                    var logEmailRequestFMDQ = await LogEmailRequestAssync(subject: nameOfReportFMDQ, message: messageSecFMDQ, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqSecFMDQ.Id, emailTo: toSec, toCC: cc);
                    var logEmailRequestFMDQPrivate = await LogEmailRequestAssync(subject: nameOfReportPrivate, message: messageSecFMDQPrivate, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqSecFMDQPrivate.Id, emailTo: toSecFMDQ, toCC: cc);
                    var logEmailRequestFMDQRenewal = await LogEmailRequestAssync(subject: nameOfReportRenewal, message: messageSecFMDQRenewal, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqSecFMDQRenewal.Id, emailTo: toSecFMDQ, toCC: cc);
                    var logEmailRequestFMDQAnnual = await LogEmailRequestAssync(subject: nameOfReportFMDQAnnual, message: messageSecFMDQAnnual, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqSecFMDQAnnual.Id, emailTo: toSecFMDQ, toCC: cc);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Reminder 27th March Annual Filing Fee Corporate Governance NCC Send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task ReminderAnnualFilingFeeCorporateGovernanceNCCGEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.PaymentDetail == "Annual Filing Fee (Corporate Governance) - NCCG" && e.MeansOfPaymentAmount == "FRCN E-portal/Remita").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 3 && requestDate.Day == 27 && requestDate.Hour == 10 && requestDate.Minute == 2)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "NCCG",
                        DeadLine = _target28March,
                        MeansOfPaymentAmount = "FRCN E-portal/Remita",
                        Amount = 10000,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFidelityBondEmailTo"],
                        PaymentDetail = "Annual Filing Fee (Corporate Governance) - NCCG",
                        BusinessEntity = "ARM Trustee"
                    };
                    string nameOfReport = "Annual Filing Fee (Corporate Governance) - NCCG";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFidelityBondEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => N10,000,<br> Deadline => {req.DeadLine},<br> Contact Person => FRCN<br> Click below link for more detail. <br><a href={complianceReportLink}>Annual Filing Fee Corporate Governance - NCCG</a>";
                    string filePath = config["EmailConfiguration:filePath"];

                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }


        public async Task FilingFeeAuditedFinancialStatementFRCNEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.CreatedOnUtc.Date.Year == requestDate.Year && e.PaymentDetail == "Filing Fee for Audited Financial Statement - FRCN" && e.MeansOfPaymentAmount == "FRCN E-portal/Remita").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 3 && requestDate.Day == 20)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "FRCN",
                        DeadLine = _target28March,
                        MeansOfPaymentAmount = "FRCN E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:FilingFeeAuditedFinancialStatementFRCNEmailTo"],
                        PaymentDetail = "Filing Fee for Audited Financial Statement - FRCN",
                        BusinessEntity = "ARM Trustee"
                    };

                    var reqSec = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "FRCN",
                        DeadLine = _target28March,
                        MeansOfPaymentAmount = "FRCN E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = "Kingsley Ottah",
                        PaymentDetail = "Filing Fee for Audited Financial Statement - FRCN",
                        BusinessEntity = "ARM Securities"
                    };
                    string nameOfReport = "Filing Fee for Audited Financial Statement - FRCN";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:FilingFeeAuditedFinancialStatementFRCNEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello All, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by FRCN <br> Deadline => {req.DeadLine},<br> Contact Person => FRCN<br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string messageSec = $"Hello Kingsley, <br>Kindly see the {reqSec.BusinessEntity} payment details.<br> Regulatory body => {reqSec.Regulator},<br>Detail => {reqSec.PaymentDetail},<br> Means of payment => {reqSec.MeansOfPaymentAmount},<br> Amount => As prescribed by FRCN <br> Deadline => {reqSec.DeadLine},<br> Contact Person => FRCN<br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var logReq = ComplianceRegulatoryPayment.InitiatePayment(req);
                    await complianceRegPayment.AddAsync(logReq);
                    await complianceRegPayment.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: logReq.Id, emailTo: to, toCC: cc);
                    
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }


        public async Task ReminderFilingFeeAuditedFinancialStatementFRCNEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.PaymentDetail == "Filing Fee for Audited Financial Statement - FRCN" && e.MeansOfPaymentAmount == "FRCN E-portal/Remita").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 3 && requestDate.Day == 27 && requestDate.Hour == 10 && requestDate.Minute == 2)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "FRCN",
                        DeadLine = _target28March,
                        MeansOfPaymentAmount = "FRCN E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:FilingFeeAuditedFinancialStatementFRCNEmailTo"],
                        PaymentDetail = "Filing Fee for Audited Financial Statement - FRCN",
                        BusinessEntity = "ARM Trustee"
                    };
                    string nameOfReport = "Filing Fee for Audited Financial Statement - FRCN";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:FilingFeeAuditedFinancialStatementFRCNEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by FRCN <br> Deadline => {req.DeadLine},<br> Contact Person => FRCN<br>Kindly ignore if this has been treated.<br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];

                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }


        public async Task FilingFeeAuditedFinancialStatementCACEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.CreatedOnUtc.Date.Year == requestDate.Year && e.PaymentDetail == "Filing Fee for Audited Financial Statement - CAC" && e.MeansOfPaymentAmount == "CAC E-portal/Remita").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 4 && requestDate.Day == 20)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "CAC",
                        DeadLine = _target28April,
                        MeansOfPaymentAmount = "CAC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:FilingFeeAuditedFinancialStatementFRCNEmailTo"],
                        PaymentDetail = "Filing Fee for Audited Financial Statement - CAC",
                        BusinessEntity = "ARM Trustee"
                    };
                    var reqSec = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "CAC",
                        DeadLine = _target28April,
                        MeansOfPaymentAmount = "CAC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = "Kingsley Ottah",
                        PaymentDetail = "Filing Fee for Audited Financial Statement - CAC",
                        BusinessEntity = "ARM Securities"
                    };
                    string nameOfReport = "Filing Fee for Audited Financial Statement - CAC";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:FilingFeeAuditedFinancialStatementFRCNEmailTo"];
                    string toSec = config["EmailConfiguration:ComplianceRegulatoryEmailToCC"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello FRCN, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by CAC <br> Deadline => {req.DeadLine},<br> Contact Person => FRCN<br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string messageSec = $"Hello FRCN, <br>Kindly see the {reqSec.BusinessEntity} payment details.<br> Regulatory body => {reqSec.Regulator},<br>Detail => {reqSec.PaymentDetail},<br> Means of payment => {reqSec.MeansOfPaymentAmount},<br> Amount => As prescribed by CAC <br> Deadline => {reqSec.DeadLine},<br> Contact Person => FRCN<br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var logReq = ComplianceRegulatoryPayment.InitiatePayment(req);
                    await complianceRegPayment.AddAsync(logReq);
                    await complianceRegPayment.SaveChangesAsync();

                    //log request Sec
                    var logReqSec = ComplianceRegulatoryPayment.InitiatePayment(reqSec);
                    await complianceRegPayment.AddAsync(logReqSec);
                    await complianceRegPayment.SaveChangesAsync();

                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: logReq.Id, emailTo: to, toCC: cc);
                    var logEmailRequestSec = await LogEmailRequestAssync(subject: nameOfReport, message: messageSec, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqSec.Id, emailTo: toSec, toCC: cc);
                    
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }


        public async Task ReminderFilingFeeAuditedFinancialStatementCACEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.PaymentDetail == "Filing Fee for Audited Financial Statement - CAC" && e.MeansOfPaymentAmount == "CAC E-portal/Remita").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 4 && requestDate.Day == 27 && requestDate.Hour == 10 && requestDate.Minute == 2)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "CAC",
                        DeadLine = _target28April,
                        MeansOfPaymentAmount = "CAC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:FilingFeeAuditedFinancialStatementFRCNEmailTo"],
                        PaymentDetail = "Filing Fee for Audited Financial Statement - CAC",
                        BusinessEntity = "ARM Trustee"
                    };
                    string nameOfReport = "Filing Fee for Audited Financial Statement - CAC";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:FilingFeeAuditedFinancialStatementFRCNEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello FRCN, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by CAC <br> Deadline => {req.DeadLine},<br> Contact Person => FRCN<br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];

                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        public async Task AccuityEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.CreatedOnUtc.Date.Year == requestDate.Year && e.PaymentDetail == "Accuity" && e.MeansOfPaymentAmount == "Wire Transfer").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 6 && requestDate.Day == 20)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SYSTEMS or APP SUBSCRIPTIONS",
                        DeadLine = _target28June,
                        MeansOfPaymentAmount = "Wire Transfer",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "Accuity",
                        BusinessEntity = "ARM Trustee"
                    };
                    string nameOfReport = "Accuity";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFinConEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello FRCN, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => $5,000 (5,000 usd) <br> Deadline => {req.DeadLine},<br> Contact Person => mbg@fmdqgroup.com<br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var logReq = ComplianceRegulatoryPayment.InitiatePayment(req);
                    await complianceRegPayment.AddAsync(logReq);
                    await complianceRegPayment.SaveChangesAsync();

                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: logReq.Id, emailTo: to, toCC: cc);
                    
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        public async Task ReminderAccuityEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.PaymentDetail == "Accuity" && e.MeansOfPaymentAmount == "Wire Transfer").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 6 && requestDate.Day == 27 && requestDate.Hour == 10 && requestDate.Minute == 2)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SYSTEMS or APP SUBSCRIPTIONS",
                        DeadLine = _target28June,
                        MeansOfPaymentAmount = "Wire Transfer",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "Accuity",
                        BusinessEntity = "ARM Trustee"
                    };
                    string nameOfReport = "Accuity";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFinConEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello FRCN, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => $5,000 (5,000 usd) <br> Deadline => {req.DeadLine},<br> Contact Person => mbg@fmdqgroup.com<br>Kindly ignore if this has been treated.<br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }


        public async Task TechSolEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.CreatedOnUtc.Date.Year == requestDate.Year && e.PaymentDetail == "TechSol" && e.MeansOfPaymentAmount == "Wire Transfer").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 6 && requestDate.Day == 20)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SYSTEMS or APP SUBSCRIPTIONS",
                        DeadLine = _target28June,
                        MeansOfPaymentAmount = "Wire Transfer",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "TechSol",
                        BusinessEntity = "ARM Trustee"
                    };
                    var reqIM = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SYSTEMS or APP SUBSCRIPTIONS",
                        DeadLine = _target28June,
                        MeansOfPaymentAmount = "Wire Transfer",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "TechSol - Wire Transfer",
                        BusinessEntity = "ARM IM"
                    };
                    var reqSec = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SYSTEMS or APP SUBSCRIPTIONS",
                        DeadLine = _target28June,
                        MeansOfPaymentAmount = "Wire Transfer",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "TechSol - Wire Transfer",
                        BusinessEntity = "ARM Securities"
                    };
                    string nameOfReport = "TechSol";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFinConEmailTo"];
                    string toIM = config["EmailConfiguration:AccuityLicenseRenewalIMEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello FRCN, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => $5,000 (5,000 usd)<br> Deadline => {req.DeadLine},<br> Contact Person => Adanna.Onuigbo@fmdqgroup.com<br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string messageIM = $"Hello FRCN, <br>Kindly see the {reqIM.BusinessEntity} payment details.<br> Regulatory body => {reqIM.Regulator},<br>Detail => {reqIM.PaymentDetail},<br> Means of payment => {reqIM.MeansOfPaymentAmount},<br> Amount => As prescribed by Fincon/Treasury<br> Deadline => {reqIM.DeadLine},<br> Contact Person => Fincon/Treasury<br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string messageSec = $"Hello FRCN, <br>Kindly see the {reqSec.BusinessEntity} payment details.<br> Regulatory body => {reqSec.Regulator},<br>Detail => {reqSec.PaymentDetail},<br> Means of payment => {reqSec.MeansOfPaymentAmount},<br> Amount => As prescribed by Fincon/Treasury<br> Deadline => {reqSec.DeadLine},<br> Contact Person => Fincon/Treasury<br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var logReq = ComplianceRegulatoryPayment.InitiatePayment(req);
                    await complianceRegPayment.AddAsync(logReq);
                    //log request IM
                    var logReqIM = ComplianceRegulatoryPayment.InitiatePayment(reqIM);
                    await complianceRegPayment.AddAsync(logReqIM);
                    await complianceRegPayment.SaveChangesAsync();

                    //log request Sec
                    var logReqSec = ComplianceRegulatoryPayment.InitiatePayment(reqSec);
                    await complianceRegPayment.AddAsync(logReqSec);
                    await complianceRegPayment.SaveChangesAsync();
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: logReq.Id, emailTo: to, toCC: cc);
                    var logEmailRequestIM = await LogEmailRequestAssync(subject: nameOfReport, message: messageIM, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqIM.Id, emailTo: toIM, toCC: cc);
                    var logEmailRequestSec = await LogEmailRequestAssync(subject: nameOfReport, message: messageSec, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqSec.Id, emailTo: toIM, toCC: cc);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }


        public async Task ReminderTechSolEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.PaymentDetail == "TechSol" && e.MeansOfPaymentAmount == "Wire Transfer").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 6 && requestDate.Day == 27 && requestDate.Hour == 10 && requestDate.Minute == 2)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SYSTEMS or APP SUBSCRIPTIONS",
                        DeadLine = _target28June,
                        MeansOfPaymentAmount = "Wire Transfer",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "TechSol",
                        BusinessEntity = "ARM Trustee"
                    };
                    var reqIM = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SYSTEMS or APP SUBSCRIPTIONS",
                        DeadLine = _target28June,
                        MeansOfPaymentAmount = "Wire Transfer",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "TechSol - Wire Transfer",
                        BusinessEntity = "ARM IM"
                    };
                    string nameOfReport = "TechSol";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFinConEmailTo"];
                    string toIM = config["EmailConfiguration:AccuityLicenseRenewalIMEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello FRCN, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => $5,000 (5,000 usd)<br> Deadline => {req.DeadLine},<br> Contact Person => Adanna.Onuigbo@fmdqgroup.com<br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string messageIM = $"Hello FRCN, <br>Kindly see the {reqIM.BusinessEntity} payment details.<br> Regulatory body => {reqIM.Regulator},<br>Detail => {reqIM.PaymentDetail},<br> Means of payment => {reqIM.MeansOfPaymentAmount},<br> Amount => As prescribed by Fincon/Treasury<br> Deadline => {reqIM.DeadLine},<br> Contact Person => Fincon/Treasury<br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";

                    string filePath = config["EmailConfiguration:filePath"];

                    var result = await SendEmailNotificationAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                    var result2 = await SendEmailNotificationAsyncV1(nameOfReport, toIM, cc, messageIM, filePath, config: config);

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        public async Task ZanibalEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.CreatedOnUtc.Date.Year == requestDate.Year && e.PaymentDetail == "Zanibal" && e.MeansOfPaymentAmount == "Wire Transfer").FirstOrDefault();
                if (getForeignTransaction == null && requestDate.Month == 6 && requestDate.Day == 20)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SYSTEMS or APP SUBSCRIPTIONS",
                        DeadLine = _target28June,
                        MeansOfPaymentAmount = "Wire Transfer",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "Zanibal",
                        BusinessEntity = "ARM Trustee"
                    };
                    var reqSec = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SYSTEMS or APP SUBSCRIPTIONS",
                        DeadLine = _target28June,
                        MeansOfPaymentAmount = "Wire Transfer",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "Zanibal",
                        BusinessEntity = "ARM Securities"
                    };
                    string nameOfReport = "Zanibal";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFinConEmailTo"];
                    string toSec = config["EmailConfiguration:AccuityLicenseRenewalIMEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello FRCN, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => $5,000 (5,000 usd)<br> Deadline => {req.DeadLine},<br> Contact Person => Adanna.Onuigbo@fmdqgroup.com<br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string messageSec = $"Hello FRCN, <br>Kindly see the {reqSec.BusinessEntity} payment details.<br> Regulatory body => {reqSec.Regulator},<br>Detail => {reqSec.PaymentDetail},<br> Means of payment => {reqSec.MeansOfPaymentAmount},<br> Amount => $5,000 (5,000 usd)<br> Deadline => {reqSec.DeadLine},<br> Contact Person => Adanna.Onuigbo@fmdqgroup.com<br> Click below link for more detail. <a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var logReq = ComplianceRegulatoryPayment.InitiatePayment(req);
                    await complianceRegPayment.AddAsync(logReq);
                    await complianceRegPayment.SaveChangesAsync();

                    //log request Sec
                    var logReqSec = ComplianceRegulatoryPayment.InitiatePayment(reqSec);
                    await complianceRegPayment.AddAsync(logReqSec);
                    await complianceRegPayment.SaveChangesAsync();

                    //SendRiskMgtUnitEmail.SendRiskMgtUnitEmailAsyncV1(nameOfReport, to, cc, message, filePath, config: config);
                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: logReq.Id, emailTo: to, toCC: cc);
                    var logEmailRequestSec = await LogEmailRequestAssync(subject: nameOfReport, message: messageSec, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqSec.Id, emailTo: toSec, toCC: cc);
                   
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        public async Task ReminderZanibalEmail()
        {
            try
            {
                var requestDate = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate && e.PaymentDetail == "Zanibal" && e.MeansOfPaymentAmount == "Wire Transfer").FirstOrDefault();
                if (getForeignTransaction != null && requestDate.Month == 6 && requestDate.Day == 27 && requestDate.Hour == 10 && requestDate.Minute == 2)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SYSTEMS or APP SUBSCRIPTIONS",
                        DeadLine = _target28June,
                        MeansOfPaymentAmount = "Wire Transfer",
                        Amount = 0,
                        ProcessOfficer = config["EmailConfiguration:ARMSecurityFinConEmailTo"],
                        PaymentDetail = "Zanibal",
                        BusinessEntity = "ARM Trustee"
                    };
                    string nameOfReport = "Zanibal";
                    string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                    string to = config["EmailConfiguration:ARMSecurityFinConEmailTo"];
                    string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                    string message = $"Hello FRCN, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => $5,000 (5,000 usd)<br> Deadline => {req.DeadLine},<br> Contact Person => Adanna.Onuigbo@fmdqgroup.com<br>Kindly ignore if this has been treated.<br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string filePath = config["EmailConfiguration:filePath"];
                    //log request
                    var logReq = ComplianceRegulatoryPayment.InitiatePayment(req);
                    await complianceRegPayment.AddAsync(logReq);
                    await complianceRegPayment.SaveChangesAsync();

                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: logReq.Id, emailTo: to, toCC: cc);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// Quarterly Supervisory Fee send Email and save details in the DB
        /// </summary>
        /// <returns></returns>
        public async Task QuarterlySupervisoryFeeJanEmail()
        {
            try
            {
                var date7 = DateTime.Now.Date;
                var requestDate = _target20Janu.AddDays(-7);
                var requestDateApril = _target20April.AddDays(-7);
                var requestDateJuly = _target13July;
                var requestDateOctober = _target13October;
                string complianceReportLink = config["EmailConfiguration:ComplianceRegPaymentLink"];
                string nameOfReport = "Quarterly Supervisory Fee";

                string to = config["EmailConfiguration:CompliancePaymentARMIMEmailTo"];
                string toSec = config["EmailConfiguration:ARMCPRegulatoryEmailTo"];
                string cc = config["EmailConfiguration:ComplianceReportsEmailToCC"];
                string filePath = config["EmailConfiguration:filePath"];
                
                var date = DateTime.Now.Date;
                var getForeignTransaction = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate.Date && e.CreatedOnUtc.Date.Year == requestDate.Year  && e.PaymentDetail == "Quarterly Supervisory Fee - January" && e.MeansOfPaymentAmount == "SEC E-portal/Remita").FirstOrDefault();
                var getApril = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate.Date && e.CreatedOnUtc.Date.Year == requestDate.Year && e.PaymentDetail == "Quarterly Supervisory Fee - April" && e.MeansOfPaymentAmount == "SEC E-portal/Remita").FirstOrDefault();
                var getJuly = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate.Date && e.CreatedOnUtc.Date.Year == requestDate.Year && e.PaymentDetail == "Quarterly Supervisory Fee - July" && e.MeansOfPaymentAmount == "SEC E-portal/Remita").FirstOrDefault();
                var getOctober = complianceRegPayment.GetContextByConditon(e => e.CreatedOnUtc.Date == requestDate.Date && e.CreatedOnUtc.Date.Year == requestDate.Year && e.PaymentDetail == "Quarterly Supervisory Fee - October" && e.MeansOfPaymentAmount == "SEC E-portal/Remita").FirstOrDefault();

                if (getForeignTransaction == null && date.Month == 1 && date.Day == 13 && date.Hour == 10 && date.Minute == 5)
                {
                    var req = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target20Janu.AddDays(-5),
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = "Temitope Akinola, Evelyn Nwogu",
                        PaymentDetail = "Quarterly Supervisory Fee - January",
                        BusinessEntity = "ARM IM"
                    };

                    var reqSec = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target20Janu.AddDays(-5),
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = "Babatunde Osho",
                        PaymentDetail = "Quarterly Supervisory Fee - January",
                        BusinessEntity = "ARM Securities"
                    };

                    string message = $"Hello All, <br>Kindly see the {req.BusinessEntity} payment details.<br> Regulatory body => {req.Regulator},<br>Detail => {req.PaymentDetail},<br> Means of payment => {req.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {req.DeadLine},<br> Contact Person => SEC Fund Supervision Dept <br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string messageSec = $"Hello All, <br>Kindly see the {reqSec.BusinessEntity} payment details.<br> Regulatory body => {reqSec.Regulator},<br>Detail => {reqSec.PaymentDetail},<br> Means of payment => {reqSec.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {reqSec.DeadLine},<br> Contact Person => SEC Fund Supervision Dept <br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    //log request
                    var logReq = ComplianceRegulatoryPayment.InitiatePayment(req);
                    await complianceRegPayment.AddAsync(logReq);
                    //log request
                    var logReqSec = ComplianceRegulatoryPayment.InitiatePayment(reqSec);
                    await complianceRegPayment.AddAsync(logReqSec);
                    await complianceRegPayment.SaveChangesAsync();

                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: message, ModuleItemType: ModuleType.Compliance, moduleItemId: logReq.Id, emailTo: to, toCC: cc);
                    var logEmailRequestSec = await LogEmailRequestAssync(subject: nameOfReport, message: messageSec, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqSec.Id, emailTo: toSec, toCC: cc);
                }

                if (getApril == null && date.Month == 4 && date.Day == 13 && date.Hour == 10 && date.Minute == 5)
                {

                    var reqApr = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target20April.AddDays(-5),
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = "Temitope Akinola, Evelyn Nwogu",
                        PaymentDetail = "Quarterly Supervisory Fee - April",
                        BusinessEntity = "ARM IM"
                    };
                    var reqSecApr = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target20April.AddDays(-5),
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = "Babatunde Osho",
                        PaymentDetail = "Quarterly Supervisory Fee - April",
                        BusinessEntity = "ARM Securities"
                    };
                    string messageApr = $"Hello, <br>Kindly see the {reqApr.BusinessEntity} payment details.<br> Regulatory body => {reqApr.Regulator},<br>Detail => {reqApr.PaymentDetail},<br> Means of payment => {reqApr.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {reqApr.DeadLine},<br> Contact Person => SEC Fund Supervision Dept <br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string messageSecApr = $"Hello, <br>Kindly see the {reqSecApr.BusinessEntity} payment details.<br> Regulatory body => {reqSecApr.Regulator},<br>Detail => {reqSecApr.PaymentDetail},<br> Means of payment => {reqSecApr.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {reqSecApr.DeadLine},<br> Contact Person => SEC Fund Supervision Dept <br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";

                    //log request
                    var logReqApri = ComplianceRegulatoryPayment.InitiatePayment(reqApr);
                    await complianceRegPayment.AddAsync(logReqApri);
                    //log request
                    var logReqSecApri = ComplianceRegulatoryPayment.InitiatePayment(reqSecApr);
                    await complianceRegPayment.AddAsync(logReqSecApri);
                    await complianceRegPayment.SaveChangesAsync();

                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: messageApr, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqApri.Id, emailTo: to, toCC: cc);
                    var logEmailRequestSecApr = await LogEmailRequestAssync(subject: nameOfReport, message: messageSecApr, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqSecApri.Id, emailTo: toSec, toCC: cc);
                }

                if (getJuly == null && date.Month == 7 && date.Day == 13 && date.Hour == 10 && date.Minute == 5)
                {
                    var reqJuly = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target13July.AddDays(2),
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = "Temitope Akinola, Evelyn Nwogu",
                        PaymentDetail = "Quarterly Supervisory Fee - July",
                        BusinessEntity = "ARM IM"
                    };
                    var reqSecJul = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target13July.AddDays(2),
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = "Babatunde Osho",
                        PaymentDetail = "Quarterly Supervisory Fee - July",
                        BusinessEntity = "ARM Securities"
                    };
                    string messageJuly = $"Hello, <br>Kindly see the {reqJuly.BusinessEntity} payment details.<br> Regulatory body => {reqJuly.Regulator},<br>Detail => {reqJuly.PaymentDetail},<br> Means of payment => {reqJuly.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {reqJuly.DeadLine},<br> Contact Person => SEC Fund Supervision Dept <br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string messageSecJuly = $"Hello, <br>Kindly see the {reqSecJul.BusinessEntity} payment details.<br> Regulatory body => {reqSecJul.Regulator},<br>Detail => {reqSecJul.PaymentDetail},<br> Means of payment => {reqSecJul.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {reqSecJul.DeadLine},<br> Contact Person => SEC Fund Supervision Dept <br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";

                    //log request
                    var logReqJuly = ComplianceRegulatoryPayment.InitiatePayment(reqJuly);
                    await complianceRegPayment.AddAsync(logReqJuly);
                    //log request
                    var logReqSecJuly = ComplianceRegulatoryPayment.InitiatePayment(reqSecJul);
                    await complianceRegPayment.AddAsync(logReqSecJuly);
                    await complianceRegPayment.SaveChangesAsync();

                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: messageJuly, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqJuly.Id, emailTo: to, toCC: cc);
                    var logEmailRequestSecJuly = await LogEmailRequestAssync(subject: nameOfReport, message: messageSecJuly, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqSecJuly.Id, emailTo: toSec, toCC: cc);
                }

                if (getOctober == null && date.Month == 10 && date.Day == 13)
                {
                    var reqOct = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target13October.AddDays(2),
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = "Temitope Akinola, Evelyn Nwogu",
                        PaymentDetail = "Quarterly Supervisory Fee - October",
                        BusinessEntity = "ARM IM"
                    };
                    var reqSecOct = new InitiateRegulatorPaymentDto
                    {
                        Regulator = "SEC",
                        DeadLine = _target13October.AddDays(2),
                        MeansOfPaymentAmount = "SEC E-portal/Remita",
                        Amount = 0,
                        ProcessOfficer = "Babatunde Osho",
                        PaymentDetail = "Quarterly Supervisory Fee - July",
                        BusinessEntity = "ARM Securities"
                    };
                    string messageOct = $"Hello, <br>Kindly see the {reqOct.BusinessEntity} payment details.<br> Regulatory body => {reqOct.Regulator},<br>Detail => {reqOct.PaymentDetail},<br> Means of payment => {reqOct.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {reqOct.DeadLine},<br> Contact Person => SEC Fund Supervision Dept <br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";
                    string messageSecOct = $"Hello, <br>Kindly see the {reqSecOct.BusinessEntity} payment details.<br> Regulatory body => {reqSecOct.Regulator},<br>Detail => {reqSecOct.PaymentDetail},<br> Means of payment => {reqSecOct.MeansOfPaymentAmount},<br> Amount => As prescribed by SEC,<br> Deadline => {reqSecOct.DeadLine},<br> Contact Person => SEC Fund Supervision Dept <br> Click below link for more detail. <br><a href={complianceReportLink}>GRC Link</a>";

                    //log request
                    var logReqOct = ComplianceRegulatoryPayment.InitiatePayment(reqOct);
                    await complianceRegPayment.AddAsync(logReqOct);
                    //log request
                    var logReqSecOct = ComplianceRegulatoryPayment.InitiatePayment(reqSecOct);
                    await complianceRegPayment.AddAsync(logReqSecOct);
                    await complianceRegPayment.SaveChangesAsync();

                    var logEmailRequest = await LogEmailRequestAssync(subject: nameOfReport, message: messageOct, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqOct.Id, emailTo: to, toCC: cc);
                    var logEmailRequestSecOct = await LogEmailRequestAssync(subject: nameOfReport, message: messageSecOct, ModuleItemType: ModuleType.Compliance, moduleItemId: logReqSecOct.Id, emailTo: toSec, toCC: cc);
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        #endregion

        public string GetNameFromEmail(string email)
        {
            string username = email.Split('@')[0];

            string[] parts = username.Split('.');

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i] = textInfo.ToTitleCase(parts[i]);
            }

            return string.Join(" ", parts);
        }

        /// <summary>
        /// Log Email Request Assync
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="ModuleItemType"></param>
        /// <param name="moduleItemId"></param>
        /// <returns></returns>
        public async Task<bool> LogEmailRequestAssync(string subject, string message, ModuleType ModuleItemType, Guid moduleItemId, string emailTo, string toCC)
        {
            try
            {
                Guid guid = Guid.NewGuid();
                Email email = new Email();
                var logEmail = email.Create(emailId: guid, to: emailTo, cc: toCC, subject: subject, message: message, moduleItemType: ModuleItemType, moduleItemId: moduleItemId, createdAt: DateTime.Now, deliveryDate: null);
                await repoEmail.AddAsync(logEmail);
                return await repoEmail.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                return false;
            }

        }

     
        /// <summary>
        /// Background service fetches all the DeliveryDate that are null from the table.
        /// Background service send email notification and update the DeliveryDate date on the DB
        /// </summary>
        /// <returns></returns>
        public async Task BackgroundSendEmail()
        {
            try
           {
                Expression<Func<Email, bool>> exp = e => e.IsMessageSent == false;
                var emailObj = repoEmail.GetContextByConditon(exp).OrderBy(e => e.CreatedAt).FirstOrDefault();

                if (emailObj != null)
                {
                    var emailSender = new MimeMessage();
                    string filePath = config["EmailConfiguration:filePath"];
                    var result = await SendEmailNotificationAsyncV1(subject:emailObj.Subject, emailTo:emailObj.To, toCC:emailObj.CC, body:emailObj.Message, filePath:filePath, config: config);
                    emailObj.UpdateDeliveryStatus(result);
                    await repoEmail.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Email notification => {ex}, {ex.Message}");
            }
        }

        public async Task<bool> SendEmailNotificationAsyncV1(string subject, string emailTo, string toCC, string body, string filePath, IConfiguration config)
        {
            string emailMessage = "";
            string cetNumber = config["EmailConfiguration:cetNumber"];
            string cetEmail = config["EmailConfiguration:cetEmail"];
            string year = DateTime.Now.Year.ToString();

            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    emailMessage = await reader.ReadToEndAsync();
                    emailMessage = emailMessage.Replace("[Context]", body)
                                               .Replace("[CETNumber]", cetNumber)
                                               .Replace("[CETEmail]", cetEmail)
                                               .Replace("[CurrentYear]", year);
                }
            }
            else
            {
                logger.Warning("Email template file not found at path: {FilePath}", filePath);
                return false;
            }
            List<string> toEmail = new List<string> { "Sodiq.Quadre@arm.com.ng, roselina.ajah@arm.com.ng" };
            List<string> copy = new List<string> { "Sodiq.Quadre@arm.com.ng, roselina.ajah@arm.com.ng" };

            var sendEmail = new EmailRequestUpdated
            {
                

                Attachments = new List<AttachementRequest>(), 
                HasAttachment = false,
                Bcc = new List<string>(),
                Body = emailMessage,
                Cc = string.IsNullOrWhiteSpace(toCC) ? new List<string>() : toCC.Split(',').Select(e => e.Trim()).ToList(),
                Channel = "11",
                IsHtml = true,
                recipents = string.IsNullOrWhiteSpace(emailTo) ? new List<string>() : emailTo.Split(',').Select(e => e.Trim()).ToList(),
                RequestID = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(10000, 999999),
                Sender = "Appnotify@arm.com.ng",
                Subject = subject
            };
            logger.Information("Payload >> {1}", JsonConvert.SerializeObject(sendEmail));
            return await SendEmailAsync(sendEmail);
        }

        public async Task<bool> SendEmailAsync(EmailRequestUpdated request)
        {
            const string clientName = "EmailServiceClient";
            const string endpoint = "https://apiapps.arm.com.ng/EmailService/Notification/SendEmail";  

            using var client = _httpClientFactory.CreateClient(clientName);

            try
            {
                logger.Information("Attempting to send email to {Recipients}", request.recipents);

                var content = new StringContent(
                    JsonConvert.SerializeObject(request),
                    Encoding.UTF8,
                    "application/json");
                logger.Information("Payload >> {1}", JsonConvert.SerializeObject(request));
                var response = await client.PostAsync(endpoint, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                logger.Debug("Email service responded with status: {StatusCode}", response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    var resp = JsonConvert.DeserializeObject<EmailResponseUpdated>(responseContent);

                    if (resp != null && resp.isSuccessful && resp.responseCode == "00")
                    {
                        logger.Information("Email sent successfully to {Recipients}", request.recipents);
                        return true;
                    }

                    logger.Warning("Email send failed. Code: {Code}, Response: {Response}", resp?.responseCode, responseContent);
                    return false;
                }

                logger.Error("HTTP error during email send. Status: {StatusCode}, Content: {Content}",
                    response.StatusCode, responseContent);
                return false;
            }
            catch (HttpRequestException ex)
            {
                logger.Error(ex, "Network error while sending email to {Recipients}", request.recipents);
                return false;
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "Unexpected error sending email to {Recipients}", request.recipents);
                return false;
            }
        }


        /// <summary>
        /// Background Log Email To Group CEO And Deputy
        /// </summary>
        /// <returns></returns>
        public async Task BackgroundSendEmailToGroupCEOAndDeputy()
        {
            try
            {
                Guid moduleItemId = Guid.NewGuid();
                string dateOfOccurrence = occurrenceDay.ToString("yyyy-MM-dd"); 
                string year = DateTime.Now.AddYears(1).Year.ToString();
                string requestDate = DateTime.Now.ToString("yyyy-MM-dd");

                var date = DateTime.Now;
                if (requestDate == dateOfOccurrence && date.Month == 11 && date.Day == 30 && date.Hour == 7 && date.Minute == 2)
                {
                    string subject = $"Internal Audit FY {year} Plan - EMC's Concern";
                    string EMCConcernsLink = config["EmailConfiguration:EMCConcernsLink"];
                    string MondayDecember11 = new DateTime(DateTime.Now.Year, 12, 13).ToString("dd MMMM yyyy");
                    string emailTo = config["EmailConfiguration:EmailToGroupCEOAndDeputy"];
                    string toCC = config["EmailConfiguration:ToCCInternalAudit"];
                    string body = $"Dear EMC, <br><br>Trust you are doing well.<br><br>The Internal Audit unit is in the process of developing the FY {DateTime.Now.AddYears(1).Year} Internal Audit plan for the different Businesses and Shared Service functions.<br><br>One of the key factors considered during this exercise is “EMC’s Concern”. This helps us to put Executive Management’s concerns around the various Businesses, Business units and Shared Service functions into consideration when developing the audit plan, in order to ensure that all significant risk and significant interest areas are adequately catered for in our plan.<br><br>Kindly complete the form in the link below with your feedback on the different areas.<br><br>Please sign in using your Active Directory user name and password.<br><br><a href={EMCConcernsLink}>GRC Link</a>.<br><br>We would appreciate completion of this form by close of business on {MondayDecember11}.<br><br>Thank you.<br><br>Internal Audit";

                    string filePath = config["EmailConfiguration:filePath"];

                    var logEmailRequest = await LogEmailRequestAssync(subject: subject, message: body, ModuleItemType: ModuleType.InternalAudit, moduleItemId: moduleItemId, emailTo: emailTo, toCC: toCC); 
                    
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Background Log Email To Business MD
        /// </summary>
        /// <returns></returns>
        public async Task BackgroundSendEmailToBusinessMD()
        {
            try
            {
                Guid moduleItemId = Guid.NewGuid();
                string dateOfOccurrence = occurrenceDay.ToString("yyyy-MM-dd"); 
                string year = DateTime.Now.AddYears(1).Year.ToString();
                string requestDate = DateTime.Now.ToString("yyyy-MM-dd");
                var date = DateTime.Now;
                if (requestDate == dateOfOccurrence && date.Month == 11 && date.Day == 30 && date.Hour == 7 && date.Minute == 2)
                {
                    string subject = $"Internal Audit FY{year} Plan - Management's Concerns";
                    string ManagementConcernsLink = config["EmailConfiguration:ManagementConcernsLink"];
                    string MondayDecember11 = new DateTime(DateTime.Now.Year, 12, 13).ToString("dd MMMM yyyy");
                    string emailTo = config["EmailConfiguration:EmailToBusinessMD"];
                    string toCC = config["EmailConfiguration:ToCCInternalAudit"];
                    string body = $"Dear All, <br><br>The Internal Audit unit is in the process of developing the FY {DateTime.Now.AddYears(1).Year} audit plan for the different Businesses and Shared Service functions. <br><br>One of the key factors considered during this exercise is “Management’s Concerns”. This helps us to put Management’s concerns or worries over their Business, Business units and Shared Service units into consideration when developing the audit plan, in order to ensure that all significant risk and significant interest areas are adequately catered for in our plan.<br><br>Kindly complete the form in the link below with your feedback on the different areas.<br><br><a href={ManagementConcernsLink}>GRC Link</a>.<br><br>Please sign in using your Active Directory user name and password.<br><br>We would appreciate completion by close of business on {MondayDecember11}.<br><br>Thank you.<br><br>Internal Audit";

                    string filePath = config["EmailConfiguration:filePath"];
                    var logEmailRequest = await LogEmailRequestAssync(subject: subject, message: body, ModuleItemType: ModuleType.InternalAudit, moduleItemId: moduleItemId, emailTo: emailTo, toCC: toCC);

                }

            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Background Log Email To Internal Audit Staff
        /// </summary>
        /// <returns></returns>
        public async Task BackgroundSendEmailToInternalAuditStaff()
        {
            try
            {
                Guid moduleItemId = Guid.NewGuid();
                string dateOfOccurrence = occurrenceDay.ToString("yyyy-MM-dd"); 
                string year = DateTime.Now.AddYears(1).Year.ToString();
                string requestDate = DateTime.Now.ToString("yyyy-MM-dd");
                var date = DateTime.Now;
                if (requestDate == dateOfOccurrence && date.Month == 11 && date.Day == 30 && date.Hour == 7 && date.Minute == 2)
                //if (requestDate == dateOfOccurrence)
                {
                    string subject = $"Internal Audit FY {year} Plan - Risk Assessment";
                    string MondayDecember11 = _target11Dec.ToString("yyyy-MM-dd"); 
                    string emailTo = config["EmailConfiguration:EmailToInternalAuditStaff"];
                    string toCC = config["EmailConfiguration:ToCCInternalAudit"];
                    string body = $"Dear All,<br>Please commence the end-of-year risk assessment for the {year} Internal Audit plan.";
                    string filePath = config["EmailConfiguration:filePath"];

                    var logEmailRequest = await LogEmailRequestAssync(subject: subject, message: body, ModuleItemType: ModuleType.InternalAudit, moduleItemId: moduleItemId, emailTo: emailTo, toCC: toCC);
                    
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Background service fetches all Internal Audit Risk Assessment on the 30th of November whose DeliveryDate are null from the table.
        /// Background service send email notification and update the DeliveryDate date on the DB
        /// </summary>
        /// <returns></returns>
        public async Task InternalAuditSendEmailAsync()
        {
            try
            {
                string dateOfOccurrence = occurrenceDay.ToString("yyyy-MM-dd"); 
                string requestDate = DateTime.Now.ToString("yyyy-MM-dd");

                if (requestDate == dateOfOccurrence)
                {
                    string year = DateTime.Now.Year.ToString();
                    Expression<Func<Email, bool>> exp = e => e.Subject == $"Internal Audit FY{year} Plan - Risk Assessment" && e.IsMessageSent == false;
                    var emailObj = repoEmail.GetContextByConditon(exp).OrderBy(e => e.CreatedAt).FirstOrDefault();

                    if (emailObj != null)
                    {
                        var emailSender = new MimeMessage();
                        string filePath = config["EmailConfiguration:filePath"];
                       
                        var result = await SendEmailNotificationAsyncV1(subject: emailObj.Subject, emailTo: emailObj.To, toCC: emailObj.CC, body: emailObj.Message, filePath: filePath, config: config);
                        emailObj.UpdateDeliveryStatus(result);
                        await repoEmail.SaveChangesAsync();
                    }

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Background service fetches all Internal Audit Management Concerns on the 30th of November whose DeliveryDate are null from the table.
        /// Background service send email notification and update the DeliveryDate date on the DB
        /// </summary>
        /// <returns></returns>
        public async Task InternalAuditManagementConcernsSendEmailAsync()
        {
            try
            {
                string dateOfOccurrence = occurrenceDay.ToString("yyyy-MM-dd"); 
                string requestDate = DateTime.Now.ToString("yyyy-MM-dd");

                if (requestDate == dateOfOccurrence)
                {
                    string year = DateTime.Now.Year.ToString();
                    Expression<Func<Email, bool>> exp = e => e.Subject == $"Internal Audit FY{year} Plan - Management's Concerns" && e.IsMessageSent == false;
                    var emailObj = repoEmail.GetContextByConditon(exp).OrderBy(e => e.CreatedAt).FirstOrDefault();

                    if (emailObj != null)
                    {
                        var emailSender = new MimeMessage();
                        string filePath = config["EmailConfiguration:filePath"];
                        var result = await SendEmailNotificationAsyncV1(subject: emailObj.Subject, emailTo: emailObj.To, toCC: emailObj.CC, body: emailObj.Message, filePath: filePath, config: config);
                        emailObj.UpdateDeliveryStatus(result);
                        await repoEmail.SaveChangesAsync();
                    }                   
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

        /// <summary>
        /// Background service fetches all EMC concerns internal Audit on the 30th of November whose DeliveryDate are null from the table.
        /// Background service send email notification and update the DeliveryDate date on the DB
        /// </summary>
        /// <returns></returns>
        public async Task InternalAuditEMCConcernSendEmailAsync()
        {
            try
            {
                string dateOfOccurrence = occurrenceDay.ToString("yyyy-MM-dd"); 
                string requestDate = DateTime.Now.ToString("yyyy-MM-dd");

                if (requestDate == dateOfOccurrence)
                {
                    string year = DateTime.Now.Year.ToString();
                    Expression<Func<Email, bool>> exp = e => e.Subject == $"Internal Audit FY{year} Plan - EMC's Concern" && e.IsMessageSent == false;
                    var emailObj = repoEmail.GetContextByConditon(exp).OrderBy(e => e.CreatedAt).FirstOrDefault();

                    if (emailObj != null)
                    {
                        var emailSender = new MimeMessage();
                        string filePath = config["EmailConfiguration:filePath"];
                        var result = await SendEmailNotificationAsyncV1(subject: emailObj.Subject, emailTo: emailObj.To, toCC: emailObj.CC, body: emailObj.Message, filePath: filePath, config: config);
                        emailObj.UpdateDeliveryStatus(result);
                        await repoEmail.SaveChangesAsync();
                    }

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
        }

    }
}
