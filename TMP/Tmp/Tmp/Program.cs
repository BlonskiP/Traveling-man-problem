using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMP
{
    class Program
    {
        static  AdjacencyMatrix _matrix;
        static void Main(string[] args)
        {
            Console.WriteLine("Generated Matrix is:");
            CreateMatrix(5);
            Console.ReadKey();
        }

        private static void CreateMatrix(int verticles)
        {
            _matrix = new AdjacencyMatrix(verticles);
            _matrix.GenerateRandomMatrix();
            _matrix.print();
        }

    }
}
