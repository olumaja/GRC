using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
       * Original Author: Sodiq Quadre
       * Date Created: 07/06/2024
       * Development Group: GRCTools
       * Compliance Planning: View Compliance Level Endpoint     
       */
    public class ViewComplianceLevelEndpoint
    {
        /// <summary>
        /// View Compliance Level List
        /// </summary>
        /// <param name="level"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(string? businessUnit, IRepository<ComplianceCalendar> level, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var getLevel = level.GetAll();

                if(!string.IsNullOrWhiteSpace(businessUnit))
                    getLevel = getLevel.Where(l => l.FirmToSubmit == businessUnit);

                if (getLevel.Count() == 0) { return TypedResults.NotFound("No record found"); }

                var resp = getLevel.OrderByDescending(r => r.CreatedOnUtc).Select(r => new GetComplianceLevelList
                {
                    BusinessUnit = r.FirmToSubmit,
                    ReportName = r.Name,
                    Frequesncy = r.Frequency,
                    DeadLine = r.DeadLine,
                    RespondStatus = r.ResponseStatus.ToString(),
                    AttachementCount = r.AttachmentCount,
                    ReportStatus = r.ReportStatus.ToString(),
                    LeveLStatus = r.LevelStatus.ToString(),
                    ReasonForRejection = r.ReasonForRejection,
                    DateCreated = r.CreatedOnUtc,
                    ProcessOfficer = r.ProcessOfficer,
                    ApprovedBy = r.ApprovedBy,
                    ApprovedDate = r.ApprovalDate,
                    ModifiedBy = r.UpdatedBy,
                    DateModified = r.ModifiedOnUtc
                });

                return TypedResults.Ok(resp);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }

        }
    }

}
