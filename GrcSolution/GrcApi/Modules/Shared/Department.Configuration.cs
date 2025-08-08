using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using Arm.GrcTool.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable(nameof(Department));
            builder.Property(b => b.Name).IsRequired();
            builder.HasKey(b => b.Id);
            builder.HasMany(itm => itm.Units)
            .WithOne(d => d.Department)
            .HasForeignKey(d => d.DepartmentId)
            //deletes all the children when the parent is deleted
            .OnDelete(DeleteBehavior.Cascade);

            //unique constraint
            builder.HasIndex(e => new { e.BusinessEntityId, e.Name })
            .IsUnique();

            //seed data
            builder.HasData(

            #region ARM Securities departments
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMSecurities), "Research", new Guid(ARMSecurities.Research)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMSecurities), "ARM Financial Advisers", new Guid(ARMSecurities.ARMFinancialAdvisers)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMSecurities), "Back Office Operations", new Guid(ARMSecurities.BackOfficeOperations)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMSecurities), "Trading / Bokerage", new Guid(ARMSecurities.TradingOrBokerage)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMSecurities), "Customer Experience", new Guid(ARMSecurities.CustomerExperience)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMSecurities), "Finance / Treasury", new Guid(ARMSecurities.FinanceOrTreasury)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMSecurities), "Information Technology", new Guid(ARMSecurities.InformationTechnology)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMSecurities), "Risk Management", new Guid(ARMSecurities.RiskManagement)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMSecurities), "Project Management Office", new Guid(ARMSecurities.ProjectManagementOffice)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMSecurities), "Internal Control / Internal Audit", new Guid(ARMSecurities.InternalControlOrInternalAudit)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMSecurities), "ARM Academy", new Guid(ARMSecurities.ARMAcademy)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMSecurities), "Coporate Transformation Unit", new Guid(ARMSecurities.CoporateTransformationUnit)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMSecurities), "Administration", new Guid(ARMSecurities.Administration)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMSecurities), "Marketing and Corporate Communications", new Guid(ARMSecurities.MarketingandCorporateCommunications)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMSecurities), "Corporate Strategy", new Guid(ARMSecurities.CorporateStrategy)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMSecurities), "Legal & Compliance", new Guid(ARMSecurities.LegalAndCompliance)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMSecurities), "Human Capital Management", new Guid(ARMSecurities.HumanCapitalManagement)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMSecurities), "ARM Security", new Guid(ARMSecurities.ARMSecurity)),
            #endregion

            #region ARMIM departments
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMIM), "Investment Management", new Guid(ARMIM.InvestmentManagement)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMIM), "Business Development", new Guid(ARMIM.BusinessDevelopment)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMIM), "Retail Sales", new Guid(ARMIM.RetailSales)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMIM), "Back Office Operations", new Guid(ARMIM.BackOfficeOperations)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMIM), "Customer Experience", new Guid(ARMIM.CustomerExperience)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMIM), "Finance / Treasury", new Guid(ARMIM.FinanceOrTreasury)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMIM), "Business Support", new Guid(ARMIM.BusinessSupport)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMIM), "Information Technology", new Guid(ARMIM.InformationTechnology)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMIM), "Risk Management", new Guid(ARMIM.RiskManagement)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMIM), "Project Management Office", new Guid(ARMIM.ProjectManagementOffice)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMIM), "Internal Control / Internal Audit", new Guid(ARMIM.InternalControlOrInternalAudit)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMIM), "ARM Academy", new Guid(ARMIM.ARMAcademy)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMIM), "Coporate Transformation Unit", new Guid(ARMIM.CoporateTransformationUnit)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMIM), "Administration", new Guid(ARMIM.Administration)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMIM), "Marketing and Corporate Communications", new Guid(ARMIM.MarketingandCorporateCommunications)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMIM), "Corporate Strategy", new Guid(ARMIM.CorporateStrategy)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMIM), "Legal & Compliance", new Guid(ARMIM.LegalAndCompliance)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMIM), "Human Capital Management", new Guid(ARMIM.HumanCapitalManagement)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMIM), "Research", new Guid(ARMIM.Research)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMIM), "Operations Settlement", new Guid(ARMIM.OperationsSettlement)),
            #endregion

            #region ARMHoldCo departments
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMHoldCo), "Proprietary and Principal Transactions", new Guid(ARMHoldCo.ProprietaryandPrincipalTransactions)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMHoldCo), "HoldCo Sales", new Guid(ARMHoldCo.HoldCoSales)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMHoldCo), "Back Office Operations", new Guid(ARMHoldCo.BackOfficeOperations)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMHoldCo), "Customer Experience", new Guid(ARMHoldCo.CustomerExperience)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMHoldCo), "Finance / Treasury", new Guid(ARMHoldCo.FinanceOrTreasury)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMHoldCo), "Information Technology", new Guid(ARMHoldCo.InformationTechnology)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMHoldCo), "Risk Management", new Guid(ARMHoldCo.RiskManagement)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMHoldCo), "Project Management Office", new Guid(ARMHoldCo.ProjectManagementOffice)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMHoldCo), "Internal Control / Internal Audit", new Guid(ARMHoldCo.InternalControlOrInternalAudit)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMHoldCo), "ARM Academy", new Guid(ARMHoldCo.ARMAcademy)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMHoldCo), "Coporate Transformation Unit", new Guid(ARMHoldCo.CoporateTransformationUnit)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMHoldCo), "Administration", new Guid(ARMHoldCo.Administration)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMHoldCo), "Marketing and Corporate Communications", new Guid(ARMHoldCo.MarketingandCorporateCommunications)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMHoldCo), "Corporate Strategy", new Guid(ARMHoldCo.CorporateStrategy)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMHoldCo), "Legal & Compliance", new Guid(ARMHoldCo.LegalAndCompliance)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMHoldCo), "Human Capital Management", new Guid(ARMHoldCo.HumanCapitalManagement)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMHoldCo), "ARM HoldCo", new Guid(ARMHoldCo.ARMHoldCompany)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMHoldCo), "Treasury Operations", new Guid(ARMHoldCo.TreasuryOperations)),
                Department.Create(new Guid(BusinessEntitySeedGuids.ARMHoldCo), "Treasury Sales", new Guid(ARMHoldCo.TreasurySales)),

            #endregion

            #region ARMTrustees departments
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMTrustees), "Private Trust", new Guid(ARMTrustees.PrivateTrust)),
                    Department.Create(new Guid((BusinessEntitySeedGuids.ARMTrustees)), "Commercial Trust", new Guid(ARMTrustees.CommercialTrust)),
                    Department.Create(new Guid((BusinessEntitySeedGuids.ARMTrustees)), "Investment Management", new Guid(ARMTrustees.InvestmentManagement)),
                    Department.Create(new Guid((BusinessEntitySeedGuids.ARMTrustees)), "Back Office Operations", new Guid(ARMTrustees.BackOfficeOperations)),
                    Department.Create(new Guid((BusinessEntitySeedGuids.ARMTrustees)), "Customer Experience", new Guid(ARMTrustees.CustomerExperience)),
                    Department.Create(new Guid((BusinessEntitySeedGuids.ARMTrustees)), "Finance / Treasury", new Guid(ARMTrustees.FinanceOrTreasury)),
                    Department.Create(new Guid((BusinessEntitySeedGuids.ARMTrustees)), "Business Support", new Guid(ARMTrustees.BusinessSupport)),
                    Department.Create(new Guid((BusinessEntitySeedGuids.ARMTrustees)), "Information Technology", new Guid(ARMTrustees.InformationTechnology)),
                    Department.Create(new Guid((BusinessEntitySeedGuids.ARMTrustees)), "Risk Management", new Guid(ARMTrustees.RiskManagement)),
                    Department.Create(new Guid((BusinessEntitySeedGuids.ARMTrustees)), "Project Management Office", new Guid(ARMTrustees.ProjectManagementOffice)),
                    Department.Create(new Guid((BusinessEntitySeedGuids.ARMTrustees)), "Internal Control / Internal Audit", new Guid(ARMTrustees.InternalControlOrInternalAudit)),
                    Department.Create(new Guid((BusinessEntitySeedGuids.ARMTrustees)), "ARM Academy", new Guid(ARMTrustees.ARMAcademy)),
                    Department.Create(new Guid((BusinessEntitySeedGuids.ARMTrustees)), "Coporate Transformation Unit", new Guid(ARMTrustees.CoporateTransformationUnit)),
                    Department.Create(new Guid((BusinessEntitySeedGuids.ARMTrustees)), "Administration", new Guid(ARMTrustees.Administration)),
                    Department.Create(new Guid((BusinessEntitySeedGuids.ARMTrustees)), "Marketing and Corporate Communications", new Guid(ARMTrustees.MarketingandCorporateCommunications)),
                    Department.Create(new Guid((BusinessEntitySeedGuids.ARMTrustees)), "Corporate Strategy", new Guid(ARMTrustees.CorporateStrategy)),
                    Department.Create(new Guid((BusinessEntitySeedGuids.ARMTrustees)), "Legal & Compliance", new Guid(ARMTrustees.LegalAndCompliance)),
                    Department.Create(new Guid((BusinessEntitySeedGuids.ARMTrustees)), "Human Capital Management", new Guid(ARMTrustees.HumanCapitalManagement)),
                #endregion

                #region ARMHarithInfracstrureInvestementLimitedDepartments
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMHarithInfracstrureInvestementLimited), "ARM Harith Infrastructure Investment Ltd", new Guid(ARMHarithInfracstrureInvestementLimited.ARMHarithInfrastructureInvestmentLtd)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMHarithInfracstrureInvestementLimited), "Customer Experience", new Guid(ARMHarithInfracstrureInvestementLimited.CustomerExperience)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMHarithInfracstrureInvestementLimited), "Finance / Treasury", new Guid(ARMHarithInfracstrureInvestementLimited.FinanceOrTreasury)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMHarithInfracstrureInvestementLimited), "Information Technology", new Guid(ARMHarithInfracstrureInvestementLimited.InformationTechnology)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMHarithInfracstrureInvestementLimited), "Risk Management", new Guid(ARMHarithInfracstrureInvestementLimited.RiskManagement)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMHarithInfracstrureInvestementLimited), "Project Management Office", new Guid(ARMHarithInfracstrureInvestementLimited.ProjectManagementOffice)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMHarithInfracstrureInvestementLimited), "Internal Control / Internal Audit", new Guid(ARMHarithInfracstrureInvestementLimited.InternalControlOrInternalAudit)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMHarithInfracstrureInvestementLimited), "ARM Academy", new Guid(ARMHarithInfracstrureInvestementLimited.ARMAcademy)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMHarithInfracstrureInvestementLimited), "Coporate Transformation Unit", new Guid(ARMHarithInfracstrureInvestementLimited.CoporateTransformationUnit)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMHarithInfracstrureInvestementLimited), "Administration", new Guid(ARMHarithInfracstrureInvestementLimited.Administration)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMHarithInfracstrureInvestementLimited), "Marketing and Corporate Communications", new Guid(ARMHarithInfracstrureInvestementLimited.MarketingandCorporateCommunications)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMHarithInfracstrureInvestementLimited), "Corporate Strategy", new Guid(ARMHarithInfracstrureInvestementLimited.CorporateStrategy)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMHarithInfracstrureInvestementLimited), "Legal & Compliance", new Guid(ARMHarithInfracstrureInvestementLimited.LegalAndCompliance)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMHarithInfracstrureInvestementLimited), "Human Capital Management", new Guid(ARMHarithInfracstrureInvestementLimited.HumanCapitalManagement)),
                #endregion

                #region SharedServices departments
                    Department.Create(new Guid(BusinessEntitySeedGuids.SharedServices), "Customer Experience", new Guid(SharedServices.CustomerExperience)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.SharedServices), "Finance / Treasury", new Guid(SharedServices.FinanceOrTreasury)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.SharedServices), "Business Support", new Guid(SharedServices.BusinessSupport)),//blank error
                    Department.Create(new Guid(BusinessEntitySeedGuids.SharedServices), "Information Technology", new Guid(SharedServices.InformationTechnology)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.SharedServices), "Risk Management", new Guid(SharedServices.RiskManagement)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.SharedServices), "Project Management Office", new Guid(SharedServices.ProjectManagementOffice)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.SharedServices), "Internal Control / Internal Audit", new Guid(SharedServices.InternalControlOrInternalAudit)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.SharedServices), "ARM Academy", new Guid(SharedServices.ARMAcademy)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.SharedServices), "Coporate Transformation Unit", new Guid(SharedServices.CoporateTransformationUnit)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.SharedServices), "Administration", new Guid(SharedServices.Administration)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.SharedServices), "Marketing and Corporate Communications", new Guid(SharedServices.MarketingandCorporateCommunications)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.SharedServices), "Corporate Strategy", new Guid(SharedServices.CorporateStrategy)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.SharedServices), "Legal & Compliance", new Guid(SharedServices.LegalAndCompliance)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.SharedServices), "Human Capital Management", new Guid(SharedServices.HumanCapitalManagement)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.SharedServices), "Information Security", new Guid(SharedServices.InformationSecurity)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.SharedServices), "Company Secretariat", new Guid(SharedServices.CompanySecretariat)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.SharedServices), "Environmental, Social and Governance", new Guid(SharedServices.EnvironmentalSocialAndGovernance)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.SharedServices), "Data and Insights", new Guid(SharedServices.DataAndInsights)),
            #endregion

            #region ARMAgriBusiness departments
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMAgriBusiness), "ARM Agricbusiness Fund Manager Ltd", new Guid(ARMAgriBusiness.ARMAgricbusinessFundManagerLtd)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMAgriBusiness), "Finance / Treasury", new Guid(ARMAgriBusiness.FinanceOrTreasury)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMAgriBusiness), "Information Technology", new Guid(ARMAgriBusiness.InformationTechnology)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMAgriBusiness), "Risk Management", new Guid(ARMAgriBusiness.RiskManagement)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMAgriBusiness), "Project Management Office", new Guid(ARMAgriBusiness.ProjectManagementOffice)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMAgriBusiness), "Internal Control / Internal Audit", new Guid(ARMAgriBusiness.InternalControlOrInternalAudit)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMAgriBusiness), "ARM Academy", new Guid(ARMAgriBusiness.ARMAcademy)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMAgriBusiness), "Coporate Transformation Unit", new Guid(ARMAgriBusiness.CoporateTransformationUnit)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMAgriBusiness), "Administration", new Guid(ARMAgriBusiness.Administration)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMAgriBusiness), "Marketing and Corporate Communications", new Guid(ARMAgriBusiness.MarketingandCorporateCommunications)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMAgriBusiness), "Corporate Strategy", new Guid(ARMAgriBusiness.CorporateStrategy)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMAgriBusiness), "Legal & Compliance", new Guid(ARMAgriBusiness.LegalAndCompliance)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMAgriBusiness), "Human Capital Management", new Guid(ARMAgriBusiness.HumanCapitalManagement)),
                #endregion

                #region MixtaNigeria departments
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Mixta Nigeria Sales", new Guid(MixtaNigeria.MixtaNigeriaSales)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Summerville / Lakowe", new Guid(MixtaNigeria.SummervilleOrLakowe)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Hospitality and Retail Management", new Guid(MixtaNigeria.HospitalityandRetailManagement)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Mixta Nigeria Operations", new Guid(MixtaNigeria.MixtaNigeriaOperations)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Technical / Projects", new Guid(MixtaNigeria.TechnicalOrProjects)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Facility Management", new Guid(MixtaNigeria.FacilityManagement)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Design & Construction", new Guid(MixtaNigeria.DesignAndConstruction)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Adiva", new Guid(MixtaNigeria.Adiva)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Beechwood", new Guid(MixtaNigeria.Beechwood)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Greater Port Harcour Golf Club", new Guid(MixtaNigeria.GreaterPortHarcourGolfClub)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "TSD Ltd", new Guid(MixtaNigeria.TSDLtd)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Oakland Limited", new Guid(MixtaNigeria.OaklandLimited)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Lakowe Lakes Golf Club Ltd", new Guid(MixtaNigeria.LakoweLakesGolfClubLtd)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Townsville", new Guid(MixtaNigeria.Townsville)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Farapark", new Guid(MixtaNigeria.Farapark)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Crosstown Iju", new Guid(MixtaNigeria.CrosstownIju)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Business Planning", new Guid(MixtaNigeria.BusinessPlanning)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Finance / Treasury", new Guid(MixtaNigeria.FinanceOrTreasury)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Information Technology", new Guid(MixtaNigeria.InformationTechnology)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Risk Management", new Guid(MixtaNigeria.RiskManagement)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Internal Control / Internal Audit", new Guid(MixtaNigeria.InternalControlOrInternalAudit)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "ARM Academy", new Guid(MixtaNigeria.ARMAcademy)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Corporate Transformation Unit", new Guid(MixtaNigeria.CorporateTransformationUnit)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Administration", new Guid(MixtaNigeria.Administration)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Marketing and Corporate Communications", new Guid(MixtaNigeria.MarketingandCorporateCommunications)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Corporate Strategy", new Guid(MixtaNigeria.CorporateStrategy)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Legal & Compliance", new Guid(MixtaNigeria.LegalAndCompliance)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.MixtaNigeria), "Human Capital Management", new Guid(MixtaNigeria.HumanCapitalManagement)),
                #endregion

                #region ARMDigitalFinancialServices departments
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMDigitalFinancialServices), "Digital Financial Services", new Guid(ARMDigitalFinancialServices.DigitalFinancialServices)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMDigitalFinancialServices), "Investment Management", new Guid(ARMDigitalFinancialServices.InvestmentManagement)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMDigitalFinancialServices), "Back Office Operations", new Guid(ARMDigitalFinancialServices.BackOfficeOperations)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMDigitalFinancialServices), "Customer Experience", new Guid(ARMDigitalFinancialServices.CustomerExperience)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMDigitalFinancialServices), "Finance / Treasury", new Guid(ARMDigitalFinancialServices.FinanceOrTreasury)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMDigitalFinancialServices), "Business Support", new Guid(ARMDigitalFinancialServices.BusinessSupport)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMDigitalFinancialServices), "Information Technology", new Guid(ARMDigitalFinancialServices.InformationTechnology)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMDigitalFinancialServices), "Risk Management", new Guid(ARMDigitalFinancialServices.RiskManagement)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMDigitalFinancialServices), "Project Management Office", new Guid(ARMDigitalFinancialServices.ProjectManagementOffice)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMDigitalFinancialServices), "Internal Control / Internal Audit", new Guid(ARMDigitalFinancialServices.InternalControlOrInternalAudit)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMDigitalFinancialServices), "ARM Academy", new Guid(ARMDigitalFinancialServices.ARMAcademy)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMDigitalFinancialServices), "Coporate Transformation Unit", new Guid(ARMDigitalFinancialServices.CoporateTransformationUnit)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMDigitalFinancialServices), "Administration", new Guid(ARMDigitalFinancialServices.Administration)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMDigitalFinancialServices), "Marketing and Corporate Communications", new Guid(ARMDigitalFinancialServices.MarketingandCorporateCommunications)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMDigitalFinancialServices), "Corporate Strategy", new Guid(ARMDigitalFinancialServices.CorporateStrategy)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMDigitalFinancialServices), "Legal and Compliance", new Guid(ARMDigitalFinancialServices.LegalAndCompliance)),
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMDigitalFinancialServices), "Human Capital Management", new Guid(ARMDigitalFinancialServices.HumanCapitalManagement)),
                #endregion

                #region ARMHIIL departments
                    Department.Create(new Guid(BusinessEntitySeedGuids.ARMHIIL), "ARM HIIL", new Guid(ARMHIILs.HIIL)),

                 #endregion

                 #region ARMCapital departments
                   Department.Create(new Guid(BusinessEntitySeedGuids.ARMCapital), "ARM Capital", new Guid(ARMCapitals.Capital))

                #endregion


            );
        }
    }
}