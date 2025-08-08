using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 08/05/2024
* Development Group: Audit Development Plan - GRCTools
* This endpoint get Commence Engagement Summary
*/
    public class CommenceEngagementSummaryEndpoint
    {

        /// <summary>
        /// This endpoint get Commence Engagement Summary
        /// </summary>
        /// <param name="repo"></param>  
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            Guid commenceEngagementId, IRepository<CommenceEngagementAuditexecution> commenceEng, IRepository<AuditPlanningMemoAuditExecution> auditmemo, IRepository<AuditProgramAuditExecution> auditProgram,
           IRepository<EngagementLetterAuditExecution> engagementLetter, IRepository<AuditAnnouncementMemoAuditExecution> auditAnnouncementmemo, IRepository<InformationRequirementAuditExecution> inforeq,
           IRepository<AnualAuditUniverseRiskRating> auditUniverse, ClaimsPrincipal user, ICurrentUserService currentUserService
        ) 
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var getSummary = commenceEng.GetContextByConditon(c => c.Id == commenceEngagementId && c.Status != BusinessRiskRatingStatus.Approved).FirstOrDefault();
                if (getSummary != null)
                {
                    var getauditmemoSummary = auditmemo.GetContextByConditon(c => c.CommenceEngagementAuditexecutionId == getSummary.Id).FirstOrDefault();
                    string memoTeam = "Not created";
                    string memoRequesterName = "Not created";
                    DateTime memoDateCreated = DateTime.Now;
                    string memoStatus = "Pending";
                    if (getauditmemoSummary != null)
                    {
                        memoTeam = getauditmemoSummary.Team;
                        memoRequesterName = getauditmemoSummary.RequesterName;
                        memoDateCreated = getauditmemoSummary.CreatedOnUtc;
                        memoStatus = getauditmemoSummary.Status.ToString();
                    }

                    var getinforeqSummary = inforeq.GetContextByConditon(c => c.CommenceEngagementAuditexecutionId == getSummary.Id).FirstOrDefault();
                    string inforeqTeam = "Not created";
                    string inforeqRequesterName = "Not created";
                    DateTime inforeqDateCreated = DateTime.Now;
                    string inforeqStatus = "Pending";
                    if (getinforeqSummary != null)
                    {
                        inforeqTeam = getinforeqSummary.Team;
                        inforeqRequesterName = getinforeqSummary.RequesterName;
                        inforeqDateCreated = getinforeqSummary.CreatedOnUtc;
                        inforeqStatus = getinforeqSummary.Status.ToString();
                    }

                    var getengagementLetterSummary = engagementLetter.GetContextByConditon(c => c.CommenceEngagementAuditexecutionId == getSummary.Id).FirstOrDefault();
                    string engLetterTeam = "Not created";
                    string engLetterRequesterName = "Not created";
                    DateTime engLetterDateCreated = DateTime.Now;
                    string engLetterStatus = "Pending";
                    if (getengagementLetterSummary != null)
                    {
                        engLetterTeam = getengagementLetterSummary.Team;
                        engLetterRequesterName = getengagementLetterSummary.RequesterName;
                        engLetterDateCreated = getengagementLetterSummary.CreatedOnUtc;
                        engLetterStatus = getengagementLetterSummary.Status.ToString();
                    }

                    var getauditAnnouncementmemoSummary = auditAnnouncementmemo.GetContextByConditon(c => c.CommenceEngagementAuditexecutionId == getSummary.Id).FirstOrDefault();
                    string auditMemoTeam = "Not created";
                    string auditMemoRecommendation = "Not created";
                    string auditMemoRequesterName = "Not created";
                    DateTime auditMemoDateCreated = DateTime.Now;
                    string auditMemoStatus = "Pending";
                    if(getauditAnnouncementmemoSummary != null)
                    {
                        auditMemoTeam = getauditAnnouncementmemoSummary.Team;
                        auditMemoRecommendation = getauditAnnouncementmemoSummary.Unit;
                        auditMemoRequesterName = getauditAnnouncementmemoSummary.RequesterName;
                        auditMemoDateCreated = getauditAnnouncementmemoSummary.CreatedOnUtc;
                        auditMemoStatus = getauditAnnouncementmemoSummary.Status.ToString();
                    }
                    
                    var getauditProgramSummary = auditProgram.GetContextByConditon(c => c.CommenceEngagementAuditexecutionId == getSummary.Id).FirstOrDefault();
                    string auditProgramTeam = "Not created";
                    string auditProgramRequesterName = "Not created";
                    DateTime auditProgramDateCreated = DateTime.Now;
                    string auditProgramStatus = "Pending";
                    if (getauditProgramSummary != null)
                    {
                        auditProgramTeam = getauditProgramSummary.Team;
                        auditProgramRequesterName = getauditProgramSummary.RequesterName;
                        auditProgramDateCreated = getauditProgramSummary.CreatedOnUtc;
                        auditProgramStatus = getauditProgramSummary.Status.ToString();
                    }

                    var result = new ViewCommenceEngagementSummaryResp
                    {
                        CommenceEngagementId = commenceEngagementId,
                        DateCreated = getSummary.CreatedOnUtc,
                        CommenceEngagement = new ViewCommenceEngagement
                        {
                            AuditAnnouncementMemo = new ViewCommenceEngagementDetail
                            {
                                Month = "November", // To Do
                                CommenceEngagementId = commenceEngagementId,
                                Team = auditMemoTeam, //getauditAnnouncementmemoSummary.Team ?? "Operation",
                                Recommendation = auditMemoRecommendation, // getauditAnnouncementmemoSummary.Unit ?? "Partial scope",
                                RequesterName = auditMemoRequesterName, // getauditAnnouncementmemoSummary.RequesterName,
                                DateCreated = auditMemoDateCreated, //getauditAnnouncementmemoSummary.CreatedOnUtc,
                                Status = auditMemoStatus, //getauditAnnouncementmemoSummary.Status,
                                EngagementPlan = getSummary.EngagementPlan.ToString(),
                                WorkPaper = getSummary.WorkPaper.ToString(),
                                Findingstatus = getSummary.Findingstatus.ToString(),
                            },
                            AuditPlanningMemo = new ViewCommenceEngagementDetail
                            {
                                Month = "December", // To Do
                                CommenceEngagementId = commenceEngagementId,
                                Team = memoTeam,
                                Recommendation = getauditAnnouncementmemoSummary.Unit ?? "Partial scope",
                                RequesterName = memoRequesterName,
                                DateCreated = memoDateCreated,
                                Status = memoStatus,
                                EngagementPlan = getSummary.EngagementPlan.ToString(),
                                WorkPaper = getSummary.WorkPaper.ToString(),
                                Findingstatus = getSummary.Findingstatus.ToString(),
                            },
                            InformationRequirement = new ViewCommenceEngagementDetail
                            {
                                Month = "January", // To Do
                                CommenceEngagementId = commenceEngagementId,
                                Team = inforeqTeam,
                                Recommendation = getauditAnnouncementmemoSummary.Unit ?? "Partial scope",
                                RequesterName = inforeqRequesterName,
                                DateCreated = inforeqDateCreated,
                                Status = inforeqStatus,
                                EngagementPlan = getSummary.EngagementPlan.ToString(),
                                WorkPaper = getSummary.WorkPaper.ToString(),
                                Findingstatus = getSummary.Findingstatus.ToString(),
                            },
                            EngagementLetter = new ViewCommenceEngagementDetail
                            {
                                Month = "January", // To Do
                                CommenceEngagementId = commenceEngagementId,
                                Team = engLetterTeam, 
                                Recommendation = getauditAnnouncementmemoSummary.Unit ?? "Partial scope",
                                RequesterName = engLetterRequesterName, 
                                DateCreated = engLetterDateCreated, 
                                Status = engLetterStatus, 
                                EngagementPlan = getSummary.EngagementPlan.ToString(),
                                WorkPaper = getSummary.WorkPaper.ToString(),
                                Findingstatus = getSummary.Findingstatus.ToString()
                            },
                            AuditProgram = new ViewCommenceEngagementDetail
                            {
                                Month = "January", // To Do
                                CommenceEngagementId = commenceEngagementId,
                                Team = auditProgramTeam,
                                Recommendation = getauditAnnouncementmemoSummary.Unit ?? "Partial scope",
                                RequesterName = auditProgramRequesterName,
                                DateCreated = auditProgramDateCreated,
                                Status = auditProgramStatus,
                                EngagementPlan = getSummary.EngagementPlan.ToString(),
                                WorkPaper = getSummary.WorkPaper.ToString(),
                                Findingstatus = getSummary.Findingstatus.ToString()
                            }
                        }
                    };
                    return TypedResults.Ok(result);
                }
                return TypedResults.NotFound();

            }
            catch (Exception ex)
            {
                //logger.Error(ex, ex.Message);
                return TypedResults.BadRequest("Commenced engegement has not been fully performed on AuditPlanningMemo or InformationRequirement or EngagementLetter or AuditProgram");
            }

        }
    }
}
