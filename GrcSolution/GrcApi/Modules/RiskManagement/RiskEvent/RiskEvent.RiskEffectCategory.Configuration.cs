using Arm.GrcTool.Domain.RiskEvent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure.Data
{
    public class RiskEffectCategoryConfiguration : IEntityTypeConfiguration<RiskEffectCategory>
    {
        public void Configure(EntityTypeBuilder<RiskEffectCategory> builder)
        {
            builder.ToTable(nameof(RiskEffectCategory));
            builder.Property(b => b.Name).IsRequired();
            builder.HasKey(b => b.Id);

            //Data seeding
            builder.HasData(
                RiskEffectCategory.Create("Legal Liability"),
                RiskEffectCategory.Create("Regulatory Action"),
                RiskEffectCategory.Create("Loss or Damage to Assets"),
                RiskEffectCategory.Create("Restitution"),
                RiskEffectCategory.Create("Loss of Recourse"),
                RiskEffectCategory.Create("Write-down"),
                RiskEffectCategory.Create("Outsourcing / Vendor Costs"),
                RiskEffectCategory.Create("Reputational Loss"),
                RiskEffectCategory.Create("Reduced operational capacity")
            ); 
        }
    }
}
