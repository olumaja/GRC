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
    public class BusinessRiskRatingARMAgribusinessEndpoint
    {
        /// <summary>
        /// Internal Audit officer perform risk rating on the ARMAgribusiness business entities
        /// Persist the rating into the DB
        /// <param name="request"></param>
        /// <param name="request"></param>
        /// <param name="busnessRiskRating"></param>
        /// <param name="agri"></param>
        /// <param name="strategy"></param>
        /// <param name="strategyAAFML"></param>
        /// <param name="strategyRFL"></param>
        /// <param name="operation"></param>
        /// <param name="operationAAFML"></param>
        /// <param name="operRFL"></param>
        /// <param name="finance"></param>
        /// <param name="financeAAFML"></param>
        /// <param name="financeRFL"></param>
        /// <param name="compliance"></param>
        /// <param name="complianceAAFML"></param>
        /// <param name="complianceRFL"></param>
        /// <param name="timeSinceLastAgriAudit"></param>
        /// <param name="ratedBusinessRiskRating"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync([FromBody] ARMAgribusinessRequest request, IRepository<BusinessRiskRating> busnessRiskRating,
            IRepository<ARMAgribusinessRating> agri, IRepository<StrategyAgribusiness> strategy,
            IRepository<StrategyAgribusinessRatingAAFML> strategyAAFML, IRepository<StrategyAgribusinessRatingRFl> strategyRFL,

            IRepository<OperationAgribusiness> operation,
            IRepository<OperationAgribusinessRatingAAFML> operationAAFML, IRepository<OperationAgribusinessRatingRFl> operRFL,

            IRepository<FinancialAgribusinessReporting> finance, IRepository<FinacialAgribusinessRatingAAFML> financeAAFML,
            IRepository<FinacialAgribusinessRatingRFl> financeRFL,

            IRepository<ComplianceAgribusiness> compliance, IRepository<ComplianceAgribusinessRatingAAFML> complianceAAFML,
            IRepository<ComplianceAgribusinessRatingRFl> complianceRFL, IRepository<TimeSinceLastAgribusinessAudit> timeSinceLastAgriAudit,
            IRepository<RatedBusinessRiskRating> ratedBusinessRiskRating, ClaimsPrincipal user, ICurrentUserService currentUserService)

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
                var getByEmail = agri.GetContextByConditon(x => x.RequesterEmail == requesterName).FirstOrDefault();
                if (getByEmail != null)
                {
                    return TypedResults.Ok($"You have previously submitted a business risk rating for ARMAgribusiness for the year {DateTime.Now.Year}");
                }
                var getUser = busnessRiskRating.GetContextByConditon(x => x.RequesterName == requesterName).FirstOrDefault();
                if (getUser != null)
                {
                    var agriLog = ARMAgribusinessRating.Create(getUser.Id, request.ARMAgribusiness.Status, requesterName);
                    await agri.AddAsync(agriLog);

                    var strategyLog = StrategyAgribusiness.Create(agriLog.Id, request.ARMAgribusiness.Strategy.Comment);
                    await strategy.AddAsync(strategyLog);

                    var strategyAAFMLLog = StrategyAgribusinessRatingAAFML.Create(strategyLog.Id, request.ARMAgribusiness);
                    await strategyAAFML.AddAsync(strategyAAFMLLog);

                    var strategyRFLLog = StrategyAgribusinessRatingRFl.Create(strategyLog.Id, request.ARMAgribusiness);
                    await strategyRFL.AddAsync(strategyRFLLog);

                    var operationLog = OperationAgribusiness.Create(agriLog.Id, request.ARMAgribusiness.Operations.Comment);
                    await operation.AddAsync(operationLog);

                    var operationAAFMLLog = OperationAgribusinessRatingAAFML.Create(operationLog.Id, request.ARMAgribusiness);
                    await operationAAFML.AddAsync(operationAAFMLLog);

                    var operRFLLog = OperationAgribusinessRatingRFl.Create(operationLog.Id, request.ARMAgribusiness);
                    await operRFL.AddAsync(operRFLLog);

                    var financeLog = FinancialAgribusinessReporting.Create(agriLog.Id, request.ARMAgribusiness.FinancialReporting.Comment);
                    await finance.AddAsync(financeLog);

                    var financeAAFMLLog = FinacialAgribusinessRatingAAFML.Create(financeLog.Id, request.ARMAgribusiness);
                    await financeAAFML.AddAsync(financeAAFMLLog);

                    var financeRFLLog = FinacialAgribusinessRatingRFl.Create(financeLog.Id, request.ARMAgribusiness);
                    await financeRFL.AddAsync(financeRFLLog);

                    var complianceLog = ComplianceAgribusiness.Create(agriLog.Id, request.ARMAgribusiness.Compliance.Comment);
                    await compliance.AddAsync(complianceLog);

                    var complianceAAFMLLog = ComplianceAgribusinessRatingAAFML.Create(complianceLog.Id, request.ARMAgribusiness);
                    await complianceAAFML.AddAsync(complianceAAFMLLog);

                    var complianceRFLLog = ComplianceAgribusinessRatingRFl.Create(complianceLog.Id, request.ARMAgribusiness);
                    await complianceRFL.AddAsync(complianceRFLLog);

                    var timeSinceLastAgriAuditLog = TimeSinceLastAgribusinessAudit.Create(agriLog.Id, request.ARMAgribusiness);
                    await timeSinceLastAgriAudit.AddAsync(timeSinceLastAgriAuditLog);

                    var logratedBusinessRiskRating = RatedBusinessRiskRating.Create(getUser.Id, "ARMAgribusiness", requesterName, request.ARMAgribusiness.Status);
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

                    var agriLog2 = ARMAgribusinessRating.Create(logRequest.Id, request.ARMAgribusiness.Status, requesterName);
                    await agri.AddAsync(agriLog2);

                    var strategyLog2 = StrategyAgribusiness.Create(agriLog2.Id, request.ARMAgribusiness.Strategy.Comment);
                    await strategy.AddAsync(strategyLog2);

                    var strategyAAFMLLog2 = StrategyAgribusinessRatingAAFML.Create(strategyLog2.Id, request.ARMAgribusiness);
                    await strategyAAFML.AddAsync(strategyAAFMLLog2);

                    var strategyRFLLog2 = StrategyAgribusinessRatingRFl.Create(strategyLog2.Id, request.ARMAgribusiness);
                    await strategyRFL.AddAsync(strategyRFLLog2);

                    var operationLog2 = OperationAgribusiness.Create(agriLog2.Id, request.ARMAgribusiness.Operations.Comment);
                    await operation.AddAsync(operationLog2);

                    var operationAAFMLLog2 = OperationAgribusinessRatingAAFML.Create(operationLog2.Id, request.ARMAgribusiness);
                    await operationAAFML.AddAsync(operationAAFMLLog2);

                    var operRFLLog2 = OperationAgribusinessRatingRFl.Create(operationLog2.Id, request.ARMAgribusiness);
                    await operRFL.AddAsync(operRFLLog2);

                    var financeLog2 = FinancialAgribusinessReporting.Create(agriLog2.Id, request.ARMAgribusiness.FinancialReporting.Comment);
                    await finance.AddAsync(financeLog2);

                    var financeAAFMLLog2 = FinacialAgribusinessRatingAAFML.Create(financeLog2.Id, request.ARMAgribusiness);
                    await financeAAFML.AddAsync(financeAAFMLLog2);

                    var financeRFLLog2 = FinacialAgribusinessRatingRFl.Create(financeLog2.Id, request.ARMAgribusiness);
                    await financeRFL.AddAsync(financeRFLLog2);

                    var complianceLog2 = ComplianceAgribusiness.Create(agriLog2.Id, request.ARMAgribusiness.Compliance.Comment);
                    await compliance.AddAsync(complianceLog2);

                    var complianceAAFMLLog2 = ComplianceAgribusinessRatingAAFML.Create(complianceLog2.Id, request.ARMAgribusiness);
                    await complianceAAFML.AddAsync(complianceAAFMLLog2);

                    var complianceRFLLog2 = ComplianceAgribusinessRatingRFl.Create(complianceLog2.Id, request.ARMAgribusiness);
                    await complianceRFL.AddAsync(complianceRFLLog2);

                    var timeSinceLastAgriAuditLog2 = TimeSinceLastAgribusinessAudit.Create(agriLog2.Id, request.ARMAgribusiness);
                    await timeSinceLastAgriAudit.AddAsync(timeSinceLastAgriAuditLog2);

                    var logratedBusinessRiskRating2 = RatedBusinessRiskRating.Create(logRequest.Id, "ARMAgribusiness", requesterName, request.ARMAgribusiness.Status);
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
