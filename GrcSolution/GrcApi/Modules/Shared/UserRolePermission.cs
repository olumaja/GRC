using Arm.GrcApi.Modules.Shared;

namespace GrcApi.Modules.Shared
{
    public class UserRolePermission : AuditEntity
    {
        public Guid UserRoleId { get; set; }
        public Guid PermissionId { get; set; }
        public UserRole UserRole { get; set; }
        public Permission Permission { get; set; }

        public static UserRolePermission Create(Guid roleId, Guid permissionId)
        {
            return new UserRolePermission
            {
                UserRoleId = roleId,
                PermissionId = permissionId
            };
        }
    }
}
