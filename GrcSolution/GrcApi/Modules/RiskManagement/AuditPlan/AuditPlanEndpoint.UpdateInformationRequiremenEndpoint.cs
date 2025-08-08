using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 06/05/2024
* Development Group: Audit plan Risk Assessment - GRCTools
*/
    public class UpdateInformationRequiremenEndpoint
    {
        /// <summary>
        /// Commence Engagement- Update Information Requirement   
        /// </summary>
        /// <param name="request"></param>
        /// <param name="inforRequirement"></param>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] UpdateInformationRequirementRequest request, IRepository<InformationRequirementAuditExecution> inforRequirement,             
            IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                string requesterUnit = user.Claims.FirstOrDefault(c => c.Type == "unit").Value;
                if (requesterUnit != "Internal Audit")
                { return TypedResults.Forbid(); }

                foreach (var item in request.InformationRequirement)
                {                    
                    var getinforRequirement = inforRequirement.GetContextByConditon(c => c.CommenceEngagementAuditexecutionId == request.CommenceEngagementId).FirstOrDefault();
                    if (getinforRequirement == null)
                    { return TypedResults.NotFound("Record was not found or it has been previously approved");  }

                    getinforRequirement.UpdateInformationRequirementAuditExecution(getinforRequirement.Id, getinforRequirement.CommenceEngagementAuditexecutionId, item.InformationRequest, item.ResponsibleOfficer, item.RequestDate, item.DateProvided);
                    getinforRequirement.SetModifiedBy(getinforRequirement.Id);
                    getinforRequirement.SetModifiedOnUtc(DateTime.Now);

                }
                inforRequirement.SaveChanges();

                return TypedResults.Ok("Record updated successfully");

            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }

        }
    }
}
