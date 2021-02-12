using log4net;
using Aerolineas.DataStorage.Repositories;
using Aerolineas.Infrastructure.Implementations;
using Aerolineas.Infrastructure.Interfaces;
using Aerolineas.Transverse;
using System;

namespace Aerolineas.DataStorage.DataAccess
{
    public class BaseAccess<T> where T : class
    {
        internal static readonly ILog log = AerolineasExcepcion.GetLogger(typeof(T));
        internal readonly IDbContextScopeFactory dbContextScopeFactory;
        internal readonly IRepository<T> repository;

        public BaseAccess()
        {
            var _dbContextScopeFactory = new DbContextScopeFactory();
            var ambientDbContextLocator = new AmbientDbContextLocator();
            var _repository = new Repository<T>(ambientDbContextLocator);

            if (_dbContextScopeFactory == null) throw new ArgumentNullException("dbContextScopeFactory");
            if (_repository == null) throw new ArgumentNullException("repository");

            dbContextScopeFactory = _dbContextScopeFactory;
            repository = _repository;
        }
    }
}
