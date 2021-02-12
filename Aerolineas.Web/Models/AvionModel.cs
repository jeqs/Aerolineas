using System.Collections.Generic;

namespace Aerolineas.Models
{
    public class Avion : BaseGatewayResponse
    {
        public int Id { get; set; }
        public string Nomre { get; set; }
    }

    public sealed class AvionResponse : BaseGatewayResponse
    {
        public Avion Avion { get; set; }

        public AvionResponse(Avion avionModel, bool success = false, IEnumerable<Message> messages = null) : base(success, messages)
        {
            Avion = avionModel;
        }
    }

}
