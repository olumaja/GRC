using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcApi.Modules.InternalControl
{
    public class InternalControlDashboardConfiguration : IEntityTypeConfiguration<InternalControlDashboard>
    {
        public void Configure(EntityTypeBuilder<InternalControlDashboard> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Comment).HasMaxLength(int.MaxValue);
            builder.Property(x => x.Remarks).HasMaxLength(int.MaxValue);
        }
    }
}
