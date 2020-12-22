// <copyright file="UniformUIntDistribution.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Distributions
{
    using System;

    /// <summary>
    /// A integer uniform where every <see cref="uint"/> in the provided range is equally likely.
    /// </summary>
    public class UniformUIntDistribution : IDistribution<uint>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UniformUIntDistribution"/> class.
        /// </summary>
        /// <param name="min">
        /// The smallest value int the range of uniformly distributed integers.
        /// </param>
        /// <param name="max">
        /// The greatest value int the range of uniformly distributed integers.
        /// </param>
        public UniformUIntDistribution(uint min, uint max)
        {
            this.Min = min;
            this.Max = max;
        }

        /// <summary>
        /// Gets the greatest value int the range of uniformly distributed integers.
        /// </summary>
        public uint Max { get; }

        /// <summary>
        /// Gets the smallest value int the range of uniformly distributed integers.
        /// </summary>
        public uint Min { get; }

        /// <inheritdoc />
        public double CDF(uint x)
        {
            return 1d / (this.Max - this.Min + 1U);
        }

        /// <inheritdoc />
        public uint InverseCDF(double p)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public double PDF(uint x)
        {
            throw new NotImplementedException();
        }
    }
}
