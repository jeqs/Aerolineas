using System.Data.Entity;
using System.Reflection;

namespace Aerolineas.DataStorage.Contexts
{
    public class AerolineasDbContext<TEntity> : DbContext where TEntity : class
    {
        // Un mapa de modelo de "TEntity"
        public DbSet<TEntity> Model { get; set; }

        public AerolineasDbContext() : base("name=AerolineasEntities")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(AerolineasDbContext<TEntity>)));
        }
    }
}
