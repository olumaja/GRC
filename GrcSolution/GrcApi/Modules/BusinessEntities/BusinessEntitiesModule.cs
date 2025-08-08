using Arm.GrcApi.Modules;
using Arm.GrcApi.Modules.BusinessEntities;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.Infrastructure;
using Microsoft.AspNetCore.Mvc;


namespace GrcApi.Modules.BusinessEntities
{
    public class BusinessEntitiesModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {
            // this line creates the endpoint header on swagger
            var routeGroup = app.MapGroup("/business-entities").WithTags(new string[] { "Business Entities" });
            routeGroup.MapGet("/", BusinessEntitiesEndpoint.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Gets all Arm business entities"
                })
                 //.RequireAuthorization("RiskManagmentEmployeeOnly")
                .WithName("GetBusinessEntities")
                .Produces<IList<BusinessEntityDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            routeGroup.MapGet("/{businessEntityId:guid}/departments", BusinessEntitiesEndpointGetDepartments.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Gets all Business entities departments for the specified businessEntityId"
                })
                .WithName("GetDepartments")
                .Produces<IList<DepartmentDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);


            routeGroup.MapGet("/departments/{departmentId:guid}/units", BusinessEntitiesEndpointGetUnits.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Gets all Department units for the specified departmentId"
                })
                .WithName("GetUnits")
                .Produces<IList<UnitDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            routeGroup.MapGet("/units", BusinessEntitiesEndpointGetAllUnits.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Gets all the units for the specified businessEntityId or gets all units if the businessEntityId is unspecified"
                })
                .WithName("GetAllUnits")
                .Produces<IList<UnitDto>>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            // /business-entities/00000000-0000-0000-0000-000000000000/process
            routeGroup.MapGet("/{unitId:guid}/process", BusinessEntitiesEndpointGetProcessByUnitId.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Get process by unit Id"
                })
                .WithName("GetProcessByUnitId")
                .Produces<IList<ProcessDto>>(StatusCodes.Status200OK)
                .Produces<string>(StatusCodes.Status400BadRequest)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            return app;
        }

        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {
            builder.AddScoped<IRepository<BusinessEntity>, Repository<BusinessEntity>>();
            builder.AddScoped<IRepository<Department>, Repository<Department>>();
            builder.AddScoped<IRepository<Unit>, Repository<Unit>>();           
            return builder;
        }
    }
}
