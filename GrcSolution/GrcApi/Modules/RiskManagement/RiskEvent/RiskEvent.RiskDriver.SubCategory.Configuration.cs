using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcApi.Modules.RiskManagement.SeedGuids;

namespace Arm.GrcTool.Infrastructure
{
    public class RiskDriverSubCategoryConfiguration : IEntityTypeConfiguration<RiskDriverSubCategory>
    {
        public void Configure(EntityTypeBuilder<RiskDriverSubCategory> builder)
        {
            builder.ToTable(nameof(RiskDriverSubCategory));
            builder.Property(b => b.Name).IsRequired().HasMaxLength(500);
            builder.HasKey(b => b.Id);

            //unique constraint
            builder.HasIndex(r => new { r.RiskDriverCategoryId, r.Name })
                .IsUnique();

            builder.HasData(
            #region People
                    RiskDriverSubCategory.Create(new Guid(PeopleRiskCategories.Skills), "Staff selection (poor educational levels etc)"),
                    RiskDriverSubCategory.Create(new Guid(PeopleRiskCategories.Skills), "Inadequate skills development (e.g. training)"),
                    RiskDriverSubCategory.Create(new Guid(PeopleRiskCategories.Skills), "Key man retention"),
                    RiskDriverSubCategory.Create(new Guid(PeopleRiskCategories.Skills), "Lack of management oversight"),
                    RiskDriverSubCategory.Create(new Guid(PeopleRiskCategories.Skills), "Lack of staff experience in relation to performed tasks"),
                    RiskDriverSubCategory.Create(new Guid(PeopleRiskCategories.Skills), "Negligence of duties and responsibilities"),
                    RiskDriverSubCategory.Create(new Guid(PeopleRiskCategories.Skills), "Performance failure of Support unit"),
                    RiskDriverSubCategory.Create(new Guid(PeopleRiskCategories.Motivation), "Inadequate staff compensation (basic salaries, bonuses, reward-system for vigilance etc)"),
                    RiskDriverSubCategory.Create(new Guid(PeopleRiskCategories.Motivation), "Working Atmosphere (level of stress, social climate, interpersonal relationships, malicious Intent)"),
                    RiskDriverSubCategory.Create(new Guid(PeopleRiskCategories.Motivation), "Workload perception (lack of clearly stated goals and objectives etc)"),
                    RiskDriverSubCategory.Create(new Guid(PeopleRiskCategories.Motivation), "Corruption / Criminal Intent"),
                    RiskDriverSubCategory.Create(new Guid(PeopleRiskCategories.Capacity), "Staff shortages within unit (lack of capacity in unit)"),
                    RiskDriverSubCategory.Create(new Guid(PeopleRiskCategories.Capacity), "Staff shortages within support units (lack of capacity in supporting units)"),
                    RiskDriverSubCategory.Create(new Guid(PeopleRiskCategories.IndustrialAction), "Disagreement on issues of mutual interest"),
                    RiskDriverSubCategory.Create(new Guid(PeopleRiskCategories.IndustrialAction), "Failure to consult organised labour on HR policies"),
            #endregion

            #region Process
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.ProcessComplexity), "Complexity of policies / procedures"),
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.ProcessComplexity), "Complexity of client agreements"),
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.ProcessComplexity), "Process inappropriate for geographic / physical location"),
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.ProcessComplexity), "Automated process failures"),
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.ChangeManagement), "Introduction of new processes and procedures"),
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.ChangeManagement), "Internal communication failures"),
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.ChangeManagement), "Lack of documented guidelines for new processes / services developed"),
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.ChangeManagement), "Rate of change / diversification of products / services"),
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.QualityOfControls), "Inadequate controls in place (specific / pervasive / monitoring)"),
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.QualityOfControls), "Lack of reporting of control weaknesses / failures"),
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.QualityOfControls), "Failure of automated controls"),
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.QualityOfControls), "Management ability to override controls or processes"),
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.RolesAndResponsibilities), "Inadequate clarity of authority (ultimate decision maker) and reporting lines"),
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.RolesAndResponsibilities), "Inadequate delegation of power (scope, limits, communication, reporting etc)"),
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.RolesAndResponsibilities), "Inadequate definition of duties and responsibilities"),
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.RolesAndResponsibilities), "Inadequate segregation of duties"),
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.AdequacyOfProcedures), "Lack of formal procedures / guidelines"),
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.AdequacyOfProcedures), "Inadequate / incomplete procedure (Internal communication failure)"),
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.AdequacyOfProcedures), "Lack of access to internal procedures / guidelines"),
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.AdequacyOfProcedures), "Lack of SLA's between internal units"),
                    RiskDriverSubCategory.Create(new Guid(ProcessRiskCategories.AdequacyOfProcedures), "Non adherence to processes and procedures"),
            #endregion

            #region Systems
                    RiskDriverSubCategory.Create(new Guid(SystemsRiskCategories.SystemAdequacy), "System inadequate for nature of required tasks"),
                    RiskDriverSubCategory.Create(new Guid(SystemsRiskCategories.SystemAdequacy), "System inadequate for volume of activities (speed, storage etc)"),
                    RiskDriverSubCategory.Create(new Guid(SystemsRiskCategories.SystemAdequacy), "Inadequate technical or functional documentation (user guides)"),
                    RiskDriverSubCategory.Create(new Guid(SystemsRiskCategories.SystemAvailability), "IT helpdesk inefficiencies"),
                    RiskDriverSubCategory.Create(new Guid(SystemsRiskCategories.SystemAvailability), "Technological obsolescence"),
                    RiskDriverSubCategory.Create(new Guid(SystemsRiskCategories.SystemAvailability), "Software failure (Software / data corruption etc)"),
                    RiskDriverSubCategory.Create(new Guid(SystemsRiskCategories.SystemAvailability), "Hardware failure (Failure of wearing parts etc)"),
                    RiskDriverSubCategory.Create(new Guid(SystemsRiskCategories.SystemAvailability), "System unavailable due to extended period of power outage"),
                    RiskDriverSubCategory.Create(new Guid(SystemsRiskCategories.SystemAvailability), "Other Equipment failure (Failure of other assets/ equipments other than IT related equipments etc.)"),
                    RiskDriverSubCategory.Create(new Guid(SystemsRiskCategories.SystemSecurity), "Inadequate security of user profiles (passwords etc)"),
                    RiskDriverSubCategory.Create(new Guid(SystemsRiskCategories.SystemSecurity), "Inadequate security over critical data areas"),
                    RiskDriverSubCategory.Create(new Guid(SystemsRiskCategories.SystemSecurity), "Inadequate logical system control checks (e.g. log monitoring)"),
                    RiskDriverSubCategory.Create(new Guid(SystemsRiskCategories.SystemComplexity), "Inadequate synergy between disparate systems with common users"),
                    RiskDriverSubCategory.Create(new Guid(SystemsRiskCategories.SystemComplexity), "Poor systems user interface"),
                    RiskDriverSubCategory.Create(new Guid(SystemsRiskCategories.DataProtection), "Inadequate system / data backups"),
                    RiskDriverSubCategory.Create(new Guid(SystemsRiskCategories.DataProtection), "Virus / Intrusion attacks"),
            #endregion

            #region ExternalEvents
                    RiskDriverSubCategory.Create(new Guid(ExternalEventsRiskCategories.Outsourcing), "Lack of formalization of relationship with outsourcer (duties, deliverables etc)"),
                    RiskDriverSubCategory.Create(new Guid(ExternalEventsRiskCategories.Outsourcing), "Performance failure of outsourced vendor / service provider"),
                    RiskDriverSubCategory.Create(new Guid(ExternalEventsRiskCategories.Regulatory), "Regulatory compliance breaches"),
                    RiskDriverSubCategory.Create(new Guid(ExternalEventsRiskCategories.Regulatory), "Government discretion to impose will and decisions without prior notice."),
                    RiskDriverSubCategory.Create(new Guid(ExternalEventsRiskCategories.Regulatory), "Ambiguity in Regulations"),
                    RiskDriverSubCategory.Create(new Guid(ExternalEventsRiskCategories.Legal), "Inadequate response to legal / contractual disputes"),
                    RiskDriverSubCategory.Create(new Guid(ExternalEventsRiskCategories.Legal), "Inadequate pre-agreement investigations"),
                    RiskDriverSubCategory.Create(new Guid(ExternalEventsRiskCategories.Legal), "Inadequate legal structures"),
                    RiskDriverSubCategory.Create(new Guid(ExternalEventsRiskCategories.SocialAndNaturalEnvironment), "Natural disasters (Fire, floods, etc)"),
                    RiskDriverSubCategory.Create(new Guid(ExternalEventsRiskCategories.SocialAndNaturalEnvironment), "External attacks (burglary, robberies, vandalism etc)"),
                    RiskDriverSubCategory.Create(new Guid(ExternalEventsRiskCategories.SocialAndNaturalEnvironment), "Political or social unrest"),
                    RiskDriverSubCategory.Create(new Guid(ExternalEventsRiskCategories.SocialAndNaturalEnvironment), "Unethical Social and Business Environment"),
                    RiskDriverSubCategory.Create(new Guid(ExternalEventsRiskCategories.ClientOrCustomerRelations), "Inadequate/inappropriate information provided by the client"),
                    RiskDriverSubCategory.Create(new Guid(ExternalEventsRiskCategories.ClientOrCustomerRelations), "Client/Counterparty Failures"),
                    RiskDriverSubCategory.Create(new Guid(ExternalEventsRiskCategories.ThirdPartyRelations), "Inadequate/inappropriate information provided by third-parties")
            #endregion
                );
        }
    }
}