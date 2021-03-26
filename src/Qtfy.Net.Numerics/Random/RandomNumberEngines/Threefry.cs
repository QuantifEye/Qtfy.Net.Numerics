// <copyright file="ThreeFry4x64.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.RandomNumberEngines
{
    using System;

    public sealed class ThreeFry4x64 : ULongRandomNumberEngine
    {
        private const nint idx = 0;
        private const nint spare0 = 1;
        private const nint spare1 = 2;
        private const nint spare2 = 3;
        private const nint key0 = 4;
        private const nint key1 = 5;
        private const nint key2 = 6;
        private const nint key3 = 7;
        private const nint key4 = 8;
        private const nint ctr0 = 9;
        private const nint ctr1 = 10;
        private const nint ctr2 = 11;
        private const nint ctr3 = 12;

        private readonly ulong[] state;

        public ThreeFry4x64(ulong[] key)
        {
            var state = new ulong[13];
            var span = state.AsSpan((int)key0, 5);
            var back = 0x1BD11BDAA9FC1A22UL;
            for (int i = 0; i < 4; ++i)
            {
                span[i] = key[i];
                back ^= key[i];
            }

            span[4] = back;
            state[idx] = 4;
            this.state = state;
        }

        /// <inheritdoc />
        public override ulong NextULong()
        {
            unchecked
            {
                unsafe
                {
                    fixed (ulong* state = this.state)
                    {
                        var i = ++state[idx];
                        if (i != 4UL)
                        {
                            return state[i];
                        }
                        else
                        {
                            state[idx] = 0UL;

                            var k0 = state[key0];
                            var k1 = state[key1];
                            var k2 = state[key2];
                            var k3 = state[key3];
                            var k4 = state[key4];
                            var c0 = state[ctr0];
                            var c1 = state[ctr1];
                            var c2 = state[ctr2];
                            var c3 = state[ctr3];

                            if (++state[c0] == 0U)
                            {
                                if (++state[c1] == 0U)
                                {
                                    if (++state[c2] == 0U)
                                    {
                                        ++state[c3];
                                    }
                                }
                            }

                            c0 += c1;
                            c1 = (c1 << 50 | c1 >> 14) ^ c0;
                            c2 += c3;
                            c3 = (c3 << 48 | c3 >> 16) ^ c2;
                            c0 += c1;
                            c3 = (c3 << 12 | c3 >> 52) ^ c0;
                            c2 += c3;
                            c1 = (c1 << 7 | c1 >> 57) ^ c2;
                            c0 += c1;
                            c1 = (c1 << 41 | c1 >> 23) ^ c0;
                            c2 += c3;
                            c3 = (c3 << 24 | c3 >> 40) ^ c2;
                            c0 += c1;
                            c3 = (c3 << 59 | c3 >> 5) ^ c0;
                            c2 += c3;
                            c1 = (c1 << 27 | c1 >> 37) ^ c2;
                            c0 += k1;
                            c1 += k2;
                            c2 += k3;
                            c3 += k4 + 1UL;
                            c0 += c1;
                            c1 = (c1 << 50 | c1 >> 14) ^ c0;
                            c2 += c3;
                            c3 = (c3 << 48 | c3 >> 16) ^ c2;
                            c0 += c1;
                            c3 = (c3 << 12 | c3 >> 52) ^ c0;
                            c2 += c3;
                            c1 = (c1 << 7 | c1 >> 57) ^ c2;
                            c0 += c1;
                            c1 = (c1 << 41 | c1 >> 23) ^ c0;
                            c2 += c3;
                            c3 = (c3 << 24 | c3 >> 40) ^ c2;
                            c0 += c1;
                            c3 = (c3 << 59 | c3 >> 5) ^ c0;
                            c2 += c3;
                            c1 = (c1 << 27 | c1 >> 37) ^ c2;
                            c0 += k2;
                            c1 += k3;
                            c2 += k4;
                            c3 += k0 + 2UL;
                            c0 += c1;
                            c1 = (c1 << 50 | c1 >> 14) ^ c0;
                            c2 += c3;
                            c3 = (c3 << 48 | c3 >> 16) ^ c2;
                            c0 += c1;
                            c3 = (c3 << 12 | c3 >> 52) ^ c0;
                            c2 += c3;
                            c1 = (c1 << 7 | c1 >> 57) ^ c2;
                            c0 += c1;
                            c1 = (c1 << 41 | c1 >> 23) ^ c0;
                            c2 += c3;
                            c3 = (c3 << 24 | c3 >> 40) ^ c2;
                            c0 += c1;
                            c3 = (c3 << 59 | c3 >> 5) ^ c0;
                            c2 += c3;
                            c1 = (c1 << 27 | c1 >> 37) ^ c2;
                            c0 += k3;
                            c1 += k4;
                            c2 += k0;
                            c3 += k1 + 3UL;
                            c0 += c1;
                            c1 = (c1 << 50 | c1 >> 14) ^ c0;
                            c2 += c3;
                            c3 = (c3 << 48 | c3 >> 16) ^ c2;
                            c0 += c1;
                            c3 = (c3 << 12 | c3 >> 52) ^ c0;
                            c2 += c3;
                            c1 = (c1 << 7 | c1 >> 57) ^ c2;
                            c0 += c1;
                            c1 = (c1 << 41 | c1 >> 23) ^ c0;
                            c2 += c3;
                            c3 = (c3 << 24 | c3 >> 40) ^ c2;
                            c0 += c1;
                            c3 = (c3 << 59 | c3 >> 5) ^ c0;
                            c2 += c3;
                            c1 = (c1 << 27 | c1 >> 37) ^ c2;
                            c0 += k4;
                            c1 += k0;
                            c2 += k1;
                            c3 += k2 + 4UL;
                            c0 += c1;
                            c1 = (c1 << 50 | c1 >> 14) ^ c0;
                            c2 += c3;
                            c3 = (c3 << 48 | c3 >> 16) ^ c2;
                            c0 += c1;
                            c3 = (c3 << 12 | c3 >> 52) ^ c0;
                            c2 += c3;
                            c1 = (c1 << 7 | c1 >> 57) ^ c2;
                            c0 += c1;
                            c1 = (c1 << 41 | c1 >> 23) ^ c0;
                            c2 += c3;
                            c3 = (c3 << 24 | c3 >> 40) ^ c2;
                            c0 += c1;
                            c3 = (c3 << 59 | c3 >> 5) ^ c0;
                            c2 += c3;
                            c1 = (c1 << 27 | c1 >> 37) ^ c2;
                            c0 += k0;
                            c1 += k1;
                            c2 += k2;
                            c3 += k3 + 5UL;

                            state[spare0] = c1;
                            state[spare1] = c2;
                            state[spare2] = c3;
                            return c0;
                        }
                    }
                }
            }
        }
    }
}
