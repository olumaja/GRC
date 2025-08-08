using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure
{
    public class RiskControlSelfAssessmentUnitConfiguration : IEntityTypeConfiguration<RiskControlSelfAssessmentUnit>
    {
        public void Configure(EntityTypeBuilder<RiskControlSelfAssessmentUnit> builder)
        {
            builder.ToTable(nameof(RiskControlSelfAssessmentUnit));
            builder.Property(b => b.RiskControlSelfAssessmentId).IsRequired();
            builder.Property(b => b.UnitId).IsRequired();
            builder.HasKey(b => b.Id);
            //unique constraint
            builder.HasIndex(e => new { e.RiskControlSelfAssessmentId, e.Id })
            .IsUnique();

            builder.HasOne(a => a.DocumentRSCAProcess)
            .WithOne(b => b.RiskControlSelfAssessmentUnit)
            .HasForeignKey<DocumentRSCAProcess>(b => b.RiskControlSelfAssessmentUnitId);
        }
    }
}
