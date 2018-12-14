using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveling_salesman_problem
{
    struct tour
    {   public List<int> route;
        public float fitness;
    }
    public class SimulatedAnnealing : TspSolver
    {
        float max_temperature;
        float cooling_rate;
        float min_temperature;
        int max_iterations;
        int verticles;
        public float bestResult = float.MaxValue;
        Random random;
        public List<int> result;

       public SimulatedAnnealing(AdjacencyMatrix matrix)
        {
            costMatrix = matrix;
            verticles = matrix.fMatrix.GetLength(0);
            random = new Random();
        }

        public override void SetVariables(AdjacencyMatrix matrix)
        {
            throw new NotImplementedException();
        }

        public override void Solve()
        {
            Calculate();
        }

       public void SetTemperature(float max, float rate, float min, int iterations)
        {
            max_temperature = max;
            cooling_rate = rate;
            min_temperature = min;
            max_iterations = iterations;
        }
        

        public float Calculate()
        {
            float temperature = max_temperature;
            tour current = new tour();
            tour next;
            current.route = FindBestGreedySolution();
            // Create random route
            
            current.fitness = costMatrix.countCost(current.route);
            bestResult = current.fitness;
            int iteration = 0;
            //iterations
            while(temperature > min_temperature && iteration < max_iterations)
            {
                if (current.fitness < bestResult)
                    bestResult = current.fitness;
                next = new tour();
                next.route = new List<int>();

                for(int i=0;i<current.route.Count;i++)
                {
                    next.route.Add(current.route[i]);
                }

                int verticleA, verticleB; //temp for swap
                verticleA = random.Next(0, verticles);
                do
                {
                    verticleB = random.Next(0, verticles);
                } while (verticleA == verticleB);

                Swap<int>(next.route, verticleA, verticleB);
                next.fitness = costMatrix.countCost(next.route);

                
                if(next.fitness<current.fitness)
                {
                    current = next;
                    result = new List<int>(next.route);
                }
                else if (calculateProbability(current, next, temperature))
                {
                    current = next;
                }

                temperature *= cooling_rate;
                iteration++;

            }

            return bestResult;
        }

        private bool calculateProbability(tour current, tour next, float temperature)
        {
            //int RAND_MAX = 32767;
            double prob = random.Next(0, 1000) / 1000;
            double e = Math.Exp(-1.0 * (changeInCost(next, current) / temperature));
          
            if(prob  < e)
            {
                return true; }
            else { return false; }
        }
        private float changeInCost(tour x, tour y)
        {
            return x.fitness - y.fitness;
        }
        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {   
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
        private List<int> FindBestGreedySolution()
        {

            List<int> bestLocalSolution = new List<int>();
            bestLocalSolution.Add(0);
            for (int i = 0; i < verticles; i++)
            {
                float lowestCost = float.MaxValue;
                int potencialVerticle = 0;
                for (int k = 0; k < verticles; k++)
                {
                    if (i != k && !bestLocalSolution.Contains(k))
                        if (costMatrix.fMatrix[i, k] < lowestCost)
                        {
                            potencialVerticle = k;
                            lowestCost = costMatrix.fMatrix[i, k];
                        }
                }
                bestLocalSolution.Add(potencialVerticle);
            }



            return bestLocalSolution;
        }
    }
}
