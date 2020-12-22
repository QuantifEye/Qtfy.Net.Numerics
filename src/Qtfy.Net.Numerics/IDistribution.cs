// <copyright file="IDistribution.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics
{
    /// <summary>
    /// The interface implemented by all statistical distributions.
    /// </summary>
    /// <typeparam name="TDomain">
    /// The type of the domain. This is typically an integral type for univariate discrete distributions,
    /// a double for continuous distributions, and a double[] for multivariate continuous distributions.
    /// </typeparam>
    public interface IDistribution<TDomain>
    {
        // TODO: should cdfs be in their own interface?
        double CDF(TDomain x);

        // TODO: this is not well defined for multivariate distributions
        TDomain InverseCDF(double p);

        /// <summary>
        /// The probability density function of the distribution.
        /// </summary>
        /// <param name="x">
        /// The point at which to evaluate the probability density function.
        /// </param>
        /// <returns>
        /// A double precision value representing the value of the probability density function
        /// at the provided <paramref name="x"/> point.
        /// </returns>
        double PDF(TDomain x);
    }
}
