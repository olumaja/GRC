using Arm.GrcTool.Domain;
using Arm.GrcTool.Infrastructure;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using GrcApi.Migrations;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.VisualBasic;
using System.Security.Claims;
using static iTextSharp.text.pdf.PdfDocument;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    /*
* Original Author: Sodiq Quadre
* Date Created: 17/05/2024
* Development Group: Audit plan Risk Assessment - GRCTools
* The endpoint update Audit Report
*/
    public class UpdateAuditReportEndpoint
    {
        /// <summary>
        /// This endpoint update audit report audit report id
        /// </summary>
        /// <param name="request"></param>
        /// <param name="internalAuditReport"></param>
        /// <param name="internalAuditRating"></param>
        /// <param name="assessmentOfDigital"></param>
        /// <param name="observationListAuditReport"></param>
        /// <param name="auditFinding"></param>
        /// <param name="detailfindings"></param>
        /// <param name="managementResponseAuditReport"></param>
        /// <param name="distributionList"></param>
        /// <param name="citationAuditReport"></param>
        /// <param name="user"></param>
        /// <param name="currentUserService"></param>
        /// <returns></returns>
        public static async Task<IResult> HandleAsync( [FromBody] UpdateInternalAuditReportRequest request, IRepository<InternalAuditReport> internalAuditReport, IRepository<InternalAuditRatingReport> internalAuditRating, 
            IRepository<AssessmentOfDigitalInitiativeList> assessmentOfDigital, IRepository<ObservationListAuditReport> observationListAuditReport, IRepository<AuditFindingAuditReport> auditFinding,
            IRepository<ReportDetailfindings> detailfindings, IRepository<ManagementResponseAuditReport> managementResponseAuditReport,
            IRepository<ReportDistributionList> distributionList, IRepository<CitationAuditReport> citationAuditReport, ClaimsPrincipal user, ICurrentUserService currentUserService
                       
            )
        { 
            try
            {
                if (string.IsNullOrWhiteSpace(currentUserService.CurrentUserEmail))
                {
                    return TypedResults.Unauthorized();
                }

                string requesterName = user.Claims.FirstOrDefault(c => c.Type == "name").Value;

                var getAuditReport = internalAuditReport.GetContextByConditon(c => c.Id == request.AuditReportId && c.Status != BusinessRiskRatingStatus.Approved).FirstOrDefault();
                if( getAuditReport == null)
                {
                    return TypedResults.NotFound($"Audit report with this Id ==> {request.AuditReportId} has been approved or was not found");
                }
                //update request               
                getAuditReport.UpdateInternalAuditReport(getAuditReport.Id, getAuditReport.CommenceEngagementAuditexecutionId, requesterName, request);
                getAuditReport.SetModifiedBy(getAuditReport.Id);
                getAuditReport.SetModifiedOnUtc(DateTime.Now);
                internalAuditReport.SaveChanges();

                //update audit rating
                var getinternalAuditRating = internalAuditRating.GetContextByConditon(c => c.InternalAuditReportId == request.AuditReportId).FirstOrDefault();
                if (getinternalAuditRating == null)
                {
                    return TypedResults.NotFound($"Audit rating was not found");
                }
                getinternalAuditRating.UpdateInternalAuditRatingReport(getinternalAuditRating.Id, getinternalAuditRating.InternalAuditReportId, request.InternalAuditRating.AuditArea, request.InternalAuditRating.CurrentRating, request.InternalAuditRating.PreviousRating);
                getinternalAuditRating.SetModifiedBy(getinternalAuditRating.Id);
                getinternalAuditRating.SetModifiedOnUtc(DateTime.Now);
                internalAuditRating.SaveChanges();

                foreach (var item in request.Distributionlists)  
                {
                    var getActionDetail = distributionList.GetContextByConditon(c => c.InternalAuditReportId == getAuditReport.Id).FirstOrDefault();
                    if (getActionDetail == null)
                    { return TypedResults.NotFound("Distribution List was not found"); }

                    getActionDetail.UpdateReportDistributionList(getActionDetail.Id, getActionDetail.InternalAuditReportId, item.Designation, item.Name, item.ForAction, item.ForDistribution);
                    getActionDetail.SetModifiedBy(getActionDetail.Id);
                    getActionDetail.SetModifiedOnUtc(DateTime.Now);
                }
                distributionList.SaveChanges();

                foreach (var item2 in request.DetailedFindings)  
                {
                    var getdetailfindings = detailfindings.GetContextByConditon(c => c.InternalAuditReportId == getAuditReport.Id).FirstOrDefault();
                    if (getdetailfindings == null)
                    { return TypedResults.NotFound("Detailed finding was not found"); }

                    getdetailfindings.UpdateReportDetailfindings(getdetailfindings.Id, getdetailfindings.InternalAuditReportId, item2.DescriptionOfIssue, item2.IssueRating, item2.Observation, item2.PotentialMaterialisedImpact);
                    getdetailfindings.SetModifiedBy(getdetailfindings.Id);
                    getdetailfindings.SetModifiedOnUtc(DateTime.Now);
                }
                detailfindings.SaveChanges();
                
                foreach (var item3 in request.ObservationList)
                {
                    var getobservationListAuditReport = observationListAuditReport.GetContextByConditon(c => c.InternalAuditReportId == getAuditReport.Id).FirstOrDefault();
                    if (getobservationListAuditReport == null)
                    { return TypedResults.NotFound("Observation List was not found"); }
                    getobservationListAuditReport.UpdateObservationListAuditReport(getobservationListAuditReport.Id, getobservationListAuditReport.InternalAuditReportId, item3.Observation, item3.Recommendation, item3.ManagementResponse, item3.ActionOwner, item3.Destination, item3.DueDate);
                    getobservationListAuditReport.SetModifiedBy(getobservationListAuditReport.Id);
                    getobservationListAuditReport.SetModifiedOnUtc(DateTime.Now);
                }
                observationListAuditReport.SaveChanges();
                foreach (var item4 in request.AuditFinding)
                {
                    var getobservationListAuditReport = auditFinding.GetContextByConditon(c => c.InternalAuditReportId == getAuditReport.Id).FirstOrDefault();
                    if (getobservationListAuditReport == null)
                    { return TypedResults.NotFound("Audit finding was not found"); }
                    getobservationListAuditReport.UpdateAuditFindingAuditReport(getobservationListAuditReport.Id, getobservationListAuditReport.InternalAuditReportId, item4.AuditFinding, item4.NameOrRecurring, item4.ControlType, item4.ControlDesignOrEffectively, item4.Rating);
                    getobservationListAuditReport.SetModifiedBy(getobservationListAuditReport.Id);
                    getobservationListAuditReport.SetModifiedOnUtc(DateTime.Now);
                }
                auditFinding.SaveChanges();

                foreach (var item5 in request.Citation)
                {
                    var getcitationAuditReport = citationAuditReport.GetContextByConditon(c => c.InternalAuditReportId == getAuditReport.Id).FirstOrDefault();
                    if (getcitationAuditReport == null)
                    { return TypedResults.Created("Audit finding was not found"); }
                    getcitationAuditReport.UpdateCitationAuditReport(getcitationAuditReport.Id, getcitationAuditReport.InternalAuditReportId, item5.Description, item5.Placement);
                    getcitationAuditReport.SetModifiedBy(getcitationAuditReport.Id);
                    getcitationAuditReport.SetModifiedOnUtc(DateTime.Now);
                }
                citationAuditReport.SaveChanges();

                foreach (var item6 in request.ManagementResponse)
                {
                    var getmanagementResponseAuditReport = managementResponseAuditReport.GetContextByConditon(c => c.InternalAuditReportId == getAuditReport.Id).FirstOrDefault();
                    if (getmanagementResponseAuditReport == null)
                    { return TypedResults.Created("Management Response was not found"); }
                    getmanagementResponseAuditReport.UpdateManagementResponseAuditReport(getmanagementResponseAuditReport.Id, getmanagementResponseAuditReport.InternalAuditReportId, item6.ActionPointToResolve, item6.ActionOwner, item6.Unit, item6.Designation, item6.DueDate);
                    getmanagementResponseAuditReport.SetModifiedBy(getmanagementResponseAuditReport.Id);
                    getmanagementResponseAuditReport.SetModifiedOnUtc(DateTime.Now);
                }
                managementResponseAuditReport.SaveChanges();

                foreach (var item7 in request.AssessmentOfDigitalInitiativeList)
                {
                    var getassessmentOfDigital = assessmentOfDigital.GetContextByConditon(c => c.InternalAuditReportId == getAuditReport.Id).FirstOrDefault();
                    if (getassessmentOfDigital == null)
                    { return TypedResults.Created("Management Response was not found"); }
                    getassessmentOfDigital.UpdateAssessmentOfDigitalInitiativeList(getassessmentOfDigital.Id, getassessmentOfDigital.InternalAuditReportId, item7.Observation, item7.Recommendation, item7.ManagementResponse, item7.ActionOwner, item7.Destination, item7.DueDate);
                    getassessmentOfDigital.SetModifiedBy(getassessmentOfDigital.Id);
                    getassessmentOfDigital.SetModifiedOnUtc(DateTime.Now);
                }
                assessmentOfDigital.SaveChanges();

                foreach (var item8 in request.AssessmentOfDigitalInitiativeList)
                {
                    var getassessmentOfDigital = assessmentOfDigital.GetContextByConditon(c => c.InternalAuditReportId == getAuditReport.Id).FirstOrDefault();
                    if (getassessmentOfDigital == null)
                    { return TypedResults.NotFound("Assessment Of Digital Initiative List was not found"); }
                    getassessmentOfDigital.UpdateAssessmentOfDigitalInitiativeList(getassessmentOfDigital.Id, getassessmentOfDigital.InternalAuditReportId, item8.Observation, item8.Recommendation, item8.ManagementResponse, item8.ActionOwner, item8.Destination, item8.DueDate);
                    getassessmentOfDigital.SetModifiedBy(getassessmentOfDigital.Id);
                    getassessmentOfDigital.SetModifiedOnUtc(DateTime.Now);
                }
                assessmentOfDigital.SaveChanges();

                return TypedResults.Ok("updated succcessfully");
            }
            catch (Exception ex) 
            {
                return TypedResults.BadRequest("Internal server error: Unable to submit the request");
            }
        }
    }
}
