using Microsoft.EntityFrameworkCore;

namespace Arm.GrcApi.Models
{
    public static class MigrationManager
    {
        /// <summary>
        /// Executes the migrations
        /// </summary>
        /// <param name="webApp"></param>
        /// <returns></returns>
        public static WebApplication MigrateDatabase(this WebApplication webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<GrcToolDbContext>())
                {
                    var logger = scope.ServiceProvider.GetRequiredService<Serilog.ILogger>();

                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex, ex.Message);
                        throw;
                    }
                }
            }
            return webApp;
        }
    }
}
