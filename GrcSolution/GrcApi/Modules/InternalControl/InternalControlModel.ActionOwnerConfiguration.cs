using Arm.GrcApi.Modules.InternalControl;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcApi.Modules.InternalControl
{
    public class InternalControlActionOwnerConfiguration : IEntityTypeConfiguration<InternalControlActionOwner>
    {
        public void Configure(EntityTypeBuilder<InternalControlActionOwner> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(b => b.ReasonForRejection).HasMaxLength(int.MaxValue);
            builder.Property(b => b.Response).HasMaxLength(int.MaxValue);
        }
    }
}
