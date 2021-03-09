// <copyright file="Impl.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.Samplers
{
    using System;
    using MathNet.Numerics.LinearAlgebra;

    /// <summary>
    /// Implementation functions for samplers.
    /// </summary>
    internal static class Impl
    {
        /// <summary>
        /// Performs the cholesky decomposition of the provided matrix,
        /// and returns it in row major packed form.
        /// </summary>
        /// <param name="covarianceMatrix">
        /// The covariance matrix to factor.
        /// </param>
        /// <returns>
        /// The factored correlation matrix.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="covarianceMatrix"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// if the covariance matrix is not zero indexed, if the covariance matrix is
        /// not symmetric, if the covariance matrix is empty, or if the matrix is not positive definite.
        /// </exception>
        internal static double[] PackedCholeskyFactor(double[,] covarianceMatrix)
        {
            if (covarianceMatrix is null)
            {
                throw new ArgumentNullException(nameof(covarianceMatrix));
            }

            if (covarianceMatrix.GetLowerBound(0) != 0 || covarianceMatrix.GetLowerBound(1) != 0)
            {
                throw new ArgumentException("covariance matrix must be zero indexed");
            }

            var rows = covarianceMatrix.GetLength(0);
            if (rows != covarianceMatrix.GetLength(1))
            {
                throw new ArgumentException("covariance matrix must be square");
            }

            if (rows < 1)
            {
                throw new ArgumentException("covariance matrix must not be empty.");
            }

            var cov = Matrix<double>.Build.DenseOfArray(covarianceMatrix);
            if (!cov.IsSymmetric())
            {
                throw new ArgumentException("covariance matrix must be symmetric.");
            }

            var factor = cov.Cholesky().Factor;
            var result = new double[(rows * (rows + 1)) / 2];
            for (int r = 0, d = 0; r < rows; ++r)
            {
                for (int c = 0; c <= r; ++c, ++d)
                {
                    result[d] = factor[r, c];
                }
            }

            return result;
        }
    }
}
