using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcApi.Modules;
using Arm.GrcTool.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.RiskManagement.RCSA;
using FluentValidation;
using GrcApi.Modules.Shared.Helpers;
using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcApi.Modules.OperationControl;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class ConsolidatedAuditFindingModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {

            // this line creates the endpoint header on swagger
            var routeGroup = app.MapGroup("/caf").WithTags(new string[] { "Consolidated Audit Findings" }); 
            //GET /addfinding/   
            routeGroup.MapGet("/addfinding", GetTeamAvailableForCAFEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get all business risk rating available for CAF"
                })
                .RequireAuthorization()
                .WithName("GetTeamAvailableForCAFEndpoint")
                .Produces<ViewTeamAvailableForCAFResp>(StatusCodes.Status200OK) 
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-finding/{auditreportId:guid}/{team}
            routeGroup.MapGet("/get-finding/{auditreportId:guid}/{team}", GetFindingAvailableForCAFEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Consolidated Audit Finding - Get Audit Finding availabe for CAF by internal report id and team"
                })
                .RequireAuthorization()
                .WithName("GetFindingAvailableForCAFEndpoint")
                .Produces<TeamAvailableForCAFResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /addfinding
            routeGroup.MapPost("/addfinding", AddConsolidatedAuditFindingEndpoint.HandleAsync)
                .Accepts<ConsolidatedAuditFindingRequest>(GRCConstants.applicationOrJson)
                .AddEndpointFilter<ValidationFilter<ConsolidatedAuditFindingRequest>>()
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Consolidated Audit Finding - Add finding"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .WithName("AddConsolidatedAuditFindingEndpoint")
                .Produces<ConsolidatedAuditFindingResp>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /get-findings
            routeGroup.MapGet("/get-findings", GetConsolidatedAuditFindingEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Consolidated Audit Finding: Get all created findings"
                })
               .RequireAuthorization()
               .WithName("GetConsolidatedAuditFindingEndpoint")
               .Produces<PaginatedGetConsolidatedAuditFindingListResp>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-finding/{consolidatedauditfindingid:guid}
            routeGroup.MapGet("/get-finding/{consolidatedauditfindingid:guid}", GetConsolidatedAuditFindingByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Consolidated Audit Finding - Get Consolidated Audit Finding By Id"
                })
                .RequireAuthorization()
                .WithName("GetConsolidatedAuditFindingByIdEndpoint")
                .Produces<GetConsolidatedAuditFindingById>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            //Patch /addfinding 
            routeGroup.MapPatch("/update-addfinding", UpdateConsolidatedAuditFindingEndpoint.HandleAsync)
                .Accepts<UpdateConsolidatedAuditFindingRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Consolidated Audit Finding - Update finding"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .AddEndpointFilter<ValidationFilter<UpdateConsolidatedAuditFindingRequest>>()
                .WithName("UpdateConsolidatedAuditFindingEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /view-resolvedfindingsummary
            routeGroup.MapGet("/view-resolvedfindingsummary", ResolvedConsolidatedAuditFindingSummaryEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Consolidated Audit Finding - Resolved Consolidated Audit Finding Summary for the year"
                })
                .RequireAuthorization() 
                .WithName("ResolvedConsolidatedAuditFindingSummaryEndpoint")
                .Produces<ViewResolvedFindingResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /view-unresolvedfindingsummary   
            routeGroup.MapGet("/view-unresolvedfindingsummary", UnResolvedConsolidatedAuditFindingSummaryEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Consolidated Audit Finding - UnResolved Consolidated Audit Finding Summary for the year"
                })
                .RequireAuthorization()
                .WithName("UnResolvedConsolidatedAuditFindingSummaryEndpoint")
                .Produces<ViewResolvedFindingResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /view-findingfallenduesummary  
            routeGroup.MapGet("/view-findingfallenduesummary", FindingFallenDueSummaryEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Consolidated Audit Finding - Finding Fallen Due Summary for the year"
                })
                .RequireAuthorization()
                .WithName("FindingFallenDueSummaryEndpoint")
                .Produces<ViewResolvedFindingResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            //Patch /update-statustoresolved
            routeGroup.MapPatch("/update-statustoresolved/{consolidatedauditfindingid:guid}", UpdateStatusToResolvedEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Consolidated Audit Finding - Update Status to Resolved by ConsolidatedAuditFindingId"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .WithName("UpdateStatusToResolvedEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /update-revisedduedate/{id:guid}/{revisedduedate}
            routeGroup.MapPatch("/update-revisedduedate/{consolidatedauditfindingid:guid}/{revisedduedate}", UpdateRevisedDueDateEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Consolidated Audit Finding - Update Revised Due Date. Revised Due Date format: yyyy-mm-dd"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .WithName("UpdateRevisedDueDateEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /download/finding/template/excel
            routeGroup.MapGet("/download/finding/template/excel", DownloadCAFTemplatefile.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Consolidated Audit Finding: CAF Download Excel.Template"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .WithName("DownloadCAFTemplatefile")
                .Produces<GetRegulatorDetailsResponse>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /upload/finding/excel
            routeGroup.MapPost("/upload/finding/excel", ExcelUploadForNewFindingEndpoint.HandleAsync)
                 .AddEndpointFilter<ValidationFilter<NewFindingExcelUpload>>()
                .Accepts<NewFindingExcelUpload>("multipart/form-data")
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Consolidated Audit Finding: Excel Upload For New findings"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .WithName("ExcelUploadForNewFindingEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /download/finding/excel
            routeGroup.MapGet("/download/finding/excel", ConsolidatedAuditFindingExcelDownloadEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Consolidated Audit Finding: CAF Download to Excel file"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .WithName("ConsolidatedAuditFindingExcelDownloadEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            return app; 
        }
        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {           
            builder.AddScoped<IRepository<ConsolidatedAuditFinding>, Repository<ConsolidatedAuditFinding>>();
            builder.AddScoped<IRepository<ConsolidatedAuditFindingActionDetail>, Repository<ConsolidatedAuditFindingActionDetail>>();
            builder.AddScoped<ICurrentUserService, CurrentUserService>();
            builder.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            builder.AddScoped<IValidator<ConsolidatedAuditFindingRequest>, ConsolidatedAuditFindingRequestValidator>();
            builder.AddScoped<IValidator<ActionDetailRequest>, ActionDetailRequestValidator>();
            builder.AddScoped<IValidator<UpdateConsolidatedAuditFindingRequest>, UpdateConsolidatedAuditFindingRequestValidator>();

            return builder;
        }
    }
}
