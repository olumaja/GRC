namespace Arm.GrcApi.Modules.Shared
{
    public static class GRCConstants
    {
        public const string applicationOrJson = "application/json";
        public const string multipartOrFormData = "multipart/form-data";
    }

    public static class GRCToolsMessages
    {
        public const string InvalidCharacters = "{PropertyName} contains one or more special characters that are not allowed";
    }

    public static class GRCUserRole
    {
        public const string UnitHead = "UnitHead";
        public const string RiskChampion = "RiskChampion";
        public const string Admin = "Admin";
        public const string ComplianceOfficer = "ComplianceOfficer";
        public const string OtherComplianceUser = "OtherComplianceUser";
        public const string Staff = "Staff";
        public const string HROfficer = "HROfficer";
        public const string FINCON = "FINCON";
        public const string Treasury = "Treasury";
        public const string InternalAuditOfficer = "InternalAuditOfficer";
        public const string InternalAuditSupervisor = "InternalAuditSupervisor";
        public const string InternalControlOfficer = "InternalControlOfficer";
        public const string InternalControlSupervisor = "InternalControlSupervisor";
        public const string InternalControlCallOverOfficer = "InternalControlCallOverOfficer";
        public const string InternalControlCallOverSupervisor = "InternalControlCallOverSupervisor";
        public const string InternalAuditManagerConcern = "InternalAuditManagerConcern";
        public const string InternalAuditExecutiveManagerConcern = "InternalAuditExecutiveManagerConcern";
        public const string OperationControlSupervisor = "OperationControlSupervisor";
        public const string OperationControlOfficer = "OperationControlOfficer";
        public const string InternalAuditee = "InternalAuditee";
        public const string SuperAdmin = "SuperAdmin";
        public const string InfoSecOfficer = "InfoSec Officer";
        public const string InfoSecISORiskChampion = "InfoSec ISO Risk Champion";
        public const string InfoSecISOUnitHead = "InfoSec ISO Unit Head";
    }

    public class GRCModule
    {
        public const string RiskIdentification = "Risk Identification";
        public const string RCSA = "Risk Control Self Assessment";
        public const string PRA = "Product Risk Assessment";
        public const string BIA = "Business Impact Analysis";
        public const string ActionTracker = "Action Tracker";
        public const string CompliancePlanning = "Compliance Planning";
        public const string RegulatoryPayment = "Regulatory Payment";
        public const string StatutoryPayment = "Statutory Payment";
        public const string InternalControl = "Internal Control";
        public const string InternalControlException = "Internal Control - Exception";
        public const string InternalControlDashboard = "Internal Control - Dashboard";
        public const string InternalControlCallOver = "Internal Control - Call Over";
        public const string OperationControl = "Operation Control";
        public const string AuditReport = "Audit Report";
        public const string AuditPlan = "Audit Plan";
        public const string AuditExecution = "Audit Execution";
    }
}
