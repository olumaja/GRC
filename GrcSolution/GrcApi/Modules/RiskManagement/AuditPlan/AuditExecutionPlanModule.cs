using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using static Arm.GrcApi.Modules.RiskManagement.AuditPlan.ApproveAuditAnnouncementMemoEndpoint;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class AuditExecutionPlanModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {

            // this line creates the endpoint header on swagger
            var routeGroup = app.MapGroup("/aep").WithTags(new string[] { "Audit Execution Plan" });

            //GET /auditexecutionplan/viewauditexecutionplansummary
            routeGroup.MapGet("/auditexecutionplan/viewauditexecutionplansummary", ViewAuditExecutionPlanEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View Internal Audit Execution Plan Summary for the Year - Supervisor Screen"
                })
                .RequireAuthorization()
                .WithName("ViewAuditExecutionPlanEndpoint")
                .Produces<ViewAuditExecutionPlan>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /auditexecutionplan/auditannouncementmemo
            routeGroup.MapPost("/auditexecutionplan/auditannouncementmemo", CommenceEngagementAuditAnnouncementMemoEndpoint.HandleAsync)
                .Accepts<AuditAnnouncementMemoRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Commence Engagement - Audit Announcement Memo Execution Plan"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .AddEndpointFilter<ValidationFilter<AuditAnnouncementMemoRequest>>()
                .WithName("CommenceEngagementAuditAnnouncementMemoEndpoint")
                .Produces<CommenceEngagementAuditexecutionResp>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /auditexecutionplan/engagementletter
            routeGroup.MapPost("/auditexecutionplan/engagementletter", CommenceEngagementEngagementLetterEndpoint.HandleAsync)
                .Accepts<EngagementLetterAuditExecutionReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Commence Engagement - Audit engagement letter Plan"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .AddEndpointFilter<ValidationFilter<EngagementLetterAuditExecutionReq>>()
                .WithName("CommenceEngagementEngagementLetterEndpoint")
                .Produces<CommenceEngagementAuditexecutionResp>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /auditexecutionplan/informationRequirement
            routeGroup.MapPost("/auditexecutionplan/informationRequirement", CommenceEngagementInformationRequiremenEndpoint.HandleAsync)
                .Accepts<InformationRequirementRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Commence Engagement - Information Requirement Execution Plan"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .AddEndpointFilter<ValidationFilter<InformationRequirementRequest>>()
                .WithName("CommenceEngagementInformationRequiremenEndpoint")
                .Produces<CommenceEngagementAuditexecutionResp>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            //POST /auditexecutionplan/auditplanningmemo
            routeGroup.MapPost("/auditexecutionplan/auditplanningmemo", CommenceEngagementAuditPlanningMemoEndpoint.HandleAsync)
                .Accepts<AuditPlanningMemoAuditExecutionReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Commence Engagement - Audit Planning Memo Execution Plan"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .AddEndpointFilter<ValidationFilter<AuditPlanningMemoAuditExecutionReq>>()
                .WithName("CommenceEngagementAuditPlanningMemoEndpoint")
                .Produces<CommenceEngagementAuditexecutionResp>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            //POST /auditexecutionplan/auditaprogam
            routeGroup.MapPost("/auditexecutionplan/auditprogam", CommenceEngagementAuditProgramEndpoint.HandleAsync)
                .Accepts<PostAuditProgramRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Commence Engagement - Audit Program"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .AddEndpointFilter<ValidationFilter<PostAuditProgramRequest>>()
                .WithName("CommenceEngagementAuditProgramEndpoint")
                .Produces<CommenceEngagementAuditexecutionResp>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplan/get-commenceengagementbyId
            routeGroup.MapGet("/auditexecutionplan/get-commenceengagementbyId", CommenceEngagementSummaryEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get Commence Engagement By Id for the supervisor to Approval"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .WithName("CommenceEngagementSummaryEndpoint")
                .Produces<ViewCommenceEngagementSummaryResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            //GET /auditexecutionplan/get-auditplanningmemo/{commenceengagementid:guid}/{team} 
            routeGroup.MapGet("/auditexecutionplan/get-auditplanningmemo/{commenceengagementid:guid}/{team}", GetAuditPlanningMemoAuditExecutionByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get Audit Planning Memo Audit Execution By Commenceengagementid" 
                })
                .RequireAuthorization() 
                .WithName("GetAuditPlanningMemoAuditExecutionByIdEndpoint")
                .Produces<GetAuditPlanningMemoAuditExecutionResp>(StatusCodes.Status200OK) 
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplan/get-informationRequirement/{commenceengagementid:guid}/{team} 
            routeGroup.MapGet("/auditexecutionplan/get-informationRequirement/{commenceengagementid:guid}/{team}", GetInformationRequirementByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get Information Requirement Audit Execution By Commenceengagementid"
                })
                .RequireAuthorization()
                .WithName("GetInformationRequirementByIdEndpoint")
                .Produces<GetInformationRequirementResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplan/get-engagementletter/{commenceengagementid:guid}/{team} 
            routeGroup.MapGet("/auditexecutionplan/get-engagementletter/{commenceengagementid:guid}/{team}", GetEngagementLetterByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get Engagement Letter Audit Execution By Commenceengagementid"
                })
                .RequireAuthorization()
                .WithName("GetEngagementLetterByIdEndpoint")
                .Produces<GetEngagementLetterAuditExecutionResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplan/get-auditannouncementMemo/{commenceengagementid:guid}/{team} 
            routeGroup.MapGet("/auditexecutionplan/get-auditannouncementmemo/{commenceengagementid:guid}/{team}", GetAuditAnnouncementMemoByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get Audit Announcement Memo Audit Execution By Commenceengagementid"
                })
                .RequireAuthorization()
                .WithName("GetAuditAnnouncementMemoByIdEndpoint")
                .Produces<GetAuditAnnouncementMemoAuditExecutionResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplan/get-auditprogram/{commenceengagementid:guid}/{team} 
            routeGroup.MapGet("/auditexecutionplan/get-auditprogram/{commenceengagementid:guid}/{team}", GetAuditProgramByCommenceIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get Audit Program By Commenceengagementid"
                })
                .RequireAuthorization()
                .WithName("GetAuditProgramByCommenceIdEndpoint")
                .Produces<GetAuditProgramResponse>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);                     

            //POST /auditexecutionplan/approve-auditannouncementMemo   
            routeGroup.MapPost("/auditexecutionplan/approve-auditannouncementmemo", ApproveAuditAnnouncementMemoEndpoint.HandleAsync)
                .Accepts<ApproveAuditAnnouncementMemoRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Approve Audit Announcement Memo Audit Execution"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .AddEndpointFilter<ValidationFilter<ApproveAuditAnnouncementMemoRequest>>()
                .WithName("ApproveAuditAnnouncementMemoEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /auditexecutionplan/approve-engagementletter  
            routeGroup.MapPost("/auditexecutionplan/approve-engagementletter", ApproveEngagementLetterEndpoint.HandleAsync)
                .Accepts<ApproveEngagementLetterRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Approve Engagement Letter Audit Execution"
                })
                 .RequireAuthorization("InternalAuditSupervisorOnly")
                .AddEndpointFilter<ValidationFilter<ApproveEngagementLetterRequest>>()
                .WithName("ApproveEngagementLetterEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /auditexecutionplan/approve-informationrequirement 
            routeGroup.MapPost("/auditexecutionplan/approve-informationrequirement", ApproveInformationRequirementEndpoint.HandleAsync)
                .Accepts<ApproveInformationRequirementRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Approve Information Requirement Audit Execution"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .AddEndpointFilter<ValidationFilter<ApproveInformationRequirementRequest>>()
                .WithName("ApproveInformationRequirementEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /auditexecutionplan/approve-auditplanningmemo  
            routeGroup.MapPost("/auditexecutionplan/approve-auditplanningmemo", ApproveAuditPlanningMemoEndpoint.HandleAsync)
                .Accepts<ApproveAuditPlanningMemoRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Approve Audit Planning Memo Audit Execution"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .AddEndpointFilter<ValidationFilter<ApproveAuditPlanningMemoRequest>>()
                .WithName("ApproveAuditPlanningMemoEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /auditexecutionplan/approve-auditprogram  
            routeGroup.MapPost("/auditexecutionplan/approve-auditprogram", ApproveAuditProgramEndpoint.HandleAsync)
                .Accepts<ApproveAuditProgramRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Approve Audit Program Audit Execution"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .AddEndpointFilter<ValidationFilter<ApproveAuditProgramRequest>>()
                .WithName("ApproveAuditProgramEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /auditexecutionplan/reject-auditannouncementMemo  
            routeGroup.MapPost("/auditexecutionplan/reject-auditannouncementmemo", RejectAuditAnnouncementMemoEndpoint.HandleAsync)
                .Accepts<RejectAuditAnnouncementMemoRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Reject Audit Announcement Memo Audit Execution"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .AddEndpointFilter<ValidationFilter<RejectAuditAnnouncementMemoRequest>>()
                .WithName("RejectAuditAnnouncementMemoEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /auditexecutionplan/reject-engagementletter   
            routeGroup.MapPost("/auditexecutionplan/reject-engagementletter", RejectEngagementLetterEndpoint.HandleAsync)
                .Accepts<RejectEngagementLetterRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Reject Engagement Letter Audit Execution"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .AddEndpointFilter<ValidationFilter<RejectEngagementLetterRequest>>()
                .WithName("RejectEngagementLetterEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /auditexecutionplan/reject-informationrequirement   
            routeGroup.MapPost("/auditexecutionplan/reject-informationrequirement", RejectInformationRequirementEndpoint.HandleAsync)
                .Accepts<RejectInformationRequirementRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Reject Information Requirement Audit Execution"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .AddEndpointFilter<ValidationFilter<RejectInformationRequirementRequest>>()
                .WithName("RejectInformationRequirementEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /auditexecutionplan/reject-auditplanningmemo 
            routeGroup.MapPost("/auditexecutionplan/reject-auditplanningmemo", RejectAuditPlanningMemoEndpoint.HandleAsync)
                .Accepts<RejectAuditPlanningMemoRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Reject Audit Planning Memo Audit Execution"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .AddEndpointFilter<ValidationFilter<RejectAuditPlanningMemoRequest>>()
                .WithName("RejectAuditPlanningMemoEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /auditexecutionplan/reject-auditprogram  
            routeGroup.MapPost("/auditexecutionplan/reject-auditprogram", RejectAuditProgramEndpoint.HandleAsync)
                .Accepts<RejectAuditProgramRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Reject Audit Program Audit Execution"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .AddEndpointFilter<ValidationFilter<RejectAuditProgramRequest>>()
                .WithName("RejectAuditProgramEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
                
            //POST /auditexecutionplan/initiate-workpaper
            routeGroup.MapPost("/auditexecutionplan/initiate-workpaper", InitiateWorkPaperEndpoint.HandleAsync)
                .Accepts<PostWorkPaperRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Commence Engagement - Initiate work paper"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .AddEndpointFilter<ValidationFilter<PostWorkPaperRequest>>()
                .WithName("InitiateWorkPaperEndpoint")
                .Produces<WorkPaperResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplan/get-workpaper/{auditProgramId}/{team}
            routeGroup.MapGet("/auditexecutionplan/get-workpaper/{auditProgramId:guid}/{team}", GetWorkPaperByAuditIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Commence Engagement - Get work paper by audit program id"
                })
                .RequireAuthorization()
                .WithName("GetWorkPaperByAuditIdEndpoint")
                .Produces<GetWorkpaperResponse>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /auditexecutionplan/initiate-audit-findings
            routeGroup.MapPost("/auditexecutionplan/initiate-audit-findings", InitiateAuditFindsEndpoint.HandleAsync)
                .Accepts<PostAuditFindingsRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Commence Engagement - Initiate audit findings"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .AddEndpointFilter<ValidationFilter<PostAuditFindingsRequest>>()
                .WithName("InitiateAuditFindsEndpoint")
                .Produces<AuditFindingsResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplan/get-audit-findings/{auditProgramId}/{team}
            routeGroup.MapGet("/auditexecutionplan/get-audit-findings/{auditProgramId:guid}/{team}", GetAuditFindingsEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Commence Engagement - Get audit findings by audit program id"
                })
                .RequireAuthorization()
                .WithName("GetAuditFindingsEndpoint")
                .Produces<GetAduitFindingsResponse>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /auditexecutionplan/approve-work-paper
            routeGroup.MapPost("/auditexecutionplan/approve-work-paper", ApproveWorkpaperEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Commence Engagement - Approve work paper"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .AddEndpointFilter<ValidationFilter<ApproveWorkpaperDto>>()
                .Accepts<ApproveWorkpaperDto>(GRCConstants.applicationOrJson)
                .WithName("ApproveWorkpaperEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /auditexecutionplan/reject-work-paper
            routeGroup.MapPost("/auditexecutionplan/reject-work-paper", RejectWorkpaperEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Commence Engagement - Reject work paper"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .AddEndpointFilter<ValidationFilter<RejectWorkpaperDto>>()
                .Accepts<RejectWorkpaperDto>(GRCConstants.applicationOrJson)
                .WithName("RejectWorkpaperEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /auditexecutionplan/approve-audit-findings
            routeGroup.MapPost("/auditexecutionplan/approve-audit-findings", ApproveAuditFindingsEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Commence Engagement - Approve audit findings"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .AddEndpointFilter<ValidationFilter<ApproveAuditFindingsDto>>()
                .Accepts<ApproveAuditFindingsDto>(GRCConstants.applicationOrJson)
                .WithName("ApproveAuditFindingsEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /auditexecutionplan/reject-audit-findings
            routeGroup.MapPost("/auditexecutionplan/reject-audit-findings", RejectAuditFindingsEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Commence Engagement - Reject audit findings"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .AddEndpointFilter<ValidationFilter<RejectWorkpaperDto>>()
                .Accepts<RejectWorkpaperDto>(GRCConstants.applicationOrJson)
                .WithName("RejectAuditFindingsEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
                      
            //GET /auditexecutionplan/viewauditexecutionplansummary
            routeGroup.MapGet("/auditexecutionplan/summary", ViewAuditExecutionPlanSummaryEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Internal Audit Execution Plan Summary for the Year - Supervisor Screen"
                })
                .RequireAuthorization()
                .WithName("ViewAuditExecutionPlanSummaryEndpoint")
                .Produces<ViewAuditExecutionPlanSummaryResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
           
            //Patch /auditexecutionplan/auditannouncementmemo
            routeGroup.MapPatch("/auditexecutionplan/update/auditannouncementmemo", UpdateAuditAnnouncementMemoEndpoint.HandleAsync)
                .Accepts<UpdateAuditAnnouncementMemoRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Commence Engagement - Update Audit Announcement Memo Execution Plan"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .AddEndpointFilter<ValidationFilter<UpdateAuditAnnouncementMemoRequest>>()
                .WithName("UpdateAuditAnnouncementMemoEndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /auditexecutionplan/update/engagementletter
            routeGroup.MapPatch("/auditexecutionplan/update/engagementletter", UpdateEngagementLetterEndpoint.HandleAsync)
                .Accepts<UpdateEngagementLetterAuditExecutionReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Commence Engagement - Update audit engagement letter Plan"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .AddEndpointFilter<ValidationFilter<UpdateEngagementLetterAuditExecutionReq>>()
                .WithName("UpdateEngagementLetterEndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /auditexecutionplan/update/informationRequirement
            routeGroup.MapPatch("/auditexecutionplan/update/informationRequirement", UpdateInformationRequiremenEndpoint.HandleAsync)
                .Accepts<UpdateInformationRequirementRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Commence Engagement - Update Information Requirement Execution Plan"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .AddEndpointFilter<ValidationFilter<UpdateInformationRequirementRequest>>()
                .WithName("UpdateInformationRequiremenEndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            //Patch /auditexecutionplan/update/auditplanningmemo
            routeGroup.MapPatch("/auditexecutionplan/update/auditplanningmemo", UpdateAuditPlanningMemoEndpoint.HandleAsync)
                .Accepts<UpdateAuditPlanningMemoAuditExecutionReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Commence Engagement - Update Audit Planning Memo Execution Plan"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .AddEndpointFilter<ValidationFilter<UpdateAuditPlanningMemoAuditExecutionReq>>()
                .WithName("UpdateAuditPlanningMemoEndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /auditexecutionplan/update-auditprogram 
            routeGroup.MapPatch("/auditexecutionplan/update-auditprogram", UpdateAuditProgramEndpoint.HandleAsync)
                .Accepts<UpdateAuditProgramRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Update Audit Program"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .AddEndpointFilter<ValidationFilter<UpdateAuditProgramRequest>>()
                .WithName("UpdateAuditProgramEndpoint")
                .Produces<CommenceEngagementAuditexecutionResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /auditexecutionplan/update/workpaper
            routeGroup.MapPatch("/auditexecutionplan/update/workpaper", UpdateWorkPaperEndpoint.HandleAsync)
                .Accepts<UpdatePostWorkPaperRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Commence Engagement - Update Initiated work paper"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .AddEndpointFilter<ValidationFilter<UpdatePostWorkPaperRequest>>()
                .WithName("UpdateWorkPaperEndpoint")
                .Produces<WorkPaperResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //Patch /auditexecutionplan/update-audit-findings
            routeGroup.MapPatch("/auditexecutionplan/update-audit-findings", UpdateInitiateAuditFindsEndpoint.HandleAsync)
                .Accepts<PostAuditFindingsRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Commence Engagement - Update initiated audit findings"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .AddEndpointFilter<ValidationFilter<UpdatePostAuditFindingsRequest>>()
                .WithName("UpdateInitiateAuditFindsEndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            routeGroup.MapGet("/team-options", TeamOptionsEndpoint.HandleAsync)
           .WithOpenApi(operation => new(operation)
           {
               Summary = "Commence Engagement: Team options"
           })
           .WithName("TeamOptionsEndpoint")
           .Produces<string>(StatusCodes.Status200OK)
           .Produces<List<string>>(StatusCodes.Status400BadRequest)
           .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            return app;
        }
        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {
            
            builder.AddScoped<IRepository<AuditPlanningMemoPlanningTimeline>, Repository<AuditPlanningMemoPlanningTimeline>>();
            builder.AddScoped<IRepository<InformationRequirementAuditExecution>, Repository<InformationRequirementAuditExecution>>();
            builder.AddScoped<IRepository<EngagementLetterAuditExecution>, Repository<EngagementLetterAuditExecution>>();
            builder.AddScoped<IRepository<AuditPlanningMemoAuditExecution>, Repository<AuditPlanningMemoAuditExecution>>();
            builder.AddScoped<IRepository<CommenceEngagementAuditexecution>, Repository<CommenceEngagementAuditexecution>>();
            builder.AddScoped<IRepository<AuditProgramAuditExecution>, Repository<AuditProgramAuditExecution>>();
            builder.AddScoped<IRepository<EngagementLetterReportDistributionList>, Repository<EngagementLetterReportDistributionList>>();
            builder.AddScoped<IRepository<EngagementLetterAuditExecutionDuration>, Repository<EngagementLetterAuditExecutionDuration>>();
            builder.AddScoped<IRepository<AuditAnnouncementMemoAuditExecution>, Repository<AuditAnnouncementMemoAuditExecution>>();
            builder.AddScoped<IRepository<WorkPaper>, Repository<WorkPaper>>();
            builder.AddScoped<IRepository<AuditFindings>, Repository<AuditFindings>>();
            builder.AddScoped<ICurrentUserService, CurrentUserService>();
            builder.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            builder.AddScoped<IValidator<PostWorkPaperRequest>, PostWorkPaperRequestValidation>();
            builder.AddScoped<IValidator<PostAuditFindingsRequest>, PostAuditFindingsRequestValidation>();
            builder.AddScoped<IValidator<ApproveAuditFindingsDto>, ApproveAuditFindingsDtoValidation>();
            builder.AddScoped<IValidator<ApproveWorkpaperDto>, ApproveWorkpaperDtoValidation>();
            builder.AddScoped<IValidator<UpdateAuditProgramRequest>, UpdateAuditProgramRequestValidation>();
            builder.AddScoped<IValidator<AuditProgrammeToBeUpdated>, AuditProgrammeToBeUpdatedValidation>();
            builder.AddScoped<IValidator<RejectAuditProgramRequest>, RejectAuditProgramRequestValidation>();
            builder.AddScoped<IValidator<RejectAuditPlanningMemoRequest>, RejectAuditPlanningMemoRequestValidation>();
            builder.AddScoped<IValidator<RejectInformationRequirementRequest>, RejectInformationRequirementRequestValidation>();
            builder.AddScoped<IValidator<RejectEngagementLetterRequest>, RejectEngagementLetterRequestValidation>();
            builder.AddScoped<IValidator<RejectAuditAnnouncementMemoRequest>, RejectAuditAnnouncementMemoRequestValidation>();
            builder.AddScoped<IValidator<ApproveAuditProgramRequest>, ApproveAuditProgramRequestValidation>();
            builder.AddScoped<IValidator<ApproveAuditPlanningMemoRequest>, ApproveAuditPlanningMemoRequestValidation>();
            builder.AddScoped<IValidator<ApproveInformationRequirementRequest>, ApproveInformationRequirementRequestValidation>();
            builder.AddScoped<IValidator<ApproveEngagementLetterRequest>, ApproveEngagementLetterRequestValidation>();
            builder.AddScoped<IValidator<ApproveAuditAnnouncementMemoRequest>, ApproveAuditAnnouncementMemoRequestValidation>();
            builder.AddScoped<IValidator<PostAuditProgramRequest>, PostAuditProgramRequestValidation>();
            builder.AddScoped<IValidator<AuditProgramme>, AuditProgrammeValidation>();
            builder.AddScoped<IValidator<AuditPlanningMemoAuditExecutionReq>, AuditPlanningMemoAuditExecutionReqValidation>();
            builder.AddScoped<IValidator<InformationRequirementRequest>, InformationRequirementRequestValidation>();
            builder.AddScoped<IValidator<InformationRequirementReq>, InformationRequirementReqValidation>();
            builder.AddScoped<IValidator<EngagementLetterAuditExecutionReq>, EngagementLetterAuditExecutionReqValidation>();
            builder.AddScoped<IValidator<EngagementLetterAuditExecutionDurationReq>, EngagementLetterAuditExecutionDurationReqValidatio>();
            builder.AddScoped<IValidator<EngagementLetterReportDistributionListReq>, EngagementLetterReportDistributionListReqValidation>();
            builder.AddScoped<IValidator<AuditAnnouncementMemoRequest>, AuditAnnouncementMemoRequestValidation>();
            builder.AddScoped<IValidator<RejectWorkpaperDto>, RejectWorkpaperDtoValidation>();
            builder.AddScoped<IValidator<UpdateAuditAnnouncementMemoRequest>, UpdateAuditAnnouncementMemoRequestValidation>();
            builder.AddScoped<IValidator<UpdateEngagementLetterAuditExecutionReq>, UpdateEngagementLetterAuditExecutionReqValidation>();
            builder.AddScoped<IValidator<UpdateInformationRequirementRequest>, UpdateInformationRequirementRequestValidation>();
            builder.AddScoped<IValidator<UpdateAuditPlanningMemoAuditExecutionReq>, UpdateAuditPlanningMemoAuditExecutionReqValidation>();
            builder.AddScoped<IValidator<UpdatePostWorkPaperRequest>, UpdatePostWorkPaperRequestValidation>();
            builder.AddScoped<IValidator<UpdatePostAuditFindingsRequest>, UpdatePostAuditFindingsRequestValidation>();

            return builder;
        }
    }
}
