using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public class ExistingPrimaryControlConfiguration : IEntityTypeConfiguration<ExistingPrimaryControl>
    {
        public void Configure(EntityTypeBuilder<ExistingPrimaryControl> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(x => x.Name).HasMaxLength(int.MaxValue);
            builder.HasOne(b => b.InfosecRiskAssessment).WithMany(i => i.ExistingPrimaryControls).HasForeignKey(b => b.InfosecRiskAssessmentId);
        }
    }
}
