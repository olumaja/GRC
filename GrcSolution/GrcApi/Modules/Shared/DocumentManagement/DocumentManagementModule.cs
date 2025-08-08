using Arm.GrcApi.Modules;
using Arm.GrcApi.Modules.RiskManagement;
using Arm.GrcTool.Domain;
using Arm.GrcTool.Domain.DocumentManagement;
using GrcApi.Modules.DocumentManagement;
using Microsoft.AspNetCore.Mvc;

namespace Arm.GrcTool.Infrastructure
{
    public class DocumentManagementModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {
            // this line creates the endpoint header on swagger
            var routeGroup = app.MapGroup("/documents").WithTags(new string[] { "Documents" });

            // GET /documents/00000000-0000-0000-0000-000000000000
            routeGroup.MapGet("/", DocumentEndpointDownloadDocument.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Download document"
                })
                .WithName("DownloadDocument")
                .Produces<Stream>(StatusCodes.Status200OK, "application/octet-stream")
                .Produces(StatusCodes.Status404NotFound)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);

            #region Testing Document Upload
            routeGroup.MapPost("/upload", DocumentEndpointUploadDocument.HandleAsync)
                .WithOpenApi(operation => new(operation)
                {
                    Summary = "Upload document"
                })
                .WithName("UploadDocument")
                .Produces<Guid>(StatusCodes.Status200OK)
                .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
            #endregion

            return app;
        }

        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {
             builder.AddScoped<IRepository<Document>, Repository<Document>>();
            return builder;
        }
    }
}
