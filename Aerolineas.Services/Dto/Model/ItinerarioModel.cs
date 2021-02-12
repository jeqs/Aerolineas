namespace Aerolineas.Services.Dto.Model
{
    public class ItinerarioModel
    {
        public int Id { get; set; }
        public int? IdAvion { get; set; }
        public int? IdCiudad { get; set; }
        public decimal? HorasVuelo { get; set; }

        // Propiedades Extendidas
        public string Nomre { get; set; }
        public string Nombre { get; set; }

    }
}
