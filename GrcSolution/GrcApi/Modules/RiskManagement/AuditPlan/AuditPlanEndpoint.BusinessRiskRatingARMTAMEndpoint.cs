using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using Azure;
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
    public class BusinessRiskRatingARMTAMEndpoint
    {
        /// <summary>
        /// Internal Audit officer perform risk rating on the ARMTAM business entities
        /// Persist the rating into the DB
        /// </summary>
        /// <param name="request"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="armTAM"></param>
        /// <param name="strategy"></param>
        /// <param name="strategyTAM"></param>
        /// <param name="operation"></param>
        /// <param name="operTAM"></param>
        /// <param name="finance"></param>
        /// <param name="financeTAM"></param>
        /// <param name="compliance"></param>
        /// <param name="complianceTAM"></param>
        /// <param name="timeSinceLastARMTAMAudit"></param>
        /// <param name="ratedBusinessRiskRating"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] ARMTAMRequest request, IRepository<BusinessRiskRating> busnessRiskRating,
            IRepository<ARMTAMBusinessRiskRating> armTAM, IRepository<StrategyBusinessARMTAM> strategy, IRepository<StrategyBusinessTAMRating> strategyTAM,

            IRepository<OperationBusinessARMTAM> operation, IRepository<OperationBusinessTAMRating> operTAM,

            IRepository<FinancialBusinessARMTAM> finance, IRepository<FinacialBusinessTAMRating> financeTAM, IRepository<ComplianceBusinessARMTAM> compliance,

            IRepository<ComplianceBusinessTAMRating> complianceTAM, IRepository<TimeSinceLastBusinessARMTAMAudit> timeSinceLastARMTAMAudit,
            IRepository<RatedBusinessRiskRating> ratedBusinessRiskRating, ClaimsPrincipal user, ICurrentUserService currentUserService
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
                var getByEmail = armTAM.GetContextByConditon(x => x.RequesterName == requesterName).FirstOrDefault();
                if (getByEmail != null)
                {
                    return TypedResults.Ok($"You have previously submitted a business risk rating for ARMTAM for the year {DateTime.Now.Year}");
                }
                var getUser = busnessRiskRating.GetContextByConditon(x => x.RequesterName == requesterName).FirstOrDefault();
                if (getUser != null)
                {
                    var logRequestId = ARMTAMBusinessRiskRating.Create(getUser.Id, request.ARMTAM.Status, requesterName);
                    await armTAM.AddAsync(logRequestId);

                    var logStrategy = StrategyBusinessARMTAM.Create(logRequestId.Id, request.ARMTAM.Strategy.Comment);
                    await strategy.AddAsync(logStrategy);

                    var strategyTAMLog = StrategyBusinessTAMRating.Create(logStrategy.Id, request.ARMTAM);
                    await strategyTAM.AddAsync(strategyTAMLog);

                    var operationLog = OperationBusinessARMTAM.Create(logRequestId.Id, request.ARMTAM.Operations.Comment);
                    await operation.AddAsync(operationLog);

                    var operTAMLog = OperationBusinessTAMRating.Create(operationLog.Id, request.ARMTAM);
                    await operTAM.AddAsync(operTAMLog);

                    var financeLog = FinancialBusinessARMTAM.Create(logRequestId.Id, request.ARMTAM.FinancialReporting.Comment);
                    await finance.AddAsync(financeLog);

                    var financeTAMLog = FinacialBusinessTAMRating.Create(financeLog.Id, request.ARMTAM);
                    await financeTAM.AddAsync(financeTAMLog);

                    var complianceLog = ComplianceBusinessARMTAM.Create(logRequestId.Id, request.ARMTAM.Compliance.Comment);
                    await compliance.AddAsync(complianceLog);

                    var complianceTAMLog = ComplianceBusinessTAMRating.Create(complianceLog.Id, request.ARMTAM);
                    await complianceTAM.AddAsync(complianceTAMLog);

                    var timeSinceLastARMTAMAuditLog = TimeSinceLastBusinessARMTAMAudit.Create(logRequestId.Id, request.ARMTAM);
                    await timeSinceLastARMTAMAudit.AddAsync(timeSinceLastARMTAMAuditLog);

                    var logratedBusinessRiskRating = RatedBusinessRiskRating.Create(getUser.Id, "ARMTAM", requesterName, request.ARMTAM.Status);
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

                    var logRequestId = ARMTAMBusinessRiskRating.Create(logRequest.Id, request.ARMTAM.Status, requesterName);
                    await armTAM.AddAsync(logRequestId);

                    var logStrategy2 = StrategyBusinessARMTAM.Create(logRequestId.Id, request.ARMTAM.Strategy.Comment);
                    await strategy.AddAsync(logStrategy2);

                    var strategyTAMLog2 = StrategyBusinessTAMRating.Create(logStrategy2.Id, request.ARMTAM);
                    await strategyTAM.AddAsync(strategyTAMLog2);

                    var operationLog2 = OperationBusinessARMTAM.Create(logRequestId.Id, request.ARMTAM.Operations.Comment);
                    await operation.AddAsync(operationLog2);

                    var operTAMLog2 = OperationBusinessTAMRating.Create(operationLog2.Id, request.ARMTAM);
                    await operTAM.AddAsync(operTAMLog2);

                    var financeLog2 = FinancialBusinessARMTAM.Create(logRequestId.Id, request.ARMTAM.FinancialReporting.Comment);
                    await finance.AddAsync(financeLog2);

                    var financeTAMLog2 = FinacialBusinessTAMRating.Create(financeLog2.Id, request.ARMTAM);
                    await financeTAM.AddAsync(financeTAMLog2);

                    var complianceLog2 = ComplianceBusinessARMTAM.Create(logRequestId.Id, request.ARMTAM.Compliance.Comment);
                    await compliance.AddAsync(complianceLog2);

                    var complianceTAMLog2 = ComplianceBusinessTAMRating.Create(complianceLog2.Id, request.ARMTAM);
                    await complianceTAM.AddAsync(complianceTAMLog2);

                    var timeSinceLastARMTAMAuditLog2 = TimeSinceLastBusinessARMTAMAudit.Create(logRequestId.Id, request.ARMTAM);
                    await timeSinceLastARMTAMAudit.AddAsync(timeSinceLastARMTAMAuditLog2);

                    var logratedBusinessRiskRating2 = RatedBusinessRiskRating.Create(logRequest.Id, "ARMTAM", requesterName, request.ARMTAM.Status);
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
