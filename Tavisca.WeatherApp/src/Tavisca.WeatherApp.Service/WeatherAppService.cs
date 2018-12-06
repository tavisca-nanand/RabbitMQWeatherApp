using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.WeatherApp.Model;
using Core = Tavisca.WeatherApp.Core;
using Tavisca.WeatherApp.Service.Validators;
using System.IO;
using RabbitMQ.Client;
using Newtonsoft.Json;
using Tavisca.WeatherApp.Service.DataContracts;
using Tavisca.WeatherApp.Service.FileSystems;
using Tavisca.WeatherApp.Service.Queues;

namespace Tavisca.WeatherApp.Service
{
    public class WeatherAppService : IWeatherAppService
    {

        private readonly IWeatherApp weatherApp;
        public WeatherAppService()
        {
            weatherApp = new Core.WeatherApp();
        }

        
        public object GetWeatherDetailsByCityName(WeatherReportByCityNameRequest request)
        {
            Validation.EnsureValid(request, new WeatherReportByCityNameRequestValidator());

            var requestModel = request.ToModel();
            var responseModel = weatherApp.GetWeatherReport(requestModel);
            return responseModel.ToDataContract();
        }

        public object GetWeatherDetailsByCityId(WeatherReportByCityIdRequest request)
        {
            Validation.EnsureValid(request, new WeatherReportByCityIdRequestValidator());
            var requestModel = request.ToModel();
            var responseModel = weatherApp.GetWeatherReport(requestModel);
            return responseModel.ToDataContract();
        }

        public object GetWeatherDetailsByCityGeoCode(WeatherReportByCityGeoCodeRequest request)
        {
            Validation.EnsureValid(request, new WeatherReportByGeoCodeRequestValidator());
            var requestModel = request.ToModel();
            var responseModel = weatherApp.GetWeatherReport(requestModel);
            return responseModel.ToDataContract();
        }

        public object GetWeatherDetailsByCityZipCode(WeatherReportByCityZipCodeRequest request)
        {
            Validation.EnsureValid(request, new WeatherReportByCityZipCodeRequestValidator());
            var requestModel = request.ToModel();
            var responseModel = weatherApp.GetWeatherReport(requestModel);
            return responseModel.ToDataContract();
        }

        public RequestIdentifier GetInitWeatherReportByCityName(WeatherReportByCityNameRequest request)
        {
            string sessionId = Guid.NewGuid().ToString();
            FileSystem dataStore = new FileSystem();
            RequestIdentifier data = dataStore.CreateFile(sessionId);
            RabbitMQStore store = new RabbitMQStore();
            RequestIdentifier storeId = store.EnqueueInRabbitMQ(data, request);
            return new RequestIdentifier() { Sessionid = storeId.Sessionid };
        }

        public RequestIdentifierResponse GetWeatherResult(RequestIdentifier request)
        {
            return new RequestIdentifierResponse()
            {
            };
                
        }

       
    }
}
