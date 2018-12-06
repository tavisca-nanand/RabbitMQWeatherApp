using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.WeatherApp.Service.DataContracts.Interfaces
{
    public interface IQueue
    {
        RequestIdentifier EnqueueInRabbitMQ(RequestIdentifier data, WeatherReportByCityNameRequest request);
    }
}
