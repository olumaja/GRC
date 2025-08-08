using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Arm.GrcApi.Modules.OperationControl
{
    public class OperationControlModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {
            var routeGroup = app.MapGroup("operation-control").WithTags(new string[] { "Operation Control" });

            ////POST /create-operation-exception
            routeGroup.MapPost("/create-operation-exception", OperationControlEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<OperationControlDto>>()
                .Accepts<OperationControlDto>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Operation Control: Create Operation Control Exception"
                })
                .RequireAuthorization()
                .WithName("OperationControlEndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);                       

            // GET /operation-exception/action-owner
            routeGroup.MapGet("/operation-exception/action-owner", GetActionOwnerOperationExceptionEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Operation Control: Get all operation exception assigned to an action owner"
                })
                .RequireAuthorization()
               .WithName("GetActionOwnerOperationExceptionEndpoint")
               .Produces<PaginatedGetExceptionsResp>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /operation-exception/operation-control-staff
            routeGroup.MapGet("/operation-exception/operation-control-staff", GetOperationExceptionEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Operation Control: Get all operation exceptions for operation control staff"
                })
               .RequireAuthorization()
               .WithName("GetOperationExceptionEndpoint")
               .Produces<PaginatedGetExceptionsResp>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            //GET /internal-control-actionowner/{operationExecptionId:guid}
            routeGroup.MapGet("/operation-exception/{operationExecptionId:guid}", GetOperationExceptionByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Operation Control: Get operation exception by id for action owner"
                })
                .RequireAuthorization()
                .WithName("GetOperationExceptionByIdEndpoint")
                .Produces<GetOperationExceptionsByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /update-actionowner-response
            routeGroup.MapPatch("/update-actionowner-response", UpdateActionOwnerFeedbackEndpoint.HandleAsync)                
                .AddEndpointFilter<ValidationFilter<UpdateActionownerReq>>()
                .Accepts<UpdateActionownerReq>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Operation Control: Update action owner response"
                })
                .RequireAuthorization()
                .WithName("UpdateActionOwnerFeedbackEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /supervisor-reassign-exception
            routeGroup.MapPatch("/supervisor-reassign-exception", SupervisorReAssignExceptionEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ReAssignExceptionReq>>()
                .Accepts<ReAssignExceptionReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Operation Control: Supervisor Re-assigned ExceptionEndpoint"
                })
                .RequireAuthorization("OperationControlSupervisorOnly")
                .WithName("SupervisorReAssignExceptionEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /approve-operation-exception
            routeGroup.MapPost("/approve-operation-exception", ApproveOperationExceptionEndpoint.HandleAsync)
                .Accepts<ApproveExceptionRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Operation Control: Officer can only approve as an Observation or as an Exception"
                })
                .RequireAuthorization()
                .WithName("ApproveOperationExceptionEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
                       
            //POST /reject-operation-exception
            routeGroup.MapPost("/reject-operation-exception", RejectOperationExceptionEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<RejectExceptionDto>>()
                .Accepts<RejectExceptionDto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Operation Control: Reject created Internal Control"
                })
                .RequireAuthorization()
                .WithName("RejectOperationExceptionEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /update-operation-exception
            routeGroup.MapPatch("/update-operation-exception", UpdateExceptionForOfficerEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<UpdateOperationControlDto>>()
                .Accepts<UpdateOperationControlDto>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Operation Control: Update Operation Control Exception For officer"
                })
                .RequireAuthorization()
                .WithName("UpdateExceptionForOfficerEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /operation-exception/exception-report
            routeGroup.MapGet("/operation-exception-report", ExceptionReportEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Operation Control: Get operation control exception report and download file"
                })
               .RequireAuthorization()
               .WithName("ExceptionReportEndpoint")
               .Produces<ExceptionRecordResponse>(StatusCodes.Status200OK)
               .Produces<List<string>>(StatusCodes.Status400BadRequest)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /operation-exception/{exceptionId:guid}
            routeGroup.MapGet("/operation-exception-report/{exceptionId:guid}", ExceptionReportDetailEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Operation Control: Get operation exception report detail"
                })
                .RequireAuthorization()
                .WithName("ExceptionReportDetailEndpoint")
                .Produces<GetOperationExceptionsByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            return app;
        }

        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {
            builder.AddScoped<IRepository<OperationControl>, Repository<OperationControl>>();

            builder.AddScoped<IValidator<OperationControlDto>, OperationControlDtoValidator>();
            builder.AddScoped<IValidator<UpdateOperationControlDto>, UpdateOperationControlDtoValidator>();
            builder.AddScoped<IValidator<ApproveExceptionRequest>, ApproveExceptionRequestValidation>();
            builder.AddScoped<IValidator<RejectExceptionDto>, RejectExceptionDtoValidation>();
            builder.AddScoped<IValidator<UpdateActionownerReq>, UpdateActionownerReqValidator>();
            builder.AddScoped<IValidator<ReAssignExceptionReq>, ReAssignExceptionReqValidation>();

            return builder;
        }
    }
}
