// <copyright file="MersenneTwisterInitByArray.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.SeedSequences
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// An enumeration that determines how a BigRational number is rounded.
    /// </summary>
    public sealed class MersenneTwisterInitByArray : ISeedSequence<uint>
    {
        public MersenneTwisterInitByArray(IEnumerable<uint> seeds)
        {
            this.Seeds = seeds.ToArray();
        }

        public uint[] Seeds { get; }

        private static unsafe void InitByArray(uint* arrayToSeed, uint[] seeds, uint size)
        {
            throw new NotImplementedException();
        }

        public uint[] SeedArray(uint arraySize)
        {
            var seeds = this.Seeds;
            var result = new uint[arraySize];
            throw new NotImplementedException();
        }
    }
}
