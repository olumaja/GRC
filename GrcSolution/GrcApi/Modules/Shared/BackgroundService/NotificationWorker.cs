using Arm.GrcTool.Infrastructure;
using ILogger = Serilog.ILogger;

namespace Arm.GrcTool.InfrastruCTOre
{
    public class NotificationWorker : BackgroundService
    {
        private readonly ILogger logger;
        private readonly IServiceScopeFactory factoryScope;
        private readonly IConfiguration config;
        private readonly PeriodicTimer timer;

        public NotificationWorker(ILogger logger, IServiceScopeFactory factoryScope, IConfiguration config)
        {
            this.logger = logger;
            this.factoryScope = factoryScope;
            this.config = config;
            timer = new(TimeSpan.FromMinutes(Convert.ToDouble(this.config["EmailSettings:JobInterval"])));
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.Information("Notification background job running");

            while (await timer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
            {
                using (IServiceScope scope = factoryScope.CreateScope())
                {
                    var sessionService = scope.ServiceProvider.GetRequiredService<ISessionService>();
                    await sessionService.UnlockUser();

                    var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
                    await emailService.BackgroundSendEmail();
                    
                    #region log internal audit email request to the table on every November 30th
                    await emailService.BackgroundSendEmailToGroupCEOAndDeputy();
                    await emailService.BackgroundSendEmailToBusinessMD();
                    await emailService.BackgroundSendEmailToInternalAuditStaff();

                    ////sent internal audit email notifications every November 30th
                    //await emailService.InternalAuditSendEmailAsync();
                    //await emailService.InternalAuditManagementConcernsSendEmailAsync();
                    //await emailService.InternalAuditEMCConcernSendEmailAsync();
                    #endregion

                    #region Operation Control Email reminder
                    await emailService.TwoDaysReminderAfterLoggedExceptionSendEmailAsync();
                    await emailService.OneDaysReminderAfterLoggedExceptionSendEmailAsync();
                    await emailService.DueExceptionReminderAfterLoggedExceptionSendEmailAsync();
                   
                    #endregion

                    #region Internal Control
                    await emailService.CallOverReportsDailyEmail();
                    await emailService.Exception48HoursReminderSendEmailAsync();
                    await emailService.Exception36HoursReminderSendEmailAsync();
                    await emailService.Exception24HoursReminderSendEmailAsync();
                    await emailService.Exception12HoursReminderSendEmailAsync();
                    await emailService.InternalControlDashboardSendEmailAsync();
                    await emailService.InternalControlDashboardSendMonthlyEmailAsync();
                    await emailService.InternalControlDashboardSendWeekEmailAsync();
                    #endregion

                    #region Internal Control - Investigation 
                    await emailService.Investigation48HoursReminderSendEmailAsync();
                    await emailService.Investgation36HoursReminderSendEmailAsync();
                    await emailService.Investgation24HoursReminderSendEmailAsync();
                    await emailService.Investgation12HoursReminderSendEmailAsync();

                    #endregion

                    #region  Compliance
                    await emailService.MajorDealReportsDailyEmail();
                    await emailService.PublicationOfAFSMutualFundsEmail();
                    await emailService.ForeignTransactionReportDailyEmail();
                    await emailService.NAVPriceMoneyMarketFundWeeklyEmail();
                    await emailService.CurrencyTransactionReportWeeklyEmail();
                    await emailService.NetCapitalPositionWeeklyEmail();
                    await emailService.SuspiciousTransactionsReportWeeklyEmail();
                    await emailService.NetCapitalPositionMonthlyEmail();
                    await emailService.PoliticallyExposedPersonsReturnsMonthlyEmail();
                    await emailService.MonthlyReportsForMutualFundEmail();
                    await emailService.MonthlyTransactionsReportEmail();
                    await emailService.MitigantOrContingencyPlansAnnuallyEmail();
                    await emailService.IndependentTestingComplianceProgrammeAnnuallyEmail();
                    await emailService.AnnualFinancialReportSECEmail();
                    await emailService.AnnualFinancialReportSecuritiesNGXCEmail();
                    await emailService.AnnualFinancialReportSecuritiesNASDEmail();
                    await emailService.AnnualFinancialReportsMutualFundSubmissionSECEmail();
                    await emailService.AnnualAuditPrivacyAndDataProtectionPracticesEmail();
                    await emailService.AnnualFinancialStatementFRCNEmail();

                    //await emailService.ReminderMonthlyTransactionsReportEmail();
                    //await emailService.ReminderNetCapitalPositionMonthlyEmail();
                    //await emailService.Reminder15thMitigantOrContingencyPlansAnnuallyEmail();
                    //await emailService.Reminder30thMitigantOrContingencyPlansAnnuallyEmail();
                    //await emailService.Reminder5thDecMitigantOrContingencyPlansAnnuallyEmail();
                    //await emailService.Reminder10thDecMitigantOrContingencyPlansAnnuallyEmail();
                    //await emailService.Reminder15thDecMitigantOrContingencyPlansAnnuallyEmail();
                    //await emailService.Reminder20thDecMitigantOrContingencyPlansAnnuallyEmail();
                    //await emailService.Reminder15NovIndependentTestingComplianceProgrammeAnnuallyEmail();
                    //await emailService.Reminder30NovIndependentTestingComplianceProgrammeAnnuallyEmail();
                    //await emailService.Reminder5thDecIndependentTestingComplianceProgrammeAnnuallyEmail();
                    //await emailService.Reminder10thDecIndependentTestingComplianceProgrammeAnnuallyEmail();
                    //await emailService.Reminder15thDecIndependentTestingComplianceProgrammeAnnuallyEmail();
                    //await emailService.Reminder20thDecIndependentTestingComplianceProgrammeAnnuallyEmail();
                    //await emailService.Reminder10AnnualFinancialReportSECEmail();
                    //await emailService.Reminder15AnnualFinancialReportSECEmail();
                    //await emailService.Reminder10MarAnnualFinancialReportSECEmail();
                    //await emailService.Reminder15MarAnnualFinancialReportSECEmail();
                    //await emailService.Reminder10AnnualFinancialReportSecuritiesNGXCEmail();
                    //await emailService.Reminder15AnnualFinancialReportSecuritiesNGXCEmail();
                    //await emailService.Reminder10MarAnnualFinancialReportSecuritiesNGXCEmail();
                    //await emailService.Reminder15MarAnnualFinancialReportSecuritiesNGXCEmail();
                    //await emailService.Reminder10AnnualFinancialReportSecuritiesNASDEmail();
                    //await emailService.Reminder15MarAnnualFinancialReportSecuritiesNASDEmail();
                    //await emailService.Reminder10MarAnnualFinancialReportSecuritiesNASDEmail();
                    //await emailService.Reminder15AnnualFinancialReportSecuritiesNASDEmail();
                    //await emailService.Reminder10AnnualFinancialReportsMutualFundSubmissionSECEmail();
                    //await emailService.Reminder15AnnualFinancialReportsMutualFundSubmissionSECEmail();
                    //await emailService.Reminder10MarAnnualFinancialReportsMutualFundSubmissionSECEmail();
                    //await emailService.Reminder15MarAnnualFinancialReportsMutualFundSubmissionSECEmail();
                    //await emailService.Reminder10AnnualAuditPrivacyAndDataProtectionPracticesEmail();
                    //await emailService.Reminder15AnnualAuditPrivacyAndDataProtectionPracticesEmail();
                    //await emailService.Reminder10MarAnnualAuditPrivacyAndDataProtectionPracticesEmail();
                    //await emailService.Reminder15MarAnnualAuditPrivacyAndDataProtectionPracticesEmail();
                    //await emailService.ReminderMonthlyReportsForMutualFundEmail();

                    #endregion

                    #region Compliance Payment
                    await emailService.QuarterlySupervisoryFeeJanEmail();
                    await emailService.AnnualFilingFeeEmail();
                    await emailService.ZanibalEmail();
                    await emailService.TechSolEmail();
                    await emailService.AnnualFilingFeeCorporateGovernanceNCCGEmail();
                    await emailService.AccuityLicenseRenewalEmail();
                    await emailService.DirectorLiabilityInsuranceEmail();
                    await emailService.FidelityBondEmail();
                    await emailService.FilingFeeAuditedFinancialStatementeCACEmail();
                    await emailService.FilingFeeAuditedFinancialStatementeEmail();
                    await emailService.AnnualSubscriptionRenewalACTEmail();
                    await emailService.AnnualRegistrationRenewalFeeEmail();
                    await emailService.AnnualFilingFeeCorporateGovernanceEmail();
                    await emailService.FilingFeeAuditedFinancialStatementFRCNEmail();
                    await emailService.FilingFeeAuditedFinancialStatementCACEmail();
                    await emailService.AccuityEmail();
                    await emailService.AnnualRegulatoryFeeEmail();

                    // await emailService.ReminderZanibalEmail();
                    // await emailService.ReminderAnnualFilingFeeEmail();
                    // await emailService.ReminderTechSolEmail();
                    //await emailService.ReminderAnnualFilingFeeCorporateGovernanceNCCGEmail();
                    //await emailService.ReminderAccuityLicenseRenewalEmail();
                    //await emailService.ReminderDirectorLiabilityInsuranceEmail();
                    // await emailService.ReminderFidelityBondEmail();
                    //await emailService.ReminderFilingFeeAuditedFinancialStatementeCACEmail();
                    // await emailService.ReminderAnnualFilingFeeCorporateGovernanceEmail();
                    //await emailService.ReminderAnnualRegistrationRenewalFeeEmail();
                    //await emailService.ReminderAnnualSubscriptionRenewalACTEmail();
                    //await emailService.ReminderFilingFeeAuditedFinancialStatementeEmail();
                    // await emailService.ReminderFilingFeeAuditedFinancialStatementFRCNEmail();
                    // await emailService.ReminderFilingFeeAuditedFinancialStatementCACEmail();
                    // await emailService.ReminderAccuityEmail();

                    #endregion

                    #region Information security
                    await emailService.OneWeekToProposedEndDateSendEmailAsync();
                    await emailService.ThreeDaysToProposedEndDateSendEmailAsync();
                    await emailService.ADayToProposedEndDateSendEmailAsync();
                    await emailService.OnTheProposedEndDateSendEmailAsync();
                    #endregion
                }
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            logger.Information($"{nameof(NotificationWorker)} is stopping.");
            await base.StopAsync(stoppingToken);
        }
    }
}
