using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;
using System.Web.Http;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{

    /*
     * Original Author: Sodiq Quadre
     * Date Created: 07/06/2024
     * Development Group: GRCTools
     * Compliance Planning: Update Created Rule by Id Endpoint     
     */
    public class UpdateCreatedRuleEndpoint
    {
        /// <summary>
        /// Update Created Rule by Id Endpoint   
        /// </summary>
        /// <param name="request"></param>
        /// <param name="rule"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] UpdateComplianceRulesAndRegulator request, IRepository<ComplianceRules> rule,
            IRepository<ComplianceRulesBusiness> ruleBusinessRepo, ICurrentUserService currentUserService
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


                var getRule = rule.GetContextByConditon(c => c.Id == request.RuleId)
                                .Include(c => c.ComplianceRulesBusiness)
                                .FirstOrDefault();

                if (getRule is null)
                {
                    return TypedResults.NotFound($"Rule was not found");
                }

                getRule.Section = request.Section;
                getRule.Heading = request.Heading;
                getRule.Penalty = request.Penalty;
                getRule.Responsibilities = request.Responsibilities;
                getRule.Deadline = request.Deadline;
                getRule.IssuesOrFillingOrReturn = request.IssuesOrFillingOrReturn;
                getRule.UpdatedBy = currentUserService.CurrentUserFullName;
                getRule.SetModifiedOnUtc(DateTime.Now);
                rule.Update(getRule);
                                
                // Remove previously attached businesses
                ruleBusinessRepo.BulkDelete(x => x.ComplianceRuleId == request.RuleId);
                // Attach new businesses
                var rulesBusinesses = request.BusinessInvolvedIds.Select(id => ComplianceRulesBusiness.Create(request.RuleId, id)).ToList();
                await ruleBusinessRepo.AddRangeAsync(rulesBusinesses);
                await ruleBusinessRepo.SaveChangesAsync();

                return TypedResults.Ok("updated succcessfully");
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
