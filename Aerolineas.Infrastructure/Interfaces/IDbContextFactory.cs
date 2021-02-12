using System.Data.Entity;

namespace Aerolineas.Infrastructure.Interfaces
{

    public interface IDbContextFactory
    {
        TDbContext CreateDbContext<TDbContext>() where TDbContext : DbContext;
    }
}
