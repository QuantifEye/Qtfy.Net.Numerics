namespace Qtfy.Net.Numerics.LinearAlgebra.Tests
{
    using NUnit.Framework;
    using Qtfy.Net.Numerics.LinearAlgebra;

    public class MatrixTests
    {
        [TestCase(1, 1)]
        [TestCase(2, 3)]
        [TestCase(2, 3)]
        public void TestDimensions(int rows, int columns)
        {
            var builder = new Matrix.Builder(rows, columns);
            var matrix = builder.BuildCopy();
            Assert.AreEqual(builder.RowCount, rows);
            Assert.AreEqual(matrix.RowCount, rows);
            Assert.AreEqual(builder.ColumnCount, columns);
            Assert.AreEqual(matrix.ColumnCount, columns);
        }

        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        public void TestEmptyMatrix(int rows, int columns)
        {
            Assert.Throws<LinearAlgebraException>(
                () => new Matrix.Builder(rows, columns));
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 2)]
        public void TestAddMatrix(int rows, int columns)
        {
            var left = MakeArray(rows, columns, 1);
            var right = MakeArray(rows, columns, 7);
            var expected = new double[rows, columns];
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    expected[i, j] = left[i, j] + right[i, j];
                }
            }

            AssertEqual(expected, Matrix.Create(left) + Matrix.Create(right));
        }

        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(2, 3)]
        [TestCase(3, 2)]
        public void TestSubtractMatrix(int rows, int columns)
        {
            var left = MakeArray(rows, columns, 1);
            var right = MakeArray(rows, columns, 7);
            var expected = new double[rows, columns];
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    expected[i, j] = left[i, j] - right[i, j];
                }
            }

            var leftMatrix = Matrix.Create(left);
            var rightMatrix = Matrix.Create(right);
            var actualMatrix = leftMatrix - rightMatrix;
            AssertEqual(expected, actualMatrix);
        }

        private static double[,] MakeArray(int r, int c, int start)
        {
            var result = new double[r, c];
            for (int i = 0; i < r; ++i)
            {
                for (int j = 0; j < c; ++j)
                {
                    result[i, j] = start;
                    ++start;
                }
            }

            return result;
        }

        private static void AssertEqual(double[,] array, IMatrix matrix)
        {
            AssertEqual(matrix, array);
        }

        private static void AssertEqual(IMatrix matrix, double[,] array)
        {
            var rows = matrix.RowCount;
            var columns = matrix.ColumnCount;
            Assert.AreEqual(rows, array.GetLength(0));
            Assert.AreEqual(columns, array.GetLength(1));
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
                    Assert.AreEqual(matrix[i, j], array[i, j]);
                }
            }
        }
    }
}
