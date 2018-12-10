using System;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traveling_salesman_problem;
using System.IO;
namespace TSPTest
{
    [TestClass]
    public class SimulatedAnn
    {
        private string file;
        string root = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        [TestMethod]
        public void AnnealingTest1()
        {
            file = root + "\\bays29.xml";
            
            XDocument tspFile = XDocument.Load(file);
            AdjacencyMatrix testMatrix = new AdjacencyMatrix(tspFile);
            SimulatedAnnealing test = new SimulatedAnnealing(testMatrix);

            test.SetTemperature(10,(float)0.997,1,5000);
           for(int i=0;i<1000;i++)
            {
                float result = test.Calculate();
                if(result>3500)  // best result world known is 2020
                {
                    Assert.Fail();
                }
            }

           



        }
    }
}
