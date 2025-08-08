using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrcApi.Modules.Shared
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable(nameof(UserRole));
            builder.Property(b => b.Name).IsRequired();
            builder.HasKey(b => b.Id);

            //unique constraint
            builder.HasIndex(e => e.Name)
            .IsUnique();

            // Seed data
            builder.HasData(
                UserRole.Create(new Guid(UserRoleSeedGuids.Admin), GRCUserRole.Admin),
                UserRole.Create(new Guid(UserRoleSeedGuids.UnitHead), GRCUserRole.UnitHead, ModuleType.RiskManagement),
                UserRole.Create(new Guid(UserRoleSeedGuids.RiskChampion), GRCUserRole.RiskChampion, ModuleType.RiskManagement),
                UserRole.Create(new Guid(UserRoleSeedGuids.Staff), GRCUserRole.Staff, ModuleType.RiskManagement),
                UserRole.Create(new Guid(UserRoleSeedGuids.OtherComplianceUser), GRCUserRole.OtherComplianceUser, ModuleType.Compliance),
                UserRole.Create(new Guid(UserRoleSeedGuids.ComplianceOfficer), GRCUserRole.ComplianceOfficer, ModuleType.Compliance),
                UserRole.Create(new Guid(UserRoleSeedGuids.HROfficer), GRCUserRole.HROfficer, ModuleType.Compliance),
                UserRole.Create(new Guid(UserRoleSeedGuids.FINCON), GRCUserRole.FINCON, ModuleType.Compliance),
                UserRole.Create(new Guid(UserRoleSeedGuids.Treasury), GRCUserRole.Treasury, ModuleType.Compliance),
                UserRole.Create(new Guid(UserRoleSeedGuids.InternalAuditOfficer), GRCUserRole.InternalAuditOfficer, ModuleType.InternalAudit),
                UserRole.Create(new Guid(UserRoleSeedGuids.InternalAuditSupervisor), GRCUserRole.InternalAuditSupervisor, ModuleType.InternalAudit),
                UserRole.Create(new Guid(UserRoleSeedGuids.InternalControlOfficer), GRCUserRole.InternalControlOfficer, ModuleType.InternalControl),
                UserRole.Create(new Guid(UserRoleSeedGuids.InternalControlSupervisor), GRCUserRole.InternalControlSupervisor, ModuleType.InternalControl),              
                UserRole.Create(new Guid(UserRoleSeedGuids.InternalAuditManagerConcern), GRCUserRole.InternalAuditManagerConcern, ModuleType.InternalAudit),
                UserRole.Create(new Guid(UserRoleSeedGuids.InternalAuditExecutiveManagerConcern), GRCUserRole.InternalAuditExecutiveManagerConcern, ModuleType.InternalAudit),
                UserRole.Create(new Guid(UserRoleSeedGuids.InternalControlCallOverOfficer), GRCUserRole.InternalControlCallOverOfficer, ModuleType.InternalControl),
                UserRole.Create(new Guid(UserRoleSeedGuids.InternalControlCallOverSupervisor), GRCUserRole.InternalControlCallOverSupervisor, ModuleType.InternalControl),
                UserRole.Create(new Guid(UserRoleSeedGuids.OperationControlOfficer), GRCUserRole.OperationControlOfficer, ModuleType.OperationControl),
                UserRole.Create(new Guid(UserRoleSeedGuids.OperationControlSupervisor), GRCUserRole.OperationControlSupervisor, ModuleType.OperationControl),
                UserRole.Create(new Guid(UserRoleSeedGuids.InternalAuditee), GRCUserRole.InternalAuditee, ModuleType.InternalAudit),
                UserRole.Create(new Guid(UserRoleSeedGuids.SuperAdmin), GRCUserRole.SuperAdmin),
                UserRole.Create(new Guid(UserRoleSeedGuids.InfoSecOfficer), GRCUserRole.InfoSecOfficer, ModuleType.InformationSecurity),
                UserRole.Create(new Guid(UserRoleSeedGuids.InfoSecISORiskChampion), GRCUserRole.InfoSecISORiskChampion, ModuleType.InformationSecurity),
                UserRole.Create(new Guid(UserRoleSeedGuids.InfoSecISOUnitHead), GRCUserRole.InfoSecISOUnitHead, ModuleType.InformationSecurity)
            );
        }
    }
}
