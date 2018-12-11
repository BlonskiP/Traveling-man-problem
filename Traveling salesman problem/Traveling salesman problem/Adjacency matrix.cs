using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Traveling_salesman_problem
{
    public class AdjacencyMatrix
    {
        public int[,] matrix;
        public float[,] fMatrix;

        public AdjacencyMatrix(string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {

                    string[] arrStr = sr.ReadToEnd().Replace(System.Environment.NewLine, " ").Split(' ').Where(x => x != "").ToArray();
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

            catch (Exception e)
            {
                MessageBox.Show("FILE ERROR");
            }
        }
        public AdjacencyMatrix(XDocument tspFile) {

            var vertexList = tspFile.Descendants("graph").Elements("vertex").ToList();
            int size = vertexList.Count();
            fMatrix = new float[(int)size, (int)size];
            int roundNumber = Int32.Parse(tspFile.Root.Element("ignoredDigits").Value);
            int i = 0; //inumerator would be better :(
            foreach (var vertex in vertexList)
            {
                var edgeList = vertex.Elements("edge").ToList();
                foreach (var edge in edgeList)
                {
                    //Console.WriteLine((edge.Attribute("cost").Value));
                    //Console.WriteLine((edge.Value));
                    int vertexNumber = Int32.Parse(edge.Value);
                    float cost = float.Parse(edge.Attribute("cost").Value, CultureInfo.InvariantCulture);
                    System.Math.Round(cost, roundNumber);
                    fMatrix[i, vertexNumber] = cost;


                }
                i++;
            }


        }
        private void CreateMatrixFromArry(int[] arr)
        {
            int temp;
            double size = Math.Sqrt(arr.Length);
            if (size % 1 == 0)
            {
                matrix = new int[(int)size, (int)size];
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
            matrix = new int[verticles, verticles];
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
            Random numberGenerator = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                    matrix[i, k] = numberGenerator.Next(1, 9);
            }
            correctPaths();
        }

        public void print()
        {
            if (matrix != null)
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int k = 0; k < matrix.GetLength(1); k++)
                        Console.Write(matrix[i, k] + " ");
                    Console.WriteLine("");
                }
            if (fMatrix != null)
            {
                Console.WriteLine("Matrix from XML");
                for (int i = 0; i < fMatrix.GetLength(0); i++)
                {
                    for (int k = 0; k < fMatrix.GetLength(1); k++)
                        Console.Write(fMatrix[i, k] + " ");
                    Console.WriteLine("");
                }
            }
        }

        public void setTestMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                    matrix[i, k] = i + 1;
            }
            correctPaths();
        }
        public float countCost(List<int> path){
            float tourCost = 0;
            for (int i=0; i < path.Count()-1; i++)
            {
                tourCost += fMatrix[path[i], path[i+1]];
            }
            
            return tourCost;
        }
    }
}
