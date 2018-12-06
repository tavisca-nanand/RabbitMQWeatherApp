using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.WeatherApp.Service.DataContracts;

namespace Tavisca.WeatherApp.Service
{
    public interface IWeatherAppService
    {
        object GetWeatherDetailsByCityName(WeatherReportByCityNameRequest request);
        object GetWeatherDetailsByCityId(WeatherReportByCityIdRequest request);
        object GetWeatherDetailsByCityGeoCode(WeatherReportByCityGeoCodeRequest request);
        object GetWeatherDetailsByCityZipCode(WeatherReportByCityZipCodeRequest request);
        RequestIdentifier GetInitWeatherReportByCityName(WeatherReportByCityNameRequest request);
        RequestIdentifierResponse GetWeatherResult(RequestIdentifier request);
    }
}
