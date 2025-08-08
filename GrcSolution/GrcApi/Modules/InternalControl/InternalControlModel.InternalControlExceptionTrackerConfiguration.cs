using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcApi.Modules.InternalControl
{
    public class InternalControlExceptionTrackerConfiguration : IEntityTypeConfiguration<InternalControlExceptionTracker>
    {
        public void Configure(EntityTypeBuilder<InternalControlExceptionTracker> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.Exception).HasMaxLength(int.MaxValue);
            builder.Property(b => b.Recommendation).HasMaxLength(int.MaxValue);
            builder.Property(b => b.ManagementResponse).HasMaxLength(int.MaxValue);
        }
    }
}
