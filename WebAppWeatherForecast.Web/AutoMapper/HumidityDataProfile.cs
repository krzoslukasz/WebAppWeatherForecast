using AutoMapper;
using WebAppWeatherForecast.Web.Models.Api;

namespace WebAppWeatherForecast.Web.AutoMapper
{
    public class HumidityDataProfile : Profile
    {
        public HumidityDataProfile()
        {
            CreateMap<SynopticDataResponse, HumidityDataResponse>()
            .ForMember(dest => dest.Nazwa,
            opt => opt.MapFrom(s => s.Stacja))
            .ForMember(dest => dest.Wilgotnosc,
                opt => opt.MapFrom(s => s.WilgotnoscWzgledna))
            ;
        }
    }
}
