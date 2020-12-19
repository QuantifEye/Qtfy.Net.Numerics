// <copyright file="UniformUIntGenerator.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.DistributionGenerators
{
    using System;

    /// <summary>
    /// A distribution generator that is able to generate bounded uniformly distributed random variables.
    /// </summary>
    [CLSCompliant(false)]
    public class UniformUIntGenerator : IDistributionGenerator<uint>
    {
        private readonly IRandomBitGenerator<uint> generator;

        private readonly uint max;

        private readonly uint min;

        /// <summary>
        /// Initializes a new instance of the <see cref="UniformUIntGenerator"/> class.
        /// The generator produces numbers in the interval [min, max].
        /// </summary>
        /// <param name="generator">
        /// The souce generator to use as a random source.
        /// </param>
        /// <param name="min">
        /// The smallest number that will be generated by this generator.
        /// </param>
        /// <param name="max">
        /// The greatest number that will be generated by this generator.
        /// </param>
        public UniformUIntGenerator(IRandomBitGenerator<uint> generator, uint min, uint max)
        {
            if (min > max)
            {
                throw new ArgumentException(null, nameof(min));
            }

            this.min = min;
            this.max = max;
            this.generator = generator;
        }

        /// <inheritdoc/>
        public uint GetNext()
        {
            var g = this.generator;
            var min = this.min;
            var range = this.max - min;
            if (range == uint.MaxValue)
            {
                return g.GetBits();
            }

            ++range;
            var scaling = uint.MaxValue / range;
            var last = range * scaling;
            uint result;
            do
            {
                result = g.GetBits();
            }
            while (result >= last);

            return (result / scaling) + min;
        }
    }
}
