using FluentValidation;
using Serilog;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GrcApi.Modules.Admin
{
    public record AdminDto(
        string Name, string Email, string Business, string Department, string Unit, string Module
    );

    public class AdminDtoValidator : AbstractValidator<AdminDto>
    {
        public AdminDtoValidator()
        {
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.Email).NotEmpty().EmailAddress();
            RuleFor(r => r.Business).NotEmpty();
            RuleFor(r => r.Department).NotEmpty();
            RuleFor(r => r.Unit).NotEmpty();
            RuleFor(r => r.Module).NotEmpty();
        }
    }

    public record CreateUserDto(
        string Name, string Email, string Business, string Department, string Unit, string Role
    );

    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.Email).NotEmpty().EmailAddress();
            RuleFor(r => r.Business).NotEmpty();
            RuleFor(r => r.Department).NotEmpty();
            RuleFor(r => r.Unit).NotEmpty();
            RuleFor(r => r.Role).NotEmpty();
        }
    }

    public record UpdateUserDto(
        Guid UserId, string Name, string Email, string Business, string Department, string Unit
    );

    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(r => r.UserId).NotEmpty();
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.Email).NotEmpty().EmailAddress();
            RuleFor(r => r.Business).NotEmpty();
            RuleFor(r => r.Department).NotEmpty();
            RuleFor(r => r.Unit).NotEmpty();
        }
    }

    public record UpdateUser(
        string Name, string Email, string Business, string Department, string Unit, Guid UnitId
    );

    public class ViewUserResp
    {
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Unit { get; set; }
        public Guid UnitId { get; set; }
        public string? Department { get; set; }
        public Guid DepartmentId { get; set; }
        public string? Entity { get; set; }
        public Guid BusinessId { get; set; }
        public string? Role { get; set; }
        public string? Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string? Module { get; set; }
        public DateTime? LastLogon { get; set; }
        public List<PermissionResponse> Permissions { get; set; }
    }

    public class RoleResponse { 
        public Guid RoleId { get; set; } 
        public string RoleName { get; set; }
        public List<PermissionResponse> Permissions { get; set; }
    }

    public class PermissionResponse
    {
        public string Name { get; set; }
        public string Module { get; set; }
    }

    public record UpdateUserStatus(string UserName, string UserEmail, string Status);

    public class UpdateUserStatusValidator : AbstractValidator<UpdateUserStatus>
    {
        public UpdateUserStatusValidator()
        {
            RuleFor(r => r.UserName).NotEmpty();
            RuleFor(r => r.UserEmail).NotEmpty().EmailAddress();
            RuleFor(r => r.Status).NotEmpty();
        }
    }

    public record ChangeUserRole(string UserName, string UserEmail, string Role);

    public class ChangeUserRoleValidator : AbstractValidator<ChangeUserRole>
    {
        public ChangeUserRoleValidator()
        {
            RuleFor(r => r.UserName).NotEmpty();
            RuleFor(r => r.UserEmail).NotEmpty().EmailAddress();
            RuleFor(r => r.Role).NotEmpty();
        }
    }
}
