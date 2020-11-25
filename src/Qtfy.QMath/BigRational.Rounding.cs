// <copyright file="BigRational.Rounding.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>
namespace Qtfy.QMath
{
    using System;
    using System.Numerics;

    /// <summary>
    /// A structure that represents a rational number with an arbitrarily large numerator and denominator.
    /// </summary>
    public partial struct BigRational
    {
        /// <summary>
        /// Returns the smallest integral value that is greater than or equal to the specified
        /// <see cref="BigRational"/> number.
        /// </summary>
        /// <param name="value">
        /// A <see cref="BigRational"/> number.
        /// </param>
        /// <returns>
        /// The smallest <see cref="BigRational"/> value that is greater than or equal to <paramref name="value"/>.
        /// </returns>
        public static BigRational Ceiling(BigRational value)
        {
            return value.IsInteger ? value.Numerator : (BigRational)CeilingImpl(value);
        }

        /// <summary>
        /// Returns the smallest number that greater than or equal to <paramref name="value"/> that is
        /// a whole number of ticks away from zero.
        /// </summary>
        /// <param name="value">
        /// The value to round.
        /// </param>
        /// <param name="tick">
        /// The size of the tickSize.
        /// </param>
        /// <returns>
        /// The smallest number that greater than or equal to <paramref name="value"/> that is
        /// a whole number of ticks away from zero.
        /// </returns>
        public static BigRational Ceiling(BigRational value, BigRational tick)
        {
            ValidateTickSize(value);
            var ticks = value / tick;
            return ticks.IsInteger ? value : CeilingImpl(ticks) * tick;
        }

        /// <summary>
        /// Returns the largest integral number that is less than or equal to the specified
        /// <see cref="BigRational"/> number.
        /// </summary>
        /// <param name="value">
        /// A <see cref="BigRational"/> number.
        /// </param>
        /// <returns>
        /// The largest integral number that is less than or equal to the specified <see cref="BigRational"/> number.
        /// </returns>
        public static BigRational Floor(BigRational value)
        {
            return value.IsInteger
                ? value.Numerator
                : FloorImpl(value);
        }

        /// <summary>
        /// Returns the largest number less than or equal to <paramref name="value"/> that is a
        /// multiple of <paramref name="tickSize"/>.
        /// </summary>
        /// <param name="value">
        /// A <see cref="BigRational"/> number.
        /// </param>
        /// <param name="tickSize">
        /// Multiples of <paramref name="tickSize"/> define the set of values that
        /// <paramref name="value"/> can be rounded to.
        /// </param>
        /// <returns>
        /// The largest number less than or equal to <paramref name="value"/> that is a
        /// multiple of <paramref name="tickSize"/>.
        /// </returns>
        public static BigRational Floor(BigRational value, BigRational tickSize)
        {
            ValidateTickSize(tickSize);
            var ticks = value / tickSize;
            return tickSize.IsInteger ? value : FloorImpl(ticks) * tickSize;
        }

        /// <summary>
        /// Rounds a <see cref="BigRational"/> value to a specified number of decimal digits.
        /// </summary>
        /// <param name="value">
        /// A decimal number to be rounded.
        /// </param>
        /// <param name="decimals">
        /// The number of decimal places to round <paramref name="value"/> to.
        /// </param>
        /// <param name="mode">
        /// Specification for how to round <paramref name="value"/> if it is
        /// midway between two other numbers, (default value = <see cref="RationalRounding.ToEven"/>).
        /// </param>
        /// <returns>
        /// The number nearest to <paramref name="value"/> that has a number
        /// of fractional digits equal to <paramref name="decimals"/>.
        /// </returns>
        public static BigRational Round(BigRational value, int decimals, RationalRounding mode = RationalRounding.ToEven)
        {
            return RoundToTick(value, Pow(10, -decimals), mode);
        }

        /// <summary>
        /// Rounds a <see cref="BigRational"/> value to the nearest integral number.
        /// </summary>
        /// <param name="value">
        /// A decimal number to be rounded.
        /// </param>
        /// <param name="mode">
        /// Specification for how to round <paramref name="value"/> if it is
        /// midway between two other numbers (default value = <see cref="RationalRounding.ToEven"/>).
        /// </param>
        /// <returns>
        /// The integral number that is nearest to <paramref name="value"/>.
        /// </returns>
        public static BigRational Round(BigRational value, RationalRounding mode = RationalRounding.ToEven)
        {
            return value.IsInteger
                ? value
                : RoundImpl(value, mode);
        }

