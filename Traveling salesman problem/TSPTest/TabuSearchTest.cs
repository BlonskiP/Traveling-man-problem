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
            file = root + "\\brazil58.xml";

            XDocument tspFile = XDocument.Load(file);
            AdjacencyMatrix testMatrix = new AdjacencyMatrix(tspFile);
            TabuSearch test = new TabuSearch(testMatrix , 1000, 3);
            test.diversificationState = true;
            test.neigState = "2or";
            test.Solve();
            float lowestKnown = 25395;
            float Result1= test.lowestCost;
            float errRat1 = (Result1- lowestKnown) / lowestKnown;
            test = new TabuSearch(testMatrix, 2000, 3);
            test.diversificationState = true;
            test.neigState = "3or";
            test.Solve();
            float Result2 = test.lowestCost;
            float errRat2 = (Result2 - lowestKnown) / lowestKnown;

            test = new TabuSearch(testMatrix, 2000, 3);
            test.diversificationState = true;
            test.neigState = "1switch";
            test.Solve();
            float Result3 = test.lowestCost;
            float errRat3 = (Result3 - lowestKnown) / lowestKnown;





        }
    }
}
