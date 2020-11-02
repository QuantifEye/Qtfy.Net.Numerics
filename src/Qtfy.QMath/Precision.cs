// <copyright file="Precision.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Utility methods related to the precision of floating point values.
    /// </summary>
    public static class Precision
    {
        /// <summary>
        /// Finds the smallest value in the set of all possible <see cref="double"/>
        /// values that is greater than <paramref name="self"/>.
        /// </summary>
        /// <param name="self">
        /// The double being extended.
        /// </param>
        /// <returns>
        /// The smallest value in the set of all possible <see cref="double"/>
        /// values that is greater than <paramref name="self"/>.
        /// </returns>
        public static double Increment(this double self)
        {
            if (double.IsInfinity(self) || double.IsNaN(self))
            {
                return self;
            }
            else if (self == 0d)
            {
                return double.Epsilon;
            }
            else if (self == double.MaxValue)
            {
                return double.PositiveInfinity;
            }

            long bits = BitConverter.DoubleToInt64Bits(self);
            return self > 0
                ? BitConverter.Int64BitsToDouble(bits + 1)
                : BitConverter.Int64BitsToDouble(bits - 1);
        }

        /// <summary>
        /// Finds the greatest value in the set of all possible <see cref="double"/>
        /// values that is smaller than <paramref name="self"/>.
        /// </summary>
        /// <param name="self">
        /// The double being extended.
        /// </param>
        /// <returns>
        /// The greatest value in the set of all possible <see cref="double"/>
        /// values that is smaller than <paramref name="self"/>.
        /// </returns>
        public static double Decrement(this double self)
        {
            if (double.IsInfinity(self) || double.IsNaN(self))
            {
                return self;
            }
            else if (self == 0d)
            {
                return -double.Epsilon;
            }
            else if (self == double.MinValue)
            {
                return double.NegativeInfinity;
            }

            long bits = BitConverter.DoubleToInt64Bits(self);
            return self > 0
                ? BitConverter.Int64BitsToDouble(bits - 1)
                : BitConverter.Int64BitsToDouble(bits + 1);
        }
    }
}
