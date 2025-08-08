

namespace Arm.GrcApi.Modules.Security
{
    public class SecurityModule : IModule
    {
        public WebApplication MapEndpoints(WebApplication app)
        {
            return app;
        }

        public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration)
        {
            builder.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            builder.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            return builder;
        }
    }
}
