using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    public class DAMModelConfiguration : IEntityTypeConfiguration<DAMLog>
    {
        public void Configure(EntityTypeBuilder<DAMLog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.EventDescription).HasMaxLength(int.MaxValue);
            builder.Property(x => x.ConfigurationDetail).HasMaxLength(int.MaxValue);
            builder.Property(x => x.Observation).HasMaxLength(int.MaxValue);
        }
    }
}
