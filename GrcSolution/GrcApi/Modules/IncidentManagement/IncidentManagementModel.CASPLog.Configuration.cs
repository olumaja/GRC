using Arm.GrcApi.Modules.IncidentManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    public class CASPLogConfiguration : IEntityTypeConfiguration<CASPLog>
    {
        public void Configure(EntityTypeBuilder<CASPLog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Observation);
        }
    }
}
