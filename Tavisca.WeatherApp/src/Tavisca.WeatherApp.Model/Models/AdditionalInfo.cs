using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.WeatherApp.Model
{
    public class AdditionalInfo
    {
        public string CountryCode { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public decimal Cloudiness { get; set; }
        public int Visibility { get; set; }
    }
}
