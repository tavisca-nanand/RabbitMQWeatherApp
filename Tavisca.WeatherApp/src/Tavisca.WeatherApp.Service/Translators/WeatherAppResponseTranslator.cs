using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.WeatherApp.Model;

namespace Tavisca.WeatherApp.Service
{
    public static class WeatherReportResponseTranslator
    {
        public static WeatherReportResponse ToDataContract(this WeatherReportResponseModel responseModel)
        {
            return new WeatherReportResponse
            {
                Id = responseModel.Id,
                Name = responseModel.Name,
                Coordinates = new CityGeoCode
                {
                    Latitude = responseModel.Coordinates.Latitude,
                    Longitude = responseModel.Coordinates.Longitude
                },
                Main = new Main
                {
                    Temp = responseModel.Main.Temp,
                    Humidity = responseModel.Main.Humidity,
                    Pressure = responseModel.Main.Pressure,
                    MaxTemperature = responseModel.Main.MaxTemperature,
                    MinTemperature = responseModel.Main.MinTemperature
                },
                Wind = new Wind
                {
                    Speed = responseModel.Wind.Speed,
                    Degree = responseModel.Wind.Degree
                },
                Weather = responseModel.Weather
                                        .Select(x => new Weather()
                                        {
                                            Description = x.Description,
                                            Type = x.Type
                                        })
                                        .ToList(),
                TimeSpan = responseModel.TimeSpan,
                AdditionalInfo = new AdditionalInfo
                {
                    Cloudiness = responseModel.AdditionalInfo.Cloudiness,
                    CountryCode = responseModel.AdditionalInfo.CountryCode,
                    Sunrise = responseModel.AdditionalInfo.Sunrise,
                    Sunset = responseModel.AdditionalInfo.Sunset,
                    Visibility = responseModel.AdditionalInfo.Visibility
                }

            };
        }
    }
}