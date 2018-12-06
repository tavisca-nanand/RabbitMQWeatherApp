using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.WeatherApp.Model;

namespace Tavisca.WeatherApp.OpenWeatherAdapter
{
    public static class WeatherReportResponseTranslator
    {
        public static WeatherReportResponseModel ToModel(this OpenWeatherResponse responseObj)
        {
            return new WeatherReportResponseModel
            {
                Id = responseObj.id,
                Name = responseObj.name,
                Coordinates = new CityGeoCode
                {
                    Latitude =responseObj.coord.lat.ToString(),
                    Longitude =responseObj.coord.lon.ToString()
                },

                Main = new Model.Main
                {
                    Humidity = responseObj.main.humidity,
                    Temp = responseObj.main.temp,
                    Pressure = responseObj.main.pressure,
                    MinTemperature = responseObj.main.temp_min,
                    MaxTemperature = responseObj.main.temp_max
                },
                Wind = new Model.Wind
                {
                    Degree = responseObj.wind.deg,
                    Speed = responseObj.wind.speed
                },
                Weather = responseObj.weather
                                         .Select(x => new Model.Weather()
                                         {
                                             Description = x.description,
                                             Type = x.main
                                         })
                                         .ToList(),
                TimeSpan = new DateTime(responseObj.dt),
                AdditionalInfo = new Model.AdditionalInfo
                {
                    Cloudiness = responseObj.clouds.all,
                    CountryCode = responseObj.sys.country,
                    Sunrise = new DateTime(responseObj.sys.sunrise),
                    Sunset = new DateTime(responseObj.sys.sunset),
                    Visibility = responseObj.visibility
                }
              

            };
        }
    }
}
