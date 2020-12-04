// <copyright file="MersenneTwister19937.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random
{
    /// <summary>
    /// The Mersenne Twister random number generator.
    /// <see href="http://stackoverflow.com">
    /// http://www.math.sci.hiroshima-u.ac.jp/m-mat/MT/emt.html
    /// </see>.
    /// </summary>
    public sealed class MersenneTwister19937 : IRandomBitGenerator<uint>
    {
        private const int N = 624;

        private const int M = 397;

        private const uint MatrixA = 0x9908b0dfU;

        private const uint UpperMask = 0x80000000U;

        private const uint LowerMask = 0x7fffffffU;

        private readonly uint[] state;

        private int index;

        /// <summary>
        /// Initializes a new instance of the <see cref="MersenneTwister19937"/> class.
        /// </summary>
        /// <param name="state">
        /// The state array of the generator.
        /// </param>
        /// <param name="index">
        /// The current position in the state.
        /// </param>
        private MersenneTwister19937(uint[] state, int index)
        {
            this.state = state;
            this.index = index;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MersenneTwister19937"/> class.
        /// </summary>
        /// <param name="seed">
        /// The seed used to seed the initial state.
        /// </param>
        /// <returns>
        /// A new instance of a Mersenne Twister PRNG.
        /// </returns>
        /// <remarks>
        /// This method uses the initialization procedure called init_by_array in the original
        /// c code.
        /// <see href="http://stackoverflow.com">
        /// http://www.math.sci.hiroshima-u.ac.jp/m-mat/MT/MT2002/CODES/mt19937ar.c
        /// </see>.
        /// </remarks>
        public static MersenneTwister19937 InitGenRand(uint seed)
        {
            var state = new uint[N];
            unsafe
            {
                fixed (uint* mt = state)
                {
                    InitGenRandImpl(mt, seed);
                }
            }

            return new MersenneTwister19937(state, N);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MersenneTwister19937"/> class.
        /// </summary>
        /// <param name="seeds">
        /// The seeds used to seed the initial state.
        /// </param>
        /// <returns>
        /// A new instance of a Mersenne Twister PRNG.
        /// </returns>
        /// <remarks>
        /// This method uses the initialization procedure called init_by_array in the original
        /// c code.
        /// <see href="http://stackoverflow.com">
        /// http://www.math.sci.hiroshima-u.ac.jp/m-mat/MT/MT2002/CODES/mt19937ar.c
        /// </see>.
        /// </remarks>
        public static MersenneTwister19937 InitByArray(uint[] seeds)
        {
            var state = new uint[N];
            unsafe
            {
                fixed (uint* mt = state)
                fixed (uint* init_key = seeds)
                {
                    InitByArrayImpl(mt, init_key, (uint)seeds.Length);
                }
            }

            return new MersenneTwister19937(state, N);
        }

        /// <inheritdoc />
        public uint Next()
        {
            if (this.index == N)
            {
                this.UpdateState(this.state);
                this.index = 0;
            }

            var y = this.state[this.index++];
            y ^= y >> 11;
            y ^= (y << 7) & 0x9d2c5680;
            y ^= (y << 15) & 0xefc60000;
            y ^= y >> 18;
            return y;
        }

        private static unsafe void UpdateStateImpl(uint* mt)
        {
            var p0 = mt;
            var p1 = mt + 1;
            var p2 = mt + M;
            var counter = N - M;
            uint y;
            do
            {
                y = (*p0 & UpperMask) | (*p1 & LowerMask);
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
                y = (*p0 & UpperMask) | (*p1 & LowerMask);
                *p0 = *p2 ^ (y >> 1) ^ ((y & 0x1U) == 0U ? 0x0U : MatrixA);
                ++p0;
                ++p1;
                ++p2;
            }
            while (--counter != 0);

            p1 = mt;
            y = (*p0 & UpperMask) | (*p1 & LowerMask);
            *p0 = *p2 ^ (y >> 1) ^ ((y & 0x1U) == 0U ? 0x0U : MatrixA);
        }

        private static unsafe void InitByArrayImpl(uint* mt, uint* initKey, uint keyLength)
        {
            InitGenRandImpl(mt, 19650218U);
            var i = 1U;
            var j = 0U;
            var k = keyLength > N ? keyLength : N;
            for (; k != 0; k--)
            {
                mt[i] = (mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) * 1664525U)) + initKey[j] + j;
                if (++i >= N)
                {
                    mt[0] = mt[N - 1];
                    i = 1;
                }

                if (++j >= keyLength)
                {
                    j = 0;
                }
            }

            for (k = N - 1; k != 0; k--)
            {
                mt[i] = (mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) * 1566083941U)) - i;
                if (++i >= N)
                {
                    mt[0] = mt[N - 1];
                    i = 1;
                }
            }

            mt[0] = 0x1U << 31;
        }

        private static unsafe void InitGenRandImpl(uint* mt, uint s)
        {
            mt[0] = s;
            for (uint mti = 1; mti < N; mti++)
            {
                mt[mti] = (1812433253U * (mt[mti - 1] ^ (mt[mti - 1] >> 30))) + mti;
            }
        }

        private void UpdateState(uint[] state)
        {
            unsafe
            {
                fixed (uint* s = state)
                {
                    UpdateStateImpl(s);
                }
            }

            this.index = 0;
        }
    }
}