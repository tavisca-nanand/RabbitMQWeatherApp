using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.WeatherApp.Model
{
    public interface IWeatherDataProvider
    {
        WeatherReportResponseModel GetWeatherReport(WeatherReportRequestModel requestModel);
    }
}
