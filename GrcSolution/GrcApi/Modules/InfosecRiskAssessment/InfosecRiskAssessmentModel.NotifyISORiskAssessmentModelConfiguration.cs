using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public class NotifyISORiskAssessmentModelConfiguration : IEntityTypeConfiguration<NotifyISORiskAssessmentModel>
    {
        public void Configure(EntityTypeBuilder<NotifyISORiskAssessmentModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Objective).HasMaxLength(int.MaxValue);           
        }
    }
}
