using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tmp;

namespace Tsp
{
    class Program
    {
        private static ExcelManager excel;
        static  AdjacencyMatrix _matrix;
        static void Main(string[] args)
        {
            Console.ReadKey();
            runMeasures();
            Console.WriteLine("Generated Matrix is:");
            CreateMatrix(10);
            
            
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
            TspBruteForce bruteforceSolver = new TspBruteForce(_matrix);
            bruteforceSolver.Solve();
           
            Console.WriteLine("Brute Force Done!");
            Console.WriteLine("Most effective path is: " + bruteforceSolver.bestPath.ToString());
            Console.WriteLine("It costs: " + bruteforceSolver.smallestCost);
            return null;
        }

        

        public static void stopWatchTest()
        {
            Stopwatch watch=new Stopwatch();
            watch.Start();
            RunDynamic();
          
            watch.Stop();
            Console.WriteLine("Time: "+watch.Elapsed);
            Console.WriteLine("mili " + watch.ElapsedMilliseconds);
            Console.WriteLine("ticks " + watch.ElapsedTicks);
            Console.WriteLine("sec? " + watch.ElapsedTicks/Stopwatch.Frequency);

            
        }

        static void testfunction()
        {
            int verticles = 15;
            _matrix=new AdjacencyMatrix(verticles);
            timeCounter timemaster=new timeCounter(100);
            DynamicTSP tester=new DynamicTSP(_matrix,0);
            TspBruteForce brute=new TspBruteForce(_matrix);
            timemaster.measureSolver(tester, verticles);
            timemaster.measureSolver(brute, verticles);

        }

        public static void runMeasures()
        {
            int verticles = 15;
            DynamicTSP tester = new DynamicTSP();
            TspBruteForce brute = new TspBruteForce();
            timeCounter timemaster = new timeCounter(2);
            excel = new ExcelManager("pomiary");
            excel.createNewFile();
            excel.changeCell(2,2, timemaster.measureSolver(tester, 16).ToString());
            excel.changeCell(3,2, timemaster.measureSolver(tester, 15).ToString());
            excel.changeCell(4,2, timemaster.measureSolver(tester, 17).ToString());
            excel.changeCell(5,2, timemaster.measureSolver(tester,18).ToString());
            //excel.changeCell(2, 6, timemaster.measureSolver(brute, 14).ToString());
            //excel.changeCell(2, 7, timemaster.measureSolver(brute, 16).ToString());
            
            
        }
        
        
    }
}
