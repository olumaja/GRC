using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Admin;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;

namespace Arm.GrcApi.Modules.Admin
{
    public class UpdateUserStatusEndpoint
    {
        public static async Task<IResult> HandleAsync(UpdateUserStatus userStatus, IRepository<User> userRepo, ICurrentUserService currentUserService)
        {
            if(userStatus.Status.ToLower() != "active" && userStatus.Status.ToLower() != "disabled")
                return TypedResults.BadRequest("Status can either be Active or Disabled");

            var user = await userRepo.FirstOrDefaultAsync(u => u.Email == userStatus.UserEmail);

            if (user is null)
                return TypedResults.BadRequest($"User {userStatus.UserName} doesnot exist");

            user.ChangeUserStatus((UserStatus) Enum.Parse(typeof(UserStatus), userStatus.Status));
            user.SetModifiedBy(currentUserService.CurrentUserFullName);
            user.SetModifiedOnUtc(DateTime.Now);
            userRepo.SaveChanges();

            return TypedResults.Ok($"{user.Name} status has been changed to {userStatus.Status}");
        }
    }
}
