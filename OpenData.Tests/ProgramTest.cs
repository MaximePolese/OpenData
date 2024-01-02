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
            FormatData newRequest = new FormatData(new FakeRequest());
            List<Ligne> result = newRequest.DeserializeData();

            List<Ligne> expected = new List<Ligne>();
            expected.Add(new Ligne("SEM:1696", "Grenoble, Chavant", 5.73233, 45.18502, "SEM_GENCHAVANT",
                new string[] { "SEM:C4", "SEM:13" }));
            expected.Add(new Ligne("test", "test", 5.73233, 45.18502, "test", new string[] { "test1", "test2" }));
            
            Assert.AreEqual(expected.Count, result.Count);
            
            // foreach (var line in result)
            // {
            //     Assert.AreEqual(expected, line);
            // }
            
        }
    }
}