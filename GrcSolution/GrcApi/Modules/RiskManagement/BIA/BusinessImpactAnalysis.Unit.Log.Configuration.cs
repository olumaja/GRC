using Arm.GrcTool.Domain.BusinessImpactAnalysis;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure
{
    public class BusinessImpactAnalysisUnitLogConfiguration : IEntityTypeConfiguration<BusinessImpactAnalysisUnitLog>
    {
        public void Configure(EntityTypeBuilder<BusinessImpactAnalysisUnitLog> builder)
        {
            builder.ToTable(nameof(BusinessImpactAnalysisUnitLog));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.BusinessImpactAnalysisUnitId).IsRequired();
            builder.Property(u => u.BusinessImpactAnalysisUnitJson).HasMaxLength(int.MaxValue);
        }
    }
}
