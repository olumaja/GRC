using Arm.GrcApi.Modules.RiskManagement.PRA;
using Arm.GrcApi.Modules.Shared.EmailNotification;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.Shared.Helpers;
using System.Security.Claims;
using System.Security.Cryptography;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Arm.GrcApi.Modules.RiskManagement
{
    public record CreateRiskEventResponseDto { 
        public Guid RiskEventId { get; set; }
    }
    public class RiskEventEndpointPostRiskEvent
    {

        public static async Task<IResult> HandleAsync(
            CreateRiskEventDto newRiskEvent, IRepository<BusinessEntity> businessRepo
            ,IRepository<RiskEvent> riskEventRepository, 
            IRepository<Document> documentRepository,
            IUnitOfWork unitOfWork, ICurrentUserService currentUserService,
            IEmailService EmailService, IConfiguration config
        ) {

            string email = currentUserService.CurrentUserEmail;

            var businessName = (await businessRepo.GetByIdAsync(newRiskEvent.LocationId))?.Name;

            RiskEvent riskEvent = RiskEvent.Create(
                newRiskEvent.DateOfIdentification,
                newRiskEvent.DateOfOcurrence,
                newRiskEvent.Description,
                newRiskEvent.EstimatedLoss,
                newRiskEvent.LocationId,
                newRiskEvent.DepartmentId,
                newRiskEvent.UnitId,
                newRiskEvent.ReportedByUsername,
                currentUserService.CurrentUserFullName
            );

            await riskEventRepository.AddAsync(riskEvent);
            if (newRiskEvent.Attachments != null && newRiskEvent.Attachments.Count > 0)
            {
                //handle attachments
                List<Document> riskEventDocuments = new();
                Parallel.ForEach(newRiskEvent.Attachments, a => riskEventDocuments.Add(DocumentExtensions.ConvertFormFileToDocument(a, ModuleType.RiskManagement, riskEvent.Id)));
                await documentRepository.AddRangeAsync(riskEventDocuments);
            }
           await unitOfWork.SaveChangesAsync();

            CreateRiskEventResponseDto result = new() { RiskEventId = riskEvent.Id};

            #region Log email request
            string subject = $"New Risk Event";
            string emailTo = config["EmailConfiguration:RiskMgtUnit"];
            string toCC = config["EmailConfiguration:toCC"];
            string linkToGRCTool = config["EmailConfiguration:linkToGRCTool"];
            string body = $"Hello all, <br> A Risk Event has been submitted on the GRC Tool.<br><ul><li>Event Description: {newRiskEvent.Description}</li><li>Event Identifier: {newRiskEvent.ReportedByUsername}</li><li>Event Location: {businessName}</li><li>Date of Occurence: {newRiskEvent.DateOfOcurrence}</li><li>Estimated Loss: {newRiskEvent.EstimatedLoss}</li></ul>  <br> <br>Kindly click on the link provided for further information:<br> <a href={linkToGRCTool} >GRC link</a>.";
            var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.RiskManagement, result.RiskEventId, emailTo, toCC);
            if (logEmailRequest == false)
            {
                return TypedResults.Ok($"Request created successfully with risk-events ID: {result.RiskEventId} but email message was not logged");
            }
            #endregion

            return TypedResults.Created($"risk-events/{result.RiskEventId}",  result);
        }
    }
}
