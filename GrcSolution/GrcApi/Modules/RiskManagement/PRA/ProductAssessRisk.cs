using Arm.GrcApi.Modules.Shared;

namespace Arm.GrcApi.Modules.RiskManagement.PRA
{
    public class ProductAssessRisk : AuditEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid ProductRiskAssementId { get; private set; }
        public ProductRiskAssessment ProductRiskAssessment { get; private set; }
        public string ProductRiskCategory { get; private set; }
        public string Description { get; private set; }
        public string? ProductOwnerResponse { get; private set; }
        public PARRating Rating { get; private set; }

        public static ProductAssessRisk Create(Guid productRiskAssementId, string productRiskCategory, string description, PARRating rating)
        {
            return new ProductAssessRisk
            {
                ProductRiskAssementId = productRiskAssementId,
                ProductRiskCategory = productRiskCategory,
                Description = description,
                Rating = rating
            };
        }

        public void UpdateProductOwnerResponse(string productOwnerResponse)
        {
            ProductOwnerResponse = productOwnerResponse;
        }
    }

    public enum PARRating
    {
        Low = 0,
        Medium,
        High
    }
}
