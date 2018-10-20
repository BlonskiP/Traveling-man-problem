using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsp;

namespace Tmp
{
    class DynamicTSP
    {
        private double[,] memo;
        private int vertexNumber;
        private AdjacencyMatrix costMatrix;
        private Int32 END_STATE;
        private int startingNode;
        private List<int> tour=new List<int>();
        public double minTourCost = Double.PositiveInfinity;
        public DynamicTSP(AdjacencyMatrix givenMatrix, int startingNode)
        {
            costMatrix = givenMatrix;
            vertexNumber = costMatrix.matrix.GetLength(0);
            int nSquare = (int)Math.Pow(2, vertexNumber);
            memo = new double[vertexNumber,nSquare];
            END_STATE = (1 << vertexNumber) - 1; //binary end state 
            this.startingNode = startingNode;
            
        }

       

        private void setup()
        {
            for (int i = 0, k=0; i < vertexNumber; i++)
            {
                if(i==startingNode) continue;
                k = ((1 << startingNode) | (1 << i));
                memo[i,k] = costMatrix.matrix[startingNode,i];
            }
            
        }

        public void printMemo()
        {
            Console.WriteLine("\n + DYNAMIC MEMORY ARRAY");
            for (int i = 0; i < memo.GetLength(0); i++)
            {
                Console.Write(i+ "  ");
                for (int k = 0; k < memo.GetLength(1); k++)
                {
                    Console.Write(memo[i,k]+ " ");
                }
                Console.WriteLine("");
            }
        }

        private List<int> Combination(int r, int n)
        {
            List<int> subsets=new List<int>();
            Combination(0, 0, r, n, subsets);
            return subsets;
        }

        private void Combination(int set, int at, int r, int n, List<int> subsets)
        {
            int elementLeftToPick = n - at;
            if (elementLeftToPick < r) return;
            if(r==0)subsets.Add(set);
            for (int i = at; i < n; i++)
            {
                set |= 1 << i;
                Combination(set, i + 1, r - 1, n, subsets);
                set &= ~(1 << i);
            }

        }
        private bool notIn(int element, int subset)
        {
            return ((1 << element) & subset) == 0;
        }
        public void Solve()
        {
            setup();


            for (int r = 3; r <= vertexNumber; r++)
            {
                foreach (var subset in Combination(r,vertexNumber))
                {
                    if(notIn(startingNode,subset))continue;
                    for (int next = 0; next < vertexNumber; next++)
                    {
                        if(next==startingNode || notIn(next,subset)) continue;
                        int subsetWithoutNext = subset ^ (1 << next);
                        double minDist=Double.PositiveInfinity;
                        for (int end = 0; end < vertexNumber; end++)
                        {
                            if (end == startingNode || end == next || notIn(end, subset)) continue;
                            double newDistance = memo[end,subsetWithoutNext] + costMatrix.matrix[end, next];
                            if (newDistance < minDist)
                            {
                                minDist = newDistance;
                            }
                            
                        }
                        memo[next, subset] = minDist;

                    }

                   
                }


                }
            //Conect tour back
            for (int i = 0; i < vertexNumber; i++)
            {
                if(i==startingNode)continue;
                double tourCost = memo[i, END_STATE] + costMatrix.matrix[i, startingNode];
                if (tourCost < minTourCost)
                {
                    minTourCost = tourCost;
                }
            }

            int lastIndex = startingNode;
            int state = END_STATE;
            tour.Add(startingNode);

            //reconstrucion
            for (int i = 1; i < vertexNumber; i++)
            {
                int index = -1;
                for (int j = 0; j < vertexNumber; j++)
                {
                    if(j==startingNode || notIn(j,state)) continue;
                    if (index == -1) index = j;
                    double prevDist = memo[index, state] + costMatrix.matrix[index, lastIndex];
                    double newDist = memo[j, state] + costMatrix.matrix[j, lastIndex];
                    if (newDist < prevDist)
                    {
                        index = j;}
                }
                tour.Add(index);
                state = state ^ (1 << index);
                lastIndex = index;
            }
            tour.Add(startingNode);
            tour.Reverse();

            



        }

        public void printTour()
        {   
            foreach (var vertex in tour)
            {
                Console.Write(vertex+"->");
            }
            
        }
    }

      
    }

