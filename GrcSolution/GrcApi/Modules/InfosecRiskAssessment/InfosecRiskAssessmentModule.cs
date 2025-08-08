using Arm.GrcApi.Modules.AntivirusAssessment;
using Arm.GrcApi.Modules.IncidentManagement;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.AntivirusAssessment;
using GrcApi.Modules.InfosecRiskAssessment;
using Microsoft.AspNetCore.Mvc;

namespace Arm.GrcApi.Modules.InfosecRiskAssessment
{
    public class InfosecRiskAssessmentModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {
            var routeGroup = app.MapGroup("infosec-risk-assessment").WithTags(new string[] { "Infosec Risk Assessment" });

           //POST /notify-iso-champion
            routeGroup.MapPost("/notify-iso-champion", NotifyISOChampionEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<NotifyISOChampionRequest>>()
                .Accepts<NotifyISOChampionRequest>(GRCConstants.applicationOrJson)
               .WithOpenApi(operation => new(operation)
               {
                   Summary = "Infosec Risk Assessment: Notify ISO Champion"
               })
                .RequireAuthorization("InfoSecOfficerOnly")
                .WithName("NotifyISOChampionEndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /notify-iso-champions
            routeGroup.MapGet("/notify-iso-champions", GetNotifyISOChampionEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Infosec Risk Assessment: Get Notified ISO Champions"
                })
               .RequireAuthorization("InfoSecOfficerOnly")
               .WithName("GetNotifyISOChampionEndpoint")
               .Produces<PaginatedGetNotifyISOChampionResp>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
                      
            //Patch /commence-assessment
            routeGroup.MapPost("/commence-assessment", InitiateISORiskAssessmentEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<InfosecRiskAssessmentDto>>()
                .Accepts<InfosecRiskAssessmentDto>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Infosec Risk Assessment:  ISO risk champion commence assessment"
                })
                .RequireAuthorization("InfoSecISORiskChampionOnly")
                .WithName("InitiateISORiskAssessmentEndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /update-commence-assessment
            routeGroup.MapPatch("/update-commence-assessment", UpdateISORiskAssessmentEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<UpdateInfosecRiskAssessmentDto>>()
                .Accepts<UpdateInfosecRiskAssessmentDto>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Infosec Risk Assessment:  ISO risk champion commence assessment"
                })
                .RequireAuthorization("InfoSecISORiskChampionOnly")
                .WithName("UpdateISORiskAssessmentEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /view-commence-assessment
            routeGroup.MapGet("/view-commence-assessment", InfosecRiskAssessmentEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Infosec Risk Assessment:  ISO risk champion and Unit head view assessment"
                })
               .RequireAuthorization()
               .WithName("InfosecRiskAssessmentEndpoint")
               .Produces<PaginatedInfosecRiskAssessmentResponse>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /view-commence-assessment/{RiskId}
            routeGroup.MapGet("/view-commence-assessment/{RiskId:guid}", GetISORiskAssessmentByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Infosec Risk Assessment: View risk assessment by Id"
                })
               .RequireAuthorization()
               .WithName("GetISORiskAssessmentByIdEndpoint")
               .Produces<InfosecRiskAssessmentByIdResponse>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /get-approved-risk
            routeGroup.MapGet("/get-approved-risk", GetApprovedRiskEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Infosec Risk Assessment:  Get approved risk assessment"
                })
               .RequireAuthorization()
               .WithName("GetApprovedRiskEndpoint")
               .Produces<PaginatedGetApprovedRiskResponse>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /get-unit-title/{team}
            routeGroup.MapGet("/get-unit-title/{unit}", GetUnitTitleEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Infosec Risk Assessment:  Get unit title"
                })
               .RequireAuthorization()
               .WithName("GetUnitTitleEndpoint")
               .Produces<PaginatedGetUnitTitleResponse>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /approve-assessment
            routeGroup.MapPatch("/approve-reject-assessment", RiskAssessmentApprovalEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ApprovalDto>>()
                .Accepts<ApprovalDto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Infosec Risk Assessment: ISO unit head approve or reject risk assessment"
                })
                .RequireAuthorization("InfoSecISOUnitHeadOnly")
                .WithName("RiskAssessmentApprovalEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /add-anexture
            routeGroup.MapPatch("/add-anexture", AddAnextureEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<AddAnexture>>()
                .Accepts<AddAnexture>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Infosec Risk Assessment:  Infosec officer add anextures"
                })
                .RequireAuthorization("InfoSecOfficerOnly")
                .WithName("AddAnextureEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /get-annexture
            routeGroup.MapGet("/get-annexture", GetAnnextureEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Infosec Risk Assessment:  Get annexture"
                })
               .RequireAuthorization()
               .WithName("GetAnnextureEndpoint")
               .Produces<PaginatedGetUnitTitleResponse>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            return app;
           
        }

        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {
            builder.AddScoped<IRepository<NotifyISORiskAssessmentModel>, Repository<NotifyISORiskAssessmentModel>>();
            builder.AddScoped<IRepository<InfosecRiskAssessmentModel>, Repository<InfosecRiskAssessmentModel>>();
            builder.AddScoped<IRepository<PlannedControl>, Repository<PlannedControl>>();
            builder.AddScoped<IRepository<ExistingPrimaryControl>, Repository<ExistingPrimaryControl>>();
            builder.AddScoped<IRepository<Annexture>, Repository<Annexture>>();
            builder.AddScoped<IRepository<PlannedControlAnnexture>, Repository<PlannedControlAnnexture>>();        
            builder.AddScoped<IRepository<ExistingPrimaryControlAnnexture>, Repository<ExistingPrimaryControlAnnexture>>();


            builder.AddScoped<IValidator<NotifyISOChampionRequest>, NotifyISOChampionRequestValidator>();
            builder.AddScoped<IValidator<InfosecRiskAssessmentDto>, InfosecRiskAssessmentDtoValidator>();
            builder.AddScoped<IValidator<UpdateInfosecRiskAssessmentDto>, UpdateInfosecRiskAssessmentDtoValidator>();
            builder.AddScoped<IValidator<PlannedControlDto>, PlannedControlDtoValidator>();
            builder.AddScoped<IValidator<ExistingPrimaryControlDto>, ExistingPrimaryControlDtoValidator>();
            builder.AddScoped<IValidator<ApprovalDto>, ApprovalDtoValidator>();
            builder.AddScoped<IValidator<AddAnexture>, AddAnextureValidator>();
            builder.AddScoped<IValidator<AddPlannedControlAnexture>, AddPlannedControlAnextureValidator>();
            builder.AddScoped<IValidator<AddPExistingPrimaryControlAnexture>, AddPExistingPrimaryControlAnextureValidator>();
            builder.AddScoped<IValidator<AnextureRequest>, AnextureRequestValidator>();

            return builder;
        }


    }
}
