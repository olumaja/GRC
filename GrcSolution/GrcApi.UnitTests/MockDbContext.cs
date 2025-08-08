using Arm.GrcApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GrcApi.UnitTests
{
    internal class MockDbContext
    {
    }

    public class MockDb : IDbContextFactory<GrcToolDbContext>
    {
        public GrcToolDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<GrcToolDbContext>()
                .UseInMemoryDatabase($"InMemoryTestDb-{DateTime.Now.ToFileTimeUtc()}")
                .Options;

            return new GrcToolDbContext(options);
        }
    }
}
