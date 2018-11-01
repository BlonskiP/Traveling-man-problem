using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traveling_salesman_problem;

namespace TSPTest
{
    [TestClass]
    public class DynamicTest
    {
        [TestMethod]
        public void Test1()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test1.txt");
            DynamicTSP solver = new DynamicTSP(testMatrix, 0);
            solver.Solve();
            Assert.AreEqual(solver.minTourCost, 132);
        }
        [TestMethod]
        public void Test2()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test2.txt");
            DynamicTSP solver = new DynamicTSP(testMatrix, 0);
            solver.Solve();
            Assert.AreEqual(solver.minTourCost, 80);
        }
        [TestMethod]
        public void Test3()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test3.txt");
            DynamicTSP solver = new DynamicTSP(testMatrix, 0);
            solver.Solve();
            Assert.AreEqual(solver.minTourCost, 212);
        }
        [TestMethod]
        public void Test4()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test4.txt");
            DynamicTSP solver = new DynamicTSP(testMatrix, 0);
            solver.Solve();
            Assert.AreEqual(solver.minTourCost, 264);
        }
        [TestMethod]
        public void Test5()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test5.txt");
            DynamicTSP solver = new DynamicTSP(testMatrix, 0);
            solver.Solve();
            Assert.AreEqual(solver.minTourCost, 269);
        }
        [TestMethod]
        public void Test6()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test6.txt");
            DynamicTSP solver = new DynamicTSP(testMatrix, 0);
            solver.Solve();
            Assert.AreEqual(solver.minTourCost, 39);
        }
        [TestMethod]
        public void Test7()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test7.txt");
            DynamicTSP solver = new DynamicTSP(testMatrix, 0);
            solver.Solve();
            Assert.AreEqual(solver.minTourCost, 291);
        }

    }
}
