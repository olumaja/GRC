using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Arm.GrcTool.Domain.Risk;

namespace Arm.GrcTool.Infrastructure
{
    public class RiskEventTypeConfiguration : IEntityTypeConfiguration<RiskEventType>
    {
        public void Configure(EntityTypeBuilder<RiskEventType> builder)
        {
            builder.ToTable(nameof(RiskEventType));
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("ID");
            builder.Property(c => c.Name).HasColumnName("NAME").IsRequired();

            //Data Seeding
            builder.HasData(
                RiskEventType.Create(Guid.Parse("33AADBFC-FA8A-448A-93D4-0C57E1618BD3"), "Internal Fraud"),
                RiskEventType.Create(Guid.Parse("92FB8BA9-3B62-4D6A-ACB1-A4111B2196AD"), "External Fraud"),
                RiskEventType.Create(Guid.Parse("D47BD1F5-C11E-4F25-9854-E028A566DB5C"), "Employment Practices and Workplace Safety"),
                RiskEventType.Create(Guid.Parse("2D5E2984-086E-41FA-8AF8-28EDE5D4079C"), "Clients, Products and Business Practices"),
                RiskEventType.Create(Guid.Parse("AC12CF01-4E9B-4CD0-B578-9E1016A3E4C1"), "Disasters and Other Events"),
                RiskEventType.Create(Guid.Parse("468F18E4-D9BE-49A9-AF61-00556B1EB6E8"), "Business Disruption and System Failures"),
                RiskEventType.Create(Guid.Parse("B0FDD290-1EBF-4A08-803F-07A69D349B4D"), "Execution, Delivery and Process Management")
            );

        }
    }
}
