using Arm.GrcApi.Modules.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrcApi.Modules.Shared
{
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable(nameof(Permission));
            builder.HasKey(x => x.Id); 

            builder.HasData(
                //Risk Management
                Permission.Create(new Guid("9F87D685-92C9-42B4-A58E-20FE028DD3C4"), "Create risk event", GRCModule.RiskIdentification),
                Permission.Create(new Guid("E6CA00E4-7080-4198-B75C-37A2A99D4BC2"), "Review risk event", GRCModule.RiskIdentification),
                Permission.Create(new Guid("226501C2-60C7-4254-BB7F-975480EAE817"), "Start RCSA", GRCModule.RCSA),
                Permission.Create(new Guid("836B6390-AA37-4C3C-BDC1-42F9977A16B4"), "Initiate RCSA", GRCModule.RCSA),
                Permission.Create(new Guid("6306F9E3-2489-4D8D-9846-FE741FAAB813"), "Review RCSA", GRCModule.RCSA),
                Permission.Create(new Guid("559C4F59-68AC-4F83-A708-6632B8A080F4"), "Process control risk rating", GRCModule.RCSA),
                Permission.Create(new Guid("2E44D6A0-5C92-40BE-8D5E-28A586DDEB26"), "Apply test to process inherent risk", GRCModule.RCSA),
                Permission.Create(new Guid("ED334B91-9E47-46F0-92B7-84C9A1E34B9E"), "Approve initiated RCSA", GRCModule.RCSA),
                Permission.Create(new Guid("6AE48C8E-E15C-40AA-A660-3A7556D53F3C"), "Reject initiated RCSA", GRCModule.RCSA),
                Permission.Create(new Guid("4467735E-4043-40A7-B571-654751D1B8D5"), "Approve reviewed test applied", GRCModule.RCSA),
                Permission.Create(new Guid("F2641950-69D9-499C-8E7B-4B7B2A8A6EFB"), "Reject reviewed test applied", GRCModule.RCSA),
                Permission.Create(new Guid("80041E2A-9387-4554-BA14-496DFC07358A"), "Finalize RCSA", GRCModule.RCSA),
                Permission.Create(new Guid("B5333A97-47AE-4464-82E7-EB552230FD2C"), "Initiate product risk assessment", GRCModule.PRA),
                Permission.Create(new Guid("E4DB911F-91DD-463E-A310-B441708198AA"), "Create assess risk", GRCModule.PRA),
                Permission.Create(new Guid("F8684D71-0B28-4F93-BCD7-D1F7C107708F"), "Approve product risk assessment", GRCModule.PRA),
                Permission.Create(new Guid("E1F00B8C-9704-4406-9D61-468146FE06DD"), "Reject product risk assessment", GRCModule.PRA),
                Permission.Create(new Guid("9F554761-84A3-4C52-9A3D-3955983C4CC3"), "Starts the Business Impact Analysis", GRCModule.BIA),
                Permission.Create(new Guid("C42A1AC1-014C-4BFA-A258-7DDB9B257B58"), "Initiate the Business Impact Analysis", GRCModule.BIA),
                Permission.Create(new Guid("0F4E423F-2A2D-48BB-B8B7-3C1A4D444FA2"), "Approve initiate business impact analysis", GRCModule.BIA),
                Permission.Create(new Guid("7F5E914D-5C48-4659-A46E-9461F64F4C9B"), "Reject initiate business impact analysis", GRCModule.BIA),
                Permission.Create(new Guid("42A05247-8579-4C6C-96BF-D5CD3A73A89F"), "Update action progress and status", GRCModule.ActionTracker),
                Permission.Create(new Guid("A17E0B76-5D29-4C79-A8DF-BAE18DA34CB1"), "Update action progress and status inherent risk", GRCModule.ActionTracker),

                //Compliance
                Permission.Create(new Guid("078C30E2-702E-4ABE-AF61-FC86357535D7"), "Create rule", GRCModule.CompliancePlanning),
                Permission.Create(new Guid("AC289FC1-4149-42E3-9870-3EC94DE81BFA"), "Update rule", GRCModule.CompliancePlanning),
                Permission.Create(new Guid("E36A0878-2621-4749-849C-0CC979EC0B32"), "Create business", GRCModule.CompliancePlanning),
                Permission.Create(new Guid("4CA6B903-3F45-446D-B1AE-6D99B696C845"), "Update business", GRCModule.CompliancePlanning),
                Permission.Create(new Guid("34E8D57A-E3F3-471E-BE17-B8B70988282B"), "Create regulator", GRCModule.CompliancePlanning),
                Permission.Create(new Guid("3FA5B006-8D8F-4FEC-AFF9-249615A896A1"), "Upload report", GRCModule.CompliancePlanning),
                Permission.Create(new Guid("0291715F-C93A-425F-91E3-3F4D64CBE720"), "Approve attached report", GRCModule.CompliancePlanning),
                Permission.Create(new Guid("C135CA16-E877-4E16-AED0-9E330456F33F"), "Reject attached report", GRCModule.CompliancePlanning),
                Permission.Create(new Guid("CF2A9CDE-97EB-41E0-B17F-D7AC38FF601B"), "Initiate regulatory payment", GRCModule.RegulatoryPayment),
                Permission.Create(new Guid("316F9D9A-3F5C-40E9-B5A5-25833587BDA3"), "Update regulatory payment", GRCModule.RegulatoryPayment),
                Permission.Create(new Guid("0D542309-09B4-4176-AD55-E7D42E028D14"), "Make Regulatory Payment", GRCModule.RegulatoryPayment),
                Permission.Create(new Guid("05CA74CC-CD70-4965-9EA5-2530E2171774"), "Approve regulatory payment", GRCModule.RegulatoryPayment),
                Permission.Create(new Guid("A9E34482-DD6B-4274-AE9F-0214D6490B3E"), "Reject regulatory payment", GRCModule.RegulatoryPayment),
                Permission.Create(new Guid("438D86F6-F78C-44A8-B0FE-DEB55693E80A"), "Initiate statutory payment", GRCModule.StatutoryPayment),
                Permission.Create(new Guid("F5B16AF9-1C7D-4C03-8C4C-5669819F74CF"), "Update statutory payment", GRCModule.StatutoryPayment),
                Permission.Create(new Guid("9425E21E-0372-466C-BFF1-70B685A75EE8"), "Process statutory payment", GRCModule.StatutoryPayment),
                Permission.Create(new Guid("3889F9F8-25A5-4904-9D9C-56BF9D506A1D"), "Submit statutory payment", GRCModule.StatutoryPayment),
                Permission.Create(new Guid("F0157A4D-DE6C-47C7-A4B3-243EBF8076CA"), "Approve statutory payment", GRCModule.StatutoryPayment),
                Permission.Create(new Guid("5C9BD282-D701-4591-877B-9E36A61CFF69"), "Reject statutory payment", GRCModule.StatutoryPayment),

                //Internal Control
                Permission.Create(new Guid("3CB6772E-8370-41E2-A4FF-9ADFA83E038C"), "Approve created Internal Control", GRCModule.InternalControl),
                Permission.Create(new Guid("D1ADA3B1-3E74-4D43-8B65-0DA982AFF7E5"), "Reject created Internal Control", GRCModule.InternalControl),
                Permission.Create(new Guid("B67903BD-6435-412D-947C-46A0D2DB14AE"), "Create Internal Control", GRCModule.InternalControl),
                Permission.Create(new Guid("57AFE880-14B9-4FCB-B627-AFE5F63B3029"), "Update Created Internal Control", GRCModule.InternalControl),
                Permission.Create(new Guid("91DC6D3F-DD35-451E-B04A-FA455816C09C"), "Upload attachment for created investigation", GRCModule.InternalControl),
                Permission.Create(new Guid("FFE65EF0-6506-47E6-B8CA-A9290F13C7C5"), "Update investigation status", GRCModule.InternalControl),
                Permission.Create(new Guid("69A2E6E4-0837-47FA-8DA9-958F632AFF10"), "Update Created Exception Tracker", GRCModule.InternalControlException),
                Permission.Create(new Guid("8AEA0F36-AB57-4F65-B9F2-5945EB3E9436"), "Create Exception Tracker", GRCModule.InternalControlException),
                Permission.Create(new Guid("FC74BE96-CE8E-469E-8A1A-83A98AADDD08"), "Delete Created Exception Tracker", GRCModule.InternalControlException),
                Permission.Create(new Guid("5ED6A1A1-55A1-4F6F-A9BB-F61F3CA03DF1"), "Share Exception report", GRCModule.InternalControlException),
                Permission.Create(new Guid("218B0863-5156-4488-AB9A-B71C8AE9D2B4"), "Create Task", GRCModule.InternalControlDashboard),
                Permission.Create(new Guid("B2A7429B-74B8-419F-B3EC-A5CAB34ABFC9"), "Supervisor to Update task", GRCModule.InternalControlDashboard),
                Permission.Create(new Guid("55B7F825-39A1-4437-A42E-2A333AE6658D"), "Approve created Call Over Report", GRCModule.InternalControlCallOver),
                Permission.Create(new Guid("26AECBD2-EB44-42B2-B83D-4B6778A9A6B8"), "Reject created Call Over Report", GRCModule.InternalControlCallOver),
                Permission.Create(new Guid("C54A7D72-D291-49A0-A6AE-BA94F662EE8E"), "Save call over report attachment", GRCModule.InternalControlCallOver),
                Permission.Create(new Guid("D4C9AFFA-992A-48B5-8E17-97E44AA3E232"), "Submit call over reports", GRCModule.InternalControlCallOver),
                Permission.Create(new Guid("D20F5128-EF29-4B73-BAC2-28F115906938"), "Save call over score", GRCModule.InternalControlCallOver),

                //Operation Control
                Permission.Create(new Guid("1C10CDA1-CD2A-42A4-B295-53404768DC35"), "Create operation control exception", GRCModule.OperationControl),
                Permission.Create(new Guid("D35AB363-6BA9-4812-B0E1-C4685725D688"), "Re-assigned exception", GRCModule.OperationControl),
                Permission.Create(new Guid("9F95E4C7-2D36-495C-B30F-44B3C136FA40"), "Approve operation exception", GRCModule.OperationControl),
                Permission.Create(new Guid("98BD95CD-1C4A-4427-BD76-957624B0CA75"), "Reject operation exception", GRCModule.OperationControl),
                Permission.Create(new Guid("4BA7DE16-CC9B-4F2E-9CA6-4133CD025310"), "Update operation control exception", GRCModule.OperationControl),

                //Internal Audit
                Permission.Create(new Guid("DF5B084E-654D-4E82-84B2-45132D8379B7"), "Audit announcement memo execution plan", GRCModule.AuditExecution),
                Permission.Create(new Guid("183358B1-ECB3-4280-BCD1-50D6CBB31E1D"), "Audit engagement letter plan", GRCModule.AuditExecution),
                Permission.Create(new Guid("A78E57AF-08FC-4EAE-9DCC-0BBC0B973AD7"), "Information requirement execution plan", GRCModule.AuditExecution),
                Permission.Create(new Guid("F6F0BFE0-8F31-484C-9D92-45803B717168"), "Audit planning memo execution plan", GRCModule.AuditExecution),
                Permission.Create(new Guid("1700F355-1943-49CB-BB43-09D91AE939D9"), "Audit program", GRCModule.AuditExecution),
                Permission.Create(new Guid("DE6F0445-9768-4CDF-B4A6-48C5AFBF666E"), "Approve audit announcement memo", GRCModule.AuditExecution),
                Permission.Create(new Guid("87FB2CBD-B5DA-48BD-8966-A6BC109E7E9D"), "Approve Engagement Letter", GRCModule.AuditExecution),
                Permission.Create(new Guid("A777E12A-F2D2-40E4-A6A3-1673FEA21290"), "Approve Information Requirement", GRCModule.AuditExecution),
                Permission.Create(new Guid("D9E92885-DDD4-4A6E-B779-3216E1BB2B4D"), "Approve Audit Planning Memo", GRCModule.AuditExecution),
                Permission.Create(new Guid("DC200A69-BB01-4D07-94A8-79844DE5170D"), "Approve Audit Program", GRCModule.AuditExecution),
                Permission.Create(new Guid("67805DA5-8BD6-441D-9B6B-9C370673C435"), "Reject Audit Announcement Memo", GRCModule.AuditExecution),
                Permission.Create(new Guid("D9D45947-D2E5-480E-95CF-379EFD384766"), "Reject Engagement Letter", GRCModule.AuditExecution),
                Permission.Create(new Guid("9DA49C2D-B60C-43DC-9850-04E8E8FCD945"), "Reject Information Requirement", GRCModule.AuditExecution),
                Permission.Create(new Guid("26A31C04-6B1D-43D5-A0D0-EA73756FA20F"), "Reject Audit Planning Memo", GRCModule.AuditExecution),
                Permission.Create(new Guid("706A5CED-92E3-46F1-8379-BF78129C1F68"), "Reject Audit Program", GRCModule.AuditExecution),
                Permission.Create(new Guid("1178EAAB-7EAC-4A3C-9A98-3D8C4B88A5F1"), "Initiate work paper", GRCModule.AuditExecution),
                Permission.Create(new Guid("C56BE2CD-FEB9-4186-AADB-5C631B12CA35"), "Initiate audit findings", GRCModule.AuditExecution),
                Permission.Create(new Guid("D8417DF3-E5B7-4AC5-98EF-8F7E0431D9BB"), "Approve work paper", GRCModule.AuditExecution),
                Permission.Create(new Guid("E40CE5F0-19E6-49B9-A0CB-795C3EC26B67"), "Reject work paper", GRCModule.AuditExecution),
                Permission.Create(new Guid("F6F8E3F6-D1CC-48D9-987A-BBC42EEBF7F3"), "Approve audit findings", GRCModule.AuditExecution),
                Permission.Create(new Guid("EAE56B73-B087-4FD8-81DD-F35F54485718"), "Reject audit findings", GRCModule.AuditExecution),
                Permission.Create(new Guid("39BCA629-6BEF-4AF2-94E2-920D9FF9BC31"), "Update Audit Announcement Memo", GRCModule.AuditExecution),
                Permission.Create(new Guid("A5DF59DF-B003-42FC-802D-830BD167CB7E"), "Update audit engagement letter", GRCModule.AuditExecution),
                Permission.Create(new Guid("689E70CD-0249-49EF-8518-04A0E344484D"), "Update Information Requirement", GRCModule.AuditExecution),
                Permission.Create(new Guid("5D027A16-4660-445C-850E-63C81242F5EA"), "Update Audit Planning Memo", GRCModule.AuditExecution),
                Permission.Create(new Guid("5F870A71-0928-4655-A95D-FF677C4A31FF"), "Update Audit Program", GRCModule.AuditExecution),
                Permission.Create(new Guid("607259D7-EDB7-4A94-A794-72F90CE076A0"), "Update work paper", GRCModule.AuditExecution),
                Permission.Create(new Guid("51E387A4-BCA5-48BD-B919-5C5E466F49B9"), "Update audit findings", GRCModule.AuditExecution)
            );
        }
    }
}
