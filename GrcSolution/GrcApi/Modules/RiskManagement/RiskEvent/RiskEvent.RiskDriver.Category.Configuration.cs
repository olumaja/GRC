using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcApi.Modules.RiskManagement.SeedGuids;

namespace Arm.GrcTool.Infrastructure
{
    public class RiskDriverCategoryConfiguration : IEntityTypeConfiguration<RiskDriverCategory>
    {
        public void Configure(EntityTypeBuilder<RiskDriverCategory> builder)
        {
            builder.ToTable(nameof(RiskDriverCategory));
            builder.Property(b => b.Name).IsRequired();
            builder.HasKey(b => b.Id);
            builder.HasMany(r => r.RiskDriverSubCategories)
                .WithOne(c => c.RiskDriverCategory)
                .HasForeignKey(c => c.RiskDriverCategoryId);

            //unique constraint
            builder.HasIndex(r => new { r.RiskDriverId, r.Name })
                .IsUnique();

            builder.HasData
                (
            #region People
                    RiskDriverCategory.Create(new Guid(RiskDriverSeedGuids.People), "Skills", new Guid(PeopleRiskCategories.Skills)),
                    RiskDriverCategory.Create(new Guid(RiskDriverSeedGuids.People), "Motivation", new Guid(PeopleRiskCategories.Motivation)),
                    RiskDriverCategory.Create(new Guid(RiskDriverSeedGuids.People), "Capacity", new Guid(PeopleRiskCategories.Capacity)),
                    RiskDriverCategory.Create(new Guid(RiskDriverSeedGuids.People), "Industrial Action", new Guid(PeopleRiskCategories.IndustrialAction)),
            #endregion

            #region Process
                    RiskDriverCategory.Create(new Guid(RiskDriverSeedGuids.Process), "Process complexity", new Guid(ProcessRiskCategories.ProcessComplexity)),
                    RiskDriverCategory.Create(new Guid(RiskDriverSeedGuids.Process), "Change management", new Guid(ProcessRiskCategories.ChangeManagement)),
                    RiskDriverCategory.Create(new Guid(RiskDriverSeedGuids.Process), "Quality of controls", new Guid(ProcessRiskCategories.QualityOfControls)),
                    RiskDriverCategory.Create(new Guid(RiskDriverSeedGuids.Process), "Roles and responsibilities", new Guid(ProcessRiskCategories.RolesAndResponsibilities)),
                    RiskDriverCategory.Create(new Guid(RiskDriverSeedGuids.Process), "Adequacy of procedures", new Guid(ProcessRiskCategories.AdequacyOfProcedures)),
            #endregion

            #region Systems
                    RiskDriverCategory.Create(new Guid(RiskDriverSeedGuids.Systems), "System adequacy", new Guid(SystemsRiskCategories.SystemAdequacy)),
                    RiskDriverCategory.Create(new Guid(RiskDriverSeedGuids.Systems), "System availability", new Guid(SystemsRiskCategories.SystemAvailability)),
                    RiskDriverCategory.Create(new Guid(RiskDriverSeedGuids.Systems), "System security", new Guid(SystemsRiskCategories.SystemSecurity)),
                    RiskDriverCategory.Create(new Guid(RiskDriverSeedGuids.Systems), "System Complexity", new Guid(SystemsRiskCategories.SystemComplexity)),
                    RiskDriverCategory.Create(new Guid(RiskDriverSeedGuids.Systems), "Data protection", new Guid(SystemsRiskCategories.DataProtection)),
            #endregion

            #region ExternalEvents
                    RiskDriverCategory.Create(new Guid(RiskDriverSeedGuids.ExternalEvents), "Outsourcing", new Guid(ExternalEventsRiskCategories.Outsourcing)),
                    RiskDriverCategory.Create(new Guid(RiskDriverSeedGuids.ExternalEvents), "Regulatory", new Guid(ExternalEventsRiskCategories.Regulatory)),
                    RiskDriverCategory.Create(new Guid(RiskDriverSeedGuids.ExternalEvents), "Legal", new Guid(ExternalEventsRiskCategories.Legal)),
                    RiskDriverCategory.Create(new Guid(RiskDriverSeedGuids.ExternalEvents), "Social, and natural environment", new Guid(ExternalEventsRiskCategories.SocialAndNaturalEnvironment)),
                    RiskDriverCategory.Create(new Guid(RiskDriverSeedGuids.ExternalEvents), "Client / customer relations", new Guid(ExternalEventsRiskCategories.ClientOrCustomerRelations)),
                    RiskDriverCategory.Create(new Guid(RiskDriverSeedGuids.ExternalEvents), "Third-party Relations", new Guid(ExternalEventsRiskCategories.ThirdPartyRelations))
            #endregion
                );
        }
    }
}