        /// <summary>
        /// Rounds <paramref name="value"/> to a nearest number that is multiple of <paramref name="tickSize"/>.
        /// If <paramref name="value"/> is exactly half way between two such numbers, <paramref name="mode"/>
        /// specifies the rounding method to use.
        /// </summary>
        /// <param name="value">
        /// The value to be rounded.
        /// </param>
        /// <param name="tickSize">
        /// Multiples of <paramref name="tickSize"/> define the set of values that <paramref name="value"/>
        /// can be rounded to.
        /// </param>
        /// <param name="mode">
        /// The specification of what to do when <paramref name="value"/> is exactly half way between two numbers
        /// that are a multiple if <paramref name="tickSize"/>, (default value = <see cref="RationalRounding.ToEven"/>).
        /// </param>
        /// <returns>
        /// Rounds<paramref name="value"/> to a nearest number that is multiple of<paramref name= "tickSize" />.
        /// If <paramref name= "value" /> is exactly half way between two such numbers, <paramref name="mode"/>
        /// specifies the rounding method to use.
        /// </returns>
        public static BigRational RoundToTick(BigRational value, BigRational tickSize, RationalRounding mode = RationalRounding.ToEven)
        {
            ValidateTickSize(tickSize);
            var ticks = value / tickSize;
            return ticks.IsInteger ? value : RoundImpl(ticks, mode) * tickSize;
        }

        /// <summary>
        /// Rounds <paramref name="value"/> to a nearest integral number. If <paramref name="value"/>
        /// is exactly half way between two such numbers, <paramref name="mode"/> specifies the rounding method to use.
        /// </summary>
        /// <param name="value">
        /// The value to round.
        /// </param>
        /// <param name="mode">
        /// The rounding methodology to use if value is exactly half way between two integral values.
        /// </param>
        /// <returns>
        /// The nearest integral number. If <paramref name="value"/>
        /// is exactly half way between two such numbers, <paramref name="mode"/> specifies the rounding method to use.
        /// </returns>
        /// <remarks>
        /// This method assumes that <paramref name="value"/> is not an integral number.
        /// </remarks>
        internal static BigInteger RoundImpl(BigRational value, RationalRounding mode)
        {
            switch (mode)
            {
                case RationalRounding.Up:
                    return RoundUp(value);
                case RationalRounding.Down:
                    return RoundDown(value);
                case RationalRounding.ToEven:
                    return RoundToEven(value);
                case RationalRounding.AwayFromZero:
                    return RoundAwayFromZero(value);
                case RationalRounding.TowardZero:
                    return RoundTowardZero(value);
                default:
                    throw new ArgumentException("Invalid RationalRounding value");
            }
        }

        /// <summary>
        /// Rounds <paramref name="value"/> to the nearest integral number that is less than <paramref name="value"/>.
        /// </summary>
        /// <param name="value">
        /// The value to round.
        /// </param>
        /// <returns>
        /// The nearest integral number that is less than <paramref name="value"/>.
        /// </returns>
        internal static BigInteger FloorImpl(BigRational value)
        {
            var div = value.Numerator / value.Denominator;
            return value.IsPositive ? div : --div;
        }

        /// <summary>
        /// Rounds <paramref name="value"/> to the nearest integral number that
        /// is greater than <paramref name="value"/>.
        /// </summary>
        /// <param name="value">
        /// The value to round.
        /// </param>
        /// <returns>
        /// The nearest integral number that is greater than <paramref name="value"/>.
        /// </returns>
        internal static BigInteger CeilingImpl(BigRational value)
        {
            var div = value.Numerator / value.Denominator;
            return value.IsPositive ? ++div : div;
        }

        /// <summary>
        /// Rounds <paramref name="value"/> to the nearest integral value. If <paramref name="value"/>
        /// is exactly half way between two integral values, it is rounded up.
        /// </summary>
        /// <param name="value">
        /// The value to round.
        /// </param>
        /// <returns>
        /// The nearest integral value. If <paramref name="value"/>
        /// is exactly half way between two integral values, it is rounded up.
        /// </returns>
        /// <remarks>
        /// Assumes that <paramref name="value"/> is not an integer.
        /// </remarks>
        internal static BigInteger RoundUp(BigRational value)
        {
            var floor = FloorImpl(value);
            return (value - floor).IsGreaterThanOrEqualToHalf()
                ? ++floor
                : floor;
        }

