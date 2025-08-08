using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    public class LogManagementModelConfiguration : IEntityTypeConfiguration<LogManagement>
    {
        public void Configure(EntityTypeBuilder<LogManagement> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ReasonForRejection).HasMaxLength(int.MaxValue);
            builder.Property(x => x.ActionOwnerRemarks).HasMaxLength(int.MaxValue);
            builder.Property(x => x.InfoSecRemarks).HasMaxLength(int.MaxValue);
            builder.Property(x => x.BusinessJustification).HasMaxLength(int.MaxValue);
        }
    }
}
