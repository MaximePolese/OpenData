using System;
using System.Globalization;
using System.IO;
using System.Net;

namespace OpenData
{
    public class Request : IRequest
    {
        private readonly double _lon;

        private readonly double _lat;

        private readonly double _dist;

        public Request(double lon, double lat, double dist)
        {
            _lon = lon;
            _lat = lat;
            _dist = dist;
        }

        public string GetData()
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
            // Console.WriteLine(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
    }
}