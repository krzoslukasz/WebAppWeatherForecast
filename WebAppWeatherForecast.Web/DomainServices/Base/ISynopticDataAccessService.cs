using WebAppWeatherForecast.Web.Models.Api;

namespace WebAppWeatherForecast.Web.DomainServices.Base
{
    public interface ISynopticDataAccessService
    {
        StatusResponse CheckPublicServerAvibility();
        StatusResponse CheckPing();

    }
}
