using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcApi.Modules.RiskManagement.PRA;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class InternalAuditReportModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {

            // this line creates the endpoint header on swagger
            var routeGroup = app.MapGroup("/ar").WithTags(new string[] { "Audit Report" });

            //GET /auditreport/   
            routeGroup.MapGet("/auditreport", ViewInternalAuditReportEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Audit Report - View Internal Audit businesses with their teams for the Year"
                })
                .RequireAuthorization()
                .WithName("ViewInternalAuditReportEndpoint")
                .Produces<ViewInternalAuditReportResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditreport/teamawaitingreportsummary/{annualAuditUniverseId:guid}
            routeGroup.MapGet("/auditreport/teamawaitingreportsummary/{annualAuditUniverseId:guid}", ViewTeamAwaitingReportEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Available for Reporting: View teams available for reporting by AnnualAuditUniverseId"
                })
                .RequireAuthorization()
                .WithName("ViewTeamAwaitingReportEndpoint")
                .Produces<GetTeamCompletedEngagementResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditreport/get-teamcompletedengagement/{commenceengagementid:guid}/{team} 
            routeGroup.MapGet("/auditreport/get-teamcompletedengagement/{annualAuditUniverseId:guid}/{team}", GetTeamCompletedEngagementEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Available for Reporting: Get team completed commenced engagement and available for reporting"
                })
                .RequireAuthorization()
                .WithName("GetTeamCompletedEngagementEndpoint")
                .Produces<GetTeamCompletedEngagementByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /auditreport/initiateauditreport
            routeGroup.MapPost("/auditreport/initiateauditreport", InitiateInternalAuditReportEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<InternalAuditReportRequest>>()
                .Accepts<InternalAuditReportRequest>(GRCConstants.applicationOrJson)                               
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Audit Report - Initiate Audit Report"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .WithName("InitiateInternalAuditReportEndpoint")
                .Produces<AuditReportResp>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            //GET /auditreport/get-auditreport/{auditreportid:guid} 
            routeGroup.MapGet("/auditreport/get-auditreport/{auditreportid:guid}/", GetAuditReportByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Audit Report - Get Audit Report By Id"
                })
                .RequireAuthorization() 
                .WithName("GetAuditReportByIdEndpoint")
                .Produces<InternalAuditReportResponse>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditreport/get-auditreport  
            routeGroup.MapGet("/get-ratedbusinessriskrating", GetAuditReportEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Audit Report: Get Audit Reports"
                })
                .RequireAuthorization()
                .WithName("GetAuditReportEndpoint")
               .Produces<List<GetAllInternalControlResp>>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /update-auditreport 
            routeGroup.MapPatch("/update-auditreport", UpdateAuditReportEndpoint.HandleAsync) 
                 .Accepts<UpdateInternalAuditReport>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Audit Report - Update Audit Report"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .WithName("UpdateAuditReportEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /auditreport/approve-report
            routeGroup.MapPost("/auditreport/approve-report", ApproveReportEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Audit Report - Approve Audit Report"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .AddEndpointFilter<ValidationFilter<ApproveReportDto>>()
                .Accepts<ApproveReportDto>(GRCConstants.applicationOrJson)
                .WithName("ApproveReportEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /auditreport/reject-report
            routeGroup.MapPost("/auditreport/reject-report", RejectAuditReportEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Audit Report - Reject Audit Report"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .AddEndpointFilter<ValidationFilter<RejectAuditReportDto>>()
                .Accepts<RejectAuditReportDto>(GRCConstants.applicationOrJson)
                .WithName("RejectAuditReportEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            return app;
        }
        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {

            builder.AddScoped<IRepository<ReportDetailfindings>, Repository<ReportDetailfindings>>();
            builder.AddScoped<IRepository<ReportDistributionList>, Repository<ReportDistributionList>>();
            builder.AddScoped<IRepository<AssessmentOfDigitalInitiativeList>, Repository<AssessmentOfDigitalInitiativeList>>();
            builder.AddScoped<IRepository<InternalAuditReport>, Repository<InternalAuditReport>>();
            builder.AddScoped<IRepository<CitationAuditReport>, Repository<CitationAuditReport>>();
            builder.AddScoped<IRepository<ObservationListAuditReport>, Repository<ObservationListAuditReport>>();
            builder.AddScoped<IRepository<ManagementResponseAuditReport>, Repository<ManagementResponseAuditReport>>();
            builder.AddScoped<IRepository<InternalAuditRatingReport>, Repository<InternalAuditRatingReport>>();
            builder.AddScoped<IRepository<AuditFindingAuditReport>, Repository<AuditFindingAuditReport>>();
            builder.AddScoped<ICurrentUserService, CurrentUserService>();
            builder.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            builder.AddScoped<IValidator<ApproveReportDto>, ApproveReportDtoValidation>();
            builder.AddScoped<IValidator<RejectAuditReportDto>, RejectAuditReportDtoValidation>();

            return builder;
        }
    }
}
