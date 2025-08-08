using Arm.GrcApi.Modules.AntivirusAssessment;
using Arm.GrcApi.Modules.IncidentManagement;
using Arm.GrcApi.Modules.InfosecRiskAssessment;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Infrastructure;
using FluentValidation;
using GrcApi.Modules.InfosecRiskAssessment;
using GrcApi.Modules.VulnerabilityManagement;
using Microsoft.AspNetCore.Mvc;

namespace Arm.GrcApi.Modules.ISMSReporting
{    
    public class ISMSReportingModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {
            var routeGroup = app.MapGroup("isms-reporting").WithTags(new string[] { "ISMS Reporting" });

            // GET /incidence-report
            routeGroup.MapGet("/incidence-reports", GetIncidencencMgtReportEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ISMS Reporting: Get Incidencenc management reports"
                })
               .RequireAuthorization("InfoSecOfficerOnly")
               .WithName("GetIncidencencMgtReportEndpoint")
               .Produces<PaginatedGetLogIncidenceResp>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /vulnerability-report
            routeGroup.MapGet("/vulnerability-reports", GetInternalVulnerabilityReportsEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ISMS Reporting: Get Vulnerability management reports"
                })
               .RequireAuthorization("InfoSecOfficerOnly")
               .WithName("GetInternalVulnerabilityReportsEndpoint")
               .Produces<PaginatedGetInternalVulnerabilityResp>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /antivirus-report
            routeGroup.MapGet("/antivirus-reports", GetAntivirusReportsEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ISMS Reporting: Get antivirus management reports"
                })
               .RequireAuthorization("InfoSecOfficerOnly")
               .WithName("GetAntivirusReportsEndpoint")
               .Produces<PaginatedGetAntivirusAssessmentResp>(StatusCodes.Status200OK)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /log-management-report
            routeGroup.MapGet("/log-management-reports", ISMSLogReportingEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ISMS Reporting: Get log management reports"
                })
               .RequireAuthorization("InfoSecOfficerOnly")
               .WithName("ISMSLogReportingEndpoint")
               .Produces<LogReportResponse>(StatusCodes.Status200OK)
               .Produces<string>(StatusCodes.Status400BadRequest)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /risk-assessment-report
            routeGroup.MapGet("/risk-assessment-reports", GetRiskAssessmentReportingEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ISMS Reporting: Get risk assessment reports"
                })
               .RequireAuthorization("InfoSecOfficerOnly")
               .WithName("GetRiskAssessmentReportingEndpoint")
               .Produces<List<RiskAssessmentReportResponse>>(StatusCodes.Status200OK)
               .Produces<string>(StatusCodes.Status400BadRequest)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /unit-risk-assessment-report
            routeGroup.MapGet("/unit-risk-assessment-reports", GetRiskAssessmentReportByUnitEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "ISMS Reporting: Get unit risk assessment reports"
                })
               .RequireAuthorization("InfoSecOfficerOnly")
               .WithName("GetRiskAssessmentReportByUnitEndpoint")
               .Produces<List<UnitRiskAssessment>>(StatusCodes.Status200OK)
               .Produces<string>(StatusCodes.Status400BadRequest)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            return app;
        }

        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {            

            return builder;
        }


    }
}
