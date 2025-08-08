using Arm.GrcApi.Modules.VulnerabilityManagement;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    public class ReducedFunctionalityModeConfiguration : IEntityTypeConfiguration<ReducedFunctionalityMode>
    {
        public void Configure(EntityTypeBuilder<ReducedFunctionalityMode> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Comment).HasMaxLength(int.MaxValue);
            builder.Property(x => x.ActionOwnerComment).HasMaxLength(int.MaxValue);
        }
    }
}
