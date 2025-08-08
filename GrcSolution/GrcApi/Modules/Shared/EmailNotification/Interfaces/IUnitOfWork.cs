namespace Arm.GrcTool.Infrastructure
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
