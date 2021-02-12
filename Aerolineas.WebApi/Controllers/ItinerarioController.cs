using Aerolineas.Services;
using Aerolineas.Services.Dto.Model;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Aerolineas.WebApi.Controllers
{
    [Route("api/Itinerario/{action}", Name = "Itinerario")]
    public class ItinerarioController : ApiController
    {
        // GET: api/Itinerario/Obtener
        [HttpGet]
        public HttpResponseMessage Obtener()
        {
            var response = ItinerarioServices.Obtener();
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

        // POST: api/Itinerario/Agregar
        [HttpPost]
        public HttpResponseMessage Agregar([FromBody] ItinerarioModel request)
        {
            var response = ItinerarioServices.Agregar(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

        // POST: api/Itinerario/Actualizar
        [HttpPost]
        public HttpResponseMessage Actualizar([FromBody] ItinerarioModel request)
        {
            var response = ItinerarioServices.Actualizar(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

        // POST: api/Itinerario/Eliminar
        [HttpPost]
        public HttpResponseMessage Eliminar([FromBody] ItinerarioModel request)
        {
            var response = ItinerarioServices.Eliminar(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

    }
}