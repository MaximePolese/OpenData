using System;
using System.Collections;
using Newtonsoft.Json;

namespace OpenData.Properties
{
    public class Ligne
    {
        // {"id":"SEM:1696","name":"Grenoble, Chavant","lon":5.73233,"lat":45.18502,"zone":"SEM_GENCHAVANT","lines":["SEM:C4","SEM:13"]}
        [JsonProperty("id")] private string id;
        [JsonProperty("name")] private string name;
        [JsonProperty("lon")] private float lon;
        [JsonProperty("lat")] private float lat;
        [JsonProperty("zone")] private string zone;
        [JsonProperty("lines")] private string[] lines;

        public string Id
        {
            get => id;
            set => id = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public float Lon
        {
            get => lon;
            set => lon = value;
        }

        public float Lat
        {
            get => lat;
            set => lat = value;
        }

        public string Zone
        {
            get => zone;
            set => zone = value;
        }

        public string[] Lines
        {
            get => lines;
            set => lines = value;
        }
    }
}