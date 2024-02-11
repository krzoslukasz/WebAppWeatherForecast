using WebAppWeatherForecast.Web.Models.Api;

namespace WebAppWeatherForecast.Web.DomainServices.Base
{
    public interface ISynopticDataService
    {
        List<SynopticDataResponse> GetListOfSynopticDataForAllTowns();
        List<string> GetTownsList();
        SynopticDataResponse GetSynopticDataForOneTown(string normalizedName);
        List<SynopticDataResponse> GetListOfSynopticDataForTowns(List<string> names);

    }
}
