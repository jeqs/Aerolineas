using AutoMapper;
using Aerolineas.Services.Dto.Model;
using Aerolineas.DataStorage.BD;

namespace Aerolineas.Services.Dto
{
    public static class ConfigAutomapper
    {
        public static IMapper mapper { get; set; }
        public static void Config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AvionModel, Avion>().ReverseMap();
                cfg.CreateMap<ItinerarioModel, Itinerario>().ReverseMap();
                cfg.CreateMap<ItinerarioModel, Itinerarios>().ReverseMap();
            });

            mapper = config.CreateMapper();
        }
    }
}
