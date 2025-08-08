using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrcApi.Modules.Compliance.CompliancePlanning
{
    public class ComplianceBusinessDepartmentConfiguration : IEntityTypeConfiguration<ComplianceBusinessDepartment>
    {
        public void Configure(EntityTypeBuilder<ComplianceBusinessDepartment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.ComplianceBusiness).WithMany(x => x.ComplianceBusinessDepartment).HasForeignKey(x => x.ComplianceBusinessId);
            builder.HasOne(x => x.ComplianceDepartment).WithMany(x => x.ComplianceBusinessDepartment).HasForeignKey(x => x.ComplianceDepartmentId);
        }
    }
}
