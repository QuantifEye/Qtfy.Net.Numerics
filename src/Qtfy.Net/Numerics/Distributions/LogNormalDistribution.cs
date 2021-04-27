// <copyright file="LogNormalDistribution.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Distributions
{
    using System;
    using static System.Math;
    using static SpecialFunctions;

    /// <summary>
    /// A Log-Normal statistical distribution object.
    /// </summary>
    public class LogNormalDistribution : IContinuousDistribution
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
            if (!double.IsFinite(mu))
            {
                throw new ArgumentException(
                    $"{nameof(mu)} must not be infinite or NaN",
                    nameof(mu));
            }

            if (!double.IsFinite(sigma) || sigma <= 0d)
            {
                throw new ArgumentException(
                    $"{nameof(sigma)} must not be greater than zero and not or NaN",
                    nameof(sigma));
            }

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
            get => Exp(this.Mu + this.Sigma * this.Sigma / 2d);
        }

        /// <inheritdoc />
        public double Variance
        {
            get
            {
                var v = this.Sigma * this.Sigma;
                return (Exp(v) - 1d) * Exp(2d * this.Mu + v);
            }
        }

        /// <inheritdoc />
        public double StandardDeviation
        {
            get => Sqrt(this.Variance);
        }

        /// <inheritdoc />
        public double Quantile(double probability)
        {
            if (probability >= 0d && probability <= 1d)
            {
                var erfInv = ErfInv(FusedMultiplyAdd(2d, probability, -1d));
                return Exp(this.Mu + Constants.SqrtTwo * this.Sigma * erfInv);
            }

            throw new ArgumentException("invalid probability", nameof(probability));
        }

        /// <inheritdoc />
        public double Density(double x)
        {
            if (x <= 0d)
            {
                return 0d;
            }
            else
            {
                var z = (Log(x) - this.Mu) / this.Sigma;
                return Exp(-0.5 * z * z) / (x * this.Sigma * Constants.SqrtTwoPi);
            }
        }

        /// <inheritdoc />
        public double DensityLn(double x)
        {
            if (x <= 0d)
            {
                return double.NegativeInfinity;
            }
            else
            {
                var z = (Log(x) - this.Mu) / this.Sigma;
                return -0.5 * z * z - Log(x * this.Sigma * Constants.SqrtTwoPi);
            }
        }

        /// <inheritdoc />
        public double CumulativeDistribution(double x)
        {
            return x <= 0d
                ? 0d
                : FusedMultiplyAdd(Erf((Log(x) - this.Mu) / (Constants.SqrtTwo * this.Sigma)), 0.5, 0.5);
        }
    }
}
