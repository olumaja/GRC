using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using DocumentFormat.OpenXml.Wordprocessing;
using GrcApi.Modules.Admin;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Modules.Admin
{
    public class AdminEndpoint
    {
        /// <summary>
        /// Display all users for the super admin
        /// </summary>
        /// <param name="userRepo"></param>
        /// <param name="httpContext"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            string? role, string? status, DateTime? startDate, DateTime? endDate, string? search, IRepository<User> userRepo, 
            IHttpContextAccessor httpContext, int pageSize = 0, int pageNumber = 0
        )
        {
            var users = userRepo.GetAll()
                                .Include(u => u.UserRoleMap)
                                .ThenInclude(m => m.Role);
            
            var totalUser = users.Count();
            var totalSuperAdmin = 0;
            var totalAdmin = 0;
            var admins = new List<AdminResp>();

            if(startDate is not null && endDate is not null)
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

            foreach (var user in users)
            {
                var roles = new List<string>();
                foreach(var mapUserRole in user.UserRoleMap)
                {
                    roles.Add(mapUserRole.Role.Name);

                    if(mapUserRole.Role.Name == GRCUserRole.SuperAdmin)
                    {
                        totalSuperAdmin++;
                    }

                    if (mapUserRole.Role.Name == GRCUserRole.Admin)
                    {
                        totalAdmin++;
                    }
                }

                admins.Add(new AdminResp
                (
                    Id: user.Id,
                    Name: user.Name,
                    Email: user.Email,
                    DateCreated: user.CreatedOnUtc,
                    Role: string.Join(",", roles),
                    Status: user.Status.ToString(),
                    LastModified: user.ModifiedOnUtc
                ));
            };

            const int MaxPageSize = 100, DefaultPageSize = 10, DefaultPageNumber = 1;

            if (pageSize > MaxPageSize)
                pageSize = MaxPageSize;

            if (pageSize < 1)
                pageSize = DefaultPageSize;
            if (pageNumber < DefaultPageNumber)
                pageNumber = DefaultPageNumber;

            var paginatedTasks = Pagination<AdminResp>.Create(admins.OrderByDescending(u => u.LastModified).AsQueryable(), pageNumber, pageSize);

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

            var response = new AdminResponse(
                TotoalUser: totalUser,
                SuperAdminCount: totalSuperAdmin,
                AdminCount: totalAdmin,
                PaginationMeta: paginationMeta,
                Admins: paginatedTasks
            );

            return TypedResults.Ok(response);
        }
    }
}
