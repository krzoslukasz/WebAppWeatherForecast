namespace WebAppWeatherForecast.Web.Models.Api;

public class SynopticShortDataResponse
{
    public string Nazwa { get; set; }
    public string DataPomiaru { get; set; }
    public string GodzinaPomiaru { get; set; }
    public string Temperatura { get; set; }
    public string Cisnienie { get; set; }
}