using System.ComponentModel;

namespace Arm.GrcTool.Infrastructure
{
    public enum ModuleType
    {
        [Description("Internal Audit")]InternalAudit,
        [Description("Risk Management")] RiskManagement,
        [Description("Compliance")] Compliance,
        [Description("Compliance Regulatory Payment")] ComplianceRegulatoryPayment,
        [Description("Compliance Statutory Payment HCM")] ComplianceStatutoryPaymentHCM,
        [Description("Compliance Statutory Payment PayingUnit")] ComplianceStatutoryPaymentPayingUnit,
        [Description("Compliance Statutory PaymentFINCON")] ComplianceStatutoryPaymentFINCON,
        [Description("Internal Control")] InternalControl,
        [Description("Internal Control ActionOwner")] InternalControlActionOwner,
        [Description("Internal Control CallOver")] InternalControlCallOver,
        [Description("Operation Control")] OperationControl,
        [Description("ActionOwner Operation Control")] ActionOwnerOperationControl,
        [Description("Operation Performance Report")] OperationPerformanceReport,
        [Description("Information Security")] InformationSecurity,
        [Description("Information Security Internal Vulnerability")] InfoSecInternalVulnerability,
        [Description("Information Security Anti-virus Inactive Sensor")] InfoSecAntivirusInactiveSensor,
        [Description("Information Security Anti-virus Reduce Functionality Mode")] InfoSecAntivirusReduceFunctionality,
        [Description("Information Security ISO Risk Champion Assessment")] InfoSecISORiskChampionAssessment
    }
}
