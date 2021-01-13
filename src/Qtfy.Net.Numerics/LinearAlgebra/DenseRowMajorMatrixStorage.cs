// <copyright file="Matrix.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    public struct DenseRowMajorMatrixStorage<T> : IMatrixStorage<T, DenseRowMajorMatrixStorage<T>>
        where T : struct
    {
        internal DenseRowMajorMatrixStorage(T[] data, int rowCount, int columnCount)
        {
            this.RowCount = rowCount;
            this.ColumnCount = columnCount;
            this.Data = data;
        }

        public T[] Data { get; internal set; }

        public int RowCount { get; internal set; }

        public int ColumnCount { get; internal set; }

        public Blas.BlasLayout Layout => Blas.BlasLayout.RowMajor;

        public T this[int r, int c]
        {
            get => this.Data[this.ColumnCount * r + c];
            set => this.Data[this.ColumnCount * r + c] = value;
        }

        public DenseRowMajorMatrixStorage<T> Copy()
        {
            return new DenseRowMajorMatrixStorage<T>((T[])this.Data.Clone(), this.RowCount, this.ColumnCount);
        }

        public void Init(int r, int c)
        {
            this.RowCount = r;
            this.ColumnCount = c;
            this.Data = new T[r * c];
        }
    }
}

