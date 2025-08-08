using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure
{
    public class RiskControlSelfAssessmentConfiguration : IEntityTypeConfiguration<RiskControlSelfAssessment>
    {
        public void Configure(EntityTypeBuilder<RiskControlSelfAssessment> builder)
        {
            builder.ToTable(nameof(RiskControlSelfAssessment));
            builder.Property(b => b.PeriodFrom).IsRequired();
            builder.Property(b => b.PeriodTo).IsRequired();
            builder.Property(b => b.StartDate).IsRequired();
            builder.Property(b => b.EndDate).IsRequired();
            builder.HasKey(b => b.Id);
            builder.HasMany(itm => itm.RiskControlSelfAssessmentUnits)
            .WithOne(d => d.RiskControlSelfAssessment)
            .HasForeignKey(d => d.RiskControlSelfAssessmentId)
            //deletes all the children when the parent is deleted
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
