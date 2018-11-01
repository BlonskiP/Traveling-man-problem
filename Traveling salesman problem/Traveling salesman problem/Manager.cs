using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveling_salesman_problem
{

    static class Manager
    {
        public static bool isSolving = false;
        private static ExcelManager excel;
        public static AdjacencyMatrix _matrix;
        public static List<int> path;
        public static double cost;
        public static Stopwatch timeCounter;

        public static void MatrixGenerator(int verticles)
        {
            _matrix=new AdjacencyMatrix(verticles);
            _matrix.GenerateRandomMatrix();
        }
        public static void RunDynamic()
        {
            isSolving = true;
            path = new List<int>();
            timeCounter =new Stopwatch();
            isSolving = true;
            timeCounter.Start();
            DynamicTSP dynamic = new DynamicTSP(_matrix, 0);

            dynamic.Solve();
            timeCounter.Stop();
            path = dynamic.tour;
            
            cost = dynamic.minTourCost;
            isSolving = false;

        }

        public static void RunBranchBound()
        {
            isSolving = true;
            path = new List<int>();
            timeCounter = new Stopwatch();
            isSolving = true;
            timeCounter.Start();
            BranchAndBound brancher = new BranchAndBound();
            brancher.SetVariables(_matrix);
            brancher.Solve();
            timeCounter.Stop();
            foreach (var element in brancher.finalPath)
            {
                path.Add(element);
            }

           

            cost = brancher.max;
            isSolving = false;
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

        public static void RunBruteForce()
        {
            isSolving = true;
            timeCounter = new Stopwatch();
          
            path=new List<int>();
            timeCounter.Start();
            TspBruteForce bruteForceSolver = new TspBruteForce(_matrix);
            bruteForceSolver.Solve();
            timeCounter.Stop();
            foreach (var element in bruteForceSolver.bestPath)
            {
                path.Add(element);
            }
            path.Add(bruteForceSolver.bestPath[0]);
            path.Reverse();
            cost = bruteForceSolver.smallestCost;
            isSolving = false;
        }



        public static void stopWatchTest()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            RunDynamic();

            watch.Stop();
            Console.WriteLine("Time: " + watch.Elapsed);
            Console.WriteLine("mili " + watch.ElapsedMilliseconds);
            Console.WriteLine("ticks " + watch.ElapsedTicks);
            Console.WriteLine("sec? " + watch.ElapsedTicks / Stopwatch.Frequency);


        }

        static void testfunction()
        {
            int verticles = 15;
            _matrix = new AdjacencyMatrix(verticles);
            timeCounter timemaster = new timeCounter(100);
            DynamicTSP tester = new DynamicTSP(_matrix, 0);
            TspBruteForce brute = new TspBruteForce(_matrix);
            timemaster.measureSolver(tester, verticles);
            timemaster.measureSolver(brute, verticles);

        }

        public static void runMeasures()
        {
           
            DynamicTSP dynamic = new DynamicTSP();
            TspBruteForce brute = new TspBruteForce();
            BranchAndBound branch = new BranchAndBound();
            timeCounter timemaster = new timeCounter(100);
            excel = new ExcelManager("pomiary");
            excel.createNewFile();
            for (int i = 2; i < 15; i++)
            {
                excel.changeCell(i, 3, timemaster.measureSolver(dynamic, i+2).ToString());//dynamic
                Console.WriteLine("Dynamic END");
                excel.changeCell(i, 4, timemaster.measureSolver(branch, i+2).ToString());//branch
                Console.WriteLine("Branch&Bound done");
                ///  excel.changeCell(i, 2, timemaster.measureSolver(brute, i+2).ToString()); //brute
                ///      Console.WriteLine("BruteForce done");
            }
            excel.close();
        }

        public static void CreateMatrixFromFile(string fileName)
        {
            
            _matrix = new AdjacencyMatrix(fileName);
        }
    }
}
