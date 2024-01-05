using Newtonsoft.Json;

namespace ClassLibrary1
{
    public class BusStop
    {
        // {"id":"SEM:1696","name":"Grenoble, Chavant","lon":5.73233,"lat":45.18502,"zone":"SEM_GENCHAVANT","lines":["SEM:C4","SEM:13"]}
        [JsonProperty("id")] public string id { get; private set; }
        [JsonProperty("name")] public string name { get; private set; }
        [JsonProperty("lon")] public double lon { get; private set; }
        [JsonProperty("lat")] public double lat { get; private set; }
        [JsonProperty("zone")] public string zone { get; private set; }
        [JsonProperty("lines")] public string[] lines { get; private set; }
        
        public BusStop(string id, string name, double lon, double lat, string zone, string[] lines)
        {
            this.id = id;
            this.name = name;
            this.lon = lon;
            this.lat = lat;
            this.zone = zone;
            this.lines = lines;
        }

        public override string ToString()
        {
            string line = string.Join(", ", lines);
            return "Bus_Stop {" +
                   "id = " + id +
                   ", name = " + name +
                   ", lon = " + lon +
                   ", lat = " + lat +
                   ", zone = " + zone +
                   ", lines = " + line +
                   "}";
        }
    }
}