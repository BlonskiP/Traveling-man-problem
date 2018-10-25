using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Traveling_salesman_problem
{
    class AdjacencyMatrix
    {
        public int[,] matrix;
        public AdjacencyMatrix(int verticles)
        {
            matrix=new int[verticles,verticles];
        }
        private void correctPaths()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, i] = 0;
            }
        }
        public void GenerateRandomMatrix()
        {   //Random edges. This graph is always connected. Every Verticle is connected to each other.
            // 0 means it is free path.
            Random  numberGenerator= new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                    matrix[i, k] = numberGenerator.Next(1,9);
            }
            correctPaths();
        }

        public void print()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                    Console.Write(matrix[i,k]+" ");
                Console.WriteLine("");
            }
        }

        public void setTestMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                    matrix[i, k] = i+1;
            }
            correctPaths();
        }
        
    }
}
