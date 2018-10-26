using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveling_salesman_problem
{
    class BranchAndBound : TspSolver
    {
        private int size;
        public AdjacencyMatrix matrix;
        public List<int> bestpath;
        public int cost;
        private bool[] visited;
        public int[] finalPath;
        public int max=Int32.MaxValue;
        public BranchAndBound()
        {
            
        }

        public override void SetVariables(AdjacencyMatrix matrix)
        {
           cost=Int32.MaxValue;;
          
            bestpath=new List<int>();
            this.matrix = matrix;
            size = matrix.matrix.GetLength(0);
            finalPath=new int[size+1];
            visited = new bool[size+1];
        }

        public override void Solve()
        {
            
            int curr_bound = 0;
            int[] currentPath=new int[size+1];
            for (int i = 0; i < currentPath.Length; i++)
            {
                currentPath[i] = -1;
                visited[i] = false;
            }
           
            for (int i = 0; i <size ; i++)
                curr_bound += (firstMin(i) + secondMin(i));
            
            curr_bound = ((curr_bound & 1) !=0) ? curr_bound / 2 + 1 : curr_bound / 2;
           
            visited[0] = true;
            currentPath[0] = 0;
            TSPRec(curr_bound, 0, 1, currentPath);

        }

        private void TSPRec(int curr_bound, int weight, int level, int[] currentPath)
        {
           
            if (level == size)
            {
                if (matrix.matrix[currentPath[level - 1], currentPath[0]] != 0)
                {
                    int curr_res =weight +matrix.matrix[currentPath[level - 1],currentPath[0]];
                    if (curr_res < max)
                    {
                        copyToFinal(currentPath);
                        max = curr_res;
                    }
                }
                return;
            }

            for (int i = 0; i < size; i++)
            {
                if (matrix.matrix[currentPath[level - 1], i] != 0 && visited[i] == false)
                {
                    int temp = curr_bound;
                    weight += matrix.matrix[currentPath[level - 1], i];
                    if (level == 1)
                    {
                        curr_bound -= ((firstMin(currentPath[level - 1]) + firstMin(i)) / 2);
                    }
                    else
                    {
                        curr_bound -= ((secondMin(currentPath[level - 1]) + firstMin(i)) / 2);
                    }

                    if (curr_bound + weight < max)
                    {
                        currentPath[level] = i;
                        visited[i] = true;
                        TSPRec(curr_bound,weight,level+1,currentPath);
                    }

                    weight -= matrix.matrix[currentPath[level - 1], i];
                   
                    curr_bound = temp;
                    for (int j = 0; j < size; j++)
                        visited[i] = false;
                    for (int j = 0; j < level-1; j++)
                        visited[currentPath[j]] = true;

                }
            }
        }
        void copyToFinal(int[] path)
        {
            for (int i = 0; i < size; i++)
                finalPath[i] = path[i];
            finalPath[size] = path[0];
        }

        private int firstMin(int x)
        {
            int min=Int32.MaxValue;
            for (int i = 0;i < size;i++)
            {
                if (matrix.matrix[x, i] < min && x != i)
                    min = matrix.matrix[x, i];
            }

            return min;
        }

        private int secondMin(int x)
        {
            int first = Int32.MaxValue, second = Int32.MaxValue;
            for (int i = 0; i < size; i++)
            {
                if(x==i)continue;
                if (matrix.matrix[x, i] <= first)
                {
                    second = first;
                    first = matrix.matrix[x, i];
                }
                else if (matrix.matrix[x, i] <= second && matrix.matrix[x, i] != first)
                    second = matrix.matrix[x, i];
            }

            return second;
        }
    }
}
