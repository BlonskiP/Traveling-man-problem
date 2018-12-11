using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveling_salesman_problem
{

    public class TabuSearch : TspSolver
    {
        TabuMap tabuMap;
        AdjacencyMatrix _matrix;
        int _maxIterations;
        int verticles;
        List<int> bestSolution;
        public float lowestCost;
        public TabuSearch(AdjacencyMatrix matrix, int iterations, int timeOfLife) {
            _matrix = matrix;
            _maxIterations = iterations;
            verticles = _matrix.fMatrix.GetLength(0);
            tabuMap = new TabuMap(timeOfLife, verticles);
        }

        public override void SetVariables(AdjacencyMatrix matrix)
        {
            throw new NotImplementedException();
        }

        public override void Solve()
        {
            List<int> curr = FindBestGreedySolution();
            bestSolution = new List<int>(curr);
            float currCost = _matrix.countCost(curr);
            lowestCost = currCost;
            
            for(int i=0; i < _maxIterations; i++)
            {
                List<int> newBestNeig = findBestNeig(curr);
                float newCost = _matrix.countCost(newBestNeig);
                curr = newBestNeig;
                currCost = newCost;
            }
            lowestCost = currCost;

        }

        private List<int> findBestNeig(List<int> curr)
        {
            List<int> neig = new List<int>(curr);
            List<List<int>> potencialNeig = new List<List<int>>();
            int verticleA;
            int verticleB;
            float bestScore = _matrix.countCost(curr);
            float currScore = bestScore;
            List<int> bestCurrNeig;
            for (int i = 1; i < verticles; i++)
            {
                for (int j = (i + 1); j < verticles; j++)
                {
                    verticleA = i;
                    verticleB = j;
                    if (!tabuMap.IsMoveTabu(verticleA, verticleB))
                    {
                        Swap<int>(neig, verticleA, verticleB);
                        currScore = _matrix.countCost(neig); 
                        if(currScore<bestScore)
                        {
                            potencialNeig.Add(neig);
                            neig = new List<int>(curr);
                        }

                    }

                }
            }

            foreach(var neigbour in potencialNeig)
            {
                float tempCost = _matrix.countCost(neigbour);
                if(tempCost < bestScore)
                {
                    bestScore = tempCost;
                    neig = new List<int>(neigbour);
                }
            }



                    return neig;
        }

        private List<int> FindBestGreedySolution()
        {
            _matrix.print();
            List<int> bestLocalSolution = new List<int>();
            bestLocalSolution.Add(0);
            for(int i=0; i<verticles;i++)
            {
                float lowestCost = float.MaxValue;
                int potencialVerticle = 0;
                for (int k = 0; k < verticles; k++)
                {
                    if (i != k && !bestLocalSolution.Contains(k))
                        if (_matrix.fMatrix[i, k] < lowestCost)
                        {
                            potencialVerticle = k;
                            lowestCost = _matrix.fMatrix[i, k];
                        }
                }
                bestLocalSolution.Add(potencialVerticle);
            }
           


            return bestLocalSolution;
        }
        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }

    }
}
