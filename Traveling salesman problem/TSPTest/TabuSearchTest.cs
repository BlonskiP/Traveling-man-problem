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
            TabuSearch test = new TabuSearch(testMatrix , 50000, 5);

            test.Solve();
            float Result1 = test.lowestCost;
            test = new TabuSearch(testMatrix, 5000, 5);

            test.Solve();
            float Result2 = test.lowestCost;
             test = new TabuSearch(testMatrix, 10000, 5);

            test.Solve();
            float Result3 = test.lowestCost;
             test = new TabuSearch(testMatrix, 15000, 5);

            test.Solve();
            float Result4 = test.lowestCost;
             test = new TabuSearch(testMatrix, 20000, 5);

            test.Solve();
            float Result5 = test.lowestCost;
             test = new TabuSearch(testMatrix, 25000, 5);

            test.Solve();
            float Result6 = test.lowestCost;
            


        }
    }
}
