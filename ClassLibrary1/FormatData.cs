using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;

namespace ClassLibrary1
{
    public class FormatData
    {
        private readonly IRequest _newRequest;

        public FormatData()
            : this(new Request())
        {
        }

        public FormatData(IRequest newRequest)
        {
            _newRequest = newRequest;
        }

        public string BusStopArroundMe(double lon, double lat, double dist)
        {
            //https://www.mobilites-m.fr/pages/opendata/OpenDataApi.html
            return string.Format(CultureInfo.InvariantCulture,
                "http://data.mobilites-m.fr/api/linesNear/json?x={0}&y={1}&dist={2}&details=true", lon, lat, dist);
        }

        public string GetData(string url)
        {
            return  _newRequest.DoRequest(url);
        }
        public List<BusStop> DeserializeBusStopData(string json)
        {
            return JsonConvert.DeserializeObject<List<BusStop>>(json);
        }
        
        private string GetLines(string code)
        {
            return "http://data.mobilites-m.fr/api/lines/json?types=ligne&codes=" + code + "";
        }
    }
}