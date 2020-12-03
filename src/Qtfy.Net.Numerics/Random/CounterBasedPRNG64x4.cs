// <copyright file="CounterBasedPRNG64x4.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

using System;
using System.Runtime.CompilerServices;


namespace Qtfy.Net.Numerics.Random
{
    public abstract class CounterBasedPRNG64x4 : IRandomBitGenerator<ulong>
    {
        public struct  Counter
        {
            public ulong Word0;

            public ulong Word1;

            public ulong Word2;

            public ulong Word3;

            public Counter(ulong word0, ulong word1, ulong word2, ulong word3)
            {
                Word0 = word0;
                Word1 = word1;
                Word2 = word2;
                Word3 = word3;
            }

            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            public Counter IncrementCounter()
            {
                if (++this.Word0 == 0UL)
                {
                    if (++this.Word1 == 0UL)
                    {
                        if (++this.Word2 == 0UL)
                        {
                            ++this.Word3;
                        }
                    }
                }

                return this;
            }
        }

        private int position;

        private Counter ctr;

        private Counter buffer;

        private readonly Counter key;

        protected CounterBasedPRNG64x4(ulong word0, ulong word1, ulong word2, ulong word3)
        {
            this.key = new Counter(word0, word1, word2, word3);
            this.ctr = default;
            this.position = 0;
        }

        /// <inheritdoc />
        public abstract Counter Bijection(Counter ctr, Counter key);

        public ulong Next()
        {
            throw new NotImplementedException();
        }
    }

    public sealed class ThreeFryGenerator64x4 : CounterBasedPRNG64x4
    {
        public ThreeFryGenerator64x4(ulong word0, ulong word1, ulong word2, ulong word3) :
            base(word0, word1, word2, word3)
        {
        }

        /// <inheritdoc />
        public override Counter Bijection(Counter ctr, Counter key)
        {
            throw new NotImplementedException();
        }
    }
}
