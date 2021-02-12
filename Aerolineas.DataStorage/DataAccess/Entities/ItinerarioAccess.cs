using Aerolineas.Transverse;
using Aerolineas.DataStorage.BD;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aerolineas.DataStorage.DataAccess
{
    public class ItinerarioAccess : BaseAccess<ItinerarioAccess>
    {
        public static List<Itinerarios> Obtener()
        {
            try
            {
                using (var dbContextScope = new AerolineasEntities(false))
                {
                    return dbContextScope.ObtenerItinerario().ToList();
                }
            }
            catch (Exception ex)
            {
                new AerolineasExcepcion(ex.Message, ex, log);
                throw ex;
            }
        }

        public static Itinerario ObtenerItinerario(int idAvion)
        {
            try
            {
                using (var dbContextScope = new AerolineasEntities(false))
                {
                    return dbContextScope.Itinerario.Where(x => x.IdAvion == idAvion).OrderByDescending(x => x.Id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                new AerolineasExcepcion(ex.Message, ex, log);
                throw ex;
            }
        }

        public static bool Agregar(Itinerario itinerario)
        {
            try
            {
                using (var dbContextScope = new AerolineasEntities(false))
                {
                    dbContextScope.Itinerario.Add(itinerario);
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

        public static bool Actualizar(Itinerario itinerario)
        {
            try
            {
                using (var dbContextScope = new AerolineasEntities(false))
                {
                    var actual = dbContextScope.Itinerario.Where(x => x.Id == itinerario.Id).FirstOrDefault();
                    actual.IdAvion = itinerario.IdAvion;
                    actual.IdCiudad = itinerario.IdCiudad;
                    actual.HorasVuelo = itinerario.HorasVuelo;

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

        public static bool Eliminar(int idItinerario)
        {
            try
            {
                using (var dbContextScope = new AerolineasEntities(false))
                {
                    var actual = dbContextScope.Itinerario.Where(x => x.Id == idItinerario).FirstOrDefault();
                    dbContextScope.Itinerario.Remove(actual);

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
