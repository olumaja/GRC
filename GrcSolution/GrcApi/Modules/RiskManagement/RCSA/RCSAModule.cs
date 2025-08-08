using Arm.GrcApi.Modules;
using Arm.GrcApi.Modules.RiskManagement;
using Arm.GrcApi.Modules.RiskManagement.PRA;
using Arm.GrcApi.Modules.RiskManagement.RCSA;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Infrastructure;

using FluentValidation;

using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using static Arm.GrcApi.Modules.RiskManagement.CreateProcessInherentRiskControlRiskRatingDto;

namespace GrcApi.Modules.RiskManagement.RCSA
{
    public class RCSAModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {
            #region RCSA
            // this line creates the endpoint header on swagger
            var rcsaRouteGroup = app.MapGroup("/rcsa").WithTags(new string[] { "Risk Control Self Assessment" });

            //POST /rcsa
            rcsaRouteGroup.MapPost("/", RiskControlSelfAssessmentEndpointPostRCSA.HandleAsync)
                .AddEndpointFilter<ValidationFilter<CreateRiskControlSelfAssessmentDto>>()
                .Accepts<CreateRiskControlSelfAssessmentDto>("application/json")
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Starts the Risk Control Self Assessment for the added units"
                })
                .RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("RiskControlSelfAssessmentEndpointPostRCSA")
                .Produces<CreateRiskControlSelfAssessmentResponseDto>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /rcsa
            rcsaRouteGroup.MapGet("/", RiskControlSelfAssessmentEndpointGetAllRCSA.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Gets all the RCSAs started by the risk management staff"
                })
                 .RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("GetAllRiskControlSelfAssessments")
                .Produces<List<RiskControlSelfAssessmentDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /rcsa/risk-management/apply-test
            rcsaRouteGroup.MapGet("/risk-management/apply-test", RiskControlSelfAssessmentEndpointGetAllRCSAForRiskManagementToApplyTest.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Gets all the RCSAs on risk management desk to apply test"
                })
                .WithName("RiskControlSelfAssessmentEndpointGetAllRCSAForRiskManagementToApplyTest")
                .Produces<List<GetAllRCSAForRiskChampionDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /rcsa/risk-champion/initiate-rcsa
            rcsaRouteGroup.MapGet("/risk-champion/initiate-rcsa", RiskControlSelfAssessmentEndpointGetAllRCSAForRiskChampionToInitiateRCSA.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Gets all the RCSAs for risk champion to initiate RCSA"
                })
                .RequireAuthorization("RiskChampionOnly")
                .WithName("RiskControlSelfAssessmentEndpointGetAllRCSAForRiskChampionToInitiateRCSA")
                .Produces<List<GetAllRCSAForRiskChampionDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /rcsa/risk-champion-head/initiate-rcsa
            rcsaRouteGroup.MapGet("/risk-champion-head/initiate-rcsa", RiskControlSelfAssessmentEndpointGetAllRCSAForRiskChampionUnitHeadToInitiateRCSA.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Gets all the RCSAs for risk champion head after initiate RCSA"
                })
                .RequireAuthorization("UnitHeadOnly")
                .WithName("RiskControlSelfAssessmentEndpointGetAllRCSAForRiskChampionUnitHeadToInitiateRCSA")
                .Produces<List<GetAllRCSAForRiskChampionDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /rcsa/risk-management/final
            rcsaRouteGroup.MapGet("/risk-management/final", RiskControlSelfAssessmentEndpointGetAllRCSAForRiskManagementFinal.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Gets all the RCSAs on risk management desk for final review"
                })
                .WithName("RiskControlSelfAssessmentEndpointGetAllRCSAForRiskManagementFinal")
                .Produces<List<GetAllRCSAForRiskChampionDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /rcsa/risk-champion/review-tests-applied
            rcsaRouteGroup.MapGet("/risk-champion/review-tests-applied", RiskControlSelfAssessmentEndpointGetAllRCSAForRiskChampionReviewTestApplied.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Gets all the RCSAs for risk champion to review tests applied"
                })
                .RequireAuthorization("RiskChampionOnly")
                .WithName("RiskControlSelfAssessmentEndpointGetAllRCSAForRiskChampionReviewTestApplied")
                .Produces<List<GetAllRCSAForRiskChampionDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /rcsa/risk-champion-head/review-tests-applied
            rcsaRouteGroup.MapGet("/risk-champion-head/review-tests-applied", RiskControlSelfAssessmentEndpointGetAllRCSAForRiskChampionHeadReviewTestApplied.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Gets all the RCSAs for risk champion head to review tests applied"
                })
                .RequireAuthorization("UnitHeadOnly")
                .WithName("RiskControlSelfAssessmentEndpointGetAllRCSAForRiskChampionHeadReviewTestApplied")
                .Produces<List<GetAllRCSAForRiskChampionDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Get /rcsa/00000000-0000-0000-0000-000000000000
            rcsaRouteGroup.MapGet("/{rcsaId:guid}", RiskControlSelfAssessmentEndpointGetRCSA.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get details for the specified rcsa"
                })
                .WithName("RiskControlSelfAssessmentEndpointGetRCSA")
                .Produces<RiskControlSelfAssessmentDto>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Get /rcsa/process
            rcsaRouteGroup.MapGet("/process", RiskControlSelfAssessmentEndpointGetProcess.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Retrive list of processes"
                })
                .RequireAuthorization()
                .WithName("RiskControlSelfAssessmentEndpointGetProcess")
                .Produces<IList<RiskControlSelfAssessmentGetProcessDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Get /rcsa/unit-process
            rcsaRouteGroup.MapGet("/unit-process", GetProcessByUnitEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Retrive list of processes by unit name"
                })
                .RequireAuthorization()
                .WithName("GetProcessByUnitEndpoint")
                .Produces<IList<GetRCSAProcessResponse>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Get /rcsa/create-process
            rcsaRouteGroup.MapPost("/create-process", CreateProcessEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<CreateRCSAProcessDto>>()
                .Accepts<CreateRCSAProcessDto>("application/json")
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Create process"
                })
                .RequireAuthorization()
                .WithName("CreateProcessEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Get /rcsa/delete-process
            rcsaRouteGroup.MapPost("/delete-process", DeleteProcessEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<DeleteRCSAProcessDto>>()
                .Accepts<DeleteRCSAProcessDto>("application/json")
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Delete process"
                })
                .RequireAuthorization()
                .WithName("DeleteProcessEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Post rcsa/documentRCSAProcess
            rcsaRouteGroup.MapPost("/documentRCSAProcess", RiskControlSelfAssessmentEndpointPostDocumentProcess.HandleAsync)
                .AddEndpointFilter<ValidationFilter<RiskControlSelfAssessmentCreateDocumentProcessDto>>()
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Initate RCSA by documenting process, risk and controls"
                })
                .RequireAuthorization("RiskChampionOnly")
                .WithName("RiskControlSelfAssessmentEndpointPostDocumentProcess")
                .Produces<CreateDocumentProcessResponseDto>(StatusCodes.Status201Created)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Get /riskControlSelfAssessmentUnitId/00000000-0000-0000-0000-000000000000/documentRCSAProcess
            rcsaRouteGroup.MapGet("/{riskControlSelfAssessmentUnitId:guid}/documentRCSAProcess", RiskControlSelfAssessmentEndpointGetDocumentedProcess.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get documented process for the specify rcsa"
                })
                 //.RequireAuthorization("RiskChampionAndUnitHead")
                .WithName("RiskControlSelfAssessmentEndpointGetDocumentedProcess")
                .Produces<GetDocumentedProcessDto>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Post rcsa/process-risk-rating
            rcsaRouteGroup.MapPost("/process-control-risk-rating", RiskControlSelfAssessmentEndpointPostProcessInherentRiskControlRiskRating.HandleAsync)
                .Accepts<CreateProcessInherentRiskControlRiskRatingDto>("multipart/form-data")
                .AddEndpointFilter<ValidationFilter<CreateProcessInherentRiskControlRiskRatingDto>>()
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Update the risk rating for the process inherent risk control"
                })
                .RequireAuthorization("RiskChampionOnly")
                .WithName("RiskControlSelfAssessmentEndpointPostProcessInherentRiskControlRiskRating")
                .Produces<Ok>()
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Get rcsa/00000000-0000-0000-0000-000000000000/process-risk-rating
            rcsaRouteGroup.MapGet("{riskControlSelfAssessmentUnitId:guid}/process-risk-rating", RiskControlSelfAssessmentEndpointGetProcessInherentRiskControlRiskRating.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get the risk rating for the process inherent risk control for risk champion head to review"
                })
                 //.RequireAuthorization("RiskChampionAndUnitHead")
                .WithName("RiskControlSelfAssessmentEndpointGetProcessInherentRiskControlRiskRating")
                .Produces<GetProcessInherentRiskControlRiskRatingDto>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Post rcsa/TestToApply
            rcsaRouteGroup.MapPost("/testToApply", RiskControlSelfAssessmentEndpointPostTestToApplyEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ApplyTestProcessInherentRiskControlDto>>()
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Apply test to process inherentrisk control"
                })
                .RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("RiskControlSelfAssessmentEndpointPostTestToApplyEndpoint")
                .Produces<Ok>()
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Post rcsa/initiate/approved
            rcsaRouteGroup.MapPost("/initiate/approve", RiskControlSelfAssessmentEndpointPostApproveInitiatedRCSA.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ApproveDto>>()
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Approve initiated risk control self assessment"
                })
                .RequireAuthorization("UnitHeadOnly")
                .WithName("RiskControlSelfAssessmentEndpointPostApproved")
                .Produces<Ok>()
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Post rcsa/initiate/reject
            rcsaRouteGroup.MapPost("/initiate/reject", RiskControlSelfAssessmentEndpointPostRejectInitiatedRCSA.HandleAsync)
                .AddEndpointFilter<ValidationFilter<RiskControlSelfAssessmentRejectDto>>()
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Reject risk control self assessment"
                })
                .RequireAuthorization("UnitHeadOnly")
                .WithName("RiskControlSelfAssessmentEndpointPostRejected")
                .Produces<Ok>()
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Post rcsa/review-test-applied/approve
            rcsaRouteGroup.MapPost("/review-test-applied/approve", RiskControlSelfAssessmentEndpointPostApproveReviewedTestApplied.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ApproveDto>>()
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Approve reviewed test applied"
                })
                .RequireAuthorization("UnitHeadOnly")
                .WithName("RiskControlSelfAssessmentEndpointPostApproveReviewedTestApplied")
                .Produces<Ok>()
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Post rcsa/review-test-applied/reject
            rcsaRouteGroup.MapPost("/review-test-applied/reject", RiskControlSelfAssessmentEndpointPostRejectReviewedTestApplied.HandleAsync)
                .AddEndpointFilter<ValidationFilter<RiskControlSelfAssessmentRejectDto>>()
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Reject reviewed test applied"
                })
                .RequireAuthorization("UnitHeadOnly")
                .WithName("RiskControlSelfAssessmentEndpointPostRejectReviewedTestApplied")
                .Produces<Ok>()
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Post rcsa/final
            rcsaRouteGroup.MapPost("/finalize", RiskControlSelfAssessmentEndpointPostFinaliseRCSA.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ApproveDto>>()
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Finalize RCSA"
                })
                .RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("RiskControlSelfAssessmentEndpointPostFinaliseRCSA")
                .Produces<Ok>()
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            #endregion

            return app;
        }

        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {
            builder.AddScoped<IRepository<RSCAProcess>, Repository<RSCAProcess>>();
            builder.AddScoped<IRepository<DocumentRSCAProcess>, Repository<DocumentRSCAProcess>>();
            builder.AddScoped<IRepository<ProcessInherentRiskControl>, Repository<ProcessInherentRiskControl>>();
            builder.AddScoped<IRepository<RiskControlSelfAssessment>, Repository<RiskControlSelfAssessment>>();
            builder.AddScoped<IRepository<RiskControlSelfAssessmentUnit>, Repository<RiskControlSelfAssessmentUnit>>();
            builder.AddScoped<IRepository<DocumentRSCAProcessLog>, Repository<DocumentRSCAProcessLog>>();
            builder.AddScoped<ICurrentUserService, CurrentUserService>();
            builder.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            builder.AddScoped<IValidator<CreateRiskControlSelfAssessmentDto>, CreateRiskControlSelfAssessmentDtoValidator>();
            builder.AddScoped<IValidator<CreateRiskControlSelfAssessmentUnitDto>, CreateRiskControlSelfAssessmentUnitDtoValidator>();
            builder.AddScoped<IValidator<CreateProcessInherentRiskControlRiskRatingDto>, CreateProcessInherentRiskControlRiskRatingDtoValidator>();
            builder.AddScoped<IValidator<ApproveDto>, ApprovedDtoValidator>();
            builder.AddScoped<IValidator<ApplyTestProcessInherentRiskControlDto>, ApplyTestProcessInherentRiskControlDtoValidator>();
            builder.AddScoped<IValidator<TestToApplyDto>, TestToApplyDtoValidator>();
            builder.AddScoped<IValidator<RiskControlSelfAssessmentRejectDto>, RiskControlSelfAssessmentRejectDtoValidator>();
            builder.AddScoped<IValidator<RiskControlSelfAssessmentCreateDocumentProcessDto>, RiskControlSelfAssessmentCreateDocumentProcessDtoValidator>();
            builder.AddScoped<IValidator<CreateProcessInherentRiskControlDto>, CreateProcessInherentRiskControlDtoValidator>();
            builder.AddScoped<IValidator<CreateRCSAProcessDto>, CreateRCSAProcessDtoValidator>();
            builder.AddScoped<IValidator<DeleteRCSAProcessDto>, DeleteRCSAProcessDtoValidator>();

            return builder;
        }
    }
}
