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
    public class NormalDistribution : IContinuousDistribution
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
            ValidateParameters(mu, sigma);
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

        /// <summary>
        /// Gets the mean of the distribution.
        /// </summary>
        public double Mean
        {
            get => this.Mu;
        }

        /// <summary>
        /// Gets the variance of the distribution.
        /// </summary>
        public double Variance
        {
            get => this.Sigma * this.Sigma;
        }

        /// <summary>
        /// Gets the standard deviation of the distribution.
        /// </summary>
        public double StandardDeviation
        {
            get => this.Sigma;
        }

        /// <inheritdoc />
        public double CumulativeDistribution(double x)
        {
            return CumulativeDistributionFunctionImpl(x, this.Mu, this.Sigma);
        }

        /// <summary>
        /// The cumulative distribution function for the normal distribution.
        /// </summary>
        /// <param name="x">
        /// The point at which to evaluate the function.
        /// </param>
        /// <param name="mu">
        /// The mean of the distribution.
        /// </param>
        /// <param name="sigma">
        /// The standard deviation of the distribution.
        /// </param>
        /// <returns>
        /// The probability that a random variable is less than or equal to <paramref name="x"/>.
        /// </returns>
        public static double CumulativeDistributionFunction(double x, double mu, double sigma)
        {
            ValidateParameters(mu, sigma);
            return CumulativeDistributionFunctionImpl(x, mu, sigma);
        }

        private static double CumulativeDistributionFunctionImpl(double x, double mu, double sigma)
        {
            var erf = SpecialFunctions.Erf((x - mu) / (sigma * Constants.SqrtTwo));
            return Math.FusedMultiplyAdd(erf, 0.5d, 0.5d);
        }

        /// <inheritdoc />
        public double Quantile(double probability)
        {
            return QuantileImpl(probability, this.Mu, this.Sigma);
        }

        /// <summary>
        /// Calculates the quantile function of the normal distribution.
        /// </summary>
        /// <param name="probability">
        /// The point at which to evaluate the function.
        /// </param>
        /// <param name="mu">
        /// The mean of the normal distribution.
        /// </param>
        /// <param name="sigma">
        /// The standard deviation of the distribution.
        /// </param>
        /// <returns>
        /// The quantile of the normal distribution.
        /// </returns>
        public static double QuantileFunction(double probability, double mu, double sigma)
        {
            ValidateParameters(mu, sigma);
            return QuantileImpl(probability, mu, sigma);
        }

        private static double QuantileImpl(double probability, double mu, double sigma)
        {
            if (probability >= 0d && probability <= 1d)
            {
                var erfInv = SpecialFunctions.ErfInv(Math.FusedMultiplyAdd(2d, probability, -1d));
                return mu + sigma * Constants.SqrtTwo * erfInv;
            }

            throw new ArgumentException("invalid probability", nameof(probability));
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

        /// <summary>
        /// Checks if the parameters are valid.
        /// </summary>
        /// <param name="mu">
        /// The mean, must be finite.
        /// </param>
        /// <param name="sigma">
        /// The standard deviation, must be positive and finite.
        /// </param>
        internal static void ValidateParameters(double mu, double sigma)
        {
            if (!double.IsFinite(mu))
            {
                throw new ArgumentException("mu must be finite");
            }

            if (!double.IsFinite(sigma) || sigma <= 0d)
            {
                throw new ArgumentException("sigma must be positive and finite");
            }
        }
    }
}
