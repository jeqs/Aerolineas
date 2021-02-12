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
    public static class AvionServices
    {
        static readonly ILog log = AerolineasExcepcion.GetLogger(typeof(AvionServices));

        public static AvionesResponse Obtener()
        {
            var mensajes = new List<Message>();

            try
            {
                var listaTransacciones = AvionAccess.Obtener();
                var transacciones = ConfigAutomapper.mapper.Map<List<AvionModel>>(listaTransacciones);

                return new AvionesResponse(transacciones, true, mensajes);
            }
            catch (Exception ex)
            {
                new AerolineasExcepcion(ex.Message, ex, log);

                //Captura de errores
                mensajes.Add(new Message(Codes.Exception, ex.Message));
                return new AvionesResponse(null, false, mensajes);
            }
        }

        public static AvionResponse Agregar(AvionModel request)
        {
            var mensajes = new List<Message>();

            try
            {
                if (request.Nomre == null)
                {
                    mensajes.Add(new Message(Codes.Mandatory, "El Nombre del Avión es obligatorio"));
                }

                // No tiene errores
                if (mensajes.Count == 0)
                {
                    // Agregar
                    var itinearioEntity = ConfigAutomapper.mapper.Map<Avion>(request);
                    AvionAccess.Agregar(itinearioEntity);

                    return new AvionResponse(request, true, mensajes);
                }
                else
                {
                    return new AvionResponse(null, false, mensajes);
                }
            }
            catch (Exception ex)
            {
                new AerolineasExcepcion(ex.Message, ex, log);

                //Captura de errores
                mensajes.Add(new Message(Codes.Exception, ex.Message));
                return new AvionResponse(null, false, mensajes);
            }
        }

        public static AvionResponse Actualizar(AvionModel request)
        {
            var mensajes = new List<Message>();

            try
            {
                if (request.Id == 0)
                {
                    mensajes.Add(new Message(Codes.Mandatory, "El Id del Avión es obligatorio"));
                }

                if (request.Nomre == null)
                {
                    mensajes.Add(new Message(Codes.Mandatory, "El Nombre del Avión es obligatorio"));
                }

                // No tiene errores
                if (mensajes.Count == 0)
                {
                    // Actualizar
                    var itinearioEntity = ConfigAutomapper.mapper.Map<Avion>(request);
                    AvionAccess.Actualizar(itinearioEntity);

                    return new AvionResponse(request, true, mensajes);
                }
                else
                {
                    return new AvionResponse(null, false, mensajes);
                }
            }
            catch (Exception ex)
            {
                new AerolineasExcepcion(ex.Message, ex, log);

                //Captura de errores
                mensajes.Add(new Message(Codes.Exception, ex.Message));
                return new AvionResponse(null, false, mensajes);
            }
        }

        public static AvionResponse Eliminar(AvionModel request)
        {
            var mensajes = new List<Message>();

            try
            {
                if (request.Id == 0)
                {
                    mensajes.Add(new Message(Codes.Mandatory, "El Id del Avion es obligatorio"));
                }

                // No tiene errores
                if (mensajes.Count == 0)
                {
                    // Eliminar
                    AvionAccess.Eliminar(request.Id);

                    return new AvionResponse(request, true, mensajes);
                }
                else
                {
                    return new AvionResponse(null, false, mensajes);
                }
            }
            catch (Exception ex)
            {
                new AerolineasExcepcion(ex.Message, ex, log);

                //Captura de errores
                mensajes.Add(new Message(Codes.Exception, ex.Message));
                return new AvionResponse(null, false, mensajes);
            }
        }

    }
}