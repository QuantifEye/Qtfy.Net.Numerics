// <copyright file="Uniform32BitGenerator.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.BitGenerators
{
    using System;

    /// <summary>
    /// A base class for random number generators that generate uniformly distributes
    /// 32 bit words.
    /// That is, <see cref="UniformIntBitGenerator"/>, and <see cref="UniformUIntBitGenerator"/>.
    /// </summary>
    public abstract class Uniform32BitGenerator : UniformBitGenerator
    {
        /// <inheritdoc />
        public abstract override uint NextUInt();

        /// <inheritdoc />
        public abstract override int NextInt();

        /// <inheritdoc/>
        public sealed override ulong NextULong()
        {
            // TODO: is this a valid method?
            // this is equivalent to w1 * pow(2, 32) + w1
            // so is it still uniform?
            ulong w1 = this.NextUInt();
            ulong w2 = this.NextUInt();
            return (w1 << 32) | w2;
        }

        /// <inheritdoc />
        public sealed override long NextLong()
        {
            return (long)this.NextULong();
        }
    }
}
