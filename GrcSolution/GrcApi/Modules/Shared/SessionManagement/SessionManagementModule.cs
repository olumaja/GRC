using Arm.GrcApi.Modules;
using GrcApi.Modules.Compliance.CompliancePlanning;

namespace Arm.GrcTool.Infrastructure
{
    public class SessionManagementModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {
            return app;
        }

        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {
            builder.AddTransient<ISessionService, SessionService>();
            
            return builder;
        }
    }
}
