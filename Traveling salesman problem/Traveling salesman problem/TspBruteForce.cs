using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Traveling_salesman_problem
{

    class TspBruteForce : TspSolver
    {
        
        AdjacencyMatrix adMatrix;
        
        public int smallestCost;
        public int[] bestPath;
        public TspBruteForce(AdjacencyMatrix matrix)
        {
            adMatrix = matrix;
            smallestCost=Int32.MaxValue;


        }

        public TspBruteForce()
        {
            smallestCost = Int32.MaxValue;
        }

        public override void SetVariables(AdjacencyMatrix matrix)
        {
            adMatrix = matrix;
       
        }
        public void permute(int[] path, int l, int r)
        {
            if (l == r)
            {
                int cost = countCost(path);
                // Debugg only
                //printPath(path);
                //Console.WriteLine( "cost" + cost);
                if (cost < smallestCost)
                {
                    int[] newPath = new int[path.Length];
                    Array.Copy(path, newPath, path.Length);
                    bestPath = newPath;
                    smallestCost = cost;
                }
            }
            else

            {
                for (int i = l; i <= r; i++)
                {
                    path=IntSwap(path, l, i);
                    permute(path,l+1,r);
                        //   path=IntSwap(path, l, i);
                }
            }
        }
        override 
        public void Solve()
        {
            int[] vertexArray = new int[adMatrix.matrix.GetLength(0)];
            for (int i = 0; i < vertexArray.Length; i++)
            {
                vertexArray[i] = i;
            }
            permute(vertexArray, 0, vertexArray.Length-1);

           



        }

        private int[] IntSwap(int[] arr, int x, int y)
        {
            int temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
            int[] newArr= new int[arr.Length];
            Array.Copy(arr,newArr,arr.Length);
            return newArr;



        }

        private int countCost(int[] path)
        {
            int cost = 0;
            for (int i = 0; i < path.Length-1; i++)
            {
               
                cost += adMatrix.matrix[ path[i + 1],path[i]];


            }

            cost += adMatrix.matrix[path[0],path[path.Length-1]];
            // Console.WriteLine("total cost:" + cost);

            return cost;
        }

        private void printPath(int[] path)
        {
            for (int i = 0; i < path.Length; i++)
            {

                Console.Write( path[i] +"");


            }

            Console.Write(path[0] + "\n");
        }
    }
}
    

