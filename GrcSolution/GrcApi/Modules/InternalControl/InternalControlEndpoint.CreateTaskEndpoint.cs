using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.InternalControl;
using GrcApi.Modules.Shared.Helpers;
using System;
using System.Globalization;

namespace Arm.GrcApi.Modules.InternalControl
{
    /*
     * Original Author: Olusegun Adaramaja
     * Date Created: 11/11/2024
     * Development Group: GRCTools
     * Create task and send notification
     */
    public class CreateTaskEndpoint
    {
        /// <summary>
        /// The endpoint create task and assign to action owner
        /// </summary>
        /// <param name="createTaskDto"></param>
        /// <param name="dashBoardRepo"></param>
        /// <param name="currentUserService"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            CreateTaskDto createTaskDto, IRepository<InternalControlDashboard> dashBoardRepo, 
            ICurrentUserService currentUserService, IConfiguration config, IEmailService emailService
        )
        {
            var activityIntervals = new Dictionary<string, InternalControlDashboardActivityInterval>
            {
                {"daily", InternalControlDashboardActivityInterval.Daily},
                {"weekly", InternalControlDashboardActivityInterval.Weekly},
                {"monthly" , InternalControlDashboardActivityInterval.Monthly},
                {"bi-monthly" , InternalControlDashboardActivityInterval.Bi_Monthly},
                {"quarterly" , InternalControlDashboardActivityInterval.Quarterly},
                {"others" , InternalControlDashboardActivityInterval.Others}
            };
                      
            if (createTaskDto.CreateTask.Any(x => !activityIntervals.ContainsKey(x.ActivityInterval.ToLower())))
                return TypedResults.BadRequest("Please enter one of the recommended activity intervals");

            var requesterName = currentUserService.CurrentUserFullName;

            var tasks = new List<InternalControlDashboard>();

            foreach (var request in createTaskDto.CreateTask) {
                //Default notification date
                DateTime? nextNotificationDate = null;
                var interval = activityIntervals[request.ActivityInterval.ToLower()];
                
                if(interval == InternalControlDashboardActivityInterval.Daily)
                    nextNotificationDate = DateTime.Today.AddDays(1).AddHours(13);
                else if (interval == InternalControlDashboardActivityInterval.Weekly)
                {
                    var daysInReverse = new Dictionary<string, int> { 
                        {"Friday", 0},{"Thursday", 1}, {"Wednesday", 2}, {"Tuesday", 3 }, {"Monday", 4}, {"Sunday", 5} , {"Saturday", 6}
                    };
                    var dayOfTheWeek = DateTime.Today.DayOfWeek;

                    if(dayOfTheWeek == DayOfWeek.Friday)
                        nextNotificationDate = DateTime.Today.AddDays(daysInReverse.Count).AddHours(13); //Get next Friday date at 1pm
                    else
                        nextNotificationDate = DateTime.Today.AddDays(daysInReverse[dayOfTheWeek.ToString()]).AddHours(13); //Get next Friday date at 1 pm
                }
                else if(interval == InternalControlDashboardActivityInterval.Monthly)
                {
                    const int January = 1;
                    var nextMonth = DateTime.Today.AddMonths(1).Month;
                    var firstDayOfNextMonth = nextMonth != January ? new DateTime(DateTime.Today.Year, nextMonth, 1) : new DateTime(DateTime.Today.AddYears(1).Year, nextMonth, 1);

                    if(firstDayOfNextMonth.DayOfWeek == DayOfWeek.Saturday)
                        firstDayOfNextMonth.AddDays(2);
                    else if(firstDayOfNextMonth.DayOfWeek == DayOfWeek.Sunday)
                        firstDayOfNextMonth.AddDays(1);
                    
                    nextNotificationDate = firstDayOfNextMonth.AddHours(13);
                }
                else if (interval == InternalControlDashboardActivityInterval.Bi_Monthly)
                {
                    var countDownToTuesday = new Dictionary<string, int> {
                        {"Wednesday", 6},{"Thursday", 5}, {"Friday", 4}, {"Saturday", 3 }, {"Sunday", 2}, {"Monday", 1} , {"Tuesday", 0}
                    };
                    const int January = 1;
                    var dayOfTheWeek = DateTime.Today.DayOfWeek.ToString();
                    var next2Month = DateTime.Today.AddMonths(2).Month;
                    var secondWeekOfNext2Month = next2Month != January ? new DateTime(DateTime.Today.Year, next2Month, 8) : new DateTime(DateTime.Today.AddYears(1).Year, next2Month, 8);
                    nextNotificationDate = secondWeekOfNext2Month.AddDays(countDownToTuesday[dayOfTheWeek]).AddHours(13);
                }
                else if (interval == InternalControlDashboardActivityInterval.Quarterly)
                {
                    const int January = 1;
                    var dayOfTheWeek = DateTime.Today.DayOfWeek.ToString();
                    var lastMonthsPerQuarter = new Dictionary<string, int> { { "March", 3 }, { "June", 6 }, { "September", 9 }, { "December", 12 } };
                    var currentMonth = DateTime.Today.Month;

                    if (currentMonth <= lastMonthsPerQuarter["March"])
                    {
                        var endOfFirstQuarter = new DateTime(DateTime.Today.Year, lastMonthsPerQuarter["March"] + 1, 1);
                        if (endOfFirstQuarter.DayOfWeek == DayOfWeek.Saturday)
                            nextNotificationDate = endOfFirstQuarter.AddDays(2).AddHours(13);
                        else if (endOfFirstQuarter.DayOfWeek == DayOfWeek.Sunday)
                            nextNotificationDate = endOfFirstQuarter.AddDays(1).AddHours(13);
                        else
                            nextNotificationDate = endOfFirstQuarter.AddHours(13);
                    }
                    else if (currentMonth <= lastMonthsPerQuarter["June"])
                    {
                        var endOfSecondQuarter = new DateTime(DateTime.Today.Year, lastMonthsPerQuarter["June"] + 1, 1);
                        if (endOfSecondQuarter.DayOfWeek == DayOfWeek.Saturday)
                            nextNotificationDate = endOfSecondQuarter.AddDays(2).AddHours(13);
                        else if (endOfSecondQuarter.DayOfWeek == DayOfWeek.Sunday)
                            nextNotificationDate = endOfSecondQuarter.AddDays(1).AddHours(13);
                        else
                            nextNotificationDate = endOfSecondQuarter.AddHours(13);
                    }
                    else if (currentMonth <= lastMonthsPerQuarter["September"])
                    {
                        var endOfThirdQuarter = new DateTime(DateTime.Today.Year, lastMonthsPerQuarter["September"] + 1, 1);
                        if (endOfThirdQuarter.DayOfWeek == DayOfWeek.Saturday)
                            nextNotificationDate = endOfThirdQuarter.AddDays(2).AddHours(13);
                        else if (endOfThirdQuarter.DayOfWeek == DayOfWeek.Sunday)
                            nextNotificationDate = endOfThirdQuarter.AddDays(1).AddHours(13);
                        else
                            nextNotificationDate = endOfThirdQuarter.AddHours(13);
                    }
                    else if (currentMonth <= lastMonthsPerQuarter["December"])
                    {
                        var endOfFourthQuarter = new DateTime(DateTime.Today.AddYears(1).Year, January, 1);
                        if (endOfFourthQuarter.DayOfWeek == DayOfWeek.Saturday)
                            nextNotificationDate = endOfFourthQuarter.AddDays(2).AddHours(13);
                        else if (endOfFourthQuarter.DayOfWeek == DayOfWeek.Sunday)
                            nextNotificationDate = endOfFourthQuarter.AddDays(1).AddHours(13);
                        else
                            nextNotificationDate = endOfFourthQuarter.AddHours(13);
                    }
                }

                tasks.Add(InternalControlDashboard.Create(
                    new CreateTask(
                        ActivityInterval: activityIntervals[request.ActivityInterval.ToLower()],
                        Activity: request.Activity,
                        Comment: request.Comment,
                        CompletionDate: request.CompletionDate,
                        ActionOwner: request.ActionOwner,
                        ActionOwnerEmail: request.ActionOwnerEmail.ToLower(),
                        NotificationDate: nextNotificationDate
                )));
            }

            foreach ( var task in tasks)
            {
                task.SetCreatedBy(requesterName);
                task.SetModifiedBy(requesterName);
                task.SetModifiedOnUtc(DateTime.Now);
            }

            dashBoardRepo.AddRange(tasks);
            dashBoardRepo.SaveChanges();

            // Send email to action owner, line mgr and internal control
            #region Log email request
            foreach (var task in tasks)
            {
                string recipientEmail = task.ActionOwnerEmail;
                string dateOfOccurrence = DateTime.Now.ToString("yyyy-MM-dd");
                string subject = $"Internal Control Officer Assigned Task - {dateOfOccurrence}";
                var linkToGRCTool = string.Format(config["EmailConfiguration:linkToGRCToolDashBoardTask"], task.Id);
                string emailTo = recipientEmail;
                string toCC = config["EmailConfiguration:InternalControlEmailToCC"];
                string body = $"Dear {task.ActionOwner},<br><br> {requesterName} has assigned an internal control task on the dash-board.<br><br> Click here for more detail: <a href={linkToGRCTool}>GRC link</a>.";

                var logEmailRequest = await emailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalControl, task.Id, emailTo, toCC);
                //if (logEmailRequest == false)
                //{
                //    return TypedResults.Ok($"Internal Control Officer assign task successfully, but email message was not logged");
                //}
            }
            #endregion

            var response = tasks.Select(e => new InternalControlDashBoardTaskResponse(Id: e.Id)).ToList();
            return TypedResults.Created($"ar/{response}", response);
        }
    }
}
