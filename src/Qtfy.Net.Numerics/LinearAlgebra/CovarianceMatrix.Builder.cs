// <copyright file="CovarianceMatrix.Builder.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    using System;

    public sealed partial class CovarianceMatrix
    {
        /// <summary>
        /// A builder object to create a <see cref="CovarianceMatrix"/>.
        /// </summary>
        public new sealed class Builder : LinearAlgebraBuilder<CovarianceMatrix>
        {
            /// <summary>
            /// The number of rows and columns of the matrix.
            /// </summary>
            private readonly int order;

            /// <summary>
            /// Initializes a new instance of the <see cref="Builder"/> class.
            /// </summary>
            /// <param name="order">
            /// The number of rows and columns of the matrix.
            /// </param>
            /// <exception cref="LinearAlgebraException">
            /// if <paramref name="order"/> is less than zero.
            /// </exception>
            public Builder(int order)
                : base(MakeData(order))
            {
                this.order = order;
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
                    var size = this.order;
                    if (r < 0 || c < 0 || r >= size || c >= size)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    return this.Data[r * size + c];
                }

                set
                {
                    var size = this.order;
                    if (r < 0 || c < 0 || r >= size || c >= size)
                    {
                        throw new IndexOutOfRangeException();
                    }

                    this.Data[r * size + c] = value;
                    this.Data[c * size + r] = value;
                }
            }

            /// <inheritdoc/>
            private protected override CovarianceMatrix Factory(double[] data)
            {
                return new (data, this.order);
            }

            private static double[] MakeData(int order)
            {
                if (order < 1)
                {
                    throw new LinearAlgebraException("Cannot construct an empty matrix");
                }

                return new double[order * order];
            }
        }
    }
}
