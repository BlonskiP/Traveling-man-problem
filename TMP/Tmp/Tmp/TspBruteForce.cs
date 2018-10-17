using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tsp
{

    class TspBruteForce
    {
        
        AdjacencyMatrix adMatrix;
        private int smallestCost;
        private int[] bestPath;
        public TspBruteForce(AdjacencyMatrix matrix)
        {
            adMatrix = matrix;
            smallestCost=Int32.MaxValue;


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

        public void solve(out int[] path, out int cost)
        {
            int[] vertexArray = new int[adMatrix.matrix.GetLength(0)];
            for (int i = 1; i <= vertexArray.Length; i++)
            {
                vertexArray[i - 1] = i;
            }
            permute(vertexArray, 0, vertexArray.Length-1);

            path = this.bestPath;
            cost = this.smallestCost;




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
               
                cost += adMatrix.matrix[ path[i + 1]-1,path[i] - 1];


            }

            cost += adMatrix.matrix[path[path.Length-1]-1, path[0]-1];
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
    

