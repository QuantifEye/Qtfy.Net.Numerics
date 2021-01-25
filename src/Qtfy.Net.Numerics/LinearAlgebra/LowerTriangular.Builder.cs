// <copyright file="LowerTriangular.Builder.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    using System;

    public sealed partial class LowerTriangular
    {
        /// <summary>
        /// A builder object for <see cref="LowerTriangular"/> objects.
        /// </summary>
        public sealed class Builder : LinearAlgebraBuilder<LowerTriangular>
        {
            /// <summary>
            /// The number of rows and columns in the matrix.
            /// </summary>
            private readonly int order;

            /// <summary>
            /// Initializes a new instance of the <see cref="Builder"/> class.
            /// </summary>
            /// <param name="order">
            /// The number of rows and columns in the matrix.
            /// </param>
            public Builder(int order)
                : base(MakeData(order))
            {
                this.order = order;
            }

            /// <summary>
            /// Gets the number of rows in the matrix.
            /// </summary>
            public int RowCount
            {
                get => this.order;
            }

            /// <summary>
            /// Gets the number of columns in the matrix.
            /// </summary>
            public int ColumnCount
            {
                get => this.order;
            }

            /// <summary>
            /// Gets the value at the provided indexes.
            /// </summary>
            /// <param name="r">
            /// The index of the row.
            /// </param>
            /// <param name="c">
            /// The index of the column.
            /// </param>
            public double this[int r, int c]
            {
                get
                {
                    this.AssertValid(r, c);
                    if (c > r)
                    {
                        return 0d;
                    }
                    else
                    {
                        return this.data[Index(r, c)];
                    }
                }

                set
                {
                    this.AssertValid(r, c);
                    if (c > r)
                    {
                        throw new LinearAlgebraException();
                    }

                    this.data[Index(r, c)] = value;
                }
            }

            /// <summary>
            /// Calculates the index in the stored data that represents the entry
            /// at matrix index <paramref name="r"/>, and <paramref name="c"/>.
            /// </summary>
            /// <param name="r">
            /// The row index.
            /// </param>
            /// <param name="c">
            /// The column index.
            /// </param>
            /// <returns>
            /// The index in the stored data that represents the entry
            /// at matrix index <paramref name="r"/>, and <paramref name="c"/>.
            /// </returns>
            private static int Index(int r, int c)
            {
                return (r * (r + 1) / 2) + c;
            }

            /// <summary>
            /// Checks if the provided indexes are valid matrix indexes. Throws an excpetion if
            /// The indexs are not valid.
            /// </summary>
            /// <param name="r">
            /// The row index.
            /// </param>
            /// <param name="c">
            /// The column index.
            /// </param>
            /// <exception cref="IndexOutOfRangeException">
            /// If the provided indexes are not valid.
            /// </exception>
            private void AssertValid(int r, int c)
            {
                var size = this.order;
                if (r < 0 || c < 0 || r >= size || c > size)
                {
                    throw new IndexOutOfRangeException();
                }
            }

            /// <inheritdoc/>
            private protected override LowerTriangular Factory(double[] data)
            {
                return new (data, this.order);
            }

            private static double[] MakeData(int order)
            {
                if (order < 1)
                {
                    throw new LinearAlgebraException("Cannot construct empty matrix");
                }

                return new double[(order * (order + 1)) / 2];
            }
        }
    }
}
