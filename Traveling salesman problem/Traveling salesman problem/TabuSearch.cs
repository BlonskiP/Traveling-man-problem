using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        List<float> costs;
        List<int> bestSolution;
        public float lowestCost;
        public TabuSearch(AdjacencyMatrix matrix, int iterations, int timeOfLife) {
            _matrix = matrix;
            _maxIterations = iterations;
            verticles = _matrix.fMatrix.GetLength(0);
            tabuMap = new TabuMap(timeOfLife, verticles);
            costs = new List<float>();
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
            int loop = 0;
            foreach (var item in curr)
                Trace.Write(item + " ");
            Trace.WriteLine("");
            costs.Add(lowestCost);
            for (int i=0; i < _maxIterations; i++)
            {
               
                List<int> newBestNeig = findBestNeig(curr);
                
                float newCost = _matrix.countCost(newBestNeig);
                costs.Add(newCost);
                if (newCost == lowestCost) //if same result5x times
                {
                    loop++;
                    curr = newBestNeig;
                }
                

                if(loop==10)
                {
                    loop = 0;
                    bestSolution = newBestNeig;
                    curr = diversification(currCost); 
                  
                    tabuMap.resetTabuMap();
                    continue;

                }
                if(lowestCost>newCost)
                {
                    lowestCost = newCost;
                }
                
                
                currCost = newCost;
                tabuMap.decreseTabuLife();
            }

            lowestCost = _matrix.countCost(bestSolution);

        }
        private List<int> randomList()
        {
            Random rnd = new Random();
            List<int> newList = new List<int>();
            newList.Add(0);
            while(newList.Count<verticles)
            {
                int newVeticle = rnd.Next(1, verticles);
                if (!newList.Contains(newVeticle))
                    newList.Add(newVeticle);

            }
            newList.Add(0);
            return newList;
        }
        private List<int> findBestNeig(List<int> curr)
        {
            List<int> neig = new List<int>(curr);
            List<List<int>> potencialNeig = new List<List<int>>();
            int verticleA;
            int verticleB;
            float bestScore = _matrix.countCost(curr);
            float currScore = bestScore;
            
            for (int i = 1; i < verticles; i++)
            {
                for (int j = (i + 1); j < verticles; j++)
                {
                    verticleA = i;
                    verticleB = j;
                    if (!tabuMap.IsMoveTabu(verticleA, verticleB) || aspiration(bestScore,verticleA,verticleB,neig))
                    {
                        Swap<int>(neig, verticleA, verticleB);
                        currScore = _matrix.countCost(neig); 
                        if(currScore<bestScore)
                        {
                           
                            potencialNeig.Add(neig);
                            tabuMap.makeMoveATabu(verticleA, verticleB);
                        }
                        neig = new List<int>(curr);

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

            createTaboMove(neig,curr);

                    return neig;
        }

        private void createTaboMove(List<int> neig, List<int> curr)
        {
           for(int i=0;i<verticles;i++)
            {
                if(neig[i]!=curr[i])
                {
                    tabuMap.makeMoveATabu(neig[i], curr[i]);
                    break;
                }
            }
        }

        private bool aspiration(float bestScore, int verticleA, int verticleB, List<int> neig)
        {
            List<int> newNeig = new List<int>(neig);
            Swap<int>(newNeig, verticleA, verticleB);
            float cost = _matrix.countCost(newNeig);
            if (cost < 0.8*bestScore) return true;
            return false;

        }
        private List<int> diversification(float cost)
        {
            List<int> newSolution = new List<int>();
            List<List<int>> solutionList = new List<List<int>>();
            solutionList.Add(randomList());
            for(int i=0;i<10;i++)
            {
                List<int> randomSolution = randomList();
                if (_matrix.countCost(randomSolution)<1.2*cost)
                {
                    solutionList.Add(randomSolution);
                }
            }
            
            float bestScore = float.MaxValue;
            foreach(var solution in solutionList)
            {
                float newCost = _matrix.countCost(solution);
                if (newCost < bestScore)
                {
                    bestScore = newCost;
                    newSolution = new List<int>(solution);
                }
            }
            return newSolution;
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
