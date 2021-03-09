// <copyright file="StandardNormalDistribution.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Distributions
{
    using System;

    /// <summary>
    /// A standard normal distribution object.
    /// </summary>
    public class StandardNormalDistribution : IContinuousDistribution
    {
        private StandardNormalDistribution()
        {
        }

        /// <summary>
        /// Gets the singleton instance of the standard normal distribution.
        /// </summary>
        public static StandardNormalDistribution Instance { get; } = new ();

        /// <inheritdoc />
        public double Mean
        {
            get => 0d;
        }

        /// <inheritdoc />
        public double Variance
        {
            get => 1d;
        }

        /// <inheritdoc />
        public double StandardDeviation
        {
            get => 1d;
        }

        /// <inheritdoc />
        public double CumulativeDistribution(double x)
        {
            return Math.FusedMultiplyAdd(SpecialFunctions.Erf(x / Constants.SqrtTwo), 0.5d, 0.5d);
        }

        /// <inheritdoc />
        public double Quantile(double probability)
        {
            if (probability >= 0d && probability <= 1d)
            {
                return Constants.SqrtTwo * SpecialFunctions.ErfInv(Math.FusedMultiplyAdd(2d, probability, -1d));
            }

            throw new ArgumentException("invalid probability", nameof(probability));
        }

        /// <inheritdoc />
        public double Density(double x)
        {
            return Math.Exp(-0.5 * x * x) / Constants.SqrtTwoPi;
        }

        /// <inheritdoc />
        public double DensityLn(double x)
        {
            return -0.5 * x * x - Constants.LogSqrtTwoPi;
        }
    }
}
