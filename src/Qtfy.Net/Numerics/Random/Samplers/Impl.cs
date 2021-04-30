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
        internal static double[] PackedCholeskyFactorCovarianceMatrix(double[,] covarianceMatrix)
        {
            CheckDimensions(covarianceMatrix);
            CheckCovarianceValues(covarianceMatrix);
            return FactorMatrix(covarianceMatrix);
        }

        /// <summary>
        /// Performs the cholesky decomposition of the provided matrix,
        /// and returns it in row major packed form.
        /// </summary>
        /// <param name="correlationMatrix">
        /// The correlation matrix to factor.
        /// </param>
        /// <returns>
        /// The factored correlation matrix.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="correlationMatrix"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// if the covariance matrix is not zero indexed, if the covariance matrix is
        /// not symmetric, if the covariance matrix is empty, or if the matrix is not positive definite.
        /// </exception>
        internal static double[] PackedCholeskyFactorCorrelationMatrix(double[,] correlationMatrix)
        {
            CheckDimensions(correlationMatrix);
            CheckCorrelationValues(correlationMatrix);
            return FactorMatrix(correlationMatrix);
        }

        private static double[] FactorMatrix(double[,] matrix)
        {
            var cov = Matrix<double>.Build.DenseOfArray(matrix);
            var rows = cov.RowCount;
            var factor = cov.Cholesky().Factor;
            var result = new double[(rows * (rows + 1)) / 2];
            for (int r = 0, d = 0; r < rows; ++r)
            {
                for (var c = 0; c <= r; ++c, ++d)
                {
                    result[d] = factor[r, c];
                }
            }

            return result;
        }

        private static void CheckDimensions(double[,] matrix)
        {
            if (matrix.GetLowerBound(0) != 0 || matrix.GetLowerBound(1) != 0)
            {
                throw new ArgumentException("matrix must be zero indexed");
            }

            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);
            if (rows != columns)
            {
                throw new ArgumentException("matrix must be square");
            }

            if (rows < 1)
            {
                throw new ArgumentException("matrix must not be empty.");
            }
        }

        private static void CheckCorrelationValues(double[,] matrix)
        {
            var rows = matrix.GetLength(0);
            for (var r = 0; r < rows; ++r)
            {
                for (var c = 0; c < r; ++c)
                {
                    var corr = matrix[r, c];
                    if (corr < -1d || corr > 1d || corr != matrix[c, r])
                    {
                        throw new ArgumentException("Matrix must be symmetric and values must be in range [-1.0, 1.0].");
                    }
                }

                if (matrix[r, r] != 1d)
                {
                    throw new ArgumentException("Diagonal values must equal to 1.0.");
                }
            }
        }

        private static void CheckCovarianceValues(double[,] matrix)
        {
            var rows = matrix.GetLength(0);
            for (var r = 0; r < rows; ++r)
            {
                for (var c = 0; c < r; ++c)
                {
                    if (matrix[r, c] != matrix[c, r])
                    {
                        throw new ArgumentException("Matrix must be symmetric.");
                    }
                }

                var variance = matrix[r, r];
                if (!double.IsFinite(variance) || variance <= 0d)
                {
                    throw new ArgumentException("Diagonal values must be positive.");
                }
            }
        }
    }
}
