using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace OpenData
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            
            // Requete à l'API TAG Grenoble des lignes à proximité d'un point
            // coordonnées GPS le Totem : 45.18486504179179, 5.731181509376984
            WebRequest request = WebRequest.Create("http://data.mobilites-m.fr/api/linesNear/json?x=5.731181509376984&y=45.18486504179179&dist=0&details=true");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Console.WriteLine(response.StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            // Console.WriteLine(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();

            // Conversion d'un JSON en Objet grace à Newtonsoft.Json (téléchargeable via le gestionnaire de paquet Nuget)
            List<Ligne> lineList = JsonConvert.DeserializeObject<List<Ligne>>(responseFromServer);
            foreach (var line in lineList)
            {
                Console.WriteLine(line.ToString());
            }
        }
    }
}