using Arm.GrcApi.Modules.RiskManagement.PRA;
using Arm.GrcTool.Domain;
using Arm.GrcTool.InfrastruCTOre;
using Arm.GrcTool.Infrastructure;
using Azure;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
     * Original Author: Sodiq Quadre
     * Date Created: 17/05/2024
     * Development Group: GRCTools
     * Initiate Internal Audit Report with document Upload.     
     */
    public class InitiateInternalAuditReportEndpoint
    {
        /// <summary>
        /// Initiate Product Risk Assessment with document Upload. 
        /// </summary> 
        /// <param name="request"></param>
        /// <param name="Commenceengement"></param>
        /// <param name="businessRiskRating"></param>
        /// <param name="internalAuditReport"></param>
        /// <param name="internalAuditRatingReport"></param>
        /// <param name="observationListAuditReport"></param>
        /// <param name="auditFindingAuditReport"></param>
        /// <param name="managementResponseAuditReport"></param>
        /// <param name="citationAuditReport"></param>
        /// <param name="documentRepository"></param>
        /// <param name="assessmentOfDigitalInitiative"></param>
        /// <param name="annualAudit"></param>
        /// <param name="commenceEng"></param>
        /// <param name="EmailService"></param>
        /// <param name="config"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>       
        public static async Task<IResult> HandleAsync([FromBody] InternalAuditReportRequest request, IRepository<CommenceEngagementAuditexecution>Commenceengement, IRepository<BusinessRiskRating> businessRiskRating, IRepository<InternalAuditReport> internalAuditReport, 
            IRepository<InternalAuditRatingReport> internalAuditRatingReport, IRepository<ObservationListAuditReport> observationListAuditReport, IRepository<ReportDistributionList> reportDistributionLists,
            IRepository<AuditFindingAuditReport> auditFindingAuditReport, IRepository<ManagementResponseAuditReport> managementResponseAuditReport,
            IRepository<CitationAuditReport> citationAuditReport, IRepository<Document> documentRepository, IRepository<AssessmentOfDigitalInitiativeList> assessmentOfDigitalInitiative,
            IRepository<AnualAuditUniverseRiskRating> annualAudit, IRepository<CommenceEngagementAuditexecution> commenceEng, IRepository<ReportDetailfindings> reportDetailfindings, 
            IEmailService EmailService, IConfiguration config, ClaimsPrincipal user, ICurrentUserService currentUserService) 
        {
            try 
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                string requesterName = user.Claims.FirstOrDefault(c => c.Type == "name").Value;

                List<ReportDetailfindings> detailfindings = new List<ReportDetailfindings>();  
                List<ReportDistributionList> distributionList = new List<ReportDistributionList>();
                List<AuditFindingAuditReport> auditFindings = new List<AuditFindingAuditReport>();
                List<ManagementResponseAuditReport> managementResponses = new List<ManagementResponseAuditReport>();
                List<ObservationListAuditReport> observationLists = new List<ObservationListAuditReport>();
                List<CitationAuditReport> citationAudits = new List<CitationAuditReport>();
                List<AssessmentOfDigitalInitiativeList> assessmentOfDigitalInitiativeList = new List<AssessmentOfDigitalInitiativeList>();
                var checkIfBusinessRiskRatingIdExist = Commenceengement.GetContextByConditon(c => c.Id == request.CommenceengagementId && c.Team == request.Team && c.EngagementPlan == BusinessRiskRatingStatus.Approved && c.WorkPaper == BusinessRiskRatingStatus.Approved && c.Findingstatus == BusinessRiskRatingStatus.Approved).FirstOrDefault();
                if (checkIfBusinessRiskRatingIdExist == null) 
                {
                    return TypedResults.BadRequest($"Commence Engagement or Work Paper or Finding has not been completed for this team '{request.Team}'");

                }
                var checkIfItHasBeenReported = internalAuditReport.GetContextByConditon(c => c.Unit == request.Unit &&c.Team == request.Team).FirstOrDefault();
                if (checkIfItHasBeenReported != null) { return TypedResults.Ok($"Audit Report has been previously initiated with the Id: {checkIfItHasBeenReported.Id}"); }

                if(checkIfItHasBeenReported == null)  
                {
                    //log request
                    var logRequest = InternalAuditReport.Create(request.CommenceengagementId, requesterName, request);
                    await internalAuditReport.AddAsync(logRequest);
                    //log distribution List Audit Report
                    foreach (var item in request.Distributionlists)
                    {
                        distributionList.Add(ReportDistributionList.Create(logRequest.Id, item.Designation, item.Name, item.ForAction, item.ForDistribution));
                    }
                    await reportDistributionLists.AddRangeAsync(distributionList);

                    //log detailed findings Audit Report
                    foreach (var item in request.DetailedFindings)
                    {
                        detailfindings.Add(ReportDetailfindings.Create(logRequest.Id, item.DescriptionOfIssue, item.IssueRating, item.Observation, item.PotentialMaterialisedImpact, item.Recommendation));
                    }
                    await reportDetailfindings.AddRangeAsync(detailfindings);

                    //log Observation List Audit Report
                    foreach (var item in request.ObservationList)
                    {
                        observationLists.Add(ObservationListAuditReport.Create(logRequest.Id, item.Observation, item.Recommendation, item.ManagementResponse, item.ActionOwner, item.Destination, item.DueDate));
                    }
                    await observationListAuditReport.AddRangeAsync(observationLists);
                    //log Audit Finding Audit Report
                    foreach (var itemFinding in request.AuditFinding)
                    {
                        auditFindings.Add(AuditFindingAuditReport.Create(logRequest.Id, itemFinding.AuditFinding, itemFinding.NameOrRecurring, itemFinding.ControlType, itemFinding.ControlDesignOrEffectively, itemFinding.Rating));
                    }
                    await auditFindingAuditReport.AddRangeAsync(auditFindings);
                  
                    //log Internal Audit Rating Report               
                    var loginternalAuditRating = InternalAuditRatingReport.Create(logRequest.Id, request.InternalAuditRating.AuditArea, request.InternalAuditRating.CurrentRating, request.InternalAuditRating.PreviousRating);
                    await internalAuditRatingReport.AddAsync(loginternalAuditRating);

                    //log Management Response Audit Report
                    foreach (var itemMgtResp in request.ManagementResponse)
                    {
                        managementResponses.Add(ManagementResponseAuditReport.Create(logRequest.Id, itemMgtResp.ActionPointToResolve, itemMgtResp.ActionOwner, itemMgtResp.Unit, itemMgtResp.Designation, itemMgtResp.DueDate));
                    }
                    await managementResponseAuditReport.AddRangeAsync(managementResponses);

                    //log Citation Audit Report
                    foreach (var itemCitation in request.Citation)
                    {
                        citationAudits.Add(CitationAuditReport.Create(logRequest.Id, itemCitation.Description, itemCitation.Placement));
                    }
                    await citationAuditReport.AddRangeAsync(citationAudits);

                    //log Assessment Of Digital InitiativeList Audit Report
                    foreach (var itemassessmentOfDigitalInitiative in request.AssessmentOfDigitalInitiativeList)
                    {
                        assessmentOfDigitalInitiativeList.Add(AssessmentOfDigitalInitiativeList.Create(logRequest.Id, itemassessmentOfDigitalInitiative.Observation, itemassessmentOfDigitalInitiative.Recommendation, itemassessmentOfDigitalInitiative.ManagementResponse, itemassessmentOfDigitalInitiative.ActionOwner, itemassessmentOfDigitalInitiative.Destination, itemassessmentOfDigitalInitiative.DueDate));
                    }
                    await assessmentOfDigitalInitiative.AddRangeAsync(assessmentOfDigitalInitiativeList);
                   
                    await internalAuditReport.SaveChangesAsync();
                    var response = new AuditReportResp
                    {
                        AuditReportRespId = logRequest.Id
                    };
                    #region Send email to the InternalAudit-HQ 
                    string subject = "Notification of audit report submission.";
                    string emailTo = config["EmailConfiguration:InternalAuditSupervisor"];
                    string toCC = config["EmailConfiguration:ToCCInternalAudit"];
                    var linkToGRCTool = string.Format(config["EmailConfiguration:AuditReportLink"], logRequest.Id);
                    string body = $"Dear Supervisor, <br><br> {requesterName} has submitted the {request.Team} audit report for your review and approval. <br><br>Please access the report with the following link <a href={linkToGRCTool}>GRC link</a><br><br> Thank you.";
                    var logEmailRequest = await EmailService.LogEmailRequestAssync(subject: subject, message: body, ModuleType.InternalAudit, logRequest.Id, emailTo, toCC);
                    
                    #endregion                  
                    return TypedResults.Created($"ar/{response}", response);
                }

                return TypedResults.BadRequest();
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }

        }
    }
}
