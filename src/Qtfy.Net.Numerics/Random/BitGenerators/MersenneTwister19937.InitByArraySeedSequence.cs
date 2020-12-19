// <copyright file="MersenneTwister19937.InitByArraySeedSequence.cs" company="QuantifEye">
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

namespace Qtfy.Net.Numerics.Random.BitGenerators
{
    using System;

    public sealed partial class MersenneTwister19937
    {
        /// <summary>
        /// This seed sequence provides the algorithm used to initialize the Mersenne Twister
        /// in the original c implementation.
        /// In the original code this method was called "init_by_array".
        /// </summary>
        /// <remarks>
        /// This may be made public in the future which is why it is not just a static method
        /// used by MersenneTwister.
        /// </remarks>
        private class InitByArraySeedSequence : ISeedSequence<uint>
        {
            private readonly uint[] seeds;

            /// <summary>
            /// Initializes a new instance of the <see cref="InitByArraySeedSequence"/> class.
            /// </summary>
            /// <param name="seeds">
            /// The seed data used as entropy.
            /// </param>
            public InitByArraySeedSequence(uint[] seeds)
            {
                this.seeds = seeds;
            }

            /// <inheritdoc />
            public uint[] Generate(int resultSize)
            {
                if (resultSize < 0)
                {
                    throw new ArgumentException("must be non negative", nameof(resultSize));
                }

                var result = new uint[resultSize];
                unsafe
                {
                    fixed (uint* mt = result, initKey = this.seeds)
                    {
                        GenerateImpl(mt, (uint)resultSize, initKey, (uint)this.seeds.Length);
                    }
                }

                return result;
            }

            private static unsafe void GenerateImpl(uint* mt, uint resultSize, uint* initKey, uint keyLength)
            {
                InitGenRandSeedSequence.GenerateImpl(mt, resultSize, 19650218U);
                var i = 1U;
                var j = 0U;
                var k = keyLength > resultSize ? keyLength : resultSize;
                for (; k != 0; k--)
                {
                    mt[i] = (mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) * 1664525U)) + initKey[j] + j;
                    if (++i >= resultSize)
                    {
                        mt[0] = mt[resultSize - 1];
                        i = 1;
                    }

                    if (++j >= keyLength)
                    {
                        j = 0;
                    }
                }

                for (k = resultSize - 1; k != 0; k--)
                {
                    mt[i] = (mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) * 1566083941U)) - i;
                    if (++i >= resultSize)
                    {
                        mt[0] = mt[resultSize - 1];
                        i = 1;
                    }
                }

                mt[0] = 0x1U << 31;
            }
        }
    }
}
