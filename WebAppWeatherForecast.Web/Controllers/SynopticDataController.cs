using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAppWeatherForecast.Web.AutoMapper;
using WebAppWeatherForecast.Web.DomainServices;
using WebAppWeatherForecast.Web.DomainServices.Base;
using WebAppWeatherForecast.Web.Models.Api;
using WebAppWeatherForecast.Web.Security;

namespace WebAppWeatherForecast.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SynopticDataController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISynopticDataService _publicDataService;
        private readonly ITranslatorService _translatorService;
        private readonly IMapper _mapper;
        private const string MessageTownsNotFound = "Nie znaleziono miast.";
        private const string MessageUnauthorised = "Brak uprawnień";
        private const string MessageRequiredTownsList = "Lista miast jest wymagana!";
        private const string MessageDataForTownsNotFound = "Nie znaleziono danych synoptycznych dla podanych nazw miast.";
        private const string MessageDataForTownNotFound = "Nie znaleziono danych synoptycznych dla podanej nazwy miasta.";


        public SynopticDataController(
            IConfiguration configuration, ISynopticDataService publicDataService,
            ITranslatorService translatorService, IMapper mapper)
        {
            _configuration = configuration;
            _publicDataService = publicDataService;
            _translatorService = translatorService;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<List<SynopticDataResponse>> AllData()
        {
            if (!ServerSecurity.SecurityCheck(_configuration, Request.Headers))
            {
                return Unauthorized(MessageUnauthorised);
            }

            var responseList = _publicDataService.GetListOfSynopticDataForAllTowns();

            if (responseList == null || responseList.Count == 0)
            {
                return NotFound();
            }
               
            return responseList;
        }


        [HttpGet]
        public ActionResult<SynopticDataResponse> AllDataTown(string unnormalizedName)
        {
            if (!ServerSecurity.SecurityCheck(_configuration, Request.Headers))
            {
                return Unauthorized(MessageUnauthorised);
            }

            if (string.IsNullOrEmpty(unnormalizedName))
            {
                return BadRequest(MessageDataForTownNotFound);
            }

            var normalizedName = _translatorService.ToSimplePolish(unnormalizedName);

            var dataResponse = _publicDataService.GetSynopticDataForOneTown(normalizedName);

            if (dataResponse == null)
            {
                return NotFound();
            }

            return dataResponse;
        }

        [HttpPost]
        public ActionResult<List<SynopticDataResponse>> AllDataTowns(List<string> namesList)
        {

            if (!ServerSecurity.SecurityCheck(_configuration, Request.Headers))
            {
                return Unauthorized(MessageUnauthorised);
            }

            if (namesList == null || namesList.Count == 0)
            {
                return BadRequest(MessageRequiredTownsList);
            }

            var responseList = _publicDataService.GetListOfSynopticDataForTowns(namesList);

            if (responseList == null || responseList.Count == 0)
            {
                return NotFound(MessageDataForTownsNotFound);
            }

            return responseList;
        }

        [HttpPost]
        public ActionResult<List<TemperatureDataResponse>> TownsTemperatures(List<string> namesList)
        {
            if (!ServerSecurity.SecurityCheck(_configuration, Request.Headers))
            {
                return Unauthorized(MessageUnauthorised);
            }

            if (namesList == null || namesList.Count == 0)
            {
                return BadRequest(MessageRequiredTownsList);
            }

            var responseList = _publicDataService.GetListOfSynopticDataForTowns(namesList);

            if (responseList == null || responseList.Count == 0)
            {
                return NotFound(MessageDataForTownsNotFound);
            }

            var temperatureDataResponse = new List<TemperatureDataResponse>();
           
            foreach ( var item in responseList)
            {
                temperatureDataResponse.Add(_mapper.Map<TemperatureDataResponse>(item));
            }

            return temperatureDataResponse;
        }

        [HttpPost]
        public ActionResult<List<PressureDataResponse>> TownsPressures(List<string> namesList)
        {
            if (!ServerSecurity.SecurityCheck(_configuration, Request.Headers))
            {
                return Unauthorized(MessageUnauthorised);
            }

            if (namesList == null || namesList.Count == 0)
            {
                return BadRequest(MessageRequiredTownsList);
            }

            var responseList = _publicDataService.GetListOfSynopticDataForTowns(namesList);

            if (responseList == null || responseList.Count == 0)
            {
                return NotFound(MessageDataForTownsNotFound);
            }

            var pressureDataResponse = new List<PressureDataResponse>();

            foreach (var item in responseList)
            {
                pressureDataResponse.Add(_mapper.Map<PressureDataResponse>(item));
            }

            return pressureDataResponse;
        }

        [HttpPost]
        public ActionResult<List<HumidityDataResponse>> TownsHumidities(List<string> namesList)
        {
            if (!ServerSecurity.SecurityCheck(_configuration, Request.Headers))
            {
                return Unauthorized(MessageUnauthorised);
            }

            if (namesList == null || namesList.Count == 0)
            {
                return BadRequest(MessageRequiredTownsList);
            }

            var responseList = _publicDataService.GetListOfSynopticDataForTowns(namesList);

            if (responseList == null || responseList.Count == 0)
            {
                return NotFound(MessageDataForTownsNotFound);
            }

            var humidityDataResponse = new List<HumidityDataResponse>();

            foreach (var item in responseList)
            {
                humidityDataResponse.Add(_mapper.Map<HumidityDataResponse>(item));
            }

            return humidityDataResponse;
        }

        [HttpGet]
        public ActionResult<List<string>> Towns()
        {
            if (!ServerSecurity.SecurityCheck(_configuration, Request.Headers))
            {
                return Unauthorized(MessageUnauthorised);
            }

            var responseList = _publicDataService.GetTownsList();

            if (responseList == null || responseList.Count == 0)
            {
                return NotFound(MessageTownsNotFound);
            }
               
            return responseList;
        }


    }
}