        /// <summary>
        /// Rounds <paramref name="value"/> to the nearest integral value. If <paramref name="value"/>
        /// is exactly half way between two integral values, it is rounded down.
        /// </summary>
        /// <param name="value">
        /// The value to round.
        /// </param>
        /// <returns>
        /// The nearest integral value. If <paramref name="value"/>
        /// is exactly half way between two integral values, it is rounded down.
        /// </returns>
        /// <remarks>
        /// Assumes that <paramref name="value"/> is not an integer.
        /// </remarks>
        internal static BigInteger RoundDown(BigRational value)
        {
            var floor = FloorImpl(value);
            return (value - floor).IsGreaterThanHalf()
                ? ++floor
                : floor;
        }

        /// <summary>
        /// Rounds <paramref name="value"/> to the nearest integral value. If <paramref name="value"/>
        /// is exactly half way between two integral values, it is rounded toward zero.
        /// </summary>
        /// <param name="value">
        /// The value to round.
        /// </param>
        /// <returns>
        /// The nearest integral value. If <paramref name="value"/>
        /// is exactly half way between two integral values, it is rounded toward zero.
        /// </returns>
        /// <remarks>
        /// Assumes that <paramref name="value"/> is not an integer.
        /// </remarks>
        internal static BigInteger RoundTowardZero(BigRational value)
        {
            var floor = FloorImpl(value);
            var fraction = value - floor;
            if (value.IsPositive)
            {
                if (fraction.IsGreaterThanHalf())
                {
                    ++floor;
                }
            }
            else
            {
                if (fraction.IsGreaterThanOrEqualToHalf())
                {
                    ++floor;
                }
            }

            return floor;
        }

        /// <summary>
        /// Rounds <paramref name="value"/> to the nearest integral value. If <paramref name="value"/>
        /// is exactly half way between two integral values, it is rounded away from zero.
        /// </summary>
        /// <param name="value">
        /// The value to round.
        /// </param>
        /// <returns>
        /// The nearest integral value. If <paramref name="value"/>
        /// is exactly half way between two integral values, it is rounded away from zero.
        /// </returns>
        /// <remarks>
        /// Assumes that <paramref name="value"/> is not an integer.
        /// </remarks>
        internal static BigInteger RoundAwayFromZero(BigRational value)
        {
            var floor = FloorImpl(value);
            var fraction = value - floor;
            if (value.IsPositive)
            {
                if (fraction.IsGreaterThanOrEqualToHalf())
                {
                    ++floor;
                }
            }
            else
            {
                if (fraction.IsGreaterThanHalf())
                {
                    ++floor;
                }
            }

            return floor;
        }

        /// <summary>
        /// Rounds <paramref name="value"/> to the nearest integral value. If <paramref name="value"/>
        /// is exactly half way between two integral values, it is rounded to the nearest even integral value.
        /// </summary>
        /// <param name="value">
        /// The value to round.
        /// </param>
        /// <returns>
        /// The nearest integral value. If <paramref name="value"/>
        /// is exactly half way between two integral values, it is rounded to the nearest even integral value.
        /// </returns>
        /// <remarks>
        /// Assumes that <paramref name="value"/> is not an integer.
        /// </remarks>
        internal static BigInteger RoundToEven(BigRational value)
        {
            var floor = FloorImpl(value);
            switch ((value - floor).CompareToHalf())
            {
                case 0:
                    return floor.IsEven ? floor : ++floor;
                case 1:
                    return ++floor;
                default:
                    return floor;
            }
        }

        private static void ValidateTickSize(BigRational value)
        {
            if (!value.IsPositive)
            {
                throw new ArgumentException("Tick size must be positive.");
            }
        }

        private bool IsGreaterThanOrEqualToHalf()
        {
            return this.Numerator * 2 >= this.Denominator;
        }

        private bool IsGreaterThanHalf()
        {
            return this.Numerator * 2 > this.Denominator;
        }

        private int CompareToHalf()
        {
            return (this.Numerator * 2).CompareTo(this.Denominator);
        }
    }
}