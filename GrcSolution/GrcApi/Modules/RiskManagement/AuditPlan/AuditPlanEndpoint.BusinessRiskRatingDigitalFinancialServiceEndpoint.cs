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
    public class BusinessRiskRatingDigitalFinancialServiceEndpoint
    {
        /// <summary>
        /// Internal Audit officer perform risk rating on the Digital Financial Services business entities
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
        public static async Task<IResult> HandleAsync([FromBody] DigitalFinancialServicesRequest request, IRepository<BusinessRiskRating> busnessRiskRating,
            IRepository<DigitalFinancialServiceBusinessRiskRating> armDFS, IRepository<StrategyDigitalFinancialService> strategy, IRepository<StrategyDigitalFinancialServiceRating> strategyDFS,

            IRepository<OperationDigitalFinancialService> operation, IRepository<OperationDigitalFinancialServiceRating> operDFS,

            IRepository<FinancialDigitalFinancialService> finance, IRepository<FinacialBusinessDigitalFinancialServiceRating> financeDFS,
            IRepository<ComplianceDigitalFinancialService> compliance, IRepository<ComplianceBusinessDigitalFinancialServiceRating> complianceDFS,
            IRepository<TimeSinceLastAuditDigitalFinancialService> timeSinceLastDFSAudit, IRepository<RatedBusinessRiskRating> ratedBusinessRiskRating, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                string requesterName = user.Claims.FirstOrDefault(c => c.Type == "name").Value;
              //  var year = DateTime.Now.Year;
                var getByEmail = armDFS.GetContextByConditon(x => x.RequesterName == requesterName).FirstOrDefault();
                if (getByEmail != null)
                {
                    return TypedResults.Ok($"You have previously submitted a business risk rating for Digital Financial Service for the year {DateTime.Now.Year}");
                }
                var getUser = busnessRiskRating.GetContextByConditon(x => x.RequesterName == requesterName).FirstOrDefault();
                if (getUser != null)
                {
                    var logRequestId = DigitalFinancialServiceBusinessRiskRating.Create(getUser.Id, request.DigitalFinancialServices.Status, requesterName);
                    await armDFS.AddAsync(logRequestId);

                    var logStrategy = StrategyDigitalFinancialService.Create(logRequestId.Id, request.DigitalFinancialServices.Strategy.Comment);
                    await strategy.AddAsync(logStrategy);

                    var strategyDFSLog = StrategyDigitalFinancialServiceRating.Create(logStrategy.Id, request.DigitalFinancialServices);
                    await strategyDFS.AddAsync(strategyDFSLog);

                    var operationLog = OperationDigitalFinancialService.Create(logRequestId.Id, request.DigitalFinancialServices.Operations.Comment);
                    await operation.AddAsync(operationLog);

                    var operDFSLog = OperationDigitalFinancialServiceRating.Create(operationLog.Id, request.DigitalFinancialServices);
                    await operDFS.AddAsync(operDFSLog);

                    var financeLog = FinancialDigitalFinancialService.Create(logRequestId.Id, request.DigitalFinancialServices.FinancialReporting.Comment);
                    await finance.AddAsync(financeLog);

                    var financeTAMLog = FinacialBusinessDigitalFinancialServiceRating.Create(financeLog.Id, request.DigitalFinancialServices);
                    await financeDFS.AddAsync(financeTAMLog);

                    var complianceLog = ComplianceDigitalFinancialService.Create(logRequestId.Id, request.DigitalFinancialServices.Compliance.Comment);
                    await compliance.AddAsync(complianceLog);

                    var complianceDFSLog = ComplianceBusinessDigitalFinancialServiceRating.Create(complianceLog.Id, request.DigitalFinancialServices);
                    await complianceDFS.AddAsync(complianceDFSLog);

                    var timeSinceLastDFSAuditLog = TimeSinceLastAuditDigitalFinancialService.Create(logRequestId.Id, request.DigitalFinancialServices);
                    await timeSinceLastDFSAudit.AddAsync(timeSinceLastDFSAuditLog);

                    var logratedBusinessRiskRating = RatedBusinessRiskRating.Create(getUser.Id, "Digital Financial Service", requesterName, request.DigitalFinancialServices.Status);
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

                    var logRequestId2 = DigitalFinancialServiceBusinessRiskRating.Create(logRequest.Id, request.DigitalFinancialServices.Status, requesterName);
                    await armDFS.AddAsync(logRequestId2);

                    var logStrategy2 = StrategyDigitalFinancialService.Create(logRequestId2.Id, request.DigitalFinancialServices.Strategy.Comment);
                    await strategy.AddAsync(logStrategy2);

                    var strategyDFSLog = StrategyDigitalFinancialServiceRating.Create(logStrategy2.Id, request.DigitalFinancialServices);
                    await strategyDFS.AddAsync(strategyDFSLog);

                    var operationLog2 = OperationDigitalFinancialService.Create(logRequestId2.Id, request.DigitalFinancialServices.Operations.Comment);
                    await operation.AddAsync(operationLog2);

                    var operDFSLog2 = OperationDigitalFinancialServiceRating.Create(operationLog2.Id, request.DigitalFinancialServices);
                    await operDFS.AddAsync(operDFSLog2);

                    var financeLog2 = FinancialDigitalFinancialService.Create(logRequestId2.Id, request.DigitalFinancialServices.FinancialReporting.Comment);
                    await finance.AddAsync(financeLog2);

                    var financeTAMLog2 = FinacialBusinessDigitalFinancialServiceRating.Create(financeLog2.Id, request.DigitalFinancialServices);
                    await financeDFS.AddAsync(financeTAMLog2);

                    var complianceLog2 = ComplianceDigitalFinancialService.Create(logRequestId2.Id, request.DigitalFinancialServices.Compliance.Comment);
                    await compliance.AddAsync(complianceLog2);

                    var complianceDFSLog2 = ComplianceBusinessDigitalFinancialServiceRating.Create(complianceLog2.Id, request.DigitalFinancialServices);
                    await complianceDFS.AddAsync(complianceDFSLog2);

                    var timeSinceLastDFSAuditLog2 = TimeSinceLastAuditDigitalFinancialService.Create(logRequestId2.Id, request.DigitalFinancialServices);
                    await timeSinceLastDFSAudit.AddAsync(timeSinceLastDFSAuditLog2);

                    var logratedBusinessRiskRating2 = RatedBusinessRiskRating.Create(logRequest.Id, "Digital Financial Service", requesterName, request.DigitalFinancialServices.Status);
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
