// <copyright file="IDistribution.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics
{
    public interface IDistribution
    {
        /// <summary>
        /// Gets the mean of the distribution.
        /// </summary>
        double Mean { get; }

        /// <summary>
        /// Gets the variance of the distribution.
        /// </summary>
        double Variance { get; }

        /// <summary>
        /// Gets the standard deviation of the distribution.
        /// </summary>
        double StandardDeviation { get; }

        /// <summary>
        /// Calculates the probability that a random variable is less than or equal to <paramref name="x"/>.
        /// </summary>
        /// <param name="x">
        /// The point at which to evaluated the cumulative distribution function.
        /// </param>
        /// <returns>
        /// The value of the cumulative distribution function evaluated at <paramref name="x"/>.
        /// </returns>
        double CumulativeDistribution(double x);
    }
}
