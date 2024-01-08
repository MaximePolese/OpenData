using Newtonsoft.Json;

namespace ClassLibrary1
{
    public class BusStop2
    {
        [JsonProperty("id")] public string id { get; private set; }
        [JsonProperty("name")] public string name { get; private set; }
        [JsonProperty("lon")] public double lon { get; private set; }
        [JsonProperty("lat")] public double lat { get; private set; }
        [JsonProperty("zone")] public string zone { get; private set; }
        
        [JsonProperty("lines")] public ConnectionLine[] Connectionlines { get; private set; }
        
        public BusStop(string id, string name, double lon, double lat, string zone, ConnectionLine[] connectionLines)
        {
            this.id = id;
            this.name = name;
            this.lon = lon;
            this.lat = lat;
            this.zone = zone;
            Connectionlines = new ConnectionLine[];
        }

        public override string ToString()
        {
            // string line = string.Join(", ", lines);
            return "Bus_Stop {" +
                   "id = " + id +
                   ", name = " + name +
                   ", lon = " + lon +
                   ", lat = " + lat +
                   ", zone = " + zone +
                   ", connection_lines = " + Connectionlines +
                   "}";
        }
    }

    public class ConnectionLine
    {
        private string _connectionLine;
        
        public ConnectionLine(string connectionLine)
        {
            _connectionLine = connectionLine;
        }
    }
}