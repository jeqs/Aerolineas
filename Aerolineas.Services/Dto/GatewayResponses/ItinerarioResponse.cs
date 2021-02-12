using Aerolineas.Services.Dto.Model;
using System.Collections.Generic;

namespace Aerolineas.Services.Dto.GatewayResponses
{
    public sealed class ItinerarioResponse : BaseGatewayResponse
    {
        public ItinerarioModel Itinerario { get; set; }

        public ItinerarioResponse(ItinerarioModel itinerarioModel, bool success = false, IEnumerable<Message> messages = null) : base(success, messages)
        {
            Itinerario = itinerarioModel;
        }
    }

    public sealed class ItinerariosResponse : BaseGatewayResponse
    {
        public List<ItinerarioModel> Itinerario { get; set; }

        public ItinerariosResponse(List<ItinerarioModel> itinerariosModel, bool success = false, IEnumerable<Message> messages = null) : base(success, messages)
        {
            Itinerario = itinerariosModel;
        }
    }
}
