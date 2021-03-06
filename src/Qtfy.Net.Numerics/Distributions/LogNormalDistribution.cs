// <copyright file="LogNormalDistribution.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Distributions
{
    using System;

    /// <summary>
    /// A Log-Normal statistical distribution object.
    /// </summary>
    public class LogNormalDistribution : IContiniousDistribution
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogNormalDistribution"/> class.
        /// </summary>
        /// <param name="mu">
        /// The mean parameter of the related normal distribution.
        /// </param>
        /// <param name="sigma">
        /// The standard deviation of the related normal distribution.
        /// </param>
        public LogNormalDistribution(double mu, double sigma)
        {
            this.Mu = mu;
            this.Sigma = sigma;
        }

        /// <summary>
        /// Gets the mean parameter of the related normal distribution.
        /// </summary>
        public double Mu { get; }

        /// <summary>
        /// Gets the standard deviation parameter of the related normal distribution.
        /// </summary>
        public double Sigma { get; }

        /// <inheritdoc />
        public double Mean
        {
            get => Math.Exp(this.Mu + 0.5 * this.Sigma * this.Sigma);
        }

        /// <inheritdoc />
        public double Variance
        {
            get
            {
                var v = this.Sigma * this.Sigma;
                return (Math.Exp(v) - 1d) * Math.Exp(2d * this.Mu + v);
            }
        }

        /// <inheritdoc />
        public double StandardDeviation
        {
            get => Math.Sqrt(this.Variance);
        }

        /// <inheritdoc />
        public double Quantile(double p)
        {
            var erfInv = Math.FusedMultiplyAdd(2d, p, -1d);
            return Math.Exp(this.Mu + Constants.SqrtTwo * this.Sigma * this.Sigma * erfInv);
        }

        /// <inheritdoc />
        public double Density(double x)
        {
            var z = (x - this.Mu) / this.Sigma;
            return Math.Exp(Math.Exp(-0.5 * z * z) / (this.Sigma * Constants.SqrtTwoPi));
        }

        /// <inheritdoc />
        public double DensityLn(double x)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public double CumulativeDistribution(double x)
        {
            var erf = SpecialFunctions.Erf((x - this.Mu) / (this.Sigma * Constants.SqrtTwo));
            return Math.FusedMultiplyAdd(erf, 0.5d, 0.5d);
        }
    }
}
