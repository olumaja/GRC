using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.RiskManagement.PRA;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Arm.GrcApi.Modules.RiskManagement.PRA
{
    public class PRAModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {

            // this line creates the endpoint header on swagger
            var routeGroup = app.MapGroup("/pra").WithTags(new string[] { "Product Risk Assessment" });

            //POST /pra/initiate product risk assessment
            routeGroup.MapPost("/", ProductRiskAssessmentEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ProductRiskAssessmentDTO>>()
                .Accepts<ProductRiskAssessmentDTO>("multipart/form-data")
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Initiate Product Risk Assessment"
                })
                .RequireAuthorization()
                .WithName("ProductRistAssessmentEndpoint")
                .Produces<ProductRiskAssessmentResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Get /pra
            routeGroup.MapGet("/", GetAllProductRiskAssessmentEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get all product risk assesstment for risk management"
                })
                .WithName("GetAllProductRiskAssessmentEndpoint")
                .Produces<List<GetAllProductRiskAssessentDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Get /pra
            routeGroup.MapGet("/get-all-product-risk-assessment-result", GetAllProductRiskAssessmentResultEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get all product risk assesstment result"
                })
                .WithName("GetAllProductRiskAssessmentResultEndpoint")
                .Produces<List<GetAllProductRiskAssessentDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Post /pra/initiate-assess-risk
            routeGroup.MapPost("/initiate-assess-risk", PostAssessRiskEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<InitiateAssessRiskDto>>()
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Create assess risk"
                })
                .RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("PostAssessRiskEndpoint")
                .Produces<Ok>()
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status500InternalServerError);

            // Get /par/00000000-0000-0000-0000-000000000000/product-risk-assessment
            routeGroup.MapGet("/{productRiskAssessmentId:guid}/product-risk-assessment", ProductRiskAssessmentEndpointGetPRA.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get details of the specified product risk assessment"
                })
                .WithName("ProductRiskAssessmentEndpointGetPRA")
                .Produces<ProcessRiskAssessmentByIdDTO>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Get /par/00000000-0000-0000-0000-000000000000
            routeGroup.MapGet("/{productRiskAssessmentId:guid}", GetProductAssessRiskByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get details of the specified product assess risk"
                })
                .WithName("GetProductAssessRiskByIdEndpoint")
                .Produces<ProductAssessRiskDTOList>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Post /par/approve-product-risk-assessment
            routeGroup.MapPost("/approve-product-risk-assessment", ApproveProductRiskAssessmentEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ApproveProductRiskAssessment>>()
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Approve specified product risk assessment"
                })
                .WithName("ApproveProductRiskAssessmentEndpoint")
                .Produces<Ok>()
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Post /par/reject-product-risk-assessment
            routeGroup.MapPost("/reject-product-risk-assessment", RejectProductRiskAssessmentEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<RejectProductRiskAssessmentDto>>()
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Reject specified product risk assessment"
                })
                .WithName("RejectProductRiskAssessmentEndpoint")
                .Produces<Ok>()
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            return app;
        }
        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {
            builder.AddScoped<IRepository<ProductRiskAssessment>, Repository<ProductRiskAssessment>>();
            builder.AddScoped<IRepository<Document>, Repository<Document>>();
            builder.AddScoped<IRepository<ProductAssessRisk>, Repository<ProductAssessRisk>>();
            builder.AddScoped<ICurrentUserService, CurrentUserService>();
            builder.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            // Register validation
            builder.AddScoped<IValidator<ProductRiskAssessmentDTO>, ProductRiskAssessmentDTOValidator>();
            builder.AddScoped<IValidator<InitiateAssessRiskDto>, InitiateAssessRiskDtoValidator>();
            builder.AddScoped<IValidator<AssessRiskDto>, AssessRiskDtoValidator>();
            builder.AddScoped<IValidator<ApproveProductRiskAssessment>, ApproveProductRiskAssessmentValidator>();
            builder.AddScoped<IValidator<ProductAssessRiskForApproval>, ProductAssessRiskForApprovalValidator>();
            builder.AddScoped<IValidator<RejectProductRiskAssessmentDto>, RejectProductRiskAssessmentValidator>();

            return builder;
        }
    }
}
