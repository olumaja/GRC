using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.RiskManagement.AuditPlan;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using static Arm.GrcApi.Modules.RiskManagement.AuditPlan.AuditUniverseResponse;

namespace Arm.GrcApi.Modules.RiskManagement.AuditPlan
{
    public class AuditPlanModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {

            // this line creates the endpoint header on swagger
            var routeGroup = app.MapGroup("/apra").WithTags(new string[] { "Audit Plan Risk Assessment" });

            //POST /apra/businessriskrating/armholdingcompany
            routeGroup.MapPost("/businessriskrating/armholdingcompany", BusinessRiskRatingARMHoldingCompanyEndpoint.HandleAsync)
                .Accepts<ARMHoldingCompanyRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ARM Holding Company Business Risk Rating"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .AddEndpointFilter<ValidationFilter<ARMHoldingCompanyRequest>>()
                .WithName("BusinessRiskRatingARMHoldingCompanyEndpoint")
                .Produces<BusinessRiskRatingResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /apra/businessriskrating/armtam
            routeGroup.MapPost("/businessriskrating/armtam", BusinessRiskRatingARMTAMEndpoint.HandleAsync)
                .Accepts<ARMTAMRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ARM TAM Business Risk Rating"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .AddEndpointFilter<ValidationFilter<ARMTAMRequest>>()
                .WithName("BusinessRiskRatingARMTAMEndpoint")
                .Produces<BusinessRiskRatingResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /apra/businessriskrating/armim
            routeGroup.MapPost("/businessriskrating/armim", BusinessRiskRatingARMIMEndpoint.HandleAsync)
                .Accepts<ARMIMRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ARM IM Business Risk Rating"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .AddEndpointFilter<ValidationFilter<ARMIMRequest>>()
                .WithName("BusinessRiskRatingARMIMEndpoint")
                .Produces<BusinessRiskRatingResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /apra/businessriskrating/armsecurity
            routeGroup.MapPost("/businessriskrating/armsecurity", BusinessRiskRatingARMSecurityEndpoint.HandleAsync) 
                .Accepts<ARMSecurityRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ARM Srcurity Business Risk Rating"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .WithName("BusinessRiskRatingARMSecurityEndpoint")
                .Produces<BusinessRiskRatingResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /apra/businessriskrating/armtrustee
            routeGroup.MapPost("/businessriskrating/armtrustee", BusinessRiskRatingARMTrusteeEndpoint.HandleAsync)
                .Accepts<ARMTrusteeRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ARM Trustee Business Risk Rating"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .WithName("BusinessRiskRatingARMTrusteeEndpoint")
                .Produces<BusinessRiskRatingResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /apra/businessriskrating/armhill
            routeGroup.MapPost("/businessriskrating/armhill", BusinessRiskRatingARMHillEndpoint.HandleAsync)
                .Accepts<ARMHillRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ARM Hill Business Risk Rating"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .WithName("BusinessRiskRatingARMHillEndpoint")
                .Produces<BusinessRiskRatingResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /apra/businessriskrating/armagribusiness
            routeGroup.MapPost("/businessriskrating/armagribusiness", BusinessRiskRatingARMAgribusinessEndpoint.HandleAsync)
                .Accepts<ARMAgribusinessRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ARM Agribusiness Business Risk Rating"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .WithName("BusinessRiskRatingARMAgribusinessEndpoint")
                .Produces<BusinessRiskRatingResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /apra/businessriskrating/digitalfinancialservice
            routeGroup.MapPost("/businessriskrating/digitalfinancialservice", BusinessRiskRatingDigitalFinancialServiceEndpoint.HandleAsync)
                .Accepts<DigitalFinancialServicesRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Digital Financial Service Business Risk Rating"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .WithName("BusinessRiskRatingDigitalFinancialServiceEndpoint")
                .Produces<BusinessRiskRatingResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /apra/businessriskrating/armcapital
            routeGroup.MapPost("/businessriskrating/armcapital", BusinessRiskRatingARMCapitalEndpoint.HandleAsync)
                .Accepts<DigitalFinancialServicesRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ARM Capital Business Risk Rating"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .WithName("BusinessRiskRatingARMCapitalEndpoint")
                .Produces<BusinessRiskRatingResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /apra/businessriskrating/armsharedservice
            routeGroup.MapPost("/businessriskrating/armsharedservice", BusinessRiskRatingARMSharedServiceEndpoint.HandleAsync)
                .Accepts<ARMSharedServiceRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ARM Shared Service Business Risk Rating"
                })
                .RequireAuthorization("InternalAuditOfficerOnly")
                .WithName("BusinessRiskRatingARMSharedServiceEndpoint")
                .Produces<BusinessRiskRatingResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-ratedbusinessriskrating/   
            routeGroup.MapGet("/get-ratedbusinessriskrating", GetRatedBusinessRiskRatingEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get all rated business risk rating"
                })
                .RequireAuthorization()
                .WithName("GetRatedBusinessRiskRatingEndpoint")
                .Produces<GetRatedBusinessRiskRating>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-armholdingcompanybusinessriskrating/{id:guid}   
            routeGroup.MapGet("/get-armholdingcompanybusinessriskrating/{id:guid}", GetARMHoldingCompanyBusinessRiskRatingByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMHoldingCompany business risk rating by Id"
                })
                .RequireAuthorization()
                .WithName("GetARMHoldingCompanyBusinessRiskRatingByIdEndpoint")
                .Produces<ARMHoldingCompanyRequest>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-dfsbusinessriskrating/{id:guid}   
            routeGroup.MapGet("/get-dfsbusinessriskrating/{id:guid}", GetDigitalFinancialServiceBusinessRiskRatingByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get Digital Financial Service business risk rating by Id"
                })
                .RequireAuthorization()
                .WithName("GetDigitalFinancialServiceBusinessRiskRatingByIdEndpoint")
                .Produces<DigitalFinancialServicesRequest>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-armcapitalriskrating/{id:guid}   
            routeGroup.MapGet("/get-armcapitalriskrating/{id:guid}", GetARMCapitalBusinessRiskRatingByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMCapital risk rating by Id"
                })
                .RequireAuthorization()
                .WithName("GetARMCapitalBusinessRiskRatingByIdEndpoint")
                .Produces<ARMCapitalRequest>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-armtambusinessriskrating/{id:guid}   
            routeGroup.MapGet("/get-armtambusinessriskrating/{id:guid}", GetARMTAMBusinessRiskRatingByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMTAM business risk rating by Id"
                })
                .RequireAuthorization()
                .WithName("GetARMTAMBusinessRiskRatingByIdEndpoint")
                .Produces<ARMTAMRequest>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-armimbusinessriskrating/{id:guid}   
            routeGroup.MapGet("/get-armimbusinessriskrating/{id:guid}", GetARMIMBusinessRiskRatingByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMIM business risk rating by Id"
                })
                .RequireAuthorization()
                .WithName("GetARMIMBusinessRiskRatingByIdEndpoint")
                .Produces<ARMIMRequest>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            //GET /get-armsecuritybusinessriskrating/{id:guid}   
            routeGroup.MapGet("/get-armsecuritybusinessriskrating/{id:guid}", GetARMSecurityBusinessRiskRatingByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMSecurity business risk rating by Id"
                })
                .RequireAuthorization()
                .WithName("GetARMSecurityBusinessRiskRatingByIdEndpoint")
                .Produces<ARMSecurityRequest>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-armtrusteebusinessriskrating/{id:guid}   
            routeGroup.MapGet("/get-armtrusteebusinessriskrating/{id:guid}", GetARMTrusteeBusinessRiskRatingByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMTrustee business risk rating by Id"
                })
                .RequireAuthorization()
                .WithName("GetARMTrusteeBusinessRiskRatingByIdEndpoint")
                .Produces<ARMTrusteeRequest>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-armtrusteebusinessriskrating/{id:guid}   
            routeGroup.MapGet("/get-armhillbusinessriskrating/{id:guid}", GetARMHillBusinessRiskRatingByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMHill business risk rating by Id"
                })
                .RequireAuthorization()
                .WithName("GetARMHillBusinessRiskRatingByIdEndpoint")
                .Produces<ARMHillRequest>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-armagribusniessriskrating/{id:guid}   
            routeGroup.MapGet("/get-armagribusniessriskrating/{id:guid}", GetARMAgribusinessRiskRatingByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMAgribusniess business risk rating by Id"
                })
                .RequireAuthorization()
                .WithName("GetARMAgribusinessRiskRatingByIdEndpoint")
                .Produces<ARMAgribusinessRequest>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-armsharedservicebusniessriskrating/{id:guid}   
            routeGroup.MapGet("/get-armsharedservicebusniessriskrating/{id:guid}", GetARMSharedServicebusinessRiskRatingByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMSharedService busniess business risk rating by Id"
                })
                .RequireAuthorization() 
                .WithName("GetARMSharedServicebusinessRiskRatingByIdEndpoint")
                .Produces<ARMSharedServiceRequest>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /businessriskrating/   
            routeGroup.MapGet("/businessriskrating", ViewBusinessRiskRatingEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get all business risk rating After EMC and MC rating"
                })
                .RequireAuthorization()
                .WithName("ViewBusinessRiskRatingEndpoint")
                .Produces<ViewBusinessRiskRatingResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /businessriskrating/rejected   
            routeGroup.MapGet("/businessriskrating/rejected", ViewRejectedBusinessRiskRatingEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get all Rejected business risk rating summary"
                })
                .RequireAuthorization()
                .WithName("ViewRejectedBusinessRiskRatingEndpoint")
                .Produces<ViewBusinessRiskRatingResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /businessriskrating/approved   
            routeGroup.MapGet("/businessriskrating/approved", ViewApprovedBusinessRiskRatingEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get all Approved business risk rating summary"
                })
                .RequireAuthorization()
                .WithName("ViewApprovedBusinessRiskRatingEndpoint")
                .Produces<ViewBusinessRiskRatingResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /businessriskrating/awaitingEMCRating     
            routeGroup.MapGet("/businessriskrating/awaitingEMCRating", BusinessRiskRatingAwaitingEMCRatingEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get all business risk rating awaiting EMC Rating"
                })
                .RequireAuthorization()
                .WithName("BusinessRiskRatingAwaitingEMCRatingEndpoint")
                .Produces<BusinessRatingAwaitingManagementConcernRatingResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /businessriskrating/awaitingManagementConcernRating   
            routeGroup.MapGet("/businessriskrating/awaitingManagementConcernRating", BusinessRiskRatingAwaitingManagementConcernRatingEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get all business risk rating awaiting ManagementConcern Rating"
                })
                .RequireAuthorization()
                .WithName("BusinessRiskRatingAwaitingManagementConcernRatingEndpoint")
                .Produces<BusinessRatingAwaitingManagementConcernRatingResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /armholdingcompanybusinessriskrating/approve/{businessriskratingId:guid}   
            routeGroup.MapPost("/armholdingcompanybusinessriskrating/approve/{businessriskratingId:guid}", ApproveARMHoldingCompanyBusinessRiskRatingEndpoint.HandleAsync)
                //.Accepts<ARMHoldingCompanyRatingReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Approve ARMHoldingCompany business risk rating after completing MC and EMC"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .WithName("ApproveARMHoldingCompanyBusinessRiskRatingEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            //POST /armtambusinessriskrating/approve/{businessriskratingId:guid}   
            routeGroup.MapPost("/armtambusinessriskrating/approve/{businessriskratingId:guid}", ApproveARMTAMBusinessRiskRatingEndpoint.HandleAsync)
                .Accepts<ARMTAMBusinessRiskRatingReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Approve ARMTAM business risk rating after completing MC and EMC"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .WithName("ApproveARMTAMBusinessRiskRatingEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /dfsbusinessriskrating/approve/{businessriskratingId:guid}   
            routeGroup.MapPost("/dfsbusinessriskrating/approve/{businessriskratingId:guid}", ApproveDFSBusinessRiskRatingEndpoint.HandleAsync)
                .Accepts<DigitalFinancialServicesBusinessRiskRatingReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Approve Digital Financial Service business risk rating after completing MC and EMC"
                })
               .RequireAuthorization("InternalAuditSupervisorOnly")
                .WithName("ApproveDFSBusinessRiskRatingEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /armcapitalbusinessriskrating/approve/{businessriskratingId:guid}   
            routeGroup.MapPost("/armcapitalbusinessriskrating/approve/{businessriskratingId:guid}", ApproveARMCapitalBusinessRiskRatingEndpoint.HandleAsync)
                .Accepts<ARMCapitalBusinessRiskRatingReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Approve ARMCapital business risk rating after completing MC and EMC"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .WithName("ApproveARMCapitalBusinessRiskRatingEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /armimbusinessriskrating/approve/{businessriskratingId:guid}   
            routeGroup.MapPost("/armimbusinessriskrating/approve/{businessriskratingId:guid}", ApproveARMIMBusinessRiskRatingEndpoint.HandleAsync)
                .Accepts<ARMIMBusinessRiskRatingReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Approve ARMIM business risk rating after completing MC and EMC"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .WithName("ApproveARMIMBusinessRiskRatingEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /armsecuritybusinessriskrating/approve/{businessriskratingId:guid}   
            routeGroup.MapPost("/armsecuritybusinessriskrating/approve/{businessriskratingId:guid}", ApproveARMSecurityBusinessRiskRatingEndpoint.HandleAsync)
                .Accepts<ARMSecurityRatingReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Approve ARMSecurity business risk rating after completing MC and EMC"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .WithName("ApproveARMSecurityBusinessRiskRatingEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /armtrusteebusinessriskrating/approve/{businessriskratingId:guid}   
            routeGroup.MapPost("/armtrusteebusinessriskrating/approve/{businessriskratingId:guid}", ApproveARMTrusteeBusinessRiskRatingEndpoint.HandleAsync)
                .Accepts<ARMTrusteeRatingReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Approve ARMTrustee business risk rating after completing MC and EMC"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .WithName("ApproveARMTrusteeBusinessRiskRatingEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /armhillbusinessriskrating/approve/{businessriskratingId:guid}   
            routeGroup.MapPost("/armhillbusinessriskrating/approve/{businessriskratingId:guid}", ApproveARMHillBusinessRiskRatingEndpoint.HandleAsync)
                .Accepts<ARMHillRatingReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Approve ARMHill business risk rating after completing MC and EMC"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .WithName("ApproveARMHillBusinessRiskRatingEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /armagribusinessbusinessriskrating/approve/{businessriskratingId:guid}   
            routeGroup.MapPost("/armagribusinessbusinessriskrating/approve/{businessriskratingId:guid}", ApproveARMAgribusinessRiskRatingEndpoint.HandleAsync)
                .Accepts<ARMAgribusinessRatingReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Approve ARMAgribusiness business risk rating after completing MC and EMC"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .WithName("ApproveARMAgribusinessRiskRatingEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /armsharedservicerating/approve/{businessriskratingId:guid}   
            routeGroup.MapPost("/armsharedservicerating/approve/{businessriskratingId:guid}", ApproveARMSharedServicebusinessRiskRatingEndpoint.HandleAsync)
                .Accepts<ARMSharedServiceRatingReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Approve ARMSharedservice business risk rating after completing MC and EMC"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .WithName("ApproveARMSharedServicebusinessRiskRatingEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            //POST /businessriskrating/reject   
            routeGroup.MapPost("/businessriskrating/reject", RejectBusinessRiskRatingEndpoint.HandleAsync)
                .Accepts<RejectBusinessRiskRatingDto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Reject business risk rating"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .AddEndpointFilter<ValidationFilter<RejectBusinessRiskRatingDto>>()
                .WithName("RejectBusinessRiskRatingEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            //POST /apra/emcconcernriskrating
            routeGroup.MapPost("/emcconcernriskrating", EMCConcernRatingEndpoint.HandleAsync)
                .Accepts<EMCConcernRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "EMC's Concern Risk Rating"
                })
                .RequireAuthorization("InternalAuditExecutiveManagerConcern")
                .WithName("EMCConcernRatingEndpoint")
                .Produces<EMCConcernRatingResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-emcconcernrating/{id:guid}
            routeGroup.MapGet("/get-emcconcernrating/{id:guid}", GetEMCConcernSummaryRatingByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get EMC's Concern Risk Rating with their average by Id "
                })
                .RequireAuthorization()
                .WithName("GetEMCConcernSummaryRatingByIdEndpoint")
                .Produces<GetEmcConcernRatingResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-emcconcernrating/    
            routeGroup.MapGet("/get-emcconcernrating", GetEMCConcernSummaryRatingEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get all EMC's Concern Risk Rating Summary"
                })
                .RequireAuthorization()
                .WithName("GetEMCConcernSummaryRatingEndpoint")
                .Produces<ViewEMCRatingResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /apra/managementconcern/armim
            routeGroup.MapPost("/managementconcern/armim", ManagementConcernRatingARMIMEndpoint.HandleAsync)
                .Accepts<ManagementConcernARMIMRiskRatingRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ARM IM Management Concern Risk Rating"
                })
                .RequireAuthorization("InternalAuditManagerConcern")
                .WithName("ManagementConcernRatingARMIMEndpoint")
                .Produces<ManagementConcernRatingResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /apra/managementconcern/armtrustee
            routeGroup.MapPost("/managementconcern/armtrustee", ManagementConcernRatingARMTrusteeEndpoint.HandleAsync)
                .Accepts<ManagementConcernARMTrusteeRiskRatingRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ARM Trustee Management Concern Risk Rating"
                })
                .RequireAuthorization("InternalAuditManagerConcern")
                .WithName("ManagementConcernRatingARMTrusteeEndpoint")
                .Produces<ManagementConcernRatingResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /apra/managementconcern/armsecurity
            routeGroup.MapPost("/managementconcern/armsecurity", ManagementConcernRatingARMSecurityEndpoint.HandleAsync)
                .Accepts<ManagementConcernARMSecurityRiskRatingRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ARM Security Management Concern Risk Rating"
                })
                .RequireAuthorization("InternalAuditManagerConcern")
                .WithName("ManagementConcernRatingARMSecurityEndpoint")
                .Produces<ManagementConcernRatingResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /apra/managementconcern/armshill
            routeGroup.MapPost("/managementconcern/armshill", ManagementConcernRatingARMHillEndpoint.HandleAsync)
                .Accepts<ManagementConcernARMHillRiskRatingRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ARM Hill Management Concern Risk Rating"
                })
                .RequireAuthorization("InternalAuditManagerConcern")
                .WithName("ManagementConcernRatingARMHillEndpoint")
                .Produces<ManagementConcernRatingResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /apra/managementconcern/dfs
            routeGroup.MapPost("/managementconcern/dfs", ManagementConcernRatingDFSEndpoint.HandleAsync)
                .Accepts<ManagementConcernDigitalFinancialServiceRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Digital Financial Service Management Concern Risk Rating"
                })
                .RequireAuthorization("InternalAuditManagerConcern")
                .WithName("ManagementConcernRatingDFSEndpoint")
                .Produces<ManagementConcernRatingResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /apra/managementconcern/armcapital
            routeGroup.MapPost("/managementconcern/armcapital", ManagementConcernRatingARMCapitalEndpoint.HandleAsync)
                .Accepts<ManagementConcernARMCapitalRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ARMCapital Management Concern Risk Rating"
                })
                .RequireAuthorization("InternalAuditManagerConcern")
                .WithName("ManagementConcernRatingARMCapitalEndpoint")
                .Produces<ManagementConcernRatingResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            //POST /apra/managementconcern/armsagribusiness
            routeGroup.MapPost("/managementconcern/armsagribusiness", ManagementConcernRatingARMAgribusinessEndpoint.HandleAsync)
                .Accepts<ManagementConcernARMAgribusinessRiskRatingRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ARM Agribusiness Management Concern Risk Rating"
                })
                .RequireAuthorization("InternalAuditManagerConcern")
                .WithName("ManagementConcernRatingARMAgribusinessEndpoint")
                .Produces<ManagementConcernRatingResponse>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-mcconcernrating/     
            routeGroup.MapGet("/get-mcconcernrating", GetManagementConcernRiskRatingEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get all MC's Concern Risk Rating Summary with their comments"
                })
                .RequireAuthorization()
                .WithName("GetManagementConcernRiskRatingEndpoint")
                .Produces<GetMCConcernRatingResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-managementconcernrating/{id:guid}   
            routeGroup.MapGet("/get-managementconcernrating/{id:guid}", GetManagementConcernRiskRatingByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get management concern risk rating by Id"
                })
                .RequireAuthorization()
                .WithName("GetManagementConcernRiskRatingByIdEndpoint")
                .Produces<GetManagementConcernRatingResponse>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-armimmanagementconcernrating/{id:guid}   
            routeGroup.MapGet("/get-armimmanagementconcernrating/{id:guid}", GetARMIMManagementConcernRiskRatingByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMIM management concern risk rating by Id"
                })
                .RequireAuthorization()
                .WithName("GetARMIMManagementConcernRiskRatingByIdEndpoint")
                .Produces<GetARMIMManagementConcernById>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-armtrusteemanagementconcernrating/{id:guid}   
            routeGroup.MapGet("/get-armtrusteemanagementconcernrating/{id:guid}", GetARMTrusteeManagementConcernRiskRatingByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMTRustee management concern risk rating by Id"
                })
                .RequireAuthorization()
                .WithName("GetARMTrusteeManagementConcernRiskRatingByIdEndpoint")
                .Produces<GetARMTrusteeManagementConcernRatingById>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-armsecuritymanagementconcernrating/{id:guid}   
            routeGroup.MapGet("/get-armsecuritymanagementconcernrating/{id:guid}", GetARMSecurityManagementConcernRiskRatingByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMSecurity management concern risk rating by Id"
                })
                .RequireAuthorization()
                .WithName("GetARMSecurityManagementConcernRiskRatingByIdEndpoint")
                .Produces<GetARMSecurityManagementConcernRatingById>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-armhillmanagementconcernrating/{id:guid}   
            routeGroup.MapGet("/get-armhillmanagementconcernrating/{id:guid}", GetARMHillManagementConcernRiskRatingByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMHill management concern risk rating by Id"
                })
                .RequireAuthorization()
                .WithName("GetARMHillManagementConcernRiskRatingByIdEndpoint")
                .Produces<GetARMHillManagementConcernRatingById>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-dfsmanagementconcernrating/{id:guid}   
            routeGroup.MapGet("/get-dfsmanagementconcernrating/{id:guid}", GetDFSManagementConcernRiskRatingByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get Digital Financial Service management concern risk rating by Id"
                })
                .RequireAuthorization()
                .WithName("GetDFSManagementConcernRiskRatingByIdEndpoint")
                .Produces<GetDFSManagementConcernRatingById>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-armcapitalmanagementconcernrating/{id:guid}   
            routeGroup.MapGet("/get-armcapitalmanagementconcernrating/{id:guid}", GetARMCapitalManagementConcernRiskRatingByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMCapital management concern risk rating by Id"
                })
                .RequireAuthorization()
                .WithName("GetARMCapitalManagementConcernRiskRatingByIdEndpoint")
                .Produces<GetDFSManagementConcernRatingById>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-armagribusinessmanagementconcernrating/{id:guid}   
            routeGroup.MapGet("/get-armagribusinessmanagementconcernrating/{id:guid}", GetARMAgribusinessManagementConcernRiskRatingByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMAgribusiness management concern risk rating by Id"
                })
                .RequireAuthorization() 
                .WithName("GetARMAgribusinessManagementConcernRiskRatingByIdEndpoint")
                .Produces<GetArmAgribusinessManagementConcernRatingById>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /audituniverse/viewarmholdcoanualaudituniverse   
            routeGroup.MapGet("/audituniverse/viewarmholdcoanualaudituniverse", ViewARMHoldingCompanyAnualAuditPlanEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARM Holding Company available for the Anual Audit Universe - after suppervisor approved business risk rating"
                })
                .RequireAuthorization()
                .WithName("ViewARMHoldingCompanyAnualAuditPlanEndpoint")
                .Produces<ARMHoldingCompanyAuditUniverseResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /audituniverse/viewarmholdcoanualaudituniverse   
            routeGroup.MapGet("/audituniverse/viewarmtamanualaudituniverse", ViewARMTAMAnualAuditPlanEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARM TAM available for the Anual Audit Universe - after suppervisor approved business risk rating"
                })
                .RequireAuthorization()
                .WithName("ViewARMTAMAnualAuditPlanEndpoint")
                .Produces<ARMTAMAuditUniverseResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /audituniverse/viewarmimanualaudituniverse   
            routeGroup.MapGet("/audituniverse/viewarmimanualaudituniverse", ViewARMIMAnualAuditPlanEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMIM available for the Anual Audit Universe - after suppervisor approved business risk rating"
                })
                .RequireAuthorization()
                .WithName("ViewARMIMAnualAuditPlanEndpoint")
                .Produces<ARMIMAuditUniverseResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            // GET /audituniverse/viewarmimanualaudituniverse  
            routeGroup.MapGet("/audituniverse/viewarmsecurityanualaudituniverse", ViewARMSecurityAnualAuditPlanEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMSecurity available for the Anual Audit Universe - after suppervisor approved business risk rating"
                })
                .RequireAuthorization()
                .WithName("ViewARMSecurityAnualAuditPlanEndpoint")
                .Produces<ARMSecurityAuditUniverseResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /audituniverse/viewarmtrusteeanualaudituniverse  
            routeGroup.MapGet("/audituniverse/viewarmtrusteeanualaudituniverse", ViewARMTrusteeAnualAuditPlanEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMTrustee available for the Anual Audit Universe - after suppervisor approved business risk rating"
                })
                .RequireAuthorization()
                .WithName("ViewARMTrusteeAnualAuditPlanEndpoint")
                .Produces<ARMTrusteeAuditUniverseResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /audituniverse/viewarmhillanualaudituniverse   
            routeGroup.MapGet("/audituniverse/viewarmhillanualaudituniverse", ViewARMHillAnualAuditPlanEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMHill available for the Anual Audit Universe - after suppervisor approved business risk rating"
                })
                .RequireAuthorization()
                .WithName("ViewARMHillAnualAuditPlanEndpoint")
                .Produces<ARMHillAuditUniverseResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /audituniverse/viewdigitalfinancialserviceanualaudituniverse   
            routeGroup.MapGet("/audituniverse/viewdigitalfinancialserviceanualaudituniverse", ViewDigitalFinancialServiceAnualAuditPlanEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View Digital Financial Service available for the Anual Audit Universe - after suppervisor approved business risk rating"
                })
                .RequireAuthorization()
                .WithName("ViewDigitalFinancialServiceAnualAuditPlanEndpoint")
                .Produces<DigitalFinancialServiceAuditUniverseResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /audituniverse/viewarmcapitalanualaudituniverse   
            routeGroup.MapGet("/audituniverse/viewarmcapitalanualaudituniverse", ViewARMCapitalAnualAuditPlanEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMCapital available for the Anual Audit Universe - after suppervisor approved business risk rating"
                })
                .RequireAuthorization()
                .WithName("ViewARMCapitalAnualAuditPlanEndpoint")
                .Produces<ARMCapitalAuditUniverseResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /audituniverse/viewarmagribusinessanualaudituniverse   
            routeGroup.MapGet("/audituniverse/viewarmagribusinessanualaudituniverse", ViewARMAgribusinessAnualAuditPlanEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMAgribusiness available for the Anual Audit Universe - after suppervisor approved business risk rating"
                })
                .RequireAuthorization()
                .WithName("ViewARMAgribusinessAnualAuditPlanEndpoint")
                .Produces<ARMAgribusinessAuditUniverseResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /audituniverse/viewarmsharedserviceanualaudituniverse   
            routeGroup.MapGet("/audituniverse/viewarmsharedserviceanualaudituniverse", ViewARMSharedServiceAnualAuditPlanEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMSharedService available for the Anual Audit Universe - after suppervisor approved business risk rating"
                })
                .RequireAuthorization()
                .WithName("ViewARMSharedServiceAnualAuditPlanEndpoint")
                .Produces<ARMSharedServiceAuditUniverseResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            //POST /apra/audituniverse/armhillmonthlyaudituniverse
            routeGroup.MapPost("/audituniverse/monthlyaudituniverse", MonthlyAuditUniverseEndpoint.HandleAsync)
                .Accepts<MonthlyAuditUniverseReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Monthly Audit Universe"
                })
                .RequireAuthorization("InternalAuditSupervisorOnly")
                .WithName("MonthlyAuditUniverseEndpoint")
                .Produces<AnualAuditUniverseResp>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /audituniverse/get-monthlyaudituniversesummary
            routeGroup.MapGet("/audituniverse/get-monthlyaudituniversesummary", Monthlyaudituniversesummary.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get all monthly audit universe summary"
                })
                .RequireAuthorization()
                .WithName("Monthlyaudituniversesummary")
                .Produces<ViewAuditUniverseSummaryResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /audituniverse/getmonthlyaudituniversesummary
            routeGroup.MapGet("/audituniverse/getmonthlyaudituniversesummary", GetMonthlyAuditUniverseSummary.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get all businesses monthly audit universe summary for download"
                })
                .RequireAuthorization()
                .WithName("GetMonthlyAuditUniverseSummary")
                .Produces<AuditUniverseReports>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError); 


            //GET /audituniverse/get-armholdingcompany/{anualAuditUniverseId:guid}   
            routeGroup.MapGet("/audituniverse/get-armholdingcompany/{anualAuditUniverseId:guid}", GetARMHoldingCompanyAnualAuditUniverseByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARM Holding Company Annual Audit Universe by AnualAuditUniverseId"
                })
                .RequireAuthorization()
                .WithName("GetARMHoldingCompanyAnualAuditUniverseByIdEndpoint")
                .Produces<GetARMHoldngCompanyAuditUniverseSummary>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
           
            //GET /audituniverse/get-dfs/{anualAuditUniverseId:guid}   
            routeGroup.MapGet("/audituniverse/get-dfs/{anualAuditUniverseId:guid}", GetDigitalFinancialServiceAnnualAuditUniverseByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get Digital Financial Service Annual Audit Universe by AnnualAuditUniverseId"
                })
                .RequireAuthorization()
                .WithName("GetDigitalFinancialServiceAnnualAuditUniverseByIdEndpoint")
                .Produces<GetDigitalFinancialServiceAuditUniverseSummary>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /audituniverse/get-armcapital/{anualAuditUniverseId:guid}   
            routeGroup.MapGet("/audituniverse/get-armcapital/{anualAuditUniverseId:guid}", GetARMCapitalAnnualAuditUniverseByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMCapital Annual Audit Universe by AnnualAuditUniverseId"
                })
                .RequireAuthorization()
                .WithName("GetARMCapitalAnnualAuditUniverseByIdEndpoint")
                .Produces<GetARMCapitalAuditUniverseSummary>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /audituniverse/get-armim/{anualAuditUniverseId:guid}   
            routeGroup.MapGet("/audituniverse/get-armim/{anualAuditUniverseId:guid}", GetARMIMAnnualAuditUniverseByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMIM Annual Audit Universe by AnualAuditUniverseId"
                })
                .RequireAuthorization()
                .WithName("GetARMIMAnnualAuditUniverseByIdEndpoint")
                .Produces<GetARMIMAuditUniverseSummary>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /audituniverse/get-armsecurity/{anualAuditUniverseId:guid}   
            routeGroup.MapGet("/audituniverse/get-armsecurity/{anualAuditUniverseId:guid}", GetARMSecurityAnnualAuditUniverseByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMSecurity Annual Audit Universe by AnualAuditUniverseId"
                })
                .RequireAuthorization()
                .WithName("GetARMSecurityAnnualAuditUniverseByIdEndpoint")
                .Produces<GetARMSecurityAuditUniverseSummary>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /audituniverse/get-armtrustee/{anualAuditUniverseId:guid}   
            routeGroup.MapGet("/audituniverse/get-armtrustee/{anualAuditUniverseId:guid}", GetARMTrusteeAnnualAuditUniverseByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMTrustee Annual Audit Universe by AnnualAuditUniverseId"
                })
                .RequireAuthorization()
                .WithName("GetARMTrusteeAnnualAuditUniverseByIdEndpoint")
                .Produces<GetARMTrusteeAuditUniverseSummary>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /audituniverse/get-armhill/{anualAuditUniverseId:guid}   
            routeGroup.MapGet("/audituniverse/get-armhill/{anualAuditUniverseId:guid}", GetARMHillAnnualAuditUniverseByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMHill Annual Audit Universe by AnnualAuditUniverseId"
                })
                .RequireAuthorization()
                .WithName("GetARMHillAnnualAuditUniverseByIdEndpoint")
                .Produces<GetARMHillAuditUniverseSummary>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /audituniverse/get-armagribusiness/{anualAuditUniverseId:guid}   
            routeGroup.MapGet("/audituniverse/get-armagribusiness/{anualAuditUniverseId:guid}", GetARMAgribusinessAnnualAuditUniverseByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMAgribusiness Annual Audit Universe by AnnualAuditUniverseId"
                })
                .RequireAuthorization()
                .WithName("GetARMAgribusinessAnnualAuditUniverseByIdEndpoint")
                .Produces<GetARMAgribusinessAuditUniverseSummary>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /audituniverse/get-armagribusiness/{anualAuditUniverseId:guid}   
            routeGroup.MapGet("/audituniverse/get-armsharedservice/{anualAuditUniverseId:guid}", GetARMSharedServiceAnnualAuditUniverseByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get ARMSharedService Annual Audit Universe by AnnualAuditUniverseId"
                })
                .RequireAuthorization()
                .WithName("GetARMSharedServiceAnnualAuditUniverseByIdEndpoint")
                .Produces<GetARMSharedServiceAuditUniverseSummary>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplanofficer/view-armholdingcompany/{anualAuditUniverseId:guid}  
            routeGroup.MapGet("/auditexecutionplanofficer/view-armholdingcompany/{anualAuditUniverseId:guid}", ViewArmHoldCoAudiPlanExecutionOfficerByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARM Holding Company Audit Execution Plan before engagement has been commenced by AnualAuditUniverseId - Audit Officer"
                })
                .RequireAuthorization()
                .WithName("ViewArmHoldCoAudiPlanExecutionOfficerByIdEndpoint")
                .Produces<ViewARMHoldCoAudiPlanExecutionByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplanofficer/get-armim/{anualAuditUniverseId:guid}   
            routeGroup.MapGet("/auditexecutionplanofficer/get-armim/{anualAuditUniverseId:guid}", ViewArmIMAudiPlanExecutionOfficerByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMIM Audit Execution Plan before engagement has been commenced by AnualAuditUniverseId - Audit Officer"
                })
                .RequireAuthorization()
                .WithName("ViewArmIMAudiPlanExecutionOfficerByIdEndpoint")
                .Produces<ViewARMIMAudiPlanExecutionByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplanofficer/view-armsecurity/{anualAuditUniverseId:guid}  
            routeGroup.MapGet("/auditexecutionplanofficer/view-armsecurity/{anualAuditUniverseId:guid}", ViewArmSecurityAudiPlanExecutionOfficerByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMSecurity Audit execution Plan before engagement has been commenced by AnualAuditUniverseId - Audit Officer"
                })
                .RequireAuthorization()
                .WithName("ViewArmSecurityAudiPlanExecutionOfficerByIdEndpoint")
                .Produces<ViewARMSecurityAudiPlanExecutionByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /audituniverseofficer/get-armtrustee/{anualAuditUniverseId:guid}   
            routeGroup.MapGet("/auditexecutionplanofficer/view-armtrustee/{anualAuditUniverseId:guid}", ViewArmTrusteeAudiPlanExecutionOfficerByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMTrustee Audit Execution before engagement has been commenced by AnualAuditUniverseId - Audit Officer"
                })
                .RequireAuthorization()
                .WithName("ViewArmTrusteeAudiPlanExecutionOfficerByIdEndpoint")
                .Produces<ViewARMTrusteeAudiPlanExecutionByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplanofficer/view-armhill/{anualAuditUniverseId:guid}  
            routeGroup.MapGet("/auditexecutionplanofficer/view-armhill/{anualAuditUniverseId:guid}", ViewArmHillAudiPlanExecutionOfficerByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMHill Audit Execution Plan before engagement has been commenced by AnualAuditUniverseId - Audit Officer"
                })
                .RequireAuthorization()
                .WithName("ViewArmHillAudiPlanExecutionOfficerByIdEndpoint")
                .Produces<ViewARMHillAudiPlanExecutionByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplanofficer/view-dfs/{anualAuditUniverseId:guid}  
            routeGroup.MapGet("/auditexecutionplanofficer/view-dfs/{anualAuditUniverseId:guid}", ViewDigitalFinancialServiceAudiPlanExecutionOfficerByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View Digital Financial Service Audit Execution Plan before engagement has been commenced by AnualAuditUniverseId - Audit Officer"
                })
                .RequireAuthorization()
                .WithName("ViewDigitalFinancialServiceAudiPlanExecutionOfficerByIdEndpoint")
                .Produces<ViewDigitalFinancialServiceAudiPlanExecutionByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            //GET /auditexecutionplanofficer/view-armcapital/{anualAuditUniverseId:guid}  
            routeGroup.MapGet("/auditexecutionplanofficer/view-armcapital/{anualAuditUniverseId:guid}", ViewARMCapitalAudiPlanExecutionOfficerByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMCapital Audit Execution Plan before engagement has been commenced by AnualAuditUniverseId - Audit Officer"
                })
                .RequireAuthorization()
                .WithName("ViewARMCapitalAudiPlanExecutionOfficerByIdEndpoint")
                .Produces<ViewARMCapitalAudiPlanExecutionByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            //GET /auditexecutionplanofficer/view-armagribusiness/{anualAuditUniverseId:guid}   
            routeGroup.MapGet("/auditexecutionplanofficer/view-armagribusiness/{anualAuditUniverseId:guid}", ViewArmAgribusinessAudiPlanExecutionOfficerByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMAgribusiness Audit Execution Plan before engagement has been commenced by AnualAuditUniverseId - Audit Officer"
                })
                .RequireAuthorization()
                .WithName("ViewArmAgribusinessAudiPlanExecutionOfficerByIdEndpoint")
                .Produces<ViewARMAgribusinessAudiPlanExecutionByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplanofficer/view-armsharedservice/{anualAuditUniverseId:guid}   
            routeGroup.MapGet("/auditexecutionplanofficer/view-armsharedservice/{anualAuditUniverseId:guid}", ViewArmSharedServiceAudiPlanExecutionOfficerByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMSharedService Audit Execution Plan before engagement has been commenced by AnualAuditUniverseId - Audit Officer"
                })
                .RequireAuthorization()
                .WithName("ViewArmSharedServiceAudiPlanExecutionOfficerByIdEndpoint")
                .Produces<ViewARMSharedServiceAudiPlanExecutionByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplan/view-armholdingcompany/{anualAuditUniverseId:guid}  
            routeGroup.MapGet("/auditexecutionplan/view-armholdingcompany/{anualAuditUniverseId:guid}", ViewArmHoldCoAudiPlanExecutionByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARM Holding Company Audit Execution Plan after engagement has been commenced by AnualAuditUniverseId - Audit Officer"
                })
                .RequireAuthorization()
                .WithName("ViewArmHoldCoAudiPlanExecutionByIdEndpoint")
                .Produces<ViewARMHoldCoAudiPlanExecutionByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplan/get-armim/{anualAuditUniverseId:guid}   
            routeGroup.MapGet("/auditexecutionplan/get-armim/{anualAuditUniverseId:guid}", ViewArmIMAudiPlanExecutionByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMIM Audit Execution Plan after engagement has been commenced by AnualAuditUniverseId - Audit Officer"
                })
                .RequireAuthorization()
                .WithName("ViewArmIMAudiPlanExecutionByIdEndpoint")
                .Produces<ViewARMIMAudiPlanExecutionByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplan/view-armsecurity/{anualAuditUniverseId:guid}  
            routeGroup.MapGet("/auditexecutionplan/view-armsecurity/{anualAuditUniverseId:guid}", ViewArmSecurityAudiPlanExecutionByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMSecurity Audit execution Plan after engagement has been commenced by AnualAuditUniverseId - Audit Officer"
                })
                .RequireAuthorization()
                .WithName("ViewArmSecurityAudiPlanExecutionByIdEndpoint")
                .Produces<ViewARMSecurityAudiPlanExecutionByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /audituniverse/get-armtrustee/{anualAuditUniverseId:guid}   
            routeGroup.MapGet("/auditexecutionplan/view-armtrustee/{anualAuditUniverseId:guid}", ViewArmTrusteeAudiPlanExecutionByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMTrustee Audit Execution after engagement has been commenced by AnualAuditUniverseId - Audit Officer"
                })
                .RequireAuthorization()
                .WithName("ViewArmTrusteeAudiPlanExecutionByIdEndpoint")
                .Produces<ViewARMTrusteeAudiPlanExecutionByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplan/view-armhill/{anualAuditUniverseId:guid}  
            routeGroup.MapGet("/auditexecutionplan/view-armhill/{anualAuditUniverseId:guid}", ViewArmHillAudiPlanExecutionByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMHill Audit Execution Plan after engagement has been commenced by AnualAuditUniverseId - Audit Officer"
                })
                .RequireAuthorization()
                .WithName("ViewArmHillAudiPlanExecutionByIdEndpoint")
                .Produces<ViewARMHillAudiPlanExecutionByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

         
            //GET /auditexecutionplan/view-dfs/{anualAuditUniverseId:guid}  
            routeGroup.MapGet("/auditexecutionplan/view-dfs/{anualAuditUniverseId:guid}", ViewDigitalFinancialServiceAudiPlanExecutionByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View Digital Financial Service Audit Execution Plan after engagement has been commenced by AnualAuditUniverseId - Audit Officer"
                })
                .RequireAuthorization()
                .WithName("ViewDigitalFinancialServiceAudiPlanExecutionByIdEndpoint")
                .Produces<ViewDigitalFinancialServiceAudiPlanExecutionByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplan/view-armcapital/{anualAuditUniverseId:guid}  
            routeGroup.MapGet("/auditexecutionplan/view-armcapital/{anualAuditUniverseId:guid}", ViewARMCapitalAudiPlanExecutionByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMCapital Audit Execution Plan after engagement has been commenced by AnualAuditUniverseId - Audit Officer"
                })
                .RequireAuthorization()
                .WithName("ViewARMCapitalAudiPlanExecutionByIdEndpoint")
                .Produces<ViewARMCapitalAudiPlanExecutionByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplan/view-armagribusiness/{anualAuditUniverseId:guid}   
            routeGroup.MapGet("/auditexecutionplan/view-armagribusiness/{anualAuditUniverseId:guid}", ViewArmAgribusinessAudiPlanExecutionByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMAgribusiness Audit Execution Plan after engagement has been commenced by AnualAuditUniverseId - Audit Officer"
                })
                .RequireAuthorization()
                .WithName("ViewArmAgribusinessAudiPlanExecutionByIdEndpoint")
                .Produces<ViewARMAgribusinessAudiPlanExecutionByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplan/view-armsharedservice/{anualAuditUniverseId:guid}   
            routeGroup.MapGet("/auditexecutionplan/view-armsharedservice/{anualAuditUniverseId:guid}", ViewArmSharedServiceAudiPlanExecutionByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View ARMSharedService Audit Execution Plan after engagement has been commenced by AnualAuditUniverseId - Audit Officer"
                })
                .RequireAuthorization()
                .WithName("ViewArmSharedServiceAudiPlanExecutionByIdEndpoint")
                .Produces<ViewARMSharedServiceAudiPlanExecutionByIdResp>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /auditexecutionplan/viewofficerauditexecutionplansummary
            routeGroup.MapGet("/auditexecutionplan/viewofficerauditexecutionplansummary", ViewOfficerAuditExecutionPlanEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "View Internal Audit Execution Plan Summary for the Year - Officer Screen"
                })
                .RequireAuthorization()
                .WithName("ViewOfficerAuditExecutionPlanEndpoint")
                .Produces<ViewAuditExecutionPlan>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            return app;
        }
        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {                               
            builder.AddScoped<IRepository<StrategyARMCapital>, Repository<StrategyARMCapital>>();           
            builder.AddScoped<IRepository<ARMIMEMCRating>, Repository<ARMIMEMCRating>>();
            builder.AddScoped<IRepository<ManagementConcernBusinessUnitARMIMRating>, Repository<ManagementConcernBusinessUnitARMIMRating>>();
            builder.AddScoped<IRepository<AuditUniverseARMIMResearch>, Repository<AuditUniverseARMIMResearch>>();
            builder.AddScoped<IRepository<ComplianceIMRatingResearch>, Repository<ComplianceIMRatingResearch>>();
            builder.AddScoped<IRepository<FinacialIMRatingResearch>, Repository<FinacialIMRatingResearch>>();
            builder.AddScoped<IRepository<OperationIMRatingResearch>, Repository<OperationIMRatingResearch>>();
            builder.AddScoped<IRepository<StrategyIMRatingResearch>, Repository<StrategyIMRatingResearch>>();
            builder.AddScoped<IRepository<ManagementConcernSharedServiceDFSRating>, Repository<ManagementConcernSharedServiceDFSRating>>();
            builder.AddScoped<IRepository<ARMCapitalEMCRating>, Repository<ARMCapitalEMCRating>>();
            builder.AddScoped<IRepository<ManagementConcernARMCapital>, Repository<ManagementConcernARMCapital>>();
            builder.AddScoped<IRepository<ManagementConcernBusinessUnitARMCapitalRating>, Repository<ManagementConcernBusinessUnitARMCapitalRating>>();
            builder.AddScoped<IRepository<ManagementConcernSharedServiceARMCapitalRating>, Repository<ManagementConcernSharedServiceARMCapitalRating>>();
            builder.AddScoped<IRepository<AuditUniverseARMCapitalRating>, Repository<AuditUniverseARMCapitalRating>>();
            builder.AddScoped<IRepository<ARMCapitalAuditUniverse>, Repository<ARMCapitalAuditUniverse>>();
            builder.AddScoped<IRepository<StrategyARMCapitalRating>, Repository<StrategyARMCapitalRating>>();
            builder.AddScoped<IRepository<ARMCapitalBusinessRiskRating>, Repository<ARMCapitalBusinessRiskRating>>();
            builder.AddScoped<IRepository<OperationARMCapital>, Repository<OperationARMCapital>>();
            builder.AddScoped<IRepository<OperationARMCapitalRating>, Repository<OperationARMCapitalRating>>();
            builder.AddScoped<IRepository<FinancialARMCapital>, Repository<FinancialARMCapital>>();
            builder.AddScoped<IRepository<FinacialBusinessARMCapitalRating>, Repository<FinacialBusinessARMCapitalRating>>();
            builder.AddScoped<IRepository<ComplianceARMCapital>, Repository<ComplianceARMCapital>>();
            builder.AddScoped<IRepository<ComplianceBusinessARMCapitalRating>, Repository<ComplianceBusinessARMCapitalRating>>();
            builder.AddScoped<IRepository<TimeSinceLastAuditARMCapital>, Repository<TimeSinceLastAuditARMCapital>>();
            builder.AddScoped<IRepository<ManagementConcernBusinessUnitDFSRating>, Repository<ManagementConcernBusinessUnitDFSRating>>();
            builder.AddScoped<IRepository<ManagementConcernDFS>, Repository<ManagementConcernDFS>>();
            builder.AddScoped<IRepository<ARMTAMEMCRating>, Repository<ARMTAMEMCRating>>();
            builder.AddScoped<IRepository<DigitalFinancialServiceEMCRating>, Repository<DigitalFinancialServiceEMCRating>>();
            builder.AddScoped<IRepository<ARMSharedAuditUniverseCompliance>, Repository<ARMSharedAuditUniverseCompliance>>();
            builder.AddScoped<IRepository<ARMSharedAuditUniverseDataAnalytic>, Repository<ARMSharedAuditUniverseDataAnalytic>>();
            builder.AddScoped<IRepository<ARMSharedAuditUniverseFinancialControl>, Repository<ARMSharedAuditUniverseFinancialControl>>();
            builder.AddScoped<IRepository<ARMIMBusinessRiskRating>, Repository<ARMIMBusinessRiskRating>>();
            builder.AddScoped<IRepository<FinacialARMIMRating>, Repository<FinacialARMIMRating>>();
            builder.AddScoped<IRepository<ComplianceIMRatingARMIM>, Repository<ComplianceIMRatingARMIM>>();
            builder.AddScoped<IRepository<OperationARMIMRating>, Repository<OperationARMIMRating>>();
            builder.AddScoped<IRepository<StrategyIMRatingARMIM>, Repository<StrategyIMRatingARMIM>>();
            builder.AddScoped<IRepository<OperationDigitalFinancialService>, Repository<OperationDigitalFinancialService>>();
            builder.AddScoped<IRepository<StrategyDigitalFinancialService>, Repository<StrategyDigitalFinancialService>>();
            builder.AddScoped<IRepository<FinacialBusinessDigitalFinancialServiceRating>, Repository<FinacialBusinessDigitalFinancialServiceRating>>();
            builder.AddScoped<IRepository<OperationDigitalFinancialServiceRating>, Repository<OperationDigitalFinancialServiceRating>>();
            builder.AddScoped<IRepository<StrategyDigitalFinancialServiceRating>, Repository<StrategyDigitalFinancialServiceRating>>();
            builder.AddScoped<IRepository<ComplianceDigitalFinancialService>, Repository<ComplianceDigitalFinancialService>>();
            builder.AddScoped<IRepository<TimeSinceLastAuditDigitalFinancialService>, Repository<TimeSinceLastAuditDigitalFinancialService>>();
            builder.AddScoped<IRepository<ComplianceBusinessDigitalFinancialServiceRating>, Repository<ComplianceBusinessDigitalFinancialServiceRating>>();
            builder.AddScoped<IRepository<FinancialDigitalFinancialService>, Repository<FinancialDigitalFinancialService>>();
            builder.AddScoped<IRepository<DigitalFinancialServiceBusinessRiskRating>, Repository<DigitalFinancialServiceBusinessRiskRating>>();
            builder.AddScoped<IRepository<RatedBusinessRiskRating>, Repository<RatedBusinessRiskRating>>();
            builder.AddScoped<IRepository<BusinessRiskRating>, Repository<BusinessRiskRating>>();
            builder.AddScoped<IRepository<EMCConcernRiskRating>, Repository<EMCConcernRiskRating>>();
            builder.AddScoped<IRepository<ManagementConcernRiskRating>, Repository<ManagementConcernRiskRating>>();
            builder.AddScoped<IRepository<ARMHoldingCompanyEMCRating>, Repository<ARMHoldingCompanyEMCRating>>();
            builder.AddScoped<IRepository<ARMIMEMCRating>, Repository<ARMIMEMCRating>>();
            builder.AddScoped<IRepository<ARMSecurityEMCRating>, Repository<ARMSecurityEMCRating>>();
            builder.AddScoped<IRepository<ARMTrusteeEMCRating>, Repository<ARMTrusteeEMCRating>>();
            builder.AddScoped<IRepository<ARMHILLEMCRating>, Repository<ARMHILLEMCRating>>();
            builder.AddScoped<IRepository<ARMAgribusinessEMCRating>, Repository<ARMAgribusinessEMCRating>>();
            builder.AddScoped<IRepository<ARMSharedServiceEMCRating>, Repository<ARMSharedServiceEMCRating>>();
            builder.AddScoped<IRepository<ManagementConcernARMIM>, Repository<ManagementConcernARMIM>>();
            builder.AddScoped<IRepository<ManagementConcernBusinessUnitARMIMRating>, Repository<ManagementConcernBusinessUnitARMIMRating>>();
            builder.AddScoped<IRepository<ManagementConcernSharedServiceARMIMRating>, Repository<ManagementConcernSharedServiceARMIMRating>>();
            builder.AddScoped<IRepository<ManagementConcernARMTrustee>, Repository<ManagementConcernARMTrustee>>();
            builder.AddScoped<IRepository<ManagementConcernSharedServiceARTrusteeRating>, Repository<ManagementConcernSharedServiceARTrusteeRating>>();
            builder.AddScoped<IRepository<ManagementConcernBusinessUnitARMTrusteeRating>, Repository<ManagementConcernBusinessUnitARMTrusteeRating>>();
            builder.AddScoped<IRepository<ManagementConcernARMSecurity>, Repository<ManagementConcernARMSecurity>>();
            builder.AddScoped<IRepository<ManagementConcernSharedServiceARMSecurityRating>, Repository<ManagementConcernSharedServiceARMSecurityRating>>();
            builder.AddScoped<IRepository<ManagementConcernBusinessUnitARMSecurityRating>, Repository<ManagementConcernBusinessUnitARMSecurityRating>>();
            builder.AddScoped<IRepository<ManagementConcernARMHill>, Repository<ManagementConcernARMHill>>();
            builder.AddScoped<IRepository<ManagementConcernSharedServiceARMHillRating>, Repository<ManagementConcernSharedServiceARMHillRating>>();
            builder.AddScoped<IRepository<ManagementConcernBusinessUnitARMHillRating>, Repository<ManagementConcernBusinessUnitARMHillRating>>();
            builder.AddScoped<IRepository<ManagementConcernARMAgribusiness>, Repository<ManagementConcernARMAgribusiness>>();
            builder.AddScoped<IRepository<ManagementConcernBusinessUnitARMAgribusinessRating>, Repository<ManagementConcernBusinessUnitARMAgribusinessRating>>();
            builder.AddScoped<IRepository<ManagementConcernSharedServiceARMAgribusinessRating>, Repository<ManagementConcernSharedServiceARMAgribusinessRating>>();
            builder.AddScoped<IRepository<ARMHoldingCompanyBusinessRating>, Repository<ARMHoldingCompanyBusinessRating>>();
            builder.AddScoped<IRepository<StrategyBusinessRatingARMHoldCo>, Repository<StrategyBusinessRatingARMHoldCo>>();
            builder.AddScoped<IRepository<StrategyBusinessArmHoldCo>, Repository<StrategyBusinessArmHoldCo>>();
            builder.AddScoped<IRepository<StrategyBusinessTreasurySale>, Repository<StrategyBusinessTreasurySale>>();
            builder.AddScoped<IRepository<OperationDigitalFinancialService>, Repository<OperationDigitalFinancialService>>();
            builder.AddScoped<IRepository<StrategyDigitalFinancialServiceRating>, Repository<StrategyDigitalFinancialServiceRating>>();
            builder.AddScoped<IRepository<TimeSinceLastAuditDigitalFinancialService>, Repository<TimeSinceLastAuditDigitalFinancialService>>();
            builder.AddScoped<IRepository<OperationBusinessRatingARMHoldCo>, Repository<OperationBusinessRatingARMHoldCo>>();
            builder.AddScoped<IRepository<ComplianceBusinessDigitalFinancialServiceRating>, Repository<ComplianceBusinessDigitalFinancialServiceRating>>();
            builder.AddScoped<IRepository<FinancialDigitalFinancialService>, Repository<FinancialDigitalFinancialService>>();
            builder.AddScoped<IRepository<OperationBusinessTreasurySale>, Repository<OperationBusinessTreasurySale>>();
            builder.AddScoped<IRepository<OperationDigitalFinancialServiceRating>, Repository<OperationDigitalFinancialServiceRating>>();
            builder.AddScoped<IRepository<OperationBusinessArmHolco>, Repository<OperationBusinessArmHolco>>();
            builder.AddScoped<IRepository<DigitalFinancialServiceBusinessRiskRating>, Repository<DigitalFinancialServiceBusinessRiskRating>>();
            builder.AddScoped<IRepository<StrategyDigitalFinancialService>, Repository<StrategyDigitalFinancialService>>();
            builder.AddScoped<IRepository<DigitalFinancialServiceBusinessRiskRating>, Repository<DigitalFinancialServiceBusinessRiskRating>>();
            builder.AddScoped<IRepository<FinacialRatingBusinessratingTreasurySale>, Repository<FinacialRatingBusinessratingTreasurySale>>();
            builder.AddScoped<IRepository<FinancialReportingBusinessratingARMHoldCo>, Repository<FinancialReportingBusinessratingARMHoldCo>>();
            builder.AddScoped<IRepository<FinacialRatingBusinessratingARMHoldCo>, Repository<FinacialRatingBusinessratingARMHoldCo>>();
            builder.AddScoped<IRepository<ComplianceBusinessRatingARMHoldCo>, Repository<ComplianceBusinessRatingARMHoldCo>>();
            builder.AddScoped<IRepository<CompliancesBusinessRiskRatingARMHoldCo>, Repository<CompliancesBusinessRiskRatingARMHoldCo>>();
            builder.AddScoped<IRepository<CompliancesBusinessTreasurySale>, Repository<CompliancesBusinessTreasurySale>>();
            builder.AddScoped<IRepository<FinacialBusinessDigitalFinancialServiceRating>, Repository<FinacialBusinessDigitalFinancialServiceRating>>();
            builder.AddScoped<IRepository<StrategySharedServiceDataAnalytic>, Repository<StrategySharedServiceDataAnalytic>>();
            builder.AddScoped<IRepository<StrategySharedServiceCompliance>, Repository<StrategySharedServiceCompliance>>();
            builder.AddScoped<IRepository<TimeSinceLastAuditBusinessRatingARMHoldCo>, Repository<TimeSinceLastAuditBusinessRatingARMHoldCo>>();
            builder.AddScoped<IRepository<TimeSinceLastBusinessARMTAMAudit>, Repository<TimeSinceLastBusinessARMTAMAudit>>();
            builder.AddScoped<IRepository<ComplianceBusinessTAMRating>, Repository<ComplianceBusinessTAMRating>>();
            builder.AddScoped<IRepository<FinacialBusinessTAMRating>, Repository<FinacialBusinessTAMRating>>();
            builder.AddScoped<IRepository<OperationSharedServiceFinancialControlRating>, Repository<OperationSharedServiceFinancialControlRating>>();
            builder.AddScoped<IRepository<OperationSharedServiceDataAnalyticRating>, Repository<OperationSharedServiceDataAnalyticRating>>();
            builder.AddScoped<IRepository<OperationSharedServiceComplianceRating>, Repository<OperationSharedServiceComplianceRating>>();
            builder.AddScoped<IRepository<StrategySharedServiceFinancialControl>, Repository<StrategySharedServiceFinancialControl>>();
            builder.AddScoped<IRepository<ComplianceSharedServiceDataAnalyticRating>, Repository<ComplianceSharedServiceDataAnalyticRating>>();
            builder.AddScoped<IRepository<ComplianceBusinessARMTAM>, Repository<ComplianceBusinessARMTAM>>();
            builder.AddScoped<IRepository<FinancialBusinessARMTAM>, Repository<FinancialBusinessARMTAM>>();
            builder.AddScoped<IRepository<ComplianceSharedServiceComplianceRating>, Repository<ComplianceSharedServiceComplianceRating>>();
            builder.AddScoped<IRepository<OperationBusinessARMTAM>, Repository<OperationBusinessARMTAM>>();
            builder.AddScoped<IRepository<StrategyBusinessTAMRating>, Repository<StrategyBusinessTAMRating>>();
            builder.AddScoped<IRepository<ComplianceSharedServiceFinancialControlRating>, Repository<ComplianceSharedServiceFinancialControlRating>>();
            builder.AddScoped<IRepository<StrategyBusinessARMTAM>, Repository<StrategyBusinessARMTAM>>();
            builder.AddScoped<IRepository<ARMTAMBusinessRiskRating>, Repository<ARMTAMBusinessRiskRating>>();
            builder.AddScoped<IRepository<OperationBusinessTAMRating>, Repository<OperationBusinessTAMRating>>();
            builder.AddScoped<IRepository<FinacialIMRatingARMRegistrar>, Repository<FinacialIMRatingARMRegistrar>>();
            builder.AddScoped<IRepository<FinancialIMBusinessRating>, Repository<FinancialIMBusinessRating>>();
            builder.AddScoped<IRepository<ComplianceIMBusinessRating>, Repository<ComplianceIMBusinessRating>>();
            builder.AddScoped<IRepository<ComplianceIMRatingFundAccount>, Repository<ComplianceIMRatingFundAccount>>();
            builder.AddScoped<IRepository<FinacialIMRatingOperationSettlement>, Repository<FinacialIMRatingOperationSettlement>>();
            builder.AddScoped<IRepository<ComplianceIMRatingOperationControl>, Repository<ComplianceIMRatingOperationControl>>();
            builder.AddScoped<IRepository<TimeSinceLastAuditIMBusinessRating>, Repository<TimeSinceLastAuditIMBusinessRating>>();
            builder.AddScoped<IRepository<ComplianceIMRatingFundAdmin>, Repository<ComplianceIMRatingFundAdmin>>();
            builder.AddScoped<IRepository<ComplianceIMRating>, Repository<ComplianceIMRating>>();
            builder.AddScoped<IRepository<ComplianceIMRatingBDPWMIAMIMRetail>, Repository<ComplianceIMRatingBDPWMIAMIMRetail>>();
            builder.AddScoped<IRepository<FinacialIMRatingOperationControl>, Repository<FinacialIMRatingOperationControl>>();
            builder.AddScoped<IRepository<ComplianceIMRatingARMRegistrar>, Repository<ComplianceIMRatingARMRegistrar>>();
            builder.AddScoped<IRepository<ComplianceIMRatingOperationSettlement>, Repository<ComplianceIMRatingOperationSettlement>>();
            builder.AddScoped<IRepository<FinacialIMRatingFundAccount>, Repository<FinacialIMRatingFundAccount>>();
            builder.AddScoped<IRepository<ComplianceIMRatingRetailOperation>, Repository<ComplianceIMRatingRetailOperation>>();
            builder.AddScoped<IRepository<FinacialIMRatingBDPWMIAMIMRetail>, Repository<FinacialIMRatingBDPWMIAMIMRetail>>();
            builder.AddScoped<IRepository<FinacialIMBusinessRating>, Repository<FinacialIMBusinessRating>>();
            builder.AddScoped<IRepository<FinacialIMRatingFundAdmin>, Repository<FinacialIMRatingFundAdmin>>();
            builder.AddScoped<IRepository<FinacialIMRatingRetailOperation>, Repository<FinacialIMRatingRetailOperation>>();
            builder.AddScoped<IRepository<StrategyIMRatingARMRegistrar>, Repository<StrategyIMRatingARMRegistrar>>();
            builder.AddScoped<IRepository<StrategyIMRatingBDPWMIAMIMRetail>, Repository<StrategyIMRatingBDPWMIAMIMRetail>>();
            builder.AddScoped<IRepository<StrategyIMRating>, Repository<StrategyIMRating>>();
            builder.AddScoped<IRepository<StrategyIMRatingFundAccount>, Repository<StrategyIMRatingFundAccount>>();
            builder.AddScoped<IRepository<StrategyIMRatingFundAdmin>, Repository<StrategyIMRatingFundAdmin>>();
            builder.AddScoped<IRepository<StrategyIMRatingRetailOperation>, Repository<StrategyIMRatingRetailOperation>>();
            builder.AddScoped<IRepository<StrategyIMRatingOperationSettlement>, Repository<StrategyIMRatingOperationSettlement>>();
            builder.AddScoped<IRepository<StrategyIMRatingOperationControl>, Repository<StrategyIMRatingOperationControl>>();
            builder.AddScoped<IRepository<StrategyImBusinessRating>, Repository<StrategyImBusinessRating>>();
            builder.AddScoped<IRepository<OperationIMRatingARMRegistrar>, Repository<OperationIMRatingARMRegistrar>>();
            builder.AddScoped<IRepository<OperationIMRatingRetailOperation>, Repository<OperationIMRatingRetailOperation>>();
            builder.AddScoped<IRepository<OperationIMRatingFundAdmin>, Repository<OperationIMRatingFundAdmin>>();
            builder.AddScoped<IRepository<OperationIMRatingFundAccount>, Repository<OperationIMRatingFundAccount>>();
            builder.AddScoped<IRepository<OperationIMRatingBDPWMIAMIMRetail>, Repository<OperationIMRatingBDPWMIAMIMRetail>>();
            builder.AddScoped<IRepository<OperationIMBusinessRating>, Repository<OperationIMBusinessRating>>();
            builder.AddScoped<IRepository<OperationIMRatingOperationSettlement>, Repository<OperationIMRatingOperationSettlement>>();
            builder.AddScoped<IRepository<OperationIMUnitRating>, Repository<OperationIMUnitRating>>();
            builder.AddScoped<IRepository<OperationIMRatingOperationControl>, Repository<OperationIMRatingOperationControl>>();
            builder.AddScoped<IRepository<TimeSinceLastSecurityAudit>, Repository<TimeSinceLastSecurityAudit>>();
            builder.AddScoped<IRepository<ComplianceSecurity>, Repository<ComplianceSecurity>>();
            builder.AddScoped<IRepository<AuditUniverseARMIMRating>, Repository<AuditUniverseARMIMRating>>();
            builder.AddScoped<IRepository<ARMSecurityRating>, Repository<ARMSecurityRating>>();
            builder.AddScoped<IRepository<StrategySecurityRatingStockBroking>, Repository<StrategySecurityRatingStockBroking>>();
            builder.AddScoped<IRepository<FinacialSecurityRatingStockBroking>, Repository<FinacialSecurityRatingStockBroking>>();
            builder.AddScoped<IRepository<ComplianceSecurityRatingStockBroking>, Repository<ComplianceSecurityRatingStockBroking>>();
            builder.AddScoped<IRepository<OperationSecurityBusinessRating>, Repository<OperationSecurityBusinessRating>>();
            builder.AddScoped<IRepository<StrategySecurityBusinessRating>, Repository<StrategySecurityBusinessRating>>();
            builder.AddScoped<IRepository<FinancialSecurityReporting>, Repository<FinancialSecurityReporting>>();
            builder.AddScoped<IRepository<OperationSecurityRatingStockBroking>, Repository<OperationSecurityRatingStockBroking>>();
            builder.AddScoped<IRepository<ComplianceBusinessRatingTrustee>, Repository<ComplianceBusinessRatingTrustee>>();
            builder.AddScoped<IRepository<FinacialTrusteeRatingCommercialTrust>, Repository<FinacialTrusteeRatingCommercialTrust>>();
            builder.AddScoped<IRepository<ComplianceTrusteeRatingPrivateTrust>, Repository<ComplianceTrusteeRatingPrivateTrust>>();
            builder.AddScoped<IRepository<TimeSinceLastTrusteeAudit>, Repository<TimeSinceLastTrusteeAudit>>();
            builder.AddScoped<IRepository<FinacialTrusteeRatingPrivateTrust>, Repository<FinacialTrusteeRatingPrivateTrust>>();
            builder.AddScoped<IRepository<ComplianceTrusteeRatingCommercialTrust>, Repository<ComplianceTrusteeRatingCommercialTrust>>();
            builder.AddScoped<IRepository<FinancialTrusteeReporting>, Repository<FinancialTrusteeReporting>>();
            builder.AddScoped<IRepository<OperationTrustee>, Repository<OperationTrustee>>();
            builder.AddScoped<IRepository<OperationTrusteeRatingCommercialTrust>, Repository<OperationTrusteeRatingCommercialTrust>>();
            builder.AddScoped<IRepository<OperationTrusteeRatingPrivateTrust>, Repository<OperationTrusteeRatingPrivateTrust>>();
            builder.AddScoped<IRepository<StrategyTrusteeRatingPrivateTrust>, Repository<StrategyTrusteeRatingPrivateTrust>>();
            builder.AddScoped<IRepository<StrategyTrusteeRatingCommercialTrust>, Repository<StrategyTrusteeRatingCommercialTrust>>();
            builder.AddScoped<IRepository<ARMTrusteeRating>, Repository<ARMTrusteeRating>>();
            builder.AddScoped<IRepository<StrategyBusinessRatingTrustee>, Repository<StrategyBusinessRatingTrustee>>();
            builder.AddScoped<IRepository<ComplianceHillRating>, Repository<ComplianceHillRating>>();
            builder.AddScoped<IRepository<TimeSinceLastHillAudit>, Repository<TimeSinceLastHillAudit>>();
            builder.AddScoped<IRepository<ComplianceBusinessRatingHill>, Repository<ComplianceBusinessRatingHill>>();
            builder.AddScoped<IRepository<StrategyHillRating>, Repository<StrategyHillRating>>();
            builder.AddScoped<IRepository<FinancialHillReporting>, Repository<FinancialHillReporting>>();
            builder.AddScoped<IRepository<OperationBusinessRatingHill>, Repository<OperationBusinessRatingHill>>();
            builder.AddScoped<IRepository<FinacialHillRating>, Repository<FinacialHillRating>>();
            builder.AddScoped<IRepository<OperationHillRating>, Repository<OperationHillRating>>();
            builder.AddScoped<IRepository<StrategyBusinessRatingARMHill>, Repository<StrategyBusinessRatingARMHill>>();
            builder.AddScoped<IRepository<ARMHillRating>, Repository<ARMHillRating>>();
            builder.AddScoped<IRepository<ComplianceAgribusiness>, Repository<ComplianceAgribusiness>>();
            builder.AddScoped<IRepository<FinacialAgribusinessRatingAAFML>, Repository<FinacialAgribusinessRatingAAFML>>();
            builder.AddScoped<IRepository<ComplianceAgribusinessRatingAAFML>, Repository<ComplianceAgribusinessRatingAAFML>>();
            builder.AddScoped<IRepository<ComplianceAgribusinessRatingRFl>, Repository<ComplianceAgribusinessRatingRFl>>();
            builder.AddScoped<IRepository<FinacialAgribusinessRatingRFl>, Repository<FinacialAgribusinessRatingRFl>>();
            builder.AddScoped<IRepository<TimeSinceLastAgribusinessAudit>, Repository<TimeSinceLastAgribusinessAudit>>();
            builder.AddScoped<IRepository<FinancialAgribusinessReporting>, Repository<FinancialAgribusinessReporting>>();
            builder.AddScoped<IRepository<OperationAgribusiness>, Repository<OperationAgribusiness>>();
            builder.AddScoped<IRepository<StrategyAgribusinessRatingAAFML>, Repository<StrategyAgribusinessRatingAAFML>>();
            builder.AddScoped<IRepository<OperationAgribusinessRatingRFl>, Repository<OperationAgribusinessRatingRFl>>();
            builder.AddScoped<IRepository<StrategyAgribusinessRatingRFl>, Repository<StrategyAgribusinessRatingRFl>>();
            builder.AddScoped<IRepository<OperationAgribusinessRatingAAFML>, Repository<OperationAgribusinessRatingAAFML>>();
            builder.AddScoped<IRepository<StrategyAgribusiness>, Repository<StrategyAgribusiness>>();
            builder.AddScoped<IRepository<ARMAgribusinessRating>, Repository<ARMAgribusinessRating>>();
            builder.AddScoped<IRepository<ComplianceSharedService>, Repository<ComplianceSharedService>>();
            builder.AddScoped<IRepository<ComplianceSharedServiceRatingMCC>, Repository<ComplianceSharedServiceRatingMCC>>();
            builder.AddScoped<IRepository<ComplianceSharedServiceRatingHCM>, Repository<ComplianceSharedServiceRatingHCM>>();
            builder.AddScoped<IRepository<ComplianceSharedServiceRatingProcurementAndAdmin>, Repository<ComplianceSharedServiceRatingProcurementAndAdmin>>();
            builder.AddScoped<IRepository<ComplianceSharedServiceRatingCTO>, Repository<ComplianceSharedServiceRatingCTO>>();
            builder.AddScoped<IRepository<ComplianceSharedServiceRatingInformationSecurity>, Repository<ComplianceSharedServiceRatingInformationSecurity>>();
            builder.AddScoped<IRepository<ComplianceSharedServiceRatingLegal>, Repository<ComplianceSharedServiceRatingLegal>>();
            builder.AddScoped<IRepository<TimeSinceLastSharedServiceAudit>, Repository<TimeSinceLastSharedServiceAudit>>();
            builder.AddScoped<IRepository<ComplianceSharedServiceRatingCustomerexperience>, Repository<ComplianceSharedServiceRatingCustomerexperience>>();
            builder.AddScoped<IRepository<ComplianceSharedServiceRatingIT>, Repository<ComplianceSharedServiceRatingIT>>();
            builder.AddScoped<IRepository<ComplianceSharedServiceRatingRiskManagement>, Repository<ComplianceSharedServiceRatingRiskManagement>>();
            builder.AddScoped<IRepository<ComplianceSharedServiceRatingAcademy>, Repository<ComplianceSharedServiceRatingAcademy>>();
            builder.AddScoped<IRepository<ComplianceSharedServiceRatingCorporatestrategy>, Repository<ComplianceSharedServiceRatingCorporatestrategy>>();
            builder.AddScoped<IRepository<ComplianceSharedServiceRatingTreasury>, Repository<ComplianceSharedServiceRatingTreasury>>();
            builder.AddScoped<IRepository<ComplianceSharedServiceRatingInternalControl>, Repository<ComplianceSharedServiceRatingInternalControl>>();
            builder.AddScoped<IRepository<OperationSharedServiceRatingLegal>, Repository<OperationSharedServiceRatingLegal>>();
            builder.AddScoped<IRepository<OperationSharedServiceRatingHCM>, Repository<OperationSharedServiceRatingHCM>>();
            builder.AddScoped<IRepository<OperationSharedServiceRatingCustomerexperience>, Repository<OperationSharedServiceRatingCustomerexperience>>();
            builder.AddScoped<IRepository<OperationSharedServiceRatingCorporatestrategy>, Repository<OperationSharedServiceRatingCorporatestrategy>>();
            builder.AddScoped<IRepository<OperationSharedServiceRatingCTO>, Repository<OperationSharedServiceRatingCTO>>();
            builder.AddScoped<IRepository<OperationSharedServiceRatingTreasury>, Repository<OperationSharedServiceRatingTreasury>>();
            builder.AddScoped<IRepository<OperationSharedServiceRatingInternalControl>, Repository<OperationSharedServiceRatingInternalControl>>();
            builder.AddScoped<IRepository<OperationSharedServiceRatingRiskManagement>, Repository<OperationSharedServiceRatingRiskManagement>>();
            builder.AddScoped<IRepository<OperationSharedServiceRatingMCC>, Repository<OperationSharedServiceRatingMCC>>();
            builder.AddScoped<IRepository<OperationSharedServiceRatingIT>, Repository<OperationSharedServiceRatingIT>>();
            builder.AddScoped<IRepository<OperationSharedServiceRatingInformationSecurity>, Repository<OperationSharedServiceRatingInformationSecurity>>();
            builder.AddScoped<IRepository<OperationSharedServiceRatingAcademy>, Repository<OperationSharedServiceRatingAcademy>>();
            builder.AddScoped<IRepository<OperationSharedServiceRatingProcurementAndAdmin>, Repository<OperationSharedServiceRatingProcurementAndAdmin>>();
            builder.AddScoped<IRepository<OperationSharedService>, Repository<OperationSharedService>>();

            builder.AddScoped<IRepository<StrategySharedService>, Repository<StrategySharedService>>();
            builder.AddScoped<IRepository<StrategySharedServiceRatingAcademy>, Repository<StrategySharedServiceRatingAcademy>>();
            builder.AddScoped<IRepository<StrategySharedServiceRatingCorporatestrategy>, Repository<StrategySharedServiceRatingCorporatestrategy>>();
            builder.AddScoped<IRepository<StrategySharedServiceRatingCustomerexperience>, Repository<StrategySharedServiceRatingCustomerexperience>>();
            builder.AddScoped<IRepository<StrategySharedServiceRatingTreasury>, Repository<StrategySharedServiceRatingTreasury>>();
            builder.AddScoped<IRepository<StrategySharedServiceRatingIT>, Repository<StrategySharedServiceRatingIT>>();
            builder.AddScoped<IRepository<StrategySharedServiceRatingProcurementAndAdmin>, Repository<StrategySharedServiceRatingProcurementAndAdmin>>();
            builder.AddScoped<IRepository<StrategySharedServiceRatingCTO>, Repository<StrategySharedServiceRatingCTO>>();
            builder.AddScoped<IRepository<StrategySharedServiceRatingInternalControl>, Repository<StrategySharedServiceRatingInternalControl>>();
            builder.AddScoped<IRepository<StrategySharedServiceRatingHCM>, Repository<StrategySharedServiceRatingHCM>>();
            builder.AddScoped<IRepository<StrategySharedServiceRatingMCC>, Repository<StrategySharedServiceRatingMCC>>();
            builder.AddScoped<IRepository<StrategySharedServiceRatingInformationSecurity>, Repository<StrategySharedServiceRatingInformationSecurity>>();
            builder.AddScoped<IRepository<StrategySharedServiceRatingLegal>, Repository<StrategySharedServiceRatingLegal>>();
            builder.AddScoped<IRepository<StrategySharedServiceRatingRiskManagement>, Repository<StrategySharedServiceRatingRiskManagement>>();
            builder.AddScoped<IRepository<ARMSharedServiceRating>, Repository<ARMSharedServiceRating>>();

            builder.AddScoped<IRepository<ARMTAMAuditUniverse>, Repository<ARMTAMAuditUniverse>>();
            builder.AddScoped<IRepository<DigitalFinancialServiceAuditUniverse>, Repository<DigitalFinancialServiceAuditUniverse>>();
            builder.AddScoped<IRepository<AuditUniverseARMTAM>, Repository<AuditUniverseARMTAM>>();
            builder.AddScoped<IRepository<AuditUniverseDigitalFinancialServiceRating>, Repository<AuditUniverseDigitalFinancialServiceRating>>();
            builder.AddScoped<IRepository<AuditUniverseARMHoldCoTreasurySale>, Repository<AuditUniverseARMHoldCoTreasurySale>>();
            builder.AddScoped<IRepository<AuditUniverseARMHoldingCompany>, Repository<AuditUniverseARMHoldingCompany>>();
            builder.AddScoped<IRepository<ARMHoldingCompanyAnnualAuditUniverse>, Repository<ARMHoldingCompanyAnnualAuditUniverse>>();
            builder.AddScoped<IRepository<AuditUniverseARMIMIMUnit>, Repository<AuditUniverseARMIMIMUnit>>();
            builder.AddScoped<IRepository<AuditUniverseARMIMBDPWMIAMIMRetail>, Repository<AuditUniverseARMIMBDPWMIAMIMRetail>>();
            builder.AddScoped<IRepository<AuditUniverseARMIMFundAccount>, Repository<AuditUniverseARMIMFundAccount>>();
            builder.AddScoped<IRepository<AuditUniverseARMIMFundAdmin>, Repository<AuditUniverseARMIMFundAdmin>>();
            builder.AddScoped<IRepository<AuditUniverseARMIMRetailOperation>, Repository<AuditUniverseARMIMRetailOperation>>();
            builder.AddScoped<IRepository<AuditUniverseARMIMRegistrar>, Repository<AuditUniverseARMIMRegistrar>>();
            builder.AddScoped<IRepository<AnualAuditUniverseRiskRating>, Repository<AnualAuditUniverseRiskRating>>();
            builder.AddScoped<IRepository<ARMIMAuditUniverse>, Repository<ARMIMAuditUniverse>>();
            builder.AddScoped<IRepository<AuditUniverseARMIMOperationControl>, Repository<AuditUniverseARMIMOperationControl>>();
            builder.AddScoped<IRepository<AuditUniverseARMIMOperationSettlement>, Repository<AuditUniverseARMIMOperationSettlement>>();
            builder.AddScoped<IRepository<AuditUniverseARMSecurityStockBroking>, Repository<AuditUniverseARMSecurityStockBroking>>();
            builder.AddScoped<IRepository<AuditUniverseARMSecurityInvestmentBanking>, Repository<AuditUniverseARMSecurityInvestmentBanking>>();
            builder.AddScoped<IRepository<AuditUniverseARMSecurityResearch>, Repository<AuditUniverseARMSecurityResearch>>();
            builder.AddScoped<IRepository<ARMSecurityAnnualAuditUniverse>, Repository<ARMSecurityAnnualAuditUniverse>>();
            builder.AddScoped<IRepository<AuditUniverseARMTrusteeCommercialTrust>, Repository<AuditUniverseARMTrusteeCommercialTrust>>();
            builder.AddScoped<IRepository<AuditUniverseARMHill>, Repository<AuditUniverseARMHill>>();
            builder.AddScoped<IRepository<AuditUniverseARMTrusteePrivateTrust>, Repository<AuditUniverseARMTrusteePrivateTrust>>();
            builder.AddScoped<IRepository<ARMHillAuditUniverse>, Repository<ARMHillAuditUniverse>>();
            builder.AddScoped<IRepository<ARMTrusteeAuditUniverse>, Repository<ARMTrusteeAuditUniverse>>();
            builder.AddScoped<IRepository<ARMAgribusinessAuditUniverse>, Repository<ARMAgribusinessAuditUniverse>>();
            builder.AddScoped<IRepository<AuditUniverseARMAgribusinessRFL>, Repository<AuditUniverseARMAgribusinessRFL>>();
            builder.AddScoped<IRepository<AuditUniverseARMAgribusinessAAFML>, Repository<AuditUniverseARMAgribusinessAAFML>>();
            builder.AddScoped<IRepository<ARMSharedAuditUniverse>, Repository<ARMSharedAuditUniverse>>();
            builder.AddScoped<IRepository<ARMSharedAuditUniverseCTO>, Repository<ARMSharedAuditUniverseCTO>>();
            builder.AddScoped<IRepository<ARMSharedAuditUniverseCustomerExperience>, Repository<ARMSharedAuditUniverseCustomerExperience>>();
            builder.AddScoped<IRepository<ARMSharedAuditUniverseAcademy>, Repository<ARMSharedAuditUniverseAcademy>>();
            builder.AddScoped<IRepository<ARMSharedAuditUniverseInformationSecurity>, Repository<ARMSharedAuditUniverseInformationSecurity>>();
            builder.AddScoped<IRepository<ARMSharedAuditUniverseHCM>, Repository<ARMSharedAuditUniverseHCM>>();
            builder.AddScoped<IRepository<ARMSharedAuditUniverseLegal>, Repository<ARMSharedAuditUniverseLegal>>();
            builder.AddScoped<IRepository<ARMSharedAuditUniverseProcurementAndAdmin>, Repository<ARMSharedAuditUniverseProcurementAndAdmin>>();
            builder.AddScoped<IRepository<ARMSharedAuditUniverseTreasury>, Repository<ARMSharedAuditUniverseTreasury>>();
            builder.AddScoped<IRepository<ARMSharedAuditUniverseCorporatestrategy>, Repository<ARMSharedAuditUniverseCorporatestrategy>>();
            builder.AddScoped<IRepository<ARMSharedAuditUniverseMCC>, Repository<ARMSharedAuditUniverseMCC>>();
            builder.AddScoped<IRepository<ARMSharedAuditUniverseRiskManagement>, Repository<ARMSharedAuditUniverseRiskManagement>>();
            builder.AddScoped<IRepository<ARMSharedAuditUniverseInternalControl>, Repository<ARMSharedAuditUniverseInternalControl>>();
            builder.AddScoped<IRepository<ARMSharedAuditUniverseIT>, Repository<ARMSharedAuditUniverseIT>>();

            builder.AddScoped<IRepository<MonthlyARMHillRating>, Repository<MonthlyARMHillRating>>();
            builder.AddScoped<IRepository<MonthlyARMIMRating>, Repository<MonthlyARMIMRating>>();
            builder.AddScoped<IRepository<MonthlyARMAgribusinessRating>, Repository<MonthlyARMAgribusinessRating>>();
            builder.AddScoped<IRepository<MonthlyARMSecurityRating>, Repository<MonthlyARMSecurityRating>>();
            builder.AddScoped<IRepository<MonthlyARMTrusteeRating>, Repository<MonthlyARMTrusteeRating>>();
            builder.AddScoped<IRepository<MonthlyARMSharedServiceRating>, Repository<MonthlyARMSharedServiceRating>>();
            builder.AddScoped<IRepository<MonthlyARMHoldingCompanyRating>, Repository<MonthlyARMHoldingCompanyRating>>();
            builder.AddScoped<ICurrentUserService, CurrentUserService>();
            builder.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            builder.AddScoped<IValidator<TimeSinceLastAuditReq>, TimeSinceLastAuditReqValidation>();
            builder.AddScoped<IValidator<ComplianceRatingReq>, ComplianceRatingReqValidation>();
            builder.AddScoped<IValidator<CompliancesReq>, CompliancesReqValidation>();
            builder.AddScoped<IValidator<FinacialRatingReq>, FinacialRatingReqValidation>();
            builder.AddScoped<IValidator<FinancialReportingReq>, FinancialReportingReqValidation>();
            builder.AddScoped<IValidator<OperationRatingReq>, OperationRatingReqValidation>();
            builder.AddScoped<IValidator<OperationReq>, OperationReqValidation>();
            builder.AddScoped<IValidator<StrategyRatingReq>, StrategyRatingReqValidation>();
            builder.AddScoped<IValidator<StrategyReq>, StrategyReqValidation>();
            builder.AddScoped<IValidator<ARMHoldingCompanyRatingReq>, ARMHoldingCompanyRatingReqValidation>();
            builder.AddScoped<IValidator<ARMHoldingCompanyRequest>, ARMHoldingCompanyRequestValidation>();
            builder.AddScoped<IValidator<ARMTAMRequest>, ARMTAMRequestValidation>();
            builder.AddScoped<IValidator<ARMTAMBusinessRiskRatingReq>, ARMTAMBusinessRiskRatingReqValidation>();
            builder.AddScoped<IValidator<StrategyBusinessARMTAMReq>, StrategyBusinessARMTAMReqValidation>();
            builder.AddScoped<IValidator<OperationBusinessARMTAMReq>, OperationBusinessARMTAMReqValidation>();
            builder.AddScoped<IValidator<FinancialBusinessARMTAMReq>, FinancialBusinessARMTAMReqValidation>();
            builder.AddScoped<IValidator<ComplianceBusinessARMTAMReq>, ComplianceBusinessARMTAMReqValidation>();
            builder.AddScoped<IValidator<TimeSinceLastBusinessARMTAMAuditReq>, TimeSinceLastBusinessARMTAMAuditReqValidation>();
            builder.AddScoped<IValidator<ARMIMRequest>, ARMIMRequestValidation>();
            builder.AddScoped<IValidator<ARMIMBusinessRiskRatingReq>, ARMIMBusinessRiskRatingReqValidation>();
            builder.AddScoped<IValidator<RejectBusinessRiskRatingDto>, RejectBusinessRiskRatingDtoValidation>();
            builder.AddScoped<IValidator<DigitalFinancialServicesRequest>, DigitalFinancialServicesRequestValidation>();
            builder.AddScoped<IValidator<DigitalFinancialServicesBusinessRiskRatingReq>, DigitalFinancialServicesBusinessRiskRatingReqValidation>();
            builder.AddScoped<IValidator<StrategyBusinessDigitalFinancialServicesReq>, StrategyBusinessDigitalFinancialServicesReqValidation>();
            builder.AddScoped<IValidator<OperationBusinessDigitalFinancialServiceReq>, OperationBusinessDigitalFinancialServiceReqValidation>();
            builder.AddScoped<IValidator<FinancialDigitalFinancialServicesReq>, FinancialDigitalFinancialServicesReqValidation>();
            builder.AddScoped<IValidator<ComplianceDigitalFinancialServicesReq>, ComplianceDigitalFinancialServicesReqValidation>();
            builder.AddScoped<IValidator<TimeSinceLastAuditDigitalFinancialServicesReq>, TimeSinceLastAuditDigitalFinancialServicesReqValidation>();

            return builder;
        }
    }
}
