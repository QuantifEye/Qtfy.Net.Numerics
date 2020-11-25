// <copyright file="BigRational.ToFloatingPoint.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath
{
    using System;
    using System.Diagnostics;
    using System.Numerics;

    /// <summary>
    /// A structure that represents a rational number with an arbitrarily large numerator and denominator.
    /// </summary>
    public partial struct BigRational
    {
        /// <summary>
        /// Converts a <see cref="BigRational"/> to a <see cref="double"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="BigRational"/> to convert.
        /// </param>
        /// <returns>
        /// The value of the provided <see cref="BigRational"/> converted to a <see cref="double"/>.
        /// </returns>
        /// <remarks>
        /// Converts a <see cref="BigRational"/> to a <see cref="double"/>. If the value is half way between two
        /// prospective double values, the value is rounded to the even value (Bankers Rounding).
        /// </remarks>
        public static explicit operator double(BigRational value)
        {
            const int maxExp = 1023;
            const int minExp = -1022;
            const int exponentBits = 11;
            const int fractionBits = 52;
            const long fractionBitsMask = (1L << fractionBits) - 1L;
            const int extraBits = 8;
            const int extraBitsMask = (1 << extraBits) - 1;

            int sign = value.Sign;
            if (value.denominator.IsZero)
            {
                throw new DivideByZeroException();
            }

            if (value.numerator.IsZero)
            {
                // TODO: negative zero
                return 0d;
            }

            var a = BigInteger.Abs(value.numerator);
            var b = BigInteger.Abs(value.denominator);
            var aBits = a.GetBitLength();
            var bBits = b.GetBitLength();

            if (aBits - bBits > maxExp)
            {
                return sign * double.PositiveInfinity;
            }

            if (aBits - bBits < minExp)
            {
                return 0d / sign;
            }

            int shift = (int)(aBits - bBits) - fractionBits - extraBits;
            var x = (long)((shift <= 0 ? a << -shift : a >> shift) / b);
            long extra = x & extraBitsMask;
            x = (x >> extraBits) - (1L << fractionBits);
            Debug.Assert(x <= fractionBitsMask, "1 <= x 2 ^ -52 < 2");

            if ((extra >> (extraBits - 1) == 1) && ((extra > (1 << (extraBits - 1))) || ((x & 1) == 1)))
            {
                ++x;
            }

            if (x >> fractionBits != 0)
            {
                ++aBits;
                if (aBits - bBits > maxExp)
                {
                    return sign * double.PositiveInfinity;
                }
            }

            long dbl = x | ((aBits - bBits - minExp + 1) << fractionBits);
            if (sign == -1)
            {
                dbl |= 1L << (fractionBits + exponentBits);
            }

            return BitConverter.Int64BitsToDouble(dbl);
        }

        /// <summary>
        /// Converts a <see cref="BigRational"/> to a <see cref="float"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="BigRational"/> to convert.
        /// </param>
        /// <returns>
        /// The value of the provided <see cref="BigRational"/> converted to a float.
        /// </returns>
        /// <remarks>
        /// The implementation relies on the implementation of the conversion operator that converts
        /// a <see cref="BigRational"/> to a double.
        /// </remarks>
        public static explicit operator float(BigRational value)
        {
            return (float)(double)value;
        }
    }
}