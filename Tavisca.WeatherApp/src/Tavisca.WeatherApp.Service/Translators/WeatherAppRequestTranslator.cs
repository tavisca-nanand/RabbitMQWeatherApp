using System;
using System.Collections.Generic;
using Tavisca.WeatherApp.Model;

namespace Tavisca.WeatherApp.Service
{
   public static class WeatherAppRequestTranslator
    {
        public static WeatherReportRequestModel ToModel(this WeatherReportByCityNameRequest request)
        {
            return new WeatherReportRequestModel
            {
                CityName = request.CityName
            };
        }

        public static WeatherReportRequestModel ToModel(this WeatherReportByCityIdRequest request)
        {
            return new WeatherReportRequestModel
            {
                CityId = request.CityId
            };
        }

        public static WeatherReportRequestModel ToModel(this WeatherReportByCityZipCodeRequest request)
        {
            return new WeatherReportRequestModel
            {
                CityZipCode = request.CityZipCode
            };
        }
        public static WeatherReportRequestModel ToModel(this WeatherReportByCityGeoCodeRequest request)
        {
            return new WeatherReportRequestModel
            {
                CityGeoCode = new Model.CityGeoCode()
                {
                    Latitude = request.CityGeoCode.Latitude,
                    Longitude = request.CityGeoCode.Longitude
                }
            };
        }
    }
}
