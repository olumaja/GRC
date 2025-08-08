using Arm.GrcApi.Modules.Shared;

namespace GrcApi.Modules.Shared
{
    public class Permission : AuditEntity2
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Module { get; set; }
        public List<UserRolePermission> UserRolePermissions { get; set; }

        public static Permission Create(Guid id, string name, string module)
        {
            return new Permission { 
                Id = id, 
                Name = name,
                Module = module
            };
        }
    }
}
