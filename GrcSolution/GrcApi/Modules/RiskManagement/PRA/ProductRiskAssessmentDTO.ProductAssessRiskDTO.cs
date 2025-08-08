using System.ComponentModel.DataAnnotations;

namespace Arm.GrcApi.Modules.RiskManagement.PRA
{
    public class ProductAssessRiskDTO
    {
        public Guid ProductAssessRiskId { get; set; }

        
        public string ProductRiskCategory { get; set; }

        
        public string Description { get; set; }

        
        public string ProductOwnerResponse { get; set; }
        public PARRating Rating { get; set; }
    }
    public class ProductAssessRiskDTOList
    {
        public List<ProductAssessRiskDTO> ProductAssessRiskDTO { get; set; }
        public Guid ProductRiskassessmentId { get; set; }
        public string ProductName { get; set; }
        public PRAStatus Status { get; set; }
        public string ProductDescription { get; set; }
        public string QuestionOrRecomendation { get; set; }
        public string OwnerResponseToRecommendation { get; set; }
        public string? Requester { get; set; }
        public string? Approval { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DocumentDTO AttachDocument { get; set; }
        public DateTime Datecreated { get; set; }
    }
    public class DocumentDTO
    {
        public Guid DocumentId { get; set; }

        
        public string DocumentName { get; set; }
        public Guid ModuleItemId { get; set; }
    }

}
