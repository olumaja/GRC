using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 08/05/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 */
    public class GetInformationRequirementByIdEndpoint
    {
        /// <summary>
        /// Endpoint to Get Information Requirement detail By Id
        /// </summary>
        /// <param name="commenceEngagementId"></param>
        /// <param name="auditmemo"></param>
        /// <param name="commenceEng"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            Guid commenceEngagementId, string team, IRepository<InformationRequirementAuditExecution> auditmemo, 
            IRepository<CommenceEngagementAuditexecution> commenceEng, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            try
            {
               
                if(!currentUserService.CurrentUserRoles.Contains("InternalAuditee") && !currentUserService.CurrentUserRoles.Contains("InternalAuditOfficer") && !currentUserService.CurrentUserRoles.Contains("InternalAuditSupervisor"))
                { return TypedResults.Unauthorized(); }

                var getCommenceEng = commenceEng.GetContextByConditon(x => x.Id == commenceEngagementId).FirstOrDefault();
                List<GetInformationRequirementResp> viewResp = new List<GetInformationRequirementResp>();

                if (getCommenceEng == null)
                {
                    return TypedResults.NotFound($"Commence Engagement Id '{commenceEngagementId}' was not found");
                }
                var getAuditAnnouncementMemo = auditmemo.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == getCommenceEng.Id && x.Team == team).OrderBy(x => x.CreatedOnUtc).ToList();
                if (getAuditAnnouncementMemo == null)
                {
                    return TypedResults.NotFound($"Information Requirement has not been fully performed");
                }
                foreach (var item in getAuditAnnouncementMemo)
                {
                    
                    viewResp.Add(new GetInformationRequirementResp
                    {
                        CommenceEngagementId = getCommenceEng.Id,
                        Team = item.Team,
                        InformationRequirementId = item.Id,
                        Status = item.Status.ToString(),
                        InformationRequest = item.InformationRequest,
                        ResponsibleOfficer = item.ResponsibleOfficer,
                        RequestDate = item.RequestDate,
                        DateProvided = item.DateProvided,
                        ReasonForRejection = item.ReasonForRejection
                    });

                }
                return TypedResults.Ok(viewResp);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }


        }
    }
}
