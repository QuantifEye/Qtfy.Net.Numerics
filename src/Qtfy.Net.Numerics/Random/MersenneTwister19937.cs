// <copyright file="MersenneTwister19937.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

using Qtfy.Net.Numerics.Random.SeedSequences;

namespace Qtfy.Net.Numerics.Random
{
    /// <summary>
    /// An enumeration that determines how a BigRational number is rounded.
    /// </summary>
    public sealed class MersenneTwister19937 : IRandomBitGenerator<uint>
    {
        private const int N = 624;

        private const int M = 397;

        private const uint MatrixA = 0x9908b0dfU;

        private const uint UPPER_MASK = 0x80000000U;

        private const uint LOWER_MASK = 0x7fffffffU;

        private readonly uint[] State;

        private int index;

        private MersenneTwister19937(uint[] state, int index)
        {
            this.State = state;
            this.index = index;
        }

        public static MersenneTwister19937 InitGenRand(uint s)
        {
            var mt = new uint[N];
            mt[0] = s;
            for (uint mti = 1; mti < N; mti++)
            {
                mt[mti] = (1812433253U * (mt[mti - 1] ^ (mt[mti - 1] >> 30))) + mti;
            }

            return new MersenneTwister19937(mt, N);
        }

        private static unsafe void UpdateStateUnsafe(uint* mt)
        {
            uint* p0 = mt;
            uint* p1 = mt + 1;
            uint* p2 = mt + M;
            int counter = N - M;
            uint y;
            do
            {
                y = (*p0 & UPPER_MASK) | (*p1 & LOWER_MASK);
                *p0 = *p2 ^ (y >> 1) ^ ((y & 0x1U) == 0U ? 0x0U : MatrixA);
                ++p0;
                ++p1;
                ++p2;
            }
            while (--counter != 0);

            counter = M - 1;
            p2 = mt;
            do
            {
                y = (*p0 & UPPER_MASK) | (*p1 & LOWER_MASK);
                *p0 = *p2 ^ (y >> 1) ^ ((y & 0x1U) == 0U ? 0x0U : MatrixA);
                ++p0;
                ++p1;
                ++p2;
            }
            while (--counter != 0);

            p1 = mt;
            y = (*p0 & UPPER_MASK) | (*p1 & LOWER_MASK);
            *p0 = *p2 ^ (y >> 1) ^ ((y & 0x1U) == 0U ? 0x0U : MatrixA);
        }

        private static void UpdateState(uint[] state)
        {
            unsafe
            {
                fixed (uint* s = state)
                {
                    UpdateStateUnsafe(s);
                }
            }
        }

        private static uint Temper(uint y)
        {
            y ^= y >> 11;
            y ^= (y << 7) & 0x9d2c5680;
            y ^= (y << 15) & 0xefc60000;
            y ^= y >> 18;
            return y;
        }

        private uint NextUnTempered()
        {
            var state = this.State;
            if (this.index == N)
            {
                UpdateState(state);
                this.index = 1;
                return state[0];
            }
            else
            {
                return state[this.index++];
            }
        }

        public uint Next()
        {
            return Temper(this.NextUnTempered());
        }
    }
}
