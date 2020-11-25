// <copyright file="BigRational.FromFloatingPoint.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath
{
    /// <summary>
    /// A structure that represents a rational number with an arbitrarily large numerator and denominator.
    /// </summary>
    public partial struct BigRational
    {
        /// <summary>
        /// An array of rationals such that array[i] == Pow(2, -i).
        /// </summary>
        /// <remarks>
        /// A cache of the powers of two needed to convert a floating point number to a
        /// <see cref="BigRational"/>.
        /// </remarks>
        private static readonly BigRational[] NegativePowerOfTwo = BuildNegativePowersOfTwo();

        /// <summary>
        /// Converts a <see cref="double"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="d">
        /// The <see cref="double"/> to convert.
        /// </param>
        public static implicit operator BigRational(double d)
        {
            ulong bits;
            unsafe
            {
                bits = *(ulong*)&d;
            }

            var m = One;
            for (var i = 1; i != 53; ++i)
            {
                if ((bits & (0x1UL << (52 - i))) != 0)
                {
                    m += NegativePowerOfTwo[i];
                }
            }

            return d.CompareTo(0) * m * Pow(2, (int)((bits >> 52) & 0b0000_0111_1111_1111UL) - 1023);
        }

        /// <summary>
        /// Converts a <see cref="float"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="d">
        /// The <see cref="float"/> to convert.
        /// </param>
        public static implicit operator BigRational(float d)
        {
            return (double)d;
        }

        /// <summary>
        /// Builds a cache of the negative powers of 2.
        /// </summary>
        /// <returns>
        /// An array of rationals such that array[i] == Pow(2, -i).
        /// </returns>
        private static BigRational[] BuildNegativePowersOfTwo()
        {
            var array = new BigRational[53];
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = Pow(2, -i);
            }

            return array;
        }
    }
}