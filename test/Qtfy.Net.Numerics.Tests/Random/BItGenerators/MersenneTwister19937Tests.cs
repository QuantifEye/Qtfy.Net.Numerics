// <copyright file="MersenneTwister19937Tests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

// The following comment relates to the code found in the methods
//  - MersenneTwister19937Tests.Original
//  - MersenneTwister19937Tests.BenchmarkInitGenRand
//  - MersenneTwister19937Tests.BenchmarkInitByArray

/*
    A C-program for MT19937, with initialization improved 2002/1/26.
    Coded by Takuji Nishimura and Makoto Matsumoto.

    Before using, initialize the state by using init_genrand(seed)
    or init_by_array(init_key, key_length).

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

namespace Qtfy.Net.Numerics.Tests.Random.BitGenerators
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using Qtfy.Net.Numerics.Random.BitGenerators;

    public class MersenneTwister19937Tests
    {
        private enum SeedMethod
        {
            InitGenRand,
            InitByArray,
        }

        [TestCase(1234U)]
        public void InitGenRandTest(uint seed)
        {
            // the number of random numbers to test
            // This is chosen so that the state is cycled twice.
            const int size = 1400;

            var generator = MersenneTwister19937.InitGenRand(seed);
            Assert.AreEqual(
                OriginalInitGenRand(seed, size),
                GetRandomValues(generator, size));
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(622)]
        [TestCase(623)]
        [TestCase(624)]
        [TestCase(625)]
        [TestCase(626)]
        public void InitByArrayTest(int seedSize)
        {
            // the number of random numbers to test
            // This is chosen so that the state is cycled twice.
            const int size = 1400;

            var seeds = OriginalInitGenRand(1, seedSize);
            var generator = MersenneTwister19937.InitByArray(seeds);
            var actual = GetRandomValues(generator, size);
            var expected = OriginalInitByArray(seeds, size);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void InitByArrayNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => MersenneTwister19937.InitByArray(null));
        }

        [TestCase(1234U, 0)]
        [TestCase(1234U, 5)]
        [TestCase(1234U, 700)]
        [TestCase(1234U, 1400)]
        public void TestFill(uint seed, int size)
        {
            var expectedGenerator = MersenneTwister19937.InitGenRand(seed);
            var expected = GetRandomValues(expectedGenerator, size);
            var actualGenerator = MersenneTwister19937.InitGenRand(seed);
            var actual = new uint[size];
            actualGenerator.Fill(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestFillNull()
        {
            var generator = MersenneTwister19937.InitGenRand(1234);
            Assert.Throws<ArgumentNullException>(
                () => generator.Fill(null));
        }

        private static uint[] GetRandomValues(MersenneTwister19937 generator, int size)
        {
            var actual = new uint[size];
            for (int i = 0; i < actual.Length; ++i)
            {
                actual[i] = generator.GetBits();
            }

            return actual;
        }

        private static uint[] OriginalInitGenRand(uint seed, int outputSize)
        {
            return Original(
                outputSize: outputSize,
                seed: seed,
                method: SeedMethod.InitGenRand);
        }

        private static uint[] OriginalInitByArray(uint[] seeds, int outputSize)
        {
            return Original(
                outputSize: outputSize,
                seeds: seeds.Select(i => (ulong)i).ToArray(),
                method: SeedMethod.InitByArray);
        }

#pragma warning disable
        /// <summary>
        /// This code in this method is taken from the c code published by the authors of the mersenne twister.
        /// It is edited as little as possible, (just enough to make it work in c#). Hence the warning disable pragma
        /// It is intended to test the c# implementation of the generator.
        /// </summary>
        private static uint[] Original(int outputSize, ulong seed = default, ulong[] seeds = default,
            SeedMethod method = default)
        {
            /*
               A C-program for MT19937, with initialization improved 2002/1/26.
               Coded by Takuji Nishimura and Makoto Matsumoto.

               Before using, initialize the state by using init_genrand(seed)
               or init_by_array(init_key, key_length).

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

            /* Period parameters */
            const int N = 624;
            const int M = 397;
            const ulong MATRIX_A = 0x9908b0dfUL; /* constant vector a */
            const ulong UPPER_MASK = 0x80000000UL; /* most significant w-r bits */
            const ulong LOWER_MASK = 0x7fffffffUL; /* least significant r bits */

            ulong[] mt = new ulong [N]; /* the array for the state vector  */
            int mti = N + 1; /* mti==N+1 means mt[N] is not initialized */

            /* initializes mt[N] with a seed */
            void init_genrand(ulong s)
            {
                mt[0] = s & 0xffffffffUL;
                for (mti = 1; mti < N; mti++)
                {
                    mt[mti] =
                        (1812433253UL * (mt[mti - 1] ^ (mt[mti - 1] >> 30)) + (ulong) mti);
                    /* See Knuth TAOCP Vol2. 3rd Ed. P.106 for multiplier. */
                    /* In the previous versions, MSBs of the seed affect   */
                    /* only MSBs of the array mt[].                        */
                    /* 2002/01/09 modified by Makoto Matsumoto             */
                    mt[mti] &= 0xffffffffUL;
                    /* for >32 bit machines */
                }
            }

            /* initialize by an array with array-length */
            /* init_key is the array for initializing keys */
            /* key_length is its length */
            /* slight change for C++, 2004/2/26 */
            void init_by_array(ulong[] init_key)
            {
                int key_length = init_key.Length;
                int i, j, k;
                init_genrand(19650218UL);
                i = 1;
                j = 0;
                k = (N > key_length ? N : key_length);
                for (; k != 0; k--)
                {
                    mt[i] = (mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) * 1664525UL))
                            + init_key[j] + (ulong) j; /* non linear */
                    mt[i] &= 0xffffffffUL; /* for WORDSIZE > 32 machines */
                    i++;
                    j++;
                    if (i >= N)
                    {
                        mt[0] = mt[N - 1];
                        i = 1;
                    }

                    if (j >= key_length) j = 0;
                }

                for (k = N - 1; k != 0; k--)
                {
                    mt[i] = (mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) * 1566083941UL))
                            - (ulong) i; /* non linear */
                    mt[i] &= 0xffffffffUL; /* for WORDSIZE > 32 machines */
                    i++;
                    if (i >= N)
                    {
                        mt[0] = mt[N - 1];
                        i = 1;
                    }
                }

                mt[0] = 0x80000000UL; /* MSB is 1; assuring non-zero initial array */
            }

            /* generates a random number on [0,0xffffffff]-interval */
            ulong genrand_int32()
            {
                ulong y;
                ulong[] mag01 = new ulong[2] {0x0UL, MATRIX_A};
                /* mag01[x] = x * MATRIX_A  for x=0,1 */

                if (mti >= N)
                {
                    /* generate N words at one time */
                    int kk;

                    if (mti == N + 1) /* if init_genrand() has not been called, */
                        init_genrand(5489UL); /* a default initial seed is used */

                    for (kk = 0; kk < N - M; kk++)
                    {
                        y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
                        mt[kk] = mt[kk + M] ^ (y >> 1) ^ mag01[y & 0x1UL];
                    }

                    for (; kk < N - 1; kk++)
                    {
                        y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
                        mt[kk] = mt[kk + (M - N)] ^ (y >> 1) ^ mag01[y & 0x1UL];
                    }

                    y = (mt[N - 1] & UPPER_MASK) | (mt[0] & LOWER_MASK);
                    mt[N - 1] = mt[M - 1] ^ (y >> 1) ^ mag01[y & 0x1UL];

                    mti = 0;
                }

                y = mt[mti++];

                /* Tempering */
                y ^= (y >> 11);
                y ^= (y << 7) & 0x9d2c5680UL;
                y ^= (y << 15) & 0xefc60000UL;
                y ^= (y >> 18);

                return y;
            }

            switch (method)
            {
                case SeedMethod.InitGenRand:
                    init_genrand(seed);
                    break;
                case SeedMethod.InitByArray:
                    init_by_array(seeds);
                    break;
            }

            uint[] result = new uint[outputSize];
            for (int i = 0; i < result.Length; ++i)
            {
                result[i] = (uint) genrand_int32();
            }

            return result;
        }
#pragma warning restore
    }
}
