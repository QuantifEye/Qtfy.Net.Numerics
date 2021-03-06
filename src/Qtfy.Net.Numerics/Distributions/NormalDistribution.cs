// <copyright file="NormalDistribution.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Distributions
{
    using System;

    /// <summary>
    /// A Normal(Gaussian) distribution object.
    /// </summary>
    public class NormalDistribution : IContiniousDistribution
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NormalDistribution"/> class.
        /// </summary>
        /// <param name="mu">
        /// The mean parameter of the distribution.
        /// </param>
        /// <param name="sigma">
        /// The standard deviation parameter of the distribution.
        /// </param>
        /// <exception cref="ArgumentException">
        /// if <paramref name="mu"/> is not finite, if <paramref name="sigma"/> is not finite, or of sigma if not
        /// greater than zero.
        /// </exception>
        public NormalDistribution(double mu, double sigma)
        {
            if (!double.IsFinite(sigma) || sigma <= 0d)
            {
                throw new ArgumentException("sigma must be finite and greater than zero.");
            }

            if (!double.IsFinite(mu))
            {
                throw new ArgumentException("mu must be finite.");
            }

            this.Mu = mu;
            this.Sigma = sigma;
        }

        /// <summary>
        /// Gets the mean parameter of the distribution.
        /// </summary>
        public double Mu { get; }

        /// <summary>
        /// Gets the standard deviation parameter of the distribution.
        /// </summary>
        public double Sigma { get; }

        /// <inheritdoc />
        public double Mean
        {
            get => this.Mu;
        }

        /// <inheritdoc />
        public double Variance
        {
            get => this.Sigma * this.Sigma;
        }

        /// <inheritdoc />
        public double StandardDeviation
        {
            get => this.Sigma;
        }

        /// <inheritdoc />
        public double CumulativeDistribution(double x)
        {
            var erf = SpecialFunctions.Erf((x - this.Mu) / (this.Sigma * Constants.SqrtTwo));
            return Math.FusedMultiplyAdd(erf, 0.5d, 0.5d);
        }

        /// <inheritdoc />
        public double Quantile(double probability)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public double Density(double x)
        {
            var s = this.Sigma;
            var z = (x - this.Mu) / s;
            return Math.Exp(-0.5 * z * z) / (s * Constants.SqrtTwoPi);
        }

        /// <inheritdoc />
        public double DensityLn(double x)
        {
            var s = this.Sigma;
            var z = (x - this.Mu) / s;
            return (z * z / -2d) - Math.Log(s * Constants.SqrtTwoPi);
        }
    }
}
