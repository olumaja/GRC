using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.Domain.Risk;
using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.RiskManagement;
using GrcApi.Modules.RiskManagement.RiskEvent;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared.RestHelper;

using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

using static GrcApi.Modules.RiskManagement.RiskEventEndpointGetRiskEffectCategory;
using static GrcApi.Modules.RiskManagement.RiskEventEndpointGetRiskEventAssessment;

namespace Arm.GrcApi.Modules.RiskManagement
{
    public class RiskEventModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {
            #region RiskEventEndpoints
            // this line creates the endpoint header on swagger
            var routeGroup = app.MapGroup("/risk-events").WithTags(new string[] { "Risk Events" });

            // GET /risk-events
            routeGroup.MapGet("/", RiskEventEndpointGetAllRiskEvent.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "retrieves the list of logged events for individual and members of risk management. "
                })
                 .RequireAuthorization()
                .WithName("GetRiskEvents")
                .Produces<IList<RiskEventDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /risk-events/statistics
            routeGroup.MapGet("/statistics", RiskEventEndpointGetRiskEventStatistics.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get risk event statistics using status"
                })
                 //.RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("RiskEventEndpointGetRiskEventStatistics")
                .Produces<IList<RiskEventDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /risk-events/00000000-0000-0000-0000-000000000000
            routeGroup.MapGet("/{riskEventId:guid}", RiskEventEndpointGetRiskEventDetails.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get risk event details"
                })
                 .RequireAuthorization()
                .WithName("GetRiskEventDetails")
                .Produces<RiskEventDto>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // POST /risk-events
            routeGroup.MapPost("/", RiskEventEndpointPostRiskEvent.HandleAsync)
                .Accepts<CreateRiskEventDto>("multipart/form-data")
                .AddEndpointFilter<ValidationFilter<CreateRiskEventDto>>()
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "log new risk event"
                })
                .RequireAuthorization()
                .WithName("LogRiskEvent")
                .Produces<CreateRiskEventResponseDto>(StatusCodes.Status201Created)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // POST /risk-events/00000000-0000-0000-0000-000000000000/assessment
            routeGroup.MapPost("/assessment", RiskEventEndpointPostRiskEventAssessment.HandleAsync)
                .AddEndpointFilter<ValidationFilter<RiskAssessmentDto>>()
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "log risk event assessment"
                })
                .RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("LogRiskEventAssessment")
                .Produces<Ok>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /risk-events/00000000-0000-0000-0000-000000000000/assessment
            routeGroup.MapGet("/{riskEventId:guid}/assessment", RiskEventEndpointGetRiskEventAssessment.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get risk event assessment"
                })
                .RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("GetRiskEventAssessment")
                .Produces<RiskAssessmentResponseDto>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /risk-events
            routeGroup.MapGet("/event-types", RiskEventTypeEndpointGetAllRiskEventType.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Retrive the list of risk event type."
                })
                 //.RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("GetRiskEventTypes")
                .Produces<IList<RiskEventTypeDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            routeGroup.MapGet("/event-types/{riskEventTypeId:guid}/categories", RiskEventTypeEndpointGetEventCategory.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get array of risk event type categories with their subcategories"
                })
                // .RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("GetRiskEventTypeCategories")
                .Produces<IList<RiskEventRiskDriverCategoryDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
            #endregion

            #region RiskDriver
            // GET /risk-drivers
            routeGroup.MapGet("/risk-drivers", RiskEventRiskDriverEndpointGetAllRiskDrivers.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Retrieves the list of risk drivers for risk events. "
                })
                 //.RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("GetRiskEventRiskDrivers")
                .Produces<IList<RiskDriverDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /risk-events/risk-drivers/00000000-0000-0000-0000-000000000000/categories
            routeGroup.MapGet("/risk-drivers/{riskDriverId:guid}/categories", RiskEventRiskDriverEndpointGetRiskDriverCategories.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get categories and sub-categories for specified risk driver"
                })
                // .RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("GetRiskDriverCategories")
                .Produces<IList<RiskEventRiskDriverCategoryDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
            #endregion

            #region RiskEffectCategory And Recoverytypes(deprecated)
            // GET /riskeffectcategory
            routeGroup.MapGet("/effect-categories", RiskEventEndpointGetRiskEffectCategory.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Retrieve list of risk effect categories"
                })
                 //.RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("GetRiskEffectCategories")
                .Produces<IList<RiskEffectCategoryDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET risk-event/recovery-types
            routeGroup.MapGet("/recovery-types", RiskEventEndpointGetRecoveryTypes.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Retrieve list of recovery types"
                })
                // .RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("RiskEventEndpointGetRecoveryTypes")
                .Produces<IList<RecoveryTypeDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Get risk-event/action-owners
            routeGroup.MapGet("/action-owners", RiskEventEndpointGetActionOwners.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Retieve all staff name, email and department that matches the search query"
                })
                 //.RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("RiskEventEndpointGetActionOwners")
                .Produces<IList<StaffNameEmail>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Post risk-event/specified-action-owners
            routeGroup.MapPost("/specified-action-owners", RiskEventEndpointPostSpecifiedActionOwners.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ActionOwnerDto>>()
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Specified staff name, email and departent that matches the search query"
                })
                .WithName("RiskEventEndpointPostSpecifiedActionOwners")
                .Produces<IList<StaffNameEmail>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            return app;
            #endregion
        }

        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {
            builder.AddScoped<IRepository<RiskEvent>, Repository<RiskEvent>>();
            builder.AddScoped<IRepository<RiskEventType>, Repository<RiskEventType>>();
            builder.AddScoped<IRepository<RiskEventTypeCategory>, Repository<RiskEventTypeCategory>>();
            builder.AddScoped<IRepository<RiskDriver>, Repository<RiskDriver>>();
            builder.AddScoped<IRepository<RiskDriverCategory>, Repository<RiskDriverCategory>>();
            builder.AddScoped<IRepository<RiskDriverSubCategory>, Repository<RiskDriverSubCategory>>();
            builder.AddScoped<IRepository<RiskEffectCategory>, Repository<RiskEffectCategory>>();
            builder.AddScoped<IRepository<RecoveryType>, Repository<RecoveryType>>();
            builder.AddScoped<IRepository<LossManagement>, Repository<LossManagement>>();
            builder.AddScoped<IRepository<ActionManagement>, Repository<ActionManagement>>();
            builder.AddScoped<IRepository<RiskEventManagement>, Repository<RiskEventManagement>>();
            builder.AddScoped<IRepository<RiskEffectManagement>, Repository<RiskEffectManagement>>();
            builder.AddScoped<ICurrentUserService, CurrentUserService>();

            builder.AddScoped<IValidator<CreateRiskEventDto>, CreateRiskEventDtoValidator>();
            builder.AddScoped<IValidator<RiskAssessmentDto>, RiskAssessmentDtoValidator>();
            builder.AddScoped<IValidator<CreateEventManagementDto>, CreateEventManagementDtoValidator>();
            builder.AddScoped<IValidator<CreateEffectManagementDto>, CreateEffectManagementDtoValidator>();
            builder.AddScoped<IValidator<CreateActionManagementDto>, CreateActionManagementDtoValidator>();
            builder.AddScoped<IValidator<CreateLossManagementDto>, CreateLossManagementDtoValidator>();
            builder.AddScoped<IValidator<ActionOwnerDto>, ActionOwnerDtoValidator>();

            builder.AddHttpClient("getStaffClient", client =>
            {
                client.Timeout = new TimeSpan(0, 0, 60);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            builder.AddScoped<IRestHelper, RestHelper>();
            return builder;
        }
    }
}
