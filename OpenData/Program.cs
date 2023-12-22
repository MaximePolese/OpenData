using System;
using System.IO;
using System.Net;

namespace OpenData
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            // coordonnées GPS le Totem : 45.18486504179179, 5.731181509376984
            WebRequest request =
                WebRequest.Create(
                    "http://data.mobilites-m.fr/api/linesNear/json?x=5.731181509376984&y=45.18486504179179&dist=0&details=false");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response.StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();
        }
    }
}