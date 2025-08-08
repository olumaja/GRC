using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcApi.Modules.RiskManagement.PRA
{
    public class ProductAssessRiskConfiguration : IEntityTypeConfiguration<ProductAssessRisk>
    {
        public void Configure(EntityTypeBuilder<ProductAssessRisk> builder)
        {
            builder.ToTable(nameof(ProductAssessRisk));
            builder.Property(b => b.ProductRiskCategory).IsRequired();
            builder.Property(b => b.Description).IsRequired().HasMaxLength(500);
            builder.Property(b => b.Rating).IsRequired();
            builder.Property(b => b.ProductRiskAssementId).IsRequired();
            builder.Property(builder => builder.ProductOwnerResponse).HasMaxLength(500);
            builder.HasKey(b => b.Id);

        }
    }
}
