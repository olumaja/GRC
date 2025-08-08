using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrcApi.Modules.Compliance.CompliancePlanning
{
    public class ComplianceRulesConfiguration : IEntityTypeConfiguration<ComplianceRules>
    {
        public void Configure(EntityTypeBuilder<ComplianceRules> builder)
        {
            builder.Property(b => b.IssuesOrFillingOrReturn).HasMaxLength(int.MaxValue);

            //builder.HasData(
            //    ComplianceRules.Create(
            //);
        }
    }
}
