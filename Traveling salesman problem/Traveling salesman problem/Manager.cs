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
           // _matrix.print();
        }
        private static void CreateTestMatrix(int verticles)
        {
            _matrix = new AdjacencyMatrix(verticles);
            _matrix.setTestMatrix();
          //  _matrix.print();
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

        internal static void RunTabu(int cadence, int iterations, string text, bool @checked)
        {
            Console.WriteLine("Tabu" + cadence + iterations);

            isSolving = true;
            path = new List<int>();
            timeCounter = new Stopwatch();

            timeCounter.Start();

            TabuSearch tabu = new TabuSearch(_matrix, iterations, cadence);
            tabu.neigState = text;
            tabu.diversificationState = @checked;
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
            // ftv4 ver
            string file;
            file = root + "\\ftv47.xml";
            XDocument tspFile = XDocument.Load(file);
            AdjacencyMatrix matrix = new AdjacencyMatrix(tspFile);
            TabuSearch tabu = new TabuSearch(matrix,10000,3);
            SimulatedAnnealing ann = new SimulatedAnnealing(matrix);
            excel = new ExcelManager("pomiary");
            excel.createNewFile();
            Console.WriteLine("frv4 ver");
            #region

            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    tabu = new TabuSearch(matrix, 1000 * i, 3);
                    tabu.diversificationState = true;
                    tabu.neigState = "or2";
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(2, i + 2, final.ToString());
            }


            // ftv170 ver
            Console.WriteLine("frv170 ver");
            file = root + "\\ftv170.xml";
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            tabu = new TabuSearch(matrix, 10000, 3);
           
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    tabu = new TabuSearch(matrix, 1000 * i, 3);
                    tabu.diversificationState = true;
                    tabu.neigState = "or2";
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(3, i + 2, final.ToString());
            }


            // rbg403 ver
            Console.WriteLine("rbg403 or2 ver");
            file = root + "\\rbg403.xml";
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            tabu = new TabuSearch(matrix, 10000, 3);
            
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    tabu = new TabuSearch(matrix, 1000 * i, 3);
                    tabu.diversificationState = true;
                    tabu.neigState = "or2";
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(4, i + 2, final.ToString());
            }


            ///////////////////////3or////////////////////////////
            file = root + "\\ftv47.xml";
            Console.WriteLine("ftv47 3or ver");
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    tabu = new TabuSearch(matrix, 1000 * i, 3);
                    tabu.diversificationState = true;
                    tabu.neigState = "or3";
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(5, i + 2, final.ToString());
            }
           


            // ftv170 ver
            file = root + "\\ftv170.xml";
            Console.WriteLine("ftv170 3or ver");
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            tabu = new TabuSearch(matrix, 10000, 3);
            
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    tabu = new TabuSearch(matrix, 1000 * i, 3);
                    tabu.diversificationState = true;
                    tabu.neigState = "or3";
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(6, i + 2, final.ToString());
            }


            // rbg403 ver
            file = root + "\\rbg403.xml";
            Console.WriteLine("rbg403 3or ver");
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            tabu = new TabuSearch(matrix, 10000, 3);
           
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    tabu = new TabuSearch(matrix, 1000 * i, 3);
                    tabu.diversificationState = true;
                    tabu.neigState = "or3";
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(7, i + 2, final.ToString());
            }

            ///// switch1//////////////////////////
            ///
            Console.WriteLine("rbg403 switch1 ver");
            file = root + "\\ftv47.xml";
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    tabu = new TabuSearch(matrix, 1000 * i, 3);
                    tabu.diversificationState = true;
                    tabu.neigState = "switch1";
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(8, i + 2, final.ToString());
            }


            // ftv170 ver
            Console.WriteLine("ftv170 switch1 ver");
            file = root + "\\ftv170.xml";
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            tabu = new TabuSearch(matrix, 10000, 3);
            
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    tabu = new TabuSearch(matrix, 1000 * i, 3);
                    tabu.diversificationState = true;
                    tabu.neigState = "switch1";
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(9, i + 2, final.ToString());
            }


            // rbg403 ver
            Console.WriteLine("rbg403 switch1 ver");
            file = root + "\\rbg403.xml";
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            tabu = new TabuSearch(matrix, 10000, 3);
          
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    tabu = new TabuSearch(matrix, 1000 * i, 3);
                    tabu.diversificationState = true;
                    tabu.neigState = "switch1";
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(10, i + 2, final.ToString());
            }
            #endregion
            #region
            ////////////////// NO DIVERSIFICATION ////////////////
            ///
            file = root + "\\ftv47.xml";
            Console.WriteLine("ftv47 or2 no");
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    tabu = new TabuSearch(matrix, 1000 * i, 3);
                    tabu.diversificationState = false;
                    tabu.neigState = "or2";
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(11, i + 2, final.ToString());
            }
           

            // ftv170 no
            file = root + "\\ftv170.xml";
            Console.WriteLine("ftv170 or2 no");
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            tabu = new TabuSearch(matrix, 10000, 3);
          
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    tabu = new TabuSearch(matrix, 1000 * i, 3);
                    tabu.diversificationState = false;
                    tabu.neigState = "or2";
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(12, i + 2, final.ToString());
            }


            // rbg403 ver
            file = root + "\\rbg403.xml";
            Console.WriteLine("rbg403 or2 no");
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            tabu = new TabuSearch(matrix, 10000, 3);
           
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    tabu = new TabuSearch(matrix, 1000 * i, 3);
                    tabu.diversificationState = false;
                    tabu.neigState = "or2";
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(13, i + 2, final.ToString());
            }


            ///////////////////////3or////////////////////////////
            file = root + "\\ftv47.xml";
            Console.WriteLine("ftv47 or3 no");
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    tabu = new TabuSearch(matrix, 1000 * i, 3);
                    tabu.diversificationState = false;
                    tabu.neigState = "or3";
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(14, i + 2, final.ToString());
            }


            // ftv170 ver
            Console.WriteLine("ftv170 or3 no");
            file = root + "\\ftv170.xml";
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            tabu = new TabuSearch(matrix, 10000, 3);
           
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    tabu = new TabuSearch(matrix, 1000 * i, 3);
                    tabu.diversificationState = false;
                    tabu.neigState = "or3";
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(15, i + 2, final.ToString());
            }


            // rbg403 ver
            Console.WriteLine("rbg403 or3 no");
            file = root + "\\rbg403.xml";
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            tabu = new TabuSearch(matrix, 10000, 3);
           
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    tabu = new TabuSearch(matrix, 1000 * i, 3);
                    tabu.diversificationState = false;
                    tabu.neigState = "or3";
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(16, i + 2, final.ToString());
            }

            ///// switch1//////////////////////////
            file = root + "\\ftv47.xml";
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    tabu = new TabuSearch(matrix, 1000 * i, 3);
                    tabu.diversificationState = false;
                    tabu.neigState = "switch1";
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(17, i + 2, final.ToString());
            }


            // ftv170 ver
            Console.WriteLine("ftv170 switch1 no");
            file = root + "\\ftv170.xml";
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            tabu = new TabuSearch(matrix, 10000, 3);
           
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    tabu = new TabuSearch(matrix, 1000 * i, 3);
                    tabu.diversificationState = false;
                    tabu.neigState = "switch1";
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(18, i + 2, final.ToString());
            }


            // rbg403 ver
            Console.WriteLine("rbg403 switch1 no");
            file = root + "\\rbg403.xml";
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            tabu = new TabuSearch(matrix, 10000, 3);
           
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    tabu = new TabuSearch(matrix, 1000 * i, 3);
                    tabu.diversificationState =false;
                    tabu.neigState = "switch1";
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(19, i + 2, final.ToString());
            }
            #endregion
            #region
            Console.WriteLine("ftv47 sa 0.9996");
            file = root + "\\ftv47.xml";
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    ann = new SimulatedAnnealing(matrix);

                    ann.SetTemperature(5000, (float)0.9996, (float)0.1, i * 1000);
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(20, i + 2, final.ToString());
            }

            file = root + "\\ftv170.xml";
            Console.WriteLine("ftv170 sa 0.9996");
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    ann = new SimulatedAnnealing(matrix);

                    ann.SetTemperature(5000, (float)0.9996, (float)0.1, i * 1000);
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(21, i + 2, final.ToString());
            }

            file = root + "\\rbg403.xml";
            Console.WriteLine("rbg403 sa 0.9996");
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    ann = new SimulatedAnnealing(matrix);

                    ann.SetTemperature(5000, (float)0.9996, (float)0.1, i * 1000);
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(22, i + 2, final.ToString());
            }
            #endregion
            #region 0.9997
            file = root + "\\ftv47.xml";
            Console.WriteLine("ftv47 sa 0.9997");
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    ann = new SimulatedAnnealing(matrix);

                    ann.SetTemperature(5000, (float)0.9997, (float)0.1, i * 1000);
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(23, i + 2, final.ToString());
            }

            file = root + "\\ftv170.xml";
            Console.WriteLine("ftv170 sa 0.9997");
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    ann = new SimulatedAnnealing(matrix);

                    ann.SetTemperature(5000, (float)0.9997, (float)0.1, i * 1000);
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(24, i + 2, final.ToString());
            }

            file = root + "\\rbg403.xml";
            Console.WriteLine("rgb403 sa 0.9997");
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    ann = new SimulatedAnnealing(matrix);

                    ann.SetTemperature(5000, (float)0.9997, (float)0.1, i * 1000);
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(25, i + 2, final.ToString());
            }
            #endregion
            #region 0.9997
            file = root + "\\ftv47.xml";
            Console.WriteLine("ftv47 sa 0.9998");
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    ann = new SimulatedAnnealing(matrix);

                    ann.SetTemperature(5000, (float)0.9998, (float)0.1, i * 1000);
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(26, i + 2, final.ToString());
            }

            file = root + "\\ftv170.xml";
            tspFile = XDocument.Load(file);
            Console.WriteLine("ftv170 sa 0.9998");
            matrix = new AdjacencyMatrix(tspFile);
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    ann = new SimulatedAnnealing(matrix);

                    ann.SetTemperature(5000, (float)0.9998, (float)0.1, i * 1000);
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(27, i + 2, final.ToString());
            }

            file = root + "\\rbg403.xml";
            Console.WriteLine("rbg403 sa 0.9998");
            tspFile = XDocument.Load(file);
            matrix = new AdjacencyMatrix(tspFile);
            for (int i = 1; i < 4; i++)
            {
                float result = 0;
                for (int k = 0; k < 10; k++)
                {
                    ann = new SimulatedAnnealing(matrix);

                    ann.SetTemperature(5000, (float)0.9998, (float)0.1, i * 1000);
                    tabu.Solve();
                    result += tabu.lowestCost;

                }
                float final = result / 10;
                excel.changeCell(28, i + 2, final.ToString());
            }
            excel.close();
            #endregion
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
