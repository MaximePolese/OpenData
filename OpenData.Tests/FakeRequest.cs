using System.Collections.Generic;
using ClassLibrary1;
using Newtonsoft.Json;

namespace OpenData.Tests
{
    public class FakeRequest : IRequest
    {
        public string DoRequest(string url)
        {
            List<BusStop> test = new List<BusStop>();
            test.Add(new BusStop("SEM:1696", "Grenoble, Chavant", 5.73233, 45.18502, "SEM_GENCHAVANT",
                new List<string> { "SEM:C4", "SEM:13" }));
            test.Add(new BusStop("test", "test", 5.73233, 45.18502, "test", new List<string> { "test1", "test2" }));
            string json = JsonConvert.SerializeObject(test, Formatting.Indented);
            return json;
        }
    }
}