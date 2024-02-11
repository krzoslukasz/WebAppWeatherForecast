using System.Text.Json;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace WebAppWeatherForecast.Web.Models.Api
{
    public class StatusResponse
    {
        public required string StatusInformation { get; set; }
        public required string StatusCode { get; set; }

        public override string ToString()
        {
            return $"StatusInformation: {StatusInformation}, StatusCode: {StatusCode}";
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static StatusResponse Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<StatusResponse>(json);
        }
    }
}
