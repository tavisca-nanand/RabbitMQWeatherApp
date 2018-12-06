using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.WeatherApp.Service.DataContracts;
using Tavisca.WeatherApp.Service.DataContracts.Interfaces;
using Tavisca.WeatherApp.Service.DataContracts.Model;

namespace Tavisca.WeatherApp.Service.Queues
{
    public class RabbitMQStore : IQueue
    {
        public RequestIdentifier EnqueueInRabbitMQ(RequestIdentifier data, WeatherReportByCityNameRequest request)
        {
            WeatherAppRequest WeatherRequest = new WeatherAppRequest();
            WeatherRequest.SessionId = data.Sessionid;
            WeatherRequest.InitRequest = request.CityName;
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            using (var connection = factory.CreateConnection())
            using (var senderRequest = connection.CreateModel())
            {
                senderRequest.QueueDeclare(
                               queue: "weatherApp",
                               durable: false,
                                exclusive: false,
                                autoDelete: false,
                                arguments: null);
                string message = JsonConvert.SerializeObject(WeatherRequest);
                var body = Encoding.UTF8.GetBytes(message);
                senderRequest.BasicPublish(exchange: "", routingKey: "weatherApp", basicProperties: null, body: body);
                Console.WriteLine("Message sent successfully");
            }
            return new RequestIdentifier
            {
                Sessionid = data.Sessionid
            };
        }
    }
}
