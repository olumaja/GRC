using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;
using Azure;
using FluentValidation;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using GrcApi.Modules.InternalControl;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Arm.GrcApi.Modules.InternalControl
{
    public class InternalControlModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {

            // this line creates the endpoint header on swagger
            var routeGroup = app.MapGroup("/ic").WithTags(new string[] { "Internal Control" });
            var routeGroup2 = app.MapGroup("/ice").WithTags(new string[] { "Internal Control - Exception Tracker" });
            var routeGroup3 = app.MapGroup("/task").WithTags(new string[] { "Internal Control - Dashboard Task" });
            var routeGroup4 = app.MapGroup("/callover").WithTags(new string[] { "Internal Control - Call Over" });

            //GET /internal-control/{id:guid}
            routeGroup.MapGet("/internal-control/{id:guid}", GetInternalControlByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Get Internal Control by id for internal control officer"
                })
                .RequireAuthorization()
                .WithName("GetInternalControlByIdEndpoint")
                .Produces<GetInternalControlByIdResponse>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /internal-control
            routeGroup.MapGet("/internal-control", GetInternalControlEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Get all created Internal Control for internal control officer. StartDate and Enddate format: yyyy-mm-dd"
                })
               .RequireAuthorization("InternalControlOfficerOnly")
               .WithName("GetInternalControlEndpoint")
               .Produces<PaginatedAllInternalControl>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /internal-control-actionowner
            routeGroup.MapGet("/internal-control-actionowner", InternalControlEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Get all created Internal Control for action owner"
                })
                .RequireAuthorization()
               .WithName("InternalControlEndpoint")
               .Produces<PaginatedInternalControlForActionOwner>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /internal-control-actionowner/{actionOwnerId:guid}
            routeGroup.MapGet("/internal-control-actionowner/{actionOwnerId:guid}", GetActionOwnerInternalControlByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Get Internal Control by id for action owner"
                })
                .RequireAuthorization()
                .WithName("GetActionOwnerInternalControlByIdEndpoint")
                .Produces<GetActionOwnerInternalControlByIdResponse>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            ////POST /action-owner-response
            routeGroup.MapPost("/action-owner-response", ActionOwnerResponseEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<InternalControlActionOwnerResponse>>()
                .Accepts<InternalControlActionOwnerResponse>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Action owner response, this endpoint also serve as update"
                })
                .RequireAuthorization()
                .WithName("ActionOwnerResponseEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /approve-internal-control
            routeGroup.MapPost("/approve-internal-control", ApproveInternalControlEndpoint.HandleAsync)
                .Accepts<ApproveInternalControlRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Approve created Internal Control"
                })
                .RequireAuthorization("InternalControlOfficerOnly")
                .WithName("ApproveInternalControlEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /reject-internal-control
            routeGroup.MapPost("/reject-internal-control", RejectInternalControlEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<RejectInternalControlRequest>>()
                .Accepts<RejectInternalControlRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Reject created Internal Control"
                })
                .RequireAuthorization("InternalControlOfficerOnly")
                .WithName("RejectInternalControlEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            ////POST /create-investigation
            routeGroup.MapPost("/create-investigation", CreateInvestigationEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<InternalControlDto>>()
                .Accepts<InternalControlDto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Create Internal Control"
                })
                .RequireAuthorization("InternalControlOfficerOnly")
                .WithName("CreateInvestigationEndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            ////Patch /update-created-investigation
            routeGroup.MapPatch("/update-created-investigation", UpdateCreatedInvestigationEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<UpdateInternalControlDto>>()
                .Accepts<UpdateInternalControlDto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Update Created Internal Control"
                })
                .RequireAuthorization("InternalControlOfficerOnly")
                .WithName("UpdateCreatedInvestigationEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            ////POST /creat-investigation-attachment
            routeGroup.MapPost("/create-investigation-attachment", CreateInvestigationAttachmentEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<InternalControlAttachmentDto>>()
                .Accepts<InternalControlAttachmentDto>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Upload attachment for created investigation"
                })
                .RequireAuthorization("InternalControlOfficerOnly")
                .WithName("CreateInvestigationAttachmentEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            ////GET /internal-closed-investigations
            routeGroup.MapGet("/internal-closed-investigations", GetClosedInternalControlEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Get all closed Internal Control. StartDate and Enddate format: yyyy-mm-dd"
                })
               .RequireAuthorization("InternalControlOfficerOnly")
               .WithName("GetClosedInternalControlEndpoint")
               .Produces<PaginatedClosedInternalControl>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            ////GET /internal-closed-investigations/{id:guid}
            routeGroup.MapGet("/internal-closed-investigations/{internalControlId:guid}", GetClosedInternalControlByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Get closed Internal Control by id"
                })
                .RequireAuthorization("InternalControlOfficerOnly")
               .WithName("GetClosedInternalControlByIdEndpoint")
               .Produces<List<GetClosedInternalControlByIdResponse>>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            ////Patch /update-investigation-status
            routeGroup.MapPatch("/update-investigation-status", UpdateInternalControlStatusEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<UpdateInternalControlStatus>>()
                .Accepts<UpdateInternalControlStatus>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Update investigation status"
                })
                .RequireAuthorization("InternalControlOfficerOnly")
                .WithName("UpdateInternalControlStatusEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /internal-control/{exceptionTrackerId:guid}
            routeGroup2.MapGet("/exception-tracker/{exceptionTrackerId:guid}", GetExceptionTrackerByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control - Exception Tracker: Get Created Exception Tracker by Id"
                })
                .RequireAuthorization()
                .WithName("GetExceptionTrackerByIdEndpoint")
                .Produces<GetExceptionTrackerByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /exception-tracker/update-exception-tracker
            routeGroup2.MapPatch("/exception-tracker/update-exception-tracker", UpdateExceptionTrackerEndpoint.HandleAsync)
               .Accepts<UpdateInternalControlExceptionTracker>(GRCConstants.applicationOrJson)
               .WithOpenApi(operation => new(operation)
               {
                   Summary = "Internal Control - Exception Tracker: Update Created Exception Tracker"
               })
                .RequireAuthorization("InternalControlOfficerOnly")
                .WithName("UpdateExceptionTrackerEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /exception-tracker/update-status
            routeGroup2.MapPatch("/exception-tracker/update-status", UpdateExceptionTrackerStatusEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<UpdateExceptionTrackerControlStatus>>()
                .Accepts<UpdateInternalControlStatus>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control - Exception Tracker: Action owner to Update the Created Exception Tracker Status and Management Response by Id"
                })
                .RequireAuthorization()
                .WithName("UpdateExceptionTrackerStatusEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            ////POST /create-exception
            routeGroup2.MapPost("/create-exception", CreateExceptionTrackerEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<CreateExceptionDto>>()
                .Accepts<CreateExceptionDto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Create Exception Tracker"
                })
                .RequireAuthorization("InternalControlOfficerOnly")
                .WithName("CreateExceptionTrackerEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /get-exception
            routeGroup2.MapGet("/get-exception", GetExceptionTrackerEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Get all created exception for internal control officer"
                })
                .RequireAuthorization("InternalControlOfficerOnly")
               .WithName("GetExceptionTrackerEndpoint")
               .Produces<PaginatedInternalControlExceptionResponse>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /get-exception/action-owner-screem   
            routeGroup2.MapGet("/get-exception/action-owner-screen", ActionOwnerGetExceptionTrackerEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Get all created exception assigned to the Action owner"
                })
               .RequireAuthorization()
               .WithName("ActionOwnerGetExceptionTrackerEndpoint")
               .Produces<PaginatedInternalControlExceptionResponse>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Delete /delete-exception-tracker
            routeGroup2.MapPost("/delete-exception-tracker", DeleteExceptionTrackerEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<DeleteExceptionTrackerControlStatus>>()
                .Accepts<DeleteExceptionTrackerControlStatus>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control - Exception Tracker: Delete Created Exception Tracker by Id"
                })
                .RequireAuthorization("InternalControlOfficerOnly")
                .WithName("DeleteExceptionTrackerEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            routeGroup2.MapGet("/exception-tracker/report", GetExceptionTrackerReportEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control - Exception Tracker: Get Exception Tracker report, also for download report"
                })
                .RequireAuthorization("InternalControlOfficerOnly")
                .WithName("GetExceptionTrackerReportEndpoint")
                .Produces<PaginatedInternalControlExceptionResponse>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            routeGroup2.MapGet("/unit", InternalControlUnitEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control - Get all units"
                })
                .RequireAuthorization()
                .WithName("InternalControlUnitEndpoint")
                .Produces<List<UnitResponse>>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /share-exception-report
            routeGroup2.MapPost("/share-exception-report", ShareExceptionTrackerReportEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ShareExceptionReport>>()
                .Accepts<ShareExceptionReport>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Share Exception report"
                })
                .RequireAuthorization("InternalControlOfficerOnly")
                .WithName("ShareExceptionTrackerReportEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /supervisor-get-exception
            routeGroup2.MapGet("/supervisor-get-exception", SupervisorGetExceptionEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Supervisor get all created exception for approval or reject"
                })
                //supervisor only
                .RequireAuthorization("InternalControlSupervisorOnly")
               .WithName("SupervisorGetExceptionEndpoint")
               .Produces<PaginatedInternalControlExceptionResponse>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //MapPatch /supervisor-approve-exception
            routeGroup2.MapPatch("/supervisor-approve-exception", SupervisorApproveExceptionEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<SupervisorApproveExceptionRequest>>()
                .Accepts<SupervisorApproveExceptionRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Supervisor Approve created Internal Control"
                })
                //supervisor only
                .RequireAuthorization("InternalControlSupervisorOnly")
                .WithName("SupervisorApproveExceptionEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //MapPatch /supervisor-reject-exception
            routeGroup2.MapPatch("/supervisor-reject-exception", SupervisorRejectExceptionEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<SupervisorRejectExceptionRequest>>()
                .Accepts<SupervisorRejectExceptionRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Supervisor Reject created Internal Control"
                })
                //supervisor only
                .RequireAuthorization("InternalControlSupervisorOnly")
                .WithName("SupervisorRejectExceptionEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);                      

            // GET /get-resolved-exception
            routeGroup2.MapGet("/get-resolved-exception", GetAllResolvedExceptionTrackerEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Get all resolved exception"
                })
                .RequireAuthorization()
               .WithName("GetAllResolvedExceptionTrackerEndpoint")
               .Produces<PaginatedInternalControlExceptionResponse>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /get-rejected-exception
            routeGroup2.MapGet("/get-rejected-exception", GetAllRejectedExceptionTrackerEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Internal Control Staff to get all rejected exception"
                })
                .RequireAuthorization("InternalControlOfficerOnly")
               .WithName("GetAllRejectedExceptionTrackerEndpoint")
               .Produces<PaginatedInternalControlExceptionResponse>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /create-task
            routeGroup3.MapPost("/create-task", CreateTaskEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<CreateTaskDto>>()
                .Accepts<CreateTaskDto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control Dashboard: Create Task"
                })
                .RequireAuthorization("InternalControlOfficerOnly")
                .WithName("CreateTaskEndpoint")
                .Produces<InternalControlDashBoardTaskResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /internal-control-dashboard/{id:guid}
            routeGroup3.MapGet("/internal-control-dashboard/{id:guid}", GetInternalControlDashboardByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control Dashboard: Get Internal Control dashboard by id for internal control officer"
                })
                .RequireAuthorization("InternalControlOfficerOnly")
                .WithName("GetInternalControlDashboardByIdEndpoint")
                .Produces<GetControlDashboardByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /internal-control-dashboard/{id:guid}
            routeGroup3.MapGet("/internal-control-dashboard/action-owner/{id:guid}", ActionOwnerGetInternalControlDashboardByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control Dashboard: Action owner get Internal Control dashboard by id for internal control officer"
                })
                .RequireAuthorization("InternalControlOfficerOnly")
                .WithName("ActionOwnerGetInternalControlDashboardByIdEndpoint")
                .Produces<GetControlDashboardByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /internal-control-dashboard/
            routeGroup3.MapGet("/internal-control-dashboard", GetInternalControlDashboardEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control Dashboard: Get all created internal control dashboard for internal control officer"
                })
                .RequireAuthorization("InternalControlOfficerOnly")
               .WithName("GetInternalControlDashboardEndpoint")
               .Produces<PaginatedControlDashboardListResp>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /internal-control-dashboard/
            routeGroup3.MapGet("/internal-control-dashboard/action-owner", GetActionownerInternalControlDashboardEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control Dashboard: Get all created internal control dashboard for internal control Action owner"
                })
                .RequireAuthorization("InternalControlOfficerOnly")
               .WithName("GetActionownerInternalControlDashboardEndpoint")
               .Produces<PaginatedControlDashboardListResp>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /internal-control-dashboard/update
            routeGroup3.MapPatch("/internal-control-dashboard/update", UpdateInternalControlDashboardEndpoint.HandleAsync)
               .AddEndpointFilter<ValidationFilter<UpdateInternalControlDashBoardTaskDto>>()
               .Accepts<UpdateInternalControlDashBoardTaskDto>(GRCConstants.applicationOrJson)
               .WithOpenApi(operation => new(operation)
               {
                   Summary = "Internal Control dDashboard - Supervisor to Update the Created internal control dashboard"
               })
                .RequireAuthorization("InternalControlSupervisorOnly")
                .WithName("UpdateInternalControlDashboardEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /internal-control-dashboard/update-my-task
            routeGroup3.MapPatch("/internal-control-dashboard/update-my-task", UpdateControlDashboardStatusEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<UpdateControlDashboardStatus>>()
                .Accepts<UpdateControlDashboardStatus>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control Dashboard - Action owner to Update the Created control dashboard Status by Id"
                })
                .RequireAuthorization("InternalControlOfficerOnly")
                .WithName("UpdateControlDashboardStatusEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /internal-control-task-report/
            routeGroup3.MapGet("/internal-control-task-report", InternalControlTaskReportEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control Dashboard: Get task resport"
                })
               .RequireAuthorization("InternalControlOfficerOnly")
               .WithName("InternalControlTaskReportEndpoint")
               .Produces<InternalControlTaskReportReponse>(StatusCodes.Status200OK)
               .Produces<List<string>>(StatusCodes.Status400BadRequest)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /internal-control-dashboard-report/export/pdf 
            routeGroup3.MapGet("/internal-control-dashboard-report/export/pdf", DownloadInternalControlDashboardReportToPDF.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control Dashboard: Download internal Control Dashboard Report to PDF."
                })
                .RequireAuthorization("InternalControlOfficerOnly")
                .WithName("DownloadInternalControlDashboardReportToPDF")
                .Produces<InternalControlTaskReportReponse>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /unit-callover
            routeGroup4.MapGet("/unit-callover", InternalControlUnitCallOverEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control: Get all call over for unit"
                })
               .RequireAuthorization()
               .WithName("InternalControlUnitCallOverEndpoint")
               .Produces<CallOverResponse>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /approve-call-over-report
            routeGroup4.MapPost("/approve-call-over-report", ApproveCallOverReportEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ApproveCallOverReportRequest>>()
                .Accepts<ApproveCallOverReportRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control Call Over: Approve created Call Over Report by unit head"
                })
                .RequireAuthorization("InternalControlCallOverSupervisorOnly")
                .WithName("ApproveCallOverReportEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /reject-call-over-report
            routeGroup4.MapPost("/reject-call-over-report", RejectCallOverReportEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<RejectCallOverReportRequest>>()
                .Accepts<RejectCallOverReportRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control Call Over: Reject created Call Over Report by unit head"
                })
                .RequireAuthorization("InternalControlCallOverSupervisorOnly")
                .WithName("RejectCallOverReportEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /unit-callover-upload-reports/{callOverId:guid}
            routeGroup4.MapGet("/unit-callover-upload-reports/{callOverId:guid}", GetUploadCallOverReportEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control Call Over: Get call over report for unit"
                })
               .RequireAuthorization()
               .WithName("GetUploadCallOverReportEndpoint")
               .Produces<CallOverReportResponse>(StatusCodes.Status200OK)
               .Produces<string>(StatusCodes.Status400BadRequest)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /callover-attached-document/{callOverReportId:guid}
            routeGroup4.MapGet("/callover-attached-document/{callOverReportId:guid}", GetCallOverReportAttachmentEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control Call Over: Get call over attached report"
                })
               .RequireAuthorization()
               .WithName("GetCallOverReportAttachmentEndpoint")
               .Produces<CallOverAttachedReportResponse>(StatusCodes.Status200OK)
               .Produces<string>(StatusCodes.Status400BadRequest)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            ////POST /save-callover-attachment
            routeGroup4.MapPost("/save-callover-attachment", SaveCallOverReportAttachmentEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<SaveCallOverAttachmentDto>>()
                .Accepts<SaveCallOverAttachmentDto>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control Call Over: Save call over report attachment for unit, this also serve as update"
                })
                .RequireAuthorization("InternalControlCallOverOfficerOnly")
                .WithName("SaveCallOverReportAttachmentEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            ////POST /submit-callover-report
            routeGroup4.MapPost("/submit-callover-report", SubmitCallOverReportsEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<SubmitCallOverDto>>()
                .Accepts<SubmitCallOverDto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control Call Over: Submit call over reports for unit"
                })
                .RequireAuthorization("InternalControlCallOverOfficerOnly")
                .WithName("SubmitCallOverReportsEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /review-callover
            routeGroup4.MapGet("/review-callover", ReviewCallOverEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control Call Over: Get all call over for review"
                })
               .RequireAuthorization("InternalControlOfficerOnly")
               .WithName("ReviewCallOverEndpoint")
               .Produces<ReviewCallOverResponse>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /review-callover/{calloverId}
            routeGroup4.MapGet("/review-callover/{calloverId:guid}", ViewCallOverScoreEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control Call Over: Get specific call over for review"
                })
               .RequireAuthorization("InternalControlOfficerOnly")
               .WithName("ViewCallOverScoreEndpoint")
               .Produces<ViewCallOverScoreResponse>(StatusCodes.Status200OK)
               .Produces<string>(StatusCodes.Status400BadRequest)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            ////POST /save-callover-score
            routeGroup4.MapPost("/save-callover-score", ScoreCallOverEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ScoreCallOverDto>>()
                .Accepts<ScoreCallOverDto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control Call Over: Save call over score"
                })
                .RequireAuthorization("InternalControlOfficerOnly")
                .WithName("ScoreCallOverEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /callover-report
            routeGroup4.MapGet("/callover-report", CallOverReportEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control Call Over: Get call over report"
                })
               .RequireAuthorization("InternalControlOfficerOnly")
               .WithName("CallOverReportEndpoint")
               .Produces<ReportCallOverResponse>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /all-callover-report
            routeGroup4.MapGet("/all-callover-report", AllCallOverReportEndpoint.HandleAsync) 
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Control Call Over: Get call over report without pagination for the graph"
                })
               .RequireAuthorization("InternalControlOfficerOnly")
               .WithName("AllCallOverReportEndpoint")
               .Produces<ReportCallOverV2>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            return app;
        }

        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {
            builder.AddScoped<IRepository<InternalControlExceptionTracker>, Repository<InternalControlExceptionTracker>>();
            builder.AddScoped<IRepository<InternalControlModel>, Repository<InternalControlModel>>();
            builder.AddScoped<IRepository<InternalControlAction>, Repository<InternalControlAction>>();
            builder.AddScoped<IRepository<InternalControlActionOwner>, Repository<InternalControlActionOwner>>();
            builder.AddScoped<IRepository<InternalControlDashboard>, Repository<InternalControlDashboard>>();
            builder.AddScoped<IRepository<InternalControlCallOver>, Repository<InternalControlCallOver>>();
            builder.AddScoped<IRepository<InternalControlCallOverReport>, Repository<InternalControlCallOverReport>>();

            builder.AddScoped<IValidator<UpdateInternalControlExceptionTracker>, UpdateInternalControlExceptionTrackerValidator>();
            builder.AddScoped<IValidator<RejectInternalControlRequest>, RejectInternalControlRequestValidation>();
            builder.AddScoped<IValidator<InternalControlDto>, InternalControlDtoValidator>();
            builder.AddScoped<IValidator<UpdateInternalControlDto>, UpdateInternalControlDtoValidator>();
            builder.AddScoped<IValidator<Action>, ActionDtoValidator>();
            builder.AddScoped<IValidator<Collaborators>, CollaboratorsValidation>();
            builder.AddScoped<IValidator<InternalControlActionOwnerResponse>, InternalControlActionOwnerResponseValidator>();
            builder.AddScoped<IValidator<UpdateExceptionTrackerControlStatus>, UpdateExceptionTrackerControlStatusValidator>();
            builder.AddScoped<IValidator<DeleteExceptionTrackerControlStatus>, DeleteExceptionTrackerControlStatusValidator>();
            builder.AddScoped<IValidator<UpdateInternalControlStatus>, UpdateInternalControlStatusValidator>();
            builder.AddScoped<IValidator<CreateExceptionDto>, CreateExceptionDtoValidator>();
            builder.AddScoped<IValidator<InternalControlExceptionDto>, InternalControlExceptionDtoValidator>();
            builder.AddScoped<IValidator<ShareExceptionReport>, ShareExceptionReportValidator>();
            builder.AddScoped<IValidator<RecipientEmail>, RecipientEmailValidator>();
            builder.AddScoped<IValidator<CreateTaskDto>, CreateTaskDtoValidator>();
            builder.AddScoped<IValidator<InternalControlDashBoardTaskDto>, InternalControlDashBoardTaskDtoValidator>();
            builder.AddScoped<IValidator<SupervisorRejectExceptionRequest>, SupervisorRejectExceptionRequestValidation>();
            builder.AddScoped<IValidator<UpdateControlDashboardStatus>, UpdateControlDashboardStatusValidator>();
            builder.AddScoped<IValidator<UpdateInternalControlDashBoardTaskDto>, UpdateInternalControlDashBoardTaskDtoValidator>();
            builder.AddScoped<IValidator<SupervisorApproveExceptionRequest>, SupervisorApproveExceptionRequestValidation>();
            builder.AddScoped<IValidator<ApproveCallOverReportRequest>, ApproveCallOverReportRequestValidator>();
            builder.AddScoped<IValidator<RejectCallOverReportRequest>, RejectCallOverReportRequestValidation>();
            builder.AddScoped<IValidator<ScoreCallOverDto>, ScoreCallOverDtoValidator>();

            return builder;
        }
    }
}
