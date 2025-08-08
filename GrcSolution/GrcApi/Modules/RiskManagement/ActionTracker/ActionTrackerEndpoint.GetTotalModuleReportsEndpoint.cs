using Arm.GrcApi.Modules.RiskManagement.PRA;
using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.ActionTracker
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 11/12/2023
     * Development Group: GRCTools
     * This endpoint get total count of all the requests in each module 
    */
    public class GetTotalModuleReportsEndpoint
    {
        /// <summary>
        /// This endpoint get total count of all the requests in each module  
        /// </summary>
        /// <param name="getPRA"></param>
        /// <param name="getBIA"></param>
        /// <param name="getRCSA"></param>
        /// <param name="getRE"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(
            IRepository<ProductRiskAssessment> getPRA, IRepository<BusinessImpactAnalysisUnit> biaUnitRepo, IRepository<BIAUnitProcessDetails> biaProcessRepo,
            IRepository<RiskControlSelfAssessmentUnit> rcsaUnitRepo, IRepository<ProcessInherentRiskControl> inherentRiskControlRepo,
            IRepository<RiskEvent> getRE, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                var riskEventCount = getRE.GetAll().Count();
                var getAllPRA = await getPRA.GetAllAsync();

                var biaUnitCount = biaUnitRepo.GetAll().Count();
                var biaProcessCount = biaProcessRepo.GetAll().Count();
                var totalBIA = biaUnitCount > biaProcessCount ? biaUnitCount : biaProcessCount;

                var rcsaUnitCount = rcsaUnitRepo.GetAll().Count();
                var processInherentRiskCount = inherentRiskControlRepo.GetAll().Count();
                var totalRCSA = rcsaUnitCount > processInherentRiskCount ? rcsaUnitCount : processInherentRiskCount;

                GetTotalModuleReports response = new GetTotalModuleReports()
                {
                    BusinessImpactAnalysis = totalBIA,
                    ProductRiskAssessment = getAllPRA.Count(),
                    RiskIdentification = riskEventCount,
                    RiskControlSelfAssessment = totalRCSA,
                };
                return TypedResults.Ok(response);
            }
            catch (Exception ex)
            {

                return TypedResults.NotFound("Record not found");
            }
        }

    }
}
