// <copyright file="GaussianCopula.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Copulas
{
    /// <summary>
    /// The gaussian copula.
    /// </summary>
    public class GaussianCopula : ICopula
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GaussianCopula"/> class.
        /// </summary>
        /// <param name="mean">
        /// The mean of the normal distribution.
        /// </param>
        /// <param name="sigma">
        /// The covariance matrix of the normal distribution.
        /// </param>
        public GaussianCopula(double[] mean, double[,] sigma)
        {
            this.Mean = mean;
            this.Sigma = sigma;
        }

        /// <summary>
        /// Gets the covariance matrix.
        /// </summary>
        public double[,] Sigma { get; }

        /// <summary>
        /// Gets the mean.
        /// </summary>
        public double[] Mean { get; }

        /// <inheritdoc />
        public double CDF(double[] x)
        {
            throw new System.NotImplementedException();
        }
    }
}
