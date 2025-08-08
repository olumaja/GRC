using Arm.GrcTool.Domain.Risk;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace Arm.GrcTool.Infrastructure
{
    public class RiskEventTypeCategoryConfiguration : IEntityTypeConfiguration<RiskEventTypeCategory>
    {
        public void Configure(EntityTypeBuilder<RiskEventTypeCategory> builder)
        {
            builder.ToTable(nameof(RiskEventTypeCategory));
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("ID");
            builder.Property(c => c.Name).HasColumnName("NAME").HasMaxLength(70).IsRequired();

            builder.HasOne(c => c.RiskEventType).WithMany(c => c.RiskEventTypeCategories).HasForeignKey(c => c.RiskEventTypeId);

            //Risk event type Ids
            string internalFraud = "33AADBFC-FA8A-448A-93D4-0C57E1618BD3";
            string executionDeliveryAndProcessManagement = "B0FDD290-1EBF-4A08-803F-07A69D349B4D";
            string disastersAndOtherEvents = "AC12CF01-4E9B-4CD0-B578-9E1016A3E4C1";
            string externalFraud = "92FB8BA9-3B62-4D6A-ACB1-A4111B2196AD";
            string employmentPracticesAndWorkplaceSafety = "D47BD1F5-C11E-4F25-9854-E028A566DB5C";
            string businessDisruptionAndSystemFailures = "468F18E4-D9BE-49A9-AF61-00556B1EB6E8";
            string clientsProductsAndBusinessPractices = "2D5E2984-086E-41FA-8AF8-28EDE5D4079C";

            //Data seeding
            builder.HasData(
            #region Internal fraud
                RiskEventTypeCategory.Create(Guid.Parse("73A0DF86-D805-4E57-A6AD-B8AF814646A4"), Guid.Parse(internalFraud), "Theft and Fraud"),
                RiskEventTypeCategory.Create(Guid.Parse("8978FAF7-D8EF-482F-9845-6F8A232F64D4"), Guid.Parse(internalFraud), "System Security"),
                RiskEventTypeCategory.Create(Guid.Parse("7F26B2BC-E09D-4DCB-9E1B-375F971B66C1"), Guid.Parse(internalFraud), "Unauthorised Activities"),
            #endregion
            #region External fraud
                RiskEventTypeCategory.Create(Guid.Parse("3429AAD4-E734-44AC-919C-AF9758979AAB"), Guid.Parse(externalFraud), "Theft and Fraud"),
                RiskEventTypeCategory.Create(Guid.Parse("F9D3F84F-C129-46F1-9A6A-E18D7EF7F317"), Guid.Parse(externalFraud), "System Security"),
                RiskEventTypeCategory.Create(Guid.Parse("849DC895-ECA1-4165-B5AB-7CFCDC0D3EBB"), Guid.Parse(externalFraud), "Unauthorised Activities"),
            #endregion
            #region Employment practices and work placeSafety
                RiskEventTypeCategory.Create(Guid.Parse("AC39225C-DB94-4127-8675-C6645B51A8C1"), Guid.Parse(employmentPracticesAndWorkplaceSafety), "Safe Environment"),
                RiskEventTypeCategory.Create(Guid.Parse("A67CDE3E-3EC3-44EE-A4DD-AD45713CDAC7"), Guid.Parse(employmentPracticesAndWorkplaceSafety), "Diversity and discrimination"),
                RiskEventTypeCategory.Create(Guid.Parse("C96FDC22-4A35-4461-8726-5F73124545B1"), Guid.Parse(employmentPracticesAndWorkplaceSafety), "Employee relations"),
            #endregion
            #region Clients Products and Business Practices
                RiskEventTypeCategory.Create(Guid.Parse("A9386E4F-342C-4868-9EF6-9C2DB682AC0B"), Guid.Parse(clientsProductsAndBusinessPractices), "Suitability, disclosure and fiduciary"),
                RiskEventTypeCategory.Create(Guid.Parse("D93D70E3-39D2-4B82-8D73-BA447F1BC06D"), Guid.Parse(clientsProductsAndBusinessPractices), "Improper business or market practices"),
                RiskEventTypeCategory.Create(Guid.Parse("F2320468-3DEF-4022-A67F-AF0F6BBDC3CD"), Guid.Parse(clientsProductsAndBusinessPractices), "Product flaws"),
                RiskEventTypeCategory.Create(Guid.Parse("EF9C5269-9866-4D0B-BC67-1CDA07009562"), Guid.Parse(clientsProductsAndBusinessPractices), "Selection, sponsorship and exposure"),
                RiskEventTypeCategory.Create(Guid.Parse("05D02531-4D98-41F9-8C34-1DA6115B385B"), Guid.Parse(clientsProductsAndBusinessPractices), "Consulting/Advisory Activities"),
                RiskEventTypeCategory.Create(Guid.Parse("8E9BE527-5BC1-48F5-A07C-10F36CD6D759"), Guid.Parse(clientsProductsAndBusinessPractices), "Mismanagement of classified company information"),
                RiskEventTypeCategory.Create(Guid.Parse("5E969527-3694-477A-8F17-40E53039966C"), Guid.Parse(clientsProductsAndBusinessPractices), "Misrepresentation of company information"),
                RiskEventTypeCategory.Create(Guid.Parse("635CA6D7-708F-4349-A483-ECF00679C489"), Guid.Parse(clientsProductsAndBusinessPractices), "Poor Quality of Media Production"),
            #endregion
            #region Disasters and Other Events
                RiskEventTypeCategory.Create(Guid.Parse("715E84F3-6D29-49D0-B8AB-9F3C6C65D27E"), Guid.Parse(disastersAndOtherEvents), "Natural causes"),
                RiskEventTypeCategory.Create(Guid.Parse("611B88D4-5289-4DA1-A78D-420F236257DC"), Guid.Parse(disastersAndOtherEvents), "Accidents and public safety"),
                RiskEventTypeCategory.Create(Guid.Parse("FBFF5D8B-2C51-43E8-8A3D-6B7F2A5873A9"), Guid.Parse(disastersAndOtherEvents), "Retroactive effects and improper activities by third parties"),
                RiskEventTypeCategory.Create(Guid.Parse("62CE3931-6D3A-42D0-A0F4-F637E9AFD0B9"), Guid.Parse(disastersAndOtherEvents), "Human Acts"),
                RiskEventTypeCategory.Create(Guid.Parse("4E053FC0-8442-4DA3-A1D9-8A1CCA234912"), Guid.Parse(disastersAndOtherEvents), "Disputes with Regulatory Authorities or other Governmental Bodies"),
            #endregion
            #region Business Disruption and System Failures
                RiskEventTypeCategory.Create(Guid.Parse("0FBE8F2C-7905-40CD-837B-7CCD5195AFF6"), Guid.Parse(businessDisruptionAndSystemFailures), "Interruption in services provided by external providers"),
                RiskEventTypeCategory.Create(Guid.Parse("0FEF6D10-B14D-4912-A09A-5DB403D34154"), Guid.Parse(businessDisruptionAndSystemFailures), "Inadequacy Inefficiency Malfunction or Block of Technology Systems"),
            #endregion
            #region Execution Delivery and Process Management
                RiskEventTypeCategory.Create(Guid.Parse("52ECC3F4-55C8-4A9A-AB54-D86EB8F2B3D0"), Guid.Parse(executionDeliveryAndProcessManagement), "Transaction capture, execution and maintenance"),
                RiskEventTypeCategory.Create(Guid.Parse("84C43920-C0C7-4D25-86FE-1EC905D69E26"), Guid.Parse(executionDeliveryAndProcessManagement), "Monitoring and reporting"),
                RiskEventTypeCategory.Create(Guid.Parse("81F7E998-9B34-4092-8590-A551647DE2C0"), Guid.Parse(executionDeliveryAndProcessManagement), "Customer intake and documentation"),
                RiskEventTypeCategory.Create(Guid.Parse("C5C4E527-45E0-4BD2-917F-59783425E0A3"), Guid.Parse(executionDeliveryAndProcessManagement), "Customer account management"),
                RiskEventTypeCategory.Create(Guid.Parse("F6D2467A-358D-446E-B6EA-79C5C649B472"), Guid.Parse(executionDeliveryAndProcessManagement), "Non-client counterparty breaches"),
                RiskEventTypeCategory.Create(Guid.Parse("9A06F398-DACD-44DC-ABFD-CFE9721E6CE5"), Guid.Parse(executionDeliveryAndProcessManagement), "Vendors and suppliers"),
                RiskEventTypeCategory.Create(Guid.Parse("CB18E18C-39A4-4802-9CC5-9A775368CC98"), Guid.Parse(executionDeliveryAndProcessManagement), "Other Process breakdown")
            #endregion
            );
        }
    }
}
