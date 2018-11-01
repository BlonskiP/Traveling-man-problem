using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traveling_salesman_problem;

namespace TSPTest
{
    [TestClass]
    public class AdjMatrixTest
    {
        [TestMethod]
        public void FileTest1()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test1.txt");
            Assert.AreNotEqual(testMatrix.matrix.Length, 0);
        }
        [TestMethod]
        public void FileTest2()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test2.txt");
            Assert.AreNotEqual(testMatrix.matrix.Length, 0);
        }
        [TestMethod]
        public void FileTest3()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test3.txt");
            Assert.AreNotEqual(testMatrix.matrix.Length, 0);
        }
        [TestMethod]
        public void FileTest4()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test4.txt");
            Assert.AreNotEqual(testMatrix.matrix.Length, 0);
        }
        [TestMethod]
        public void FileTest5()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test5.txt");
            Assert.AreNotEqual(testMatrix.matrix.Length, 0);
        }
        [TestMethod]
        public void FileTest6()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test6.txt");
            Assert.AreNotEqual(testMatrix.matrix.Length, 0);
        }
        [TestMethod]
        public void FileTest7()
        {
            AdjacencyMatrix testMatrix = new AdjacencyMatrix("test7.txt");
            Assert.AreNotEqual(0, testMatrix.matrix.Length);
        }

    }
}
