using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;
using System.Web.Http;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
      * Original Author: Sodiq Quadre
      * Date Created: 07/06/2024
      * Development Group: GRCTools
      * Compliance Planning: Add New Rule Endpoint     
      */
    public class AddNewRuleEndpoint
    {
        /// <summary>
        /// Create New Regulator Endpoint.  
        /// </summary> 
        /// <param name="request"></param>
        /// <param name="regulator"></param>
        /// <param name="newRule"></param>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            ComplianceRulesAndRegulatorDto request, IRepository<ComplianceRegulator> regulator, ICurrentUserService currentUserService,
            IRepository<ComplianceRules> newRule, IRepository<ComplianceRulesBusiness> complianceRulesBusinessRepo
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var startDate = new DateTime(1994, 1, 1);
                var endDate = DateTime.Now;

                if (!DateTime.TryParseExact(request.Deadline.ToString(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
                {
                    return TypedResults.BadRequest("Invalid date format. Deadline must be in the format yyyy-MM-dd");
                }               

                if (startDate.AddDays(1) < endDate)
                {
                    return TypedResults.BadRequest("Oops, Deadline date cannot be earlier than today's date");

                }
                var checkIfRegulatorExist = await regulator.GetByIdAsync(request.RegulatorId);

                if (checkIfRegulatorExist is null)
                    return TypedResults.NotFound($"Regulatior not found");

                var logRequest = ComplianceRules.Create(checkIfRegulatorExist.Id, request, currentUserService.CurrentUserFullName);
                await newRule.AddAsync(logRequest);

                //Add business to rule
                var rulesBusinesses = request.BusinessInvolvedIds.Select(id => ComplianceRulesBusiness.Create(logRequest.Id, id)).ToList();
                await complianceRulesBusinessRepo.AddRangeAsync(rulesBusinesses);
                await complianceRulesBusinessRepo.SaveChangesAsync();

                var response = new AddNewRuleResp
                {
                    NewRuleId = logRequest.Id
                };

                return TypedResults.Created($"ar/{response}", response);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }

        }
    }
}
