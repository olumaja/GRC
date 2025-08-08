using Arm.GrcApi.Modules.AntivirusAssessment;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcApi.Modules.VulnerabilityManagement;
using GrcApi.Modules.VulnerabilityManagement;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{    
    public class ReducedFunctionalityMode : AuditEntity2
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid AntivirusAssessmentModelId { get; private set; }
        public string? ComputerName { get; private set; }
        public string? LastSeenOnCrowdStrike { get; private set; }
        public string? MACAddress { get; private set; }
        public string? SystemVersion { get; private set; }
        public string? LoggedOnUser { get; private set; }
        public string? LastSeenOnManageEngine { get; private set; }
        public string? Comment { get; set; }
        public string? ActionOwnerComment { get; private set; }
        public AntivirusStatus Status { get; private set; } = AntivirusStatus.Pending;
        public AntivirusStatus? Action { get; private set; }
        public AntivirusAssessmentModel AntivirusAssessmentModel { get; private set; }

        public static ReducedFunctionalityMode ExcelUploadCreate(Guid id, ReducedFunctionalityModeReq request)
        {
            return new ReducedFunctionalityMode
            {
                AntivirusAssessmentModelId = id,
                ComputerName = request.ComputerName,
                LastSeenOnCrowdStrike = request.LastSeenOnCrowdStrike,
                MACAddress = request.MACAddress,
                SystemVersion = request.SystemVersion,
                LoggedOnUser = request.LoggedOnUser,
                LastSeenOnManageEngine = request.LastSeenOnManageEngine
            };
        }
               
        public void ApproveReducedFunctionalityMode()
        {
            Action = AntivirusStatus.Approve;
        }
        public void RejectReducedFunctionalityMode(string comment)
        {
            Comment = comment;
            Action = AntivirusStatus.Rejected;
        }

        public void ResetAction()
        {
            Action = null;
        }

        public void UpdateAfterActionOwnerResponse(AntivirusStatus status, string? actionOwnerComment)
        {
            Status = status;
            ActionOwnerComment = actionOwnerComment;
        }

        public void EditReduceFunctionality(UpdateReduceFunctionality request)
        {            
            Status = request.Status;
            ActionOwnerComment = request.ActionownerComment;
        }
    }
}
