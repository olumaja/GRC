using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.Infrastructure;

using FluentValidation;
using GrcApi.Modules.RiskManagement.BIA;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Arm.GrcApi.Modules.RiskManagement.BIA
{
    public class BIAModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {
            // this line creates the endpoint header on swagger
            var routeGroup = app.MapGroup("/bia").WithTags(new string[] { "Business Impact Analysis" });

            //POST /bia/start
            routeGroup.MapPost("/start", StartBusinessImpactAnalysisEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<StartBIADto>>()
                .Accepts<StartBIADto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Starts the Business Impact Analysis for the added units"
                })
                .RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("StartBusinessImpactAnalysisEndpoint")
                .Produces<StartBIAResponseDto>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /bia/started
            routeGroup.MapGet("/", GetAllStartedBIAEndpoint.HandleAsync)
               .WithOpenApi(operation => new(operation)
               {
                   Summary = "Gets all the started BIA"
               })
               .RequireAuthorization("RiskManagmentEmployeeOnly")
               .WithName("GetAllStartedBIAEndpoint")
               .Produces<PagedResult<BusinessImpactAnalysisDto>>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            // GET /bia/risk-champion/initiate-bia
            routeGroup.MapGet("/risk-champion/initiate-bia", GetAllBusinessImpactAnalysisForRiskChampionEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get business impact analysis for risk champion"
                })
                .RequireAuthorization("RiskChampionOnly")
                .WithName("GetAllBusinessImpactAnalysisForRiskChampionEndpoint")
                .Produces<List<GetAllBIAForRiskChampionDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /bia/risk-champion-head/initiate-bia
            routeGroup.MapGet("/risk-champion-head/initiate-bia", GetAllBusinessImpactAnalysisForRiskChampionHeadEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get business impact analysis for risk champion unit head"
                })
                .RequireAuthorization("UnitHeadOnly")
                .WithName("GetAllBusinessImpactAnalysisForRiskChampionHeadEndpoint")
                .Produces<List<GetAllBIAForRiskChampionDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /bia/risk-management/review-bia
            routeGroup.MapGet("/risk-management/review-bia", GetAllBusinessImpactAnalysisForRiskManagementEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get all business impact analysis for risk management after risk champion unit head approved"
                })
                //.RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("GetAllBusinessImpactAnalysisForRiskManagementEndpoint")
                .Produces<List<GetAllBIAForRiskChampionDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /bia/00000000-0000-0000-0000-000000000000/bia-unit-process-details
            routeGroup.MapGet("/{biaUnitId:guid}/bia-unit-process-details", GetBusinessImpactAnalysisEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get details of selected Business Analysis Impact"
                })
                //.RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("GetBusinessImpactAnalysisEndpoint")
                .Produces<GetBIAUnitDto>(StatusCodes.Status200OK)
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Get /bia/create-process
            routeGroup.MapPost("/create-process", BIACreateProcessEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<CreateRCSAProcessDto>>()
                .Accepts<CreateRCSAProcessDto>("application/json")
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Create process"
                })
                .RequireAuthorization()
                .WithName("BIACreateProcessEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Get /bia/delete-process
            routeGroup.MapPost("/delete-process", BIADeleteProcessEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<DeleteRCSAProcessDto>>()
                .Accepts<DeleteRCSAProcessDto>("application/json")
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Delete process"
                })
                .RequireAuthorization()
                .WithName("BIADeleteProcessEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /bia/initiate
            routeGroup.MapPost("/initiate", InitiateBusinessImpactAnalysisEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<InitiateBIADto>>()
                .Accepts<InitiateBIADto>("application/json")
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Initiate the Business Impact Analysis"
                })
                .RequireAuthorization("RiskChampionOnly")
                .WithName("InitiateBusinessImpactAnalysisEndpoint")
                .Produces<InitiateBIAResponseDto>(StatusCodes.Status201Created)
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // POST /bia/approve-initiate-bia
            routeGroup.MapPost("/approve-initiate-bia", ApproveInitiateBusinessImpactAnalysisEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ApproveInitiateBIADto>>()
                .Accepts<ApproveInitiateBIADto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Approve initiate business impact analysis"
                })
                .RequireAuthorization("UnitHeadOnly")
                .WithName("ApproveInitiateBusinessImpactAnalysisEndpoint")
                .Produces<Ok>()
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // POST /bia/reject-initiate-bia
            routeGroup.MapPost("/reject-initiate-bia", RejectInitiateBusinessImpactAnalysisEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<RejectInitiateBIADto>>()
                .Accepts<RejectInitiateBIADto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Reject initiate business impact analysis"
                })
                .RequireAuthorization("UnitHeadOnly")
                .WithName("RejectInitiateBusinessImpactAnalysisEndpoint")
                .Produces<Ok>()
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            return app;
        }

        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {
            builder.AddScoped<IRepository<BusinessImpactAnalysis>, Repository<BusinessImpactAnalysis>>();
            builder.AddScoped<IRepository<BusinessImpactAnalysisUnit>, Repository<BusinessImpactAnalysisUnit>>();
            builder.AddScoped<IRepository<BIAUnitProcessDetails>, Repository<BIAUnitProcessDetails>>();
            builder.AddScoped<IRepository<BIAUnitProcessDetailsBusinessUnitToRunProcess>, Repository<BIAUnitProcessDetailsBusinessUnitToRunProcess>>();
            builder.AddScoped<IRepository<BusinessImpactAnalysisUnitLog>, Repository<BusinessImpactAnalysisUnitLog>>();
            builder.AddScoped<ICurrentUserService, CurrentUserService>();
            builder.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            builder.AddScoped<IValidator<StartBIADto>, StartBusinessImpactAnalysisDtoValidator>();
            builder.AddScoped<IValidator<CreateBusinessImpactAnalysisUnitDto>, CreateBusinessImpactAnalysisUnitDtoValidator>();
            builder.AddScoped<IValidator<InitiateBIADto>, InitiateBIADtoValidator>();
            builder.AddScoped<IValidator<InitiateBIAProcessDetailsDto>, InitiateBIAProcessDetailsDtoValidator>();
            builder.AddScoped<IValidator<ApproveInitiateBIADto>, ApproveInitiateBIAValidator>();
            builder.AddScoped<IValidator<RejectInitiateBIADto>, RejectInitiateBIAValidator>();

            return builder;
        }
    }
}
