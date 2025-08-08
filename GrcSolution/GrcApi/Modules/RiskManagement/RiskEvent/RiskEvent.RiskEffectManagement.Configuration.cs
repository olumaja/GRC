using Arm.GrcTool.Domain.RiskEvent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure.Data
{
    public class RiskEffectManagementConfiguration : IEntityTypeConfiguration<RiskEffectManagement>
    {
        public void Configure(EntityTypeBuilder<RiskEffectManagement> builder)
        {
            builder.ToTable(nameof(RiskEffectManagement));
            builder.Property(b => b.EffectDescription).HasMaxLength(500);
            builder.Property(b => b.LossValue).HasColumnType("decimal").HasPrecision(10, 2);
            builder.HasKey(b => b.Id).IsClustered();
        }
    }
}
