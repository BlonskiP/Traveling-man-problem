using System;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traveling_salesman_problem;
using System.IO;

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
            test.Solve();
            float Result1 = test.lowestCost;
            float errRat1 = (Result1 - 2020) / 2020;
            test = new TabuSearch(testMatrix, 10000, 5);
            test.Solve();
            float Result2 = test.lowestCost;
            float errRat2 = (Result2 - 2020) / 2020;
            test = new TabuSearch(testMatrix, 10000, 7);
            test.Solve();
            float Result3 = test.lowestCost;
            float errRat3 = (Result3 - 2020) / 2020;
            test = new TabuSearch(testMatrix, 10000, 8);
            test.Solve();
            float Result4 = test.lowestCost;
            float errRat4 = (Result4 - 2020) / 2020;
            test = new TabuSearch(testMatrix, 10000, 10);
            test.Solve();
            float Result5 = test.lowestCost;
            float errRat5 = (Result5 - 2020) / 2020;
            test = new TabuSearch(testMatrix, 10000, 15);
            test.Solve();
            float Result6 = test.lowestCost;
            float errRat6 = (Result6 - 2020) / 2020;

            test = new TabuSearch(testMatrix, 10000, 15);
            test.Solve();
            float Result7 = test.lowestCost;
            float errRat7 = (Result7 - 2020) / 2020;







        }
    }
}
