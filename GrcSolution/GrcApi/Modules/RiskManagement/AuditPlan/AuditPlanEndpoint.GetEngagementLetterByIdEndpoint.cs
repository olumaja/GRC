using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 08/05/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 */
    public class GetEngagementLetterByIdEndpoint
    {
        /// <summary>
        /// Endpoint to Get Engagement Letter detail By Id
        /// </summary>
        /// <param name="commenceEngagementId"></param>
        /// <param name="auditmemo"></param>
        /// <param name="commenceEng"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            Guid commenceEngagementId, string team, IRepository<EngagementLetterAuditExecution> auditmemo, IRepository<CommenceEngagementAuditexecution> commenceEng,
            IRepository<EngagementLetterReportDistributionList> reportDistributionList, IRepository<EngagementLetterAuditExecutionDuration> duration,
            ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (!currentUserService.CurrentUserRoles.Contains("InternalAuditee") && !currentUserService.CurrentUserRoles.Contains("InternalAuditOfficer") && !currentUserService.CurrentUserRoles.Contains("InternalAuditSupervisor"))
                { return TypedResults.Unauthorized(); }

                var getCommenceEng = commenceEng.GetContextByConditon(x => x.Id == commenceEngagementId).FirstOrDefault();
                if (getCommenceEng == null)
                {
                    return TypedResults.NotFound($"Commence Engagement Id '{commenceEngagementId}' was not found");
                }
                var getEngagementLetter = auditmemo.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == getCommenceEng.Id).FirstOrDefault();
                
                var getduration = duration.GetContextByConditon(x => x.EngagementLetterAuditExecutionId == getEngagementLetter.Id).OrderBy(x => x.CreatedOnUtc);
                var getreportDistributionList = reportDistributionList.GetContextByConditon(x => x.EngagementLetterAuditExecutionId == getEngagementLetter.Id).OrderBy(x=> x.CreatedOnUtc);

                if (getEngagementLetter == null)
                {
                    return TypedResults.NotFound($"Engagement Letter with the team {team} was not found");
                }

                var getdurationResp = getduration.Select(p => new EngagementLetterAuditExecutionDurationReq
                {
                    Action = p.DurationAction,
                    Timing = p.DurationTiming
                   
                }).ToList();
                var getListResp = getreportDistributionList.Select(p => new EngagementLetterReportDistributionListReq
                {
                    Name = p.ReportDistributionListName,
                    Title = p.ReportDistributionListTitle,
                    BusinessUnit = p.ReportDistributionListBusinessUnit

                }).ToList();

                GetEngagementLetterAuditExecutionResp resp = new GetEngagementLetterAuditExecutionResp
                {
                    CommenceEngagementId = getCommenceEng.Id,
                    EngagementLetterId = getEngagementLetter.Id,
                    Team = getEngagementLetter.Team,
                    Status = getEngagementLetter.Status.ToString(),
                    AuditTitle = getEngagementLetter.AuditTitle,
                    AuditType = getEngagementLetter.AuditType,
                    ScopeLimitation = getEngagementLetter.ScopeLimitation,
                    AuditScope = getEngagementLetter.AuditScope,
                    AuditObjective = getEngagementLetter.AuditObjective,
                    ResponsibilityOfInternalAudit = getEngagementLetter.ResponsibilityOfInternalAudit,
                    BusinessUnit = getEngagementLetter.BusinessUnit,
                    Comment = getEngagementLetter.Comment,
                    Date = getEngagementLetter.Date,
                    BriefBackgroundObjective = getEngagementLetter.BriefBackgroundObjective,
                    BusinessOwner = getEngagementLetter.BusinessOwner,
                    IssueBy = getEngagementLetter.IssueBy,
                    CommunicationProtocol = getEngagementLetter.CommunicationProtocol,
                    KeyRisk = getEngagementLetter.KeyRisk,
                    Mandate = getEngagementLetter.Mandate,
                    ResponsibleExecutive = getEngagementLetter.ResponsibleExecutive,
                    EngagementLetterAuditExecutionDuration = getdurationResp,
                    EngagementLetterReportDistributionList = getListResp,
                    ReasonForRejection = getEngagementLetter.ReasonForRejection
                };
                return TypedResults.Ok(resp);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }


        }
    }
}
