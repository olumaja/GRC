using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure
{
    public class DocumentRSCAProcessLogConfiguration : IEntityTypeConfiguration<DocumentRSCAProcessLog>
    {
        public void Configure(EntityTypeBuilder<DocumentRSCAProcessLog> builder)
        {
            builder.ToTable(nameof(DocumentRSCAProcessLog));
            builder.HasKey(e => e.Id);
            builder.Property(l => l.DocumentRSCAProcessJsonDump).HasMaxLength(int.MaxValue);
        }
    }
}
