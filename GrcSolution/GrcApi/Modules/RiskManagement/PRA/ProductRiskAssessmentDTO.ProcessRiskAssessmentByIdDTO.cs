using Arm.GrcApi.Modules.RiskManagement.PRA;
using System.ComponentModel.DataAnnotations;

namespace GrcApi.Modules.RiskManagement.PRA
{
    public class ProcessRiskAssessmentByIdDTO
    {
        public Guid ProductRiskAssessmentId { get; set; }
        public string DateInitiated { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ReasonForRejection { get; set; }
        public string QuestionOrRecomendation { get; set; }
        public PRAStatus Status { get; set; }
        public string? Requester { get; set; }
        public string? Approval { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public List<ProductAssessDto> ProductAssessDtos { get; set; } = new();
        public DocumentDTO Document { get; set; }
    }

    public class ProductAssessDto
    {
        public Guid ProductAssessRiskId { get; set;}
        
        public string ProductRiskCategory { get; set; }
        
        public string Description { get; set; }
        public PARRating Rating { get; set; }
    }
}
