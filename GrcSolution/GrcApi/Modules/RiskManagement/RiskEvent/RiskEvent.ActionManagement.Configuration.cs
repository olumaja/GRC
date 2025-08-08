using Arm.GrcTool.Domain.RiskEvent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrcApi.Modules.RiskManagement
{
    public class ActionManagementConfiguration : IEntityTypeConfiguration<ActionManagement>
    {
        public void Configure(EntityTypeBuilder<ActionManagement> builder)
        {
            builder.ToTable(nameof(ActionManagement));
            builder.HasKey(b => b.Id).IsClustered();
        }
    }
}
