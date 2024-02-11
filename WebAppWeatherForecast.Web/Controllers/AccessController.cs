using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppWeatherForecast.Web.DomainServices;
using WebAppWeatherForecast.Web.DomainServices.Base;
using WebAppWeatherForecast.Web.Models.Api;
using WebAppWeatherForecast.Web.Security;

namespace WebAppWeatherForecast.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISynopticDataAccessService _accessService;
        private const string MessageUnauthorised = "Brak uprawnień";

        public AccessController(
            IConfiguration configuration, ISynopticDataAccessService accessService)
        {
            _configuration = configuration;
            _accessService = accessService;
        }

        [HttpGet]
        public ActionResult<StatusResponse> ServerStatus()
        {

            if (!ServerSecurity.SecurityCheck(_configuration, Request.Headers))
            {
                return Unauthorized(MessageUnauthorised);
            }

            var response = _accessService.CheckPublicServerAvibility();

            if (response == null)
            {
                return NotFound();
            }

            return response;
        }

        [HttpGet]
        public ActionResult<StatusResponse> Ping()
        {
            if (!ServerSecurity.SecurityCheck(_configuration, Request.Headers))
            {
                return Unauthorized(MessageUnauthorised);
            }

            var response = _accessService.CheckPing();

            if (response == null)
            {
                return NotFound();
            }
                
            return response;
        }
    }
}
