using Arm.GrcTool.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrcApi.Modules.Shared.SessionManagement
{
    public class SessionTrackerConfiguration : IEntityTypeConfiguration<SessionTracker>
    {
        public void Configure(EntityTypeBuilder<SessionTracker> builder)
        {
            builder.ToTable(nameof(SessionTracker));
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).HasColumnName("UserName");
            builder.Property(b => b.Token).HasMaxLength(int.MaxValue);
            builder.Property(b => b.RefreshToken).HasMaxLength(int.MaxValue);
        }
    }
}
