using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
       * Original Author: Sodiq Quadre
       * Date Created: 07/06/2024
       * Development Group: GRCTools
       * Compliance Planning: Get Compliance Level By Business Unit Endpoint     
       */
    public class GetComplianceLevelByBusinessUnitEndpoint
    {
        /// <summary>
        /// Get Compliance Level By Business Unit
        /// </summary>
        /// <param name="businessunit"></param>
        /// <param name="level"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(string businessunit, IRepository<ComplianceCalendar> level, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                var getLevel = level.GetContextByConditon(c => c.FirmToSubmit == businessunit).ToList();
                if (getLevel.Count == 0) { return TypedResults.NotFound("No record found"); }
                List<GetComplianceLevelList> resp = new List<GetComplianceLevelList>();
                if (getLevel is not null)
                {
                    foreach (var item in getLevel)
                    {                        
                        resp.Add(new GetComplianceLevelList
                        {
                            BusinessUnit = item.FirmToSubmit,
                            ReportName = item.Name,
                            Frequesncy = item.Frequency,
                            DeadLine = item.DeadLine,
                            RespondStatus = item.ReportStatus.ToString(),
                            AttachementCount = item.AttachmentCount,
                            ReportStatus = item.ReportStatus.ToString(),
                            LeveLStatus = item.ReportStatus.ToString(),
                            ReasonForRejection = item.ReasonForRejection


                        });
                    }
                    return TypedResults.Ok(resp);

                }
                return TypedResults.NotFound();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }

        }
    }

}
