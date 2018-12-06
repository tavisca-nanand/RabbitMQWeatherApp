using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tavisca.WeatherApp.Service.DataContracts;

namespace Tavisca.WeatherApp.Service.FileSystems
{
    public class FileSystem
    {
        public RequestIdentifier CreateFile(string id)
        {
            RequestIdentifierResponse InitResult = new RequestIdentifierResponse();
            InitResult.Status = "In Progress";
            string JSONresult = JsonConvert.SerializeObject(InitResult);
            var path = @"C:\Users\nanand\Desktop\" + id + ".txt";
            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(JSONresult.ToString());
                tw.Close();
            }
            return new RequestIdentifier()
            {
                Sessionid = id
            };
        }
    }
}
