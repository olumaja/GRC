
namespace Arm.GrcApi.Modules.Shared
{
    public class BaseEntity : AuditEntity
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string Name { get; protected set; } = null!;
    }
}
