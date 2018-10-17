using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tsp
{
    
    class TspBruteForce
    {
        private List<List<int>> pathPermutationList;
        AdjacencyMatrix matrix;
        public TspBruteForce(AdjacencyMatrix matrix)
        {
            this.matrix = matrix;
            pathPermutationList=new List<List<int>>();

            
        }

        public void printPerm() //print permutations
        {
            Console.WriteLine("Number of Permutations: "+pathPermutationList.Count);
            Console.WriteLine("Permutation list: ");
            foreach (var permutation in pathPermutationList)
            {
                foreach ( var vertex  in permutation)
                {
                Console.Write(vertex + "");
                }
                Console.WriteLine("");
            }
            if(pathPermutationList.Count==0)
                Console.WriteLine("No permuations err");
        }

       
    }
}
