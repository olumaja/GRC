//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;
//using Arm.GrcTool.Domain.BusinessImpactAnalysis;

//namespace Arm.GrcTool.Infrastructure
//{
//    public class BIAUnitProcessDetailsResponsibleBusinessUnitConfiguration : IEntityTypeConfiguration<BIAUnitProcessDetailsResponsibleBusinessUnit>
//    {
//        public void Configure(EntityTypeBuilder<BIAUnitProcessDetailsResponsibleBusinessUnit> builder)
//        {
//            builder.ToTable(nameof(BIAUnitProcessDetailsResponsibleBusinessUnit));
//            builder.HasKey(u => u.Id);
//            builder.Property(u => u.UnitId).IsRequired();
//            builder.Property(u => u.BIAUnitProcessDetailsId).IsRequired();
//        }
//    }
//}
