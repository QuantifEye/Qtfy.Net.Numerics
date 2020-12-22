// <copyright file="NormalDistribution.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Distributions
{
    /// <summary>
    /// The normal distribution.
    /// </summary>
    public sealed class NormalDistribution : IDistribution<double>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NormalDistribution"/> class.
        /// </summary>
        /// <param name="mean">
        /// The mean of the normal distribution.
        /// </param>
        /// <param name="sigma">
        /// The variance of the normal distribution.
        /// </param>
        public NormalDistribution(double mean, double sigma)
        {
            this.Mean = mean;
            this.Sigma = sigma;
        }

        /// <summary>
        /// Gets the mean of the distribution.
        /// </summary>
        public double Mean { get; }

        /// <summary>
        /// Gets the variance of the distribution.
        /// </summary>
        public double Sigma { get; }

        /// <inheritdoc />
        public double CDF(double x)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public double InverseCDF(double p)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public double PDF(double x)
        {
            throw new System.NotImplementedException();
        }
    }
}
