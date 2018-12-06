using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.WeatherApp.Service.DataContracts.Model
{
    public class WeatherAppRequest
    {
        public string SessionId { get; set; }
        public string InitRequest { get; set; }
    }
}
