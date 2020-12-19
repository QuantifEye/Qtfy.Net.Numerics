// <copyright file="MersenneTwister19937.InitGenRandSeedSequence.cs" company="QuantifEye">
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
        /// In the original code this method was called "init_genrand".
        /// </summary>
        /// <remarks>
        /// This may be made public in the future which is why it is not just a static method
        /// used by MersenneTwister.
        /// </remarks>
        private class InitGenRandSeedSequence : ISeedSequence<uint>
        {
            private readonly uint seed;

            /// <summary>
            /// Initializes a new instance of the <see cref="InitGenRandSeedSequence"/> class.
            /// </summary>
            /// <param name="seed">
            /// The seed used to construct this seed sequence.
            /// </param>
            public InitGenRandSeedSequence(uint seed)
            {
                this.seed = seed;
            }

            /// <inheritdoc />
            public uint[] Generate(int resultSize)
            {
                // TODO: should we hardcode the resultSize as the size of the mersenne twister
                // internal array for performance?
                // This sounds reasonable because this seed sequence is added to allow reproducible
                // MersenneTwister19937 32 numbers.
                if (resultSize < 0)
                {
                    throw new ArgumentException("must be non negative", nameof(resultSize));
                }

                var result = new uint[resultSize];
                unsafe
                {
                    fixed (uint* mt = result)
                    {
                        GenerateImpl(mt, (uint)resultSize, this.seed);
                    }
                }

                return result;
            }

            /// <summary>
            /// The implementation of the generate method. The logic for this method can be found in the
            /// initial c code by the name init_genrand(...).
            /// The unit tests contains a copy of this code ported to c#.
            /// </summary>
            /// <param name="mt">The array to fill with generated numbers.</param>
            /// <param name="resultSize">The size of mt.</param>
            /// <param name="seed">The seed used as entropy.</param>
            internal static unsafe void GenerateImpl(uint* mt, uint resultSize, uint seed)
            {
                mt[0] = seed;
                for (uint mti = 1; mti < resultSize; mti++)
                {
                    mt[mti] = (1812433253U * (mt[mti - 1] ^ (mt[mti - 1] >> 30))) + mti;
                }
            }
        }
    }
}
