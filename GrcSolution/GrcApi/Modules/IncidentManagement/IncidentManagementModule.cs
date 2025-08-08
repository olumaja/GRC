using Arm.GrcApi.Modules.OperationControl;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcApi.Modules;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Arm.GrcApi.Modules.IncidentManagement;
using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcApi.Modules.RiskManagement.AuditPlan;

namespace GrcApi.Modules.IncidentManagement
{
    public class IncidentManagementModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {
            var routeGroup = app.MapGroup("incidence-management").WithTags(new string[] { "Incidence Management" });
            var routeGroup2 = app.MapGroup("log-management").WithTags(new string[] { "Log Management" });

            //POST /log-new-incidence
            routeGroup.MapPost("/log-new-incidence", LogNewIncidenceEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<LogIncidenceRequest>>()
                .Accepts<LogIncidenceRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Incidence Management: Log new incidence"
                })
                .RequireAuthorization()
                .WithName("LogNewIncidenceEndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /logged-incidence
            routeGroup.MapGet("/logged-incidence", GetLoggedIncidenceEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Incidence Management: Get all logged incidence"
                })
               //infosec staff only
               .RequireAuthorization("InfoSecOfficerOnly")
               .WithName("GetLoggedIncidenceEndpoint")
               .Produces<PaginatedGetLogIncidenceResp>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /action-owner-logged-incidence
            routeGroup.MapGet("/action-owner-logged-incidence", ActionOwnerGetLoggedIncidenceEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Incidence Management: Action Owner get all logged incidence assigned to them"
                })
               .RequireAuthorization()
               .WithName("ActionOwnerGetLoggedIncidenceEndpoint")
               .Produces<PaginatedGetLogIncidenceResp>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /logged-incidence/{incidencId:guid}"
            routeGroup.MapGet("/logged-incidence/{incidencId:guid}", GetLoggedIncidenceByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Incidence Management: Get logged incidence by id"
                })
                .RequireAuthorization()
                .WithName("GetLoggedIncidenceByIdEndpoint")
                .Produces<GetLogIncidenceById>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /infosec-assign-logged-incident
            routeGroup.MapPatch("/infosec-assign-logged-incident", AssignLoggedIncidenceEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<InfosecAssignLogIncidenceReq>>()
                .Accepts<InfosecAssignLogIncidenceReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Incidence Management: Infosec assign logged incidence to an action owner"
                })
                //infosec staff only
                .RequireAuthorization("InfoSecOfficerOnly")
                .WithName("AssignLoggedIncidenceEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /action-owner-update
            routeGroup.MapPatch("/action-owner-update", ActionOwnerUpdateEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ActionownerResponseReq>>()
                .Accepts<ActionownerResponseReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Incidence Management: Action owner response to the incidence logged"
                })
                .RequireAuthorization()
                .WithName("ActionOwnerUpdateEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /action-owner-feedback
            routeGroup.MapGet("/action-owner-feedback", GetAllActionOwnerIncidenceFeedbackEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Incidence Management: Get all action owners incidence feedback"
                })
               //infosec staff only
               .RequireAuthorization("InfoSecOfficerOnly")
               .WithName("GetAllActionOwnerIncidenceFeedbackEndpoint")
               .Produces<PaginatedGetLogIncidenceResp>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            routeGroup.MapGet("/incidence-management-options", IncidenceMgtOptionsEndpoint.HandleAsync)
             .WithOpenApi(operation => new(operation)
             {
              Summary = "Incidence Management: Incidence Management Options"
             })
             .WithName("IncidenceMgtOptionsEndpoint")
            .Produces<string>(StatusCodes.Status200OK)
            .Produces<List<string>>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /log-pam
            routeGroup2.MapPost("/log-pam", LogNewPAMEndpoint.HandleAsync)
                 .AddEndpointFilter<ValidationFilter<NewPAMRequest>>()
                .Accepts<NewPAMRequest>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Log Management: Log PAM"
                })
                .RequireAuthorization("InfoSecOfficerOnly")
                .WithName("LogNewPAMEndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /log-casp
            routeGroup2.MapPost("/log-casp", LogNewCASPEndpoint.HandleAsync)                
                 .AddEndpointFilter<ValidationFilter<NewCASPRequest>>()
                .Accepts<NewCASPRequest>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Log Management: Log CASP"
                })
                .RequireAuthorization("InfoSecOfficerOnly")
                .WithName("LogNewCASPEndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /log-siem
            routeGroup2.MapPost("/log-siem", LogRequestSIEMEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<LogManagementDto>>()
                .Accepts<LogManagementDto>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Log Management: Log SIEM"
                })
                .RequireAuthorization("InfoSecOfficerOnly")
                .WithName("LogRequestSIEMEndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /log-dam
            routeGroup2.MapPost("/log-dam", LogDAMEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<LogDAMDto>>()
                .Accepts<LogDAMDto>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Log Management: Log DAM"
                })
                .RequireAuthorization("InfoSecOfficerOnly")
                .WithName("LogDAMEndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /log-fim
            routeGroup2.MapPost("/log-fim", LogRequestFIMEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<LogFIMDto>>()
                .Accepts<LogFIMDto>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Log Management: Log FIM"
                })
                .RequireAuthorization("InfoSecOfficerOnly")
                .WithName("LogRequestFIMEndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /log-dlp
            routeGroup2.MapPost("/log-dlp", LogRequestDLPEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<LogDLPDto>>()
                .Accepts<LogDLPDto>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Log Management: Log DLP"
                })
                .RequireAuthorization("InfoSecOfficerOnly")
                .RequireAuthorization()
                .WithName("LogRequestDLPEndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /log-edr
            routeGroup2.MapPost("/log-edr", LogRequestEDREndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<LogERDDto>>()
                .Accepts<LogERDDto>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Log Management: Log EDR"
                })
                .RequireAuthorization("InfoSecOfficerOnly")
                .WithName("LogRequestEDREndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /action-owner-logged-mgt
            routeGroup2.MapGet("/action-owner-logged-mgt", ActionOwnerGetLoggedMgtEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
               {
                    Summary = "Log Management: Action Owner get all logged management assigned to them"
                })
               .RequireAuthorization()
               .WithName("ActionOwnerGetLoggedMgtEndpoint")
               .Produces<PaginatedGetLogMgtResp>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /infosec-owner-owner-feedback
            routeGroup2.MapGet("/infosec-owner-owner-feedback", GetAllActionOwnerFeedbackEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Log Management: InfoSec Staff to get all log management"
                })
               .RequireAuthorization("InfoSecOfficerOnly")
               .WithName("GetAllActionOwnerFeedbackEndpoint")
               .Produces<PaginatedGetLogMgtResp>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /log-mgt/{logmgtId:guid}"
            routeGroup2.MapGet("/log-mgt/{logmgtId:guid}", GetLoggedMgtByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Log Management: Get logged Mgt by id"
                })
                .RequireAuthorization()
                .WithName("GetLoggedMgtByIdEndpoint")
                .Produces<GetLogMgtSIEMById>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /log-management-report
            routeGroup2.MapGet("/log-management-report", LogManagementReportEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Log Management: Display report and export"
                })
               .RequireAuthorization("InfoSecOfficerOnly")
               .WithName("LogManagementReportEndpoint")
               .Produces<PaginatedGetLogMgtResp>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /action-owner-feedback
            routeGroup2.MapPatch("/action-owner-feedback", ActionOwnerfeedbackEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ActionownerFeedbackReq>>()
                .Accepts<ActionownerFeedbackReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Log Management: Action owner feedback on the logged Mgt"
                })
                .RequireAuthorization()
                .WithName("ActionOwnerfeedbackEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /infosec-response
            routeGroup2.MapPatch("/infosec-response", InfoSecResponseEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<InfoSecResponseReq>>()
                .Accepts<InfoSecResponseReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Log Management: InfoSec staff view action owner feedback on the logged Mgt"
                })
                .RequireAuthorization("InfoSecOfficerOnly")
                .WithName("InfoSecResponseEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
                      
            return app;
        }

        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {
            builder.AddScoped<IRepository<IncidentManagementLog>, Repository<IncidentManagementLog>>();

            builder.AddScoped<IValidator<LogIncidenceRequest>, LogIncidenceRequestValidator>();
            builder.AddScoped<IValidator<InfosecAssignLogIncidenceReq>, InfosecAssignLogIncidenceReqValidator>();
            builder.AddScoped<IValidator<ActionownerResponseReq>, ActionownerResponseReqValidator>();
            builder.AddScoped<IValidator<UpdateStatusToClosed>, UpdateStatusToClosedValidator>();
            builder.AddScoped<IValidator<ActionownerFeedbackReq>, ActionownerFeedbackReqValidator>();
            builder.AddScoped<IValidator<InfoSecResponseReq>, InfoSecResponseReqValidator>();
            builder.AddScoped<IValidator<NewCASPRequest>, NewCASPRequestValidator>();
            builder.AddScoped<IValidator<NewPAMRequest>, NewPAMRequestValidator>();
            builder.AddScoped<IValidator<LogManagementDto>, LogManagementDtoValidator>();
            builder.AddScoped<IValidator<LogFIMDto>, LogFIMDtoValidator>();
            builder.AddScoped<IValidator<LogERDDto>, LogERDDtoValidator>();
            builder.AddScoped<IValidator<LogDLPDto>, LogDLPDtoValidator>();
            builder.AddScoped<IValidator<LogDAMDto>, LogDAMDtoValidator>();
            builder.AddScoped<IRepository<LogManagement>, Repository<LogManagement>>();
            builder.AddScoped<IRepository<CASPLog>, Repository<CASPLog>>();
            builder.AddScoped<IRepository<DAMLog>, Repository<DAMLog>>();
            builder.AddScoped<IRepository<DLPLog>, Repository<DLPLog>>();
            builder.AddScoped<IRepository<EDRLog>, Repository<EDRLog>>();
            builder.AddScoped<IRepository<SIEMLog>, Repository<SIEMLog>>();
            builder.AddScoped<IRepository<PAMLog>, Repository<PAMLog>>();
            builder.AddScoped<IRepository<FIMLog>, Repository<FIMLog>>();

            return builder;
        }
    }
}
