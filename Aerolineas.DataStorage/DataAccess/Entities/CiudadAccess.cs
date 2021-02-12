using Aerolineas.Transverse;
using Aerolineas.DataStorage.BD;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aerolineas.DataStorage.DataAccess
{
    public class CiudadAccess : BaseAccess<CiudadAccess>
    {
        public static List<Ciudad> ObtenerCiudades()
        {
            try
            {
                using (var dbContextScope = new AerolineasEntities(false))
                {
                    return dbContextScope.Ciudad.ToList();
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
