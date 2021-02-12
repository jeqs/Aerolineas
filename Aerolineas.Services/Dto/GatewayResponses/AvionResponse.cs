using Aerolineas.Services.Dto.Model;
using System.Collections.Generic;

namespace Aerolineas.Services.Dto.GatewayResponses
{
    public sealed class AvionResponse : BaseGatewayResponse
    {
        public AvionModel Avion { get; set; }

        public AvionResponse(AvionModel avionModel, bool success = false, IEnumerable<Message> messages = null) : base(success, messages)
        {
            Avion = avionModel;
        }
    }

    public sealed class AvionesResponse : BaseGatewayResponse
    {
        public List<AvionModel> Aviones { get; set; }

        public AvionesResponse(List<AvionModel> avionesModel, bool success = false, IEnumerable<Message> messages = null) : base(success, messages)
        {
            Aviones = avionesModel;
        }
    }
}
