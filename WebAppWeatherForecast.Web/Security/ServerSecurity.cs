using AutoMapper;
using Microsoft.Extensions.Configuration;
using WebAppWeatherForecast.Web.DomainServices.Base;

namespace WebAppWeatherForecast.Web.Security
{
    public class ServerSecurity
    {
        
        public static bool SecurityCheck(IConfiguration configuration, IHeaderDictionary requestHeaders)
        {
            if (requestHeaders.TryGetValue("client-token", out var token))
            {
                var tokenValue = token.FirstOrDefault();
                if (string.IsNullOrWhiteSpace(tokenValue))
                    return false;

                var localToken = configuration.GetValue<string>("ClientToken");
                if (string.IsNullOrWhiteSpace(localToken))
                    return false;

                if (tokenValue == localToken)
                    return true;
            }

            return false;
        }
    }
}
