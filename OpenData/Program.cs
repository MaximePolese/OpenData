﻿using System;
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
            //https://www.mobilites-m.fr/pages/opendata/OpenDataApi.html
            double lon = 5.731181509376984;
            double lat = 45.18486504179179;
            double dist = 300;
            FormatData request1 = new FormatData();
            List<BusStop> busStopArroundMe = request1.GetBusStopArroundMe(lon, lat, dist);
            foreach (var busStop in busStopArroundMe)
            {
                Console.WriteLine(busStop.ToString());
            }
            
            Line lineinfo = 

            // Request test = new Request();
            // string result = test.DoRequest("http://data.mobilites-m.fr/api/lines/json?types=ligne&codes=SEM_13");
            // Console.WriteLine(result);
        }
    }
}