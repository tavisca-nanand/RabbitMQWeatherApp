using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.WeatherApp.Service.DataContracts
{
    public class RequestIdentifierResponse
    {
        public string Status { get; set; }
        public WeatherReportResponse WeatherDetails { get; set; }
    }
}
