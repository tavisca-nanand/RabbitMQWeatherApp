using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.WeatherApp.Model
{
   public interface IWeatherAdapter
    {
        WeatherReportResponseModel GetWeatherReport(WeatherReportRequestModel requestModel);
    }
}
