using Arm.GrcTool.Domain.Risk;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GrcApi.Modules.RiskManagement
{
    public class RiskEventTypeSubCategoryConfiguration : IEntityTypeConfiguration<RiskEventTypeSubCategory>
    {
        public void Configure(EntityTypeBuilder<RiskEventTypeSubCategory> builder)
        {
            builder.ToTable(nameof(RiskEventTypeSubCategory));
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("Id");
            builder.Property(c => c.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();

            builder.HasOne(c => c.RiskEventTypeCategory).WithMany(c => c.RiskEventTypeSubCategories).HasForeignKey(c => c.RiskEventTypeCategoryId);

            //Risk event type category Ids
            string monitoringandreporting = "84C43920-C0C7-4D25-86FE-1EC905D69E26";
            string vendorsandsuppliers = "9A06F398-DACD-44DC-ABFD-CFE9721E6CE5";
            string disputeswithRegulatoryAuthoritiesorotherGovernmentalBodies = "4E053FC0-8442-4DA3-A1D9-8A1CCA234912";
            string employeerelations = "C96FDC22-4A35-4461-8726-5F73124545B1";
            string consultingAdvisoryActivities = "05D02531-4D98-41F9-8C34-1DA6115B385B";
            string theftandFraudExternal = "3429AAD4-E734-44AC-919C-AF9758979AAB";
            string suitabilitydisclosureandfiduciary = "A9386E4F-342C-4868-9EF6-9C2DB682AC0B";
            string unauthorisedActivitiesExternal = "849DC895-ECA1-4165-B5AB-7CFCDC0D3EBB";
            string improperbusinessormarketpractices = "D93D70E3-39D2-4B82-8D73-BA447F1BC06D";
            string retroactiveeffectsandimproperactivitiesbythirdparties = "FBFF5D8B-2C51-43E8-8A3D-6B7F2A5873A9";
            string productflaws = "F2320468-3DEF-4022-A67F-AF0F6BBDC3CD";
            string theftandFraudInternal = "73A0DF86-D805-4E57-A6AD-B8AF814646A4";
            string nonclientcounterpartybreaches = "F6D2467A-358D-446E-B6EA-79C5C649B472";
            string systemSecurityExternal = "F9D3F84F-C129-46F1-9A6A-E18D7EF7F317";
            string customerintakeanddocumentation = "81F7E998-9B34-4092-8590-A551647DE2C0";
            string naturalcauses = "715E84F3-6D29-49D0-B8AB-9F3C6C65D27E";
            string safeEnvironment = "AC39225C-DB94-4127-8675-C6645B51A8C1";
            string interruptioninservicesprovidedbyexternalproviders = "0FBE8F2C-7905-40CD-837B-7CCD5195AFF6";
            string humanActs = "62CE3931-6D3A-42D0-A0F4-F637E9AFD0B9";
            string diversityanddiscrimination = "A67CDE3E-3EC3-44EE-A4DD-AD45713CDAC7";
            string accidentsandpublicsafety = "611B88D4-5289-4DA1-A78D-420F236257DC";
            string selectionsponsorshipandexposure = "EF9C5269-9866-4D0B-BC67-1CDA07009562";
            string otherProcessbreakdown = "CB18E18C-39A4-4802-9CC5-9A775368CC98";
            string inadequacyInefficiencyMalfunctionorBlockofTechnologySystems = "0FEF6D10-B14D-4912-A09A-5DB403D34154";
            string mismanagementofclassifiedcompanyinformation = "8E9BE527-5BC1-48F5-A07C-10F36CD6D759";
            string transactioncaptureexecutionandmaintenance = "52ECC3F4-55C8-4A9A-AB54-D86EB8F2B3D0";
            string systemSecurityInternal = "8978FAF7-D8EF-482F-9845-6F8A232F64D4";
            string unauthorisedActivitiesInternal = "7F26B2BC-E09D-4DCB-9E1B-375F971B66C1";
            string customeraccountmanagement = "C5C4E527-45E0-4BD2-917F-59783425E0A3";
            string misrepresentationofcompanyinformation = "5E969527-3694-477A-8F17-40E53039966C";
            string poorQualityofMediaProduction = "635CA6D7-708F-4349-A483-ECF00679C489";

            //Data seeding
            builder.HasData(
            #region Theft and fraud (Internal)
                RiskEventTypeSubCategory.Create(Guid.Parse(theftandFraudInternal), "Fraud"),
                RiskEventTypeSubCategory.Create(Guid.Parse(theftandFraudInternal), "Theft"),
                RiskEventTypeSubCategory.Create(Guid.Parse(theftandFraudInternal), "Cash management shortages"),
                RiskEventTypeSubCategory.Create(Guid.Parse(theftandFraudInternal), "Extortion"),
                RiskEventTypeSubCategory.Create(Guid.Parse(theftandFraudInternal), "Embezzlement"),
                RiskEventTypeSubCategory.Create(Guid.Parse(theftandFraudInternal), "Forgery"),
                RiskEventTypeSubCategory.Create(Guid.Parse(theftandFraudInternal), "Cash suppression"),
                RiskEventTypeSubCategory.Create(Guid.Parse(theftandFraudInternal), "Cheque conversion"),
                RiskEventTypeSubCategory.Create(Guid.Parse(theftandFraudInternal), "Manipulation of source documents"),
                RiskEventTypeSubCategory.Create(Guid.Parse(theftandFraudInternal), "Manipulation of customer accounts"),
                RiskEventTypeSubCategory.Create(Guid.Parse(theftandFraudInternal), "Teaming"),
                RiskEventTypeSubCategory.Create(Guid.Parse(theftandFraudInternal), "Illegal sales of securities from Clients portfolio"),
            #endregion
            #region System Security (Internal)
                RiskEventTypeSubCategory.Create(Guid.Parse(systemSecurityInternal), "Customer data theft"),
                RiskEventTypeSubCategory.Create(Guid.Parse(systemSecurityInternal), "manipulation of files / programs"),
                RiskEventTypeSubCategory.Create(Guid.Parse(systemSecurityInternal), "Illegal withdrawals from client accounts"),
            #endregion
            #region Unauthorised Activities (Internal)
                RiskEventTypeSubCategory.Create(Guid.Parse(unauthorisedActivitiesInternal), "Misappropriation of company assets"),
                RiskEventTypeSubCategory.Create(Guid.Parse(unauthorisedActivitiesInternal), "Bribes"),
                RiskEventTypeSubCategory.Create(Guid.Parse(unauthorisedActivitiesInternal), "Kickbacks"),
                RiskEventTypeSubCategory.Create(Guid.Parse(unauthorisedActivitiesInternal), "Intentional mispricing of products"),
                RiskEventTypeSubCategory.Create(Guid.Parse(unauthorisedActivitiesInternal), "Destruction of source documents"),
                RiskEventTypeSubCategory.Create(Guid.Parse(unauthorisedActivitiesInternal), "Unauthorised income waivers"),
                RiskEventTypeSubCategory.Create(Guid.Parse(unauthorisedActivitiesInternal), "Granting unauthorised credit"),
            #endregion
            #region Theft and Fraud (External)
                RiskEventTypeSubCategory.Create(Guid.Parse(theftandFraudExternal), "Fraud"),
                RiskEventTypeSubCategory.Create(Guid.Parse(theftandFraudExternal), "Cash theft"),
                RiskEventTypeSubCategory.Create(Guid.Parse(theftandFraudExternal), "Pool car theft"),
                RiskEventTypeSubCategory.Create(Guid.Parse(theftandFraudExternal), "Cheque forgery"),
                RiskEventTypeSubCategory.Create(Guid.Parse(theftandFraudExternal), "Cheque fraud"),
                RiskEventTypeSubCategory.Create(Guid.Parse(theftandFraudExternal), "Cheque kiting"),
                RiskEventTypeSubCategory.Create(Guid.Parse(theftandFraudExternal), "Fake currency fraud"),
            #endregion
            #region System Security (External)
                RiskEventTypeSubCategory.Create(Guid.Parse(systemSecurityExternal), "Customer data theft"),
                RiskEventTypeSubCategory.Create(Guid.Parse(systemSecurityExternal), "manipulation of files / programs"),
                RiskEventTypeSubCategory.Create(Guid.Parse(systemSecurityExternal), "Illegal withdrawals from client accounts"),
            #endregion
            #region Unauthorised Activities (External)
                RiskEventTypeSubCategory.Create(Guid.Parse(unauthorisedActivitiesExternal), "Account take over / impersonation"),
                RiskEventTypeSubCategory.Create(Guid.Parse(unauthorisedActivitiesExternal), "Bribes"),
                RiskEventTypeSubCategory.Create(Guid.Parse(unauthorisedActivitiesExternal), "Kickbacks"),
            #endregion
            #region Safe Environment
                RiskEventTypeSubCategory.Create(Guid.Parse(safeEnvironment), "Employee health and safety violations"),
                RiskEventTypeSubCategory.Create(Guid.Parse(safeEnvironment), "Worker's compensation claims"),
            #endregion
            #region Diversity and discrimination
                RiskEventTypeSubCategory.Create(Guid.Parse(diversityanddiscrimination), "Discrimination on account of religion, nationality, race"),
                RiskEventTypeSubCategory.Create(Guid.Parse(diversityanddiscrimination), "Worker's compensation claims"),
            #endregion
            #region Employee relations
                RiskEventTypeSubCategory.Create(Guid.Parse(employeerelations), "Employee disputes and investigations"),
                RiskEventTypeSubCategory.Create(Guid.Parse(employeerelations), "Mistakes in the administration of employee compensation, benefits, or termination"),
                RiskEventTypeSubCategory.Create(Guid.Parse(employeerelations), "Organised labour activities"),
                RiskEventTypeSubCategory.Create(Guid.Parse(employeerelations), "Fighting between staff"),
            #endregion
            #region Suitability, disclosure and fiduciary
                RiskEventTypeSubCategory.Create(Guid.Parse(suitabilitydisclosureandfiduciary), "Fiduciary breaches and guideline violations"),
                RiskEventTypeSubCategory.Create(Guid.Parse(suitabilitydisclosureandfiduciary), "Customer suitability violations"),
                RiskEventTypeSubCategory.Create(Guid.Parse(suitabilitydisclosureandfiduciary), "Disclosure / misuse of confidential client data"),
                RiskEventTypeSubCategory.Create(Guid.Parse(suitabilitydisclosureandfiduciary), "Breach of regulatory guidelines on foreign exchange transactions / suspicious transactions"),
            #endregion
            #region Improper business or market practices
                RiskEventTypeSubCategory.Create(Guid.Parse(improperbusinessormarketpractices), "Aggressive selling"),
                RiskEventTypeSubCategory.Create(Guid.Parse(improperbusinessormarketpractices), "Account churning"),
                RiskEventTypeSubCategory.Create(Guid.Parse(improperbusinessormarketpractices), "Unlicensed activities"),
                RiskEventTypeSubCategory.Create(Guid.Parse(improperbusinessormarketpractices), "Money laundering"),
                RiskEventTypeSubCategory.Create(Guid.Parse(improperbusinessormarketpractices), "Tax non-remittance"),
            #endregion
            #region Product flaws
                RiskEventTypeSubCategory.Create(Guid.Parse(productflaws), "Product defects (e.g. Marketing of unauthorised products)"),
                RiskEventTypeSubCategory.Create(Guid.Parse(productflaws), "Model errors (e.g. product conception, methodology, or pricing errors)"),
            #endregion
            #region Selection, sponsorship and exposure
                RiskEventTypeSubCategory.Create(Guid.Parse(selectionsponsorshipandexposure), "Non - compliance with internal guidelines when investigating a client"),
                RiskEventTypeSubCategory.Create(Guid.Parse(selectionsponsorshipandexposure), "Client exposure (loan) limits exceeded"),
            #endregion
            #region Consulting/Advisory Activities
                RiskEventTypeSubCategory.Create(Guid.Parse(consultingAdvisoryActivities), "Penalties / Fees incurred for contractual disputes / transgressions"),
            #endregion
            #region Mismanagement of classified company information
                RiskEventTypeSubCategory.Create(Guid.Parse(mismanagementofclassifiedcompanyinformation), "Competitors obtaining information about the firm's initiatives and business strategy"),
                RiskEventTypeSubCategory.Create(Guid.Parse(mismanagementofclassifiedcompanyinformation), "Misplacement of client information and correspondence"),
            #endregion
            #region Misrepresentation of company information
                RiskEventTypeSubCategory.Create(Guid.Parse(misrepresentationofcompanyinformation), "Errors in ARM's publications and annual reports"),
                RiskEventTypeSubCategory.Create(Guid.Parse(misrepresentationofcompanyinformation), "Misquotes by public media sources"),
            #endregion
            #region Poor Quality of Media Production
                RiskEventTypeSubCategory.Create(Guid.Parse(poorQualityofMediaProduction), "Inferior production of corporate gifts"),
                RiskEventTypeSubCategory.Create(Guid.Parse(poorQualityofMediaProduction), "Substandard /Offensive advertisements and promotional activities"),
                RiskEventTypeSubCategory.Create(Guid.Parse(poorQualityofMediaProduction), "Poor quality of Annual Reports prints"),
            #endregion
            #region Natural causes
                RiskEventTypeSubCategory.Create(Guid.Parse(naturalcauses), "Fire"),
                RiskEventTypeSubCategory.Create(Guid.Parse(naturalcauses), "floods"),
                RiskEventTypeSubCategory.Create(Guid.Parse(naturalcauses), "hail damage"),
            #endregion
            #region Accidents and public safety
                RiskEventTypeSubCategory.Create(Guid.Parse(accidentsandpublicsafety), "General responsibility for injuries caused to third parties eg. company Vehicle accidents"),
                RiskEventTypeSubCategory.Create(Guid.Parse(accidentsandpublicsafety), "Electrical surges"),
                RiskEventTypeSubCategory.Create(Guid.Parse(accidentsandpublicsafety), "Fire outbreak"),
                RiskEventTypeSubCategory.Create(Guid.Parse(accidentsandpublicsafety), "Water spillage"),
                RiskEventTypeSubCategory.Create(Guid.Parse(accidentsandpublicsafety), "Smoke detectors not functioning"),
                RiskEventTypeSubCategory.Create(Guid.Parse(accidentsandpublicsafety), "Fire alarms not functioning"),
            #endregion
            #region Retroactive effects and improper activities by third parties
                RiskEventTypeSubCategory.Create(Guid.Parse(retroactiveeffectsandimproperactivitiesbythirdparties), "Political interference in the companys operations"),
                RiskEventTypeSubCategory.Create(Guid.Parse(retroactiveeffectsandimproperactivitiesbythirdparties), "Launch of competitive products by agents"),
                RiskEventTypeSubCategory.Create(Guid.Parse(retroactiveeffectsandimproperactivitiesbythirdparties), "Court debt judgements"),
                RiskEventTypeSubCategory.Create(Guid.Parse(retroactiveeffectsandimproperactivitiesbythirdparties), "Out-of-court settlement costs"),
                RiskEventTypeSubCategory.Create(Guid.Parse(retroactiveeffectsandimproperactivitiesbythirdparties), "Litigation expenses"),
                RiskEventTypeSubCategory.Create(Guid.Parse(retroactiveeffectsandimproperactivitiesbythirdparties), "Debt recovery expenses"),
                RiskEventTypeSubCategory.Create(Guid.Parse(retroactiveeffectsandimproperactivitiesbythirdparties), "Fines & penalties"),
                RiskEventTypeSubCategory.Create(Guid.Parse(retroactiveeffectsandimproperactivitiesbythirdparties), "Loan writeoff expenses"),
            #endregion
            #region Human Acts
                RiskEventTypeSubCategory.Create(Guid.Parse(humanActs), "Vandalisation of company property"),
                RiskEventTypeSubCategory.Create(Guid.Parse(humanActs), "Sabotage"),
                RiskEventTypeSubCategory.Create(Guid.Parse(humanActs), "Robberies"),
            #endregion
            #region Disputes with Regulatory Authorities or other Governmental Bodies
                RiskEventTypeSubCategory.Create(Guid.Parse(disputeswithRegulatoryAuthoritiesorotherGovernmentalBodies), "Missed deadlines"),
                RiskEventTypeSubCategory.Create(Guid.Parse(disputeswithRegulatoryAuthoritiesorotherGovernmentalBodies), "undeserved fines and licence supensions"),
            #endregion
            #region Interruption in services provided by external providers
                RiskEventTypeSubCategory.Create(Guid.Parse(interruptioninservicesprovidedbyexternalproviders), "Interruption in communications"),
                RiskEventTypeSubCategory.Create(Guid.Parse(interruptioninservicesprovidedbyexternalproviders), "Power outages"),
                RiskEventTypeSubCategory.Create(Guid.Parse(interruptioninservicesprovidedbyexternalproviders), "Inability to process transactions"),
                RiskEventTypeSubCategory.Create(Guid.Parse(interruptioninservicesprovidedbyexternalproviders), "Telecommunication link outages"),
                RiskEventTypeSubCategory.Create(Guid.Parse(interruptioninservicesprovidedbyexternalproviders), "CCTV outages"),
            #endregion
            #region Inadequacy / Inefficiency / Malfunction or Block of Technology Systems
                RiskEventTypeSubCategory.Create(Guid.Parse(inadequacyInefficiencyMalfunctionorBlockofTechnologySystems), "System downtime"),
                RiskEventTypeSubCategory.Create(Guid.Parse(inadequacyInefficiencyMalfunctionorBlockofTechnologySystems), "Automated data processing errors"),
            #endregion
            #region Transaction capture, execution and maintenance
                RiskEventTypeSubCategory.Create(Guid.Parse(transactioncaptureexecutionandmaintenance), "Errors in the maintenance of information"),
                RiskEventTypeSubCategory.Create(Guid.Parse(transactioncaptureexecutionandmaintenance), "Data entry errors (payment instructions, rates)"),
                RiskEventTypeSubCategory.Create(Guid.Parse(transactioncaptureexecutionandmaintenance), "Transaction not booked"),
                RiskEventTypeSubCategory.Create(Guid.Parse(transactioncaptureexecutionandmaintenance), "Alteration not countersigned"),
                RiskEventTypeSubCategory.Create(Guid.Parse(transactioncaptureexecutionandmaintenance), "Transaction not registered"),
                RiskEventTypeSubCategory.Create(Guid.Parse(transactioncaptureexecutionandmaintenance), "Amount in words different from figures"),
                RiskEventTypeSubCategory.Create(Guid.Parse(transactioncaptureexecutionandmaintenance), "Application of wrong interest or exchange rates"),
                RiskEventTypeSubCategory.Create(Guid.Parse(transactioncaptureexecutionandmaintenance), "Failure to regularise customer instructions"),
                RiskEventTypeSubCategory.Create(Guid.Parse(transactioncaptureexecutionandmaintenance), "Data entry errors"),
                RiskEventTypeSubCategory.Create(Guid.Parse(transactioncaptureexecutionandmaintenance), "Processing undated transactions"),
                RiskEventTypeSubCategory.Create(Guid.Parse(transactioncaptureexecutionandmaintenance), "Improper identification of beneficiaries"),
                RiskEventTypeSubCategory.Create(Guid.Parse(transactioncaptureexecutionandmaintenance), "Wrong classification of accounts"),
            #endregion
            #region Monitoring and reporting
                RiskEventTypeSubCategory.Create(Guid.Parse(monitoringandreporting), "Incorrect client records"),
                RiskEventTypeSubCategory.Create(Guid.Parse(monitoringandreporting), "Inaccurate information sent to clients / external parties"),
            #endregion
            #region Customer intake and documentation
                RiskEventTypeSubCategory.Create(Guid.Parse(customerintakeanddocumentation), "Client permissions/disclaimers missing"),
                RiskEventTypeSubCategory.Create(Guid.Parse(customerintakeanddocumentation), "Contractual documents missing / incomplete / erroneous"),
                RiskEventTypeSubCategory.Create(Guid.Parse(customerintakeanddocumentation), "Improper account setup"),
                RiskEventTypeSubCategory.Create(Guid.Parse(customerintakeanddocumentation), "Incomplete account opening documentation"),
                RiskEventTypeSubCategory.Create(Guid.Parse(customerintakeanddocumentation), "Failure to upload mandates"),
            #endregion
            #region Customer account management
                RiskEventTypeSubCategory.Create(Guid.Parse(customeraccountmanagement), "Unapproved access given to accounts"),
                RiskEventTypeSubCategory.Create(Guid.Parse(customeraccountmanagement), "Negligent loss or damage of client assets"),
            #endregion
            #region Non-client counterparty breaches
                RiskEventTypeSubCategory.Create(Guid.Parse(nonclientcounterpartybreaches), "Failure of counter-party company to repay inter-company lending amounts on demand"),
            #endregion
            #region Vendors and suppliers
                RiskEventTypeSubCategory.Create(Guid.Parse(vendorsandsuppliers), "Failure of vendors to deliver on contractual obligations"),
                RiskEventTypeSubCategory.Create(Guid.Parse(vendorsandsuppliers), "Disagreements over terms of outsourcing contracts"),
            #endregion
            #region Other Process breakdown
                RiskEventTypeSubCategory.Create(Guid.Parse(otherProcessbreakdown), "Errors in Human Resources/ Administration processes"),
                RiskEventTypeSubCategory.Create(Guid.Parse(otherProcessbreakdown), "Procurement not authorised"),
                RiskEventTypeSubCategory.Create(Guid.Parse(otherProcessbreakdown), "Disposal of Fixed asset not approved")
            #endregion
            );
        }
    }
}
