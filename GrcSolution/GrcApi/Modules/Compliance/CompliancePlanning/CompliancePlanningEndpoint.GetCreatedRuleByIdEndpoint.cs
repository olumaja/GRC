using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 07/06/2024
     * Development Group: GRCTools
     * Compliance Planning: Get Created Rule by IdEndpoint     
     */
    public class GetCreatedRuleByIdEndpoint
    {
        /// <summary>
        /// Get Created Rule by Id Endpoint
        /// </summary>
        /// <param name="ruleid"></param>
        /// <param name="rule"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid ruleid, IRepository<ComplianceRules> rule, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var getRule = rule.GetContextByConditon(x => x.Id == ruleid)
                                .Include(r => r.ComplianceRulesBusiness)
                                .ThenInclude(b => b.ComplianceBusiness)
                                .FirstOrDefault();

                if (getRule is null)
                {
                    return TypedResults.NotFound($"Rule not found");
                }

                GetRulesAndRegulatorDetail resp = new GetRulesAndRegulatorDetail
                {
                    RuleId = getRule.Id,
                    Section = getRule.Section,
                    Heading = getRule.Heading,
                    Deadline = getRule.Deadline,
                    IssuesOrFillingOrReturn = getRule.IssuesOrFillingOrReturn,
                    Penalty = getRule.Penalty,
                    Responsibilities = getRule.Responsibilities,
                    DateCreated = getRule.CreatedOnUtc,
                    CreatedBy = getRule.InitiatedBy,
                    ModifiedBy = getRule.UpdatedBy,
                    DateModified = getRule.ModifiedOnUtc,
                    BusinessInvolved = string.Join(", ", getRule.ComplianceRulesBusiness.Select(b => b.ComplianceBusiness.BusinessName))
                };

                return TypedResults.Ok(resp);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }


        }
    }
}
