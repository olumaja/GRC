using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    public class EDRModelConfiguration : IEntityTypeConfiguration<EDRLog>
    {
        public void Configure(EntityTypeBuilder<EDRLog> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.EventDescription).HasMaxLength(int.MaxValue);
            builder.Property(e => e.ConfigurationDetail).HasMaxLength(int.MaxValue);
            builder.Property(e => e.ActionTakenByUs).HasMaxLength(int.MaxValue);
            builder.Property(e => e.Observation).HasMaxLength(int.MaxValue);
        }
    }
}
