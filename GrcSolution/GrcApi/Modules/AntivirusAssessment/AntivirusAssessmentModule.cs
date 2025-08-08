using Arm.GrcApi.Modules.Shared;
using Arm.GrcApi.Modules.VulnerabilityManagement;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.AntivirusAssessment;
using GrcApi.Modules.VulnerabilityManagement;
using Microsoft.AspNetCore.Mvc;

namespace Arm.GrcApi.Modules.AntivirusAssessment
{
    public class AntivirusAssessmentModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {
            var routeGroup = app.MapGroup("antivirus-assessment").WithTags(new string[] { "Antivirus Assessment" });

            //POST /antivirus/assessment/file/upload
            routeGroup.MapPost("/antivirus/assessment/file/upload", AntivirusAssessmentFileUploadEndpoint.HandleAsync)
                 .AddEndpointFilter<ValidationFilter<AntivirusAssessmentFileUploadReq>>()
                .Accepts<AntivirusAssessmentFileUploadReq>("multipart/form-data")
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Antivirus Assessment: Antivirus Assessment Excel File Upload "
                })
               .RequireAuthorization("InfoSecOfficerOnly")
                .WithName("AntivirusAssessmentFileUploadEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /infosec/antivirus-assessment
            routeGroup.MapGet("/infosec/antivirus-assessment", InfosecGetAntivirusAssessmentEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Antivirus Assessment: Infosec get all Antivirus Assessment to assign an action owner by id"
                })
               //infosec staff
               .RequireAuthorization("InfoSecOfficerOnly")
               .WithName("InfosecGetAntivirusAssessmentEndpoint")
               .Produces<PaginatedGetAntivirusAssessmentResp>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET  /infosec/antivirus/{antivirusAssessmentFileId:guid}"
            routeGroup.MapGet("/infosec/antivirus/{antivirusAssessmentFileId:guid}", InfosecGetAntivirusAssessmentByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Antivirus Assessment: Get Antivirus Assessment to assign an action owner by id"
                })
                //infosec staff
                .RequireAuthorization("InfoSecOfficerOnly")
                .WithName("InfosecGetAntivirusAssessmentByIdEndpoint")
                .Produces<InfosecGetAntivirusAssessmentByIdDetail>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /infosec/antivirus/assign-action-owner
            routeGroup.MapPatch("/infosec/antivirus/assign-action-owner", InfoSecAssignedAntivirusToActionOwnerEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<InfoSecAssignAntivirusToActionOwnerReq>>()
                .Accepts<InfoSecAssignAntivirusToActionOwnerReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Antivirus Assessment:  InfoSec staff assign an action owner to the Antivirus Assessment raised"
                })
               .RequireAuthorization("InfoSecOfficerOnly")
                .WithName("InfoSecAssignedAntivirusToActionOwnerEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /antivirus-assessment/action-owner
            routeGroup.MapGet("/antivirus-assessment/action-owner", ActionOwnerGetAntivirusAssessmentEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Antivirus Assessment: Action Owner get all Antivirus Assessment assigned to them"
                })
               .RequireAuthorization()
               .WithName("ActionOwnerGetAntivirusAssessmentEndpoint")
               .Produces<PaginatedGetAntivirusAssessmentResp>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET  /antivirus-assessment/{antivirusAssessmentFileId:guid}"
            routeGroup.MapGet("/antivirus-assessment/{antivirusAssessmentFileId:guid}", GetAntivirusAssessmentByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Antivirus Assessment: Get Antivirus Assessment Detail by id"
                })
                 .RequireAuthorization()
                .WithName("GetAntivirusAssessmentByIdEndpoint")
                .Produces<GetAntivirusAssessmentById>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /approve/inactive-sensors/antivirus
            routeGroup.MapPatch("/approve/inactive-sensors/antivirus", ApproveInactiveSensorsAntivirusEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ApproveAntivirusAssessmentRequest>>()
                .Accepts<ApproveAntivirusAssessmentRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Antivirus Assessment: Approve Inactive Sensors Antivirus. antivirusId is the InactiveSensorsId"
                })
                .RequireAuthorization("InfoSecOfficerOnly")
                .WithName("ApproveInactiveSensorsAntivirusEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /approve/reduced-functionality/antivirus
            routeGroup.MapPatch("/approve/reduced-functionality/antivirus", ApproveReducedFunctionalityAntivirusEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ApproveAntivirusAssessmentRequest>>()
                .Accepts<ApproveAntivirusAssessmentRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Antivirus Assessment: Approve Reduced Functionality Antivirus. antivirusId is the ReducedFunctionalityMode Id"
                })
                .RequireAuthorization("InfoSecOfficerOnly")
                .WithName("ApproveReducedFunctionalityAntivirusEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);                      

            //Patch /submit-approved/antivirus
            routeGroup.MapPatch("/submit-approved/antivirus", SubmitAntivirusApprovedEndpoints.HandleAsync)
                .AddEndpointFilter<ValidationFilter<SubmitAntivirusAssessmentDt0>>()
                .Accepts<SubmitAntivirusAssessmentDt0>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Antivirus Assessment: Submit approved Antivirus Assessment"
                })
                .RequireAuthorization("InfoSecOfficerOnly")
                .WithName("SubmitAntivirusApprovedEndpoints")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /reject/reduced-functionality/antivirus
            routeGroup.MapPatch("/reject/reduced-functionality/antivirus", RejectReducedFunctionalityModeEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<RejectAntivirusAssessmentReq>>()
                .Accepts<RejectAntivirusAssessmentReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Antivirus Assessment:  Reject Reduced Functionality Mode. antivirusId is the ReducedFunctionalityMode Id"
                })
                .RequireAuthorization("InfoSecOfficerOnly")
                .WithName("RejectReducedFunctionalityModeEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /reject/inactive-sensors/antivirus
            routeGroup.MapPatch("/reject/inactive-sensors/antivirus", RejectInactiveSensorsEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<RejectAntivirusAssessmentReq>>()
                .Accepts<RejectAntivirusAssessmentReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Antivirus Assessment:  Reject Inactive Sensors. antivirusId is the InactiveSensorsId"
                })
                .RequireAuthorization("InfoSecOfficerOnly")
                .WithName("RejectInactiveSensorsEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET infosec/review/action-owner-feedback
            routeGroup.MapGet("/infosec/review/action-owner-feedback", InfosecReviewActionOwnerFeedbackpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Antivirus Assessment: Infosec get all action owner feedback for the approval or rejection"
                })
               .RequireAuthorization("InfoSecOfficerOnly")
               .WithName("InfosecReviewActionOwnerFeedbackpoint")
               .Produces<PaginatedGetAntivirusAssessmentResp>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /inactive-sensors/action-owner-response
            routeGroup.MapPatch("/inactive-sensors/action-owner-response", AntivirusInactiveActionOwnerResponseEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Antivirus Assessment:  Action owner response to inactive sensor"
                })
                .RequireAuthorization()
                .WithName("AntivirusInactiveActionOwnerResponseEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /reduce-functionality/action-owner-response
            routeGroup.MapPatch("/reduce-functionality/action-owner-response", AntivirusReduceFunctionalityActionOwnerResponseEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Antivirus Assessment:  Action owner response to reduce functionality mode"
                })
                .RequireAuthorization()
                .WithName("AntivirusReduceFunctionalityActionOwnerResponseEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /inactive-sensors/update-action-owner-response
            routeGroup.MapPatch("/inactive-sensors/update-action-owner-response", UpdateInactiveSensorsAntivirusEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<UpdateInactivesensorsDto>>()
                .Accepts<UpdateInactivesensorsDto>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Antivirus Assessment:  Action owner can update response on inactive sensor"
                })
                .RequireAuthorization()
                .WithName("UpdateInactiveSensorsAntivirusEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /inactive-sensors/update-action-owner-response
            routeGroup.MapPatch("/reduce-functionality/update-action-owner-response", UpdateReduceFunctionalityAntivirusEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<UpdateReduceFunctionalityDto>>()
                .Accepts<UpdateReduceFunctionalityDto>(GRCConstants.multipartOrFormData)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Antivirus Assessment:  Action owner can update response on reduce functionality mode"
                })
                .RequireAuthorization()
                .WithName("UpdateReduceFunctionalityAntivirusEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            return app;
        }

        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {
            builder.AddScoped<IRepository<AntivirusAssessmentModel>, Repository<AntivirusAssessmentModel>>();
            builder.AddScoped<IRepository<ReducedFunctionalityMode>, Repository<ReducedFunctionalityMode>>();
            builder.AddScoped<IRepository<InactiveSensors>, Repository<InactiveSensors>>();
            builder.AddScoped<IValidator<RejectAntivirusAssessmentReq>, RejectAntivirusAssessmentReqValidator>();
            builder.AddScoped<IValidator<ApproveAntivirusAssessmentRequest>, ApproveAntivirusAssessmentRequestValidator>();
            builder.AddScoped<IValidator<InfoSecAssignAntivirusToActionOwnerReq>, InfoSecAssignAntivirusToActionOwnerReqValidator>();
            builder.AddScoped<IValidator<AntivirusAssessmentFileUploadReq>, AntivirusAssessmentFileUploadReqValidator>();
            builder.AddScoped<IValidator<SubmitAntivirusAssessmentDt0>, SubmitAntivirusAssessmentDt0Validator>();
            builder.AddScoped<IValidator<UpdateInactivesensorsDto>, UpdateInactivesensorsDtoValidator>();
            builder.AddScoped<IValidator<UpdateReduceFunctionalityDto>, UpdateUpdateReduceFunctionalityDtoValidator>();

            return builder;
        }
    }
}
