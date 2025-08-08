using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{
    /*
      * Original Author: Sodiq Quadre
      * Date Created: 07/06/2024
      * Development Group: GRCTools
      * Compliance Planning: View Created Rule Endpoint     
      */
    public class ViewCreatedRuleEndpoint
    {
        /// <summary>
        /// View Created Rule Endpoint 
        /// </summary>
        /// <param name="newRule"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid regulatorId, IRepository<ComplianceRules> ruleRepo, ICurrentUserService currentUserService)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var getRules = ruleRepo.GetContextByConditon(r => r.ComplianceRegulatorId == regulatorId)
                                    .Include(r => r.ComplianceRulesBusiness)
                                    .ThenInclude(b => b.ComplianceBusiness).OrderByDescending(r => r.CreatedOnUtc);

                var response = getRules.Select(r => new GetRulesAndRegulatorDetail
                {
                    RuleId = r.Id,
                    Section = r.Section,
                    Heading = r.Heading,
                    IssuesOrFillingOrReturn = r.IssuesOrFillingOrReturn,
                    Deadline = r.Deadline,
                    Responsibilities = r.Responsibilities,
                    Penalty = r.Penalty,
                    DateCreated = r.CreatedOnUtc,
                    CreatedBy = r.InitiatedBy,
                    ModifiedBy = r.UpdatedBy,
                    DateModified = r.ModifiedOnUtc,
                    BusinessInvolved = r.ComplianceRulesBusiness.Count == 0 ? "" : r.ComplianceRulesBusiness.Count == 1 ? r.ComplianceRulesBusiness.Select(b => b.ComplianceBusiness.BusinessName).FirstOrDefault() : $"{r.ComplianceRulesBusiness.Select(b => b.ComplianceBusiness.BusinessName).FirstOrDefault()} +{r.ComplianceRulesBusiness.Count - 1}"
                });

                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }

        }
    }
}
