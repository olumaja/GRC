using Arm.GrcTool.Domain.BusinessImpactAnalysis;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure
{
    public class BusinessImpactAnalysisUnitConfiguration : IEntityTypeConfiguration<BusinessImpactAnalysisUnit>
    {
        public void Configure(EntityTypeBuilder<BusinessImpactAnalysisUnit> builder)
        {
            builder.ToTable(nameof(BusinessImpactAnalysisUnit));
            builder.HasKey(x => x.Id);
            builder.Property(u => u.Comment).HasMaxLength(int.MaxValue);
            builder.HasMany(itm => itm.BIAUnitProcessDetails)
            .WithOne(d => d.BusinessImpactAnalysisUnit)
            .HasForeignKey(d => d.BusinessImpactAnalysisUnitId)
            .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(itm => itm.BusinessImpactAnalysisUnitLogs)
                .WithOne(l => l.BusinessImpactAnalysisUnit)
                .HasForeignKey(l => l.BusinessImpactAnalysisUnitId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
