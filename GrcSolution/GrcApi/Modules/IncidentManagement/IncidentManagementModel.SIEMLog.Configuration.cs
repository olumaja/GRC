using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    public class SIEMLogConfiguration : IEntityTypeConfiguration<SIEMLog>
    {
        public void Configure(EntityTypeBuilder<SIEMLog> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.EventDescription).HasMaxLength(int.MaxValue);
            builder.Property(e => e.ConfigurationDetail).HasMaxLength(int.MaxValue);
            builder.Property(e => e.Observation).HasMaxLength(int.MaxValue);
            builder.Property(e => e.MaliciousReputation).HasMaxLength(int.MaxValue);
        }
    }
}
