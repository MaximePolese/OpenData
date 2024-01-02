using System;
using System.Net;
using ClassLibrary1;

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
            FormatData newRequest = new FormatData(lon, lat, dist);

            foreach (var line in newRequest.DeserializeData())
            {
                Console.WriteLine(line.ToString());
            }
        }
    }
}