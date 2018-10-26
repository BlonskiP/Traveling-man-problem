using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Traveling_salesman_problem
{
    class timeCounter
    {
        private double[] measureTab;
        public timeCounter(int measuresCount)
        {
            measureTab = new double[measuresCount];
        }

        public double measureSolver(TspSolver tsp,int verticles)
        {
            
            for (int i = 0; i < measureTab.Length; i++)
            {
               AdjacencyMatrix newMatrix = new AdjacencyMatrix(verticles);
               newMatrix.GenerateRandomMatrix();
                tsp.SetVariables(newMatrix);
                Stopwatch watch = new Stopwatch();
                watch.Start();
                tsp.Solve();
                watch.Stop();
                Console.WriteLine(watch.Elapsed);

                measureTab[i] = watch.ElapsedMilliseconds;



            }
          //  showMeasures();
            return Math.Round(countEndValue(), 5);

        }

        public void showMeasures()
        {
            foreach (var value in measureTab)
            {
                Console.Write(value+" ");
            }
        }

        private double countEndValue()
        {
            double endValue = 0;
            foreach (var measure in measureTab)
            {
                Math.Round(endValue += measure,5);
            }
            return endValue/measureTab.Length;
        }
    }
}
