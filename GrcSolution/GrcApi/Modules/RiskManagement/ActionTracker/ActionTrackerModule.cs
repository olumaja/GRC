using Arm.GrcApi.Modules.RiskManagement.ActionTracker;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain.RiskControlSelfAssessment;
using Arm.GrcTool.Domain.RiskEvent;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.RiskManagement.ActionTracker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using GrcApi.Modules.Shared.Helpers;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.Risk;

namespace Arm.GrcApi.Modules.RiskManagementActionTracker
{
    public class ActionTrackerModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {
            // this line creates the endpoint header on swagger
            var routeGroup = app.MapGroup("/action-tracker").WithTags(new string[] { "Action Tracker" });

            //GET /apt/{startDate}/{endDate}
            routeGroup.MapGet("get-riskidentification-actionPlanPtracker", GetRiskIdentificationWithCountEndpoint.HandleAsync)
               .WithOpenApi(operation => new(operation)
               {
                   Summary = "Gets Risk Identification with their count Action plan Tracker"
               })
               //.RequireAuthorization("RiskManagmentEmployeeOnly")
               .WithName("GetRiskIdentificationWithCountEndpoint")
               .Produces<GetRiskEventReportTrackers>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
           
            routeGroup.MapGet("get-rcsa-actionplantracker", GetRCSAWithCountActionTrackerEndpoint.HandleAsync)
               .WithOpenApi(operation => new(operation)
               {
                   Summary = "Gets RCSA with their count Action plan Tracker"
               })
               //.RequireAuthorization("RiskManagmentEmployeeOnly")
               .WithName("GetRCSAWithCountActionTrackerEndpoint")
               .Produces<GetRCSAReportTrackers>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /apt/report
            routeGroup.MapGet("get-riskidentification-actionplantracker-report", GetRiskIdentificationActionTrackerEndpoint.HandleAsync)
               .WithOpenApi(operation => new(operation)
               {
                   Summary = "Gets Risk Identification Action Tracker by date range and unit id. StartDate and Enddate format: yyyy-mm-dd"
               })
               //.RequireAuthorization("RiskManagmentEmployeeOnly")
               .WithName("GetRiskIdentificationActionTrackerEndpoint")
               .Produces<ActionTrackerDtoRiskReport>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /apt/{startDate}/{endDate}
            routeGroup.MapGet("get-riskidentification-actionplantracker/{startDate}/{endDate}", GetRiskIdentificationActionTrackerReportEndpoint.HandleAsync)
               .WithOpenApi(operation => new(operation)
               {
                   Summary = "Gets Risk Identification Action Tracker Report by date range. StartDate and Enddate format: yyyy-mm-dd"
               })
               //.RequireAuthorization("RiskManagmentEmployeeOnly")
               .WithName("GetRiskIdentificationActionTrackerReportEndpoint")
               .Produces<ActionTrackerDtoRiskReport>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // get-riskidentification-actionplantracker/{unitId:guid}/{startDate}/{endDate}
            routeGroup.MapGet("/get-riskidentification-actionplantracker/{unitId:guid}/{startDate}/{endDate}", ActionTrackerEndpointGetRiskEventReport.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get risk identification report. StartDate and Enddate format: yyyy-mm-dd"
                })
                //.RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("ActionTrackerEndpointGetRiskEventReport")
                .Produces<List<ActionTrackerDtoRiskReport>>(StatusCodes.Status200OK)
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status500InternalServerError);


            //GET /apt/{startDate}/{endDate}
            routeGroup.MapGet("get-rcsa-actionplantracker/{startDate}/{endDate}", GetRCSAActionTrackerEndpoint.HandleAsync)
               .WithOpenApi(operation => new(operation)
               {
                   Summary = "Gets RCSA Action Tracker by date range. StartDate and Enddate format: yyyy-mm-dd"
               })
               //.RequireAuthorization("RiskManagmentEmployeeOnly")
               .WithName("GetRCSAActionTrackerEndpoint")
               .Produces<ActionTrackerRCSAReport>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /apt/{unitId}/{startDate}/{endDate}  
            routeGroup.MapGet("/get-rcsa-reports/{unitId:guid}/{startDate}/{endDate}", GetRCSAReportsEndpoint.HandleAsync)
               .WithOpenApi(operation => new(operation)
               {
                   Summary = "Gets RCSA reports by date range and unitId. StartDate and Enddate format: yyyy-mm-dd"
               })
               //.RequireAuthorization("RiskManagmentEmployeeOnly")
               .WithName("GetRCSAReportsEndpoint")
               .Produces<List<ActionTrackerRCSAReport>>(StatusCodes.Status200OK)
               .Produces<string>(StatusCodes.Status400BadRequest)
               .Produces(StatusCodes.Status500InternalServerError); 

            //GET /apt/{startDate}/{endDate}  
            routeGroup.MapGet("/get-pra-reports/{startDate}/{endDate}", GetPRAReportByDateEndpoint.HandleAsync)
               .WithOpenApi(operation => new(operation)
               {
                   Summary = "Gets Product Risk Assessment reports by date range. StartDate and Enddate format: yyyy-mm-dd"
               })
               //.RequireAuthorization("RiskManagmentEmployeeOnly")
               .WithName("GetPRAReportByDateEndpoint")
               .Produces<GetPRAListReports>(StatusCodes.Status200OK)
               .Produces<string>(StatusCodes.Status400BadRequest)
               .Produces(StatusCodes.Status500InternalServerError);

            //GET /apt/{startDate}/{endDate}/{unitId}  
            routeGroup.MapGet("/get-pra-reports/{unitId:guid}/{startDate}/{endDate}", GetPRAReportsEndpoint.HandleAsync)
               .WithOpenApi(operation => new(operation)
               {
                   Summary = "Gets Product Risk Assessment reports by date range and unitId. StartDate and Enddate format: yyyy-mm-dd"
               })
               //.RequireAuthorization("RiskManagmentEmployeeOnly")
               .WithName("GetPRAReportsEndpoint")
               .Produces<GetPRAListReports>(StatusCodes.Status200OK)
               .Produces<string>(StatusCodes.Status400BadRequest)
               .Produces(StatusCodes.Status500InternalServerError);


            // /at/get-bia-report/yyyy-MM-dd/yyyy-MM-dd
            routeGroup.MapGet("/get-bia-report/{startDate}/{endDate}", ActionTrackerEndpointGetBIAReportByDate.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get business impact analysis report by date range"
                })
                //.RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("ActionTrackerEndpointGetBIAReportByDate")
                .Produces<List<BIAReportDto>>(StatusCodes.Status200OK)
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status500InternalServerError);

         
            // /at/get-bia-report/00000000-0000-0000-0000-000000000000/yyyy-MM-dd/yyyy-MM-dd
            routeGroup.MapGet("/get-bia-report/{unitId:guid}/{startDate}/{endDate}", ActionTrackerEndpointGetBIAReport.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get business impact analysis report"
                })
                //.RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("ActionTrackerEndpointGetBIAReport")
                .Produces<List<BIAReportDto>>(StatusCodes.Status200OK)
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status500InternalServerError);
                                  

            //GET /reports
            routeGroup.MapGet("/", GetTotalModuleReportsEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get total count of all the request in each module"
                })
                //.RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("GetTotalModuleReportsEndpoint")
               .Produces<GetTotalModuleReports>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
           
            //GET /reports
            routeGroup.MapGet("get-total-records/{startDate}/{endDate}", GetTotalReportsWithDateRangeEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get total count of all the request in each module with date range. StartDate and Enddate format: yyyy-mm-dd"
                })
                //.RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("GetTotalReportsWithDateRangeEndpoint")
               .Produces<GetTotalModuleReports>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);                   
                  
            // Post /at/update-action-progress-risk-event
            routeGroup.MapPost("/update-action-progress-risk-event", ActionTrackerEndpointUpdateActionManagment.HandleAsync)
                .AddEndpointFilter<ValidationFilter<UpdateActionProgressAndStatusDto>>()
                .Accepts<UpdateActionProgressAndStatusDto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Update action progress and status"
                })
                //.RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("ActionTrackerEndpointUpdateActionManagment")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // Post /at/update-action-progress-RCSA
            routeGroup.MapPost("/update-action-progress-rcsa", ActionTrackerEndpointUpdateRCSA.HandleAsync)
                .AddEndpointFilter<ValidationFilter<UpdateActionAndStatusForRCSADto>>()
                .Accepts<UpdateActionAndStatusForRCSADto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Update action progress and status for process inherent risk control"
                })
                //.RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("ActionTrackerEndpointUpdateRCSA")
                 .Produces<Ok>()
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //// Get    /at/GetReportsOnAllModulesByRiskManagementEndpoint/Id ::to view the reports on all modules in Risk management
            routeGroup.MapGet("/ViewEventDescriptionByIDEndpoint/{id:guid}", ViewEventDescriptionByIDEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View the reports on all modules in Risk management"
                })
                //.RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("GetReportsOnAllModulesByRiskManagement")
                .Produces<ViewEventDescriptionDTO>(StatusCodes.Status200OK)
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //// Get    /at/GetOutstandingActionItemsPlusPointSummary/Id ::get details on outstanding action item plus point summary(inherent risk, control, test)
            routeGroup.MapGet("/ViewActionSummeryByIDEndpoint/{Id:guid}", ViewActionSummaryByIDEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get details on outstanding action item plus point summary(inherent risk, control, test)"
                })
                //.RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("GetDetailsOnOutstandingActionItemsPlusPointSummaryEndpoint")
                .Produces<ViewActionItemSummaryDTO>(StatusCodes.Status200OK)
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            return app;
        }

        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {
            builder.AddScoped<IRepository<ActionManagement>, Repository<ActionManagement>>();
            builder.AddScoped<IRepository<ProcessInherentRiskControl>, Repository<ProcessInherentRiskControl>>();
            builder.AddScoped<IRepository<RiskControlSelfAssessment>, Repository<RiskControlSelfAssessment>>();
            builder.AddScoped<IRepository<RiskEvent>, Repository<RiskEvent>>();

            builder.AddScoped<IRepository<Unit>,  Repository<Unit>>();
            builder.AddScoped<IRepository<RiskEffectManagement>, Repository<RiskEffectManagement>>();
            builder.AddScoped<IRepository<RiskEventManagement>, Repository<RiskEventManagement>>();
            builder.AddScoped<IRepository<LossManagement>, Repository<LossManagement>>();
            builder.AddScoped<IRepository<Department>, Repository<Department>>();
            builder.AddScoped<IRepository<BusinessEntity>, Repository<BusinessEntity>>();
            builder.AddScoped<IRepository<RiskEventType>, Repository<RiskEventType>>();
            builder.AddScoped<IRepository<RiskEventTypeCategory>, Repository<RiskEventTypeCategory>>();
            builder.AddScoped<IRepository<RiskEventTypeSubCategory>, Repository<RiskEventTypeSubCategory>>();
            builder.AddScoped<IRepository<RiskDriver>, Repository<RiskDriver>>();
            builder.AddScoped<IRepository<RiskDriverCategory>, Repository<RiskDriverCategory>>();
            builder.AddScoped<IRepository<RiskDriverSubCategory>, Repository<RiskDriverSubCategory>>();
            builder.AddScoped<IRepository<RiskEffectCategory>, Repository<RiskEffectCategory>>();

            builder.AddScoped<ICurrentUserService, CurrentUserService>();
            builder.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            //Register validation
            builder.AddScoped<IValidator<UpdateActionProgressAndStatusDto>, UpdateActionProgressAndStatusDtoValidator>();
            builder.AddScoped<IValidator<UpdateActionAndStatusForRCSADto>, UpdateActionAndStatusForRCSADtoValidator>();

            return builder;
        }
    }
}
