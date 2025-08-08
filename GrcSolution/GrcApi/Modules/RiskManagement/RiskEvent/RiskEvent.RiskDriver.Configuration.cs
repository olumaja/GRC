using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcApi.Modules.RiskManagement.SeedGuids;

namespace Arm.GrcTool.Infrastructure
{
    public class RiskDriverConfiguration : IEntityTypeConfiguration<RiskDriver>
    {
        public void Configure(EntityTypeBuilder<RiskDriver> builder)
        {
            builder.ToTable(nameof(RiskDriver));
            builder.Property(b => b.Name).IsRequired();
            builder.HasKey(b => b.Id);
            builder.HasMany(r => r.RiskDriverCategories)
                .WithOne(c => c.RiskDriver)
                .HasForeignKey(c => c.RiskDriverId);

            //unique constraint
            builder.HasIndex(r => r.Name)
                .IsUnique();

            builder.HasData
                (
                    RiskDriver.Create("People", new Guid(RiskDriverSeedGuids.People)),
                    RiskDriver.Create("Process", new Guid(RiskDriverSeedGuids.Process)),
                    RiskDriver.Create("Systems", new Guid(RiskDriverSeedGuids.Systems)),
                    RiskDriver.Create("ExternalEvents", new Guid(RiskDriverSeedGuids.ExternalEvents))
                );
        }
    }
}