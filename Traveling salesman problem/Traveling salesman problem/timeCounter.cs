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
        private TimeSpan[] measureTab;
        public timeCounter(int measuresCount)
        {
            measureTab = new TimeSpan[measuresCount];
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

                measureTab[i] = watch.Elapsed;



            }
          //  showMeasures();
            return countEndValue();

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
            TimeSpan endValue = new TimeSpan();

            foreach (var measure in measureTab)
            {
                endValue += measure;
            }
            double result= (double)endValue.Ticks / measureTab.Length;
            Console.WriteLine("Result:" +result);
            return result;
        }
    }
}
