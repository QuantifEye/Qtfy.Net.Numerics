// <copyright file="UniformBitGenerator.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.BitGenerators
{
    using System;
    using System.Numerics;

    /// <summary>
    /// A base class for all random bit generators that generate uniformly distributed values.
    /// </summary>
    public abstract class UniformBitGenerator : IUniformBitGenerator
    {
        /// <inheritdoc />
        public abstract int NextInt();

        /// <inheritdoc />
        public abstract uint NextUInt();

        /// <inheritdoc />
        public abstract long NextLong();

        /// <inheritdoc />
        public abstract ulong NextULong();

        /// <summary>
        /// Generates a <see cref="uint"/> that is uniformly distributed in the interval
        /// [0, <paramref name="max"/>].
        /// </summary>
        /// <param name="max">
        /// The greatest number that will be generated.
        /// </param>
        /// <returns>
        /// A <see cref="uint"/> that is uniformly distributed in the interval [0, <paramref name="max"/>].
        /// </returns>
        private protected uint NextUInt(uint max)
        {
            if (max == uint.MaxValue)
            {
                return this.NextUInt();
            }

            var range = max + 1u;
            var scaling = uint.MaxValue / range;
            var last = range * scaling;
            uint result;
            do
            {
                result = this.NextUInt();
            }
            while (result >= last);

            return result / scaling;
        }

        /// <summary>
        /// Generates a <see cref="ulong"/> that is uniformly distributed in the interval
        /// [0, <paramref name="max"/>].
        /// </summary>
        /// <param name="max">
        /// The greatest number that will be generated.
        /// </param>
        /// <returns>
        /// A <see cref="ulong"/> that is uniformly distributed in the interval [0, <paramref name="max"/>].
        /// </returns>
        private protected ulong NextULong(ulong max)
        {
            if (max == ulong.MaxValue)
            {
                return this.NextULong();
            }

            var range = max + 1UL;
            var scaling = ulong.MaxValue / range;
            var last = range * scaling;
            ulong result;
            do
            {
                result = this.NextULong();
            }
            while (result >= last);

            return result / scaling;
        }

        /// <inheritdoc />
        public uint NextUInt(uint min, uint max)
        {
            if (max < min)
            {
                throw new ArgumentException("min must be less than or equal to max", nameof(min));
            }

            return min + this.NextUInt(max - min);
        }

        /// <inheritdoc />
        public ulong NextULong(ulong min, ulong max)
        {
            if (max < min)
            {
                throw new ArgumentException("min must be less than or equal to max", nameof(min));
            }

            return min + this.NextULong(max - min);
        }

        /// <inheritdoc />
        public int NextInt(int min, int max)
        {
            if (max < min)
            {
                throw new ArgumentException("min must be less than or equal to max", nameof(min));
            }

            var signedMax = (uint)((long)max - min);

            return (int)(min + this.NextUInt(signedMax));
        }

        /// <inheritdoc />
        public long NextLong(long min, long max)
        {
            if (max < min)
            {
                throw new ArgumentException("min must be less than or equal to max", nameof(min));
            }

            // TODO: initial implementation, can be done without BigInteger
            var signedMax = (ulong)((BigInteger)max - min);
            return (long)((BigInteger)min + this.NextULong(signedMax));
        }

        /// <inheritdoc />
        public double NextStandardUniform()
        {
            throw new NotImplementedException();
        }
    }
}
