namespace Arm.GrcApi.Modules;

public interface IModule
{
    public IServiceCollection RegisterModule(IServiceCollection builder, ConfigurationManager configuration);
    public WebApplication MapEndpoints(WebApplication app);
}
