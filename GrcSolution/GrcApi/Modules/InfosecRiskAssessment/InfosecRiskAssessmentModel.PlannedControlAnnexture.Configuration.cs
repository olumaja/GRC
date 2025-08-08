using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public class PlannedControlAnnextureConfiguration : IEntityTypeConfiguration<PlannedControlAnnexture>
    {
        public void Configure(EntityTypeBuilder<PlannedControlAnnexture> builder)
        {
            builder.HasKey(b => new { b.AnnextureId, b.PlannedControlId });
            builder.HasOne(b => b.Annexture).WithMany(u => u.PlannedControlAnnextures).HasForeignKey(b => b.AnnextureId);
            builder.HasOne(b => b.PlannedControl).WithMany(u => u.PlannedControlAnnextures).HasForeignKey(b => b.PlannedControlId);
        }
    }
}
