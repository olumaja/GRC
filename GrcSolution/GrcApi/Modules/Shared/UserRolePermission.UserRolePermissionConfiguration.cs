using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using Arm.GrcApi.Modules.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrcApi.Modules.Shared
{
    public class UserRolePermissionConfiguration : IEntityTypeConfiguration<UserRolePermission>
    {
        public void Configure(EntityTypeBuilder<UserRolePermission> builder)
        {
            builder.ToTable(nameof(UserRolePermission));
            builder.HasKey(b => new { b.UserRoleId, b.PermissionId });
            builder.HasOne(b => b.UserRole).WithMany(u => u.UserRolePermissions).HasForeignKey(b => b.UserRoleId);
            builder.HasOne(b => b.Permission).WithMany(u => u.UserRolePermissions).HasForeignKey(b => b.PermissionId);

            builder.HasData(
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.UnitHead), new Guid("9F87D685-92C9-42B4-A58E-20FE028DD3C4")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.RiskChampion), new Guid("9F87D685-92C9-42B4-A58E-20FE028DD3C4")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.Staff), new Guid("9F87D685-92C9-42B4-A58E-20FE028DD3C4")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.UnitHead), new Guid("B5333A97-47AE-4464-82E7-EB552230FD2C")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.RiskChampion), new Guid("B5333A97-47AE-4464-82E7-EB552230FD2C")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.RiskChampion), new Guid("F8684D71-0B28-4F93-BCD7-D1F7C107708F")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.RiskChampion), new Guid("E1F00B8C-9704-4406-9D61-468146FE06DD")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.UnitHead), new Guid("F8684D71-0B28-4F93-BCD7-D1F7C107708F")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.UnitHead), new Guid("E1F00B8C-9704-4406-9D61-468146FE06DD")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.RiskChampion), new Guid("836B6390-AA37-4C3C-BDC1-42F9977A16B4")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.RiskChampion), new Guid("559C4F59-68AC-4F83-A708-6632B8A080F4")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.RiskChampion), new Guid("2E44D6A0-5C92-40BE-8D5E-28A586DDEB26")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.UnitHead), new Guid("ED334B91-9E47-46F0-92B7-84C9A1E34B9E")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.UnitHead), new Guid("6AE48C8E-E15C-40AA-A660-3A7556D53F3C")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.UnitHead), new Guid("4467735E-4043-40A7-B571-654751D1B8D5")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.UnitHead), new Guid("F2641950-69D9-499C-8E7B-4B7B2A8A6EFB")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.RiskChampion), new Guid("C42A1AC1-014C-4BFA-A258-7DDB9B257B58")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.UnitHead), new Guid("0F4E423F-2A2D-48BB-B8B7-3C1A4D444FA2")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.UnitHead), new Guid("7F5E914D-5C48-4659-A46E-9461F64F4C9B")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.UnitHead), new Guid("42A05247-8579-4C6C-96BF-D5CD3A73A89F")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.RiskChampion), new Guid("42A05247-8579-4C6C-96BF-D5CD3A73A89F")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.UnitHead), new Guid("A17E0B76-5D29-4C79-A8DF-BAE18DA34CB1")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.RiskChampion), new Guid("A17E0B76-5D29-4C79-A8DF-BAE18DA34CB1")),
                //Compliance
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.ComplianceOfficer), new Guid("078C30E2-702E-4ABE-AF61-FC86357535D7")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.ComplianceOfficer), new Guid("AC289FC1-4149-42E3-9870-3EC94DE81BFA")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.ComplianceOfficer), new Guid("E36A0878-2621-4749-849C-0CC979EC0B32")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.ComplianceOfficer), new Guid("4CA6B903-3F45-446D-B1AE-6D99B696C845")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.ComplianceOfficer), new Guid("34E8D57A-E3F3-471E-BE17-B8B70988282B")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.OtherComplianceUser), new Guid("3FA5B006-8D8F-4FEC-AFF9-249615A896A1")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.ComplianceOfficer), new Guid("0291715F-C93A-425F-91E3-3F4D64CBE720")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.ComplianceOfficer), new Guid("C135CA16-E877-4E16-AED0-9E330456F33F")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.ComplianceOfficer), new Guid("CF2A9CDE-97EB-41E0-B17F-D7AC38FF601B")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.ComplianceOfficer), new Guid("316F9D9A-3F5C-40E9-B5A5-25833587BDA3")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.OtherComplianceUser), new Guid("0D542309-09B4-4176-AD55-E7D42E028D14")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.ComplianceOfficer), new Guid("05CA74CC-CD70-4965-9EA5-2530E2171774")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.ComplianceOfficer), new Guid("A9E34482-DD6B-4274-AE9F-0214D6490B3E")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.HROfficer), new Guid("438D86F6-F78C-44A8-B0FE-DEB55693E80A")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.HROfficer), new Guid("F5B16AF9-1C7D-4C03-8C4C-5669819F74CF")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.FINCON), new Guid("9425E21E-0372-466C-BFF1-70B685A75EE8")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.Treasury), new Guid("3889F9F8-25A5-4904-9D9C-56BF9D506A1D")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.HROfficer), new Guid("F0157A4D-DE6C-47C7-A4B3-243EBF8076CA")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.HROfficer), new Guid("5C9BD282-D701-4591-877B-9E36A61CFF69")),
                //Internal Control
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalControlOfficer), new Guid("3CB6772E-8370-41E2-A4FF-9ADFA83E038C")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalControlOfficer), new Guid("D1ADA3B1-3E74-4D43-8B65-0DA982AFF7E5")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalControlOfficer), new Guid("B67903BD-6435-412D-947C-46A0D2DB14AE")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalControlOfficer), new Guid("57AFE880-14B9-4FCB-B627-AFE5F63B3029")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalControlOfficer), new Guid("91DC6D3F-DD35-451E-B04A-FA455816C09C")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalControlOfficer), new Guid("FFE65EF0-6506-47E6-B8CA-A9290F13C7C5")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalControlOfficer), new Guid("69A2E6E4-0837-47FA-8DA9-958F632AFF10")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalControlOfficer), new Guid("8AEA0F36-AB57-4F65-B9F2-5945EB3E9436")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalControlOfficer), new Guid("FC74BE96-CE8E-469E-8A1A-83A98AADDD08")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalControlOfficer), new Guid("5ED6A1A1-55A1-4F6F-A9BB-F61F3CA03DF1")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalControlOfficer), new Guid("218B0863-5156-4488-AB9A-B71C8AE9D2B4")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalControlSupervisor), new Guid("B2A7429B-74B8-419F-B3EC-A5CAB34ABFC9")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalControlCallOverSupervisor), new Guid("55B7F825-39A1-4437-A42E-2A333AE6658D")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalControlCallOverSupervisor), new Guid("26AECBD2-EB44-42B2-B83D-4B6778A9A6B8")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalControlCallOverOfficer), new Guid("C54A7D72-D291-49A0-A6AE-BA94F662EE8E")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalControlCallOverOfficer), new Guid("D4C9AFFA-992A-48B5-8E17-97E44AA3E232")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalControlOfficer), new Guid("D20F5128-EF29-4B73-BAC2-28F115906938")),
                //Operation Control
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.OperationControlOfficer), new Guid("1C10CDA1-CD2A-42A4-B295-53404768DC35")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.OperationControlSupervisor), new Guid("1C10CDA1-CD2A-42A4-B295-53404768DC35")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.OperationControlSupervisor), new Guid("D35AB363-6BA9-4812-B0E1-C4685725D688")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.OperationControlOfficer), new Guid("9F95E4C7-2D36-495C-B30F-44B3C136FA40")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.OperationControlSupervisor), new Guid("9F95E4C7-2D36-495C-B30F-44B3C136FA40")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.OperationControlOfficer), new Guid("98BD95CD-1C4A-4427-BD76-957624B0CA75")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.OperationControlSupervisor), new Guid("98BD95CD-1C4A-4427-BD76-957624B0CA75")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.OperationControlOfficer), new Guid("4BA7DE16-CC9B-4F2E-9CA6-4133CD025310")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.OperationControlSupervisor), new Guid("4BA7DE16-CC9B-4F2E-9CA6-4133CD025310")),
                //Internal Audit
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditOfficer), new Guid("DF5B084E-654D-4E82-84B2-45132D8379B7")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditOfficer), new Guid("183358B1-ECB3-4280-BCD1-50D6CBB31E1D")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditOfficer), new Guid("A78E57AF-08FC-4EAE-9DCC-0BBC0B973AD7")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditOfficer), new Guid("F6F0BFE0-8F31-484C-9D92-45803B717168")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditOfficer), new Guid("1700F355-1943-49CB-BB43-09D91AE939D9")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditSupervisor), new Guid("DE6F0445-9768-4CDF-B4A6-48C5AFBF666E")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditSupervisor), new Guid("87FB2CBD-B5DA-48BD-8966-A6BC109E7E9D")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditSupervisor), new Guid("A777E12A-F2D2-40E4-A6A3-1673FEA21290")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditSupervisor), new Guid("D9E92885-DDD4-4A6E-B779-3216E1BB2B4D")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditSupervisor), new Guid("DC200A69-BB01-4D07-94A8-79844DE5170D")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditSupervisor), new Guid("67805DA5-8BD6-441D-9B6B-9C370673C435")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditSupervisor), new Guid("D9D45947-D2E5-480E-95CF-379EFD384766")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditSupervisor), new Guid("9DA49C2D-B60C-43DC-9850-04E8E8FCD945")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditSupervisor), new Guid("26A31C04-6B1D-43D5-A0D0-EA73756FA20F")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditSupervisor), new Guid("706A5CED-92E3-46F1-8379-BF78129C1F68")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditOfficer), new Guid("1178EAAB-7EAC-4A3C-9A98-3D8C4B88A5F1")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditOfficer), new Guid("C56BE2CD-FEB9-4186-AADB-5C631B12CA35")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditSupervisor), new Guid("D8417DF3-E5B7-4AC5-98EF-8F7E0431D9BB")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditSupervisor), new Guid("E40CE5F0-19E6-49B9-A0CB-795C3EC26B67")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditSupervisor), new Guid("F6F8E3F6-D1CC-48D9-987A-BBC42EEBF7F3")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditSupervisor), new Guid("EAE56B73-B087-4FD8-81DD-F35F54485718")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditOfficer), new Guid("39BCA629-6BEF-4AF2-94E2-920D9FF9BC31")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditOfficer), new Guid("A5DF59DF-B003-42FC-802D-830BD167CB7E")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditOfficer), new Guid("689E70CD-0249-49EF-8518-04A0E344484D")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditOfficer), new Guid("5D027A16-4660-445C-850E-63C81242F5EA")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditOfficer), new Guid("5F870A71-0928-4655-A95D-FF677C4A31FF")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditOfficer), new Guid("607259D7-EDB7-4A94-A794-72F90CE076A0")),
                UserRolePermission.Create(new Guid(UserRoleSeedGuids.InternalAuditOfficer), new Guid("51E387A4-BCA5-48BD-B919-5C5E466F49B9"))
            );
        }
    }
}
