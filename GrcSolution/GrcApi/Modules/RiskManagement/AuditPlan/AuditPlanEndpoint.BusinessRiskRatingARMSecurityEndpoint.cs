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
    public class BusinessRiskRatingARMSecurityEndpoint
    {
        /// <summary>
        /// Internal Audit officer perform risk rating on the ARMSecurity business entities
        /// Persist the rating into the DB
        /// </summary>
        /// <param name="request"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="security"></param>
        /// <param name="strategy"></param>
        /// <param name="strategyStockBro"></param>
        /// <param name="operation"></param>
        /// <param name="operStockBro"></param>
        /// <param name="finance"></param>
        /// <param name="financeStockbro"></param>
        /// <param name="compliance"></param>
        /// <param name="compliancestockbro"></param>
        /// <param name="timeSinceLastSecurityAudit"></param>
        /// <param name="ratedBusinessRiskRating"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] ARMSecurityRequest request, IRepository<BusinessRiskRating> busnessRiskRating,
            IRepository<ARMSecurityRating> security, IRepository<StrategySecurityBusinessRating> strategy, 
            IRepository<StrategySecurityRatingStockBroking> strategyStockBro, 

            IRepository<OperationSecurityBusinessRating> operation, IRepository<OperationSecurityRatingStockBroking> operStockBro,

            IRepository<FinancialSecurityReporting> finance, IRepository<FinacialSecurityRatingStockBroking> financeStockbro, 

            IRepository<ComplianceSecurity> compliance, IRepository<ComplianceSecurityRatingStockBroking> compliancestockbro, 
            IRepository<TimeSinceLastSecurityAudit> timeSinceLastSecurityAudit, IRepository<RatedBusinessRiskRating> ratedBusinessRiskRating,
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
                var getByEmail = security.GetContextByConditon(x => x.RequesterName == requesterName).FirstOrDefault();
                if (getByEmail != null)
                {
                    return TypedResults.Ok($"You have previously submitted a business risk rating for ARMSecurity for the year {DateTime.Now.Year}");
                }
                var getUser = busnessRiskRating.GetContextByConditon(x => x.RequesterName == requesterName).FirstOrDefault();
                if (getUser != null)
                {

                    var securityLog = ARMSecurityRating.Create(getUser.Id, request.ARMSecurity.Status, requesterName);
                    await security.AddAsync(securityLog);

                    var strategyLog = StrategySecurityBusinessRating.Create(securityLog.Id, request.ARMSecurity.Strategy.Comment);
                    await strategy.AddAsync(strategyLog);
                                      
                    var strategyStockBroLog = StrategySecurityRatingStockBroking.Create(strategyLog.Id, request.ARMSecurity);
                    await strategyStockBro.AddAsync(strategyStockBroLog);
                                       
                    var operationLog = OperationSecurityBusinessRating.Create(securityLog.Id, request.ARMSecurity.Operations.Comment);
                    await operation.AddAsync(operationLog);                                     

                    var operStockBroLog = OperationSecurityRatingStockBroking.Create(operationLog.Id, request.ARMSecurity);
                    await operStockBro.AddAsync(operStockBroLog);

                    var financeLog = FinancialSecurityReporting.Create(securityLog.Id, request.ARMSecurity.FinancialReporting.Comment);
                    await finance.AddAsync(financeLog);

                    var financeStockbroLog = FinacialSecurityRatingStockBroking.Create(financeLog.Id, request.ARMSecurity);
                    await financeStockbro.AddAsync(financeStockbroLog);

                    var complianceLog = ComplianceSecurity.Create(securityLog.Id, request.ARMSecurity.Compliance.Comment);
                    await compliance.AddAsync(complianceLog);

                    var compliancestockbroLog = ComplianceSecurityRatingStockBroking.Create(complianceLog.Id, request.ARMSecurity);
                    await compliancestockbro.AddAsync(compliancestockbroLog);

                    var timeSinceLastSecurityAuditLog = TimeSinceLastSecurityAudit.Create(securityLog.Id, request.ARMSecurity);
                    await timeSinceLastSecurityAudit.AddAsync(timeSinceLastSecurityAuditLog);

                    var logratedBusinessRiskRating = RatedBusinessRiskRating.Create(getUser.Id, "ARMSecurity", requesterName, request.ARMSecurity.Status);
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

                    var securityLog2 = ARMSecurityRating.Create(logRequest.Id, request.ARMSecurity.Status, requesterName);
                    await security.AddAsync(securityLog2);

                    var strategyLog2 = StrategySecurityBusinessRating.Create(securityLog2.Id, request.ARMSecurity.Strategy.Comment);
                    await strategy.AddAsync(strategyLog2);

                    var strategyStockBroLog2 = StrategySecurityRatingStockBroking.Create(strategyLog2.Id, request.ARMSecurity);
                    await strategyStockBro.AddAsync(strategyStockBroLog2);

                    var operationLog2 = OperationSecurityBusinessRating.Create(securityLog2.Id, request.ARMSecurity.Operations.Comment);
                    await operation.AddAsync(operationLog2);

                    var operStockBroLog2 = OperationSecurityRatingStockBroking.Create(operationLog2.Id, request.ARMSecurity);
                    await operStockBro.AddAsync(operStockBroLog2);

                    var financeLog2 = FinancialSecurityReporting.Create(securityLog2.Id, request.ARMSecurity.FinancialReporting.Comment);
                    await finance.AddAsync(financeLog2);

                    var financeStockbroLog2 = FinacialSecurityRatingStockBroking.Create(financeLog2.Id, request.ARMSecurity);
                    await financeStockbro.AddAsync(financeStockbroLog2);
                                     
                    var complianceLog2 = ComplianceSecurity.Create(securityLog2.Id, request.ARMSecurity.Compliance.Comment);
                    await compliance.AddAsync(complianceLog2);

                    var compliancestockbroLog2 = ComplianceSecurityRatingStockBroking.Create(complianceLog2.Id, request.ARMSecurity);
                    await compliancestockbro.AddAsync(compliancestockbroLog2);


                    var timeSinceLastSecurityAuditLog2 = TimeSinceLastSecurityAudit.Create(securityLog2.Id, request.ARMSecurity);
                    await timeSinceLastSecurityAudit.AddAsync(timeSinceLastSecurityAuditLog2);

                    var logratedBusinessRiskRating2 = RatedBusinessRiskRating.Create(logRequest.Id, "ARMSecurity", requesterName, request.ARMSecurity.Status);
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
