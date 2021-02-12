using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;

namespace Aerolineas.DataStorage.BD
{
    public partial class AerolineasEntities : DbContext
    {
        public AerolineasEntities(bool lazyLoadingEnabled)
        {
            this.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
        }

        public ObjectContext ObjectContext()
        {
            return (this as IObjectContextAdapter).ObjectContext;
        }
    }
}
