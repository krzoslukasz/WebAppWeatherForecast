using System.Text.Json;
using RestSharp;
using System.Diagnostics;
using WebAppWeatherForecast.Web.DomainServices.Base;
using WebAppWeatherForecast.Web.Models.Api;

namespace WebAppWeatherForecast.Web.DomainServices
{
    public class SynopticDataService : ISynopticDataService
    {
        private readonly RestClient _restClient;
        private readonly string _baseUrl;

        public SynopticDataService(IConfiguration configuration)
        {
            _baseUrl = configuration.GetValue<string>("PublicDataUrl");
            if (string.IsNullOrWhiteSpace(_baseUrl))
            {
                throw new ArgumentNullException();
            }
            _restClient = new RestClient(_baseUrl);
        }

        public List<SynopticDataResponse> GetListOfSynopticDataForAllTowns()
        {
            var request = new RestRequest($"/synop", Method.Get);

            try
            {
                var result = _restClient.Execute<List<SynopticDataResponse>>(request);

                if (result.IsSuccessful && result.Content != null)
                {
                    var synopticDataList = JsonSerializer.Deserialize<List<SynopticDataResponse>>(result.Content);

                    if (synopticDataList == null)
                    {
                        return null;
                    }

                    return synopticDataList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }

        public List<string> GetTownsList()
        {
            var request = new RestRequest($"/synop", Method.Get);

            try
            {
                var result = _restClient.Execute<List<SynopticDataResponse>>(request);

                if (result.IsSuccessful && result.Content != null)
                {
                    var synopticDataList = JsonSerializer.Deserialize<List<SynopticDataResponse>>(result.Content);

                    if (synopticDataList == null)
                    {
                        return null;
                    }
                      
                    var townNamesList = new List<string>();

                    foreach (var item in synopticDataList)
                    {
                        townNamesList.Add(item.Stacja);
                    }

                    return townNamesList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }

        public SynopticDataResponse GetSynopticDataForOneTown(string normalizedName)
        {
            var request = new RestRequest($"/synop/station/{normalizedName}", Method.Get);

            try
            {
                var result = _restClient.Execute<SynopticDataResponse>(request);

                if (result.IsSuccessful && result.Content != null)
                {
                    var synopticData = JsonSerializer.Deserialize<SynopticDataResponse>(result.Content);

                    if (synopticData == null)
                    {
                        return null;
                    }
                        
                    return synopticData;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }

        public List<SynopticDataResponse> GetListOfSynopticDataForTowns(List<string> namesList)
        {
            var request = new RestRequest($"/synop", Method.Get);

            try
            {
                var result = _restClient.Execute<List<SynopticDataResponse>>(request);

                if (result.IsSuccessful && result.Content != null)
                {
                    var synopticDataList = JsonSerializer.Deserialize<List<SynopticDataResponse>>(result.Content);

                    if (synopticDataList == null)
                    {
                        return null;
                    }

                    var synopticDataForTowns = new List<SynopticDataResponse>();

                    for (int i = 0; i < namesList.Count; i++)
                    {
                        namesList[i] = namesList[i].ToUpper();
                    }

                    foreach (var item in synopticDataList)
                    {
                        if (item.Stacja != null)
                        {
                            if (namesList.Contains(item.Stacja.ToUpper()))
                            {
                                synopticDataForTowns.Add(item);
                            }
                        }

                    }

                    return synopticDataForTowns;
                }
                else
                {
                    return null;
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
