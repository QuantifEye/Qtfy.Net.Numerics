// <copyright file="Matrix.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    using System;

    public partial class Matrix : IMatrix
    {
        /// <summary>
        /// The data of the matrix in row major format.
        /// </summary>
        private readonly double[] data;

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="data">
        /// The data to construct the matrix with.
        /// </param>
        /// <param name="rows">
        /// The number of rows in the matrix.
        /// </param>
        /// <param name="columns">
        /// the number of columns in the matrix.
        /// </param>
        /// <exception cref="LinearAlgebraException">
        /// If rows * columns != data.Length.
        /// </exception>
        private protected Matrix(double[] data, int rows, int columns)
        {
            if (rows < 1 || columns < 1 || rows * columns != data.Length)
            {
                throw new LinearAlgebraException();
            }

            this.data = data;
            this.RowCount = rows;
            this.ColumnCount = columns;
        }

        /// <inheritdoc />
        public int RowCount { get; }

        /// <inheritdoc />
        public int ColumnCount { get; }

        /// <inheritdoc />
        public double this[int r, int c]
        {
            get
            {
                if (r < 0 || c < 0 || r >= this.RowCount || c >= this.ColumnCount)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.data[(r * this.ColumnCount) + c];
            }
        }

        /// <summary>
        /// Adds <paramref name="left"/> to <paramref name="right"/>.
        /// </summary>
        /// <param name="left">
        /// The left matrix.
        /// </param>
        /// <param name="right">
        /// The right matrix.
        /// </param>
        /// <returns>
        /// A new matrix that is the sum of the provided matrices.
        /// </returns>
        /// <exception cref="LinearAlgebraException">
        /// If the provided matrices do not have the same dimensions.
        /// </exception>
        public static Matrix operator +(Matrix left, Matrix right)
        {
            var rows = left.RowCount;
            var columns = left.ColumnCount;
            if (rows != right.RowCount || columns != right.ColumnCount)
            {
                throw new LinearAlgebraException();
            }

            return new (ArrayMath.Add(left.data, right.data), rows, columns);
        }

        /// <summary>
        /// Adds a scaler to each element in a matrix.
        /// </summary>
        /// <param name="matrix">
        /// A <see cref="Matrix"/>.
        /// </param>
        /// <param name="scalar">
        /// A scaler.
        /// </param>
        /// <returns>
        /// A new matrix that is the result of adding a scalar to each element in <paramref name="matrix"/>.
        /// </returns>
        public static Matrix operator +(Matrix matrix, double scalar)
        {
            return new (ArrayMath.Add(matrix.data, scalar), matrix.RowCount, matrix.ColumnCount);
        }

        /// <summary>
        /// Adds a scaler to each element in a matrix.
        /// </summary>
        /// <param name="scalar">
        /// A scaler.
        /// </param>
        /// <param name="matrix">
        /// A <see cref="Matrix"/>.
        /// </param>
        /// <returns>
        /// A new matrix that is the result of adding a scalar to each element in <paramref name="matrix"/>.
        /// </returns>
        public static Matrix operator +(double scalar, Matrix matrix)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Subtracts each element in <paramref name="right"/> from each element in <paramref name="left"/>.
        /// </summary>
        /// <param name="left">
        /// The value to subtract from.
        /// </param>
        /// <param name="right">
        /// The value to subtract.
        /// </param>
        /// <returns>
        /// A new matrix where each element in <paramref name="right"/>
        /// has been subtracted from each element in <paramref name="left."/>.
        /// </returns>
        /// <exception cref="LinearAlgebraException">
        /// If the matrices do not have the same dimensions.
        /// </exception>
        public static Matrix operator -(Matrix left, Matrix right)
        {
            if (left.RowCount != right.RowCount || left.ColumnCount != right.ColumnCount)
            {
                throw new LinearAlgebraException();
            }

            return new Matrix(ArrayMath.Subtract(left.data, right.data), left.RowCount, left.ColumnCount);
        }

        /// <summary>
        /// Subtracts <paramref name="right"/> from each element in <paramref name="left"/>.
        /// </summary>
        /// <param name="left">
        /// The value to subtract from.
        /// </param>
        /// <param name="right">
        /// The value to subtract.
        /// </param>
        /// <returns>
        /// A new matrix where <paramref name="right "/> has been subtracted from each element in
        /// <paramref name="left"/>.
        /// </returns>
        public static Matrix operator -(Matrix left, double right)
        {
            return new (ArrayMath.Subtract(left.data, right), left.RowCount, left.ColumnCount);
        }

        /// <summary>
        /// Multiplies each element in <paramref name="matrix"/> by <paramref name="scalar"/>.
        /// </summary>
        /// <param name="matrix">
        /// The matrix to multiply.
        /// </param>
        /// <param name="scalar">
        /// The scalar to multiply matrix with.
        /// </param>
        /// <returns>
        /// A new matrix where each element in <paramref name="matrix"/> has been multiplied with
        /// <paramref name="scalar"/>.
        /// </returns>
        public static Matrix operator *(Matrix matrix, double scalar)
        {
            return new (ArrayMath.Multiply(matrix.data, scalar), matrix.RowCount, matrix.ColumnCount);
        }

        /// <summary>
        /// Multiplies each element in <paramref name="matrix"/> by <paramref name="scalar"/>.
        /// </summary>
        /// <param name="scalar">
        /// The scalar to multiply matrix with.
        /// </param>
        /// <param name="matrix">
        /// The matrix to multiply.
        /// </param>
        /// <returns>
        /// A new matrix where each element in <paramref name="matrix"/> has been multiplied with
        /// <paramref name="scalar"/>.
        /// </returns>
        public static Matrix operator *(double scalar, Matrix matrix)
        {
            return matrix * scalar;
        }

        /// <summary>
        /// Calculates the product of <paramref name="matrix"/> and <paramref name="vector"/>.
        /// </summary>
        /// <param name="matrix">
        /// The matrix to multiply.
        /// </param>
        /// <param name="vector">
        /// The vector to multiply.
        /// </param>
        /// <returns>
        /// A new vector that is the product of <paramref name="matrix"/> and <paramref name="vector"/>.
        /// </returns>
        /// <exception cref="LinearAlgebraException">
        /// If the number fo columns in <paramref name="matrix"/> is not equal to the number of elements in
        /// <paramref name="vector"/>.
        /// </exception>
        public static Vector operator *(Matrix matrix, Vector vector)
        {
            var rows = matrix.RowCount;
            var columns = matrix.ColumnCount;
            var vData = vector.Data;
            var vLength = vData.Length;
            if (columns != vLength)
            {
                throw new LinearAlgebraException();
            }

            var result = new double[rows];
            unsafe
            {
                fixed (double* mPin = matrix.data, vPin = vData, rPin = result)
                {
                    MatrixVectorProductImpl(mPin, vPin, vPin + vLength, rPin, rPin + columns);
                }
            }

            return new Vector(result);
        }

        /// <summary>
        /// Calculates the product of <paramref name="vector"/> and <paramref name="matrix"/>.
        /// </summary>
        /// <param name="vector">
        /// The vector to multiply.
        /// </param>
        /// <param name="matrix">
        /// The matrix to multiply.
        /// </param>
        /// <returns>
        /// A new vector that is the product of <paramref name="vector"/> and <paramref name="matrix"/>.
        /// </returns>
        /// <exception cref="LinearAlgebraException">
        /// If the number fo rows in <paramref name="matrix"/> is not equal to the number of elements in
        /// <paramref name="vector"/>.
        /// </exception>
        public static Vector operator *(Vector vector, Matrix matrix)
        {
            var rows = matrix.RowCount;
            var columns = matrix.ColumnCount;
            var vData = vector.Data;
            var vLength = vData.Length;
            if (vLength != rows)
            {
                throw new LinearAlgebraException();
            }

            var result = new double[rows];
            unsafe
            {
                fixed (double* mPin = matrix.data, vPin = vData, rPin = result)
                {
                    VectorMatrixProductImpl(mPin, columns, vPin, vPin + vLength, rPin, rPin + columns);
                }
            }

            return new Vector(result);
        }

        /// <summary>
        /// Calculates the product of <paramref name="left"/> and <paramref name="right"/>.
        /// </summary>
        /// <param name="left">
        /// The left matrix to multiply.
        /// </param>
        /// <param name="right">
        /// Teh right matrix to multiply.
        /// </param>
        /// <returns>
        /// A new matrix that is the product of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <exception cref="LinearAlgebraException">
        /// If the number of columns in <paramref name="left"/> does not equal the number of rows in
        /// <paramref name="right"/>.
        /// </exception>
        public static Matrix operator *(Matrix left, Matrix right)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a new <see cref="Matrix"/> from the provided two dimensional array by making a copy of the data..
        /// </summary>
        /// <param name="array">
        /// The array to create matrix from.
        /// </param>
        /// <returns>
        /// A new matrix with corresponding entries to <paramref name="array"/>.
        /// </returns>
        /// <exception cref="LinearAlgebraException">
        /// If the <paramref name="array"/> is empty, or if any of the lower bound values
        /// of the provided array is not zero. (That is if the provided array is not zero index in all dimensions.).
        /// </exception>
        public static Matrix Create(double[,] array)
        {
            if (array.GetLowerBound(0) != 0 || array.GetLowerBound(1) != 0)
            {
                throw new ArgumentException();
            }

            var rows = array.GetLength(0);
            var columns = array.GetLength(1);
            if (rows < 1 || columns < 1)
            {
                throw new ArgumentException("Array must not be empty.");
            }

            var data = new double[rows * columns];
            int index = 0;
            foreach (var value in array)
            {
                data[index] = value;
                ++index;
            }

            return new Matrix(data, rows, columns);
        }

        /// <summary>
        /// Calculates <paramref name="leftAndRight"/> * <paramref name="middle"/> * <paramref name="leftAndRight"/>,
        /// in a single step.
        /// </summary>
        /// <param name="leftAndRight">
        /// The vector to left and right multiply with.
        /// </param>
        /// <param name="middle">
        /// A matrix.
        /// </param>
        /// <returns>
        /// A double that is the result of calculating
        /// <paramref name="leftAndRight"/> * <paramref name="middle"/> * <paramref name="leftAndRight"/>.
        /// </returns>
        /// <exception cref="LinearAlgebraException">
        /// if <paramref name="middle"/> is not a square matrix, or if the number of elements in
        /// <paramref name="leftAndRight"/> is not equal to the number of rows or columns in <paramref name="middle"/>.
        /// </exception>
        public static double FusedProduct(Vector leftAndRight, Matrix middle)
        {
            unsafe
            {
                var vData = leftAndRight.Data;
                var vLength = vData.Length;
                var rows = middle.RowCount;

                if (rows != middle.ColumnCount || rows != vLength)
                {
                    throw new LinearAlgebraException();
                }

                fixed (double* lPin = vData, mPin = middle.data)
                {
                    return FusedVectorMatrixVectorProductImpl(
                        lPin,
                        lPin + vLength,
                        mPin);
                }
            }
        }

        /// <summary>
        /// Calculates <paramref name="left"/> * <paramref name="middle"/> * <paramref name="right"/>,
        /// in a single step.
        /// </summary>
        /// <param name="left">
        /// The vector to left multiply with.
        /// </param>
        /// <param name="middle">
        /// A matrix.
        /// </param>
        /// <param name="right">
        /// The vector to right multiply with.
        /// </param>
        /// <returns>
        /// A double that is the result of calculating
        /// <paramref name="left"/> * <paramref name="middle"/> * <paramref name="right"/>.
        /// </returns>
        /// <exception cref="LinearAlgebraException">
        /// If the number of elements in left does not equal the number of rows in <paramref name="middle"/>, or if the
        /// number of elements in right does not equal the number of columns in <paramref name="middle"/>.
        /// </exception>
        public static double FusedProduct(Vector left, Matrix middle, Vector right)
        {
            unsafe
            {
                var lData = left.Data;
                var rData = right.Data;
                var lLength = lData.Length;
                var rLength = rData.Length;

                if (middle.RowCount != lLength || middle.ColumnCount != rLength)
                {
                    throw new LinearAlgebraException();
                }

                fixed (double* lPin = lData, mPin = middle.data, rPin = rData)
                {
                    return FusedVectorMatrixVectorProductImpl(
                        lPin,
                        lPin + lLength,
                        mPin,
                        rPin,
                        rPin + rLength);
                }
            }
        }
    }
}
