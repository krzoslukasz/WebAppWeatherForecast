using AutoMapper;
using WebAppWeatherForecast.Web.Models.Api;

namespace WebAppWeatherForecast.Web.AutoMapper
{
    public class TemperatureDataProfile : Profile
    {
        public TemperatureDataProfile()
        {
            CreateMap<SynopticDataResponse, TemperatureDataResponse>()
            .ForMember(dest => dest.Nazwa,
            opt => opt.MapFrom(s => s.Stacja))
            .ForMember(dest => dest.Temperatura,
                opt => opt.MapFrom(s => s.Temperatura))
            ;

        }
    }
}
