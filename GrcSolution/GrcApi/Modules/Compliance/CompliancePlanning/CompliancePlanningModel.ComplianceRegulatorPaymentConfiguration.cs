using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrcApi.Modules.Compliance.CompliancePlanning
{
    public class ComplianceRegulatorPaymentConfiguration : IEntityTypeConfiguration<ComplianceRegulatoryPayment>
    {
        public void Configure(EntityTypeBuilder<ComplianceRegulatoryPayment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PaymentDetail).HasMaxLength(int.MaxValue);
        }
    }
}

