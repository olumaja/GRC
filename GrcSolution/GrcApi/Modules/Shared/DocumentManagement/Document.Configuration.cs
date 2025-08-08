using Arm.GrcTool.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable(nameof(Document));
            builder.Property(d => d.ModuleItemType).IsRequired();
            builder.Property(d => d.ModuleItemId).IsRequired();
            builder.Property(d => d.FileType).IsRequired().HasMaxLength(100);
            builder.Property(d => d.Blob).IsRequired();
            builder.Property(d => d.Name).HasMaxLength(100);
            builder.HasKey(d => d.Id);
        }
    }
}
