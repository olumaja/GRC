using Arm.GrcApi.Modules.OperationControl;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    /*
        * Original Author: Sodiq Quadre
        * Date Created: 04/04/2025
        * Development Group: GRCTools
        * Get logged incidence by Id Endpoint.
        */
    public class GetLoggedIncidenceByIdEndpoint
    {
        /// <summary>
        /// Get logged incidence by Id Endpoint.
        /// </summary>
        /// <param name="incidencId"></param>
        /// <param name="repository"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid incidencId, IRepository<IncidentManagementLog> repository,
            ICurrentUserService currentUserService
        )
        {
            var loggedIncidence = repository.GetContextByConditon(r => r.Id == incidencId).FirstOrDefault();

            if (loggedIncidence is null)
                return TypedResults.NotFound("Record not found");
            string tag = null;
            if(loggedIncidence.IncidentTag == IncidentTagCategory.False_Positive)
            {
                tag = "False Positive";
            }
            if (loggedIncidence.IncidentTag == IncidentTagCategory.True_Positive)
            {
                tag = "True Positive";
            }
            string[] impacts = loggedIncidence.Impact.Split(',');
            string[] SecurityAreas = loggedIncidence.SecurityAreas.Split(',');
            return TypedResults.Ok(new GetLogIncidenceById(
                IncidenceId: loggedIncidence.Id,               
                SecurityIncident: loggedIncidence.SecurityIncident,
                SecurityAreas: SecurityAreas,
                Severity: loggedIncidence.Severity.ToString(),
                DescriptionOfIncident: loggedIncidence.DescriptionOfIncident,
                TypeOfAsset: loggedIncidence.TypeOfAsset,
                AssetDescription: loggedIncidence.AssetDescription,
                DateOfReporting: loggedIncidence.CreatedOnUtc,
                DateOfIncidence: loggedIncidence.DateOfReporting,
                DescriptionOfActionTaken: loggedIncidence.DescriptionOfActionTaken,
                RootCause: loggedIncidence.RootCause,
                Impact: impacts, 
                RecommendationToPreventFutureReoccurence: loggedIncidence.RecommendationToPreventFutureReoccurence,
                LessonLearnt: loggedIncidence.LessonLearnt,
                Status: loggedIncidence.Status.ToString(),
                DateOfClosure: loggedIncidence.DateOfClosure,
                Comment: loggedIncidence.ReportingStaffComment,
                ReportingStaffCommentDate: loggedIncidence.ReportingStaffCommentDate,
                ReportingStaff: loggedIncidence.ReportingStaff,
                ReportingStaffEmailAddress: loggedIncidence.ReportingStaffEmailAddress,
                ReportingStaffComment: loggedIncidence.ReportingStaffComment,
                ActionOwnerName: loggedIncidence.ActionOwnerName,
                ActionOwnerComment: loggedIncidence.ActionOwnerComment,
                IncidentTag: tag,
                ReportingUnit: loggedIncidence.ReportingUnit,
                InfoSecStaffName: loggedIncidence.InfoSecStaffName,
                InfoSecRecommendation: loggedIncidence.InfoSecRecommendation,
                InfoSecStaffCommentDate: loggedIncidence.InfoSecStaffCommentDate,
                ActionOwnerCommentDate: loggedIncidence.ActionOwnerCommentDate,
                ActionOwnerUnit: loggedIncidence.ActionOwnerUnit              
            ));
        }
    }
}
