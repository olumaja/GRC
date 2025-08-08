using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Admin;

namespace GrcApi.Modules.Shared
{

    public enum UserStatus
    {
        Active,
        Disabled
    }

    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Business { get;  set; }
        public string? Department { get; set; }
        public string Unit { get; set; }
        public Guid UnitId { get; set; }
        public ModuleType? ModuleItemType { get; set; }
        public UserStatus Status { get; set; } = UserStatus.Active;
        public new string? CreatedBy { get; private set; }
        public new string? ModifiedBy { get; private set; }
        public List<UserRoleMap> UserRoleMap { get; set; }

        

        public static User Create(string name, string email, string business, string unit, Guid unitId, 
            string? department = null, ModuleType? moduleItemType = null
         )
        {
            return new User
            {
                Name = name,
                Email = email,
                Business = business,
                Department = department,
                Unit = unit,
                UnitId = unitId,
                ModuleItemType = moduleItemType
            };
        }

        public void Update(UpdateUser user )
        {
            Business = user.Business;
            Department = user.Department;
            Unit = user.Unit;
            UnitId = user.UnitId;
            Email = user.Email;
            Name = user.Name;
        }

        public void ChangeUserStatus(UserStatus status)
        {
            Status = status;
        }

        public void SetModifiedBy(string? modifiedBy)
        {
            ModifiedBy = modifiedBy;
        }

        public void SetCreatedBy(string? createdBy)
        {
            //AddCreatedBy();
            CreatedBy = createdBy;
        }

        public void AddModule(ModuleType moduleType)
        {
            ModuleItemType = moduleType;
        }
    }
}
