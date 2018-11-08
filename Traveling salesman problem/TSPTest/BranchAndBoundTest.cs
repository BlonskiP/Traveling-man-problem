using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traveling_salesman_problem;
namespace TSPTest
{
    [TestClass]
    public class BranchAndBoundTest
    {
        
        [TestMethod]
        
        public void Test1()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test1.txt");
            BranchAndBound solver = new BranchAndBound(); solver.SetVariables(testMatrix);
            solver.Solve();
            Assert.AreEqual(solver.max, 132);
        }
        [TestMethod]
        public void Test2()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test2.txt");
            BranchAndBound solver = new BranchAndBound(); solver.SetVariables(testMatrix);
            solver.Solve();
            Assert.AreEqual(solver.max, 80);
        }
        [TestMethod]
        public void Test3()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test3.txt");
            BranchAndBound solver = new BranchAndBound(); solver.SetVariables(testMatrix);
            solver.Solve();
            Assert.AreEqual(solver.max, 212);
        }
        [TestMethod]
        public void Test4()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test4.txt");
            BranchAndBound solver = new BranchAndBound(); solver.SetVariables(testMatrix);
            solver.Solve();
            Assert.AreEqual(solver.max, 264);
        }
      //  [TestMethod]
        public void Test5()
        {   
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test5.txt");
            BranchAndBound solver = new BranchAndBound(); solver.SetVariables(testMatrix);
            solver.Solve();
            Assert.AreEqual(solver.max, 269);
        }
        [TestMethod]
        public void Test8()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test8.txt");
            BranchAndBound solver = new BranchAndBound(); solver.SetVariables(testMatrix);
            solver.Solve();
           
            Assert.AreEqual(14, solver.max);
          

        }
        [TestMethod]
        public void Test9()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test9.txt");
            BranchAndBound solver = new BranchAndBound(); solver.SetVariables(testMatrix);
            solver.Solve();
            DynamicTSP dynamicSolver = new DynamicTSP(testMatrix, 0);
            dynamicSolver.Solve();
            Assert.AreEqual(dynamicSolver.minTourCost, solver.max);


        }
        [TestMethod]
        public void ManualTest()
        {
           
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("manualTest.txt");
            DynamicTSP dynamicSolver = new DynamicTSP(testMatrix, 0);
            BranchAndBound solver = new BranchAndBound(); solver.SetVariables(testMatrix);
            solver.Solve();
            dynamicSolver.Solve();
            for (int i = 0; i < solver.finalPath.Length; i++)
                Console.WriteLine(solver.finalPath[i]);
            Assert.AreEqual(dynamicSolver.minTourCost, solver.max);
          

        }
        [TestMethod]
        public void RandomTest()
        {
            for(int i = 0; i < 5; i++) {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix(8);
            BranchAndBound solver = new BranchAndBound();
            testMatrix.GenerateRandomMatrix();
            DynamicTSP dynamicSolver = new DynamicTSP(testMatrix, 0);
            dynamicSolver.SetVariables(testMatrix);
            dynamicSolver.Solve();
            solver.SetVariables(testMatrix);
            solver.Solve();
               
                  if(((int)dynamicSolver.minTourCost !=solver.max))
                      testMatrix.print();
                   Assert.AreEqual( (int) dynamicSolver.minTourCost, solver.max);
                   
            }
        }

        [TestMethod]
        public void FirstBoundTest()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix(4);
            for (int i = 0; i < 100000; i++)
            {
                
                BranchAndBound solver = new BranchAndBound();
                testMatrix.GenerateRandomMatrix();
                DynamicTSP dynamicSolver = new DynamicTSP(testMatrix, 0);
                solver.SetVariables(testMatrix);
                dynamicSolver.Solve();
                solver.Solve();
                if (dynamicSolver.minTourCost < solver.firstBound)
                {   Console.WriteLine("BestTour :" +dynamicSolver.minTourCost + "<= To bound" + solver.firstBound);
                    testMatrix.print();
                    dynamicSolver.printTour();
                    Assert.Fail();
                }
                
           
              
            }
        }

        
       
    }
}
