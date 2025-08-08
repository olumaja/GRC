using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 10/03/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* This endpoint allow Internal Audit officer perform risk rating on the business entities
*/
    public class BusinessRiskRatingARMHillEndpoint
    {
        /// <summary>
        /// Internal Audit officer perform risk rating on the ARMHill business entities
        /// Persist the rating into the DB
        /// </summary>
        /// <param name="request"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="hill"></param>
        /// <param name="strategy"></param>
        /// <param name="strategyArmhill"></param>
        /// <param name="ratedBusinessRiskRating"></param>
        /// <param name="operation"></param>
        /// <param name="operARMHill"></param>
        /// <param name="finance"></param>
        /// <param name="financeArmHill"></param>
        /// <param name="compliance"></param>
        /// <param name="complianceARMHill"></param>
        /// <param name="timeSinceLastHillAudit"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] ARMHillRequest request, IRepository<BusinessRiskRating> busnessRiskRating,
            IRepository<ARMHillRating> hill, IRepository<StrategyBusinessRatingARMHill> strategy,
            IRepository<StrategyHillRating> strategyArmhill, IRepository<RatedBusinessRiskRating> ratedBusinessRiskRating,

            IRepository<OperationBusinessRatingHill> operation, IRepository<OperationHillRating> operARMHill,

            IRepository<FinancialHillReporting> finance, IRepository<FinacialHillRating> financeArmHill,

            IRepository<ComplianceBusinessRatingHill> compliance,
            IRepository<ComplianceHillRating> complianceARMHill, IRepository<TimeSinceLastHillAudit> timeSinceLastHillAudit,
            ClaimsPrincipal user, ICurrentUserService currentUserService)

        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                string requesterName = user.Claims.FirstOrDefault(c => c.Type == "name").Value;
                //get the id by the requester email
                //var year = DateTime.Now.Year;
                var getByEmail = hill.GetContextByConditon(x => x.RequesterEmail == requesterName).FirstOrDefault();
                if (getByEmail != null)
                {
                    return TypedResults.Ok($"You have previously submitted a business risk rating for ARMHill for the year {DateTime.Now.Year}");
                }
                var getUser = busnessRiskRating.GetContextByConditon(x => x.RequesterName == requesterName).FirstOrDefault();
                if (getUser != null)
                {
                    var hillLog = ARMHillRating.Create(getUser.Id, request.ARMHill.Status, requesterName);
                    await hill.AddAsync(hillLog);

                    var strategyLog = StrategyBusinessRatingARMHill.Create(hillLog.Id, request.ARMHill.Strategy.Comment);
                    await strategy.AddAsync(strategyLog);

                    var strategyArmhillLog = StrategyHillRating.Create(strategyLog.Id, request.ARMHill);
                    await strategyArmhill.AddAsync(strategyArmhillLog);

                    var operationLog = OperationBusinessRatingHill.Create(hillLog.Id, request.ARMHill.Operations.Comment);
                    await operation.AddAsync(operationLog);

                    var operARMHillLog = OperationHillRating.Create(operationLog.Id, request.ARMHill);
                    await operARMHill.AddAsync(operARMHillLog);

                    var financeLog = FinancialHillReporting.Create(hillLog.Id, request.ARMHill.FinancialReporting.Comment);
                    await finance.AddAsync(financeLog);

                    var financeArmHillLog = FinacialHillRating.Create(financeLog.Id, request.ARMHill);
                    await financeArmHill.AddAsync(financeArmHillLog);

                    var complianceLog = ComplianceBusinessRatingHill.Create(hillLog.Id, request.ARMHill.Compliance.Comment);
                    await compliance.AddAsync(complianceLog);

                    var complianceARMHillLog = ComplianceHillRating.Create(complianceLog.Id, request.ARMHill);
                    await complianceARMHill.AddAsync(complianceARMHillLog);

                    var timeSinceLastHillAuditLog = TimeSinceLastHillAudit.Create(hillLog.Id, request.ARMHill);
                    await timeSinceLastHillAudit.AddAsync(timeSinceLastHillAuditLog);

                    var logratedBusinessRiskRating = RatedBusinessRiskRating.Create(getUser.Id, "ARMHill", requesterName, request.ARMHill.Status);
                    await ratedBusinessRiskRating.AddAsync(logratedBusinessRiskRating);
                    await ratedBusinessRiskRating.SaveChangesAsync();

                    BusinessRiskRatingResponse response = new BusinessRiskRatingResponse
                    {
                        BusinessRiskRatingID = getUser.Id
                    };

                    return TypedResults.Created($"apra/{response}", response);
                }

                if (getUser == null)
                {
                    var logRequest = BusinessRiskRating.Create(requesterName);
                    await busnessRiskRating.AddAsync(logRequest);

                    var hillLog2 = ARMHillRating.Create(logRequest.Id, request.ARMHill.Status, requesterName);
                    await hill.AddAsync(hillLog2);

                    var strategyLog2 = StrategyBusinessRatingARMHill.Create(hillLog2.Id, request.ARMHill.Strategy.Comment);
                    await strategy.AddAsync(strategyLog2);

                    var strategyArmhillLog2 = StrategyHillRating.Create(strategyLog2.Id, request.ARMHill);
                    await strategyArmhill.AddAsync(strategyArmhillLog2);

                    var operationLog2 = OperationBusinessRatingHill.Create(hillLog2.Id, request.ARMHill.Operations.Comment);
                    await operation.AddAsync(operationLog2);

                    var operARMHillLog2 = OperationHillRating.Create(operationLog2.Id, request.ARMHill);
                    await operARMHill.AddAsync(operARMHillLog2);

                    var financeLog2 = FinancialHillReporting.Create(hillLog2.Id, request.ARMHill.FinancialReporting.Comment);
                    await finance.AddAsync(financeLog2);

                    var financeArmHillLog2 = FinacialHillRating.Create(financeLog2.Id, request.ARMHill);
                    await financeArmHill.AddAsync(financeArmHillLog2);

                    var complianceLog2 = ComplianceBusinessRatingHill.Create(hillLog2.Id, request.ARMHill.Compliance.Comment);
                    await compliance.AddAsync(complianceLog2);

                    var complianceARMHillLog2 = ComplianceHillRating.Create(complianceLog2.Id, request.ARMHill);
                    await complianceARMHill.AddAsync(complianceARMHillLog2);

                    var timeSinceLastHillAuditLog2 = TimeSinceLastHillAudit.Create(hillLog2.Id, request.ARMHill);
                    await timeSinceLastHillAudit.AddAsync(timeSinceLastHillAuditLog2);

                    var logratedBusinessRiskRating2 = RatedBusinessRiskRating.Create(logRequest.Id, "ARMHill", requesterName, request.ARMHill.Status);
                    await ratedBusinessRiskRating.AddAsync(logratedBusinessRiskRating2);
                    await ratedBusinessRiskRating.SaveChangesAsync();


                    BusinessRiskRatingResponse response = new BusinessRiskRatingResponse
                    {
                        BusinessRiskRatingID = logRequest.Id
                    };

                    return TypedResults.Created($"apra/{response}", response);
                }
                return TypedResults.BadRequest("Unable to submit the request");
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }

        }
    }
}
