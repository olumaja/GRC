using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcApi.Modules.OperationControl
{
    public class OperationControlConfiguration : IEntityTypeConfiguration<OperationControl>
    {
        public void Configure(EntityTypeBuilder<OperationControl> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ExceptionDescription).HasMaxLength(int.MaxValue);
            builder.Property(x => x.ActionPoint).HasMaxLength(int.MaxValue);
            builder.Property(x => x.Comment).HasMaxLength(int.MaxValue);
        }
    }
}
