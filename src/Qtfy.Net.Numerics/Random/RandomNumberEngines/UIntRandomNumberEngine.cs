// <copyright file="UIntRandomNumberEngine.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.RandomNumberEngines
{
    using System;

    /// <summary>
    /// A base class for all random bit generators that generate uniformly distributed values.
    /// </summary>
    public abstract class UIntRandomNumberEngine : RandomNumberEngineBase
    {
        /// <inheritdoc/>
        public sealed override ulong NextULong()
        {
            ulong w1 = this.NextUInt();
            ulong w2 = this.NextUInt();
            return (w1 << 32) | w2;
        }

        /// <inheritdoc />
        public sealed override long NextLong()
        {
            unchecked
            {
                return long.MinValue + (long)this.NextULong();
            }
        }


        /// <inheritdoc />
        public sealed override int NextInt()
        {
            unchecked
            {
                return int.MinValue + (int)this.NextUInt();
            }
        }

        private uint NextUIntImpl(uint upper)
        {
            unchecked
            {
                var range = upper + 1u;
                var scaling = uint.MaxValue / range;
                var last = range * scaling;
                uint temp;
                do
                {
                    temp = this.NextUInt();
                }
                while (temp >= last);

                return temp / scaling;
            }
        }

        /// <inheritdoc />
        public sealed override ulong NextULong(ulong max)
        {
            ulong result;
            if (max == ulong.MaxValue)
            {
                result = this.NextULong();
            }
            else if (max <= uint.MaxValue)
            {
                result = this.NextUInt((uint)max);
            }
            else
            {
                var upperMax = (uint)(max >> 32);
                if (upperMax != uint.MaxValue)
                {
                    var range = upperMax + 1UL;
                    var scaling = uint.MaxValue / range;
                    var last = range * scaling;
                    ulong temp;
                    do
                    {
                        do
                        {
                            temp = this.NextUInt();
                        }
                        while (temp >= last);

                        result = ((temp / scaling) << 32) + this.NextUInt();
                    }
                    while (result > max);
                }
                else
                {
                    do
                    {
                        result = (ulong)this.NextUInt() << 32;
                        result += this.NextUInt();
                    }
                    while (result > max);
                }
            }

            return result;
        }

        /// <inheritdoc />
        public sealed override int NextInt(int max)
        {
            unchecked
            {
                return max < 0
                    ? throw new ArgumentException("max must be greater than or equal to zero")
                    : (int)this.NextUIntImpl((uint)max);
            }
        }

        /// <inheritdoc />
        public sealed override uint NextUInt(uint max)
        {
            return max == uint.MaxValue
                ? this.NextUInt()
                : this.NextUIntImpl(max);
        }

        /// <inheritdoc />
        public sealed override long NextLong(long max)
        {
            return max < 0
                ? throw new ArgumentException()
                : (long)this.NextULong((ulong)max);
        }


        /// <inheritdoc />
        public sealed override uint NextUInt(uint min, uint max)
        {
            unchecked
            {
                return max < min
                    ? throw new ArgumentException("min must be less than or equal to max", nameof(min))
                    : min + this.NextUInt(max - min);
            }
        }

        /// <inheritdoc />
        public sealed override ulong NextULong(ulong min, ulong max)
        {
            unchecked
            {
                return max < min
                    ? throw new ArgumentException("min must be less than or equal to max", nameof(min))
                    : min + this.NextULong(max - min);
            }
        }


        /// <inheritdoc />
        public sealed override int NextInt(int min, int max)
        {
            unchecked
            {
                return max < min
                    ? throw new ArgumentException("min must be less than or equal to max", nameof(min))
                    : min + (int)this.NextUInt((uint)(max - min));
            }
        }

        /// <inheritdoc />
        public sealed override long NextLong(long min, long max)
        {
            unchecked
            {
                return max < min
                    ? throw new ArgumentException("min must be less than or equal to max", nameof(min))
                    : min + (long)this.NextULong((ulong)(max - min));
            }
        }
    }
}
