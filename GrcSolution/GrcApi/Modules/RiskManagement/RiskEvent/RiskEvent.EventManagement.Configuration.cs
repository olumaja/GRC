using Arm.GrcTool.Domain.RiskEvent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure.Data;

public class RiskEventManagementConfiguration : IEntityTypeConfiguration<RiskEventManagement>
{
    public void Configure(EntityTypeBuilder<RiskEventManagement> builder)
    {
        builder.ToTable(nameof(RiskEventManagement));
        builder.Property(b => b.RiskDriverDescription).HasMaxLength(500);
        builder.HasKey(b => b.Id).IsClustered();
    }
}
