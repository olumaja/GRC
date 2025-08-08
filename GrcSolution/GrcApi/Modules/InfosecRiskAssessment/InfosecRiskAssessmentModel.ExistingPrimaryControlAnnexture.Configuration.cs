using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public class ExistingPrimaryControlAnnextureConfiguration : IEntityTypeConfiguration<ExistingPrimaryControlAnnexture>
    {
        public void Configure(EntityTypeBuilder<ExistingPrimaryControlAnnexture> builder)
        {
            builder.HasKey(m => new { m.AnnextureId, m.ExistingPrimaryControlId });
            builder.HasOne(m => m.Annexture).WithMany(u => u.ExistingPrimaryControlAnnextures).HasForeignKey(m => m.AnnextureId);
            builder.HasOne(m => m.ExistingPrimaryControl).WithMany(r => r.ExistingPrimaryControlAnnextures).HasForeignKey(m => m.ExistingPrimaryControlId);
        }
    }
}
