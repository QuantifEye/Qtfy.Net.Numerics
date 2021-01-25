// <copyright file="LowerTriangular.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    using System;

    /// <summary>
    /// A matrix with only lower triangular entries (including diagonal), with all other entries being zero.
    /// Only the non zero entries are stored.
    /// </summary>
    public sealed partial class LowerTriangular : IMatrix
    {
        /// <summary>
        /// The data in packed row major format.
        /// </summary>
        private readonly double[] data;

        /// <summary>
        /// The number of rows and columns.
        /// </summary>
        private readonly int order;

        /// <summary>
        /// Initializes a new instance of the <see cref="LowerTriangular"/> class.
        /// </summary>
        /// <param name="data">
        /// The data as packed row major storage layout.
        /// </param>
        /// <param name="order">
        /// The number of rows and columns.
        /// </param>
        private LowerTriangular(double[] data, int order)
        {
            this.data = data;
            this.order = order;
        }

        /// <inheritdoc />
        public int RowCount
        {
            get => this.order;
        }

        /// <inheritdoc />
        public int ColumnCount
        {
            get => this.order;
        }

        /// <inheritdoc />
        public double this[int r, int c]
        {
            get
            {
                if (r < 0 || c < 0 || r >= this.order || c >= this.order)
                {
                    throw new IndexOutOfRangeException();
                }

                return this.data[((r * (r + 1)) / 2) + c];
            }
        }
    }
}
