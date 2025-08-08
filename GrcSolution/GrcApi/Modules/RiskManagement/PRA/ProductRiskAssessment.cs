using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;

namespace Arm.GrcApi.Modules.RiskManagement.PRA
{
    public class ProductRiskAssessment : AuditEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string ProductName { get; private set; }
        public Guid BusinessId { get; private set; }
        public Guid DepartmentId { get; private set; }
        public Guid UnitId { get; private set; }
        public string ProductDescription { get; private set; }
        public string EmailAddress { get; private set; }
        public PRAStatus Status { get; private set; } = PRAStatus.Pending;
        public PRAStage Stage { get; private set; } = PRAStage.RiskChampionStartPRA;
        public Guid DocumentAttachId { get; private set; }
        public ModuleType TestResultAttachmentModuleType { get; private set; } = ModuleType.RiskManagement;
        public string? QuestionOrRecomendation {  get; private set; }
        public string? OwnerResponse { get; private set; }
        public string? ReseasonForRejection { get; private set; }
        public string? Requester { get; private set; }
        public string? Approval { get; private set; }
        public DateTime? ApprovalDate { get; private set; }
        public virtual List<ProductAssessRisk> ProductAssessRisks { get; private set; } = new();

        public static ProductRiskAssessment Create(
            string productName, Guid businessId, Guid departmentId,
            string productDescription, Guid unitId, PRAStage stage, string emailAddress, string? requester
        )
        {
            return new ProductRiskAssessment
            {
                ProductName = productName,
                BusinessId = businessId,
                DepartmentId = departmentId,
                UnitId = unitId,
                ProductDescription = productDescription,
                Stage = stage,
                EmailAddress = emailAddress,
                Requester = requester
            };
        }

        //update DocumentAttachId
        public void UpdatePRADocumentAttachId(Guid documentAttachId)
        {
            DocumentAttachId = documentAttachId;
        }

        public void UpdatePRAStageStatusReason(PRAStage stage, PRAStatus status, string reasonForRejection = null)
        {
            Stage = stage;
            Status = status;
            ReseasonForRejection = reasonForRejection;
        }

        public void UpdateQuestionRecommendation(string questionRecommendation)
        {
            QuestionOrRecomendation = questionRecommendation;
        }

        public void UpdateOwnerResponseToRecommendation(string ownerResponse)
        {
            OwnerResponse = ownerResponse;
        }

        public void AddApproval(string? approval)
        {
            Approval = approval;
            ApprovalDate = DateTime.Now;
        }
    }

    public enum PRAStatus
    {
        Pending = 0,
        AwaitingResponse,
        Responded,
        Approved,
        Rejected,
        Treated
    }

    public enum PRAStage
    {
        RiskChampionStartPRA,
        RiskManagement,  
        RiskChampionReviewPRA,
        Final
    }


}
