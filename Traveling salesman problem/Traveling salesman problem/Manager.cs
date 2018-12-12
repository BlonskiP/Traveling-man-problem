using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

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
        static string root = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

        public static float ErrorRate;

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

        internal static void CreateMatrixFromXMLFile(string fileName)
        {
            XDocument doc = XDocument.Load(fileName);
            
            _matrix = new AdjacencyMatrix(doc);
        }

        public static void runMeasures()
        {
           
            DynamicTSP dynamic = new DynamicTSP();
            TspBruteForce brute = new TspBruteForce();
            BranchAndBound branch = new BranchAndBound();
            timeCounter timemaster = new timeCounter(100);
            excel = new ExcelManager("pomiary");
            excel.createNewFile();
            for (int i = 2; i < 10; i++)
            {
                excel.changeCell(i, 3, timemaster.measureSolver(dynamic, i+2).ToString());//dynamic
                Console.WriteLine("Dynamic END" + i);
                excel.changeCell(i, 4, timemaster.measureSolver(branch, i+2).ToString());//branch
                Console.WriteLine("Branch&Bound done" +i);
                excel.changeCell(i, 2, timemaster.measureSolver(brute, i+2).ToString()); //brute
                Console.WriteLine("BruteForce done" + i);
            }
            excel.close();
        }

        internal static void RunTabu(int cadence, int iterations)
        {
            Console.WriteLine("Tabu" + cadence + iterations);

            isSolving = true;
            path = new List<int>();
            timeCounter = new Stopwatch();

            timeCounter.Start();

            TabuSearch tabu = new TabuSearch(_matrix, iterations, cadence);

            tabu.Solve();

            
            timeCounter.Stop();
            foreach (var element in tabu.bestSolution)
            {
                path.Add(element);
            }



            cost = tabu.lowestCost;
            isSolving = false;
        }

        internal static void runMeasuresTsSA()
        {
            string file = root + "\\ftv47.xml";
            XDocument tspFile = XDocument.Load(file);
            AdjacencyMatrix matrix = new AdjacencyMatrix(tspFile);
            TabuSearch tabu = new TabuSearch(matrix,10000,3);
            SimulatedAnnealing ann = new SimulatedAnnealing(matrix);
            excel = new ExcelManager("pomiary");
            excel.createNewFile();
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for(int k = 0; k < 10; k++)
                {
                    tabu = new TabuSearch(matrix, 1000 * i, 3);
                    tabu.Solve();
                    result += tabu.lowestCost;
                    
                }
                float final = result / 10;
                excel.changeCell(2,i+2,final.ToString());  
            }
            excel.close();
        }

        internal static void RunSimulatedAnnealing(int temperature, float cooling , int iterations, float mintemp)
        {
            Console.WriteLine("ANNELING" + temperature + " "+ cooling + " " + iterations);

            isSolving = true;
            path = new List<int>();
            timeCounter = new Stopwatch();
           
            timeCounter.Start();
          
            SimulatedAnnealing anneling = new SimulatedAnnealing(_matrix);
            string coolingToS = cooling.ToString();
            double power = Math.Pow((double)10, (double)coolingToS.Length);

            float parameter = cooling / (float)power;
            
            anneling.SetTemperature(temperature, cooling, mintemp, iterations);
            anneling.Calculate();
            timeCounter.Stop();
            foreach (var element in anneling.result)
            {
                path.Add(element);
            }



            cost = anneling.bestResult;
            isSolving = false;
        }

        public static void CreateMatrixFromFile(string fileName)
        {
            
            _matrix = new AdjacencyMatrix(fileName);
        }
    }
}
