// <copyright file="CovarianceMatrix.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    /// <summary>
    /// An object representing a covariance matrix.
    /// </summary>
    public sealed partial class CovarianceMatrix : Matrix
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CovarianceMatrix"/> class.
        /// </summary>
        /// <param name="data">
        /// The data to construct the matrix with. This should be symmetric dense storage.
        /// </param>
        /// <param name="order">
        /// The number of rows and columns of the matrix.
        /// </param>
        /// <exception cref="LinearAlgebraException">
        /// If the provided data does not result in a positive definite matrix.
        /// </exception>
        private CovarianceMatrix(double[] data, int order)
            : base(data, order, order)
        {
            throw new LinearAlgebraException("do square root and inverse here?");
        }

        /// <summary>
        /// Gets the lower triangular matrix resulting from the Cholesky decomposition
        /// of the covariance matrix.
        /// </summary>
        public LowerTriangular SquareRoot { get; }

        /// <summary>
        /// Gets the determinant of the correlation matrix.
        /// </summary>
        public double Determinant { get; }

        /// <summary>
        /// Gets the inverse of the correlation matrix.
        /// </summary>
        public Matrix Inverse { get; }
    }
}
