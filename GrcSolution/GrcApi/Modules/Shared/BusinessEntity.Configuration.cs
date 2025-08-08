using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using Arm.GrcTool.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure
{
    public class BusinessEntityConfiguration : IEntityTypeConfiguration<BusinessEntity>
    {
        public void Configure(EntityTypeBuilder<BusinessEntity> builder)
        {
            builder.ToTable(nameof(BusinessEntity));
            builder.Property(b => b.Name).IsRequired();
            builder.HasKey(b => b.Id);
            builder.HasMany(itm => itm.Departments)
            .WithOne(d => d.BusinessEntity)
            .HasForeignKey(d => d.BusinessEntityId)
            //deletes all the children when the parent is deleted
            .OnDelete(DeleteBehavior.Cascade);

            //unique constraint
            builder.HasIndex(e => e.Name)
            .IsUnique();

            //Seed Data
            builder.HasData
            (
                BusinessEntity.Create("ARM Securities", new Guid(BusinessEntitySeedGuids.ARMSecurities)),
                BusinessEntity.Create("ARMIM", new Guid(BusinessEntitySeedGuids.ARMIM)),
                BusinessEntity.Create("ARM HoldCo", new Guid(BusinessEntitySeedGuids.ARMHoldCo)),
                BusinessEntity.Create("ARM Trustees", new Guid(BusinessEntitySeedGuids.ARMTrustees)),
                BusinessEntity.Create("ARM Harith Infracstrure Investement Limited", new Guid(BusinessEntitySeedGuids.ARMHarithInfracstrureInvestementLimited)),
                BusinessEntity.Create("Shared Services", new Guid(BusinessEntitySeedGuids.SharedServices)),
                BusinessEntity.Create("ARM AgriBusiness", new Guid(BusinessEntitySeedGuids.ARMAgriBusiness)),
                BusinessEntity.Create("Mixta Nigeria", new Guid(BusinessEntitySeedGuids.MixtaNigeria)),
                BusinessEntity.Create("ARM Digital Financial Services", new Guid(BusinessEntitySeedGuids.ARMDigitalFinancialServices)),
                BusinessEntity.Create("ARM HIIL", new Guid(BusinessEntitySeedGuids.ARMHIIL)),
                BusinessEntity.Create("ARM Capital", new Guid(BusinessEntitySeedGuids.ARMCapital))
            );
        }
    }
}
