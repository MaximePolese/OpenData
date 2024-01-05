using System;
using System.Collections.Generic;
using System.Net;
using ClassLibrary1;
using Newtonsoft.Json;

namespace OpenData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            double lon = 5.731181509376984;
            double lat = 45.18486504179179;
            double dist = 0;
            FormatData request1 = new FormatData();
            string url = request1.BusStopArroundMe(lon, lat, dist);
            string json = request1.GetData(url);
            List<BusStop> busStopArroundMe = request1.DeserializeBusStopData(json);
            foreach (var busStop in busStopArroundMe)
            {
                Console.WriteLine(busStop.ToString());
            }

            // Request test = new Request();
            // string result = test.DoRequest("http://data.mobilites-m.fr/api/lines/json?types=ligne&codes=SEM_13");
            // Console.WriteLine(result);
        }
    }
}