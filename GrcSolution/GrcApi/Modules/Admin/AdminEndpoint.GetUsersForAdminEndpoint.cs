using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared;
using Microsoft.EntityFrameworkCore;
using GrcApi.Modules.Shared.SessionManagement;
using System.Linq;
using GrcApi.Modules.Admin;

namespace Arm.GrcApi.Modules.Admin
{
    public class GetUsersForAdminEndpoint
    {
        /// <summary>
        /// Display all users in the module to admin
        /// </summary>
        /// <param name="role"></param>
        /// <param name="status"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="search"></param>
        /// <param name="userRepo"></param>
        /// <param name="sessionRepo"></param>
        /// <param name="currentUserService"></param>
        /// <param name="httpContext"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            string? role, string? status, DateTime? startDate, DateTime? endDate, string? search, IRepository<User> userRepo,
            IRepository<SessionTracker> sessionRepo, ICurrentUserService currentUserService, IHttpContextAccessor httpContext, 
            int pageSize = 0, int pageNumber = 0
        )
        {

            var users = userRepo.GetAll()
                                .Include(u => u.UserRoleMap)
                                .ThenInclude(m => m.Role);

            var currentAdmin = users.SingleOrDefault(u => u.Email == currentUserService.CurrentUserEmail);

            if (startDate is not null && endDate is not null)
            {
                if (startDate > endDate)
                    return TypedResults.BadRequest($"Start date {startDate} cannot be greater than end date {endDate}");

                users = users.Where(u => u.CreatedOnUtc.Date >= startDate.Value.Date && u.CreatedOnUtc.Date <= endDate.Value.Date)
                    .Include(m => m.UserRoleMap)
                    .ThenInclude(r => r.Role);
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                var statusDic = new Dictionary<string, UserStatus> { { "active", UserStatus.Active }, { "disabled", UserStatus.Disabled } };
                status = status.ToLower();

                if (!statusDic.ContainsKey(status))
                    return TypedResults.BadRequest("Status can either be Active or Disabled");

                users = users.Where(u => u.Status == statusDic[status])
                    .Include(m => m.UserRoleMap)
                    .ThenInclude(r => r.Role);
            }

            if (!string.IsNullOrWhiteSpace(role))
            {
                var userIds = users.SelectMany(u =>
                    u.UserRoleMap.Where(r =>
                    r.Role.Name == role
                    ).Select(m => m.UserId)
                    ).ToList();

                users = users.Where(u => userIds.Contains(u.Id))
                    .Include(m => m.UserRoleMap)
                    .ThenInclude(r => r.Role);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                users = users.Where(u => u.Name.ToLower().StartsWith(search.ToLower()))
                    .Include(m => m.UserRoleMap)
                    .ThenInclude(r => r.Role);
            }

            var usersSession = sessionRepo.GetAll()
                                        .Select(s => new Usersession { Email = s.Email, Lastlogin = s.LastLogin })
                                        .ToList();

            var allUsers = new List<UserResp>();

            foreach (var user in users)
            {
                var userRoles = user.UserRoleMap.Select(u => u.Role).ToList();
                var userRoleModuleType = userRoles.Select(r => r.ModuleItemType).ToList();
                var roles = userRoles.Select(r => r.Name).ToList();

                if (userRoleModuleType.Contains(currentAdmin.ModuleItemType))
                {
                    var lastLogin = usersSession.Find(l => l.Email == user.Email);
                    allUsers.Add(new UserResp(
                        Id: user.Id,
                        Name: user.Name,
                        Email: user.Email,
                        Business: user.Business,
                        Department: user.Department,
                        Unit: user.Unit,
                        DateCreated: user.CreatedOnUtc,
                        Role: string.Join(",", roles),
                        LastLogin: lastLogin != null ? lastLogin.Lastlogin : null,
                        Status: user.Status.ToString(),
                        LastModified: user.ModifiedOnUtc
                    ));
                }
            };

            var totalUser = allUsers.Count();
            var totalActiveUser = allUsers.Count(a => a.Status == UserStatus.Active.ToString());
            var totalDisabledUser = allUsers.Count(a => a.Status == UserStatus.Disabled.ToString());

            const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

            if (pageSize > MaxPageSize)
                pageSize = MaxPageSize;

            if (pageSize < 1)
                pageSize = DefaultPageSize;
            if (pageNumber < DefaultPageNumber)
                pageNumber = DefaultPageNumber;

            var paginatedTasks = Pagination<UserResp>.Create(allUsers.OrderByDescending(u => u.LastModified).AsQueryable(), pageNumber, pageSize);

            var paginationMeta = new PaginationMeta
            (
                paginatedTasks.HasNextPage,
                paginatedTasks.HasPreviousPage,
                paginatedTasks.CurrentPage,
                paginatedTasks.PageSize,
                paginatedTasks.TotalPages,
                paginatedTasks.TotalCount
            );

            httpContext.HttpContext.Response.AddPagination(paginationMeta);

            var response = new UserResponse(
                TotoalUser: totalUser,
                TotalActiveUser: totalActiveUser,
                TotalDisabledUser: totalDisabledUser,
                PaginationMeta: paginationMeta,
                Users: paginatedTasks
            );

            return TypedResults.Ok(response);
        }
    }
}
