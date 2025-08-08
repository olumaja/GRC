
//using Arm.GrcTool.Infrastructure;

using Arm.GrcApi.Modules.Shared.EmailNotification;
using Arm.GrcTool.Infrastructure;

namespace Arm.GrcTool.InfrastruCTOre
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(EmailRequestUpdated request);
        Task InternalAuditSendEmailAsync();
        Task Investigation48HoursReminderSendEmailAsync();
        Task Investgation36HoursReminderSendEmailAsync();
        Task Investgation24HoursReminderSendEmailAsync();
        Task Investgation12HoursReminderSendEmailAsync();
        Task InternalAuditEMCConcernSendEmailAsync();
        Task InternalAuditManagementConcernsSendEmailAsync();
        Task<bool> SendEmailNotificationAsyncV1(string subject, string emailTo, string toCC, string body, string filePath, IConfiguration config);
        Task ReminderMonthlyReportsForMutualFundEmail();
        Task OneDaysReminderAfterLoggedExceptionSendEmailAsync();
        Task TwoDaysReminderAfterLoggedExceptionSendEmailAsync();
        Task DueExceptionReminderAfterLoggedExceptionSendEmailAsync();
        Task Exception48HoursReminderSendEmailAsync();
        Task Exception36HoursReminderSendEmailAsync();
        Task Exception24HoursReminderSendEmailAsync();
        Task Exception12HoursReminderSendEmailAsync();
        Task InternalControlDashboardSendEmailAsync();
        Task InternalControlDashboardSendMonthlyEmailAsync();
        Task InternalControlDashboardSendWeekEmailAsync();
        Task CallOverReportsDailyEmail();
        Task<bool> LogEmailRequestAssync(string subject, string message, ModuleType ModuleItemType, Guid moduleItemId, string emailTo, string toCC);
        Task BackgroundSendEmail();
        Task BackgroundSendEmailToGroupCEOAndDeputy();
        Task BackgroundSendEmailToBusinessMD();
        Task BackgroundSendEmailToInternalAuditStaff();
      
        #region compliance
        Task MajorDealReportsDailyEmail();
        Task NAVPriceMoneyMarketFundWeeklyEmail();
        Task ForeignTransactionReportDailyEmail();
        Task CurrencyTransactionReportWeeklyEmail();
        Task NetCapitalPositionWeeklyEmail();
        Task SuspiciousTransactionsReportWeeklyEmail();
        Task NetCapitalPositionMonthlyEmail();
        Task PoliticallyExposedPersonsReturnsMonthlyEmail();
        Task MonthlyReportsForMutualFundEmail();
       // Task ReminderMonthlyReportsForMutualFundEmail();
        Task MonthlyTransactionsReportEmail();
        Task ReminderMonthlyTransactionsReportEmail();
        Task MitigantOrContingencyPlansAnnuallyEmail();
        Task ReminderNetCapitalPositionMonthlyEmail();
        Task Reminder15thMitigantOrContingencyPlansAnnuallyEmail();
        Task Reminder30thMitigantOrContingencyPlansAnnuallyEmail();
        Task Reminder5thDecMitigantOrContingencyPlansAnnuallyEmail();
        Task Reminder10thDecMitigantOrContingencyPlansAnnuallyEmail();
        Task Reminder15thDecMitigantOrContingencyPlansAnnuallyEmail();
        Task Reminder20thDecMitigantOrContingencyPlansAnnuallyEmail();
        Task IndependentTestingComplianceProgrammeAnnuallyEmail();
        Task Reminder15NovIndependentTestingComplianceProgrammeAnnuallyEmail();
        Task Reminder30NovIndependentTestingComplianceProgrammeAnnuallyEmail();
        Task Reminder5thDecIndependentTestingComplianceProgrammeAnnuallyEmail();
        Task Reminder10thDecIndependentTestingComplianceProgrammeAnnuallyEmail();
        Task Reminder15thDecIndependentTestingComplianceProgrammeAnnuallyEmail();
        Task Reminder20thDecIndependentTestingComplianceProgrammeAnnuallyEmail();
        Task AnnualFinancialReportSECEmail();
        Task Reminder10AnnualFinancialReportSECEmail();
        Task Reminder15AnnualFinancialReportSECEmail();
        Task Reminder10MarAnnualFinancialReportSECEmail();
        Task Reminder15MarAnnualFinancialReportSECEmail();
        Task AnnualFinancialReportSecuritiesNGXCEmail();
        Task Reminder10AnnualFinancialReportSecuritiesNGXCEmail();
        Task Reminder15AnnualFinancialReportSecuritiesNGXCEmail();
        Task Reminder10MarAnnualFinancialReportSecuritiesNGXCEmail();
        Task Reminder15MarAnnualFinancialReportSecuritiesNGXCEmail();
        Task AnnualFinancialReportSecuritiesNASDEmail();
        Task Reminder10AnnualFinancialReportSecuritiesNASDEmail();
        Task Reminder15MarAnnualFinancialReportSecuritiesNASDEmail();
        Task Reminder10MarAnnualFinancialReportSecuritiesNASDEmail();
        Task Reminder15AnnualFinancialReportSecuritiesNASDEmail();
        Task AnnualFinancialReportsMutualFundSubmissionSECEmail();
        Task Reminder10AnnualFinancialReportsMutualFundSubmissionSECEmail();
        Task Reminder15AnnualFinancialReportsMutualFundSubmissionSECEmail();
        Task Reminder10MarAnnualFinancialReportsMutualFundSubmissionSECEmail();
        Task Reminder10AnnualAuditPrivacyAndDataProtectionPracticesEmail();
        Task Reminder15MarAnnualFinancialReportsMutualFundSubmissionSECEmail();
        Task AnnualAuditPrivacyAndDataProtectionPracticesEmail();
        Task Reminder15AnnualAuditPrivacyAndDataProtectionPracticesEmail();
        Task Reminder10MarAnnualAuditPrivacyAndDataProtectionPracticesEmail();
        Task Reminder15MarAnnualAuditPrivacyAndDataProtectionPracticesEmail();
        Task AnnualFinancialStatementFRCNEmail();
        #endregion

        #region Compliance Payment
        Task PublicationOfAFSMutualFundsEmail();
        Task QuarterlySupervisoryFeeJanEmail();
        Task ReminderAnnualFilingFeeCorporateGovernanceNCCGEmail();
        Task AnnualFilingFeeCorporateGovernanceNCCGEmail();
        Task ReminderAccuityLicenseRenewalEmail();
        Task AccuityLicenseRenewalEmail();
        Task ReminderDirectorLiabilityInsuranceEmail();
        Task DirectorLiabilityInsuranceEmail();
        Task ReminderFidelityBondEmail();
        Task FidelityBondEmail();
        Task ReminderFilingFeeAuditedFinancialStatementeCACEmail();
        Task FilingFeeAuditedFinancialStatementeCACEmail();
        Task ReminderFilingFeeAuditedFinancialStatementeEmail();
        Task FilingFeeAuditedFinancialStatementeEmail();
        Task ReminderAnnualFilingFeeCorporateGovernanceEmail();
        Task AnnualRegistrationRenewalFeeEmail();
        Task ReminderAnnualRegistrationRenewalFeeEmail();
        Task ReminderAnnualSubscriptionRenewalACTEmail();
        Task AnnualFilingFeeCorporateGovernanceEmail();
        Task AnnualSubscriptionRenewalACTEmail();
        Task FilingFeeAuditedFinancialStatementFRCNEmail();
        Task ReminderFilingFeeAuditedFinancialStatementFRCNEmail();
        Task FilingFeeAuditedFinancialStatementCACEmail();
        Task ReminderFilingFeeAuditedFinancialStatementCACEmail();
        Task AccuityEmail();
        Task ReminderAccuityEmail();
        Task ReminderTechSolEmail();
        Task ReminderAnnualFilingFeeEmail();
        Task TechSolEmail();
        Task ZanibalEmail();
        Task ReminderZanibalEmail();
        Task AnnualFilingFeeEmail();
        Task AnnualRegulatoryFeeEmail();
        #endregion

        #region InforSec
        Task OneWeekToProposedEndDateSendEmailAsync();
        Task ThreeDaysToProposedEndDateSendEmailAsync();
        Task ADayToProposedEndDateSendEmailAsync();
        Task OnTheProposedEndDateSendEmailAsync();
        #endregion
    }
}
