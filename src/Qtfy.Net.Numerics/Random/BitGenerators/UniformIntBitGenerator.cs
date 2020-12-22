// <copyright file="UniformIntBitGenerator.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.BitGenerators
{
    using System;

    /// <summary>
    /// A base class for random number generators that generate <see cref="int"/> values that are distributed
    /// across the entire range of possible <see cref="int"/> values.
    /// </summary>
    public abstract class UniformIntBitGenerator : Uniform32BitGenerator, IRandomBitGenerator<int>
    {
        /// <inheritdoc />
        public abstract int GetBits();

        /// <inheritdoc />
        public sealed override uint NextUInt()
        {
            return (uint)this.GetBits();
        }

        /// <inheritdoc />
        public sealed override int NextInt()
        {
            return this.GetBits();
        }
    }
}
