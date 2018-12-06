using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.WeatherApp.Model
{
    public interface IWeatherApp
    {
        WeatherReportResponseModel GetWeatherReport(WeatherReportRequestModel request);
    }
}
