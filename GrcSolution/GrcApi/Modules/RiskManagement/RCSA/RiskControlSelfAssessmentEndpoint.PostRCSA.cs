using Arm.GrcApi.Modules.RiskManagement.BIA;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.RCSA
{
    public class RiskControlSelfAssessmentEndpointPostRCSA
    {
        public static async Task<IResult> HandleAsync([FromBody] CreateRiskControlSelfAssessmentDto CreateRiskControlSelfAssessmentDto, ICurrentUserService currentUserService,
            IRepository<RiskControlSelfAssessment> rcsaRepository, IEmailService EmailService, IConfiguration config, ClaimsPrincipal user
        )
        {
            try
            {
                if (CreateRiskControlSelfAssessmentDto.RiskControlSelfAssessmentUnits == null || CreateRiskControlSelfAssessmentDto.RiskControlSelfAssessmentUnits.Count == 0)
                {
                    List<string> response = new List<string> { "Invalid units" };
                    return TypedResults.BadRequest(response);
                }
                //create rcsa
                List<RiskControlSelfAssessmentUnit> units = CreateRiskControlSelfAssessmentDto.RiskControlSelfAssessmentUnits
                    .Select(u => RiskControlSelfAssessmentUnit
                    .Create(unitId: u.UnitId, documentRSCAProcess: DocumentRSCAProcess.Create(DocumentRSCAProcess.Stage.RiskChampionInitiateRCSA))).ToList();

                RiskControlSelfAssessment rcsa = RiskControlSelfAssessment.Create(
                    DateOnly.FromDateTime(CreateRiskControlSelfAssessmentDto.PeriodFrom),
                    DateOnly.FromDateTime(CreateRiskControlSelfAssessmentDto.PeriodTo),
                    DateOnly.FromDateTime(CreateRiskControlSelfAssessmentDto.StartDate),
                    DateOnly.FromDateTime(CreateRiskControlSelfAssessmentDto.EndDate),
                    units);

                rcsaRepository.Add(rcsa);

                await rcsaRepository.SaveChangesAsync();

                CreateRiskControlSelfAssessmentResponseDto result = new(rcsa.Id);

                #region Log email request
                string subject = $"New RCSA Exercise";
                string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
                string emailTo = config["EmailConfiguration:RiskChampionsUnitHeads"];
                string toCC = config["EmailConfiguration:RiskMgtUnit"];
                string body = $"Hello all, <br>The RCSA exercise has begun, and you have been mandated to initiate all RCSA activities as your unit’s Risk Champion. <br><ul><li>RCSA Period Covered: {CreateRiskControlSelfAssessmentDto.PeriodFrom} - {CreateRiskControlSelfAssessmentDto.PeriodTo}</li><li>RCSA Exercise Timeline: {CreateRiskControlSelfAssessmentDto.StartDate} - {CreateRiskControlSelfAssessmentDto.EndDate}</li></ul> <br> Kindly login to the GRC Tool to initiate the RCSA exercise:<br> <a href={linkToGRCTool} >GRC link</a>.";

                var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.RiskManagement, rcsa.Id, emailTo, toCC);
                if (logEmailRequest == false)
                {
                    return TypedResults.Ok($"New RCSA Exercise was created successfully with RCSA ID: {rcsa.Id}, {result},  but email message was not logged");
                }
                #endregion

                return TypedResults.Created($"RiskControlSelfAssessment/{rcsa.Id}", result);
            }
            catch (Exception ex)
            {

                return TypedResults.BadRequest("Unable to submit the request");
            }
        }
    }
}
