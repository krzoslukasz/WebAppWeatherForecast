using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WebAppWeatherForecast.Web.Models.Api;

public class SynopticDataResponse
{
    [JsonPropertyName("id_stacji")]
    public string? IdStacji { get; set; }

    [JsonPropertyName("stacja")]
    public string? Stacja { get; set; }

    [JsonPropertyName("data_pomiaru")]
    public string? DataPomiaru { get; set; }

    [JsonPropertyName("godzina_pomiaru")]
    public string? GodzinaPomiaru { get; set; }

    [JsonPropertyName("temperatura")]
    public string? Temperatura { get; set; }

    [JsonPropertyName("predkosc_wiatru")]
    public string? PredkoscWiatru { get; set; }

    [JsonPropertyName("kierunek_wiatru")]
    public string? KierunekWiatru { get; set; }

    [JsonPropertyName("wilgotnosc_wzgledna")]
    public string? WilgotnoscWzgledna { get; set; }

    [JsonPropertyName("suma_opadu")]
    public string? SumaOpadu { get; set; }

    [JsonPropertyName("cisnienie")]
    public string? Cisnienie { get; set; }

}