using Arm.GrcTool.Domain.RiskEvent;

using GrcApi.Modules.Shared;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure
{
    public class RecoveryTypeConfiguration : IEntityTypeConfiguration<RecoveryType>
    {
        public void Configure(EntityTypeBuilder<RecoveryType> builder)
        {
            builder.ToTable(nameof(RecoveryType));
            builder.Property(b => b.Name).HasMaxLength(100).IsRequired();
            builder.HasKey(b => b.Id);

            builder.HasData(
                    RecoveryType.Create(new Guid(RecoveryTypeGuids.recovery1), nameof(RecoveryTypeGuids.recovery1)),
                    RecoveryType.Create(new Guid(RecoveryTypeGuids.recovery2), nameof(RecoveryTypeGuids.recovery2))
                );
        }
    }
}
