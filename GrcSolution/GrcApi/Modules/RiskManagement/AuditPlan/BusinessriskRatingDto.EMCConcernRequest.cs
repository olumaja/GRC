using Arm.GrcApi.Modules.Shared;
using GrcApi.Modules.RiskManagement.AuditPlan;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class EMCConcernRequest
    {
        public ARMHoldingCompanyRiskRatingEMC ARMHoldingCompany { get; set; }
        public ARMTAMRiskRatingEMC ARMTAM { get; set; }       
        public ARMIMRiskRatingEMC ARMIM { get; set; }
        public ARMSecurityRiskRatingEMC ARMSecurity { get; set; }
        public ARMTrusteeRiskRatingEMC ARMTrustee { get; set; }
        public ARMHILLRiskRatingEMC ARMHILL { get; set; }
        public ARMAgribusinessRiskRatingEMC ARMAgribusiness { get; set; }
        public DigitalFinancialServiceRating DigitalFinancialService { get; set; }
        public ARMCapitalRating ARMCapital { get; set; }
        public ARMSharedServiceRiskRating ARMSharedService { get; set; }
        [RegularExpression("^[a-zA-Z0-9]*$")]
        public string? Comment { get; set; }
        public string? BusinessRateRequesterName { get; set; }
        [Required]
        public Guid BusinessRiskRatingId { get; set; }
    }
}
