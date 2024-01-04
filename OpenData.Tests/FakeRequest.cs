using System.Collections.Generic;
using ClassLibrary1;
using Newtonsoft.Json;

namespace OpenData.Tests
{
    public class FakeRequest : IRequest
    {
        public string GetData(string url)
        {
            List<Ligne> test = new List<Ligne>();
            test.Add(new Ligne("SEM:1696", "Grenoble, Chavant", 5.73233, 45.18502, "SEM_GENCHAVANT", new string[] { "SEM:C4", "SEM:13"}));
            test.Add(new Ligne("test", "test", 5.73233, 45.18502, "test", new string[] { "test1","test2" }));
            string json = JsonConvert.SerializeObject(test, Formatting.Indented);
            return json;
        }
    }
}