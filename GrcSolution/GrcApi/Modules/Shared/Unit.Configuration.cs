using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using Arm.GrcTool.Domain;
using GrcApi.Modules.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcTool.Infrastructure
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable(nameof(Unit));
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired();
            

            //unique constraint
            builder.HasIndex(e => new { e.DepartmentId, e.Name })
            .IsUnique();

            //seed units data ongoing
            builder.HasData(
            #region ARM Securities units

                Unit.Create(new Guid(ARMSecurities.Research), "Research", new Guid(ARMSecuritiesResearch.Research)),
                Unit.Create(new Guid(ARMSecurities.ARMFinancialAdvisers), "ARM Financial Advisers", new Guid(ARMSecuritiesARMFinancialAdvisers.ARMFinancialAdvisers)),
                Unit.Create(new Guid(ARMSecurities.BackOfficeOperations), "Securities Operations", new Guid(ARMSecuritiesBackOfficeOperations.SecuritiesOperations)),
                Unit.Create(new Guid(ARMSecurities.TradingOrBokerage), "Trading / Bokerage", new Guid(ARMSecuritiesTradingBokerage.TradingBokerage)),
                Unit.Create(new Guid(ARMSecurities.CustomerExperience), "Call Centre", new Guid(ARMSecuritiesCustomerExperience.CallCentre)),
                Unit.Create(new Guid(ARMSecurities.CustomerExperience), "Customer Service", new Guid(ARMSecuritiesCustomerExperience.CustomerService)),
                Unit.Create(new Guid(ARMSecurities.FinanceOrTreasury), "Financial Control", new Guid(ARMSecuritiesFinanceTreasury.FinancialControl)),
                Unit.Create(new Guid(ARMSecurities.FinanceOrTreasury), "Treasury", new Guid(ARMSecuritiesFinanceTreasury.Treasury)),
                Unit.Create(new Guid(ARMSecurities.InformationTechnology), "Information Technology", new Guid(ARMSecuritiesInformationTechnology.InformationTechnology)),
                Unit.Create(new Guid(ARMSecurities.RiskManagement), "Risk Management", new Guid(ARMSecuritiesRiskManagement.RiskManagement)),
                Unit.Create(new Guid(ARMSecurities.ProjectManagementOffice), "Project Management Office", new Guid(ARMSecuritiesProjectManagementOffice.ProjectManagementOffice)),
                Unit.Create(new Guid(ARMSecurities.InternalControlOrInternalAudit), "Internal Control", new Guid(ARMSecuritiesInternalControlInternalAudit.InternalControl)),
                Unit.Create(new Guid(ARMSecurities.InternalControlOrInternalAudit), "Internal Audit", new Guid(ARMSecuritiesInternalControlInternalAudit.InternalAudit)),
                Unit.Create(new Guid(ARMSecurities.ARMAcademy), "ARM Academy", new Guid(ARMSecuritiesARMAcademy.ARMAcademy)),
                Unit.Create(new Guid(ARMSecurities.CoporateTransformationUnit), "Coporate Transformation", new Guid(ARMSecuritiesCoporateTransformationUnit.CoporateTransformationUnit)),
                Unit.Create(new Guid(ARMSecurities.Administration), "Administration", new Guid(ARMSecuritiesAdministration.Administration)),
                Unit.Create(new Guid(ARMSecurities.MarketingandCorporateCommunications), "Marketing and Corporate Communications", new Guid(ARMSecuritiesMarketingandCorporateCommunications.MarketingandCorporateCommunications)),
                Unit.Create(new Guid(ARMSecurities.CorporateStrategy), "Corporate Strategy", new Guid(ARMSecuritiesCorporateStrategy.CorporateStrategy)),
                Unit.Create(new Guid(ARMSecurities.LegalAndCompliance), "Legal", new Guid(ARMSecuritiesLegalCompliance.Legal)),
                Unit.Create(new Guid(ARMSecurities.LegalAndCompliance), "Compliance", new Guid(ARMSecuritiesLegalCompliance.Compliance)),
                Unit.Create(new Guid(ARMSecurities.LegalAndCompliance), "Co.Sec", new Guid(ARMSecuritiesLegalCompliance.CoSec)),
                Unit.Create(new Guid(ARMSecurities.HumanCapitalManagement), "Human Capital Management", new Guid(ARMSecuritiesHumanCapitalManagement.HumanCapitalManagement)),
                Unit.Create(new Guid(ARMSecurities.ARMSecurity), "ARM Securities", new Guid(ARMSecuritiesARMSecurity.ARMSecurities)),
            #endregion

            #region ARMIM units

                    Unit.Create(new Guid(ARMIM.InvestmentManagement), "Investment Management", new Guid(ARMIMInvestmentManagement.InvestmentManagement)),
                    Unit.Create(new Guid(ARMIM.BusinessDevelopment), "Institutional", new Guid(ARMIMBusinessDevelopment.Institutional)),
                    Unit.Create(new Guid(ARMIM.BusinessDevelopment), "Wealth & Relationship Management -Abuja", new Guid(ARMIMBusinessDevelopment.WealthRelationshipManagementAbuja)),
                    Unit.Create(new Guid(ARMIM.BusinessDevelopment), "Wealth & Relationship Management -Lagos", new Guid(ARMIMBusinessDevelopment.WealthRelationshipManagementLagos)),
                    Unit.Create(new Guid(ARMIM.BusinessDevelopment), "Wealth & Relationship Management -Port Harcourt", new Guid(ARMIMBusinessDevelopment.WealthRelationshipManagementPortHarcourt)),
                    Unit.Create(new Guid(ARMIM.RetailSales), "Abuja", new Guid(ARMIMRetailSales.Abuja)),
                    Unit.Create(new Guid(ARMIM.RetailSales), "Lagos", new Guid(ARMIMRetailSales.Lagos)),
                    Unit.Create(new Guid(ARMIM.RetailSales), "Port Harcourt", new Guid(ARMIMRetailSales.PortHarcourt)),
                    Unit.Create(new Guid(ARMIM.BackOfficeOperations), "Fund Account", new Guid(ARMIMBackOfficeOperations.FundAccount)),
                    Unit.Create(new Guid(ARMIM.BackOfficeOperations), "Fund Admin", new Guid(ARMIMBackOfficeOperations.FundAdmin)),
                    Unit.Create(new Guid(ARMIM.BackOfficeOperations), "Retail Operations", new Guid(ARMIMBackOfficeOperations.RetailOperations)),
                    Unit.Create(new Guid(ARMIM.BackOfficeOperations), "Registrars", new Guid(ARMIMBackOfficeOperations.Registrars)),
                    Unit.Create(new Guid(ARMIM.BackOfficeOperations), "Operation Controls", new Guid(ARMIMBackOfficeOperations.OperationControls)),
                    Unit.Create(new Guid(ARMIM.CustomerExperience), "Call Centre", new Guid(ARMIMCustomerExperience.CallCenter)),
                    Unit.Create(new Guid(ARMIM.CustomerExperience), "Customer Service", new Guid(ARMIMCustomerExperience.CustomerService)),
                    Unit.Create(new Guid(ARMIM.FinanceOrTreasury), "Financial Control", new Guid(ARMIMFinanceTreasury.FinancialControl)),
                    Unit.Create(new Guid(ARMIM.FinanceOrTreasury), "Treasury", new Guid(ARMIMFinanceTreasury.Treasury)),
                    Unit.Create(new Guid(ARMIM.BusinessSupport), "Abuja", new Guid(ARMIMBusinessSupport.Abuja)),
                    Unit.Create(new Guid(ARMIM.BusinessSupport), "Port Harcourt", new Guid(ARMIMBusinessSupport.PortHarcourt)),
                    Unit.Create(new Guid(ARMIM.BusinessSupport), "Lagos", new Guid(ARMIMBusinessSupport.Lagos)),
                    Unit.Create(new Guid(ARMIM.InformationTechnology), "Information Technology", new Guid(ARMIMInformationTechnology.InformationTechnology)),
                    Unit.Create(new Guid(ARMIM.RiskManagement), "Risk Management", new Guid(ARMIMRiskManagement.RiskManagement)),
                    Unit.Create(new Guid(ARMIM.ProjectManagementOffice), "Project Management Office", new Guid(ARMIMProjectManagementOffice.ProjectManagementOffice)),
                    Unit.Create(new Guid(ARMIM.InternalControlOrInternalAudit), "Internal Control", new Guid(ARMIMInternalControlInternalAudit.InternalControl)),
                    Unit.Create(new Guid(ARMIM.InternalControlOrInternalAudit), "Internal Audit", new Guid(ARMIMInternalControlInternalAudit.InternalAudit)),
                    Unit.Create(new Guid(ARMIM.ARMAcademy), "ARM Academy", new Guid(ARMIMARMAcademy.ARMAcademy)),
                    Unit.Create(new Guid(ARMIM.CoporateTransformationUnit), "Coporate Transformation", new Guid(ARMIMCoporateTransformationUnit.CoporateTransformation)),
                    Unit.Create(new Guid(ARMIM.Administration), "Administration", new Guid(ARMIMAdministration.Administration)),
                    Unit.Create(new Guid(ARMIM.MarketingandCorporateCommunications), "Marketing and Corporate Communications", new Guid(ARMIMMarketingandCorporateCommunications.MarketingandCorporateCommunications)),
                    Unit.Create(new Guid(ARMIM.CorporateStrategy), "Corporate Strategy", new Guid(ARMIMCorporateStrategy.CorporateStrategy)),
                    Unit.Create(new Guid(ARMIM.LegalAndCompliance), "Legal", new Guid(ARMIMLegalCompliance.Legal)),
                    Unit.Create(new Guid(ARMIM.LegalAndCompliance), "Compliance", new Guid(ARMIMLegalCompliance.Compliance)),
                    Unit.Create(new Guid(ARMIM.LegalAndCompliance), "Co.Sec", new Guid(ARMIMLegalCompliance.CoSec)),
                    Unit.Create(new Guid(ARMIM.HumanCapitalManagement), "Human Capital Management", new Guid(ARMIMHumanCapitalManagement.HumanCapitalManagement)),
                    Unit.Create(new Guid(ARMIM.BusinessDevelopment), "Business Development", new Guid(ARMIMBusinessDevelopment.BusinessDevelopment)),
                    Unit.Create(new Guid(ARMIM.Research), "Research", new Guid(ARMIMResearch.Research)),
                    Unit.Create(new Guid(ARMIM.RetailSales), "Retail Sales", new Guid(ARMIMRetailSales.RetailSale)),
                    Unit.Create(new Guid(ARMIM.OperationsSettlement), "Operations Settlement", new Guid(ARMIMOperationsSettlement.OperationsSettlements)),

                    Unit.Create(new Guid(ARMIM.OperationsSettlement), "Customer Onboarding & Data Mgt Team", new Guid(ARMIMCustomerOnboardingDataMgtTeam.CustomerOnboardingDataMgtTeam)),
                    Unit.Create(new Guid(ARMIM.OperationsSettlement), "Relationship Manager", new Guid(ARMIMRelationshipManagers.RelationshipManagers)),
                    Unit.Create(new Guid(ARMIM.OperationsSettlement), "Account Executives", new Guid(ARMIMAccountExecutives.AccountExecutives)),

            #endregion

            #region ARMHoldCo units

                     Unit.Create(new Guid(ARMHoldCo.ProprietaryandPrincipalTransactions), "Proprietary and Principal Transactions", new Guid(ARMHoldCoProprietaryandPrincipalTransactions.ProprietaryandPrincipalTransactions)),
                    Unit.Create(new Guid(ARMHoldCo.HoldCoSales), "HoldCo Sales", new Guid(ARMHoldCoHoldCoSales.HoldCoSales)),
                    Unit.Create(new Guid(ARMHoldCo.BackOfficeOperations), "Fund Admin", new Guid(ARMHoldCoBackOfficeOperations.FundAdmin)),
                    Unit.Create(new Guid(ARMHoldCo.BackOfficeOperations), "Registrars", new Guid(ARMHoldCoBackOfficeOperations.Register)),
                    Unit.Create(new Guid(ARMHoldCo.BackOfficeOperations), "Retail Operations", new Guid(ARMHoldCoBackOfficeOperations.RetailOperations)),
                    Unit.Create(new Guid(ARMHoldCo.BackOfficeOperations), "Fund Account", new Guid(ARMHoldCoBackOfficeOperations.FundAccount)),
                    Unit.Create(new Guid(ARMHoldCo.CustomerExperience), "Call Centre", new Guid(ARMHoldCoCustomerExperience.CallCentre)),
                    Unit.Create(new Guid(ARMHoldCo.CustomerExperience), "Customer Service", new Guid(ARMHoldCoCustomerExperience.CustomerService)),
                    Unit.Create(new Guid(ARMHoldCo.FinanceOrTreasury), "Financial Control", new Guid(ARMHoldCoFinanceTreasury.FinancialControl)),
                    Unit.Create(new Guid(ARMHoldCo.FinanceOrTreasury), "Treasury", new Guid(ARMHoldCoFinanceTreasury.Treasury)),
                    Unit.Create(new Guid(ARMHoldCo.InformationTechnology), "Information Technology", new Guid(ARMHoldCoInformationTechnology.InformationTechnology)),
                    Unit.Create(new Guid(ARMHoldCo.RiskManagement), "Risk Management", new Guid(ARMHoldCoRiskManagement.RiskManagement)),
                    Unit.Create(new Guid(ARMHoldCo.ProjectManagementOffice), "Project Management Office", new Guid(ARMHoldCoProjectManagementOffice.ProjectManagementOffice)),
                    Unit.Create(new Guid(ARMHoldCo.InternalControlOrInternalAudit), "Internal Control", new Guid(ARMHoldCoInternalControlInternalAudit.InternalControl)),
                    Unit.Create(new Guid(ARMHoldCo.InternalControlOrInternalAudit), "Internal Audit", new Guid(ARMHoldCoInternalControlInternalAudit.InternalAudit)),
                    Unit.Create(new Guid(ARMHoldCo.ARMAcademy), "ARM Academy", new Guid(ARMHoldCoARMAcademy.ARMAcademy)),
                    Unit.Create(new Guid(ARMHoldCo.CoporateTransformationUnit), "Coporate Transformation", new Guid(ARMHoldCoCoporateTransformationUnit.CoporateTransformation)),
                    Unit.Create(new Guid(ARMHoldCo.Administration), "Administration", new Guid(ARMHoldCoAdministration.Administration)),
                    Unit.Create(new Guid(ARMHoldCo.MarketingandCorporateCommunications), "Marketing and Corporate Communications", new Guid(ARMHoldCoMarketingandCorporateCommunications.MarketingandCorporateCommunications)),
                    Unit.Create(new Guid(ARMHoldCo.CorporateStrategy), "Corporate Strategy", new Guid(ARMHoldCoCorporateStrategy.CorporateStrategy)),
                    Unit.Create(new Guid(ARMHoldCo.LegalAndCompliance), "Legal", new Guid(ARMHoldCoLegalCompliance.Legal)),
                    Unit.Create(new Guid(ARMHoldCo.LegalAndCompliance), "Compliance", new Guid(ARMHoldCoLegalCompliance.Compliance)),
                    Unit.Create(new Guid(ARMHoldCo.LegalAndCompliance), "Co.Sec", new Guid(ARMHoldCoLegalCompliance.CoSec)),
                    Unit.Create(new Guid(ARMHoldCo.HumanCapitalManagement), "Human Capital Management", new Guid(ARMHoldCoHumanCapitalManagement.HumanCapitalManagement)),
                   Unit.Create(new Guid(ARMHoldCo.ARMHoldCompany), "ARM HoldCo", new Guid(ARMHoldCoARMHoldCompany.ARMHoldCo)),
                   Unit.Create(new Guid(ARMHoldCo.FinanceOrTreasury), "Treasury Operations", new Guid(ARMHoldCoFinanceTreasury.TreasuryOperations)),
                   Unit.Create(new Guid(ARMHoldCo.FinanceOrTreasury), "Treasury Sales", new Guid(ARMHoldCoFinanceTreasury.TreasurySales)),

            #endregion

            #region ARMTrustees units
                        Unit.Create(new Guid(ARMTrustees.PrivateTrust), "Private Trust", new Guid(ARMTrusteesPrivateTrust.PrivateTrust)),
                        Unit.Create(new Guid((ARMTrustees.CommercialTrust)), "Commercial Trust", new Guid(ARMTrusteesCommercialTrust.CommercialTrust)),
                        Unit.Create(new Guid((ARMTrustees.InvestmentManagement)), "Investment Management", new Guid(ARMTrusteesInvestmentManagement.InvestmentManagement)),
                        Unit.Create(new Guid(ARMTrustees.BackOfficeOperations), "Fund Admin", new Guid(ARMTrusteesBackOfficeOperations.FundAdmin)),
                        Unit.Create(new Guid(ARMTrustees.BackOfficeOperations), "Registrars", new Guid(ARMTrusteesBackOfficeOperations.Registrars)),
                        Unit.Create(new Guid(ARMTrustees.BackOfficeOperations), "Retail Operations", new Guid(ARMTrusteesBackOfficeOperations.RetailOperations)),
                        Unit.Create(new Guid(ARMTrustees.BackOfficeOperations), "Fund Account", new Guid(ARMTrusteesBackOfficeOperations.FundAccount)),
                        Unit.Create(new Guid(ARMTrustees.CustomerExperience), "Call Centre", new Guid(ARMTrusteesCustomerExperience.CallCenter)),
                        Unit.Create(new Guid(ARMTrustees.CustomerExperience), "Customer Service", new Guid(ARMTrusteesCustomerExperience.CustomerService)),
                        Unit.Create(new Guid(ARMTrustees.FinanceOrTreasury), "Financial Control", new Guid(ARMTrusteesFinanceTreasury.FinancialControl)),
                        Unit.Create(new Guid(ARMTrustees.FinanceOrTreasury), "Treasury", new Guid(ARMTrusteesFinanceTreasury.Treasury)),
                        Unit.Create(new Guid(ARMTrustees.BusinessSupport), "Abuja", new Guid(ARMTrusteesBusinessSupport.Abuja)),
                        Unit.Create(new Guid(ARMTrustees.BusinessSupport), "Port Harcourt", new Guid(ARMTrusteesBusinessSupport.PortHarcourt)),
                        Unit.Create(new Guid(ARMTrustees.BusinessSupport), "Lagos", new Guid(ARMTrusteesBusinessSupport.Lagos)),
                        Unit.Create(new Guid(ARMTrustees.InformationTechnology), "Information Technology", new Guid(ARMTrusteesInformationTechnology.InformationTechnology)),
                        Unit.Create(new Guid(ARMTrustees.RiskManagement), "Risk Management", new Guid(ARMTrusteesRiskManagement.RiskManagement)),
                        Unit.Create(new Guid(ARMTrustees.ProjectManagementOffice), "Project Management Office", new Guid(ARMTrusteesProjectManagementOffice.ProjectManagementOffice)),
                        Unit.Create(new Guid(ARMTrustees.InternalControlOrInternalAudit), "Internal Control", new Guid(ARMTrusteesInternalControlAudit.InternalControl)),
                        Unit.Create(new Guid(ARMTrustees.InternalControlOrInternalAudit), "Internal Audit", new Guid(ARMTrusteesInternalControlAudit.InternalAudit)),
                        Unit.Create(new Guid(ARMTrustees.ARMAcademy), "ARM Academy", new Guid(ARMTrusteesARMAcademy.ARMAcademy)),
                        Unit.Create(new Guid(ARMTrustees.CoporateTransformationUnit), "Coporate Transformation", new Guid(ARMTrusteesCoporateTransformationUnit.CoporateTransformation)),
                        Unit.Create(new Guid(ARMTrustees.Administration), "Administration", new Guid(ARMTrusteesAdministration.Administration)),
                        Unit.Create(new Guid(ARMTrustees.MarketingandCorporateCommunications), "Marketing and Corporate Communications", new Guid(ARMTrusteesMarketingandCorporateCommunications.MarketingandCorporateCommunications)),
                        Unit.Create(new Guid(ARMTrustees.CorporateStrategy), "Corporate Strategy", new Guid(ARMTrusteesCorporateStrategy.CorporateStrategy)),
                        Unit.Create(new Guid(ARMTrustees.LegalAndCompliance), "Legal", new Guid(ARMTrusteesLegalCompliance.Legal)),
                        Unit.Create(new Guid(ARMTrustees.LegalAndCompliance), "Compliance", new Guid(ARMTrusteesLegalCompliance.Compliance)),
                        Unit.Create(new Guid(ARMTrustees.LegalAndCompliance), "Co.Sec", new Guid(ARMTrusteesLegalCompliance.CoSec)),
                        Unit.Create(new Guid(ARMTrustees.HumanCapitalManagement), "Human Capital Management", new Guid(ARMTrusteesHumanCapitalManagement.HumanCapitalManagement)),
                #endregion

                #region ARMHarithInfracstrureInvestementLimited units
                        Unit.Create(new Guid(ARMHarithInfracstrureInvestementLimited.ARMHarithInfrastructureInvestmentLtd), "ARM Harith Infrastructure Investment Ltd", new Guid(ARMHarithInfracstrureInvestementLimitedARMHarithInfrastructureInvestmentLtd.ARMHarithInfrastructureInvestmentLtd)),
                        Unit.Create(new Guid(ARMHarithInfracstrureInvestementLimited.ARMHarithInfrastructureInvestmentLtd), "ARM Harith Investment Ltd", new Guid(ARMHarithInfracstrureInvestementLimitedARMHarithInfrastructureInvestmentLtd.ARMHarithInvestmentLtd)),
                        Unit.Create(new Guid(ARMHarithInfracstrureInvestementLimited.CustomerExperience), "Call Centre", new Guid(ARMHarithInfracstrureInvestementLimitedCustomerExperience.CallCentre)),
                        Unit.Create(new Guid(ARMHarithInfracstrureInvestementLimited.CustomerExperience), "Customer Service", new Guid(ARMHarithInfracstrureInvestementLimitedCustomerExperience.CustomerService)),
                        Unit.Create(new Guid(ARMHarithInfracstrureInvestementLimited.FinanceOrTreasury), "Financial Control", new Guid(ARMHarithInfracstrureInvestementLimitedFinanceTreasury.FinancialControl)),
                        Unit.Create(new Guid(ARMHarithInfracstrureInvestementLimited.FinanceOrTreasury), "Treasury", new Guid(ARMHarithInfracstrureInvestementLimitedFinanceTreasury.Treasury)),
                        Unit.Create(new Guid(ARMHarithInfracstrureInvestementLimited.InformationTechnology), "Information Technology", new Guid(ARMHarithInfracstrureInvestementLimitedInformationTechnology.InformationTechnology)),
                        Unit.Create(new Guid(ARMHarithInfracstrureInvestementLimited.RiskManagement), "Risk Management", new Guid(ARMHarithInfracstrureInvestementLimitedRiskManagement.RiskManagement)),
                        Unit.Create(new Guid(ARMHarithInfracstrureInvestementLimited.ProjectManagementOffice), "Real Estate", new Guid(ARMHarithInfracstrureInvestementLimitedProjectManagementOffice.RealEstate)),
                        Unit.Create(new Guid(ARMHarithInfracstrureInvestementLimited.InternalControlOrInternalAudit), "Internal Control", new Guid(ARMHarithInfracstrureInvestementLimitedInternalControlInternalAudit.InternalControl)),
                        Unit.Create(new Guid(ARMHarithInfracstrureInvestementLimited.InternalControlOrInternalAudit), "Internal Audit", new Guid(ARMHarithInfracstrureInvestementLimitedInternalControlInternalAudit.InternalAudit)),
                        Unit.Create(new Guid(ARMHarithInfracstrureInvestementLimited.ARMAcademy), "ARM Academy", new Guid(ARMHarithInfracstrureInvestementLimitedARMAcademy.ARMAcademy)),
                        Unit.Create(new Guid(ARMHarithInfracstrureInvestementLimited.CoporateTransformationUnit), "Coporate Transformation", new Guid(ARMHarithInfracstrureInvestementLimitedCoporateTransformationUnit.CoporateTransformation)),
                        Unit.Create(new Guid(ARMHarithInfracstrureInvestementLimited.Administration), "Administration", new Guid(ARMHarithInfracstrureInvestementLimitedAdministration.Administration)),
                        Unit.Create(new Guid(ARMHarithInfracstrureInvestementLimited.MarketingandCorporateCommunications), "Marketing and Corporate Communications", new Guid(ARMHarithInfracstrureInvestementLimitedMarketingandCorporateCommunications.MarketingandCorporateCommunications)),
                        Unit.Create(new Guid(ARMHarithInfracstrureInvestementLimited.CorporateStrategy), "Corporate Strategy", new Guid(ARMHarithInfracstrureInvestementLimitedCorporateStrategy.CorporateStrategy)),
                        Unit.Create(new Guid(ARMHarithInfracstrureInvestementLimited.LegalAndCompliance), "Legal", new Guid(ARMHarithInfracstrureInvestementLimitedLegalCompliance.Legal)),
                        Unit.Create(new Guid(ARMHarithInfracstrureInvestementLimited.LegalAndCompliance), "Compliance", new Guid(ARMHarithInfracstrureInvestementLimitedLegalCompliance.Compliance)),
                        Unit.Create(new Guid(ARMHarithInfracstrureInvestementLimited.LegalAndCompliance), "Co.Sec", new Guid(ARMHarithInfracstrureInvestementLimitedLegalCompliance.CoSec)),
                        Unit.Create(new Guid(ARMHarithInfracstrureInvestementLimited.HumanCapitalManagement), "Human Capital Management", new Guid(ARMHarithInfracstrureInvestementLimitedHumanCapitalManagement.HumanCapitalManagement)),
                #endregion

                #region SharedServices units

                    Unit.Create(new Guid(SharedServices.CustomerExperience), "Call Centre", new Guid(SharedServicesCustomerExperience.CallCentre)),
                    Unit.Create(new Guid(SharedServices.CustomerExperience), "Customer Service", new Guid(SharedServicesCustomerExperience.CustomerService)),
                    Unit.Create(new Guid(SharedServices.FinanceOrTreasury), "Financial Control", new Guid(SharedServicesFinanceTreasury.FinancialControl)),
                    Unit.Create(new Guid(SharedServices.FinanceOrTreasury), "Treasury", new Guid(SharedServicesFinanceTreasury.Treasury)),
                    Unit.Create(new Guid(SharedServices.BusinessSupport), "Port Harcourt", new Guid(SharedServicesBusinessSupport.PortHarcourt)),
                    Unit.Create(new Guid(SharedServices.BusinessSupport), "Lagos", new Guid(SharedServicesBusinessSupport.Lagos)),
                    Unit.Create(new Guid(SharedServices.InformationTechnology), "Information Technology", new Guid(SharedServicesInformationTechnology.InformationTechnology)),
                    Unit.Create(new Guid(SharedServices.RiskManagement), "Risk Management", new Guid(SharedServicesRiskManagement.RiskManagement)),
                    Unit.Create(new Guid(SharedServices.ProjectManagementOffice), "Project Management Office", new Guid(SharedServicesProjectManagementOffice.ProjectManagementOffice)),
                    Unit.Create(new Guid(SharedServices.InternalControlOrInternalAudit), "Internal Control", new Guid(SharedServicesInternalControlInternalAudit.InternalControl)),
                    Unit.Create(new Guid(SharedServices.InternalControlOrInternalAudit), "Internal Audit", new Guid(SharedServicesInternalControlInternalAudit.InternalAudit)),
                    Unit.Create(new Guid(SharedServices.ARMAcademy), "ARM Academy", new Guid(SharedServicesARMAcademy.ARMAcademy)),
                    Unit.Create(new Guid(SharedServices.CoporateTransformationUnit), "Coporate Transformation", new Guid(SharedServicesCoporateTransformationUnit.CoporateTransformation)),
                    Unit.Create(new Guid(SharedServices.Administration), "Procurement and Administration", new Guid(SharedServicesProcurementandAdministration.ProcurementandAdministration)),
                    Unit.Create(new Guid(SharedServices.MarketingandCorporateCommunications), "Marketing and Corporate Communications", new Guid(SharedServicesMarketingandCorporateCommunications.MarketingandCorporateCommunications)),
                    Unit.Create(new Guid(SharedServices.CorporateStrategy), "Corporate Strategy", new Guid(SharedServicesCorporateStrategy.CorporateStrategy)),
                    Unit.Create(new Guid(SharedServices.LegalAndCompliance), "Legal", new Guid(SharedServicesLegalCompliance.Legal)),
                    Unit.Create(new Guid(SharedServices.LegalAndCompliance), "Compliance", new Guid(SharedServicesLegalCompliance.Compliance)),
                    Unit.Create(new Guid(SharedServices.LegalAndCompliance), "Co.Sec", new Guid(SharedServicesLegalCompliance.CoSec)),
                    Unit.Create(new Guid(SharedServices.HumanCapitalManagement), "Human Capital Management", new Guid(SharedServicesHumanCapitalManagement.HumanCapitalManagement)),
                    Unit.Create(new Guid(SharedServices.InformationSecurity), "Information Security", new Guid(SharedServicesInformationSecurity.InformationSecurity)),
                    Unit.Create(new Guid(SharedServices.CompanySecretariat), "Company Secretariat", new Guid(SharedServicesCompanySecretariats.CompanySecretariat)),
                    Unit.Create(new Guid(SharedServices.DataAndInsights), "Data and Insights", new Guid(SharedServicesDataAndInsights.DataAndInsight)),
                    Unit.Create(new Guid(SharedServices.EnvironmentalSocialAndGovernance), "Environmental, Social and Governance", new Guid(SharedServicesEnvironmentalSocialAndGovernances.EnvironmentalSocialAndGovernance)),

            #endregion

            #region ARMAgriBusiness units

                        Unit.Create(new Guid(ARMAgriBusiness.ARMAgricbusinessFundManagerLtd), "ARM Agric Fund", new Guid(ARMAgriBusinessARMAgricbusinessFundManagerLtd.ARMAgricFund)),
                        Unit.Create(new Guid(ARMAgriBusiness.ARMAgricbusinessFundManagerLtd), "ODA", new Guid(ARMAgriBusinessARMAgricbusinessFundManagerLtd.ODA)),
                        Unit.Create(new Guid(ARMAgriBusiness.ARMAgricbusinessFundManagerLtd), "Advisory", new Guid(ARMAgriBusinessARMAgricbusinessFundManagerLtd.Advisory)),
                        Unit.Create(new Guid(ARMAgriBusiness.ARMAgricbusinessFundManagerLtd), "RFL", new Guid(ARMAgriBusinessARMAgricbusinessFundManagerLtd.RFL)),
                        Unit.Create(new Guid(ARMAgriBusiness.FinanceOrTreasury), "Financial Control", new Guid(ARMAgriBusinessFinanceTreasury.FinancialControl)),
                        Unit.Create(new Guid(ARMAgriBusiness.FinanceOrTreasury), "Treasury", new Guid(ARMAgriBusinessFinanceTreasury.Treasury)),
                        Unit.Create(new Guid(ARMAgriBusiness.InformationTechnology), "Information Technology", new Guid(ARMAgriBusinessInformationTechnology.InformationTechnology)),
                        Unit.Create(new Guid(ARMAgriBusiness.RiskManagement), "Risk Management", new Guid(ARMAgriBusinessRiskManagement.RiskManagement)),
                        Unit.Create(new Guid(ARMAgriBusiness.ProjectManagementOffice), "Real Estate", new Guid(ARMAgriBusinessProjectManagementOffice.RealEstate)),
                        Unit.Create(new Guid(ARMAgriBusiness.InternalControlOrInternalAudit), "Internal Control", new Guid(ARMAgriBusinessInternalControlInternalAudit.InternalControl)),
                        Unit.Create(new Guid(ARMAgriBusiness.InternalControlOrInternalAudit), "Internal Audit", new Guid(ARMAgriBusinessInternalControlInternalAudit.InternalAudit)),
                        Unit.Create(new Guid(ARMAgriBusiness.ARMAcademy), "ARM Academy", new Guid(ARMAgriBusinessARMAcademy.ARMAcademy)),
                        Unit.Create(new Guid(ARMAgriBusiness.CoporateTransformationUnit), "Coporate Transformation", new Guid(ARMAgriBusinessCoporateTransformationUnit.CoporateTransformation)),
                        Unit.Create(new Guid(ARMAgriBusiness.Administration), "Administration", new Guid(ARMAgriBusinessAdministration.Administration)),
                        Unit.Create(new Guid(ARMAgriBusiness.MarketingandCorporateCommunications), "Marketing and Corporate Communications", new Guid(ARMAgriBusinessMarketingandCorporateCommunications.MarketingandCorporateCommunications)),
                        Unit.Create(new Guid(ARMAgriBusiness.CorporateStrategy), "Corporate Strategy", new Guid(ARMAgriBusinessCorporateStrategy.CorporateStrategy)),
                        Unit.Create(new Guid(ARMAgriBusiness.LegalAndCompliance), "Legal", new Guid(ARMAgriBusinessLegalCompliance.Legal)),
                        Unit.Create(new Guid(ARMAgriBusiness.LegalAndCompliance), "Compliance", new Guid(ARMAgriBusinessLegalCompliance.Compliance)),
                        Unit.Create(new Guid(ARMAgriBusiness.LegalAndCompliance), "Co.Sec", new Guid(ARMAgriBusinessLegalCompliance.CoSec)),
                        Unit.Create(new Guid(ARMAgriBusiness.HumanCapitalManagement), "Human Capital Management", new Guid(ARMAgriBusinessHumanCapitalManagement.HumanCapitalManagement)),

                #endregion

                #region MixtaNigeria units
                            Unit.Create(new Guid(MixtaNigeria.MixtaNigeriaSales), "Mixta Nigeria Sales", new Guid(MixtaNigeriaMixtaNigeriaSales.MixtaNigeriaSales)),
                            Unit.Create(new Guid(MixtaNigeria.SummervilleOrLakowe), "Summerville / Lakowe", new Guid(MixtaNigeriaSummervilleLakowe.SummervilleLakowe)),
                            Unit.Create(new Guid(MixtaNigeria.SummervilleOrLakowe), "Enclave", new Guid(MixtaNigeriaSummervilleLakowe.Enclave)),
                            Unit.Create(new Guid(MixtaNigeria.SummervilleOrLakowe), "Platform 30", new Guid(MixtaNigeriaSummervilleLakowe.Platform30)),
                            Unit.Create(new Guid(MixtaNigeria.SummervilleOrLakowe), "Village", new Guid(MixtaNigeriaSummervilleLakowe.Village)),
                            Unit.Create(new Guid(MixtaNigeria.SummervilleOrLakowe), "RDP", new Guid(MixtaNigeriaSummervilleLakowe.RDP)),
                            Unit.Create(new Guid(MixtaNigeria.HospitalityandRetailManagement), "Hospitality and Retail Management", new Guid(MixtaNigeriaHospitalityandRetailManagement.HospitalityandRetailManagement)),
                            Unit.Create(new Guid(MixtaNigeria.MixtaNigeriaOperations), "Mixta Nigeria Operations", new Guid(MixtaNigeriaMixtaNigeriaOperations.MixtaNigeriaOperations)),
                            Unit.Create(new Guid(MixtaNigeria.TechnicalOrProjects), "Technical / Projects", new Guid(MixtaNigeriaTechnicalProjects.TechnicalProjects)),
                            Unit.Create(new Guid(MixtaNigeria.FacilityManagement), "Facility Management", new Guid(MixtaNigeriaFacilityManagement.FacilityManagement)),
                            Unit.Create(new Guid(MixtaNigeria.DesignAndConstruction), "Procurement and Contracting", new Guid(MixtaNigeriaDesignConstruction.ProcurementandContracting)),
                            Unit.Create(new Guid(MixtaNigeria.DesignAndConstruction), "Design", new Guid(MixtaNigeriaDesignConstruction.Design)),
                            Unit.Create(new Guid(MixtaNigeria.Adiva), "Adiva", new Guid(MixtaNigeriaAdiva.Adiva)),
                            Unit.Create(new Guid(MixtaNigeria.Beechwood), "Beechwood", new Guid(MixtaNigeriaBeechwood.Beechwood)),
                            Unit.Create(new Guid(MixtaNigeria.GreaterPortHarcourGolfClub), "Greater Port Harcour Golf Club", new Guid(MixtaNigeriaGreaterPortHarcourGolfClub.GreaterPortHarcourGolfClub)),
                            Unit.Create(new Guid(MixtaNigeria.TSDLtd), "TSD Ltd", new Guid(MixtaNigeriaTSDLtd.TSDLtd)),
                            Unit.Create(new Guid(MixtaNigeria.OaklandLimited), "Oakland Limited", new Guid(MixtaNigeriaOaklandLimited.OaklandLimited)),
                            Unit.Create(new Guid(MixtaNigeria.LakoweLakesGolfClubLtd), "Lakowe Lakes Golf Club Ltd", new Guid(MixtaNigeriaLakoweLakesGolfClubLtd.LakoweLakesGolfClubLtd)),
                            Unit.Create(new Guid(MixtaNigeria.Townsville), "Townsville", new Guid(MixtaNigeriaTownsville.Townsville)),
                            Unit.Create(new Guid(MixtaNigeria.Farapark), "Farapark", new Guid(MixtaNigeriaFarapark.Farapark)),
                            Unit.Create(new Guid(MixtaNigeria.CrosstownIju), "Crosstown Iju", new Guid(MixtaNigeriaCrosstownIju.CrosstownIju)),
                            Unit.Create(new Guid(MixtaNigeria.BusinessPlanning), "Business Planning", new Guid(MixtaNigeriaBusinessPlanning.BusinessPlanning)),
                            Unit.Create(new Guid(MixtaNigeria.FinanceOrTreasury), "Financial Control", new Guid(MixtaNigeriaFinanceTreasury.FinancialControl)),
                            Unit.Create(new Guid(MixtaNigeria.FinanceOrTreasury), "Treasury", new Guid(MixtaNigeriaFinanceTreasury.Treasury)),
                            Unit.Create(new Guid(MixtaNigeria.InformationTechnology), "Information Technology", new Guid(MixtaNigeriaInformationTechnology.InformationTechnology)),
                            Unit.Create(new Guid(MixtaNigeria.RiskManagement), "Risk Management", new Guid(MixtaNigeriaRiskManagement.RiskManagement)),
                            Unit.Create(new Guid(MixtaNigeria.InternalControlOrInternalAudit), "Internal Control", new Guid(MixtaNigeriaInternalControlInternalAudit.InternalControl)),
                            Unit.Create(new Guid(MixtaNigeria.InternalControlOrInternalAudit), "Internal Audit", new Guid(MixtaNigeriaInternalControlInternalAudit.InternalAudit)),
                            Unit.Create(new Guid(MixtaNigeria.ARMAcademy), "ARM Academy", new Guid(MixtaNigeriaARMAcademy.ARMAcademy)),
                            Unit.Create(new Guid(MixtaNigeria.CorporateTransformationUnit), "Coporate Transformation", new Guid(MixtaNigeriaCorporateTransformationUnit.CorporateTransformation)),
                            Unit.Create(new Guid(MixtaNigeria.Administration), "Administration", new Guid(MixtaNigeriaAdministration.Administration)),
                            Unit.Create(new Guid(MixtaNigeria.MarketingandCorporateCommunications), "Marketing and Corporate Communications", new Guid(MixtaNigeriaMarketingandCorporateCommunications.MarketingandCorporateCommunications)),
                            Unit.Create(new Guid(MixtaNigeria.CorporateStrategy), "Corporate Strategy", new Guid(MixtaNigeriaCorporateStrategy.CorporateStrategy)),
                            Unit.Create(new Guid(MixtaNigeria.LegalAndCompliance), "Legal", new Guid(MixtaNigeriaLegalCompliance.Legal)),
                            Unit.Create(new Guid(MixtaNigeria.LegalAndCompliance), "Compliance", new Guid(MixtaNigeriaLegalCompliance.Compliance)),
                            Unit.Create(new Guid(MixtaNigeria.LegalAndCompliance), "Co.Sec", new Guid(MixtaNigeriaLegalCompliance.CoSec)),
                            Unit.Create(new Guid(MixtaNigeria.HumanCapitalManagement), "Human Capital Management", new Guid(MixtaNigeriaHumanCapitalManagement.HumanCapitalManagement)),
                    #endregion

                #region ARMDigitalFinancialServices units
                        Unit.Create(new Guid(ARMDigitalFinancialServices.DigitalFinancialServices), "Digital Financial Services", new Guid(ARMDigitalFinancialServicesDigitalFinancialServices.DigitalFinancialServices)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.InvestmentManagement), "Investment Management", new Guid(ARMDigitalFinancialServicesInvestmentManagement.InvestmentManagement)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.BackOfficeOperations), "Fund Account", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAccount)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.BackOfficeOperations), "Retail Operations", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.RetailOperations)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.BackOfficeOperations), "Registrars", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.Registrars)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.BackOfficeOperations), "Fund Admin", new Guid(ARMDigitalFinancialServicesBackOfficeOperations.FundAdmin)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.CustomerExperience), "Call Centre", new Guid(ARMDigitalFinancialServicesCustomerExperience.CallCentre)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.CustomerExperience), "Customer Service", new Guid(ARMDigitalFinancialServicesCustomerExperience.CustomerService)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.FinanceOrTreasury), "Financial Control", new Guid(ARMDigitalFinancialServicesFinanceTreasury.FinancialControl)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.FinanceOrTreasury), "Treasury", new Guid(ARMDigitalFinancialServicesFinanceTreasury.Treasury)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.BusinessSupport), "Abuja", new Guid(ARMDigitalFinancialServicesBusinessSupport.Abuja)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.BusinessSupport), "Port Harcourt", new Guid(ARMDigitalFinancialServicesBusinessSupport.PortHarcourt)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.BusinessSupport), "Lagos", new Guid(ARMDigitalFinancialServicesBusinessSupport.Lagos)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.InformationTechnology), "Information Technology", new Guid(ARMDigitalFinancialServicesInformationTechnology.InformationTechnology)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.RiskManagement), "Risk Management", new Guid(ARMDigitalFinancialServicesRiskManagement.RiskManagement)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.ProjectManagementOffice), "Project Management Office", new Guid(ARMDigitalFinancialServicesProjectManagementOffice.ProjectManagementOffice)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.InternalControlOrInternalAudit), "Internal Control", new Guid(ARMDigitalFinancialServicesInternalControlInternalAudit.InternalControl)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.InternalControlOrInternalAudit), "Internal Audit", new Guid(ARMDigitalFinancialServicesInternalControlInternalAudit.InternalAudit)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.ARMAcademy), "ARM Academy", new Guid(ARMDigitalFinancialServicesARMAcademy.ARMAcademy)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.CoporateTransformationUnit), "Coporate Transformation", new Guid(ARMDigitalFinancialServicesCoporateTransformationUnit.CoporateTransformation)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.Administration), "Administration", new Guid(ARMDigitalFinancialServicesAdministration.Administration)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.MarketingandCorporateCommunications), "Marketing and Corporate Communications", new Guid(ARMDigitalFinancialServicesMarketingandCorporateCommunications.MarketingandCorporateCommunications)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.CorporateStrategy), "Corporate Strategy", new Guid(ARMDigitalFinancialServicesCorporateStrategy.CorporateStrategy)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.LegalAndCompliance), "Legal", new Guid(ARMDigitalFinancialServicesLegalCompliance.Legal)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.LegalAndCompliance), "Compliance", new Guid(ARMDigitalFinancialServicesLegalCompliance.Compliance)),
                        Unit.Create(new Guid(ARMDigitalFinancialServices.HumanCapitalManagement), "Human Capital Management", new Guid(ARMDigitalFinancialServicesHumanCapitalManagement.HumanCapitalManagement)),
                #endregion

                 #region ARMHIIL units
                      Unit.Create(new Guid(ARMHIILs.HIIL), "ARMHIIL", new Guid(ARMHIIL.HIIL)),
                 #endregion

                #region ARMCapital units
                   Unit.Create(new Guid(ARMCapitals.Capital), "ARM Capital", new Guid(ARMCapital.Capital))

                #endregion


              );
        }
    }
}
