using Arm.GrcApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Arm.GrcTool.Infrastructure
{
    public class SessionService : ISessionService
    {
        private readonly Serilog.ILogger _logger;
        private readonly GrcToolDbContext _context;

        public SessionService(Serilog.ILogger logger, GrcToolDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task UnlockUser()
        {
            try
            {
                await _context.SessionTracker.Where(s => s.IsLock && s.LockDuration < DateTime.Now)
                                        .ExecuteUpdateAsync(l => l.SetProperty(u => u.IsLock, u => false)
                                        .SetProperty(u => u.LockDuration, u => null));
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error occur inside {nameof(SessionService)}.{nameof(UnlockUser)} ===> {ex.Message}");
            }
        }
    }
}
