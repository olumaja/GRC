using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrcApi.Modules.Compliance.CompliancePlanning
{
    public class ComplianceRulesBusinessConfiguration : IEntityTypeConfiguration<ComplianceRulesBusiness>
    {
        public void Configure(EntityTypeBuilder<ComplianceRulesBusiness> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ComplianceBusiness).WithMany(x => x.ComplianceRulesBusiness).HasForeignKey(x => x.BusinessId);
            builder.HasOne(x => x.ComplianceRule).WithMany(x => x.ComplianceRulesBusiness).HasForeignKey(x => x.ComplianceRuleId);
        }
    }
}
