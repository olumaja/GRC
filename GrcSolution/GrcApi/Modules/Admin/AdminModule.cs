using Arm.GrcApi.Modules;
using Arm.GrcApi.Modules.Admin;
using Arm.GrcApi.Modules.OperationControl;
using Arm.GrcApi.Modules.Shared;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace GrcApi.Modules.Admin
{
    public class AdminModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {
            var routeGroup = app.MapGroup("admin-dashboard").WithTags(new string[] { "Admin Dashboard" });

            //POST /create-admin
            routeGroup.MapPost("/create-admin", CreateAdminEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<AdminDto>>()
                .Accepts<AdminDto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Admin Dashboard: Create Admin user"
                })
                .RequireAuthorization("SuperAdminOnly")
                .WithName("CreateAdminEndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /create-user
            routeGroup.MapPost("/create-user", CreateUserEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<CreateUserDto>>()
                .Accepts<CreateUserDto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Admin Dashboard: Create user"
                })
                .RequireAuthorization()
                .WithName("CreateUserEndpoint")
                .Produces<string>(StatusCodes.Status201Created)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //POST /update-user
            routeGroup.MapPatch("/update-user", UpdateUserEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<UpdateUserDto>>()
                .Accepts<UpdateUserDto>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Admin Dashboard: Update user"
                })
                .RequireAuthorization()
                .WithName("UpdateUserEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /fetch-all-admins
            routeGroup.MapGet("/get-all-admin", AdminEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Admin Dashboard: Get all admins and users"
                })
               .RequireAuthorization("SuperAdminOnly")
               .WithName("AdminEndpoint")
               .Produces<AdminResponse>(StatusCodes.Status200OK)
               .Produces<List<string>>(StatusCodes.Status400BadRequest)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /fetch-users
            routeGroup.MapGet("/get-users", GetUsersForAdminEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Admin Dashboard: Get all users"
                })
               .RequireAuthorization("AdminOnly")
               .WithName("GetUsersForAdminEndpoint")
               .Produces<UserResponse>(StatusCodes.Status200OK)
               .Produces<List<string>>(StatusCodes.Status400BadRequest)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /view-user/{id:guid}
            routeGroup.MapGet("/view-user/{id:guid}", ViewUserByIdEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Admin Dashboard: View user by Id"
                })
               .RequireAuthorization()
               .WithName("ViewUserByIdEndpoint")
               .Produces<ViewUserResp>(StatusCodes.Status200OK)
               .Produces<List<string>>(StatusCodes.Status400BadRequest)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /roles
            routeGroup.MapGet("/roles", RoleEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Admin Dashboard: Roles"
                })
               .RequireAuthorization()
               .WithName("RoleEndpoint")
               .Produces<RoleResponse>(StatusCodes.Status200OK)
               .Produces<List<string>>(StatusCodes.Status400BadRequest)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // GET /module-types
            routeGroup.MapGet("/module-types", ModuleTypeEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Admin Dashboard: Module Types"
                })
               .RequireAuthorization()
               .WithName("ModuleTypeEndpoint")
               .Produces<List<ModuleTypeResponse>>(StatusCodes.Status200OK)
               .Produces<List<string>>(StatusCodes.Status400BadRequest)
               .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //PATCH /update-user-status
            routeGroup.MapPatch("/update-user-status", UpdateUserStatusEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<UpdateUserStatus>>()
                .Accepts<UpdateUserStatus>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Admin Dashboard: Update user status"
                })
                .RequireAuthorization("SuperAdminOnly")
                .WithName("UpdateUserStatusEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //PATCH /add-user-role
            routeGroup.MapPatch("/add-user-role", AddRoleEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ChangeUserRole>>()
                .Accepts<ChangeUserRole>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Admin Dashboard: Add new role to user"
                })
                .RequireAuthorization()
                .WithName("AddRoleEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            //PATCH /revoke-user-role
            routeGroup.MapPatch("/revoke-user-role", RemoveRoleEndpoint.HandleAsync)
                .AddEndpointFilter<ValidationFilter<ChangeUserRole>>()
                .Accepts<ChangeUserRole>(GRCConstants.applicationOrJson)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Admin Dashboard: Revoke role from user"
                })
                .RequireAuthorization()
                .WithName("RemoveRoleEndpoint")
                .Produces<string>(StatusCodes.Status200OK)
                .Produces<List<string>>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            return app;
        }

        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {
            builder.AddScoped<IValidator<AdminDto>, AdminDtoValidator>();
            builder.AddScoped<IValidator<CreateUserDto>, CreateUserDtoValidator>();
            builder.AddScoped<IValidator<UpdateUserDto>, UpdateUserDtoValidator>();
            builder.AddScoped<IValidator<UpdateUserStatus>, UpdateUserStatusValidator>();
            builder.AddScoped<IValidator<ChangeUserRole>, ChangeUserRoleValidator>();

            return builder;
        }
    }
}
