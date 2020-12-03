// <copyright file="MersenneTwisterInitGenRand.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.SeedSequences
{
    /// <summary>
    /// An enumeration that determines how a BigRational number is rounded.
    /// </summary>
    public sealed class MersenneTwisterInitGenRand : ISeedSequence<uint>
    {
        public MersenneTwisterInitGenRand(uint seed)
        {
            this.Seed = seed;
        }

        public uint Seed { get; }

        private static unsafe void InitGenRandUnsafe(uint* mt, uint seed, uint size)
        {
            mt[0] = seed;
            for (uint mti = 1; mti < size; mti++)
            {
                mt[mti] = (1812433253U * (mt[mti - 1U] ^ (mt[mti - 1U] >> 30)) + mti);
                /* See Knuth TAOCP Vol2. 3rd Ed. P.106 for multiplier. */
                /* In the previous versions, MSBs of the seed affect   */
                /* only MSBs of the array mt[].                        */
                /* 2002/01/09 modified by Makoto Matsumoto             */
            }
        }

        public uint[] SeedArray(uint arraySize)
        {
            var result = new uint[arraySize];
            unsafe
            {
                fixed (uint* arr = result)
                {
                    InitGenRandUnsafe(arr, this.Seed, arraySize);
                }
            }

            return result;
        }
    }
}
