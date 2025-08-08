using Arm.GrcTool.Domain.BusinessImpactAnalysis;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure
{
    public class BIAUnitProcessDetailsBusinessUnitToRunProcessConfiguration : IEntityTypeConfiguration<BIAUnitProcessDetailsBusinessUnitToRunProcess>
    {
        public void Configure(EntityTypeBuilder<BIAUnitProcessDetailsBusinessUnitToRunProcess> builder)
        {
            builder.ToTable(nameof(BIAUnitProcessDetailsBusinessUnitToRunProcess));
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UnitId).IsRequired();
            builder.Property(u => u.BIAUnitProcessDetailsId).IsRequired();
        }
    }
}
