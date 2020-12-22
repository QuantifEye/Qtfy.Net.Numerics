// <copyright file="Uniform64BitGenerator.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.BitGenerators
{
    using System;

    /// <summary>
    /// A base class for random number generators that generate uniformly distributes
    /// 64 bit words.
    /// That is, <see cref="UniformLongBitGenerator"/>, and <see cref="UniformULongBitGenerator"/>.
    /// </summary>
    public abstract class Uniform64BitGenerator : UniformBitGenerator
    {
        /// <inheritdoc />
        public abstract override ulong NextULong();

        /// <inheritdoc />
        public abstract override long NextLong();

        /// <inheritdoc />
        public sealed override uint NextUInt()
        {
            return (uint)this.NextULong(uint.MaxValue);
        }

        /// <inheritdoc />
        public sealed override int NextInt()
        {
            return (int)this.NextUInt();
        }
    }
}
