using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcApi.Modules.IncidentManagement
{
    public class PAMModelConfiguration : IEntityTypeConfiguration<PAMLog>
    {
        public void Configure(EntityTypeBuilder<PAMLog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CorrectiveActionCarriedOut).HasMaxLength(int.MaxValue);
            builder.Property(x => x.IncidentDescription).HasMaxLength(int.MaxValue);
        }
    }
}
