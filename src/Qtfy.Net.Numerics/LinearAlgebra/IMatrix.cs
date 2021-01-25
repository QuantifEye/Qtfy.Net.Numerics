// <copyright file="IMatrix.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    /// <summary>
    /// The interface for all linear algebra matrices.
    /// </summary>
    public interface IMatrix
    {
        /// <summary>
        /// Gets the number of rows in the matrix.
        /// </summary>
        int RowCount { get; }

        /// <summary>
        /// Gets the number of columns in the matrix.
        /// </summary>
        int ColumnCount { get; }

        /// <summary>
        /// Gets the value at the provided indexes.
        /// </summary>
        /// <param name="i">
        /// The index of the row.
        /// </param>
        /// <param name="j">
        /// The index of the column.
        /// </param>
        double this[int i, int j] { get; }
    }
}
