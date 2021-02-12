using System;

namespace Aerolineas.Infrastructure.Interfaces
{
    public interface IDbContextReadOnlyScope : IDisposable
    {
        IDbContextCollection DbContexts { get; }
    }
}