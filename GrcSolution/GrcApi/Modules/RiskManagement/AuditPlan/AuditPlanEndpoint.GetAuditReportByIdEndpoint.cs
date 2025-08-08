using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcTool.Infrastructure;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;
using System.Security.Claims;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 17/05/2024
* Development Group: Audit plan Risk Assessment - GRCTools
*/
    public class GetAuditReportByIdEndpoint
    {
        /// <summary>
        /// Endpoint to Get Audit Report By Id
        /// </summary>
        /// <param name="auditreportid"></param>
        /// <param name="internalAuditReport"></param>
        /// <param name="internalAuditRatingReport"></param>
        /// <param name="observationListAuditReport"></param>
        /// <param name="auditFindingAuditReport"></param>
        /// <param name="managementResponseAuditReport"></param>
        /// <param name="citationAuditReport"></param>
        /// <param name="annualAudit"></param>
        /// <param name="commenceEng"></param>
        /// <param name="auditProgram"></param>
        /// <param name="workPaper"></param>
        /// <param name="assessmentOfDigitalInitiative"></param>
        /// <param name="currentUserService"></param>
        /// <param name="distributionList"></param>
        /// <param name="businessRiskRating"></param>
        /// <param name="engagementLetter"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync(Guid auditreportid, IRepository<InternalAuditReport> internalAuditReport, IRepository<InternalAuditRatingReport> internalAuditRatingReport,
            IRepository<ObservationListAuditReport> observationListAuditReport, IRepository<AuditFindingAuditReport> auditFindingAuditReport, IRepository<ManagementResponseAuditReport> managementResponseAuditReport,
            IRepository<CitationAuditReport> citationAuditReport, IRepository<AnualAuditUniverseRiskRating> annualAudit, IRepository<CommenceEngagementAuditexecution> commenceEng,
            IRepository<AuditProgramAuditExecution> auditProgram, IRepository<WorkPaper> workPaper, IRepository<AssessmentOfDigitalInitiativeList> assessmentOfDigitalInitiative, ICurrentUserService currentUserService,
            IRepository<BusinessRiskRating> businessRiskRating, IRepository<ReportDistributionList> reportDistributionList,
            IRepository<ReportDetailfindings> reportDetailfindings, IRepository<EngagementLetterAuditExecution> engagementLetter, ClaimsPrincipal user) 
        {
            try   
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }
                string requesterUnit = user.Claims.FirstOrDefault(c => c.Type == "unit").Value;
                if (requesterUnit != "Internal Audit")
                { return TypedResults.Forbid(); }
                var getInternalAuditReport = internalAuditReport.GetContextByConditon(x => x.Id == auditreportid).FirstOrDefault();
                if (getInternalAuditReport == null)
                {
                    return TypedResults.NotFound($"Audit Report Id '{auditreportid}' or Unit/team was not found");
                }
                var getDetailfinding = reportDetailfindings.GetContextByConditon(x => x.InternalAuditReportId == getInternalAuditReport.Id).FirstOrDefault();

                var getobservationListAudit = observationListAuditReport.GetContextByConditon(x => x.InternalAuditReportId == getInternalAuditReport.Id).OrderBy(x => x.CreatedOnUtc);
                var getauditFindingAudit = auditFindingAuditReport.GetContextByConditon(x => x.InternalAuditReportId == getInternalAuditReport.Id).OrderBy(x => x.CreatedOnUtc);
                var getinternalAudit = internalAuditRatingReport.GetContextByConditon(x => x.InternalAuditReportId == getInternalAuditReport.Id).FirstOrDefault();
                var getcitationAudit = citationAuditReport.GetContextByConditon(x => x.InternalAuditReportId == getInternalAuditReport.Id).OrderBy(x => x.CreatedOnUtc);
                var getmanagementResponseAudit = managementResponseAuditReport.GetContextByConditon(x => x.InternalAuditReportId == getInternalAuditReport.Id).OrderBy(x => x.CreatedOnUtc);
                var getassessmentOfDigitalInitiative = assessmentOfDigitalInitiative.GetContextByConditon(x => x.InternalAuditReportId == getInternalAuditReport.Id).OrderBy(x => x.CreatedOnUtc);
                var getreportDistributionList = reportDistributionList.GetContextByConditon(x => x.InternalAuditReportId == getInternalAuditReport.Id).OrderBy(x => x.CreatedOnUtc);
                var getreportDetailfindings = reportDetailfindings.GetContextByConditon(x => x.InternalAuditReportId == getInternalAuditReport.Id).OrderBy(x => x.CreatedOnUtc);

                #region get distribution list fron engagement letter

                var getcommenceEngResp = commenceEng.GetContextByConditon(x => x.Id == getInternalAuditReport.CommenceEngagementAuditexecutionId).FirstOrDefault();
                var getengagementLetterResp = engagementLetter.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == getcommenceEngResp.Id).FirstOrDefault();

                #endregion

                #region get root cause               
                
                var getauditProgram = auditProgram.GetContextByConditon(x => x.CommenceEngagementAuditexecutionId == getcommenceEngResp.Id).FirstOrDefault();
                if (getauditProgram == null)
                {
                    return TypedResults.NotFound($"Audit program has not been initiated");
                }
                var getWorkPaper = workPaper.GetContextByConditon(x => x.AuditProgramId == getauditProgram.Id).FirstOrDefault();
                if (getWorkPaper == null)
                {
                    return TypedResults.NotFound($"Work paper cannot be traced");
                }
                #endregion

                var getreportDistributionLists = getreportDistributionList.Select(p => new DistributionList
                {
                    Designation = p.Designation,
                    Name = p.Name,
                    ForAction = p.ForAction,
                    ForDistribution = p.ForDistribution                   
                }).ToList();

                var getreportDetailfindingList = getreportDetailfindings.Select(p => new DetailsfindingsReq
                {
                    DescriptionOfIssue = p.DescriptionOfIssue,
                    IssueRating = p.IssueRating,
                    Observation = p.Observation,
                    PotentialMaterialisedImpact = p.PotentialMaterialisedImpact
                }).ToList();

                var getmanagementResponseAuditResp = getmanagementResponseAudit.Select(p => new ManagementResponseAudit
                {
                    Unit = p.Unit,
                    ActionOwner = p.ActionOwner,
                    ActionPointToResolve = p.ActionPointToResolve,
                    Designation = p.Designation,
                    DueDate = p.DueDate
                }).ToList();

                var getcitationAuditResp = getcitationAudit.Select(p => new CitationAudit
                {
                    Description = p.Description,
                    Placement = p.Placement
                }).ToList();                              

                var getobservationListAuditResp = getobservationListAudit.Select(p => new ObservationListAudit
                {
                    Observation = p.Observation,
                    ActionOwner = p.ActionOwner,
                    Destination = p.Destination,
                    DueDate = p.DueDate,
                    ManagementResponse = p.ManagementResponse,
                    Recommendation = p.Recommendation
                }).ToList();

                var getauditFindingAuditResp = getauditFindingAudit.Select(p => new AuditFindingAudit
                {
                    AuditFinding = p.AuditFinding,
                    ControlDesignOrEffectively = p.ControlDesignOrEffectively,
                    ControlType = p.ControlType,
                    NameOrRecurring = p.NameOrRecurring,
                    Rating = p.Rating
                }).ToList();

                var getgetassessmentOfDigitalInitiative = getassessmentOfDigitalInitiative.Select(p => new ObservationListAudit
                {
                    Observation = p.Observation,
                    ActionOwner = p.ActionOwner,
                    Destination = p.Destination,
                    DueDate = p.DueDate,
                    ManagementResponse = p.ManagementResponse,
                    Recommendation = p.Recommendation
                }).ToList();

                InternalAuditReportResponse resp = new InternalAuditReportResponse
                {
                    CommenceEngagementId = getcommenceEngResp.Id,
                    AuditReportId = auditreportid,
                    Unit = getInternalAuditReport.Unit,
                    Team = getInternalAuditReport.Team,
                    Scope = getInternalAuditReport.Scope,
                    DetailedFinding = getInternalAuditReport.DetailedFinding,
                    ScopeLimitation = getInternalAuditReport.ScopeLimitation,
                    SignedBy = getInternalAuditReport.SignedBy,
                    Summary = getInternalAuditReport.Summary,
                    DescriptionOfIssue = getDetailfinding.DescriptionOfIssue, 
                    AuditFinding = getauditFindingAuditResp,
                    ObservationList = getobservationListAuditResp,
                    InternalAuditRating = new InternalAuditRating
                    { 
                      AuditArea = getinternalAudit.AuditArea,
                      CurrentRating = getinternalAudit.CurrentRating,
                      PreviousRating = getinternalAudit.PreviousRating
                    },
                    Citation = getcitationAuditResp,
                    ManagementResponse = getmanagementResponseAuditResp,
                    ExecutiveSummary = getInternalAuditReport.ExecutiveSummary,
                    AdditionalDescription = getInternalAuditReport.AdditionalDescription,
                    AssessmentOfDigitalInitiative = getInternalAuditReport.AssessmentOfDigitalInitiative,
                    AssessmentOfDigitalInitiativeList = getgetassessmentOfDigitalInitiative,
                    OtherImprovementArea = getInternalAuditReport.OtherImprovementArea,
                    GoodPractiseInclude = getInternalAuditReport.GoodPractiseInclude,
                    Impact = getWorkPaper.Impact ?? getInternalAuditReport.Impact,
                    RootCause = getWorkPaper.RootCause ?? getInternalAuditReport.Impact,
                    Recommendation = getWorkPaper.Recommendation ?? getInternalAuditReport.Impact,
                    IssueRating = getDetailfinding.IssueRating, 
                    Observation = getDetailfinding.Observation, 
                    PotentialMaterialisedImpact = getDetailfinding.PotentialMaterialisedImpact, 
                    OverAllManagementComment = getInternalAuditReport.OverAllManagementComment,
                    ReportDistributionList = getreportDistributionLists,
                    DetailedFindings = getreportDetailfindingList,
                    Status = getInternalAuditReport.Status.ToString(),
                    ReportComment = getInternalAuditReport.ReportComment,
                    ReasonForRejection = getInternalAuditReport.ReasonForRejection
                };
                return TypedResults.Ok(resp);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound("Record was not found");
            }


        }
    }
}
