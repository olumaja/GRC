using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.RiskManagement.SeedGuids;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
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
    public class BusinessRiskRatingARMTrusteeEndpoint
    {
        /// <summary>
        /// Internal Audit officer perform risk rating on the ARMTrustee business entities
        /// Persist the rating into the DB
        /// </summary>
        /// <param name="request"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="trustee"></param>
        /// <param name="strategy"></param>
        /// <param name="straCommercialTru"></param>
        /// <param name="straPrivate"></param>
        /// <param name="operation"></param>
        /// <param name="operCommercialtrus"></param>
        /// <param name="operationPrivateTru"></param>
        /// <param name="finance"></param>
        /// <param name="financePrivate"></param>
        /// <param name="financecommercialTru"></param>
        /// <param name="compliance"></param>
        /// <param name="complianceComercial"></param>
        /// <param name="compliancePrivate"></param>
        /// <param name="timeSinceLastTrusteeAudit"></param>
        /// <param name="ratedBusinessRiskRating"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] ARMTrusteeRequest request, IRepository<BusinessRiskRating> busnessRiskRating,
            IRepository<ARMTrusteeRating> trustee, IRepository<StrategyBusinessRatingTrustee> strategy,
            IRepository<StrategyTrusteeRatingCommercialTrust> straCommercialTru, IRepository<StrategyTrusteeRatingPrivateTrust> straPrivate,

            IRepository<OperationTrustee> operation, IRepository<OperationTrusteeRatingCommercialTrust> operCommercialtrus,
            IRepository<OperationTrusteeRatingPrivateTrust> operationPrivateTru,

            IRepository<FinancialTrusteeReporting> finance,
            IRepository<FinacialTrusteeRatingPrivateTrust> financePrivate, IRepository<FinacialTrusteeRatingCommercialTrust> financecommercialTru,

            IRepository<ComplianceBusinessRatingTrustee> compliance,
            IRepository<ComplianceTrusteeRatingCommercialTrust> complianceComercial, IRepository<ComplianceTrusteeRatingPrivateTrust> compliancePrivate,
            IRepository<TimeSinceLastTrusteeAudit> timeSinceLastTrusteeAudit, IRepository<RatedBusinessRiskRating> ratedBusinessRiskRating,
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
                var getByEmail = trustee.GetContextByConditon(x => x.RequesterName == requesterName).FirstOrDefault();
                if (getByEmail != null)
                {
                    return TypedResults.Ok($"You have previously submitted a business risk rating for ARMTrustee for the year {DateTime.Now.Year}");
                }
                var getUser = busnessRiskRating.GetContextByConditon(x => x.RequesterName == requesterName).FirstOrDefault();
                if (getUser != null)
                {
                    var trusteeLog = ARMTrusteeRating.Create(getUser.Id, request.ARMTrustee.Status, requesterName);
                    await trustee.AddAsync(trusteeLog);

                    var strategyLog = StrategyBusinessRatingTrustee.Create(trusteeLog.Id, request.ARMTrustee.Strategy.Comment);
                    await strategy.AddAsync(strategyLog);

                    var straCommercialTruLog = StrategyTrusteeRatingCommercialTrust.Create(strategyLog.Id, request.ARMTrustee);
                    await straCommercialTru.AddAsync(straCommercialTruLog);

                    var straPrivateLog = StrategyTrusteeRatingPrivateTrust.Create(strategyLog.Id, request.ARMTrustee);
                    await straPrivate.AddAsync(straPrivateLog);

                    var operationLog = OperationTrustee.Create(trusteeLog.Id, request.ARMTrustee.Operations.Comment);
                    await operation.AddAsync(operationLog);

                    var operCommercialtrusLog = OperationTrusteeRatingCommercialTrust.Create(operationLog.Id, request.ARMTrustee);
                    await operCommercialtrus.AddAsync(operCommercialtrusLog);

                    var operationPrivateTruLog = OperationTrusteeRatingPrivateTrust.Create(operationLog.Id, request.ARMTrustee);
                    await operationPrivateTru.AddAsync(operationPrivateTruLog);

                    var financeLog = FinancialTrusteeReporting.Create(trusteeLog.Id, request.ARMTrustee.FinancialReporting.Comment);
                    await finance.AddAsync(financeLog);

                    var financePrivateLog = FinacialTrusteeRatingPrivateTrust.Create(financeLog.Id, request.ARMTrustee);
                    await financePrivate.AddAsync(financePrivateLog);

                    var financecommercialTruLog = FinacialTrusteeRatingCommercialTrust.Create(financeLog.Id, request.ARMTrustee);
                    await financecommercialTru.AddAsync(financecommercialTruLog);

                    var complianceLog = ComplianceBusinessRatingTrustee.Create(trusteeLog.Id, request.ARMTrustee.Compliance.Comment);
                    await compliance.AddAsync(complianceLog);

                    var complianceComercialLog = ComplianceTrusteeRatingCommercialTrust.Create(complianceLog.Id, request.ARMTrustee);
                    await complianceComercial.AddAsync(complianceComercialLog);

                    var compliancePrivateLog = ComplianceTrusteeRatingPrivateTrust.Create(complianceLog.Id, request.ARMTrustee);
                    await compliancePrivate.AddAsync(compliancePrivateLog);

                    var timeSinceLastTrusteeAuditLog = TimeSinceLastTrusteeAudit.Create(trusteeLog.Id, request.ARMTrustee);
                    await timeSinceLastTrusteeAudit.AddAsync(timeSinceLastTrusteeAuditLog);

                    var logratedBusinessRiskRating = RatedBusinessRiskRating.Create(getUser.Id, "ARMTrustee", requesterName, request.ARMTrustee.Status);
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

                    var trusteeLog2 = ARMTrusteeRating.Create(logRequest.Id, request.ARMTrustee.Status, requesterName);
                    await trustee.AddAsync(trusteeLog2);

                    var strategyLog2 = StrategyBusinessRatingTrustee.Create(trusteeLog2.Id, request.ARMTrustee.Strategy.Comment);
                    await strategy.AddAsync(strategyLog2);

                    var straCommercialTruLog2 = StrategyTrusteeRatingCommercialTrust.Create(strategyLog2.Id, request.ARMTrustee);
                    await straCommercialTru.AddAsync(straCommercialTruLog2);

                    var straPrivateLog2 = StrategyTrusteeRatingPrivateTrust.Create(strategyLog2.Id, request.ARMTrustee);
                    await straPrivate.AddAsync(straPrivateLog2);

                    var operationLog2 = OperationTrustee.Create(trusteeLog2.Id, request.ARMTrustee.Operations.Comment);
                    await operation.AddAsync(operationLog2);

                    var operCommercialtrusLog2 = OperationTrusteeRatingCommercialTrust.Create(operationLog2.Id, request.ARMTrustee);
                    await operCommercialtrus.AddAsync(operCommercialtrusLog2);

                    var operationPrivateTruLog2 = OperationTrusteeRatingPrivateTrust.Create(operationLog2.Id, request.ARMTrustee);
                    await operationPrivateTru.AddAsync(operationPrivateTruLog2);

                    var financeLog2 = FinancialTrusteeReporting.Create(trusteeLog2.Id, request.ARMTrustee.FinancialReporting.Comment);
                    await finance.AddAsync(financeLog2);

                    var financePrivateLog2 = FinacialTrusteeRatingPrivateTrust.Create(financeLog2.Id, request.ARMTrustee);
                    await financePrivate.AddAsync(financePrivateLog2);

                    var financecommercialTruLog2 = FinacialTrusteeRatingCommercialTrust.Create(financeLog2.Id, request.ARMTrustee);
                    await financecommercialTru.AddAsync(financecommercialTruLog2);

                    var complianceLog2 = ComplianceBusinessRatingTrustee.Create(trusteeLog2.Id, request.ARMTrustee.Compliance.Comment);
                    await compliance.AddAsync(complianceLog2);

                    var complianceComercialLog2 = ComplianceTrusteeRatingCommercialTrust.Create(complianceLog2.Id, request.ARMTrustee);
                    await complianceComercial.AddAsync(complianceComercialLog2);

                    var compliancePrivateLog2 = ComplianceTrusteeRatingPrivateTrust.Create(complianceLog2.Id, request.ARMTrustee);
                    await compliancePrivate.AddAsync(compliancePrivateLog2);

                    var timeSinceLastTrusteeAuditLog2 = TimeSinceLastTrusteeAudit.Create(trusteeLog2.Id, request.ARMTrustee);
                    await timeSinceLastTrusteeAudit.AddAsync(timeSinceLastTrusteeAuditLog2);
                    // await timeSinceLastTrusteeAudit.SaveChangesAsync();

                    var logratedBusinessRiskRating2 = RatedBusinessRiskRating.Create(logRequest.Id, "ARMTrustee", requesterName, request.ARMTrustee.Status);
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
