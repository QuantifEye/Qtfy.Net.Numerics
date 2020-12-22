// <copyright file="UniformULongBitGenerator.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.BitGenerators
{
    using System;

    /// <summary>
    /// A base class for random number generators that generate <see cref="ulong"/> values that are distributed
    /// across the entire range of possible <see cref="ulong"/> values.
    /// </summary>
    public abstract class UniformULongBitGenerator : Uniform64BitGenerator, IRandomBitGenerator<ulong>
    {
        /// <inheritdoc />
        public abstract ulong GetBits();

        /// <inheritdoc />
        public sealed override ulong NextULong()
        {
            return this.GetBits();
        }

        /// <inheritdoc />
        public sealed override long NextLong()
        {
            return (long)this.GetBits();
        }
    }
}
