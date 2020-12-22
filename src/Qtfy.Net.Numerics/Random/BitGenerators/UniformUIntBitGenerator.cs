// <copyright file="UniformUIntBitGenerator.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.BitGenerators
{
    using System;

    /// <summary>
    /// A base class for random number generators that generate <see cref="uint"/> values that are distributed
    /// across the entire range of possible <see cref="uint"/> values.
    /// </summary>
    public abstract class UniformUIntBitGenerator : Uniform32BitGenerator, IRandomBitGenerator<uint>
    {
        /// <inheritdoc />
        public abstract uint GetBits();

        /// <inheritdoc />
        public sealed override uint NextUInt()
        {
            return this.GetBits();
        }

        /// <inheritdoc />
        public sealed override int NextInt()
        {
            return (int)this.GetBits();
        }
    }
}
