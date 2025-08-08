using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcApi.Modules.InternalControl
{
    public class InternalControlCallOverConfiguration : IEntityTypeConfiguration<InternalControlCallOver>
    {
        public void Configure(EntityTypeBuilder<InternalControlCallOver> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ReasonForRejection).HasMaxLength(int.MaxValue);
            builder.Property(x => x.Comment).HasMaxLength(int.MaxValue);

            builder.HasMany(x => x.Reports).WithOne(r => r.CallOver).HasForeignKey(r => r.CallOverId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class InternalControlCallOverReportConfiguration : IEntityTypeConfiguration<InternalControlCallOverReport>
    {
        public void Configure(EntityTypeBuilder<InternalControlCallOverReport> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
