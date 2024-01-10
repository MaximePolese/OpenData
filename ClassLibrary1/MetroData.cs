using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace ClassLibrary1
{
    public class MetroData : IDataAccess
    {
        private readonly IRequest _newRequest;

        public MetroData()
            : this(new Request())
        {
        }

        public MetroData(IRequest newRequest)
        {
            _newRequest = newRequest;
        }

        private string BusStopArroundMeUrl(double lon, double lat, double dist)
        {
            if (dist > 2000)
            {
                dist = 2000;
            }
            string url = string.Format(CultureInfo.InvariantCulture,
                "http://data.mobilites-m.fr/api/linesNear/json?x={0}&y={1}&dist={2}&details=true", lon, lat, dist);
            Console.WriteLine(url);
            return url;
        }

        private string GetData(string url)
        {
            return _newRequest.DoRequest(url);
        }

        private List<BusStop> DeserializeBusStopData(string json)
        {
            return JsonConvert.DeserializeObject<List<BusStop>>(json);
        }

        public List<BusStop> GetBusStopArroundMe(double lon, double lat, double dist)
        {
            return DeserializeBusStopData(GetData(BusStopArroundMeUrl(lon, lat, dist)));
        }

        private string LineInfoUrl(string lineCode)
        {
            return "http://data.mobilites-m.fr/api/lines/json?types=ligne&codes=" + lineCode + "";
        }
        private Line DeserializeLineData(string json)
        {
            return JsonConvert.DeserializeObject<Line>(json);
        }
        public Line GetLineInfo(string lineCode)
        {
            return DeserializeLineData(GetData(LineInfoUrl(lineCode)));
        }

        // public List<double> GetCoords(string lineCode)
        // {
        //     foreach (var feature in lineinfo.features)
        //     {
        //         foreach (var coordinateSet in feature.geometry.coordinates)
        //         {
        //             foreach (var coordinate in coordinateSet)
        //             {
        //                 Line.Add(new Location(coordinate[1], coordinate[0]));
        //             }
        //         }
        //     }
        //
        //     return null;
        // }
    }
}