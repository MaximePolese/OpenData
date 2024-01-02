using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace OpenData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            Request newRequest = new Request();
            newRequest.Connection();
            Console.WriteLine(newRequest.ResponseFromServer);
            newRequest.CloseConnection();
            
            // Conversion d'un JSON en Objet grace à Newtonsoft.Json (téléchargeable via le gestionnaire de paquet Nuget)
            List<Ligne> lineList = JsonConvert.DeserializeObject<List<Ligne>>(newRequest.ResponseFromServer);
            foreach (var line in lineList)
            {
                Console.WriteLine(line.ToString());
            }
        }
    }
}