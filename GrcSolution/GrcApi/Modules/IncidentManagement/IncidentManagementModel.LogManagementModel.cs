using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GrcApi.Modules.IncidentManagement;
using System.ComponentModel;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    public enum LogMgtStatus
    {
        [Description("Open")] Open = 1,
        [Description("Work in progress")] Work_In_Progress,
        [Description("Rejected")] Rejected,
        [Description("Closed")] Closed
    }
    public enum LogType
    {       
        [Description("SIEM")] SIEM = 1,
        [Description("PAM")] PAM,
        [Description("FIM")] FIM,
        [Description("EDR")] EDR,
        [Description("DLP")] DLP,
        [Description("DAM")] DAM,
        [Description("CASP")] CASP
    }
   

    public class LogManagement : AuditEntity2
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public LogType LogType { get; private set; }
        public DateTime? DateAlertGenerated { get; private set; }
        public string? ActionownerName { get; private set; }
        public string? ActionownerEmailAddress { get; private set; }
        public string? EventName { get; private set; }
        public string? RequesterEmailAddress { get; private set; }
        public DateTime? ProposeEndDate { get; private set; }
        public string? ActionOwnerUnit { get; private set; }
        public LogMgtStatus Status { get; private set; } = LogMgtStatus.Open;
        public string? BusinessJustification { get; private set; }
        public string? UserApprovalObtained { get; private set; }
        public string? InfoSecRemarks { get; private set; }
        public string? ActionOwnerRemarks { get; private set; }
        public string? ReasonForRejection { get; private set; }
        public bool IsReminderSent1WkToProposedEndDate { get; private set; } = false;
        public bool IsReminderSent3DaysToProposedEndDate { get; private set; } = false;
        public bool IsReminderSent1DayToProposedEndDate { get; private set; } = false;
        public bool IsReminderSentOnTheProposedEndDate { get; private set; } = false;
        public CASPLog CASP { get; private set; }
        public DAMLog DAM { get; private set; }
        public DLPLog DLP { get; private set; }
        public EDRLog EDR { get; private set; }
        public FIMLog FIM { get; private set; }
        public PAMLog PAM { get; private set; }
        public SIEMLog SIEM { get; private set; }

        public static LogManagement CreateLogMgt(LogType logType, string eventName, DateTime? dateAlertWasGenerated, DateTime? proposeEndDate, 
            LogMgtStatus status, string remark, string requesterEmail, string? actionOwner, string? actionOwnerEmailAddress, string? actionOwnerUnit, string? businessJustification = null
        )
        {
            return new LogManagement
            {
                LogType = logType,
                EventName = eventName,
                DateAlertGenerated = dateAlertWasGenerated,
                BusinessJustification = businessJustification,
                ProposeEndDate = proposeEndDate,
                Status = status,
                InfoSecRemarks = remark,
                RequesterEmailAddress = requesterEmail,
                ActionownerName = actionOwner,
                ActionownerEmailAddress = actionOwnerEmailAddress,
                ActionOwnerUnit = actionOwnerUnit
            };
        }

        public void ActionOwnerFeedback(string? businessJustification, string? userApprovalObtained, string? remarks)
        {
            BusinessJustification = businessJustification;
            UserApprovalObtained = userApprovalObtained;
            ActionOwnerRemarks = remarks;
            Status = LogMgtStatus.Work_In_Progress;
        }
        public void InfoSecRespnse(LogMgtStatus status, string remark)
        {
            Status = status;
            ReasonForRejection = remark;
        }
        public void UpdateIsReminderSent1WkToProposedEndDate(bool status)
        {
            IsReminderSent1WkToProposedEndDate = status;
        }
        public void UpdateIsReminderSent3DaysToProposedEndDate(bool status)
        {
            IsReminderSent3DaysToProposedEndDate = status;
        }
        public void UpdateIsReminderSent1DayToProposedEndDate(bool status)
        {
            IsReminderSent1DayToProposedEndDate = status;
        }
        public void UpdateIsReminderSentOnTheProposedEndDate(bool status)
        {
            IsReminderSentOnTheProposedEndDate = status;
        }

    }
}
