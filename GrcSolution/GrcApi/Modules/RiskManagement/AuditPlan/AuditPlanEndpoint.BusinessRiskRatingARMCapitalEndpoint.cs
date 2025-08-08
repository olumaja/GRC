using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;
using System.Web.Http;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
 * Original Author: Sodiq Quadre
 * Date Created: 17/08/2024
 * Development Group: Audit plan Risk Assessment - GRCTools
 * This endpoint allow Internal Audit officer perform risk rating on the business entities
 */
    public class BusinessRiskRatingARMCapitalEndpoint
    {
        /// <summary>
        /// Internal Audit officer perform risk rating on the ARM Capital business entities
        /// Persist the rating into the DB
        /// </summary>
        /// <param name="request"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="armDFS"></param>
        /// <param name="strategy"></param>
        /// <param name="strategyDFS"></param>
        /// <param name="operation"></param>
        /// <param name="operDFS"></param>
        /// <param name="finance"></param>
        /// <param name="financeDFS"></param>
        /// <param name="compliance"></param>
        /// <param name="complianceDFS"></param>
        /// <param name="timeSinceLastDFSAudit"></param>
        /// <param name="ratedBusinessRiskRating"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] ARMCapitalRequest request, IRepository<BusinessRiskRating> busnessRiskRating,
         IRepository<ARMCapitalBusinessRiskRating> armDFS, IRepository<StrategyARMCapital> strategy, IRepository<StrategyARMCapitalRating> strategyDFS,

         IRepository<OperationARMCapital> operation, IRepository<OperationARMCapitalRating> operDFS,

         IRepository<FinancialARMCapital> finance, IRepository<FinacialBusinessARMCapitalRating> financeDFS,
         IRepository<ComplianceARMCapital> compliance, IRepository<ComplianceBusinessARMCapitalRating> complianceDFS,
         IRepository<TimeSinceLastAuditARMCapital> timeSinceLastDFSAudit, IRepository<RatedBusinessRiskRating> ratedBusinessRiskRating, ClaimsPrincipal user, ICurrentUserService currentUserService
         )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                string requesterName = user.Claims.FirstOrDefault(c => c.Type == "name").Value;
                //var year = DateTime.Now.Year;
                var getByEmail = armDFS.GetContextByConditon(x => x.RequesterName == requesterName).FirstOrDefault();
                if (getByEmail != null)
                {
                    return TypedResults.Ok($"You have previously submitted a business risk rating for ARM Capital for the year {DateTime.Now.Year}");
                }
                var getUser = busnessRiskRating.GetContextByConditon(x => x.RequesterName == requesterName).FirstOrDefault();
                if (getUser != null)
                {
                    var logRequestId = ARMCapitalBusinessRiskRating.Create(getUser.Id, request.ARMCapital.Status, requesterName);
                    await armDFS.AddAsync(logRequestId);

                    var logStrategy = StrategyARMCapital.Create(logRequestId.Id, request.ARMCapital.Strategy.Comment);
                    await strategy.AddAsync(logStrategy);

                    var strategyDFSLog = StrategyARMCapitalRating.Create(logStrategy.Id, request.ARMCapital);
                    await strategyDFS.AddAsync(strategyDFSLog);

                    var operationLog = OperationARMCapital.Create(logRequestId.Id, request.ARMCapital.Operations.Comment);
                    await operation.AddAsync(operationLog);

                    var operDFSLog = OperationARMCapitalRating.Create(operationLog.Id, request.ARMCapital);
                    await operDFS.AddAsync(operDFSLog);

                    var financeLog = FinancialARMCapital.Create(logRequestId.Id, request.ARMCapital.FinancialReporting.Comment);
                    await finance.AddAsync(financeLog);

                    var financeTAMLog = FinacialBusinessARMCapitalRating.Create(financeLog.Id, request.ARMCapital);
                    await financeDFS.AddAsync(financeTAMLog);

                    var complianceLog = ComplianceARMCapital.Create(logRequestId.Id, request.ARMCapital.Compliance.Comment);
                    await compliance.AddAsync(complianceLog);

                    var complianceDFSLog = ComplianceBusinessARMCapitalRating.Create(complianceLog.Id, request.ARMCapital);
                    await complianceDFS.AddAsync(complianceDFSLog);

                    var timeSinceLastDFSAuditLog = TimeSinceLastAuditARMCapital.Create(logRequestId.Id, request.ARMCapital);
                    await timeSinceLastDFSAudit.AddAsync(timeSinceLastDFSAuditLog);

                    var logratedBusinessRiskRating = RatedBusinessRiskRating.Create(getUser.Id, "ARMCapital", requesterName, request.ARMCapital.Status);
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

                    var logRequestId2 = ARMCapitalBusinessRiskRating.Create(logRequest.Id, request.ARMCapital.Status, requesterName);
                    await armDFS.AddAsync(logRequestId2);

                    var logStrategy2 = StrategyARMCapital.Create(logRequestId2.Id, request.ARMCapital.Strategy.Comment);
                    await strategy.AddAsync(logStrategy2);

                    var strategyDFSLog = StrategyARMCapitalRating.Create(logStrategy2.Id, request.ARMCapital);
                    await strategyDFS.AddAsync(strategyDFSLog);

                    var operationLog2 = OperationARMCapital.Create(logRequestId2.Id, request.ARMCapital.Operations.Comment);
                    await operation.AddAsync(operationLog2);

                    var operDFSLog2 = OperationARMCapitalRating.Create(operationLog2.Id, request.ARMCapital);
                    await operDFS.AddAsync(operDFSLog2);

                    var financeLog2 = FinancialARMCapital.Create(logRequestId2.Id, request.ARMCapital.FinancialReporting.Comment);
                    await finance.AddAsync(financeLog2);

                    var financeTAMLog2 = FinacialBusinessARMCapitalRating.Create(financeLog2.Id, request.ARMCapital);
                    await financeDFS.AddAsync(financeTAMLog2);

                    var complianceLog2 = ComplianceARMCapital.Create(logRequestId2.Id, request.ARMCapital.Compliance.Comment);
                    await compliance.AddAsync(complianceLog2);

                    var complianceDFSLog2 = ComplianceBusinessARMCapitalRating.Create(complianceLog2.Id, request.ARMCapital);
                    await complianceDFS.AddAsync(complianceDFSLog2);

                    var timeSinceLastDFSAuditLog2 = TimeSinceLastAuditARMCapital.Create(logRequestId2.Id, request.ARMCapital);
                    await timeSinceLastDFSAudit.AddAsync(timeSinceLastDFSAuditLog2);

                    var logratedBusinessRiskRating2 = RatedBusinessRiskRating.Create(logRequest.Id, "ARMCapital", requesterName, request.ARMCapital.Status);
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
