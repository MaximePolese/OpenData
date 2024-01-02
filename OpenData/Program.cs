using System;
using System.Net;

namespace OpenData
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            Request newRequest = new Request(5.731181509376984, 45.18486504179179, 0);
            
            foreach (var line in newRequest.GetData())
            {
                Console.WriteLine(line.ToString());
            }
        }
    }
}