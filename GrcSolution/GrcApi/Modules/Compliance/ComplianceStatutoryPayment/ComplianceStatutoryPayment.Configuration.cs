using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment
{
    public class ComplianceStatutoryPaymentConfigurtion : IEntityTypeConfiguration<ComplianceStatutoryPayment>
    {
        public void Configure(EntityTypeBuilder<ComplianceStatutoryPayment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Purpose).HasMaxLength(int.MaxValue);
            builder.Property(x => x.Comments).HasMaxLength(int.MaxValue);
        }
    }
}
