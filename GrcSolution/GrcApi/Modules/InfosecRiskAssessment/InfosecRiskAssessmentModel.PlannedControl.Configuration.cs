using Arm.GrcApi.Modules.InfosecRiskAssessment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrcApi.Modules.InfosecRiskAssessment
{
    public class PlannedControlConfiguration : IEntityTypeConfiguration<PlannedControl>
    {
        public void Configure(EntityTypeBuilder<PlannedControl> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(int.MaxValue);
            builder.HasOne(b => b.InfosecRiskAssessment).WithMany(i => i.PlannedControls).HasForeignKey(b => b.InfosecRiskAssessmentId);
        }
    }
}
