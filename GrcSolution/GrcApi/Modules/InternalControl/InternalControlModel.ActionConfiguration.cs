using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcApi.Modules.InternalControl
{
    public class ActionConfiguration : IEntityTypeConfiguration<InternalControlAction>
    {
        public void Configure(EntityTypeBuilder<InternalControlAction> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ActionToBeResolved).HasMaxLength(500);

            builder.HasMany(x => x.InternalControlActionOwners).WithOne(i => i.InternalControlAction)
                .HasForeignKey(i => i.InternalControlActionlId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
