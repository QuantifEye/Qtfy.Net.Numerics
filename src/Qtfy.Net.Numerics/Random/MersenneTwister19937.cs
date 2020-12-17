// <copyright file="MersenneTwister19937.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

/*
   Original code's copyright and license:
   Copyright (C) 1997 - 2002, Makoto Matsumoto and Takuji Nishimura,
   All rights reserved.
   Redistribution and use in source and binary forms, with or without
   modification, are permitted provided that the following conditions
   are met:
     1. Redistributions of source code must retain the above copyright
        notice, this list of conditions and the following disclaimer.
     2. Redistributions in binary form must reproduce the above copyright
        notice, this list of conditions and the following disclaimer in the
        documentation and/or other materials provided with the distribution.
     3. The names of its contributors may not be used to endorse or promote
        products derived from this software without specific prior written
        permission.
   THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
   "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
   LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
   A PARTICULAR PURPOSE ARE DISCLAIMED.  IN NO EVENT SHALL THE COPYRIGHT OWNER OR
   CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
   EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
   PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
   PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
   LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
   NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
   SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
   Any feedback is very welcome.
   http://www.math.sci.hiroshima-u.ac.jp/~m-mat/MT/emt.html
   email: m-mat @ math.sci.hiroshima-u.ac.jp (remove space)
*/

namespace Qtfy.Net.Numerics.Random
{
    using System;

    /// <summary>
    /// The Mersenne Twister random number generator.
    /// <see href="http://stackoverflow.com">
    /// http://www.math.sci.hiroshima-u.ac.jp/m-mat/MT/MT2002/emt19937ar.html
    /// </see>.
    /// </summary>
    [CLSCompliant(false)]
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
                    MersenneTwister19937.InitGenRandImpl(mt, seed);
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
            if (seeds is null)
            {
                throw new ArgumentNullException(nameof(seeds));
            }

            var state = new uint[N];
            unsafe
            {
                fixed (uint* mt = state, initKey = seeds)
                {
                    MersenneTwister19937.InitByArrayImpl(mt, initKey, (uint)seeds.Length);
                }
            }

            return new MersenneTwister19937(state, N);
        }

        /// <inheritdoc />
        public uint GetBits()
        {
            if (this.index == N)
            {
                MersenneTwister19937.UpdateState(this.state);
                this.index = 0;
            }

            return Temper(this.state[this.index++]);
        }

        /// <summary>
        /// Fills thhe provided buffer with generated numbers, advancing the state of the generator.
        /// </summary>
        /// <param name="buffer">
        /// The buffer to fill with generated numbers.
        /// </param>
        public void Fill(uint[] buffer)
        {
            if (buffer is null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            int size = buffer.Length;
            if (size == 0)
            {
                return;
            }

            unsafe
            {
                fixed (uint* s = this.state, b = buffer)
                {
                    this.index = FillImpl(s, b, b + size, this.index);
                }
            }
        }

        /// <summary>
        /// The implementation of <see cref="Fill"/>.
        /// </summary>
        /// <param name="state">
        /// A pointer to the first element in the state.
        /// </param>
        /// <param name="buffer">
        /// A pointer to the first element in the buffer to fill.
        /// </param>
        /// <param name="bufferEnd">
        /// A pointer to the first element after the last element in the buffer to fill.
        /// </param>
        /// <param name="index">
        /// The current state position.
        /// </param>
        /// <returns>
        /// The new state position.
        /// </returns>
        private static unsafe int FillImpl(uint* state, uint* buffer, uint* bufferEnd, int index)
        {
            do
            {
                if (index == N)
                {
                    UpdateStateImpl(state);
                    index = 1;
                    *buffer = Temper(*state);
                }
                else
                {
                    *buffer = Temper(state[index]);
                    ++index;
                }
            }
            while (++buffer != bufferEnd);
            return index;
        }

        private static uint Temper(uint y)
        {
            y ^= y >> 11;
            y ^= (y << 7) & 0x9d2c5680;
            y ^= (y << 15) & 0xefc60000;
            y ^= y >> 18;
            return y;
        }

        /// <summary>
        /// The implementation of <see cref="UpdateState"/>.
        /// </summary>
        /// <param name="mt">
        /// A pointer to the first element in the state. The name mt is retained from the original c code.
        /// </param>
        private static unsafe void UpdateStateImpl(uint* mt)
        {
            var p0 = mt;
            var p1 = mt + 1;
            var p2 = mt + M;
            uint y;

            var counter = N - M;
            do
            {
                y = (*p0 & UpperMask) | (*p1 & LowerMask);
                *p0 = *p2 ^ (y >> 1) ^ ((y & 0x1U) == 0U ? 0x0U : MatrixA);
                ++p0;
                ++p1;
                ++p2;
            }
            while (--counter != 0);

            p2 = mt;
            counter = M - 1;
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

        /// <summary>
        /// Advances the state by recalculating the state. This is used when the end of the state has been reached in
        /// order to update state values.
        /// </summary>
        /// <param name="state">
        /// The state array to update.
        /// </param>
        private static void UpdateState(uint[] state)
        {
            unsafe
            {
                fixed (uint* s = state)
                {
                    MersenneTwister19937.UpdateStateImpl(s);
                }
            }
        }

        /// <summary>
        /// The implementation of the <see cref="InitByArray"/> initialization procedure.
        /// </summary>
        /// <param name="mt">
        /// A pointer to the first element in the state. The name mt is retained from the original c code.
        /// </param>
        /// <param name="initKey">
        /// A pointer to the first element in the provided array of seeds.
        /// </param>
        /// <param name="keyLength">
        /// The number of seeds in the provided array of seeds.
        /// </param>
        private static unsafe void InitByArrayImpl(uint* mt, uint* initKey, uint keyLength)
        {
            MersenneTwister19937.InitGenRandImpl(mt, 19650218U);
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

        /// <summary>
        /// The implementation of <see cref="InitGenRand"/>.
        /// </summary>
        /// <param name="mt">
        /// A pointer to the first element in the state. The name mt is retained from the original c code.
        /// </param>
        /// <param name="seed">
        /// The seed.
        /// </param>
        private static unsafe void InitGenRandImpl(uint* mt, uint seed)
        {
            mt[0] = seed;
            for (uint mti = 1; mti < N; mti++)
            {
                mt[mti] = (1812433253U * (mt[mti - 1] ^ (mt[mti - 1] >> 30))) + mti;
            }
        }
    }
}
