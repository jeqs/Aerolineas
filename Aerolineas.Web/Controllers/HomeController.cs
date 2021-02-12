using Aerolineas.App_Code;
using Aerolineas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Aerolineas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> ItinerarioObtener()
        {
            HttpServiceModel httpServiceModel = new HttpServiceModel();
            httpServiceModel.Controlador = "Itinerario";
            httpServiceModel.Accion = "Get";
            var itinerarioData = await ApiCliente<ItinerariosResponse>.ProcessAsync(httpServiceModel);
            return Json(((ItinerariosResponse)itinerarioData).Itinerario, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> AvionCrear(Avion avion)
        {
            HttpServiceModel httpServiceModel = new HttpServiceModel();
            httpServiceModel.Controlador = "Avion";
            httpServiceModel.Accion = avion.Id == 0 ? "Post" : "Put";
            httpServiceModel.Parametros = avion;
            var avionData = await ApiCliente<AvionResponse>.ProcessAsync(httpServiceModel);
            return Json(((AvionResponse)avionData).Avion, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> AvionEliminar(Avion avion)
        {
            HttpServiceModel httpServiceModel = new HttpServiceModel();
            httpServiceModel.Controlador = "Avion";
            httpServiceModel.Accion = "Delete";
            httpServiceModel.Parametros = avion;
            var avionData = await ApiCliente<AvionResponse>.ProcessAsync(httpServiceModel);
            return Json(((AvionResponse)avionData).Avion, JsonRequestBehavior.AllowGet);
        }
    }
}