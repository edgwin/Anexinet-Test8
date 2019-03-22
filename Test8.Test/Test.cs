using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test8.Test
{
    [TestClass]
    public class Test
    {
        private int[,] matrix()
        {
            var matrix = new int[3, 3];
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[1, 0] = 4;
            matrix[1, 1] = 0;
            matrix[1, 2] = 6;
            matrix[2, 0] = 7;
            matrix[2, 1] = 8;
            matrix[2, 2] = 9;
            return matrix;
        }

        private int[,] expectedMatrix()
        {
            var matrix = new int[3, 3];
            matrix[0, 0] = 1;
            matrix[0, 1] = 0;
            matrix[0, 2] = 3;
            matrix[1, 0] = 0;
            matrix[1, 1] = 0;
            matrix[1, 2] = 0;
            matrix[2, 0] = 7;
            matrix[2, 1] = 0;
            matrix[2, 2] = 9;
            return matrix;
        }

        private int[,] noneexpectedMatrix()
        {
            var matrix = new int[3, 3];
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[1, 0] = 4;
            matrix[1, 1] = 5;
            matrix[1, 2] = 6;
            matrix[2, 0] = 7;
            matrix[2, 1] = 8;
            matrix[2, 2] = 9;
            return matrix;
        }

        [TestMethod]
        public void ExpectedResult()
        {
            var result = Program.processMatrix(matrix());
            var expected = expectedMatrix();
            Assert.IsTrue(result.Rank == expected.Rank &&
                            Enumerable.Range(0, result.Rank).All(dimension => expected.GetLength(dimension) == expected.GetLength(dimension)) &&
                            result.Cast<int>().SequenceEqual(expected.Cast<int>()));

        }

        [TestMethod]
        public void UnExpectedResult()
        {
            var result = Program.processMatrix(matrix());
            var expected = noneexpectedMatrix();
            Assert.IsFalse(result.Rank == expected.Rank &&
                            Enumerable.Range(0, result.Rank).All(dimension => expected.GetLength(dimension) == expected.GetLength(dimension)) &&
                            result.Cast<int>().SequenceEqual(expected.Cast<int>()));

        }
    }
}
