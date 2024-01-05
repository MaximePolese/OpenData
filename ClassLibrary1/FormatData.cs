﻿using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace ClassLibrary1
{
    public class FormatData
    {
        private readonly IRequest _newRequest;
        private readonly double _lon;
        private readonly double _lat;
        private readonly double _dist;
        public List<BusStop> busStopList;

        public FormatData(double lon, double lat, double dist)
            : this(new Request())
        {
            _lon = lon;
            _lat = lat;
            _dist = dist;
        }

        public FormatData(IRequest newRequest)
        {
            _newRequest = newRequest;
            busStopList = new List<BusStop>();
        }

        private string BusStopArroundMe()
        {
            //https://www.mobilites-m.fr/pages/opendata/OpenDataApi.html
            return string.Format(CultureInfo.InvariantCulture,
                "http://data.mobilites-m.fr/api/linesNear/json?x={0}&y={1}&dist={2}&details=true", _lon, _lat, _dist);
        }
        
        private string DisplayLine()
        {
            return string.Format(CultureInfo.InvariantCulture,
                "http://data.mobilites-m.fr/api/lines/json?types=ligne&codes=SEM_C1", _lon, _lat, _dist);
        }
       
        public List<BusStop> DeserializeData()
        {
            return JsonConvert.DeserializeObject<List<BusStop>>(_newRequest.DoRequest(BusStopArroundMe()));
        }

        public List<BusStop> BusStopList
        {
            get => DeserializeData();
            set => busStopList = value;
        }
    }
}