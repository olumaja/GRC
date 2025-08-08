using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Arm.GrcTool.Domain.RiskEvent.RiskEvent;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class RatedBusinessRiskRating : AuditEntity
    {
        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();
        [ForeignKey(nameof(BusinessRiskRating))]
        public Guid BusinessRiskRatingId { get; private set; }
        [ForeignKey(nameof(BusinessRiskRatingId))]
        public BusinessRiskRating BusinessRiskRating { get; set; }
        public string RequesterName { get; private set; }
        public string Business { get; private set; }
        public BusinessRiskRatingStatus Status { get; set; } = BusinessRiskRatingStatus.Completed;

        public static RatedBusinessRiskRating Create(Guid businessRiskRatingId, string business, string requesterName, BusinessRiskRatingStatus status)
        {
            return new RatedBusinessRiskRating
            {
                BusinessRiskRatingId = businessRiskRatingId,
                Business = business,
                RequesterName = requesterName,
                Status = status
            };
        }
    }

}
