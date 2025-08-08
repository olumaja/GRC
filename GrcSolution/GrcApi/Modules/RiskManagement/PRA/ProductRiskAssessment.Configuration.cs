using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcApi.Modules.RiskManagement.PRA
{
    public class ProductRiskAssessmentConfiguration : IEntityTypeConfiguration<ProductRiskAssessment>
    {
        public void Configure(EntityTypeBuilder<ProductRiskAssessment> builder)
        {
            builder.ToTable(nameof(ProductRiskAssessment));
            builder.Property(b => b.BusinessId).IsRequired();
            builder.Property(b => b.DepartmentId).IsRequired();
            builder.Property(b => b.UnitId).IsRequired();
            builder.Property(b => b.ProductName).IsRequired();
            builder.Property(b => b.ProductDescription).IsRequired().HasMaxLength(500);
            builder.Property(b => b.QuestionOrRecomendation).HasMaxLength(500);
            builder.Property(b => b.OwnerResponse).HasMaxLength(500);
            builder.Property(b => b.ReseasonForRejection).HasMaxLength(500);
            builder.HasKey(b => b.Id);

            builder.HasMany(itm => itm.ProductAssessRisks)
           .WithOne(d => d.ProductRiskAssessment)
           .HasForeignKey(d => d.ProductRiskAssementId)
           // delete all the children when the parent is deleted
           .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
