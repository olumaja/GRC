using Arm.GrcTool.Domain.RiskControlSelfAssessment;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure
{
    public class DocumentRSCAProcessConfiguration : IEntityTypeConfiguration<DocumentRSCAProcess>
    {
        public void Configure(EntityTypeBuilder<DocumentRSCAProcess> builder)
        {
            builder.ToTable(nameof(DocumentRSCAProcess));
            builder.HasKey(b => b.Id);

            builder.HasMany(d => d.DocumentRSCAProcessLogs)
                .WithOne(l => l.DocumentRSCAProcess)
                .HasForeignKey(l => l.DocumentRSCAProcessId);
        }
    }
}
