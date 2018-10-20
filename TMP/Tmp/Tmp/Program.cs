﻿using System;
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
            //RunBruteForce();
            RunDynamic();
            Console.ReadKey();
        }

        private static void RunDynamic()
        {
            DynamicTSP dynamic=new DynamicTSP(_matrix, 0);
            dynamic.Solve();
        }

        private static void CreateMatrix(int verticles)
        {
            _matrix = new AdjacencyMatrix(verticles);
            _matrix.GenerateRandomMatrix();
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
    }
}
