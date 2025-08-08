using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrcApi.Modules.Compliance.CompliancePlanning
{
    public class ComplianceBusinesConfiguration : IEntityTypeConfiguration<ComplianceBusines>
    {
        public void Configure(EntityTypeBuilder<ComplianceBusines> builder)
        {
            builder.Property(b => b.Description).HasMaxLength(int.MaxValue);

            builder.HasData(
                ComplianceBusines.Create(new Guid("B8FDA6FB-0E8A-4621-BAE1-16F26D40F345"), "ARM Securities"),
                ComplianceBusines.Create(new Guid("C767A782-A495-4B96-988C-22E8E16C33D9"), "ARM IM"),
                ComplianceBusines.Create(new Guid("70C25108-C4C7-4221-B444-2A98BDDBBA7B"), "ARM Trustees"),
                ComplianceBusines.Create(new Guid("803DCB0E-6A10-4E3B-9C73-35F1C7C4A265"), "ARM Capital Partner")
            );
        }
    }
}
