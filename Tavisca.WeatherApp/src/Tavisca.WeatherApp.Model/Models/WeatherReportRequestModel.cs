using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.WeatherApp.Model
{
    public class WeatherReportRequestModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CityZipCode { get; set; }
        public CityGeoCode CityGeoCode{ get; set; }
    }
}

