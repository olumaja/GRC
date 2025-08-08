using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.RiskManagement.BIA;
using Arm.GrcApi.Modules.RiskManagement.PRA;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using Azure;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 27/02/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* This endpoint allow Internal Audit officer perform risk rating on the business entities
*/
    public class BusinessRiskRatingARMHoldingCompanyEndpoint
    {
        /// <summary>
        /// Internal Audit officer perform risk rating on the ARMHoldingcompany business entities
        /// Persist the rating into the DB
        /// </summary>
        /// <param name="request"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="armHoldcorating"></param>
        /// <param name="strategylog"></param>
        /// <param name="strategyrating"></param>
        /// <param name="strategytreasurysale"></param>
        /// <param name="operationlog"></param>
        /// <param name="operationrating"></param>
        /// <param name="operationtreasurysale"></param>
        /// <param name="financelog"></param>
        /// <param name="financerating"></param>
        /// <param name="financeTreasurysale"></param>
        /// <param name="complianceRating"></param>
        /// <param name="compliancelog"></param>
        /// <param name="complianceTreasurysale"></param>
        /// <param name="timesinceaudit"></param>
        /// <param name="ratedBusinessRiskRating"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] ARMHoldingCompanyRequest request, IRepository<BusinessRiskRating> busnessRiskRating,
            IRepository<ARMHoldingCompanyBusinessRating> armHoldcorating, IRepository<StrategyBusinessRatingARMHoldCo> strategylog, IRepository<StrategyBusinessArmHoldCo> strategyrating,
            IRepository<StrategyBusinessTreasurySale> strategytreasurysale, IRepository<OperationBusinessRatingARMHoldCo> operationlog, IRepository<OperationBusinessArmHolco> operationrating,
            IRepository<OperationBusinessTreasurySale> operationtreasurysale, IRepository<FinancialReportingBusinessratingARMHoldCo> financelog,
            IRepository<FinacialRatingBusinessratingARMHoldCo> financerating, IRepository<FinacialRatingBusinessratingTreasurySale> financeTreasurysale,
            IRepository<ComplianceBusinessRatingARMHoldCo> complianceRating, IRepository<CompliancesBusinessRiskRatingARMHoldCo> compliancelog,
            IRepository<CompliancesBusinessTreasurySale> complianceTreasurysale,
            IRepository<TimeSinceLastAuditBusinessRatingARMHoldCo> timesinceaudit, IRepository<RatedBusinessRiskRating> ratedBusinessRiskRating,
            ClaimsPrincipal user, ICurrentUserService currentUserService
        )
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
                var getByEmail = armHoldcorating.GetContextByConditon(x => x.RequesterName == requesterName).FirstOrDefault();
                if (getByEmail != null)
                {
                    return TypedResults.Ok($"You have previously submitted a business risk rating for ARM Holding Company for the year {DateTime.Now.Year}");
                }

                var getUser = busnessRiskRating.GetContextByConditon(x => x.RequesterName == requesterName).FirstOrDefault();
                if (getUser != null)
                {

                    var logRequestId = ARMHoldingCompanyBusinessRating.Create(getUser.Id, request.ARMHoldingCompany.Status, requesterName);
                    await armHoldcorating.AddAsync(logRequestId);

                    var logStrategy = StrategyBusinessRatingARMHoldCo.Create(logRequestId.Id, request.ARMHoldingCompany.Strategy.Comment);
                    await strategylog.AddAsync(logStrategy);

                    var startegyratingarmholdco = StrategyBusinessArmHoldCo.Create(logStrategy.Id, request.ARMHoldingCompany);
                    await strategyrating.AddAsync(startegyratingarmholdco);

                    var startegyTreasury = StrategyBusinessTreasurySale.Create(logStrategy.Id, request.ARMHoldingCompany);
                    await strategytreasurysale.AddAsync(startegyTreasury);

                    var logoperation = OperationBusinessRatingARMHoldCo.Create(logRequestId.Id, request.ARMHoldingCompany.Operations.Comment);
                    await operationlog.AddAsync(logoperation);

                    var operationratinglog = OperationBusinessArmHolco.Create(logoperation.Id, request.ARMHoldingCompany);
                    await operationrating.AddAsync(operationratinglog);

                    var operationTreasurylog = OperationBusinessTreasurySale.Create(logoperation.Id, request.ARMHoldingCompany);
                    await operationtreasurysale.AddAsync(operationTreasurylog);

                    var logFinancialReport = FinancialReportingBusinessratingARMHoldCo.Create(logRequestId.Id, request.ARMHoldingCompany.FinancialReporting.Comment);
                    await financelog.AddAsync(logFinancialReport);

                    var financialtinglog = FinacialRatingBusinessratingARMHoldCo.Create(logFinancialReport.Id, request.ARMHoldingCompany);
                    await financerating.AddAsync(financialtinglog);

                    var financialtreasurysalelog = FinacialRatingBusinessratingTreasurySale.Create(logFinancialReport.Id, request.ARMHoldingCompany);
                    await financeTreasurysale.AddAsync(financialtreasurysalelog);

                    var logCompliance = ComplianceBusinessRatingARMHoldCo.Create(logRequestId.Id, request.ARMHoldingCompany.FinancialReporting.Comment);
                    await complianceRating.AddAsync(logCompliance);

                    var complianceRatinglog = CompliancesBusinessRiskRatingARMHoldCo.Create(logCompliance.Id, request.ARMHoldingCompany);
                    await compliancelog.AddAsync(complianceRatinglog);

                    var complianceTreasurysaleLog = CompliancesBusinessTreasurySale.Create(logCompliance.Id, request.ARMHoldingCompany);
                    await complianceTreasurysale.AddAsync(complianceTreasurysaleLog);

                    var timesinceauditRating = TimeSinceLastAuditBusinessRatingARMHoldCo.Create(logRequestId.Id, request.ARMHoldingCompany);
                    await timesinceaudit.AddAsync(timesinceauditRating);

                    var logratedBusinessRiskRating = RatedBusinessRiskRating.Create(getUser.Id, "ARMHoldingCompany", requesterName, request.ARMHoldingCompany.Status);
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
                    busnessRiskRating.AddAsync(logRequest);

                    var logRequestId2 = ARMHoldingCompanyBusinessRating.Create(logRequest.Id, request.ARMHoldingCompany.Status, requesterName);
                    await armHoldcorating.AddAsync(logRequestId2);

                    var logStrategy2 = StrategyBusinessRatingARMHoldCo.Create(logRequestId2.Id, request.ARMHoldingCompany.Strategy.Comment);
                    await strategylog.AddAsync(logStrategy2);

                    var startegyratingarmholdco2 = StrategyBusinessArmHoldCo.Create(logStrategy2.Id, request.ARMHoldingCompany);
                    await strategyrating.AddAsync(startegyratingarmholdco2);

                    var startegyTreasury2 = StrategyBusinessTreasurySale.Create(logStrategy2.Id, request.ARMHoldingCompany);
                    await strategytreasurysale.AddAsync(startegyTreasury2);

                    var logoperation2 = OperationBusinessRatingARMHoldCo.Create(logRequestId2.Id, request.ARMHoldingCompany.Operations.Comment);
                    await operationlog.AddAsync(logoperation2);

                    var operationratinglog2 = OperationBusinessArmHolco.Create(logoperation2.Id, request.ARMHoldingCompany);
                    await operationrating.AddAsync(operationratinglog2);

                    var operationTreasurylog2 = OperationBusinessTreasurySale.Create(logoperation2.Id, request.ARMHoldingCompany);
                    await operationtreasurysale.AddAsync(operationTreasurylog2);

                    var logFinancialReport2 = FinancialReportingBusinessratingARMHoldCo.Create(logRequestId2.Id, request.ARMHoldingCompany.FinancialReporting.Comment);
                    await financelog.AddAsync(logFinancialReport2);

                    var financialtinglog2 = FinacialRatingBusinessratingARMHoldCo.Create(logFinancialReport2.Id, request.ARMHoldingCompany);
                    await financerating.AddAsync(financialtinglog2);

                    var financialtreasurysalelog2 = FinacialRatingBusinessratingTreasurySale.Create(logFinancialReport2.Id, request.ARMHoldingCompany);
                    await financeTreasurysale.AddAsync(financialtreasurysalelog2);

                    var logCompliance2 = ComplianceBusinessRatingARMHoldCo.Create(logRequestId2.Id, request.ARMHoldingCompany.FinancialReporting.Comment);
                    await complianceRating.AddAsync(logCompliance2);

                    var complianceRatinglog2 = CompliancesBusinessRiskRatingARMHoldCo.Create(logCompliance2.Id, request.ARMHoldingCompany);
                    await compliancelog.AddAsync(complianceRatinglog2);

                    var complianceTreasurysaleLog2 = CompliancesBusinessTreasurySale.Create(logCompliance2.Id, request.ARMHoldingCompany);
                    await complianceTreasurysale.AddAsync(complianceTreasurysaleLog2);

                    var timesinceauditRating2 = TimeSinceLastAuditBusinessRatingARMHoldCo.Create(logRequestId2.Id, request.ARMHoldingCompany);
                    await timesinceaudit.AddAsync(timesinceauditRating2);

                    var logratedBusinessRiskRating2 = RatedBusinessRiskRating.Create(logRequest.Id, "ARMHoldingCompany", requesterName, request.ARMHoldingCompany.Status);
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
