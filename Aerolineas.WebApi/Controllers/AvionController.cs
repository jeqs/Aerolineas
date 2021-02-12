using Aerolineas.Services;
using Aerolineas.Services.Dto.Model;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Aerolineas.WebApi.Controllers
{
    [Route("api/Avion/{action}", Name = "Avion")]
    public class AvionController : ApiController
    {
        // GET: api/Avion/Obtener
        [HttpGet]
        public HttpResponseMessage Obtener()
        {
            var response = AvionServices.Obtener();
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

        // POST: api/Avion/Agregar
        [HttpPost]
        public HttpResponseMessage Agregar([FromBody] AvionModel request)
        {
            var response = AvionServices.Agregar(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

        // POST: api/Avion/Actualizar
        [HttpPost]
        public HttpResponseMessage Actualizar([FromBody] AvionModel request)
        {
            var response = AvionServices.Actualizar(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

        // POST: api/Avion/Eliminar
        [HttpPost]
        public HttpResponseMessage Eliminar([FromBody] AvionModel request)
        {
            var response = AvionServices.Eliminar(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

    }
}
