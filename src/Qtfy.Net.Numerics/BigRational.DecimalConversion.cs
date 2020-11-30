// <copyright file="BigRational.DecimalConversion.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics
{
    using System;
    using System.Numerics;

    /// <summary>
    /// A structure that represents a rational number with an arbitrarily large numerator and denominator.
    /// </summary>
    public partial struct BigRational
    {
        /// <summary>
        /// The greatest value a <see cref="decimal"/> value can have as a <see cref="BigInteger"/>.
        /// </summary>
        private static readonly BigInteger DecimalMax = (BigInteger)decimal.MaxValue;

        /// <summary>
        /// The smallest value a <see cref="decimal"/> value can have as a <see cref="BigInteger"/>.
        /// </summary>
        private static readonly BigInteger DecimalMin = (BigInteger)decimal.MinValue;

        /// <summary>
        /// Converts a <see cref="decimal"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="decimal"/> to convert.
        /// </param>
        public static implicit operator BigRational(decimal value)
        {
            // there must be a better way than this.
            static byte[] GetBytes(int[] nums)
            {
                var bytes = new byte[16];
                for (var i = 0; i < 4;)
                {
                    var temp = BitConverter.GetBytes(nums[i]);
                    for (var j = 0; j < 4; i++, j++)
                    {
                        bytes[i] = temp[j];
                    }
                }

                return bytes;
            }

            var intArr = decimal.GetBits(value);
            var intPart = new int[3];
            Array.Copy(intArr, intPart, 3);
            var num = new BigInteger(GetBytes(intPart));
            var den = BigInteger.Pow(10, (intArr[3] >> 16) & 0x000000FF);
            return new BigRational(value >= 0 ? num : -num, den);
        }

        /// <summary>
        /// Converts a <see cref="BigRational"/> to a <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="BigRational"/> to convert.
        /// </param>
        /// <exception cref="OverflowException">
        /// A <see cref="OverflowException"/> is raised if the <paramref name="value"/>
        /// is not in the valid range of a <see cref="decimal"/>.
        /// </exception>
        public static explicit operator decimal(BigRational value)
        {
            if (value < DecimalMin || value > DecimalMax)
            {
                throw new OverflowException("Value outside of range of valid decimal values.");
            }

            if (value.IsInteger)
            {
                return (decimal)value.Numerator;
            }

            var rationalWhole = RoundTowardZeroImpl(value);
            var rationalScale = BigInteger.Pow(10, 28 - Digits(rationalWhole));
            var scaledFraction = (value - rationalWhole) * rationalScale;
            var scaledRounded = RoundToInt(scaledFraction);

            return ((decimal)scaledRounded / (decimal)rationalScale) + (decimal)rationalWhole;
        }

        private static int Digits(BigInteger number)
        {
            if (number.IsZero)
            {
                return 0;
            }

            number = BigInteger.Abs(number);
            var count = 0;
            var ten = new BigInteger(10);
            while (number > 1)
            {
                ++count;
                number /= ten;
            }

            return count;
        }
    }
}