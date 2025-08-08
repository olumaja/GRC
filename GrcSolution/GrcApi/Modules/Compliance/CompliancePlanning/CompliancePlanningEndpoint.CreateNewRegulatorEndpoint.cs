using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;
using System.Web.Http;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
      * Original Author: Sodiq Quadre
      * Date Created: 07/06/2024
      * Development Group: GRCTools
      * Compliance Planning: Create New Regulator Endpoint.     
      */
    public class CreateNewRegulatorEndpoint
    {
        /// <summary>
        /// Create New Regulator Endpoint.  
        /// </summary> 
        /// <param name="request"></param>
        /// <param name="regulator"></param>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            [FromBody] ComplianceRegulatorDto request, IRepository<ComplianceRegulator> regulator,
            IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                var checkIRegulatorExist = regulator.GetContextByConditon(c => c.Description == request.Description && c.RegulatorTitle == request.RegulatorTitle).FirstOrDefault();
                if (checkIRegulatorExist != null) { return TypedResults.Ok($"Regulator with the name {request.RegulatorTitle} has been previously created with the Id: {checkIRegulatorExist.Id}"); }

                if (checkIRegulatorExist == null)
                {
                    //log request
                    var logRequest = ComplianceRegulator.Create(request, currentUserService.CurrentUserFullName);
                    await regulator.AddAsync(logRequest);
                    await regulator.SaveChangesAsync();
                    var response = new CreateNewRegulatorResp
                    {
                        NewRegulatorId = logRequest.Id
                    };
                    return TypedResults.Created($"ar/{response}", response);
                }

                return TypedResults.BadRequest();
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }

        }
    }
}
