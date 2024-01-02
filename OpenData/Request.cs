using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace OpenData
{
    public class Request : IRequest
    {
        private readonly double _lon;

        private readonly double _lat;

        private readonly double _dist;

        private List<Ligne> _lineList;

        public Request(double lon, double lat, double dist)
        {
            _lon = lon;
            _lat = lat;
            _dist = dist;
            _lineList = new List<Ligne>();
        }

        public List<Ligne> GetData()
        {
            string api = string.Format(CultureInfo.InvariantCulture,
                "http://data.mobilites-m.fr/api/linesNear/json?x={0}&y={1}&dist={2}&details=true", _lon, _lat, _dist);
            // Console.WriteLine(api);
            WebRequest request = WebRequest.Create(api);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Console.WriteLine(response.StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();
            _lineList = JsonConvert.DeserializeObject<List<Ligne>>(responseFromServer);
            return _lineList;
        }
    }
}