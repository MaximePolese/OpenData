using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;

namespace OpenData.Tests
{
    [TestClass]
    [TestSubject(typeof(Program))]
    public class ProgramTest
    {
        [TestMethod]
        public void Test()
        {
            MetroData request1 = new MetroData(new FakeRequest());
            List<BusStop> result = request1.GetBusStopArroundMe(0, 0, 0);
            foreach (var line in result)
            {
                Console.WriteLine(line.ToString());
            }

            List<BusStop> expected = new List<BusStop>();
            expected.Add(new BusStop("SEM:1696", "Grenoble, Chavant", 5.73233, 45.18502, "SEM_GENCHAVANT",
                new List<string> { "SEM:C4", "SEM:13" }));
            expected.Add(new BusStop("test", "test", 5.73233, 45.18502, "test",
                new List<string> { "test1", "test2" }));

            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Count, result.Count);
            Assert.AreEqual("Grenoble, Chavant", result[0].name);

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].id, result[i].id);
                Assert.AreEqual(expected[i].name, result[i].name);
                Assert.AreEqual(expected[i].lon, result[i].lon);
                Assert.AreEqual(expected[i].lat, result[i].lat);
            }
        }
    }
}