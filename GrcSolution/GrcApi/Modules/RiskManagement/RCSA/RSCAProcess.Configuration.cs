using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using GrcApi.Modules.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure
{
    public class RSCAProcessCofiguration : IEntityTypeConfiguration<RSCAProcess>
    {
        public void Configure(EntityTypeBuilder<RSCAProcess> builder)
        {
            builder.ToTable(nameof(RSCAProcess));
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).HasMaxLength(500);
            builder.HasOne(b => b.Unit).WithMany(b => b.RSCAProcess).HasForeignKey(b => b.UnitId);


            // Data seeding

            builder.HasData(
            #region ARMSecuritiesRiskManagement Processes
                    RSCAProcess.Create("Risk event reporting on the oprisk manager", new Guid(ARMSecuritiesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Loss Data Collection", new Guid(ARMSecuritiesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("MRC Reporting", new Guid(ARMSecuritiesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("RCSA Process", new Guid(ARMSecuritiesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("ALCO Reporting", new Guid(ARMSecuritiesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Risk Management Disclosures", new Guid(ARMSecuritiesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("BARC Reporting", new Guid(ARMSecuritiesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("MFIC Reporting", new Guid(ARMSecuritiesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Fianacial Risk Review and Reporting", new Guid(ARMSecuritiesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Pledge Review and Approval", new Guid(ARMSecuritiesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("New Product Assessment", new Guid(ARMSecuritiesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Counterparty Review and Assessment", new Guid(ARMSecuritiesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Business Continuity Management Tests", new Guid(ARMSecuritiesRiskManagement.RiskManagement)),
            #endregion
            #region ARMSecuritiesCorporateStrategy Processes
                    RSCAProcess.Create("Corporate strategy development", new Guid(ARMSecuritiesCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Business strategy articulataion", new Guid(ARMSecuritiesCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Strategy revision", new Guid(ARMSecuritiesCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Business strategy monitoring", new Guid(ARMSecuritiesCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Quarterly performance review session", new Guid(ARMSecuritiesCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Report preparation", new Guid(ARMSecuritiesCorporateStrategy.CorporateStrategy)),
            #endregion
            #region ARMSecuritiesCustomerExperience Processes

                RSCAProcess.Create("Mutual Funds Account Creation", new Guid(ARMSecuritiesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Data Update", new Guid(ARMSecuritiesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Embassy Letter", new Guid(ARMSecuritiesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Unit Transfer", new Guid(ARMSecuritiesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid(ARMSecuritiesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Client Communications", new Guid(ARMSecuritiesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Root Cause Analysis", new Guid(ARMSecuritiesCustomerExperience.CustomerService)),

                RSCAProcess.Create("Mutual Funds Account Creation", new Guid(ARMSecuritiesCustomerExperience.CallCentre)),
                RSCAProcess.Create("Data Update", new Guid(ARMSecuritiesCustomerExperience.CallCentre)),
                RSCAProcess.Create("Embassy Letter", new Guid(ARMSecuritiesCustomerExperience.CallCentre)),
                RSCAProcess.Create("Unit Transfer", new Guid(ARMSecuritiesCustomerExperience.CallCentre)),
                RSCAProcess.Create("Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid(ARMSecuritiesCustomerExperience.CallCentre)),
                RSCAProcess.Create("Client Communications", new Guid(ARMSecuritiesCustomerExperience.CallCentre)),
                RSCAProcess.Create("Root Cause Analysis", new Guid(ARMSecuritiesCustomerExperience.CallCentre)),
            #endregion
            #region ARMSecuritiesLegalCompliance Processes
                    RSCAProcess.Create("Contract drafting and reviews", new Guid(ARMSecuritiesLegalCompliance.Legal)),
                    RSCAProcess.Create("Drafting Embassy letters ", new Guid(ARMSecuritiesLegalCompliance.Legal)),
                    RSCAProcess.Create("Legal Advisory", new Guid(ARMSecuritiesLegalCompliance.Legal)),
                    RSCAProcess.Create("Regulatory filings", new Guid(ARMSecuritiesLegalCompliance.Legal)),
                    RSCAProcess.Create("Coordination of Boarding and Committee Meetings", new Guid(ARMSecuritiesLegalCompliance.Legal)),
                    RSCAProcess.Create("Drafting of Minutes and other post meeting documents/Correspondence", new Guid(ARMSecuritiesLegalCompliance.Legal)),
                    RSCAProcess.Create("General secretarial activities", new Guid(ARMSecuritiesLegalCompliance.Legal)),

                    RSCAProcess.Create("Account Opening", new Guid(ARMSecuritiesLegalCompliance.Compliance)),
                    RSCAProcess.Create("Filing of Regulatory Returns", new Guid(ARMSecuritiesLegalCompliance.Compliance)),
                    RSCAProcess.Create("Due Diligence on Clients and Vendors", new Guid(ARMSecuritiesLegalCompliance.Compliance)),
                    RSCAProcess.Create("SEC Registration of Sponsored individuals/Transfers and Applications", new Guid(ARMSecuritiesLegalCompliance.Compliance)),
                    RSCAProcess.Create("Sanction Sceening on clients", new Guid(ARMSecuritiesLegalCompliance.Compliance)),
            #endregion
            #region ARMSecuritiesInformationTechnology Process
                RSCAProcess.Create("Systems Maintenance", new Guid(ARMSecuritiesInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Applications Development/Enhancement", new Guid(ARMSecuritiesInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Planning, Implementing and Closing IT Projects", new Guid(ARMSecuritiesInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Data Backup", new Guid(ARMSecuritiesInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Data Recovery Steps", new Guid(ARMSecuritiesInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Simulating Disaster and Recovery", new Guid(ARMSecuritiesInformationTechnology.InformationTechnology)),
            #endregion
            #region ARMSecuritiesInternalControlInternalAudit Processes
                RSCAProcess.Create("Development of Annual Audit Plan (IA Plan)", new Guid(ARMSecuritiesInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Audit Review", new Guid(ARMSecuritiesInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Investigation", new Guid(ARMSecuritiesInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Follow Up", new Guid(ARMSecuritiesInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Operational Performance Rating", new Guid(ARMSecuritiesInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Board Audit and Risk Management Committee (BARC) Reporting", new Guid(ARMSecuritiesInternalControlInternalAudit.InternalAudit)),

                RSCAProcess.Create("Cash call-over", new Guid(ARMSecuritiesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Trade call-over", new Guid(ARMSecuritiesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Mutual Fund Pricing Review", new Guid(ARMSecuritiesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Institutional Fund Pricing Review", new Guid(ARMSecuritiesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Portfolio Stock Account Reconciliation", new Guid(ARMSecuritiesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Fixed Income Trade Review", new Guid(ARMSecuritiesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("BRD and UAT review", new Guid(ARMSecuritiesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("User Rights Access Mgt", new Guid(ARMSecuritiesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Statutory Remittance Review", new Guid(ARMSecuritiesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Daily Teams Call Over", new Guid(ARMSecuritiesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("CSCS Reconciliation", new Guid(ARMSecuritiesInternalControlInternalAudit.InternalControl)),
            #endregion

            #region ARMIMBusinessDevelopment Processes
                RSCAProcess.Create("Redemption/Withdrawals/Other Payments", new Guid(ARMIMBusinessDevelopment.WealthRelationshipManagementAbuja)),
                RSCAProcess.Create("Subscriptions", new Guid(ARMIMBusinessDevelopment.WealthRelationshipManagementAbuja)),
                RSCAProcess.Create("Reference Letters", new Guid(ARMIMBusinessDevelopment.WealthRelationshipManagementAbuja)),
                RSCAProcess.Create("Statement/Valuation Requests & Quarterly Portfolio Reviews", new Guid(ARMIMBusinessDevelopment.WealthRelationshipManagementAbuja)),
            #endregion
            #region ARMIMRiskManagement Processes
                    RSCAProcess.Create("Risk event reporting on the oprisk manager", new Guid(ARMIMRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Loss Data Collection", new Guid(ARMIMRiskManagement.RiskManagement)),
                    RSCAProcess.Create("MRC Reporting", new Guid(ARMIMRiskManagement.RiskManagement)),
                    RSCAProcess.Create("RCSA Process", new Guid(ARMIMRiskManagement.RiskManagement)),
                    RSCAProcess.Create("ALCO Reporting", new Guid(ARMIMRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Risk Management Disclosures", new Guid(ARMIMRiskManagement.RiskManagement)),
                    RSCAProcess.Create("BARC Reporting", new Guid(ARMIMRiskManagement.RiskManagement)),
                    RSCAProcess.Create("MFIC Reporting", new Guid(ARMIMRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Fianacial Risk Review and Reporting", new Guid(ARMIMRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Pledge Review and Approval", new Guid(ARMIMRiskManagement.RiskManagement)),
                    RSCAProcess.Create("New Product Assessment", new Guid(ARMIMRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Counterparty Review and Assessment", new Guid(ARMIMRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Business Continuity Management Tests", new Guid(ARMIMRiskManagement.RiskManagement)),
            #endregion
            #region ARMIMCorporateStrategy Processes
                    RSCAProcess.Create("Corporate strategy development", new Guid(ARMIMCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Business strategy articulataion", new Guid(ARMIMCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Strategy revision", new Guid(ARMIMCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Business strategy monitoring", new Guid(ARMIMCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Quarterly performance review session", new Guid(ARMIMCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Report preparation", new Guid(ARMIMCorporateStrategy.CorporateStrategy)),

            #endregion
            #region ARMIMCustomerExperience Processes

                RSCAProcess.Create("Mutual Funds Account Creation", new Guid(ARMIMCustomerExperience.CustomerService)),
                RSCAProcess.Create("Data Update", new Guid(ARMIMCustomerExperience.CustomerService)),
                RSCAProcess.Create("Embassy Letter", new Guid(ARMIMCustomerExperience.CustomerService)),
                RSCAProcess.Create("Unit Transfer", new Guid(ARMIMCustomerExperience.CustomerService)),
                RSCAProcess.Create("Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid(ARMIMCustomerExperience.CustomerService)),
                RSCAProcess.Create("Client Communications", new Guid(ARMIMCustomerExperience.CustomerService)),
                RSCAProcess.Create("Root Cause Analysis", new Guid(ARMIMCustomerExperience.CustomerService)),

                RSCAProcess.Create("Mutual Funds Account Creation", new Guid(ARMIMCustomerExperience.CallCenter)),
                RSCAProcess.Create("Data Update", new Guid(ARMIMCustomerExperience.CallCenter)),
                RSCAProcess.Create("Embassy Letter", new Guid(ARMIMCustomerExperience.CallCenter)),
                RSCAProcess.Create("Unit Transfer", new Guid(ARMIMCustomerExperience.CallCenter)),
                RSCAProcess.Create("Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid(ARMIMCustomerExperience.CallCenter)),
                RSCAProcess.Create("Client Communications", new Guid(ARMIMCustomerExperience.CallCenter)),
                RSCAProcess.Create("Root Cause Analysis", new Guid(ARMIMCustomerExperience.CallCenter)),
            #endregion
            #region ARMIMLegalCompliance Processes
                    RSCAProcess.Create("Contract drafting and reviews", new Guid(ARMIMLegalCompliance.Legal)),
                    RSCAProcess.Create("Drafting Embassy letters ", new Guid(ARMIMLegalCompliance.Legal)),
                    RSCAProcess.Create("Legal Advisory", new Guid(ARMIMLegalCompliance.Legal)),
                    RSCAProcess.Create("Regulatory filings", new Guid(ARMIMLegalCompliance.Legal)),
                    RSCAProcess.Create("Coordination of Boarding and Committee Meetings", new Guid(ARMIMLegalCompliance.Legal)),
                    RSCAProcess.Create("Drafting of Minutes and other post meeting documents/Correspondence", new Guid(ARMIMLegalCompliance.Legal)),
                    RSCAProcess.Create("General secretarial activities", new Guid(ARMIMLegalCompliance.Legal)),

                    RSCAProcess.Create("Account Opening", new Guid(ARMIMLegalCompliance.Compliance)),
                    RSCAProcess.Create("Filing of Regulatory Returns", new Guid(ARMIMLegalCompliance.Compliance)),
                    RSCAProcess.Create("Due Diligence on Clients and Vendors", new Guid(ARMIMLegalCompliance.Compliance)),
                    RSCAProcess.Create("SEC Registration of Sponsored individuals/Transfers and Applications", new Guid(ARMIMLegalCompliance.Compliance)),
                    RSCAProcess.Create("Sanction Sceening on clients", new Guid(ARMIMLegalCompliance.Compliance)),
            #endregion
            #region ARMIMBackOfficeOperations Processes

                    RSCAProcess.Create("Stock & Institution creation, Issuer Creation, Mutual fund Creation", new Guid(ARMIMBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Portfolio CSCS creation", new Guid(ARMIMBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Bank statement upload on AMS and  Fund injection processing on Deluxe", new Guid(ARMIMBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Foreign exchnage upload. Price and rates upload (Bloomberg prices, FMDQ, NGX, FMAN, NASD)", new Guid(ARMIMBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Portfolio, Transactional client, Scheme  withdrwals", new Guid(ARMIMBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Accounting unit postings / adjsutements", new Guid(ARMIMBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Bank account mapping", new Guid(ARMIMBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Portfolio creation, System bank account creation, Bank account mapping", new Guid(ARMIMBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("RM creation and mapping ", new Guid(ARMIMBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Fee set up and fee mapping", new Guid(ARMIMBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Client creation and client mapping", new Guid(ARMIMBackOfficeOperations.FundAccount)),

                    RSCAProcess.Create("Receipt of client instruction", new Guid(ARMIMBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Receipt of share certificates and verification documents", new Guid(ARMIMBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Inter-Member transfer request", new Guid(ARMIMBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Unverified returned share certificates", new Guid(ARMIMBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Corporate Action", new Guid(ARMIMBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Dividend Settlement", new Guid(ARMIMBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Portfolio stock reconciliation", new Guid(ARMIMBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Transfer of portfolio to another party (broker)/Portfolio stock withdrawal", new Guid(ARMIMBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Transfer of stocks between same client’s portfolios", new Guid(ARMIMBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Custodian reconciliation", new Guid(ARMIMBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Update of Instrument Information", new Guid(ARMIMBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("MMF Quarterly Dividend Reinvestment", new Guid(ARMIMBackOfficeOperations.FundAdmin)),

                    RSCAProcess.Create("Account Onboarding", new Guid(ARMIMBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Redemption Processing - Verification (Mutual Fund)", new Guid(ARMIMBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Withdrawal Processing (Portfolio Fund)", new Guid(ARMIMBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Record Update", new Guid(ARMIMBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Unit Transfer", new Guid(ARMIMBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Standard Embassy Letter", new Guid(ARMIMBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Estate Transmission - Letter of Administration / Probate", new Guid(ARMIMBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Deactivation of Mobile Number Re-assigned to a Third Party", new Guid(ARMIMBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Unclaimed Dividend Payment", new Guid(ARMIMBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("EOQ/Dividend Payment", new Guid(ARMIMBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Change of Dividend Mandate", new Guid(ARMIMBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("NFIU Reporting", new Guid(ARMIMBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Sanction Screening", new Guid(ARMIMBackOfficeOperations.Registrars)),

                    RSCAProcess.Create("AMS pulls transactions from the Bank API", new Guid(ARMIMBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("AMS automatch transactions with membership ID and integrates to NAV", new Guid(ARMIMBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Manual matching of inflow into clients account", new Guid(ARMIMBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Manual Collation of inflows and uploads into core application- NAV", new Guid(ARMIMBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Posting of all matched subscription on NAV", new Guid(ARMIMBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Posting of all verified redemptions and pass for payment", new Guid(ARMIMBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Initiation of Intra-fund unit transfers", new Guid(ARMIMBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Direct debit set up and Termination", new Guid(ARMIMBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Posting of Buybacks", new Guid(ARMIMBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Memo for Transfer of fund across Bank", new Guid(ARMIMBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Goal-related Transactions", new Guid(ARMIMBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Daily Movement of posted subscriptions at Bank(Cash Sweep)", new Guid(ARMIMBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Daily Reconciliation of all Web transactions", new Guid(ARMIMBackOfficeOperations.RetailOperations)),

                    RSCAProcess.Create("Reconciliation", new Guid(ARMIMBackOfficeOperations.OperationControls)),
                    RSCAProcess.Create("Call over", new Guid(ARMIMBackOfficeOperations.OperationControls)),
                    RSCAProcess.Create("Fee accrual validation", new Guid(ARMIMBackOfficeOperations.OperationControls)),
                    RSCAProcess.Create("GL reconciliation and review", new Guid(ARMIMBackOfficeOperations.OperationControls)),
                    RSCAProcess.Create("Valuation and pricing review, EOD activities review", new Guid(ARMIMBackOfficeOperations.OperationControls)),
            #endregion
            #region ARMIMInformationTechnology Process
                RSCAProcess.Create("Systems Maintenance", new Guid(ARMIMInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Applications Development/Enhancement", new Guid(ARMIMInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Planning, Implementing and Closing IT Projects", new Guid(ARMIMInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Data Backup", new Guid(ARMIMInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Data Recovery Steps", new Guid(ARMIMInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Simulating Disaster and Recovery", new Guid(ARMIMInformationTechnology.InformationTechnology)),
            #endregion
            #region ARMIMInternalControlInternalAudit Processes
                RSCAProcess.Create("Development of Annual Audit Plan (IA Plan)", new Guid(ARMIMInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Audit Review", new Guid(ARMIMInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Investigation", new Guid(ARMIMInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Follow Up", new Guid(ARMIMInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Operational Performance Rating", new Guid(ARMIMInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Board Audit and Risk Management Committee (BARC) Reporting", new Guid(ARMIMInternalControlInternalAudit.InternalAudit)),

                RSCAProcess.Create("Cash call-over", new Guid(ARMIMInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Trade call-over", new Guid(ARMIMInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Mutual Fund Pricing Review", new Guid(ARMIMInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Institutional Fund Pricing Review", new Guid(ARMIMInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Portfolio Stock Account Reconciliation", new Guid(ARMIMInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Fixed Income Trade Review", new Guid(ARMIMInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("BRD and UAT review", new Guid(ARMIMInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("User Rights Access Mgt", new Guid(ARMIMInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Statutory Remittance Review", new Guid(ARMIMInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Daily Teams Call Over", new Guid(ARMIMInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("CSCS Reconciliation", new Guid(ARMIMInternalControlInternalAudit.InternalControl)),
            #endregion

            #region ARMHoldCoRiskManagement Processes
                    RSCAProcess.Create("Risk event reporting on the oprisk manager", new Guid(ARMHoldCoRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Loss Data Collection", new Guid(ARMHoldCoRiskManagement.RiskManagement)),
                    RSCAProcess.Create("MRC Reporting", new Guid(ARMHoldCoRiskManagement.RiskManagement)),
                    RSCAProcess.Create("RCSA Process", new Guid(ARMHoldCoRiskManagement.RiskManagement)),
                    RSCAProcess.Create("ALCO Reporting", new Guid(ARMHoldCoRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Risk Management Disclosures", new Guid(ARMHoldCoRiskManagement.RiskManagement)),
                    RSCAProcess.Create("BARC Reporting", new Guid(ARMHoldCoRiskManagement.RiskManagement)),
                    RSCAProcess.Create("MFIC Reporting", new Guid(ARMHoldCoRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Fianacial Risk Review and Reporting", new Guid(ARMHoldCoRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Pledge Review and Approval", new Guid(ARMHoldCoRiskManagement.RiskManagement)),
                    RSCAProcess.Create("New Product Assessment", new Guid(ARMHoldCoRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Counterparty Review and Assessment", new Guid(ARMHoldCoRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Business Continuity Management Tests", new Guid(ARMHoldCoRiskManagement.RiskManagement)),

            #endregion
            #region ARMHoldCoCorporateStrategy Processes
                    RSCAProcess.Create("Corporate strategy development", new Guid(ARMHoldCoCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Business strategy articulataion", new Guid(ARMHoldCoCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Strategy revision", new Guid(ARMHoldCoCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Business strategy monitoring", new Guid(ARMHoldCoCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Quarterly performance review session", new Guid(ARMHoldCoCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Report preparation", new Guid(ARMHoldCoCorporateStrategy.CorporateStrategy)),

            #endregion
            #region ARMHoldCoCustomerExperience Processes

                RSCAProcess.Create("Mutual Funds Account Creation", new Guid(ARMHoldCoCustomerExperience.CustomerService)),
                RSCAProcess.Create("Data Update", new Guid(ARMHoldCoCustomerExperience.CustomerService)),
                RSCAProcess.Create("Embassy Letter", new Guid(ARMHoldCoCustomerExperience.CustomerService)),
                RSCAProcess.Create("Unit Transfer", new Guid(ARMHoldCoCustomerExperience.CustomerService)),
                RSCAProcess.Create("Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid(ARMHoldCoCustomerExperience.CustomerService)),
                RSCAProcess.Create("Client Communications", new Guid(ARMHoldCoCustomerExperience.CustomerService)),
                RSCAProcess.Create("Root Cause Analysis", new Guid(ARMHoldCoCustomerExperience.CustomerService)),

                RSCAProcess.Create("Mutual Funds Account Creation", new Guid(ARMHoldCoCustomerExperience.CallCentre)),
                RSCAProcess.Create("Data Update", new Guid(ARMHoldCoCustomerExperience.CallCentre)),
                RSCAProcess.Create("Embassy Letter", new Guid(ARMHoldCoCustomerExperience.CallCentre)),
                RSCAProcess.Create("Unit Transfer", new Guid(ARMHoldCoCustomerExperience.CallCentre)),
                RSCAProcess.Create("Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid(ARMHoldCoCustomerExperience.CallCentre)),
                RSCAProcess.Create("Client Communications", new Guid(ARMHoldCoCustomerExperience.CallCentre)),
                RSCAProcess.Create("Root Cause Analysis", new Guid(ARMHoldCoCustomerExperience.CallCentre)),

            #endregion
            #region ARMHoldCoLegalCompliance Processes
                    RSCAProcess.Create("Contract drafting and reviews", new Guid(ARMHoldCoLegalCompliance.Legal)),
                    RSCAProcess.Create("Drafting Embassy letters ", new Guid(ARMHoldCoLegalCompliance.Legal)),
                    RSCAProcess.Create("Legal Advisory", new Guid(ARMHoldCoLegalCompliance.Legal)),
                    RSCAProcess.Create("Regulatory filings", new Guid(ARMHoldCoLegalCompliance.Legal)),
                    RSCAProcess.Create("Coordination of Boarding and Committee Meetings", new Guid(ARMHoldCoLegalCompliance.Legal)),
                    RSCAProcess.Create("Drafting of Minutes and other post meeting documents/Correspondence", new Guid(ARMHoldCoLegalCompliance.Legal)),
                    RSCAProcess.Create("General secretarial activities", new Guid(ARMHoldCoLegalCompliance.Legal)),

                    RSCAProcess.Create("Account Opening", new Guid(ARMHoldCoLegalCompliance.Compliance)),
                    RSCAProcess.Create("Filing of Regulatory Returns", new Guid(ARMHoldCoLegalCompliance.Compliance)),
                    RSCAProcess.Create("Due Diligence on Clients and Vendors", new Guid(ARMHoldCoLegalCompliance.Compliance)),
                    RSCAProcess.Create("SEC Registration of Sponsored individuals/Transfers and Applications", new Guid(ARMHoldCoLegalCompliance.Compliance)),
                    RSCAProcess.Create("Sanction Sceening on clients", new Guid(ARMHoldCoLegalCompliance.Compliance)),
            #endregion
            #region ARMHoldCoBackOfficeOperations Processes

                    RSCAProcess.Create("Stock & Institution creation, Issuer Creation, Mutual fund Creation", new Guid(ARMHoldCoBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Portfolio CSCS creation", new Guid(ARMHoldCoBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Bank statement upload on AMS and  Fund injection processing on Deluxe", new Guid(ARMHoldCoBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Foreign exchnage upload. Price and rates upload (Bloomberg prices, FMDQ, NGX, FMAN, NASD)", new Guid(ARMHoldCoBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Portfolio, Transactional client, Scheme  withdrwals", new Guid(ARMHoldCoBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Accounting unit postings / adjsutements", new Guid(ARMHoldCoBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Bank account mapping", new Guid(ARMHoldCoBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Portfolio creation, System bank account creation, Bank account mapping", new Guid(ARMHoldCoBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("RM creation and mapping ", new Guid(ARMHoldCoBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Fee set up and fee mapping", new Guid(ARMHoldCoBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Client creation and client mapping", new Guid(ARMHoldCoBackOfficeOperations.FundAccount)),

                    RSCAProcess.Create("Receipt of client instruction", new Guid(ARMHoldCoBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Receipt of share certificates and verification documents", new Guid(ARMHoldCoBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Inter-Member transfer request", new Guid(ARMHoldCoBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Unverified returned share certificates", new Guid(ARMHoldCoBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Corporate Action", new Guid(ARMHoldCoBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Dividend Settlement", new Guid(ARMHoldCoBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Portfolio stock reconciliation", new Guid(ARMHoldCoBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Transfer of portfolio to another party (broker)/Portfolio stock withdrawal", new Guid(ARMHoldCoBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Transfer of stocks between same client’s portfolios", new Guid(ARMHoldCoBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Custodian reconciliation", new Guid(ARMHoldCoBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Update of Instrument Information", new Guid(ARMHoldCoBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("MMF Quarterly Dividend Reinvestment", new Guid(ARMHoldCoBackOfficeOperations.FundAdmin)),

                    RSCAProcess.Create("Account Onboarding", new Guid(ARMHoldCoBackOfficeOperations.Register)),
                    RSCAProcess.Create("Redemption Processing - Verification (Mutual Fund)", new Guid(ARMHoldCoBackOfficeOperations.Register)),
                    RSCAProcess.Create("Withdrawal Processing (Portfolio Fund)", new Guid(ARMHoldCoBackOfficeOperations.Register)),
                    RSCAProcess.Create("Record Update", new Guid(ARMHoldCoBackOfficeOperations.Register)),
                    RSCAProcess.Create("Unit Transfer", new Guid(ARMHoldCoBackOfficeOperations.Register)),
                    RSCAProcess.Create("Standard Embassy Letter", new Guid(ARMHoldCoBackOfficeOperations.Register)),
                    RSCAProcess.Create("Estate Transmission - Letter of Administration / Probate", new Guid(ARMHoldCoBackOfficeOperations.Register)),
                    RSCAProcess.Create("Deactivation of Mobile Number Re-assigned to a Third Party", new Guid(ARMHoldCoBackOfficeOperations.Register)),
                    RSCAProcess.Create("Unclaimed Dividend Payment", new Guid(ARMHoldCoBackOfficeOperations.Register)),
                    RSCAProcess.Create("EOQ/Dividend Payment", new Guid(ARMHoldCoBackOfficeOperations.Register)),
                    RSCAProcess.Create("Change of Dividend Mandate", new Guid(ARMHoldCoBackOfficeOperations.Register)),
                    RSCAProcess.Create("NFIU Reporting", new Guid(ARMHoldCoBackOfficeOperations.Register)),
                    RSCAProcess.Create("Sanction Screening", new Guid(ARMHoldCoBackOfficeOperations.Register)),

                    RSCAProcess.Create("AMS pulls transactions from the Bank API", new Guid(ARMHoldCoBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("AMS automatch transactions with membership ID and integrates to NAV", new Guid(ARMHoldCoBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Manual matching of inflow into clients account", new Guid(ARMHoldCoBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Manual Collation of inflows and uploads into core application- NAV", new Guid(ARMHoldCoBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Posting of all matched subscription on NAV", new Guid(ARMHoldCoBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Posting of all verified redemptions and pass for payment", new Guid(ARMHoldCoBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Initiation of Intra-fund unit transfers", new Guid(ARMHoldCoBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Direct debit set up and Termination", new Guid(ARMHoldCoBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Posting of Buybacks", new Guid(ARMHoldCoBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Memo for Transfer of fund across Bank", new Guid(ARMHoldCoBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Goal-related Transactions", new Guid(ARMHoldCoBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Daily Movement of posted subscriptions at Bank(Cash Sweep)", new Guid(ARMHoldCoBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Daily Reconciliation of all Web transactions", new Guid(ARMHoldCoBackOfficeOperations.RetailOperations)),
            #endregion
            #region ARMHoldCoInformationTechnology Process
                RSCAProcess.Create("Systems Maintenance", new Guid(ARMHoldCoInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Applications Development/Enhancement", new Guid(ARMHoldCoInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Planning, Implementing and Closing IT Projects", new Guid(ARMHoldCoInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Data Backup", new Guid(ARMHoldCoInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Data Recovery Steps", new Guid(ARMHoldCoInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Simulating Disaster and Recovery", new Guid(ARMHoldCoInformationTechnology.InformationTechnology)),
            #endregion
            #region ARMHoldCoInternalControlInternalAudit Processes
                RSCAProcess.Create("Development of Annual Audit Plan (IA Plan)", new Guid(ARMHoldCoInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Audit Review", new Guid(ARMHoldCoInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Investigation", new Guid(ARMHoldCoInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Follow Up", new Guid(ARMHoldCoInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Operational Performance Rating", new Guid(ARMHoldCoInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Board Audit and Risk Management Committee (BARC) Reporting", new Guid(ARMHoldCoInternalControlInternalAudit.InternalAudit)),

                RSCAProcess.Create("Cash call-over", new Guid(ARMHoldCoInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Trade call-over", new Guid(ARMHoldCoInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Mutual Fund Pricing Review", new Guid(ARMHoldCoInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Institutional Fund Pricing Review", new Guid(ARMHoldCoInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Portfolio Stock Account Reconciliation", new Guid(ARMHoldCoInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Fixed Income Trade Review", new Guid(ARMHoldCoInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("BRD and UAT review", new Guid(ARMHoldCoInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("User Rights Access Mgt", new Guid(ARMHoldCoInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Statutory Remittance Review", new Guid(ARMHoldCoInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Daily Teams Call Over", new Guid(ARMHoldCoInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("CSCS Reconciliation", new Guid(ARMHoldCoInternalControlInternalAudit.InternalControl)),
            #endregion

            #region ARMTrusteesPrivateTrust Processes
                RSCAProcess.Create("Trust Client Acquisition", new Guid(ARMTrusteesPrivateTrust.PrivateTrust)),
                RSCAProcess.Create("Client Request Processing ", new Guid(ARMTrusteesPrivateTrust.PrivateTrust)),
                RSCAProcess.Create("Client Investment Monitoring", new Guid(ARMTrusteesPrivateTrust.PrivateTrust)),
                RSCAProcess.Create("Real estate asset management", new Guid(ARMTrusteesPrivateTrust.PrivateTrust)),
                RSCAProcess.Create("Business Development", new Guid(ARMTrusteesPrivateTrust.PrivateTrust)),
            #endregion
            #region ARMTrusteesRiskManagement Processes
                    RSCAProcess.Create("Risk event reporting on the oprisk manager", new Guid(ARMTrusteesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Loss Data Collection", new Guid(ARMTrusteesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("MRC Reporting", new Guid(ARMTrusteesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("RCSA Process", new Guid(ARMTrusteesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("ALCO Reporting", new Guid(ARMTrusteesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Risk Management Disclosures", new Guid(ARMTrusteesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("BARC Reporting", new Guid(ARMTrusteesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("MFIC Reporting", new Guid(ARMTrusteesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Fianacial Risk Review and Reporting", new Guid(ARMTrusteesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Pledge Review and Approval", new Guid(ARMTrusteesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("New Product Assessment", new Guid(ARMTrusteesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Counterparty Review and Assessment", new Guid(ARMTrusteesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Business Continuity Management Tests", new Guid(ARMTrusteesRiskManagement.RiskManagement)),

            #endregion
            #region ARMTrusteesCustomerExperience Processes
                RSCAProcess.Create("Mutual Funds Account Creation", new Guid(ARMTrusteesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Data Update", new Guid(ARMTrusteesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Embassy Letter", new Guid(ARMTrusteesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Unit Transfer", new Guid(ARMTrusteesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid(ARMTrusteesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Client Communications", new Guid(ARMTrusteesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Root Cause Analysis", new Guid(ARMTrusteesCustomerExperience.CustomerService)),

                RSCAProcess.Create("Mutual Funds Account Creation", new Guid(ARMTrusteesCustomerExperience.CallCenter)),
                RSCAProcess.Create("Data Update", new Guid(ARMTrusteesCustomerExperience.CallCenter)),
                RSCAProcess.Create("Embassy Letter", new Guid(ARMTrusteesCustomerExperience.CallCenter)),
                RSCAProcess.Create("Unit Transfer", new Guid(ARMTrusteesCustomerExperience.CallCenter)),
                RSCAProcess.Create("Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid(ARMTrusteesCustomerExperience.CallCenter)),
                RSCAProcess.Create("Client Communications", new Guid(ARMTrusteesCustomerExperience.CallCenter)),
                RSCAProcess.Create("Root Cause Analysis", new Guid(ARMTrusteesCustomerExperience.CallCenter)),
            #endregion
            #region ARMTrusteesCorporateStrategy Processes
                    RSCAProcess.Create("Corporate strategy development", new Guid(ARMTrusteesCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Business strategy articulataion", new Guid(ARMTrusteesCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Strategy revision", new Guid(ARMTrusteesCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Business strategy monitoring", new Guid(ARMTrusteesCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Quarterly performance review session", new Guid(ARMTrusteesCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Report preparation", new Guid(ARMTrusteesCorporateStrategy.CorporateStrategy)),

            #endregion
            #region ARMTrusteesLegalCompliance Processes
                    RSCAProcess.Create("Contract drafting and reviews", new Guid(ARMTrusteesLegalCompliance.Legal)),
                    RSCAProcess.Create("Drafting Embassy letters ", new Guid(ARMTrusteesLegalCompliance.Legal)),
                    RSCAProcess.Create("Legal Advisory", new Guid(ARMTrusteesLegalCompliance.Legal)),
                    RSCAProcess.Create("Regulatory filings", new Guid(ARMTrusteesLegalCompliance.Legal)),
                    RSCAProcess.Create("Coordination of Boarding and Committee Meetings", new Guid(ARMTrusteesLegalCompliance.Legal)),
                    RSCAProcess.Create("Drafting of Minutes and other post meeting documents/Correspondence", new Guid(ARMTrusteesLegalCompliance.Legal)),
                    RSCAProcess.Create("General secretarial activities", new Guid(ARMTrusteesLegalCompliance.Legal)),

                    RSCAProcess.Create("Account Opening", new Guid(ARMTrusteesLegalCompliance.Compliance)),
                    RSCAProcess.Create("Filing of Regulatory Returns", new Guid(ARMTrusteesLegalCompliance.Compliance)),
                    RSCAProcess.Create("Due Diligence on Clients and Vendors", new Guid(ARMTrusteesLegalCompliance.Compliance)),
                    RSCAProcess.Create("SEC Registration of Sponsored individuals/Transfers and Applications", new Guid(ARMTrusteesLegalCompliance.Compliance)),
                    RSCAProcess.Create("Sanction Sceening on clients", new Guid(ARMTrusteesLegalCompliance.Compliance)),
            #endregion
            #region ARMTrusteesBackOfficeOperations Processes

                    RSCAProcess.Create("Stock & Institution creation, Issuer Creation, Mutual fund Creation", new Guid(ARMTrusteesBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Portfolio CSCS creation", new Guid(ARMTrusteesBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Bank statement upload on AMS and  Fund injection processing on Deluxe", new Guid(ARMTrusteesBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Foreign exchnage upload. Price and rates upload (Bloomberg prices, FMDQ, NGX, FMAN, NASD)", new Guid(ARMTrusteesBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Portfolio, Transactional client, Scheme  withdrwals", new Guid(ARMTrusteesBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Accounting unit postings / adjsutements", new Guid(ARMTrusteesBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Bank account mapping", new Guid(ARMTrusteesBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Portfolio creation, System bank account creation, Bank account mapping", new Guid(ARMTrusteesBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("RM creation and mapping ", new Guid(ARMTrusteesBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Fee set up and fee mapping", new Guid(ARMTrusteesBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Client creation and client mapping", new Guid(ARMTrusteesBackOfficeOperations.FundAccount)),

                    RSCAProcess.Create("Receipt of client instruction", new Guid(ARMTrusteesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Receipt of share certificates and verification documents", new Guid(ARMTrusteesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Inter-Member transfer request", new Guid(ARMTrusteesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Unverified returned share certificates", new Guid(ARMTrusteesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Corporate Action", new Guid(ARMTrusteesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Dividend Settlement", new Guid(ARMTrusteesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Portfolio stock reconciliation", new Guid(ARMTrusteesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Transfer of portfolio to another party (broker)/Portfolio stock withdrawal", new Guid(ARMTrusteesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Transfer of stocks between same client’s portfolios", new Guid(ARMTrusteesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Custodian reconciliation", new Guid(ARMTrusteesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Update of Instrument Information", new Guid(ARMTrusteesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("MMF Quarterly Dividend Reinvestment", new Guid(ARMTrusteesBackOfficeOperations.FundAdmin)),

                    RSCAProcess.Create("Account Onboarding", new Guid(ARMTrusteesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Redemption Processing - Verification (Mutual Fund)", new Guid(ARMTrusteesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Withdrawal Processing (Portfolio Fund)", new Guid(ARMTrusteesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Record Update", new Guid(ARMTrusteesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Unit Transfer", new Guid(ARMTrusteesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Standard Embassy Letter", new Guid(ARMTrusteesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Estate Transmission - Letter of Administration / Probate", new Guid(ARMTrusteesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Deactivation of Mobile Number Re-assigned to a Third Party", new Guid(ARMTrusteesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Unclaimed Dividend Payment", new Guid(ARMTrusteesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("EOQ/Dividend Payment", new Guid(ARMTrusteesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Change of Dividend Mandate", new Guid(ARMHoldCoBackOfficeOperations.Register)),
                    RSCAProcess.Create("NFIU Reporting", new Guid(ARMTrusteesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Sanction Screening", new Guid(ARMTrusteesBackOfficeOperations.Registrars)),

                    RSCAProcess.Create("AMS pulls transactions from the Bank API", new Guid(ARMTrusteesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("AMS automatch transactions with membership ID and integrates to NAV", new Guid(ARMTrusteesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Manual matching of inflow into clients account", new Guid(ARMTrusteesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Manual Collation of inflows and uploads into core application- NAV", new Guid(ARMTrusteesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Posting of all matched subscription on NAV", new Guid(ARMTrusteesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Posting of all verified redemptions and pass for payment", new Guid(ARMTrusteesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Initiation of Intra-fund unit transfers", new Guid(ARMTrusteesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Direct debit set up and Termination", new Guid(ARMTrusteesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Posting of Buybacks", new Guid(ARMTrusteesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Memo for Transfer of fund across Bank", new Guid(ARMTrusteesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Goal-related Transactions", new Guid(ARMTrusteesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Daily Movement of posted subscriptions at Bank(Cash Sweep)", new Guid(ARMTrusteesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Daily Reconciliation of all Web transactions", new Guid(ARMTrusteesBackOfficeOperations.RetailOperations)),
            #endregion
            #region ARMTrusteesInformationTechnology Process
                RSCAProcess.Create("Systems Maintenance", new Guid(ARMTrusteesInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Applications Development/Enhancement", new Guid(ARMTrusteesInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Planning, Implementing and Closing IT Projects", new Guid(ARMTrusteesInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Data Backup", new Guid(ARMTrusteesInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Data Recovery Steps", new Guid(ARMTrusteesInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Simulating Disaster and Recovery", new Guid(ARMTrusteesInformationTechnology.InformationTechnology)),
            #endregion
            #region ARMTrusteesInternalControlInternalAudit Processes
                RSCAProcess.Create("Development of Annual Audit Plan (IA Plan)", new Guid(ARMTrusteesInternalControlAudit.InternalAudit)),
                RSCAProcess.Create("Audit Review", new Guid(ARMTrusteesInternalControlAudit.InternalAudit)),
                RSCAProcess.Create("Investigation", new Guid(ARMTrusteesInternalControlAudit.InternalAudit)),
                RSCAProcess.Create("Follow Up", new Guid(ARMTrusteesInternalControlAudit.InternalAudit)),
                RSCAProcess.Create("Operational Performance Rating", new Guid(ARMTrusteesInternalControlAudit.InternalAudit)),
                RSCAProcess.Create("Board Audit and Risk Management Committee (BARC) Reporting", new Guid(ARMTrusteesInternalControlAudit.InternalAudit)),

                RSCAProcess.Create("Cash call-over", new Guid(ARMTrusteesInternalControlAudit.InternalControl)),
                RSCAProcess.Create("Trade call-over", new Guid(ARMTrusteesInternalControlAudit.InternalControl)),
                RSCAProcess.Create("Mutual Fund Pricing Review", new Guid(ARMTrusteesInternalControlAudit.InternalControl)),
                RSCAProcess.Create("Institutional Fund Pricing Review", new Guid(ARMTrusteesInternalControlAudit.InternalControl)),
                RSCAProcess.Create("Portfolio Stock Account Reconciliation", new Guid(ARMTrusteesInternalControlAudit.InternalControl)),
                RSCAProcess.Create("Fixed Income Trade Review", new Guid(ARMTrusteesInternalControlAudit.InternalControl)),
                RSCAProcess.Create("BRD and UAT review", new Guid(ARMTrusteesInternalControlAudit.InternalControl)),
                RSCAProcess.Create("User Rights Access Mgt", new Guid(ARMTrusteesInternalControlAudit.InternalControl)),
                RSCAProcess.Create("Statutory Remittance Review", new Guid(ARMTrusteesInternalControlAudit.InternalControl)),
                RSCAProcess.Create("Daily Teams Call Over", new Guid(ARMTrusteesInternalControlAudit.InternalControl)),
                RSCAProcess.Create("CSCS Reconciliation", new Guid(ARMTrusteesInternalControlAudit.InternalControl)),
            #endregion

            #region ARMHarithInfracstrureInvestementLimitedCustomerExperience Processes
                RSCAProcess.Create("Mutual Funds Account Creation", new Guid(ARMHarithInfracstrureInvestementLimitedCustomerExperience.CustomerService)),
                RSCAProcess.Create("Data Update", new Guid(ARMHarithInfracstrureInvestementLimitedCustomerExperience.CustomerService)),
                RSCAProcess.Create("Embassy Letter", new Guid(ARMHarithInfracstrureInvestementLimitedCustomerExperience.CustomerService)),
                RSCAProcess.Create("Unit Transfer", new Guid(ARMHarithInfracstrureInvestementLimitedCustomerExperience.CustomerService)),
                RSCAProcess.Create("Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid(ARMHarithInfracstrureInvestementLimitedCustomerExperience.CustomerService)),
                RSCAProcess.Create("Client Communications", new Guid(ARMHarithInfracstrureInvestementLimitedCustomerExperience.CustomerService)),
                RSCAProcess.Create("Root Cause Analysis", new Guid(ARMHarithInfracstrureInvestementLimitedCustomerExperience.CustomerService)),

                RSCAProcess.Create("Mutual Funds Account Creation", new Guid(ARMHarithInfracstrureInvestementLimitedCustomerExperience.CallCentre)),
                RSCAProcess.Create("Data Update", new Guid(ARMHarithInfracstrureInvestementLimitedCustomerExperience.CallCentre)),
                RSCAProcess.Create("Embassy Letter", new Guid(ARMHarithInfracstrureInvestementLimitedCustomerExperience.CallCentre)),
                RSCAProcess.Create("Unit Transfer", new Guid(ARMHarithInfracstrureInvestementLimitedCustomerExperience.CallCentre)),
                RSCAProcess.Create("Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid(ARMHarithInfracstrureInvestementLimitedCustomerExperience.CallCentre)),
                RSCAProcess.Create("Client Communications", new Guid(ARMHarithInfracstrureInvestementLimitedCustomerExperience.CallCentre)),
                RSCAProcess.Create("Root Cause Analysis", new Guid(ARMHarithInfracstrureInvestementLimitedCustomerExperience.CallCentre)),
            #endregion
            #region ARMHarithInfracstrureInvestementLimitedRiskManagement Processes
                    RSCAProcess.Create("Risk event reporting on the oprisk manager", new Guid(ARMHarithInfracstrureInvestementLimitedRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Loss Data Collection", new Guid(ARMHarithInfracstrureInvestementLimitedRiskManagement.RiskManagement)),
                    RSCAProcess.Create("MRC Reporting", new Guid(ARMHarithInfracstrureInvestementLimitedRiskManagement.RiskManagement)),
                    RSCAProcess.Create("RCSA Process", new Guid(ARMHarithInfracstrureInvestementLimitedRiskManagement.RiskManagement)),
                    RSCAProcess.Create("ALCO Reporting", new Guid(ARMHarithInfracstrureInvestementLimitedRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Risk Management Disclosures", new Guid(ARMHarithInfracstrureInvestementLimitedRiskManagement.RiskManagement)),
                    RSCAProcess.Create("BARC Reporting", new Guid(ARMHarithInfracstrureInvestementLimitedRiskManagement.RiskManagement)),
                    RSCAProcess.Create("MFIC Reporting", new Guid(ARMHarithInfracstrureInvestementLimitedRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Fianacial Risk Review and Reporting", new Guid(ARMHarithInfracstrureInvestementLimitedRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Pledge Review and Approval", new Guid(ARMHarithInfracstrureInvestementLimitedRiskManagement.RiskManagement)),
                    RSCAProcess.Create("New Product Assessment", new Guid(ARMHarithInfracstrureInvestementLimitedRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Counterparty Review and Assessment", new Guid(ARMHarithInfracstrureInvestementLimitedRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Business Continuity Management Tests", new Guid(ARMHarithInfracstrureInvestementLimitedRiskManagement.RiskManagement)),
            #endregion
            #region ARMHarithInfracstrureInvestementLimitedInformationTechnology Process
                RSCAProcess.Create("Systems Maintenance", new Guid(ARMHarithInfracstrureInvestementLimitedInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Applications Development/Enhancement", new Guid(ARMHarithInfracstrureInvestementLimitedInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Planning, Implementing and Closing IT Projects", new Guid(ARMHarithInfracstrureInvestementLimitedInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Data Backup", new Guid(ARMHarithInfracstrureInvestementLimitedInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Data Recovery Steps", new Guid(ARMHarithInfracstrureInvestementLimitedInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Simulating Disaster and Recovery", new Guid(ARMHarithInfracstrureInvestementLimitedInformationTechnology.InformationTechnology)),
            #endregion
            #region ARMHarithInfracstrureInvestementLimitedCorporateStrategy Processes
                    RSCAProcess.Create("Corporate strategy development", new Guid(ARMHarithInfracstrureInvestementLimitedCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Business strategy articulataion", new Guid(ARMHarithInfracstrureInvestementLimitedCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Strategy revision", new Guid(ARMHarithInfracstrureInvestementLimitedCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Business strategy monitoring", new Guid(ARMHarithInfracstrureInvestementLimitedCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Quarterly performance review session", new Guid(ARMHarithInfracstrureInvestementLimitedCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Report preparation", new Guid(ARMHarithInfracstrureInvestementLimitedCorporateStrategy.CorporateStrategy)),

            #endregion
            #region ARMHarithInfracstrureInvestementLimitedLegalCompliance Processes
                    RSCAProcess.Create("Contract drafting and reviews", new Guid(ARMHarithInfracstrureInvestementLimitedLegalCompliance.Legal)),
                    RSCAProcess.Create("Drafting Embassy letters ", new Guid(ARMHarithInfracstrureInvestementLimitedLegalCompliance.Legal)),
                    RSCAProcess.Create("Legal Advisory", new Guid(ARMHarithInfracstrureInvestementLimitedLegalCompliance.Legal)),
                    RSCAProcess.Create("Regulatory filings", new Guid(ARMHarithInfracstrureInvestementLimitedLegalCompliance.Legal)),
                    RSCAProcess.Create("Coordination of Boarding and Committee Meetings", new Guid(ARMHarithInfracstrureInvestementLimitedLegalCompliance.Legal)),
                    RSCAProcess.Create("Drafting of Minutes and other post meeting documents/Correspondence", new Guid(ARMHarithInfracstrureInvestementLimitedLegalCompliance.Legal)),
                    RSCAProcess.Create("General secretarial activities", new Guid(ARMHarithInfracstrureInvestementLimitedLegalCompliance.Legal)),

                    RSCAProcess.Create("Account Opening", new Guid(ARMHarithInfracstrureInvestementLimitedLegalCompliance.Compliance)),
                    RSCAProcess.Create("Filing of Regulatory Returns", new Guid(ARMHarithInfracstrureInvestementLimitedLegalCompliance.Compliance)),
                    RSCAProcess.Create("Due Diligence on Clients and Vendors", new Guid(ARMHarithInfracstrureInvestementLimitedLegalCompliance.Compliance)),
                    RSCAProcess.Create("SEC Registration of Sponsored individuals/Transfers and Applications", new Guid(ARMHarithInfracstrureInvestementLimitedLegalCompliance.Compliance)),
                    RSCAProcess.Create("Sanction Sceening on clients", new Guid(ARMHarithInfracstrureInvestementLimitedLegalCompliance.Compliance)),
            #endregion
            #region ARMHarithInfracstrureInvestementLimitedInternalControlInternalAudit Processes
                RSCAProcess.Create("Development of Annual Audit Plan (IA Plan)", new Guid(ARMHarithInfracstrureInvestementLimitedInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Audit Review", new Guid(ARMHarithInfracstrureInvestementLimitedInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Investigation", new Guid(ARMHarithInfracstrureInvestementLimitedInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Follow Up", new Guid(ARMHarithInfracstrureInvestementLimitedInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Operational Performance Rating", new Guid(ARMHarithInfracstrureInvestementLimitedInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Board Audit and Risk Management Committee (BARC) Reporting", new Guid(ARMHarithInfracstrureInvestementLimitedInternalControlInternalAudit.InternalAudit)),

                RSCAProcess.Create("Cash call-over", new Guid(ARMHarithInfracstrureInvestementLimitedInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Trade call-over", new Guid(ARMHarithInfracstrureInvestementLimitedInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Mutual Fund Pricing Review", new Guid(ARMHarithInfracstrureInvestementLimitedInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Institutional Fund Pricing Review", new Guid(ARMHarithInfracstrureInvestementLimitedInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Portfolio Stock Account Reconciliation", new Guid(ARMHarithInfracstrureInvestementLimitedInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Fixed Income Trade Review", new Guid(ARMHarithInfracstrureInvestementLimitedInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("BRD and UAT review", new Guid(ARMHarithInfracstrureInvestementLimitedInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("User Rights Access Mgt", new Guid(ARMHarithInfracstrureInvestementLimitedInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Statutory Remittance Review", new Guid(ARMHarithInfracstrureInvestementLimitedInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Daily Teams Call Over", new Guid(ARMHarithInfracstrureInvestementLimitedInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("CSCS Reconciliation", new Guid(ARMHarithInfracstrureInvestementLimitedInternalControlInternalAudit.InternalControl)),
            #endregion

            #region SharedServicesCustomerExperience Processes
                RSCAProcess.Create("Mutual Funds Account Creation", new Guid(SharedServicesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Data Update", new Guid(SharedServicesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Embassy Letter", new Guid(SharedServicesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Unit Transfer", new Guid(SharedServicesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid(SharedServicesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Client Communications", new Guid(SharedServicesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Root Cause Analysis", new Guid(SharedServicesCustomerExperience.CustomerService)),

                RSCAProcess.Create("Mutual Funds Account Creation", new Guid(SharedServicesCustomerExperience.CallCentre)),
                RSCAProcess.Create("Data Update", new Guid(SharedServicesCustomerExperience.CallCentre)),
                RSCAProcess.Create("Embassy Letter", new Guid(SharedServicesCustomerExperience.CallCentre)),
                RSCAProcess.Create("Unit Transfer", new Guid(SharedServicesCustomerExperience.CallCentre)),
                RSCAProcess.Create("Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid(SharedServicesCustomerExperience.CallCentre)),
                RSCAProcess.Create("Client Communications", new Guid(SharedServicesCustomerExperience.CallCentre)),
                RSCAProcess.Create("Root Cause Analysis", new Guid(SharedServicesCustomerExperience.CallCentre)),
            #endregion
            #region SharedServicesRiskManagement Processes
                    RSCAProcess.Create("Risk event reporting on the oprisk manager", new Guid(SharedServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Loss Data Collection", new Guid(SharedServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("MRC Reporting", new Guid(SharedServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("RCSA Process", new Guid(SharedServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("ALCO Reporting", new Guid(SharedServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Risk Management Disclosures", new Guid(SharedServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("BARC Reporting", new Guid(SharedServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("MFIC Reporting", new Guid(SharedServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Fianacial Risk Review and Reporting", new Guid(SharedServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Pledge Review and Approval", new Guid(SharedServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("New Product Assessment", new Guid(SharedServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Counterparty Review and Assessment", new Guid(SharedServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Business Continuity Management Tests", new Guid(SharedServicesRiskManagement.RiskManagement)),
            #endregion
            #region SharedServicesInformationTechnology Processes
                RSCAProcess.Create("Systems Maintenance", new Guid(SharedServicesInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Applications Development/Enhancement", new Guid(SharedServicesInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Planning, Implementing and Closing IT Projects", new Guid(SharedServicesInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Data Backup", new Guid(SharedServicesInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Data Recovery Steps", new Guid(SharedServicesInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Simulating Disaster and Recovery", new Guid(SharedServicesInformationTechnology.InformationTechnology)),
            #endregion
            #region SharedServicesCorporateStrategy Processes
                    RSCAProcess.Create("Corporate strategy development", new Guid(SharedServicesCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Business strategy articulataion", new Guid(SharedServicesCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Strategy revision", new Guid(SharedServicesCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Business strategy monitoring", new Guid(SharedServicesCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Quarterly performance review session", new Guid(SharedServicesCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Report preparation", new Guid(SharedServicesCorporateStrategy.CorporateStrategy)),

            #endregion
            #region SharedServicesInternalControlInternalAudit Processes
                RSCAProcess.Create("Development of Annual Audit Plan (IA Plan)", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Audit Review", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Investigation", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Follow Up", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Operational Performance Rating", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Board Audit and Risk Management Committee (BARC) Reporting", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),

                RSCAProcess.Create("Cash call-over", new Guid(SharedServicesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Trade call-over", new Guid(SharedServicesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Mutual Fund Pricing Review", new Guid(SharedServicesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Institutional Fund Pricing Review", new Guid(SharedServicesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Portfolio Stock Account Reconciliation", new Guid(SharedServicesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Fixed Income Trade Review", new Guid(SharedServicesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("BRD and UAT review", new Guid(SharedServicesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("User Rights Access Mgt", new Guid(SharedServicesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Statutory Remittance Review", new Guid(SharedServicesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Daily Teams Call Over", new Guid(SharedServicesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("CSCS Reconciliation", new Guid(SharedServicesInternalControlInternalAudit.InternalControl)),
            #endregion
            #region SharedServicesLegalCompliance Processes
                RSCAProcess.Create("Contract drafting and reviews", new Guid(SharedServicesLegalCompliance.Legal)),
                    RSCAProcess.Create("Drafting Embassy letters ", new Guid(SharedServicesLegalCompliance.Legal)),
                    RSCAProcess.Create("Legal Advisory", new Guid(SharedServicesLegalCompliance.Legal)),
                    RSCAProcess.Create("Regulatory filings", new Guid(SharedServicesLegalCompliance.Legal)),
                    RSCAProcess.Create("Coordination of Boarding and Committee Meetings", new Guid(SharedServicesLegalCompliance.Legal)),
                    RSCAProcess.Create("Drafting of Minutes and other post meeting documents/Correspondence", new Guid(SharedServicesLegalCompliance.Legal)),
                    RSCAProcess.Create("General secretarial activities", new Guid(SharedServicesLegalCompliance.Legal)),

                    RSCAProcess.Create("Account Opening", new Guid(SharedServicesLegalCompliance.Compliance)),
                    RSCAProcess.Create("Filing of Regulatory Returns", new Guid(SharedServicesLegalCompliance.Compliance)),
                    RSCAProcess.Create("Due Diligence on Clients and Vendors", new Guid(SharedServicesLegalCompliance.Compliance)),
                    RSCAProcess.Create("SEC Registration of Sponsored individuals/Transfers and Applications", new Guid(SharedServicesLegalCompliance.Compliance)),
                    RSCAProcess.Create("Sanction Sceening on clients", new Guid(SharedServicesLegalCompliance.Compliance)),
            #endregion
            #region SharedServicesMarketingandCorporateCommunications Processes
                    RSCAProcess.Create("Develop Marketing and Corporate Communication (external and internal)", new Guid(SharedServicesMarketingandCorporateCommunications.MarketingandCorporateCommunications)),
                    RSCAProcess.Create("Production of Branded Materials", new Guid(SharedServicesMarketingandCorporateCommunications.MarketingandCorporateCommunications)),
                    RSCAProcess.Create("Web Development /Update (this is the process of developing or updating web pages)", new Guid(SharedServicesMarketingandCorporateCommunications.MarketingandCorporateCommunications)),
                    RSCAProcess.Create("CSR Evaluation & Sponsorshp Selection Process", new Guid(SharedServicesMarketingandCorporateCommunications.MarketingandCorporateCommunications)),
            #endregion
            #region SharedServicesFinanceTreasury Processes
                    RSCAProcess.Create("Budget and Planning", new Guid(SharedServicesFinanceTreasury.FinancialControl)),
                    RSCAProcess.Create("Bank Reconciliation", new Guid(SharedServicesFinanceTreasury.FinancialControl)),
                    RSCAProcess.Create("Create Asset Master Data", new Guid(SharedServicesFinanceTreasury.FinancialControl)),
                    RSCAProcess.Create("Asset Disposal", new Guid(SharedServicesFinanceTreasury.FinancialControl)),
                    RSCAProcess.Create("Invoicing", new Guid(SharedServicesFinanceTreasury.FinancialControl)),
                    RSCAProcess.Create("Process Payments", new Guid(SharedServicesFinanceTreasury.FinancialControl)),
                    RSCAProcess.Create("Cash Advance and Cash Advance Retirement", new Guid(SharedServicesFinanceTreasury.FinancialControl)),
                    RSCAProcess.Create("Reimbursements", new Guid(SharedServicesFinanceTreasury.FinancialControl)),
                    RSCAProcess.Create("Investor Notes Reconciliation", new Guid(SharedServicesFinanceTreasury.FinancialControl)),
            #endregion
            #region SharedServicesHumanCapitalManagement Processes
                    RSCAProcess.Create("STAFF DISCIPLINARY ISSUES", new Guid(SharedServicesHumanCapitalManagement.HumanCapitalManagement)),
                    RSCAProcess.Create("TOTAL REWARDS", new Guid(SharedServicesHumanCapitalManagement.HumanCapitalManagement)),
                    RSCAProcess.Create("STAFF FILE", new Guid(SharedServicesHumanCapitalManagement.HumanCapitalManagement)),
                    RSCAProcess.Create("PERFORMANCE APPRAISAL", new Guid(SharedServicesHumanCapitalManagement.HumanCapitalManagement)),
                    RSCAProcess.Create("HMO MANAGEMENT", new Guid(SharedServicesHumanCapitalManagement.HumanCapitalManagement)),
                    RSCAProcess.Create("TALENT ACQUISITION AND ORGANIZATIONAL DEVELOPMENT", new Guid(SharedServicesHumanCapitalManagement.HumanCapitalManagement)),
                    RSCAProcess.Create("STATUTORY DEDUCTIONS", new Guid(SharedServicesHumanCapitalManagement.HumanCapitalManagement)),
            #endregion

            #region ARMAgricbusinessARMAgricbusinessFundManagerLtd
                    RSCAProcess.Create("Staff and Visitors Identification", new Guid(ARMAgriBusinessARMAgricbusinessFundManagerLtd.RFL)),
                    RSCAProcess.Create("Staff Sign-in/attendance management", new Guid(ARMAgriBusinessARMAgricbusinessFundManagerLtd.RFL)),
                    RSCAProcess.Create("Keys Management", new Guid(ARMAgriBusinessARMAgricbusinessFundManagerLtd.RFL)),
                    RSCAProcess.Create("Scrutiny of all entrants", new Guid(ARMAgriBusinessARMAgricbusinessFundManagerLtd.RFL)),
                    RSCAProcess.Create("Cold Room Management", new Guid(ARMAgriBusinessARMAgricbusinessFundManagerLtd.RFL)),
                    RSCAProcess.Create("Dispensed goods Invoice", new Guid(ARMAgriBusinessARMAgricbusinessFundManagerLtd.RFL)),
                    RSCAProcess.Create("Goods received register", new Guid(ARMAgriBusinessARMAgricbusinessFundManagerLtd.RFL)),
                    RSCAProcess.Create("Community Relationships and Development", new Guid(ARMAgriBusinessARMAgricbusinessFundManagerLtd.RFL)),
                    RSCAProcess.Create("Procurement of Supplies and Inventory Update", new Guid(ARMAgriBusinessARMAgricbusinessFundManagerLtd.RFL)),
                    RSCAProcess.Create("Store inventory management", new Guid(ARMAgriBusinessARMAgricbusinessFundManagerLtd.RFL)),
                    RSCAProcess.Create("Requisition Invoice", new Guid(ARMAgriBusinessARMAgricbusinessFundManagerLtd.RFL)),
                    RSCAProcess.Create("Store key management", new Guid(ARMAgriBusinessARMAgricbusinessFundManagerLtd.RFL)),
            #endregion
            #region ARMAgriBusinessRiskManagement Processes
                    RSCAProcess.Create("Risk event reporting on the oprisk manager", new Guid(ARMAgriBusinessRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Loss Data Collection", new Guid(ARMAgriBusinessRiskManagement.RiskManagement)),
                    RSCAProcess.Create("MRC Reporting", new Guid(ARMAgriBusinessRiskManagement.RiskManagement)),
                    RSCAProcess.Create("RCSA Process", new Guid(ARMAgriBusinessRiskManagement.RiskManagement)),
                    RSCAProcess.Create("ALCO Reporting", new Guid(ARMAgriBusinessRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Risk Management Disclosures", new Guid(ARMAgriBusinessRiskManagement.RiskManagement)),
                    RSCAProcess.Create("BARC Reporting", new Guid(ARMAgriBusinessRiskManagement.RiskManagement)),
                    RSCAProcess.Create("MFIC Reporting", new Guid(ARMAgriBusinessRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Fianacial Risk Review and Reporting", new Guid(ARMAgriBusinessRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Pledge Review and Approval", new Guid(ARMAgriBusinessRiskManagement.RiskManagement)),
                    RSCAProcess.Create("New Product Assessment", new Guid(ARMAgriBusinessRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Counterparty Review and Assessment", new Guid(ARMAgriBusinessRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Business Continuity Management Tests", new Guid(ARMAgriBusinessRiskManagement.RiskManagement)),
            #endregion
            #region ARMAgriBusinessInformationTechnology Processes
                RSCAProcess.Create("Systems Maintenance", new Guid(ARMAgriBusinessInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Applications Development/Enhancement", new Guid(ARMAgriBusinessInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Planning, Implementing and Closing IT Projects", new Guid(ARMAgriBusinessInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Data Backup", new Guid(ARMAgriBusinessInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Data Recovery Steps", new Guid(ARMAgriBusinessInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Simulating Disaster and Recovery", new Guid(ARMAgriBusinessInformationTechnology.InformationTechnology)),
            #endregion
            #region ARMAgriBusinessCorporateStrategy Processes
                    RSCAProcess.Create("Corporate strategy development", new Guid(ARMAgriBusinessCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Business strategy articulataion", new Guid(ARMAgriBusinessCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Strategy revision", new Guid(ARMAgriBusinessCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Business strategy monitoring", new Guid(ARMAgriBusinessCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Quarterly performance review session", new Guid(ARMAgriBusinessCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Report preparation", new Guid(ARMAgriBusinessCorporateStrategy.CorporateStrategy)),

            #endregion
            #region ARMAgriBusinessInternalControlInternalAudit Processes
                RSCAProcess.Create("Development of Annual Audit Plan (IA Plan)", new Guid(ARMAgriBusinessInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Audit Review", new Guid(ARMAgriBusinessInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Investigation", new Guid(ARMAgriBusinessInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Follow Up", new Guid(ARMAgriBusinessInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Operational Performance Rating", new Guid(ARMAgriBusinessInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Board Audit and Risk Management Committee (BARC) Reporting", new Guid(ARMAgriBusinessInternalControlInternalAudit.InternalAudit)),

                RSCAProcess.Create("Cash call-over", new Guid(ARMAgriBusinessInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Trade call-over", new Guid(ARMAgriBusinessInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Mutual Fund Pricing Review", new Guid(ARMAgriBusinessInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Institutional Fund Pricing Review", new Guid(ARMAgriBusinessInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Portfolio Stock Account Reconciliation", new Guid(ARMAgriBusinessInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Fixed Income Trade Review", new Guid(ARMAgriBusinessInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("BRD and UAT review", new Guid(ARMAgriBusinessInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("User Rights Access Mgt", new Guid(ARMAgriBusinessInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Statutory Remittance Review", new Guid(ARMAgriBusinessInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Daily Teams Call Over", new Guid(ARMAgriBusinessInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("CSCS Reconciliation", new Guid(ARMAgriBusinessInternalControlInternalAudit.InternalControl)),
            #endregion
            #region ARMAgriBusinessLegalCompliance Processes
                RSCAProcess.Create("Contract drafting and reviews", new Guid(ARMAgriBusinessLegalCompliance.Legal)),
                    RSCAProcess.Create("Drafting Embassy letters ", new Guid(ARMAgriBusinessLegalCompliance.Legal)),
                    RSCAProcess.Create("Legal Advisory", new Guid(ARMAgriBusinessLegalCompliance.Legal)),
                    RSCAProcess.Create("Regulatory filings", new Guid(ARMAgriBusinessLegalCompliance.Legal)),
                    RSCAProcess.Create("Coordination of Boarding and Committee Meetings", new Guid(ARMAgriBusinessLegalCompliance.Legal)),
                    RSCAProcess.Create("Drafting of Minutes and other post meeting documents/Correspondence", new Guid(ARMAgriBusinessLegalCompliance.Legal)),
                    RSCAProcess.Create("General secretarial activities", new Guid(ARMAgriBusinessLegalCompliance.Legal)),

                    RSCAProcess.Create("Account Opening", new Guid(ARMAgriBusinessLegalCompliance.Compliance)),
                    RSCAProcess.Create("Filing of Regulatory Returns", new Guid(ARMAgriBusinessLegalCompliance.Compliance)),
                    RSCAProcess.Create("Due Diligence on Clients and Vendors", new Guid(ARMAgriBusinessLegalCompliance.Compliance)),
                    RSCAProcess.Create("SEC Registration of Sponsored individuals/Transfers and Applications", new Guid(ARMAgriBusinessLegalCompliance.Compliance)),
                    RSCAProcess.Create("Sanction Sceening on clients", new Guid(ARMAgriBusinessLegalCompliance.Compliance)),
            #endregion

            #region MixtaNigeriaRiskManagement Processes
                    RSCAProcess.Create("Risk event reporting on the oprisk manager", new Guid(MixtaNigeriaRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Loss Data Collection", new Guid(MixtaNigeriaRiskManagement.RiskManagement)),
                    RSCAProcess.Create("MRC Reporting", new Guid(MixtaNigeriaRiskManagement.RiskManagement)),
                    RSCAProcess.Create("RCSA Process", new Guid(MixtaNigeriaRiskManagement.RiskManagement)),
                    RSCAProcess.Create("ALCO Reporting", new Guid(MixtaNigeriaRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Risk Management Disclosures", new Guid(MixtaNigeriaRiskManagement.RiskManagement)),
                    RSCAProcess.Create("BARC Reporting", new Guid(MixtaNigeriaRiskManagement.RiskManagement)),
                    RSCAProcess.Create("MFIC Reporting", new Guid(MixtaNigeriaRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Fianacial Risk Review and Reporting", new Guid(MixtaNigeriaRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Pledge Review and Approval", new Guid(MixtaNigeriaRiskManagement.RiskManagement)),
                    RSCAProcess.Create("New Product Assessment", new Guid(MixtaNigeriaRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Counterparty Review and Assessment", new Guid(MixtaNigeriaRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Business Continuity Management Tests", new Guid(MixtaNigeriaRiskManagement.RiskManagement)),
            #endregion
            #region MixtaNigeriaInformationTechnology Processes
                RSCAProcess.Create("Systems Maintenance", new Guid(MixtaNigeriaInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Applications Development/Enhancement", new Guid(MixtaNigeriaInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Planning, Implementing and Closing IT Projects", new Guid(MixtaNigeriaInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Data Backup", new Guid(MixtaNigeriaInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Data Recovery Steps", new Guid(MixtaNigeriaInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Simulating Disaster and Recovery", new Guid(MixtaNigeriaInformationTechnology.InformationTechnology)),
            #endregion
            #region MixtaNigeriaCorporateStrategy Processes
                    RSCAProcess.Create("Corporate strategy development", new Guid(MixtaNigeriaCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Business strategy articulataion", new Guid(MixtaNigeriaCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Strategy revision", new Guid(MixtaNigeriaCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Business strategy monitoring", new Guid(MixtaNigeriaCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Quarterly performance review session", new Guid(MixtaNigeriaCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Report preparation", new Guid(MixtaNigeriaCorporateStrategy.CorporateStrategy)),

            #endregion
            #region MixtaNigeriaInternalControlInternalAudit Processes
                RSCAProcess.Create("Development of Annual Audit Plan (IA Plan)", new Guid(MixtaNigeriaInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Audit Review", new Guid(MixtaNigeriaInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Investigation", new Guid(MixtaNigeriaInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Follow Up", new Guid(MixtaNigeriaInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Operational Performance Rating", new Guid(MixtaNigeriaInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Board Audit and Risk Management Committee (BARC) Reporting", new Guid(MixtaNigeriaInternalControlInternalAudit.InternalAudit)),

                RSCAProcess.Create("Cash call-over", new Guid(MixtaNigeriaInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Trade call-over", new Guid(MixtaNigeriaInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Mutual Fund Pricing Review", new Guid(MixtaNigeriaInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Institutional Fund Pricing Review", new Guid(MixtaNigeriaInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Portfolio Stock Account Reconciliation", new Guid(MixtaNigeriaInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Fixed Income Trade Review", new Guid(MixtaNigeriaInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("BRD and UAT review", new Guid(MixtaNigeriaInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("User Rights Access Mgt", new Guid(MixtaNigeriaInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Statutory Remittance Review", new Guid(MixtaNigeriaInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Daily Teams Call Over", new Guid(MixtaNigeriaInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("CSCS Reconciliation", new Guid(MixtaNigeriaInternalControlInternalAudit.InternalControl)),
            #endregion
            #region MixtaNigeriaLegalCompliance Processes
                RSCAProcess.Create("Contract drafting and reviews", new Guid(MixtaNigeriaLegalCompliance.Legal)),
                    RSCAProcess.Create("Drafting Embassy letters ", new Guid(MixtaNigeriaLegalCompliance.Legal)),
                    RSCAProcess.Create("Legal Advisory", new Guid(MixtaNigeriaLegalCompliance.Legal)),
                    RSCAProcess.Create("Regulatory filings", new Guid(MixtaNigeriaLegalCompliance.Legal)),
                    RSCAProcess.Create("Coordination of Boarding and Committee Meetings", new Guid(MixtaNigeriaLegalCompliance.Legal)),
                    RSCAProcess.Create("Drafting of Minutes and other post meeting documents/Correspondence", new Guid(MixtaNigeriaLegalCompliance.Legal)),
                    RSCAProcess.Create("General secretarial activities", new Guid(MixtaNigeriaLegalCompliance.Legal)),

                    RSCAProcess.Create("Account Opening", new Guid(MixtaNigeriaLegalCompliance.Compliance)),
                    RSCAProcess.Create("Filing of Regulatory Returns", new Guid(MixtaNigeriaLegalCompliance.Compliance)),
                    RSCAProcess.Create("Due Diligence on Clients and Vendors", new Guid(MixtaNigeriaLegalCompliance.Compliance)),
                    RSCAProcess.Create("SEC Registration of Sponsored individuals/Transfers and Applications", new Guid(MixtaNigeriaLegalCompliance.Compliance)),
                    RSCAProcess.Create("Sanction Sceening on clients", new Guid(MixtaNigeriaLegalCompliance.Compliance)),
            #endregion

            #region ARMDigitalFinancialServicesRiskManagement Processes
                    RSCAProcess.Create("Risk event reporting on the oprisk manager", new Guid(ARMDigitalFinancialServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Loss Data Collection", new Guid(ARMDigitalFinancialServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("MRC Reporting", new Guid(ARMDigitalFinancialServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("RCSA Process", new Guid(ARMDigitalFinancialServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("ALCO Reporting", new Guid(ARMDigitalFinancialServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Risk Management Disclosures", new Guid(ARMDigitalFinancialServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("BARC Reporting", new Guid(ARMDigitalFinancialServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("MFIC Reporting", new Guid(ARMDigitalFinancialServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Fianacial Risk Review and Reporting", new Guid(ARMDigitalFinancialServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Pledge Review and Approval", new Guid(ARMDigitalFinancialServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("New Product Assessment", new Guid(ARMDigitalFinancialServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Counterparty Review and Assessment", new Guid(ARMDigitalFinancialServicesRiskManagement.RiskManagement)),
                    RSCAProcess.Create("Business Continuity Management Tests", new Guid(ARMDigitalFinancialServicesRiskManagement.RiskManagement)),
            #endregion
            #region ARMDigitalFinancialServicesCorporateStrategy Processes
                    RSCAProcess.Create("Corporate strategy development", new Guid(ARMDigitalFinancialServicesCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Business strategy articulataion", new Guid(ARMDigitalFinancialServicesCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Strategy revision", new Guid(ARMDigitalFinancialServicesCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Business strategy monitoring", new Guid(ARMDigitalFinancialServicesCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Quarterly performance review session", new Guid(ARMDigitalFinancialServicesCorporateStrategy.CorporateStrategy)),
                    RSCAProcess.Create("Report preparation", new Guid(ARMDigitalFinancialServicesCorporateStrategy.CorporateStrategy)),

            #endregion
            #region ARMDigitalFinancialServicesCustomerExperience Processes
                RSCAProcess.Create("Mutual Funds Account Creation", new Guid(ARMDigitalFinancialServicesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Data Update", new Guid(ARMDigitalFinancialServicesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Embassy Letter", new Guid(ARMDigitalFinancialServicesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Unit Transfer", new Guid(ARMDigitalFinancialServicesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid(ARMDigitalFinancialServicesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Client Communications", new Guid(ARMDigitalFinancialServicesCustomerExperience.CustomerService)),
                RSCAProcess.Create("Root Cause Analysis", new Guid(ARMDigitalFinancialServicesCustomerExperience.CustomerService)),

                RSCAProcess.Create("Mutual Funds Account Creation", new Guid(ARMDigitalFinancialServicesCustomerExperience.CallCentre)),
                RSCAProcess.Create("Data Update", new Guid(ARMDigitalFinancialServicesCustomerExperience.CallCentre)),
                RSCAProcess.Create("Embassy Letter", new Guid(ARMDigitalFinancialServicesCustomerExperience.CallCentre)),
                RSCAProcess.Create("Unit Transfer", new Guid(ARMDigitalFinancialServicesCustomerExperience.CallCentre)),
                RSCAProcess.Create("Processing Client Requests, complaints and enquiries (Walk-in, phone and emails)", new Guid(ARMDigitalFinancialServicesCustomerExperience.CallCentre)),
                RSCAProcess.Create("Client Communications", new Guid(ARMDigitalFinancialServicesCustomerExperience.CallCentre)),
                RSCAProcess.Create("Root Cause Analysis", new Guid(ARMDigitalFinancialServicesCustomerExperience.CallCentre)),
            #endregion
            #region ARMDigitalFinancialServicesLegalCompliance Processes
                    RSCAProcess.Create("Contract drafting and reviews", new Guid(ARMDigitalFinancialServicesLegalCompliance.Legal)),
                    RSCAProcess.Create("Drafting Embassy letters ", new Guid(ARMDigitalFinancialServicesLegalCompliance.Legal)),
                    RSCAProcess.Create("Legal Advisory", new Guid(ARMDigitalFinancialServicesLegalCompliance.Legal)),
                    RSCAProcess.Create("Regulatory filings", new Guid(ARMDigitalFinancialServicesLegalCompliance.Legal)),
                    RSCAProcess.Create("Coordination of Boarding and Committee Meetings", new Guid(ARMDigitalFinancialServicesLegalCompliance.Legal)),
                    RSCAProcess.Create("Drafting of Minutes and other post meeting documents/Correspondence", new Guid(ARMDigitalFinancialServicesLegalCompliance.Legal)),
                    RSCAProcess.Create("General secretarial activities", new Guid(ARMDigitalFinancialServicesLegalCompliance.Legal)),

                    RSCAProcess.Create("Account Opening", new Guid(ARMDigitalFinancialServicesLegalCompliance.Compliance)),
                    RSCAProcess.Create("Filing of Regulatory Returns", new Guid(ARMDigitalFinancialServicesLegalCompliance.Compliance)),
                    RSCAProcess.Create("Due Diligence on Clients and Vendors", new Guid(ARMDigitalFinancialServicesLegalCompliance.Compliance)),
                    RSCAProcess.Create("SEC Registration of Sponsored individuals/Transfers and Applications", new Guid(ARMDigitalFinancialServicesLegalCompliance.Compliance)),
                    RSCAProcess.Create("Sanction Sceening on clients", new Guid(ARMDigitalFinancialServicesLegalCompliance.Compliance)),
            #endregion
            #region ARMDigitalFinancialServicesBackOfficeOperations Processes

                    RSCAProcess.Create("Stock & Institution creation, Issuer Creation, Mutual fund Creation", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Portfolio CSCS creation", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Bank statement upload on AMS and  Fund injection processing on Deluxe", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Foreign exchnage upload. Price and rates upload (Bloomberg prices, FMDQ, NGX, FMAN, NASD)", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Portfolio, Transactional client, Scheme  withdrwals", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Accounting unit postings / adjsutements", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Bank account mapping", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Portfolio creation, System bank account creation, Bank account mapping", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("RM creation and mapping ", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Fee set up and fee mapping", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAccount)),
                    RSCAProcess.Create("Client creation and client mapping", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAccount)),

                    RSCAProcess.Create("Receipt of client instruction", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Receipt of share certificates and verification documents", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Inter-Member transfer request", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Unverified returned share certificates", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Corporate Action", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Dividend Settlement", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Portfolio stock reconciliation", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Transfer of portfolio to another party (broker)/Portfolio stock withdrawal", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Transfer of stocks between same client’s portfolios", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Custodian reconciliation", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("Update of Instrument Information", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAdmin)),
                    RSCAProcess.Create("MMF Quarterly Dividend Reinvestment", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAdmin)),

                    RSCAProcess.Create("Account Onboarding", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Redemption Processing - Verification (Mutual Fund)", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Withdrawal Processing (Portfolio Fund)", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Record Update", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Unit Transfer", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Standard Embassy Letter", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Estate Transmission - Letter of Administration / Probate", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Deactivation of Mobile Number Re-assigned to a Third Party", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Unclaimed Dividend Payment", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("EOQ/Dividend Payment", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Change of Dividend Mandate", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("NFIU Reporting", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.Registrars)),
                    RSCAProcess.Create("Sanction Screening", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.Registrars)),

                    RSCAProcess.Create("AMS pulls transactions from the Bank API", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("AMS automatch transactions with membership ID and integrates to NAV", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Manual matching of inflow into clients account", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Manual Collation of inflows and uploads into core application- NAV", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Posting of all matched subscription on NAV", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Posting of all verified redemptions and pass for payment", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Initiation of Intra-fund unit transfers", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Direct debit set up and Termination", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Posting of Buybacks", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Memo for Transfer of fund across Bank", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Goal-related Transactions", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Daily Movement of posted subscriptions at Bank(Cash Sweep)", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.RetailOperations)),
                    RSCAProcess.Create("Daily Reconciliation of all Web transactions", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.RetailOperations)),
            #endregion
            #region ARMDigitalFinancialServicesInformationTechnology Process
                RSCAProcess.Create("Systems Maintenance", new Guid(ARMDigitalFinancialServicesInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Applications Development/Enhancement", new Guid(ARMDigitalFinancialServicesInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Planning, Implementing and Closing IT Projects", new Guid(ARMDigitalFinancialServicesInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Data Backup", new Guid(ARMDigitalFinancialServicesInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Data Recovery Steps", new Guid(ARMDigitalFinancialServicesInformationTechnology.InformationTechnology)),
                RSCAProcess.Create("Simulating Disaster and Recovery", new Guid(ARMDigitalFinancialServicesInformationTechnology.InformationTechnology)),
            #endregion
            #region ARMDigitalFinancialServicesInternalControlInternalAudit Processes
                RSCAProcess.Create("Development of Annual Audit Plan (IA Plan)", new Guid(ARMDigitalFinancialServicesInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Audit Review", new Guid(ARMDigitalFinancialServicesInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Investigation", new Guid(ARMDigitalFinancialServicesInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Follow Up", new Guid(ARMDigitalFinancialServicesInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Operational Performance Rating", new Guid(ARMDigitalFinancialServicesInternalControlInternalAudit.InternalAudit)),
                RSCAProcess.Create("Board Audit and Risk Management Committee (BARC) Reporting", new Guid(ARMDigitalFinancialServicesInternalControlInternalAudit.InternalAudit)),

                RSCAProcess.Create("Cash call-over", new Guid(ARMDigitalFinancialServicesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Trade call-over", new Guid(ARMDigitalFinancialServicesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Mutual Fund Pricing Review", new Guid(ARMDigitalFinancialServicesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Institutional Fund Pricing Review", new Guid(ARMDigitalFinancialServicesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Portfolio Stock Account Reconciliation", new Guid(ARMDigitalFinancialServicesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Fixed Income Trade Review", new Guid(ARMDigitalFinancialServicesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("BRD and UAT review", new Guid(ARMDigitalFinancialServicesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("User Rights Access Mgt", new Guid(ARMDigitalFinancialServicesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Statutory Remittance Review", new Guid(ARMDigitalFinancialServicesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("Daily Teams Call Over", new Guid(ARMDigitalFinancialServicesInternalControlInternalAudit.InternalControl)),
                RSCAProcess.Create("CSCS Reconciliation", new Guid(ARMDigitalFinancialServicesInternalControlInternalAudit.InternalControl)),
            #endregion

            #region ARMDigitalFinancialServicesDigitalFinancialServices Processes
                RSCAProcess.Create("Agile Delivery Process", new Guid(ARMDigitalFinancialServicesDigitalFinancialServices.DigitalFinancialServices)),
                RSCAProcess.Create("DEVOPs Operations (Deployment to Production)", new Guid(ARMDigitalFinancialServicesDigitalFinancialServices.DigitalFinancialServices)),
                RSCAProcess.Create("Functional Testing – User Acceptance Test", new Guid(ARMDigitalFinancialServicesDigitalFinancialServices.DigitalFinancialServices)),
                RSCAProcess.Create("Post Go Live Support", new Guid(ARMDigitalFinancialServicesDigitalFinancialServices.DigitalFinancialServices))
            #endregion
            );

        }
    }
}
