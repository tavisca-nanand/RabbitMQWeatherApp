using System;
using Tavisca.Platform.Common.Models;
using Tavisca.WeatherApp.Model;

namespace Tavisca.WeatherApp.OpenWeatherAdapter
{
    public class OpenWeatherAdapter : WeatherReportBase, IWeatherAdapter
    {
        private readonly OpenWeatherAppSvcSettings _settings;

        public OpenWeatherAdapter(OpenWeatherAppSvcSettings settings)
        {
            _settings = settings;
        }

        public WeatherReportResponseModel GetWeatherReport(WeatherReportRequestModel requestModel)
        {
            if (_settings == null)
                throw new BaseApplicationException(ErrorMessages.MandatoryFieldMissing("OpenWeatherSvcSettings"), FaultCodes.MandatoryFieldMissing);

            var url = GenerateUrl(requestModel);

            var responseObj = Execute<OpenWeatherResponse>(url);

            return responseObj.ToModel();
        }

        private string GenerateUrl(WeatherReportRequestModel requestModel)
        {
            string url = null;
            if (requestModel.CityId != 0)
                url = $"{_settings.Url}?id={requestModel.CityId}&APPID={_settings.ApiKey}";
            else if (requestModel.CityName != null)
                url = $"{_settings.Url}?q={requestModel.CityName}&APPID={_settings.ApiKey}";

            else if (requestModel.CityZipCode != 0)
                url = $"{_settings.Url}?zip={requestModel.CityZipCode}&APPID={_settings.ApiKey}";
            else if (requestModel.CityGeoCode.Latitude != "0" && requestModel.CityGeoCode.Longitude != "0")
                url = $"{_settings.Url}?lat={requestModel.CityGeoCode.Latitude}&lon={requestModel.CityGeoCode.Longitude}&APPID={_settings.ApiKey}";
            return url;
          
        }
    }
}