using AutoMapper;
using WebAppWeatherForecast.Web.Models.Api;

namespace WebAppWeatherForecast.Web.AutoMapper;

public class SynopticShortDataProfile: Profile
{
    public SynopticShortDataProfile()
    {
        CreateMap<SynopticDataResponse,SynopticShortDataResponse>()
        .ForMember( dest => dest.Nazwa,
        opt => opt.MapFrom( s => s.Stacja ))
        .ForMember(dest => dest.Temperatura,
            opt => opt.MapFrom(s => s.Temperatura))
        .ForMember(dest => dest.DataPomiaru,
            opt => opt.MapFrom(s => s.DataPomiaru))
        .ForMember(dest => dest.Cisnienie,
            opt => opt.MapFrom(s => s.Cisnienie))
        .ForMember(dest => dest.GodzinaPomiaru,
            opt => opt.MapFrom(s => s.GodzinaPomiaru))
        ;
    }
}