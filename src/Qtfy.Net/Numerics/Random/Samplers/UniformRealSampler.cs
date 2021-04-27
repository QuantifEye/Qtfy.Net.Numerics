// <copyright file="UniformRealSampler.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.Samplers
{
    using System;

    /// <summary>
    /// A distribution that generates continuous uniform values.
    /// </summary>
    public sealed class UniformRealSampler : ISampler<double>
    {
        private readonly IRandomNumberEngine generator;

        /// <summary>
        /// Initializes a new instance of the <see cref="UniformRealSampler"/> class.
        /// </summary>
        /// <param name="generator">
        /// The underlying bit generator to use.
        /// </param>
        /// <param name="min">
        /// The lower bound of the values that will be generated.
        /// </param>
        /// <param name="max">
        /// The upper bound of the values that will be generated.
        /// </param>
        public UniformRealSampler(IRandomNumberEngine generator, double min, double max)
        {
            if (!double.IsFinite(min))
            {
                throw new ArgumentException("min must be finite");
            }

            if (!double.IsFinite(max))
            {
                throw new ArgumentException("max must be finite");
            }

            if (max <= min)
            {
                throw new ArgumentException("min must be less that or equal to max");
            }

            this.generator = generator ?? throw new ArgumentNullException(nameof(generator));
            this.Min = min;
            this.Max = max;
        }

        /// <summary>
        /// Gets the lower bound of the values that will be generated.
        /// </summary>
        public double Min { get; }

        /// <summary>
        /// Gets the upper bound of the values that will be generated.
        /// </summary>
        public double Max { get; }

        /// <inheritdoc/>
        public double GetNext()
        {
            return Math.FusedMultiplyAdd(this.generator.NextStandardUniform(), this.Max - this.Min, this.Min);
        }
    }
}
