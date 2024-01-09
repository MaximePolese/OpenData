using System.Collections.Generic;
using Newtonsoft.Json;

namespace ClassLibrary1
{
    public class BusStop
    {
        [JsonProperty("id")] public string id { get; private set; }
        [JsonProperty("name")] public string name { get; private set; }
        [JsonProperty("lon")] public double lon { get; private set; }
        [JsonProperty("lat")] public double lat { get; private set; }
        [JsonProperty("zone")] public string zone { get; private set; }
        [JsonProperty("lines")] public List<string> ConnectionLines { get; private set; }

        public string Line
        {
            get { return string.Join(", ", ConnectionLines); }
        }
        public BusStop(string id, string name, double lon, double lat, string zone, List<string> connectionLines)
        {
            this.id = id;
            this.name = name;
            this.lon = lon;
            this.lat = lat;
            this.zone = zone;
            ConnectionLines = connectionLines;
        }

        public override string ToString()
        {
            return "Bus_Stop {" +
                   "id = " + id +
                   ", name = " + name +
                   ", lon = " + lon +
                   ", lat = " + lat +
                   ", zone = " + zone +
                   ", connection_lines = " + Line +
                   "}";
        }
    }
}