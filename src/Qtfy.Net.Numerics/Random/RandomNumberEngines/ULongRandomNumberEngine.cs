// <copyright file="ULongRandomNumberEngine.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.RandomNumberEngines
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// A base class for all random bit generators that generate uniformly distributed values.
    /// </summary>
    public abstract class ULongRandomNumberEngine : RandomNumberEngineBase
    {
        /// <inheritdoc />
        public sealed override long NextLong()
        {
            unchecked
            {
                return long.MinValue + (long)this.NextULong();
            }
        }

        /// <inheritdoc />
        public sealed override uint NextUInt()
        {
            // TODO: check if this can be replaces with
            // return (uint)(this.NextUlong() >> 32)
            // This will break gcc compatibility, but could be significantly faster
            unchecked
            {
                const ulong range = (ulong)uint.MaxValue + 1UL;
                const ulong scaling = ulong.MaxValue / range;
                const ulong last = range * scaling;
                ulong result;
                do
                {
                    result = this.NextULong();
                }
                while (result >= last);

                return (uint)(result / scaling);
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

        private ulong NextULongImpl(ulong max)
        {
            Debug.Assert(max != ulong.MaxValue, "range check");
            unchecked
            {
                var range = max + 1UL;
                var scaling = ulong.MaxValue / range;
                var last = range * scaling;
                ulong result;
                do
                {
                    result = this.NextULong();
                }
                while (result >= last);

                return result / scaling;
            }
        }

        /// <inheritdoc />
        public sealed override ulong NextULong(ulong max)
        {
            return max == ulong.MaxValue
                ? this.NextULong()
                : this.NextULongImpl(max);
        }

        /// <inheritdoc />
        public sealed override long NextLong(long max)
        {
            return max < 0L
                ? throw new ArgumentException("max must be non negative")
                : (long)this.NextULongImpl((ulong)max);
        }

        /// <inheritdoc/>
        public sealed override uint NextUInt(uint max)
        {
            return (uint)this.NextULongImpl(max);
        }


        /// <inheritdoc />
        public sealed override int NextInt(int max)
        {
            unchecked
            {
                return max < 0L
                    ? throw new ArgumentException("max must be non-negative")
                    : (int)this.NextULongImpl((ulong)max);
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
        public sealed override long NextLong(long min, long max)
        {
            unchecked
            {
                return max < min
                    ? throw new ArgumentException("min must be less than or equal to max", nameof(min))
                    : min + (long)this.NextULong((ulong)(max - min));
            }
        }

        /// <inheritdoc />
        public sealed override uint NextUInt(uint min, uint max)
        {
            unchecked
            {
                return max < min
                    ? throw new ArgumentException("min must be less than or equal to max", nameof(min))
                    : min + (uint)this.NextULongImpl(max - min);
            }
        }

        /// <inheritdoc />
        public sealed override int NextInt(int min, int max)
        {
            unchecked
            {
                return max < min
                    ? throw new ArgumentException("min must be less than or equal to max", nameof(min))
                    : (int)((ulong)min + this.NextULongImpl((ulong)max - (ulong)min));
            }
        }
    }
}
