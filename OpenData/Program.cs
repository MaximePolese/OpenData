using System;
using System.Net;
using ClassLibrary1;

namespace OpenData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            FormatData newRequest = new FormatData();
            
            foreach (var line in newRequest.DeserializeData())
            {
                Console.WriteLine(line.ToString());
            }
        }
    }
}