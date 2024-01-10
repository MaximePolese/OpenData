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

            //https://www.mobilites-m.fr/pages/opendata/OpenDataApi.html
            double lon = 5.731181509376984;
            double lat = 45.18486504179179;
            double dist = 300;
            MetroData request1 = new MetroData();
            List<BusStop> busStopArroundMe = request1.GetBusStopArroundMe(lon, lat, dist);
            foreach (var busStop in busStopArroundMe)
            {
                Console.WriteLine(busStop.ToString());
            }

            MetroData request2 = new MetroData();
            Line lineinfo = request2.GetLineInfo("SEM:13");
            Console.WriteLine($"Description: {lineinfo.description}");
            Console.WriteLine($"Type: {lineinfo.type}");
            // Affichage des features
            foreach (var feature in lineinfo.features)
            {
                Console.WriteLine($"Feature description: {feature.type}");
                // Affichage des properties---------------------------
                Console.WriteLine($"Feature NUMERO: {feature.properties.NUMERO}");
                Console.WriteLine($"Feature PMR: {feature.properties.PMR}");
                Console.WriteLine($"Feature COULEUR: {feature.properties.COULEUR}");
                Console.WriteLine($"Feature CODE: {feature.properties.CODE}");
                Console.WriteLine($"Feature LIBELLE: {feature.properties.LIBELLE}");
                Console.WriteLine($"Feature ZONES_ARRET: {feature.properties.ZONES_ARRET}");
                Console.WriteLine($"Feature type: {feature.properties.type}");
                Console.WriteLine($"Feature id: {feature.properties.id}");
                Console.WriteLine($"Feature shape: {feature.properties.shape}");
                //----------------------------------------------------
                Console.WriteLine($"Feature description: {feature.description}");
                
                Console.WriteLine($"Feature description: {feature.geometry.type}");
                Console.WriteLine($"Coordinates:");
                foreach (var coordinateSet in feature.geometry.coordinates)
                {
                    foreach (var coordinate in coordinateSet)
                    {
                        Console.WriteLine($"Longitude: {coordinate[0]}, Latitude: {coordinate[1]}");
                    }
                }
            }
            // Request test = new Request();
            // string result = test.DoRequest("http://data.mobilites-m.fr/api/lines/json?types=ligne&codes=SEM_13");
            // Console.WriteLine(result);
            //
        }
    }
}