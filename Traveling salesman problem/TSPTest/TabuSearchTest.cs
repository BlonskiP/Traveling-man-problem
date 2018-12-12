using System;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traveling_salesman_problem;
using System.IO;
using System.Diagnostics;

namespace TSPTest
{
    [TestClass]
    public class TabuSearchTest
    {
        private string file;
        string root = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        [TestMethod]
        public void TabuTest1()
        {
            file = root + "\\bays29.xml";

            XDocument tspFile = XDocument.Load(file);
            AdjacencyMatrix testMatrix = new AdjacencyMatrix(tspFile);
            TabuSearch test = new TabuSearch(testMatrix , 10000, 3);

            float lowestKnown = 2020;

            test = new TabuSearch(testMatrix, 10000, 4);
            test.Solve();
            float Result7 = test.lowestCost;
            float errRat7 = (Result7 - lowestKnown) / lowestKnown;







        }
    }
}
