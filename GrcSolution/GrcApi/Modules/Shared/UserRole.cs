using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;

namespace GrcApi.Modules.Shared
{
    public class UserRole : BaseEntity
    {
        public ModuleType? ModuleItemType { get; set; }
        public List<UserRoleMap> UserRoleMap { get; set; }
        public List<UserRolePermission> UserRolePermissions { get; set; }

        public static UserRole Create(Guid id, string name, ModuleType? moduleItemType = null)
        {
            return new UserRole
            {
                Id = id,
                Name = name,
                ModuleItemType = moduleItemType,
            };
        }

        //public static UserRole Create(string name)
        //{
        //    return new UserRole
        //    {
        //        Name = name
        //    };
        //}
    }
}
