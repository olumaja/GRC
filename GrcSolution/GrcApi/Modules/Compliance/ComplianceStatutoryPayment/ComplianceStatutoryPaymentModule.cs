using Arm.GrcApi.Modules.Compliance.CompliancePlanning;
using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.RiskManagement.BIA;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.Compliance.ComplianceStatutoryPayment;
using GrcApi.Modules.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Arm.GrcApi.Modules.Compliance.ComplianceStatutoryPayment
{
    public class ComplianceStatutoryPaymentModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {
            // this line creates the endpoint header on swagger
            var routeGroup = app.MapGroup("/statutory-payment").WithTags(new string[] { "Compliance Statutory Payment" });
            var routeGroup2 = app.MapGroup("/compliance-level-reports").WithTags(new string[] { "Compliance Level Reports" });

            //GET /statutory-payment
            routeGroup.MapGet("/", ComplianceStatutoryPaymentEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Statutory Payment: Statutory payment view for HCM"
                })
               .RequireAuthorization("HROfficerOnly")
               .WithName("ComplianceStatutoryPaymentEndpoint")
               .Produces<List<ComplianceStatutoryPaymentResponse>>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /paying-unit
            routeGroup.MapGet("/paying-unit", GetPendingPaymentForPaymentUnit.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Statutory Payment: Statutory payment view for FINCON"
                })
               .RequireAuthorization("FINCONOnly")
               .WithName("GetPendingPaymentForPaymentUnit")
               .Produces<List<ComplianceStatutoryPaymentResponse>>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /treasury
            routeGroup.MapGet("/treasury", GetPendingPaymentForTreasury.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Statutory Payment: Statutory payment view for Treasury"
                })
               .RequireAuthorization("TREASURYOnly")
               .WithName("GetPendingPaymentForTreasury")
               .Produces<List<ComplianceStatutoryPaymentResponse>>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /initiate-statutory-payment
            routeGroup.MapPost("/initiate-statutory-payment", InitiatePaymentEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ComplianceStatutoryPaymentDto>>()
                .Accepts<ComplianceStatutoryPaymentDto>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Statutory Payment: Initiate payment"
                })
                .RequireAuthorization("HROfficerOnly")
                .WithName("InitiatePaymentEndpoint")
                .Produces<InitiateStatutoryPaymentResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /update-initiate-statutory-payment
            routeGroup.MapPost("/update-initiate-statutory-payment", InitiatePaymentUpdateEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<UpdateComplianceStatutoryPaymentDto>>()
                .Accepts<UpdateComplianceStatutoryPaymentDto>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Statutory Payment: Update initiate payment"
                })
                .RequireAuthorization("HROfficerOnly")
                .WithName("InitiatePaymentUpdateEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /process-statutory-payment
            routeGroup.MapPost("/process-statutory-payment", POSTProcessPaymentEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ProcessPayment>>()
                .Accepts<ProcessPayment>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Statutory Payment: FINCON attached processed documents, this also serve as update"
                })
                .RequireAuthorization("FINCONOnly")
                .WithName("POSTProcessPaymentEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /submit-statutory-payment
            routeGroup.MapPost("/submit-statutory-payment", PayingUnitResponseEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<MakePaymentRequest>>()
                .Accepts<MakePaymentRequest>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Statutory Payment: Treasury submit prove of payment to statutory body, this also serve as update"
                })
                .RequireAuthorization("TREASURYOnly")
                .WithName("PayingUnitResponseEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-statutory-payment/00000000-0000-0000-0000-000000000000
            routeGroup.MapGet("/get-statutory-payment/{id:guid}", GetStatutoryPaymentByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Statutory Payment: Get Statutory Payment by id"
                })
                .WithName("GetStatutoryPaymentByIdEndpoint")
                .Produces<GetStatutoryPaymentByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /approve-statutory-payment
            routeGroup.MapPost("/approve-statutory-payment", ApproveStatutoryPaymentEndpoint.HandleAsync)
                .Accepts<ApproveStatutoryPaymentRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Statutory Payment: HR officer approve payment"
                })
                .RequireAuthorization("HROfficerOnly")
                .WithName("ApproveStatutoryPaymentEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /reject-statutory-payment
            routeGroup.MapPost("/reject-statutory-payment", RejectStatutoryPaymentEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<RejectStatutoryPaymentRequest>>()
                .Accepts<RejectStatutoryPaymentRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Statutory Payment: HR officer reject payment"
                })
                .RequireAuthorization("HROfficerOnly")
                .WithName("RejectStatutoryPaymentEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /compliance-level
            routeGroup.MapGet("/compliance-level", ComplianceLevelEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Statutory Payment: Compliance officer view compliance level"
                })
               .RequireAuthorization("ComplianceOfficerOnly")
               .WithName("ComplianceLevelEndpoint")
               .Produces<List<ComplianceLevelResponse>>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /compliance-reports
            routeGroup2.MapGet("/compliance-planning", CompliancePlanningReportEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Reports: Compliance officers to view compliance planning reports"
                })
               .RequireAuthorization("ComplianceOfficerOnly")
               .WithName("CompliancePlanningReportEndpoint")
               .Produces<List<CompliancePlanningReport>>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /compliance-reports
            routeGroup2.MapGet("/regulatory-payment", ComplianceRegulatoryPaymentReportEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Reports: Compliance officers to view regulatory payment reports"
                })
               .RequireAuthorization("ComplianceOfficerOnly")
               .WithName("ComplianceRegulatoryPaymentReportEndpoint")
               .Produces<List<ComplianceRegulatoryPaymentReport>>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /compliance-reports
            routeGroup2.MapGet("/statutory-payment", ComplianceStatutoryPaymentReportEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Reports: Compliance officers to view statutory payment reports"
                })
               .RequireAuthorization("ComplianceOfficerOnly")
               .WithName("ComplianceStatutoryPaymentReportEndpoint")
               .Produces<List<ComplianceStatutoryPaymentReport>>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            return app;
        }

        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {
            builder.AddScoped<IRepository<ComplianceStatutoryPayment>, Repository<ComplianceStatutoryPayment>>();

            builder.AddScoped<IValidator<ComplianceStatutoryPaymentDto>, ComplianceStatutoryPaymentDtoValidator>();
            builder.AddScoped<IValidator<UpdateComplianceStatutoryPaymentDto>, UpdateComplianceStatutoryPaymentDtoValidator>();
            builder.AddScoped<IValidator<MakePaymentRequest>, MakePaymentRequestValidator>();
            builder.AddScoped<IValidator<RejectStatutoryPaymentRequest>, RejectStatutoryPaymentRequestValidation>();

            return builder;
        }
    }
}
