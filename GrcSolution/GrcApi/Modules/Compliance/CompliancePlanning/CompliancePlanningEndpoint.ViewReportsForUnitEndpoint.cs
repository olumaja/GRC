using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;

namespace GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
      * Original Author: Olusegun Adaramaja
      * Date Created: 2/07/2024
      * Development Group: GRCTools
      * Compliance Planning: Get report by id Endpoint.     
      */
    public class ViewReportsForUnitEndpoint
    {
        /// <summary>
        /// Get all reports for each business unit
        /// </summary>
        /// <param name="currentUserService"></param>
        /// <param name="calendarRepo"></param>
        /// <param name="userRoleRepo"></param>
        /// <param name="userRepo"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            ICurrentUserService currentUserService, IRepository<ComplianceCalendar> calendarRepo, IRepository<UserRole> userRoleRepo,
            IRepository<User> userRepo, IRepository<UserRoleMap> userRoleMapRepo
        )
        {
            if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                return TypedResults.Unauthorized();

            var response = new List<GetCompliancePlaningReportDto>();
            var roles = currentUserService.CurrentUserRoles;

            if (!roles.Contains(GRCUserRole.OtherComplianceUser))
                return TypedResults.Ok(response);

            var roleId = userRoleRepo.GetContextByConditon(r => r.Name == GRCUserRole.OtherComplianceUser)
                                    .Select(r => r.Id)
                                    .FirstOrDefault();

            var userIds = userRoleMapRepo.GetContextByConditon(m => m.RoleId == roleId)
                                                .Select(m => m.UserId);

            var business = userRepo.GetContextByConditon(u => u.Email == currentUserService.CurrentUserEmail && userIds.Contains(u.Id))
                                .Select(u => u.Business)
                                .FirstOrDefault();

            var results = calendarRepo.GetContextByConditon(r => r.FirmToSubmit == business)
                                        .OrderByDescending(r => r.CreatedOnUtc);

            
            if (results.Count() == 0) return TypedResults.Ok(response);

            response = results.Select(x => new GetCompliancePlaningReportDto
            {
                ReportId = x.Id,
                ReportStatus = x.ReportStatus.ToString(),
                ResponseStatus = x.ResponseStatus.ToString(),
                ReportName = x.Name,
                Frequency = x.Frequency,
                UnitOfInterest = x.FirmToSubmit,
                Deadline = x.DeadLine,
                ReasonForRejection = x.ReasonForRejection,
                LeveLStatus = x.LevelStatus.ToString(),
                DateCreated = x.CreatedOnUtc,
                ProcessOfficer = x.ProcessOfficer,
                ApprovedBy = x.ApprovedBy,
                ApprovalDate = x.ApprovalDate,
                AttachmentCount = x.AttachmentCount.HasValue ? x.AttachmentCount.Value : 0
            }).ToList();
            
            return TypedResults.Ok(response);
        }
    }
}
