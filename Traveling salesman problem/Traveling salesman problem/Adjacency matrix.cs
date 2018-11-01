using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Traveling_salesman_problem
{
    public class AdjacencyMatrix
    {
        public int[,] matrix;

        public AdjacencyMatrix(string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {

                    string[] arrStr = sr.ReadToEnd().Replace(System.Environment.NewLine," ").Split(' ').Where(x=> x!="").ToArray();
                    double size = Math.Sqrt(arrStr.Length);
                    int[] arr = new int[arrStr.Length];

                    if (size % 1 == 0)
                    {
                        for (int i = 0; i < arr.Length; i++)
                        {
                            arr[i] = Int32.Parse(arrStr[i]);
                        }
                        CreateMatrixFromArry(arr);
                        print();
                    }
                    else
                    {
                        Console.WriteLine("BAD");
                    }



                }
            }
        
        catch(Exception e)
        {
            MessageBox.Show("FILE ERROR");
        }
        }

        private void CreateMatrixFromArry(int[] arr)
        {
            int temp;
            double size = Math.Sqrt(arr.Length);
            if (size % 1 == 0)
            {
                matrix=new int[(int)size,(int)size];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        temp = i * matrix.GetLength(0) + j;
                        matrix[i, j] = arr[temp];
                    }
                }
            }
            else
            {
                MessageBox.Show("Wrong file matrix error");
            }
        }


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
