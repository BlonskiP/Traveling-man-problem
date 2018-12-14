using System;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traveling_salesman_problem;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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

            List<float> coolingParameterList = new List<float>();
            List<float> symulationResultList = new List<float>();
            float coolingParameter = (float)0.9997;

            while (coolingParameter < 0.9998)
            {
                float result = annTest(coolingParameter, testMatrix);
                coolingParameterList.Add(coolingParameter);
                symulationResultList.Add(result);
                coolingParameter += (float)0.00001;



            }
            float bestResult = symulationResultList.Min();
            int index = symulationResultList.IndexOf(bestResult);
            float bestPara = coolingParameterList[index];


        }


        public float annTest(float cooling, AdjacencyMatrix testMatrix) {
            SimulatedAnnealing test = new SimulatedAnnealing(testMatrix);
            test.SetTemperature(10000, cooling, (float)0.1, 5000);
            float results = 0;
            for (int i = 0; i < 1000; i++)
            {
                float result = test.Calculate();
                float err = (result - 2020) / 2020;
                results += err;
            }
            float final = results / 1000;

            return final;
        }
    }
}
