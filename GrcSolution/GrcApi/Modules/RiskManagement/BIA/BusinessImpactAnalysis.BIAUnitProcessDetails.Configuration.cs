using Arm.GrcTool.Domain.BusinessImpactAnalysis;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure
{
    public class BIAUnitProcessDetailsConfiguration : IEntityTypeConfiguration<BIAUnitProcessDetails>
    {
        public void Configure(EntityTypeBuilder<BIAUnitProcessDetails> builder)
        {
            builder.ToTable(nameof(BIAUnitProcessDetails));
            builder.HasKey(x => x.Id);
            builder.Property(d => d.ProcessId).IsRequired();
            builder.Property(d => d.BusinessImpactAnalysisUnitId).IsRequired();
            builder.Property(d => d.BusinessProcessDescriptionSummary).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(d => d.FinancialImpact).IsRequired().HasMaxLength(100);
            builder.Property(d => d.CustomerExperience).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(d => d.OtherProcessesOrPeople).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(d => d.RegulatoryOrLegal).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(d => d.Reputation).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(d => d.ThirdPartyImpact).IsRequired().HasMaxLength(100);
            builder.Property(d => d.MinimumBusinessContinuityObjective).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(d => d.MaximumAllowableOutage).IsRequired().HasMaxLength(100);
            builder.Property(d => d.RecoveryTimeObjective).IsRequired().HasMaxLength(100);
            builder.Property(d => d.RecoveryPointObjective).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(d => d.ApplicationsUsedToRunProcess).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(d => d.KeyVendors).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(d => d.AnyNonElectronicVitalRecords).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(d => d.AlternativeWorkarounds).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(d => d.PrimaryRecoverStrategyAndSolution).IsRequired().HasMaxLength(int.MaxValue);
            builder.Property(d => d.RemoteWorking).IsRequired().HasMaxLength(int.MaxValue);
            //builder.HasMany(d => d.ResponsibleBusinessUnits)
            //    .WithOne(u => u.BIAUnitProcessDetails)
            //    .HasForeignKey(u => u.BIAUnitProcessDetailsId)
            //    .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(d => d.BusinessUnitsToRunProcess)
                .WithOne(u => u.BIAUnitProcessDetails)
                .HasForeignKey(u => u.BIAUnitProcessDetailsId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
