﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Traveling_salesman_problem
{
    class timeCounter
    {
        private long[] measureTab;
        public timeCounter(int measuresCount)
        {
            measureTab = new long[measuresCount];
        }

        public long measureSolver(TspSolver tsp,int verticles)
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
                Console.WriteLine(watch.ElapsedMilliseconds);
                measureTab[i] = watch.ElapsedMilliseconds;
               
                

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

        private long countEndValue()
        {
            long endValue = 0;
            foreach (var measure in measureTab)
            {
                endValue += measure;
            }
            return endValue/measureTab.Length;
        }
    }
}