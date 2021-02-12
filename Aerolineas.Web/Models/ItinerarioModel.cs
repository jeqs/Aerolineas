using System.Collections.Generic;

namespace Aerolineas.Models
{
    public class Itinerario : BaseGatewayResponse
    {
        public int Id { get; set; }
        public int? IdAvion { get; set; }
        public int? IdCiudad { get; set; }
        public decimal? HorasVuelo { get; set; }

        // Propiedades Extendidas
        public string Nomre { get; set; }
        public string Nombre { get; set; }
    }

    public sealed class ItinerariosResponse : BaseGatewayResponse
    {
        public List<Itinerario> Itinerario { get; set; }

        public ItinerariosResponse(List<Itinerario> itinerariosModel, bool success = false, IEnumerable<Message> messages = null) : base(success, messages)
        {
            Itinerario = itinerariosModel;
        }
    }
}
