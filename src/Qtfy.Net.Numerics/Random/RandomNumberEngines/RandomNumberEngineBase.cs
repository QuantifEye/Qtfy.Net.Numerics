// <copyright file="RandomNumberEngineBase.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.RandomNumberEngines
{
    using System;

    /// <summary>
    /// A base class for all random bit generators that generate uniformly distributed values.
    /// </summary>
    public abstract class RandomNumberEngineBase : IRandomNumberEngine
    {
        /// <inheritdoc />
        public abstract uint NextUInt();

        /// <inheritdoc />
        public abstract uint NextUInt(uint max);

        /// <inheritdoc />
        public abstract uint NextUInt(uint min, uint max);

        /// <inheritdoc />
        public abstract int NextInt();

        /// <inheritdoc />
        public abstract int NextInt(int max);

        /// <inheritdoc />
        public abstract int NextInt(int min, int max);

        /// <inheritdoc />
        public abstract ulong NextULong();

        /// <inheritdoc />
        public abstract ulong NextULong(ulong max);

        /// <inheritdoc />
        public abstract ulong NextULong(ulong min, ulong max);

        /// <inheritdoc />
        public abstract long NextLong();

        /// <inheritdoc />
        public abstract long NextLong(long max);

        /// <inheritdoc />
        public abstract long NextLong(long min, long max);

        /// <inheritdoc />
        public double NextCanonical()
        {
            return Math.ScaleB(this.NextULong() >> 11, -52);
        }

        /// <inheritdoc />
        public double NextIncrementedCanonical()
        {
            return Math.ScaleB((this.NextULong() >> 11) + 1UL, -52);
        }

        /// <inheritdoc />
        public double NextSymmetricCanonical()
        {
            const long mostSignificantBit = 1L << 63;
            var x = (long)this.NextULong();
            return Math.ScaleB(((x ^ mostSignificantBit) >> 10) | (x | mostSignificantBit), -52);
        }
    }
}
