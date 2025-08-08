using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrcApi.Modules.Compliance.CompliancePlanning
{
    public class CompliancePlanningModel : IEntityTypeConfiguration<ComplianceCalendar>
    {
        public void Configure(EntityTypeBuilder<ComplianceCalendar> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("NameOfReport").HasMaxLength(int.MaxValue);
            builder.Property(x => x.FirmToSubmit).HasMaxLength(int.MaxValue);
            builder.Property(x => x.ReasonForRejection).HasMaxLength(500);
        }
    }
}
