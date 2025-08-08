using Arm.Ad.Users;
using Arm.GrcApi.Modules;
using Arm.GrcApi.Modules.RiskManagement;
using Arm.GrcApi.Modules.RiskManagement.BIA;
using Arm.GrcApi.Modules.Shared;
using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.Domain.Employee;
using Arm.GrcTool.Infrastructure;
using Arm.GrcTool.Infrastructure.Services;
using FluentValidation;
using GrcApi.Modules.Employees;
using GrcApi.Modules.Shared;
using GrcApi.Modules.Shared.Helpers;
using GrcApi.Modules.Shared.SessionManagement;
using Microsoft.AspNetCore.Mvc;
using System.ServiceModel;

namespace Arm.GrcTool.Modules.Employees
{
    public class EmployeeModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {
            // this line creates the endpoint header on swagger
            var routeGroup = app.MapGroup("/employee").WithTags(new string[] { "Employee" });

            // POST /employee/authenticate
            routeGroup.MapPost("/authenticate", EmployeeEndpointAuthenticate.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Authenticate ARM employee against active directory"
                })
                .RequireRateLimiting("fixed")
                .AddEndpointFilter<ValidationFilter<AuthenticateDto>>()
                .WithName("AuthenticateEmployee")
                .Produces<AuthenticateResponseDto>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // POST /employee/logout
            routeGroup.MapPost("/Logout", LogoutEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Logout endpoint"
                })
                .WithName("LogoutEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // POST /employee/refresh-token
            routeGroup.MapPost("/refresh-token", RefreshTokenEndpoint.HandleAsync)
                .Accepts<RefreshTokenDto>(GRCConstants.applicationOrJson)
                .AddEndpointFilter<ValidationFilter<RefreshTokenDto>>()
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Refresh token endpoint"
                })
                .WithName("RefreshTokenEndpoint")
                .Produces<AuthenticateResponseDto>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // POST /employee/validate-token
            routeGroup.MapPost("/validate-token", ValidateTokenEndpoint.HandleAsync)
                .Accepts<ValidateTokenDto>(GRCConstants.applicationOrJson)
                .AddEndpointFilter<ValidationFilter<ValidateTokenDto>>()
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Validate token endpoint"
                })
                .WithName("ValidateTokenEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status404NotFound)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            return app;
        }

        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {
            builder.AddScoped<IRepository<User>, Repository<User>>();
            builder.AddScoped<IRepository<SessionTracker>, Repository<SessionTracker>>();
            builder.AddScoped<IRepository<UserRole>, Repository<UserRole>>();           
            builder.AddSingleton<IEmployeeService, EmployeeServiceActiveDirectory>();
            builder.AddScoped<ICurrentUserService, CurrentUserService>();
            builder.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            builder.AddScoped<IRepository<UserRoleMap>, Repository<UserRoleMap>>();

            builder.AddTransient<ISOAPADHelperService, SOAPADHelperServiceClient>((ctx) => new SOAPADHelperServiceClient()
            {
                Endpoint =
                {
                    Address = new EndpointAddress($"{configuration["ArmActiveDirectoryService"]}")
                }
            });

            builder.AddScoped<IValidator<AuthenticateDto>, AuthenticateDtoValidation>();
            builder.AddScoped<IValidator<RefreshTokenDto>, RefreshTokenDtoValidator>();
            builder.AddScoped<IValidator<ValidateTokenDto>, ValidateTokenDtoValidator>();

            return builder;
        }
    }
}
