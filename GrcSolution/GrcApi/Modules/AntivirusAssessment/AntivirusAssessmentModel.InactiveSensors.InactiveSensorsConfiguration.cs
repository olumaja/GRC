using Arm.GrcApi.Modules.AntivirusAssessment;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    public class InactiveSensorsConfiguration : IEntityTypeConfiguration<InactiveSensors>
    {
        public void Configure(EntityTypeBuilder<InactiveSensors> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SystemProductName).HasMaxLength(int.MaxValue);
            builder.Property(x => x.Comment).HasMaxLength(int.MaxValue);
            builder.Property(x => x.ActionOwnerComment).HasMaxLength(int.MaxValue);
        }
    }
}
