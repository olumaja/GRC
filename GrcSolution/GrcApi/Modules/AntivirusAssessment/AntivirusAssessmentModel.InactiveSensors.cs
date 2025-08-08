using Arm.GrcApi.Modules.Shared;
using Arm.GrcApi.Modules.VulnerabilityManagement;
using GrcApi.Modules.VulnerabilityManagement;
using System.ComponentModel;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{    
    public class InactiveSensors : AuditEntity2
    {        
        public Guid Id { get; init; } = Guid.NewGuid();
        public Guid AntivirusAssessmentModelId { get; private set; }
        public string? ComputerName { get; private set; }
        public string? LastSeenOnCrowdStrike { get; private set; }        
        public string? MACAddress { get; private set; }
        public string? SystemProductName { get; private set; }
        public string? SystemVersion { get; private set; }
        public string? LoggedOnUser { get; private set; }
        public string? LastSeenOnManageEngine { get; private set; }
        public string? Comment { get; set; }
        public string? ActionOwnerComment { get; set; }
        public AntivirusStatus Status { get; private set; } = AntivirusStatus.Pending;
        public AntivirusStatus? Action { get; private set; }
        public AntivirusAssessmentModel AntivirusAssessmentModel { get; private set; }

        public static InactiveSensors ExcelUploadCreate(Guid id, InactiveSensorsReq request)
        {
            return new InactiveSensors
            {
                AntivirusAssessmentModelId = id,
                ComputerName = request.ComputerName,
                LastSeenOnCrowdStrike = request.LastSeenOnCrowdStrike,
                MACAddress = request.MACAddress,
                SystemProductName = request.SystemProductName,
                SystemVersion = request.SystemVersion,
                LoggedOnUser = request.LoggedOnUser,
                LastSeenOnManageEngine = request.LastSeenOnManageEngine
            };
        }
              
        public void ApproveAntivirusAssessment()
        {
            Action = AntivirusStatus.Approve;
        }
        public void RejectAntivirusAssessment(string comment)
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

        public void EditInactiveSensor(UpdateInactivesensor request)
        {
            Status = request.Status;
            ActionOwnerComment = request.ActionownerComment;
        }
    }
}
