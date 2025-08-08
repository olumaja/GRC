using Arm.GrcApi.Modules;
using Arm.GrcTool.Domain.BusinessImpactAnalysis;
using Arm.GrcTool.Infrastructure.Data;
using Arm.GrcTool.Infrastructure;

namespace Arm.GrcTool.InfrastruCTOre
{
    public class EmailNotificationModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {
            return app;
        }

        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {
            builder.AddHostedService<NotificationWorker>();
            builder.AddTransient<IEmailService, EmailService>();
            builder.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.AddScoped<IRepository<Email>, Repository<Email>>();
            builder.AddScoped<IEmailService, EmailService>();

            return builder;
        }
    }
}
