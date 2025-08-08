using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure.Data
{
    public class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.ToTable(nameof(Email));
            builder.Property(e => e.Subject).HasMaxLength(500);
            builder.Property(e => e.To).HasMaxLength(150);
            builder.Property(e => e.CC).HasMaxLength(150);
            builder.Property(e => e.Message).HasColumnType("nvarchar(max)");
            builder.HasKey(e => e.EmailId).IsClustered();
        }
    }
}
