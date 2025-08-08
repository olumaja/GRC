using Arm.GrcApi.Modules.AntivirusAssessment;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public class InfosecRiskAssessmentModelConfiguration : IEntityTypeConfiguration<InfosecRiskAssessmentModel>
    {
        public void Configure(EntityTypeBuilder<InfosecRiskAssessmentModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ReasonForRejection).HasMaxLength(int.MaxValue);
            builder.Property(x => x.AssetDescription).HasMaxLength(int.MaxValue);
            builder.Property(x => x.Objective).HasMaxLength(int.MaxValue);
            builder.Property(x => x.Vulnerability).HasMaxLength(int.MaxValue);
            builder.Property(x => x.ControlEffective).HasMaxLength(int.MaxValue);
            builder.Property(x => x.AdditionalInformation).HasMaxLength(int.MaxValue);
            builder.Property(x => x.Threat).HasMaxLength(int.MaxValue);
            builder.Property(x => x.ActionOwner).HasMaxLength(int.MaxValue);
            builder.Property(x => x.ActionOwnerEmail).HasMaxLength(int.MaxValue);
        }
    }
}
