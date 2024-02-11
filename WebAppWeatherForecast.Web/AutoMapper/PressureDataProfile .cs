using AutoMapper;
using WebAppWeatherForecast.Web.Models.Api;

namespace WebAppWeatherForecast.Web.AutoMapper;

    public class PressureDataProfile: Profile
    {
        public PressureDataProfile()
        {
            CreateMap<SynopticDataResponse,PressureDataResponse>()
            .ForMember( dest => dest.Nazwa,
            opt => opt.MapFrom( s => s.Stacja ))
            .ForMember(dest => dest.Cisnienie,
                opt => opt.MapFrom(s => s.Cisnienie))
            ;
        }
    }