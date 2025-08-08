using Arm.GrcApi.Models;

namespace Arm.GrcTool.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GrcToolDbContext context;

        public UnitOfWork(GrcToolDbContext context)
        {
            this.context = context;
        }
        public Task<int> SaveChangesAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}
