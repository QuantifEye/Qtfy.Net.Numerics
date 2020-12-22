// <copyright file="IDistributionGenerator.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random
{
    using Qtfy.Net.Numerics.Distributions;

    /// <summary>
    /// An object used to transform the values produced by a bit random generator
    /// into a random number with the desired distribution.
    /// </summary>
    /// <typeparam name="TDomain">
    /// The type of the generated values.
    /// </typeparam>
    public interface IDistributionGenerator<TDomain>
    {
        /// <summary>
        /// Gets the distribution that describes the random number that will be generated.
        /// </summary>
        IDistribution<TDomain> Distribution { get; }

        /// <summary>
        /// Gets the next random number.
        /// </summary>
        /// <returns>
        /// The next random number.
        /// </returns>
        TDomain GetNext();
    }
}
