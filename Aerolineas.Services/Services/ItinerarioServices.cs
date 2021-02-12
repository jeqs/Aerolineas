using log4net;
using Aerolineas.DataStorage.DataAccess;
using Aerolineas.Services.Code;
using Aerolineas.Services.Dto;
using Aerolineas.Services.Dto.GatewayResponses;
using Aerolineas.Services.Dto.Model;
using Aerolineas.Transverse;
using Aerolineas.DataStorage.BD;
using System;
using System.Collections.Generic;

namespace Aerolineas.Services
{
    public static class ItinerarioServices
    {
        static readonly ILog log = AerolineasExcepcion.GetLogger(typeof(ItinerarioServices));

        public static ItinerariosResponse Obtener()
        {
            var mensajes = new List<Message>();

            try
            {
                var listaTransacciones = ItinerarioAccess.Obtener();
                var transacciones = ConfigAutomapper.mapper.Map<List<ItinerarioModel>>(listaTransacciones);

                return new ItinerariosResponse(transacciones, true, mensajes);
            }
            catch (Exception ex)
            {
                new AerolineasExcepcion(ex.Message, ex, log);

                //Captura de errores
                mensajes.Add(new Message(Codes.Exception, ex.Message));
                return new ItinerariosResponse(null, false, mensajes);
            }
        }

        public static ItinerarioResponse Agregar(ItinerarioModel request)
        {
            var mensajes = new List<Message>();

            try
            {
                if (request.IdAvion == null)
                {
                    mensajes.Add(new Message(Codes.Mandatory, "El Id del Avión es obligatorio"));
                }

                if (request.IdCiudad == null)
                {
                    mensajes.Add(new Message(Codes.Mandatory, "El Id del Ciudad es obligatorio"));
                }

                if (request.HorasVuelo == null)
                {
                    mensajes.Add(new Message(Codes.Mandatory, "Las Horas de Vuelo es obligatoria"));
                }

                // No tiene errores
                if (mensajes.Count == 0)
                {
                    // Agregar
                    var itinearioEntity = ConfigAutomapper.mapper.Map<Itinerario>(request);
                    ItinerarioAccess.Agregar(itinearioEntity);

                    return new ItinerarioResponse(request, true, mensajes);
                }
                else
                {
                    return new ItinerarioResponse(null, false, mensajes);
                }
            }
            catch (Exception ex)
            {
                new AerolineasExcepcion(ex.Message, ex, log);

                //Captura de errores
                mensajes.Add(new Message(Codes.Exception, ex.Message));
                return new ItinerarioResponse(null, false, mensajes);
            }
        }

        public static ItinerarioResponse Actualizar(ItinerarioModel request)
        {
            var mensajes = new List<Message>();

            try
            {
                if (request.Id == 0)
                {
                    mensajes.Add(new Message(Codes.Mandatory, "El Id del Itinerario es obligatorio"));
                }

                if (request.IdAvion == null)
                {
                    mensajes.Add(new Message(Codes.Mandatory, "El Id del Avión es obligatorio"));
                }

                if (request.IdCiudad == null)
                {
                    mensajes.Add(new Message(Codes.Mandatory, "El Id del Ciudad es obligatorio"));
                }

                if (request.HorasVuelo == null)
                {
                    mensajes.Add(new Message(Codes.Mandatory, "Las Horas de Vuelo es obligatoria"));
                }

                // No tiene errores
                if (mensajes.Count == 0)
                {
                    // Actualizar
                    var itinearioEntity = ConfigAutomapper.mapper.Map<Itinerario>(request);
                    ItinerarioAccess.Actualizar(itinearioEntity);

                    return new ItinerarioResponse(request, true, mensajes);
                }
                else
                {
                    return new ItinerarioResponse(null, false, mensajes);
                }
            }
            catch (Exception ex)
            {
                new AerolineasExcepcion(ex.Message, ex, log);

                //Captura de errores
                mensajes.Add(new Message(Codes.Exception, ex.Message));
                return new ItinerarioResponse(null, false, mensajes);
            }
        }

        public static ItinerarioResponse Eliminar(ItinerarioModel request)
        {
            var mensajes = new List<Message>();

            try
            {
                if (request.Id == 0)
                {
                    mensajes.Add(new Message(Codes.Mandatory, "El Id del Itinerario es obligatorio"));
                }

                // No tiene errores
                if (mensajes.Count == 0)
                {
                    // Eliminar
                    ItinerarioAccess.Eliminar(request.Id);

                    return new ItinerarioResponse(request, true, mensajes);
                }
                else
                {
                    return new ItinerarioResponse(null, false, mensajes);
                }
            }
            catch (Exception ex)
            {
                new AerolineasExcepcion(ex.Message, ex, log);

                //Captura de errores
                mensajes.Add(new Message(Codes.Exception, ex.Message));
                return new ItinerarioResponse(null, false, mensajes);
            }
        }

    }
}