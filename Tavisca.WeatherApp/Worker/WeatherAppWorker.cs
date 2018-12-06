using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Tavisca.WeatherApp.Service;
using Tavisca.WeatherApp.Service.DataContracts.Model;

namespace Worker
{
    class WeatherAppWorker
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            WeatherReportByCityNameRequest request = new WeatherReportByCityNameRequest();
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "weatherApp",
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                Console.WriteLine(" [*] Waiting for messages.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);


                    Console.WriteLine(" [x] Done");
                    string outputjson = message.Replace("\\", "");
                    WeatherAppRequest obj = JsonConvert.DeserializeObject<WeatherAppRequest>(outputjson);
                    request.CityName = obj.InitRequest;
                    GetReport(request);
                   
                };
                channel.BasicConsume(queue: "weatherApp",
                                     autoAck: false,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
        public static void GetReport(WeatherReportByCityNameRequest request)
        {
            WeatherAppService weatherAppService = new WeatherAppService();
            var response = weatherAppService.GetWeatherDetailsByCityName(request);
        }
    }
}
