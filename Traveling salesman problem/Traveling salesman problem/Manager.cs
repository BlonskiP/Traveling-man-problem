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
            //Dynamic
            excel.changeCell(2, 3, timemaster.measureSolver(dynamic, 4).ToString());
            excel.changeCell(3, 3, timemaster.measureSolver(dynamic, 5).ToString());
            excel.changeCell(4, 3, timemaster.measureSolver(dynamic, 6).ToString());
            excel.changeCell(5, 3, timemaster.measureSolver(dynamic, 7).ToString());
            excel.changeCell(6, 3, timemaster.measureSolver(dynamic, 8).ToString());
            excel.changeCell(7, 3, timemaster.measureSolver(dynamic, 9).ToString());
            excel.changeCell(8, 3, timemaster.measureSolver(dynamic, 10).ToString());
            excel.changeCell(9, 3, timemaster.measureSolver(dynamic, 11).ToString());
            Console.WriteLine("Dynamic END");
            // BruteForce
            //excel.changeCell(2, 2, timemaster.measureSolver(brute, 4).ToString());
            //excel.changeCell(3, 2, timemaster.measureSolver(brute, 5).ToString());
            //excel.changeCell(4, 2, timemaster.measureSolver(brute, 6).ToString());
            //excel.changeCell(5, 2, timemaster.measureSolver(brute, 7).ToString());
            //excel.changeCell(6, 2, timemaster.measureSolver(brute, 8).ToString());
            //excel.changeCell(7, 2, timemaster.measureSolver(brute, 9).ToString());
            //excel.changeCell(8, 2, timemaster.measureSolver(brute, 10).ToString());
            //excel.changeCell(9, 2, timemaster.measureSolver(brute, 11).ToString());
            Console.WriteLine("BruteForce done");
           // Branch & bound
            excel.changeCell(2, 4, timemaster.measureSolver(branch, 4).ToString());
            excel.changeCell(3, 4, timemaster.measureSolver(branch, 5).ToString());
            excel.changeCell(4, 4, timemaster.measureSolver(branch, 6).ToString());
            excel.changeCell(5, 4, timemaster.measureSolver(branch, 7).ToString());
            excel.changeCell(6, 4, timemaster.measureSolver(branch, 8).ToString());
            excel.changeCell(7, 4, timemaster.measureSolver(branch, 9).ToString());
            excel.changeCell(8, 4, timemaster.measureSolver(branch, 10).ToString());
            excel.changeCell(9, 4, timemaster.measureSolver(branch, 11).ToString());
            Console.WriteLine("Branch&Bound done");
            excel.close();
        }

        public static void CreateMatrixFromFile(string fileName)
        {
            
            _matrix = new AdjacencyMatrix(fileName);
        }
    }
}
