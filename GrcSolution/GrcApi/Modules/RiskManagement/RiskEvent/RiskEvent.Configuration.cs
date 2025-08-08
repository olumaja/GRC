using Arm.GrcTool.Domain.RiskEvent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure.Data
{
    public class RiskEventConfiguration : IEntityTypeConfiguration<RiskEvent>
    {
        public void Configure(EntityTypeBuilder<RiskEvent> builder)
        {
            builder.ToTable(nameof(RiskEvent));
            builder.Property(b => b.EstimatedLoss).HasColumnType("decimal(18,2)");
            builder.Property(b => b.Description).HasMaxLength(500);
            builder.Property(b => b.AssesmentStatus).HasMaxLength(10);
            builder.HasKey(b => b.Id).IsClustered();
        }
    }
}
