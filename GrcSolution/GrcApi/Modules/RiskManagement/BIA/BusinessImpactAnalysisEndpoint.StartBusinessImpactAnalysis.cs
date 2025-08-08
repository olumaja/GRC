using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.BIA
{
    public class StartBusinessImpactAnalysisEndpoint
    {
        public static async Task<IResult> HandleAsync(
            [FromBody] StartBIADto StartBIADto, IRepository<BusinessImpactAnalysis> businessImpactAnalysisRepository, IRepository<Unit> unitRepo, 
            IConfiguration config, Serilog.ILogger logger, IEmailService EmailService, ClaimsPrincipal user, ICurrentUserService currentUserService
        )
        {
            try
            {
                List<string> errorResponse = new();
                if (StartBIADto.BusinessImpactAnalysisUnits == null || StartBIADto.BusinessImpactAnalysisUnits.Count == 0)
                {
                    errorResponse.Add("Invalid units");
                    return TypedResults.BadRequest(errorResponse);
                }

                #region Validate Units
                HashSet<Guid> businessImpactAnalysisUnits = StartBIADto.BusinessImpactAnalysisUnits.Select(u => u.UnitId).ToHashSet();

                var allUnits = unitRepo.GetContextByConditon(u => businessImpactAnalysisUnits.Contains(u.Id)).Select(u => u.Id).ToHashSet();

                List<Guid> notFound = businessImpactAnalysisUnits.Except(allUnits).ToList();
                if (notFound.Count > 0)
                {
                    notFound.ForEach(u => errorResponse.Add($"Invalid unitId, {u}"));
                    return TypedResults.BadRequest(errorResponse);
                }
                #endregion

                //create bia
                List<BusinessImpactAnalysisUnit> units = StartBIADto.BusinessImpactAnalysisUnits
                    .Select(u => BusinessImpactAnalysisUnit
                    .Create(u.UnitId)).ToList();

                BusinessImpactAnalysis bia = BusinessImpactAnalysis.Create(
                    StartBIADto.PeriodFrom,
                    StartBIADto.PeriodTo,
                    StartBIADto.StartDate,
                    StartBIADto.EndDate,
                    units);

                businessImpactAnalysisRepository.Add(bia);

                StartBIAResponseDto result = new(bia.Id, new List<BIAUnitDto>(units.Select(u => new BIAUnitDto(u.Id))));

                await businessImpactAnalysisRepository.SaveChangesAsync();

                #region Log email request
                DateTime dateOfOccurrence = DateTime.Now;
                string subject = $"New BIA Exercise";                              
                string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string emailTo =  config["EmailConfiguration:RiskMgtUnit"];
                string toCC = config["EmailConfiguration:toCC"];
                string body = $"Hello all, <br> The BIA exercise has begun, and you have been mandated to initiate all BIA activities as your unit’s Risk Champion. <br><ul><li>BIA Period Covered: {StartBIADto.PeriodFrom} - {StartBIADto.PeriodTo}</li><li>BIA Exercise Timeline: {StartBIADto.StartDate} - {StartBIADto.EndDate}</li></ul> <br>. Kindly login to the GRC Tool to initiate the BIA exercise: <br><a href={linkToGRCTool}>GRC link</a>.";
                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.RiskManagement, bia.Id, emailTo, toCC);
                if (logEmailRequest == false)
                {
                    return TypedResults.Ok($"BIA Started successfully with bia ID: {bia.Id}, {result},  but email message was not logged");
                }
                #endregion

                return TypedResults.Created($"bia/{bia.Id}", result);
            }
            catch(Exception ex)
            {
                logger.Error(ex, ex.Message);
                return TypedResults.BadRequest("Unable to submit the request");
            }
            
        }
    }
}
