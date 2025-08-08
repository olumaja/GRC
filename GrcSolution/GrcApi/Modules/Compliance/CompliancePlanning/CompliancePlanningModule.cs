using Arm.GrcApi.Modules.InternalControl;
using Arm.GrcApi.Modules.RiskManagement.AuditPlan;
using Arm.GrcApi.Modules.RiskManagement.PRA;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.Compliance.CompliancePlanning;
using GrcApi.Modules.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Arm.GrcApi.Modules.Compliance.CompliancePlanning
{   
    public class CompliancePlanningModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {

            // this line creates the endpoint header on swagger
            var routeGroup = app.MapGroup("/cp").WithTags(new string[] { "Compliance Planning" });
            var routeGroup2 = app.MapGroup("/crp").WithTags(new string[] { "Compliance Regulator Payment" });

            //GET /regulatorrule/export/excel 
            routeGroup.MapGet("/regulatorrule/export/excel", DownloadComplianceRulefile.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Planning: Regulator Rule Download Excel Template"
                })
                .RequireAuthorization("ComplianceOfficerOnly")
                .WithName("DownloadComplianceRulefile")
                .Produces<GetRegulatorDetailsResponse>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /regulatorrule/upload/excel
            routeGroup.MapPost("/regulatorrule/upload/excel", ExcelUploadForNewRuleEndpoint.HandleAsync) 
                 .AddEndpointFilter<ValidationFilter<RuleExcelUpload>>()
                .Accepts<RuleExcelUpload>("multipart/form-data")
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Planning: Excel Upload For New Rule"
                })
                .RequireAuthorization("ComplianceOfficerOnly")
                .WithName("ExcelUploadForNewRuleEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            //POST /createbusiness
            routeGroup.MapPost("/createbusiness", CreateBusinessEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ComplianceBusinesDto>>()
                .Accepts<ComplianceBusinesDto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Planning: Create new Business"
                })
                .RequireAuthorization("ComplianceOfficerOnly")
                .WithName("CreateBusinessEndpoint")
                .Produces<AddNewBusinessResp>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /update-business
            routeGroup.MapPost("/update-business", UpdateBusinessEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<UpdateComplianceBusinesDto>>()
                .Accepts<UpdateComplianceBusinesDto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Planning: Update Business"
                })
                .RequireAuthorization("ComplianceOfficerOnly")
                .WithName("UpdateBusinessEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-createdbusineses   
            routeGroup.MapGet("/get-createdbusineses", GetCreatedBusinessUnitEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Planning: Get list of the created businesses"
                })
                 .RequireAuthorization()
                .WithName("GetCreatedBusinessUnitEndpoint")
                .Produces<List<GetComplianceBusinesResponse>>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-createdbusineses/00000000-0000-0000-0000-000000000000
            routeGroup.MapGet("/get-createdbusineses/{businessId:guid}", GetBusinessByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Planning: Get created business by id"
                })
                 .RequireAuthorization("ComplianceOfficerOnly")
                .WithName("GetBusinessByIdEndpoint")
                .Produces<List<GetComplianceBusinesByIdResponse>>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /get-departments   
            routeGroup.MapGet("/get-departments", GetDepartmentEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Planning: Get list of the departments"
                })
                 .RequireAuthorization("ComplianceOfficerOnly")
                .WithName("GetDepartmentEndpoint")
                .Produces<List<GetComplianceDeparment>>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /createnewregulator
            routeGroup.MapPost("/createnewregulator", CreateNewRegulatorEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ComplianceRegulatorDto>>()
                .Accepts<ComplianceRegulatorDto>(GRCConstants.applicationOrJson)

                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Planning: Create new regulator"
                })
                .RequireAuthorization("ComplianceOfficerOnly")
                .WithName("CreateNewRegulatorEndpoint")
                .Produces<CreateNewRegulatorResp>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /getregulators   
            routeGroup.MapGet("/getregulators", GetRegulatorsEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Planning: Get regulators"
                })
                .RequireAuthorization("ComplianceOfficerOnly")
                .WithName("GetRegulatorsEndpoint")
                .Produces<List<GetRegulatorDetailsResponse>>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /getregulator/{regulatorid:guid}   
            routeGroup.MapGet("/getregulator/{regulatorid:guid}", GetRegulatorByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Planning: Get Created Regulator by Id "
                })
                 .RequireAuthorization("ComplianceOfficerOnly")
                .WithName("GetRegulatorByIdEndpoint")
                .Produces<GetComplianceRegulatorById>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /addnewrule
            routeGroup.MapPost("/addnewrule", AddNewRuleEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ComplianceRulesAndRegulatorDto>>()
                .Accepts<ComplianceRulesAndRegulatorDto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Planning: Add new rule and regulation"
                })
                .RequireAuthorization("ComplianceOfficerOnly")
                .WithName("AddNewRuleEndpoint")
                .Produces<AddNewRuleResp>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            //GET /viewcreatedrules/00000000-0000-0000-0000-000000000000  
            routeGroup.MapGet("/viewcreatedrules/{regulatorId:guid}", ViewCreatedRuleEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Planning: View Created rules "
                })
                .RequireAuthorization("ComplianceOfficerOnly")
                .WithName("ViewCreatedRuleEndpoint")
                .Produces<List<GetRulesAndRegulatorDetail>>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /getcreatedrules/{ruleid:guid}   
            routeGroup.MapGet("/getcreatedrules/{ruleid:guid}", GetCreatedRuleByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Planning: Get Created rules by Id "
                })
                .WithName("GetCreatedRuleByIdEndpoint")
                .Produces<GetRulesAndRegulatorDetail>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /update-createdrule
            routeGroup.MapPost("/update-createdrule", UpdateCreatedRuleEndpoint.HandleAsync)
                 .Accepts<UpdateComplianceRulesAndRegulator>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Planning: Update Created rules by Id "
                })
                .RequireAuthorization("ComplianceOfficerOnly")
                .WithName("UpdateCreatedRuleEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /complianceattachedreport/export/excel 
            routeGroup.MapGet("/complianceattachedreport/export/excel", DownloadComplianceReport.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Planning: Download Compliance Attached Report to Excel."
                })
                .RequireAuthorization("ComplianceOfficerOnly")
                .WithName("DownloadComplianceReport")
                .Produces<ComplianceCalendar>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            //GET /viewcompliancelevel   
            routeGroup.MapGet("/viewcompliancelevel", ViewComplianceLevelEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Planning: View Compliance Level"
                })
                .RequireAuthorization("ComplianceOfficerOnly")
                .WithName("ViewComplianceLevelEndpoint")
                .Produces<List<GetComplianceLevelList>>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /unit-view-reports
            routeGroup.MapGet("/unit-view-reports", ViewReportsForUnitEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Planning: Complaince report view for business unit"
                })
                .RequireAuthorization("OtherComplianceUserOnly")
                .WithName("ViewReportsForUnitEndpoint")
                .Produces<List<GetCompliancePlaningReportDto>>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /compliance-view-reports
            routeGroup.MapGet("/compliance-view-reports", ViewReportsForComplianceEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Planning: Get complaince report for all units"
                })
                .RequireAuthorization("ComplianceOfficerOnly")
                .WithName("ViewReportsForComplianceEndpoint")
                .Produces<List<GetCompliancePlaningReportForComplianceDto>>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /unit-view-reports/00000000-0000-0000-0000-000000000000
            routeGroup.MapGet("/get-report/{ComplianceReportId:guid}", GetReportById.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Planning: Get compliance report by id"
                })
                .RequireAuthorization()
                .WithName("GetReportById")
                .Produces<GetCompliancePlaningReportByIdResponse>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /attach-report
            routeGroup.MapPost("/attach-report", AttachReportsEndpoint.HandleAsync)
                 .AddEndpointFilter<ValidationFilter<AttachReportDto>>()
                .Accepts<AttachReportDto>("multipart/form-data")
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Planning: Upload report"
                })
                .RequireAuthorization("OtherComplianceUserOnly")
                .WithName("AttachReportsEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /approve-compliancereport 
            routeGroup.MapPost("/approve-compliancereport", ApproveComplianceReportEndpoint.HandleAsync)
                .Accepts<ApproveComplianceReportRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Report: Approve Compliance Attached Report"
                })
                .RequireAuthorization("ComplianceOfficerOnly")
                .AddEndpointFilter<ValidationFilter<ApproveComplianceReportRequest>>()
                .WithName("ApproveComplianceReportEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /reject-compliancereport
            routeGroup.MapPost("/reject-compliancereport", RejectComplianceReportEndpoint.HandleAsync)
                .Accepts<RejectComplianceReportRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Report: Reject Compliance Attached Report"
                })
                .RequireAuthorization("ComplianceOfficerOnly")
                .AddEndpointFilter<ValidationFilter<RejectComplianceReportRequest>>()
                .WithName("RejectComplianceReportEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /initiate-regulator-payment
            routeGroup2.MapPost("/initiate-regulator-payment", InitiateRegulatorPaymentEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<InitiateRegulatorPaymentDto>>()
                .Accepts<InitiateRegulatorPaymentDto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Payment: Initiate New Regulator Payment"
                })
                .RequireAuthorization("ComplianceOfficerOnly")
                .WithName("InitiateRegulatorPaymentEndpoint")
                .Produces<InitiateRegulatorPaymentResp>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /edit-regulator-payment
            routeGroup2.MapPost("/edit-regulator-payment", UpdateInitiatedRegulatorPaymentEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<UpdateComplianceRegulatorPaymentReq>>()
                .Accepts<UpdateComplianceRegulatorPaymentReq>(GRCConstants.applicationOrJson)
                //.Accepts<UpdateComplianceRegulatorPaymentReq>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Payment: Update Initiated Compliance Regulator Payment"
                })
                .RequireAuthorization("ComplianceOfficerOnly")
                .WithName("UpdateInitiatedRegulatorPaymentEndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /initiated-payment-view-for-compliance
            routeGroup2.MapGet("/initiated-payment-view-for-compliance", ViewInitiatedRegulatorPaymentAsComplianceEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Payment: Get Regulator Payment for compliance officer view"
                })
                .RequireAuthorization("ComplianceOfficerOnly")
                .WithName("ViewInitiatedRegulatorPaymentAsComplianceEndpoint")
                .Produces<List<GetComplianceRegulatorPayment>>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /initiated-payment-view-for-business-unit
            routeGroup2.MapGet("/initiated-payment-view-for-business-unit", ViewInitiatedRegulatorPaymentAsBusinessUnitEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Payment: Get Regulator Payment for business unit view"
                })
                .RequireAuthorization("OtherComplianceUserOnly")
                .WithName("ViewInitiatedRegulatorPaymentAsBusinessUnitEndpoint")
                .Produces<List<GetComplianceRegulatorPayment>>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /view-compliance-level
            routeGroup2.MapGet("/view-compliance-level", ViewRegulatorPaymentComplianceLevelEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Payment: View compliance level"
                })
                .RequireAuthorization("ComplianceOfficerOnly")
                .WithName("ViewRegulatorPaymentComplianceLevelEndpoint")
                .Produces<List<GetComplianceRegulatorPayment>>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /view-initiated-payment/00000000-0000-0000-0000-000000000000
            routeGroup2.MapGet("/view-initiated-payment/{regulatorPaymentId:guid}", GetRegulatorPaymentByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Payment: Get Regulator Payment by id"
                })
                 .RequireAuthorization()
                .WithName("GetRegulatorPaymentByIdEndpoint")
                .Produces<GetComplianceRegulatorPaymentById>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /make-regulator-payment
            routeGroup2.MapPost("/make-regulator-payment", MakeRegulatorPaymentEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<MakePaymentDto>>()
                .Accepts<MakePaymentDto>("multipart/form-data")
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Payment: Make Regulator Payment"
                })
                .RequireAuthorization("OtherComplianceUserOnly")
                .WithName("MakeRegulatorPaymentEndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /approve-compliance-regulatory-payment 
            routeGroup2.MapPost("/approve-compliance-regulatory-payment", ApproveComplianceRegulatorPaymentEndpoint.HandleAsync)
                .Accepts<ApproveCompliancePaymentRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Payment: Approve Compliance Regulatory Payment"
                })
                .RequireAuthorization("ComplianceOfficerOnly")
                .AddEndpointFilter<ValidationFilter<ApproveCompliancePaymentRequest>>()
                .WithName("ApproveComplianceRegulatorPaymentEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /reject-compliance-regulatory-payment"
            routeGroup2.MapPost("/reject-compliance-regulatory-payment", RejectComplianceRegulatorPaymentEndpoint.HandleAsync)
                .Accepts<RejectComplianceRegulatoryPaymentRequest>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Payment: Reject Compliance Regulatory Payment"
                })
                .RequireAuthorization("ComplianceOfficerOnly")
                .AddEndpointFilter<ValidationFilter<RejectComplianceRegulatoryPaymentRequest>>()
                .WithName("RejectComplianceRegulatorPaymentEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //GET /view-overdue-compliance-regulatory-payment
            routeGroup2.MapGet("/view-overdue-compliance-regulatory-payment", ViewOverdueComplianceRegulatoryPaymentEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Compliance Payment: View over due complaince regulatory payment for all business entities"
                })
                .RequireAuthorization()
                .WithName("ViewOverdueComplianceRegulatoryPaymentEndpoint")
                .Produces<List<OverdueComplianceRegulatoryPaymentRes>>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
            

            routeGroup2.MapGet("/options", RegulatoryOptionsEndpoint.HandleAsync)
               .WithOpenApi(operation => new(operation)
               {
                   Summary = "Compliance Payment: Provides Regulators and Business entities options"
               })
               .WithName("RegulatoryOptionsEndpoint")
               .Produces<string>(StatusCodes.Status200OK)
               .Produces<List<string>>(StatusCodes.Status400BadRequest)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);           

            return app;
        }
        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {

            builder.AddScoped<IRepository<ComplianceRegulatoryPayment>, Repository<ComplianceRegulatoryPayment>>();
            builder.AddScoped<IRepository<ComplianceCalendar>, Repository<ComplianceCalendar>>();
            builder.AddScoped<IRepository<ComplianceBusines>, Repository<ComplianceBusines>>();
            builder.AddScoped<IRepository<ComplianceRegulator>, Repository<ComplianceRegulator>>();
            builder.AddScoped<IRepository<ComplianceRules>, Repository<ComplianceRules>>();
            builder.AddScoped<IRepository<ComplianceDepartment>, Repository<ComplianceDepartment>>();
            builder.AddScoped<IRepository<ComplianceBusinessDepartment>, Repository<ComplianceBusinessDepartment>>();
            builder.AddScoped<IRepository<ComplianceRulesBusiness>,  Repository<ComplianceRulesBusiness>>();
            builder.AddTransient<IRepository<ComplianceCalendar>, Repository<ComplianceCalendar>>();
            builder.AddScoped<ICurrentUserService, CurrentUserService>();
            builder.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            builder.AddScoped<IValidator<RuleExcelUpload>, RuleExcelUploadValidator>();
            builder.AddScoped<IValidator<ComplianceBusinesDto>, ComplianceBusinesDtoValidator>();
            builder.AddScoped<IValidator<ComplianceRegulatorDto>, ComplianceRegulatorDtoValidator>();
            builder.AddScoped<IValidator<ComplianceRulesAndRegulatorDto>, ComplianceRulesAndRegulatorDtoValidator>();
            builder.AddScoped<IValidator<AttachReportDto>, AttachReportValidator>();
            builder.AddScoped<IValidator<ApproveComplianceReportRequest>, ApproveComplianceReportRequestValidation>();
            builder.AddScoped<IValidator<RejectComplianceReportRequest>, RejectComplianceReportRequestValidation>();
            builder.AddScoped<IValidator<InitiateRegulatorPaymentDto>, InitiateRegulatorPaymentDtoValidator>();
            builder.AddScoped<IValidator<MakePaymentDto>, MakePaymentDtoValidator>();
            builder.AddScoped<IValidator<UpdateComplianceRegulatorPaymentReq>, UpdateComplianceRegulatorPaymentReqValidator>();
            builder.AddScoped<IValidator<ApproveCompliancePaymentRequest>, ApproveCompliancePaymentRequestValidation>();
            builder.AddScoped<IValidator<RejectComplianceRegulatoryPaymentRequest>, RejectComplianceRegulatoryPaymentRequestValidation>();

            return builder;
        }
    }
}
