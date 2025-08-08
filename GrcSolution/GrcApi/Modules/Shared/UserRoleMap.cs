using Arm.GrcApi.Modules.Shared;

namespace GrcApi.Modules.Shared
{
    public class UserRoleMap : AuditEntity
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public User User { get; set; }
        public UserRole Role { get; set; }

        public static UserRoleMap Create(Guid userId, Guid roleId)
        {
            return new UserRoleMap
            {
                UserId = userId,
                RoleId = roleId
            };
        }
    }
}
