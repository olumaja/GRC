using Arm.GrcApi.Modules.Security;
using Arm.GrcTool.Domain.Employee;
using Arm.GrcTool.Infrastructure;
using Arm.GrcTool.Infrastructure.Data;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared.SessionManagement;
using System.Security.Claims;

/*
* Original Author: Olusegun Adaramaja
* Date Created: 20/03/2024
* Development Group: Logout - GRCTools
* Endpoint to ensure force user to logout from previous session before they login again
*/
namespace GrcApi.Modules.Employees
{
    /// <summary>
    /// This endpoint implement logout
    /// </summary>
    public class LogoutEndpoint
    {
        public static async Task<IResult> HandleAsync(IRepository<SessionTracker> sessionRepo, ICurrentUserService currentUserService)
        {
            
            var email = currentUserService.CurrentUserEmail;
            
            if (string.IsNullOrWhiteSpace(email))
            {
                return TypedResults.Unauthorized();
            }

            var session = sessionRepo.GetContextByConditon(s => s.Email == email)
                                    .FirstOrDefault();
            if(session is not null)
            {
                session.UpdateToken();
                session.UpdateRefreshToken();
                session.UpdateLastLogOut(DateTime.Now);
                sessionRepo.SaveChanges();
            }
            
            return TypedResults.Ok("Logout successful");
        }
    }

    public record LoginOutDto(string Email);
}
