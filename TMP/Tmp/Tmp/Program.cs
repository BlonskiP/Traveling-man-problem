using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmp;

namespace Tsp
{
    class Program
    {
        static  AdjacencyMatrix _matrix;
        static void Main(string[] args)
        {
            Console.WriteLine("Generated Matrix is:");
           CreateMatrix(3);
           // CreateTestMatrix(3);
          
          //  RunBruteForce();
            //RunDynamic();
           if(runTest())Console.WriteLine("Dziala");
            else Console.WriteLine("Dupa");
            Console.ReadKey();
        }

        private static void RunDynamic()
        {
            
                DynamicTSP dynamic = new DynamicTSP(_matrix, 0);
                dynamic.Solve();
                Console.WriteLine("Dynamic Done!");
                Console.WriteLine("Most effective path is: ");
                dynamic.printTour();
                Console.WriteLine("It costs: " + dynamic.minTourCost);
                

        }

        private static void CreateMatrix(int verticles)
        {
            _matrix = new AdjacencyMatrix(verticles);
            _matrix.GenerateRandomMatrix();
            _matrix.print();
        }
        private static void CreateTestMatrix(int verticles)
        {
            _matrix = new AdjacencyMatrix(verticles);
            _matrix.setTestMatrix();
            _matrix.print();
        }

        private static List<int> RunBruteForce()
        {
            TspBruteForce bruteforceSolver=new TspBruteForce(_matrix);
            int[] path;
            int smallestCost;
            bruteforceSolver.solve(out path, out smallestCost);
           
            Console.WriteLine("Brute Force Done!");
            Console.WriteLine("Most effective path is: " + String.Join(" ",path)+" "+path[0].ToString());
            Console.WriteLine("It costs: " + smallestCost);
            return null;
        }

        private static bool runTest()
        {
            int[] output;
            int cost2;
            for (int i = 0; i < 10000; i++)
            {
                AdjacencyMatrix testMatrix = new AdjacencyMatrix(5);
                DynamicTSP testObject = new DynamicTSP(testMatrix, 0);
                TspBruteForce testObject2 = new TspBruteForce(testMatrix);
                testObject2.solve(out output, out cost2);
                testObject.Solve();
                if (cost2 != testObject.minTourCost)
                    return false;
            }

            return true;
        }
    }
}
