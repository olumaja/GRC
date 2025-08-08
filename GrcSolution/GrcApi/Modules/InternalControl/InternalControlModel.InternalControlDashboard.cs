using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain;
using GrcApi.Modules.InternalControl;

namespace Arm.GrcApi.Modules.InternalControl
{
    public enum InternalControlDashboardStatus
    {
        On_Hold = 1,
        Work_In_Progress,
        Completed        
    }

    public enum InternalControlDashboardActivityInterval
    {
        Daily = 1,
        Weekly,
        Monthly,
        Bi_Monthly,
        Quarterly,
        Others
    }

    public class InternalControlDashboard : AuditEntity2
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public InternalControlDashboardActivityInterval ActivityIntervals { get; private set; }
        public string Activity { get; private set; }
        public string Comment { get; private set; }
        public DateTime ProposedCompletionDate { get; private set; }
        public string ActionOwner { get; private set; }
        public string ActionOwnerEmail { get; private set; }
        public string? Remarks { get; private set; }
        public int? NumberOfTransactionsReviewed { get; private set; }
        public DateTime? NextNoficationDate { get; private set; }
        public bool ToTrigger { get; set; } = false;
        public InternalControlDashboardStatus Status { get; private set; } = InternalControlDashboardStatus.Work_In_Progress;
        public DateTime? DateTaskCompleted { get; private set; }
        public bool? IsDailyReminderSent { get; private set; }= false;
        public bool? IsWeeklyReminderSent { get; private set; }= false;
        public bool? IsMonthlyReminderSent { get; private set; }= false;

        public static InternalControlDashboard Create(CreateTask task)
        {
            return new InternalControlDashboard
            {
                ActivityIntervals = task.ActivityInterval,
                Activity = task.Activity,
                Comment = task.Comment,
                ProposedCompletionDate = task.CompletionDate,
                ActionOwner = task.ActionOwner,
                ActionOwnerEmail = task.ActionOwnerEmail,
                NextNoficationDate = task.NotificationDate
            };
        }
       
        public void UpdateStatus(UpdateControlDashboardStatusReq update)
        {
            Status = update.Status;
            Remarks = update.Remark;
            NumberOfTransactionsReviewed = update.NumberOfTransaction;

            if(update.Status == InternalControlDashboardStatus.Completed)
                DateTaskCompleted = DateTime.Now;
        }
      
        public void UpdateTask(UpdateInternalControlDashBoard update)
        {
            ActivityIntervals = update.ActivityInterval;
            Activity = update.Activity;
            ProposedCompletionDate = update.CompletionDate;
            ActionOwner = update.ActionOwner;
            ActionOwnerEmail = update.ActionOwnerEmail;
            Comment = update.Comment;
            NextNoficationDate = update.NotificationDate;
        }

        public void UpdateDailyReminder(bool status)
        {
            IsDailyReminderSent = status;           
        }
        public void UpdateWeeklyReminder(bool status)
        {
            IsWeeklyReminderSent = status;
        }

        public void UpdateMonthlyReminder(bool status)
        {
            IsMonthlyReminderSent = status;
        }
    }
}
