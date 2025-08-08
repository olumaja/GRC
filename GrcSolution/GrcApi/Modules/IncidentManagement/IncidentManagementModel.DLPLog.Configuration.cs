using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    public class DLPModelConfiguration : IEntityTypeConfiguration<DLPLog>
    {
        public void Configure(EntityTypeBuilder<DLPLog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ActionTaken).HasMaxLength(int.MaxValue);
        }
    }
}
