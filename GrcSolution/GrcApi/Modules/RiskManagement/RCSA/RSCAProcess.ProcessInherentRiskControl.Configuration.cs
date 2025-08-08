using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure
{
    public class ProcessInherentRiskControlConfiguration : IEntityTypeConfiguration<ProcessInherentRiskControl>
    {
        public void Configure(EntityTypeBuilder<ProcessInherentRiskControl> builder)
        {
            builder.ToTable(nameof(ProcessInherentRiskControl));
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Control).HasMaxLength(int.MaxValue);
            builder.Property(b => b.InherentRisk).HasMaxLength(int.MaxValue);
            builder.Property(b => b.TestToApply).HasMaxLength(int.MaxValue);

            builder.Property(b => b.TestResult).HasMaxLength(int.MaxValue);
            builder.Property(b => b.ColourEffectiveness).HasMaxLength(int.MaxValue);
            builder.Property(b => b.ResidualRisks).HasMaxLength(int.MaxValue);
            builder.Property(b => b.CorrectiveActions).HasMaxLength(int.MaxValue);

            builder.HasOne(b => b.DocumentRCSAProcess).WithMany(b => b.ProcessInherentRiskControls).HasForeignKey(b => b.DocumentRCSAProcessId);
        }
    }
}
