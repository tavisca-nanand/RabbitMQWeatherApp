using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tavisca.WeatherApp.Service;

namespace Tavisca.WeatherApp.Web.Controllers
{
    [Route("api/WeatherDetails")]
    [ApiController]
    public class WeatherDetailsController : ControllerBase
    {
        private readonly IWeatherAppService weatherAppService;

        public WeatherDetailsController()
        {
            weatherAppService = new WeatherAppService();
        }
        [HttpPost]
        [Route("InitialiseByCityName")]
        public IActionResult InitaliseByCityName([FromBody] WeatherReportByCityNameRequest request)
        {
            var response = weatherAppService.GetInitWeatherReportByCityName(request);
            return Ok(response);
          
        }

        [HttpPost]
        [Route("GetWeatherByCityName")]
        public IActionResult GetWeatherDetailsByCityName([FromBody] WeatherReportByCityNameRequest request)
        {
           var response =  weatherAppService.GetWeatherDetailsByCityName(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("GetWeatherByCityId")]
        public ActionResult GetWeatherReportByCityId([FromBody] WeatherReportByCityIdRequest request)
        {
            var response = weatherAppService.GetWeatherDetailsByCityId(request);
            return Ok(response);
        }
        [HttpPost]
        [Route("GetWeatherByCityGeoCode")]
        public ActionResult GetWeatherReportByGeoCode([FromBody] WeatherReportByCityGeoCodeRequest request)
        {
            var response = weatherAppService.GetWeatherDetailsByCityGeoCode(request);
            return Ok(response);
        }
        [HttpPost]
        [Route("GetWeatherByCityZipcode")]
        public ActionResult GetWeatherReportByZipCode([FromBody] WeatherReportByCityZipCodeRequest request)
        {
            var response = weatherAppService.GetWeatherDetailsByCityZipCode(request);
            return Ok(response);
        }
    }
}