using Microsoft.AspNetCore.Hosting.Server;
using RestSharp;
using System.Diagnostics;
using System.Net;
using WebAppWeatherForecast.Web.DomainServices.Base;
using WebAppWeatherForecast.Web.Models.Api;

namespace WebAppWeatherForecast.Web.DomainServices
{
    public class SynopticDataAccessService : ISynopticDataAccessService
    {
        private readonly RestClient _restClient;
        private readonly string _baseUrl;
        private const string MessageServerWorks = "Serwer pogodowy jest dostępny!";
        private const string MessageServerNotWorks = "Serwer pogodowy jest niedostępny!";

        public SynopticDataAccessService(IConfiguration configuration)
        {
            _baseUrl = configuration.GetValue<string>("PublicDataBasicUrl");
            if (string.IsNullOrWhiteSpace(_baseUrl))
            {
                throw new ArgumentNullException();
            }
            _restClient = new RestClient(_baseUrl);
        }

        public StatusResponse CreateStatusResponse(string info, string code)
        {
            StatusResponse statusResponse = new StatusResponse()
            {
                StatusInformation = info,
                StatusCode = code
            };
            return statusResponse;
        }

        public StatusResponse CheckPublicServerAvibility()
        {
            var request = new RestRequest("/apiinfo", Method.Get);

            try
            {
                var response =  _restClient.Execute(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    return CreateStatusResponse(MessageServerWorks, $"{response.StatusCode}");
                }
                else
                {
                    return CreateStatusResponse(MessageServerNotWorks, $"{response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }

        public StatusResponse CheckPing()
        {
            var request = new RestRequest("", Method.Get);

            try
            {
                var response = _restClient.Execute(request);

                if (response.IsSuccessful && response.Content != null)
                {
                    return CreateStatusResponse(MessageServerWorks, $"{response.StatusCode}");
                }
                else
                {
                    return CreateStatusResponse(MessageServerNotWorks, $"{response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return null;
        }
    }
}
