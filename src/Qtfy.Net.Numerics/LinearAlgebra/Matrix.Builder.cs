// <copyright file="Matrix.Builder.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    public partial class Matrix
    {
        /// <summary>
        /// A builder object to create <see cref="Matrix"/>s with.
        /// </summary>
        public sealed class Builder : LinearAlgebraBuilder<Matrix>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Builder"/> class.
            /// </summary>
            /// <param name="rowCount">
            /// The number of rows in the matrix.
            /// </param>
            /// <param name="columnCount">
            /// The number of columns in the matrix.
            /// </param>
            public Builder(int rowCount, int columnCount)
                : base(MakeData(rowCount, columnCount))
            {
                this.RowCount = rowCount;
                this.ColumnCount = columnCount;
            }

            /// <summary>
            /// Gets the number of rows in the matrix.
            /// </summary>
            public int RowCount { get; }

            /// <summary>
            /// Gets the number of columns in the matrix.
            /// </summary>
            public int ColumnCount { get; }

            /// <summary>
            /// Gets the value at the provided indexes.
            /// </summary>
            /// <param name="i">
            /// The index of the row.
            /// </param>
            /// <param name="j">
            /// The index of the column.
            /// </param>
            public double this[int i, int j]
            {
                get => this.Data[this.Index(i, j)];
                set => this.Data[this.Index(i, j)] = value;
            }

            /// <inheritdoc/>
            private protected override Matrix Factory(double[] data)
            {
                return new (this.Data, this.RowCount, this.ColumnCount);
            }

            private static double[] MakeData(int rowCount, int columnCount)
            {
                if (rowCount < 1 || columnCount < 1)
                {
                    throw new LinearAlgebraException("Cannot construct empty matrix");
                }

                return new double[rowCount * columnCount];
            }

            private int Index(int i, int j)
            {
                if (i < 0 || j < 0 || i >= this.RowCount || j >= this.ColumnCount)
                {
                    throw new LinearAlgebraException();
                }

                return i * this.ColumnCount + j;
            }
        }
    }
}
