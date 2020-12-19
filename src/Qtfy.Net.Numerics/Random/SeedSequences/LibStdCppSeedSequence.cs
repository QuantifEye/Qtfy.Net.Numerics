// <copyright file="LibStdCppSeedSequence.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.SeedSequences
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// a <see cref="uint"/> seed sequence. <see cref="ISeedSequence{T}"/>.
    /// </summary>
    [CLSCompliant(false)]
    public class LibStdCppSeedSequence : ISeedSequence<uint>
    {
        private readonly uint[] entropy;

        /// <summary>
        /// Initializes a new instance of the <see cref="LibStdCppSeedSequence"/> class.
        /// </summary>
        /// <param name="seeds">
        /// The seeds to construct the seed sequence with.
        /// </param>
        public LibStdCppSeedSequence(IEnumerable<uint> seeds)
        {
            if (seeds is null)
            {
                throw new ArgumentNullException(nameof(seeds));
            }

            this.entropy = seeds.ToArray();
            if (this.entropy.Length == 0)
            {
                throw new ArgumentException("Must provide entropy.");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LibStdCppSeedSequence"/> class.
        /// </summary>
        /// <param name="seeds">
        /// The seeds to construct the seed sequence with.
        /// </param>
        public LibStdCppSeedSequence(params uint[] seeds)
            : this(seeds.AsEnumerable())
        {
        }

        /// <inheritdoc />
        public uint[] Generate(int resultSize)
        {
            unchecked
            {
                if (resultSize < 0)
                {
                    throw new ArgumentException($"{nameof(resultSize)} must be positive");
                }

                if (resultSize == 0)
                {
                    return Array.Empty<uint>();
                }

                var r = (uint)resultSize;
                var seeds = this.entropy;
                var seedSize = (uint)seeds.Length;

                var result = new uint[r];
                for (var i = 0; i < result.Length; ++i)
                {
                    result[i] = 0x8b8b8b8bu;
                }

                var t = (r >= 623U) ? 11U
                    : (r >= 68U) ? 7U
                    : (r >= 39U) ? 5U
                    : (r >= 7U) ? 3U
                    : (r - 1U) / 2U;
                var p = (r - t) / 2U;
                var q = p + t;

                // k == 0
                var a = result[(0U - 1U) % r] ^ result[0U] ^ result[p % r];
                var r1 = (a ^ (a >> 27)) * 1664525U;
                var r2 = r1 + seedSize;
                result[p % r] += r1;
                result[q % r] += r2;
                result[0U] = r2;

                // k <= seedSize
                var k = 1u;
                for (; k <= seedSize; ++k)
                {
                    a = result[(k - 1U) % r] ^ result[k % r] ^ result[(k + p) % r];
                    r1 = (a ^ (a >> 27)) * 1664525U;
                    r2 = r1 + ((k % r) + seeds[k - 1U]);
                    result[(k + p) % r] += r1;
                    result[(k + q) % r] += r2;
                    result[k % r] = r2;
                }

                // k < maxSize
                var m = Math.Max(seedSize + 1U, r);
                for (; k < m; ++k)
                {
                    a = result[(k - 1U) % r] ^ result[k % r] ^ result[(k + p) % r];
                    r1 = (a ^ (a >> 27)) * 1664525U;
                    r2 = r1 + (k % r);
                    result[(k + p) % r] += r1;
                    result[(k + q) % r] += r2;
                    result[k % r] = r2;
                }

                // k < m + resultSize
                m = m + r;
                for (; k < m; ++k)
                {
                    a = result[(k - 1U) % r] + result[k % r] + result[(k + p) % r];
                    r1 = (a ^ (a >> 27)) * 1566083941U;
                    r2 = r1 - (k % r);
                    result[(k + p) % r] ^= r1;
                    result[(k + q) % r] ^= r2;
                    result[k % r] = r2;
                }

                return result;
            }
        }
    }
}
