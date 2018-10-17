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
        private List<int[]> pathPermutationList;
        AdjacencyMatrix adMatrix;

        public TspBruteForce(AdjacencyMatrix matrix)
        {
            adMatrix = matrix;
            pathPermutationList = new List<int[]>();


        }

        public void printPerm() //print permutations
        {
            Console.WriteLine("Number of Permutations: " + pathPermutationList.Count);
            Console.WriteLine("Permutation list: ");
            foreach (var permutation in pathPermutationList)
            {
                foreach (var vertex in permutation)
                {
                    Console.Write(vertex + "");
                }

                Console.WriteLine("");
            }

            if (pathPermutationList.Count == 0)
                Console.WriteLine("No permuations err");
        }

        public void permute(int[] path, int l, int r)
        {
            if (l == r)
            {
                int[] newPath = new int[path.Length];
                Array.Copy(path,newPath,path.Length);
                pathPermutationList.Add(newPath);

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
            
          //  printPerm();
            List <int> bestRoute= new List<int>();
            int[] tempBest=new int[vertexArray.Length];
            int smallestCost = Int32.MaxValue;
            int newCost;
            foreach (var array in pathPermutationList)
            {
                 newCost = countCost(array);
                if (newCost < smallestCost)
                {
                    tempBest = array;
                    smallestCost = newCost;
                }
            }

            cost = smallestCost;
            path = tempBest;

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
        
    }
}
    

