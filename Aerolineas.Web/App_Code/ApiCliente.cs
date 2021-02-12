using Aerolineas.Models;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aerolineas.App_Code
{
    public static class ApiCliente<T>
    {
        //  HttpClient
        public static readonly HttpClient client = new HttpClient();

        public static string Url
        {
            get
            {
                return ConfigurationManager.AppSettings["RutaUrlApi"];
            }
        }

        public static async Task<dynamic> ProcessAsync(HttpServiceModel httpServiceModel)
        {
            var json = JsonConvert.SerializeObject(httpServiceModel.Parametros);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                string result = string.Empty;
                switch (httpServiceModel.Accion)
                {
                    case "Get":
                        var responseGet = await client.GetAsync(Url + "/" + httpServiceModel.Controlador + "/Obtener");
                        result = responseGet.Content.ReadAsStringAsync().Result;
                        break;
                    case "Post":
                        var responsePost = await client.PostAsync(Url + "/" + httpServiceModel.Controlador + "/Agregar", data);
                        result = responsePost.Content.ReadAsStringAsync().Result;
                        break;
                    case "Put":
                        var responsePut = await client.PostAsync(Url + "/" + httpServiceModel.Controlador + "/Actualizar", data);
                        result = responsePut.Content.ReadAsStringAsync().Result;
                        break;
                    case "Delete":
                        var responseDelete = await client.PostAsync(Url + "/" + httpServiceModel.Controlador + "/Eliminar", data);
                        result = responseDelete.Content.ReadAsStringAsync().Result;
                        break;
                }

                return JsonConvert.DeserializeObject<T>(result);
            }
        }
    }
}