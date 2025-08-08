using Arm.GrcApi.Modules.VulnerabilityManagement;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    public class AntivirusAssessmentModelConfiguration : IEntityTypeConfiguration<AntivirusAssessmentModel>
    {
        public void Configure(EntityTypeBuilder<AntivirusAssessmentModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.InactiveSensors).WithOne(v => v.AntivirusAssessmentModel).HasForeignKey(v => v.AntivirusAssessmentModelId);
            builder.HasMany(x => x.ReducedFunctionalityMode).WithOne(v => v.AntivirusAssessmentModel).HasForeignKey(v => v.AntivirusAssessmentModelId);
        }
    }
}
