using Arm.GrcTool.Domain.RiskEvent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrcApi.Modules.RiskManagement
{
    public class LossManagementConfiguration : IEntityTypeConfiguration<LossManagement>
    {
        public void Configure(EntityTypeBuilder<LossManagement> builder)
        {
            builder.ToTable(nameof(LossManagement));
            builder.HasKey(b => b.Id).IsClustered();
            builder.Property(b => b.RecoveryDescription).HasMaxLength(500);
            builder.Property(b => b.GrossLossValue).HasColumnType("decimal").HasPrecision(10, 2);
            builder.Property(b => b.RecoveredAmount).HasColumnType("decimal").HasPrecision(10, 2);
            builder.Property(b => b.TotalRecoveredAmount).HasColumnType("decimal").HasPrecision(10, 2);
            builder.Property(b => b.NetLoss).HasColumnType("decimal").HasPrecision(10, 2);
        }
    }
}
