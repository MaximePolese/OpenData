using Newtonsoft.Json;

namespace OpenData
{
    public class Ligne
    {
        // {"id":"SEM:1696","name":"Grenoble, Chavant","lon":5.73233,"lat":45.18502,"zone":"SEM_GENCHAVANT","lines":["SEM:C4","SEM:13"]}
        [JsonProperty("id")] public string id { get; private set; }
        [JsonProperty("name")] public string name { get; private set; }
        [JsonProperty("lon")] public float lon { get; private set; }
        [JsonProperty("lat")] public float lat { get; private set; }
        [JsonProperty("zone")] public string zone { get; private set; }
        [JsonProperty("lines")] public string[] lines { get; private set; }

        public override string ToString()
        {
            string line = string.Join(", ", lines);
            return "Ligne {" +
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