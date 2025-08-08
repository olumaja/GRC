using Arm.GrcTool.Domain.BusinessImpactAnalysis;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure
{
    public class BusinessImpactAnalysisConfiguration : IEntityTypeConfiguration<BusinessImpactAnalysis>
    {
        public void Configure(EntityTypeBuilder<BusinessImpactAnalysis> builder)
        {
            builder.ToTable(nameof(BusinessImpactAnalysis));
            builder.Property(b => b.PeriodFrom).IsRequired();
            builder.Property(b => b.PeriodTo).IsRequired();
            builder.Property(b => b.StartDate).IsRequired();
            builder.Property(b => b.EndDate).IsRequired();
            builder.HasKey(b => b.Id);
            builder.HasMany(itm => itm.BusinessImpactAnalysisUnits)
            .WithOne(d => d.BusinessImpactAnalysis)
            .HasForeignKey(d => d.BusinessImpactAnalysisId)
            //not delete all the children when the parent is deleted
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
