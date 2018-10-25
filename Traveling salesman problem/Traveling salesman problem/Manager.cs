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
            timeCounter=new Stopwatch();
            isSolving = true;
            timeCounter.Start();
            DynamicTSP dynamic = new DynamicTSP(_matrix, 0);

            dynamic.Solve();
            timeCounter.Stop();
            path = dynamic.tour;
            
            cost = dynamic.minTourCost;
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
            timeCounter = new Stopwatch();
            isSolving = true;
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
            int verticles = 15;
            DynamicTSP tester = new DynamicTSP();
            TspBruteForce brute = new TspBruteForce();
            timeCounter timemaster = new timeCounter(2);
            excel = new ExcelManager("pomiary");
            excel.createNewFile();
            excel.changeCell(2, 2, timemaster.measureSolver(tester, 16).ToString());
            excel.changeCell(3, 2, timemaster.measureSolver(tester, 15).ToString());
            excel.changeCell(4, 2, timemaster.measureSolver(tester, 17).ToString());
            excel.changeCell(5, 2, timemaster.measureSolver(tester, 18).ToString());
            //excel.changeCell(2, 6, timemaster.measureSolver(brute, 14).ToString());
            //excel.changeCell(2, 7, timemaster.measureSolver(brute, 16).ToString());


        }

    }
}
