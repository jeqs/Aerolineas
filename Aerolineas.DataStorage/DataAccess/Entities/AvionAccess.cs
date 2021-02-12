using Aerolineas.Transverse;
using Aerolineas.DataStorage.BD;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aerolineas.DataStorage.DataAccess
{
    public class AvionAccess : BaseAccess<AvionAccess>
    {
        public static List<Avion> Obtener()
        {
            try
            {
                using (var dbContextScope = new AerolineasEntities(false))
                {
                    return dbContextScope.Avion.ToList();
                }
            }
            catch (Exception ex)
            {
                new AerolineasExcepcion(ex.Message, ex, log);
                throw ex;
            }
        }

        public static Avion ObtenerAvion(int idAvion)
        {
            try
            {
                using (var dbContextScope = new AerolineasEntities(false))
                {
                    return dbContextScope.Avion.Where(x => x.Id == idAvion).OrderByDescending(x => x.Id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                new AerolineasExcepcion(ex.Message, ex, log);
                throw ex;
            }
        }

        public static bool Agregar(Avion avion)
        {
            try
            {
                using (var dbContextScope = new AerolineasEntities(false))
                {
                    dbContextScope.Avion.Add(avion);
                    dbContextScope.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                new AerolineasExcepcion(ex.Message, ex, log);
                throw ex;
            }
        }

        public static bool Actualizar(Avion avion)
        {
            try
            {
                using (var dbContextScope = new AerolineasEntities(false))
                {
                    var actual = dbContextScope.Avion.Where(x => x.Id == avion.Id).FirstOrDefault();
                    actual.Nomre = avion.Nomre;

                    dbContextScope.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                new AerolineasExcepcion(ex.Message, ex, log);
                throw ex;
            }
        }

        public static bool Eliminar(int idAvion)
        {
            try
            {
                using (var dbContextScope = new AerolineasEntities(false))
                {
                    var actual = dbContextScope.Avion.Where(x => x.Id == idAvion).FirstOrDefault();
                    dbContextScope.Avion.Remove(actual);

                    dbContextScope.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                new AerolineasExcepcion(ex.Message, ex, log);
                throw ex;
            }
        }
    }
}
