using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcApi.Modules.InternalControl
{
    public class InternalControlModelConfiguration : IEntityTypeConfiguration<InternalControlModel>
    {
        public void Configure(EntityTypeBuilder<InternalControlModel> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.IssueSummary).HasMaxLength(int.MaxValue);
            builder.Property(b => b.Collaborators).HasMaxLength(int.MaxValue);
            builder.Property(b => b.CollaboratorEmail).HasMaxLength(int.MaxValue);

            builder.HasMany(b => b.Actions).WithOne(i => i.InternalControl)
                .HasForeignKey(i => i.InternalControlId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
