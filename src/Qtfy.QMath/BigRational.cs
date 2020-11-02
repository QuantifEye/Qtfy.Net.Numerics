// <copyright file="BigRational.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath
{
    using System;
    using System.Numerics;
    using System.Runtime.InteropServices;
    using System.Runtime.Serialization;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;

    /// <summary>
    /// A structure that represents a rational number with an arbitrarily large numerator and denominator.
    /// </summary>
    [Serializable]
    public struct BigRational :
        IEquatable<BigRational>,
        IComparable<BigRational>,
        ISerializable,
        IXmlSerializable
    {
        /// <summary>
        /// A <see cref="BigRational"/> that represents a zero value (0).
        /// </summary>
        public static readonly BigRational Zero = BigInteger.Zero;

        /// <summary>
        /// A <see cref="BigRational"/> that represents the value one (1).
        /// </summary>
        public static readonly BigRational One = BigInteger.One;

        /// <summary>
        /// A <see cref="BigRational"/> that represents the value minus one (-1).
        /// </summary>
        public static readonly BigRational MinusOne = BigInteger.MinusOne;

        /// <summary>
        /// A <see cref="BigRational"/> that represents the value 1/2.
        /// </summary>
        public static readonly BigRational Half = new BigRational(1, 2);

        /// <summary>
        /// The greatest value a <see cref="decimal"/> value can have as a <see cref="BigInteger"/>.
        /// </summary>
        public static readonly BigInteger DecimalMax = (BigInteger)decimal.MaxValue;

        /// <summary>
        /// The smallest value a <see cref="decimal"/> value can have as a <see cref="BigInteger"/>.
        /// </summary>
        public static readonly BigInteger DecimalMin = (BigInteger)decimal.MinValue;

        /// <summary>
        /// The name used for the numerator field for binary serialization.
        /// </summary>
        /// <remarks>
        /// Do not change as this will break binary serialization.
        /// </remarks>
        private const string NumeratorName = "n";

        /// <summary>
        /// The name used for the denominator field for binary serialization.
        /// </summary>
        /// <remarks>
        /// Do not change as this will break binary serialization.
        /// </remarks>
        private const string DenominatorName = "d";

        /// <summary>
        /// An array of rationals such that array[i] == Pow(2, -i).
        /// </summary>
        /// <remarks>
        /// A cache of the powers of two needed to convert a floating point number to a
        /// <see cref="BigRational"/>.
        /// </remarks>
        private static readonly BigRational[] NegativePowerOfTwo = BuildNegativePowersOfTwo();

        /// <summary>
        /// The denominator value of this <see cref="BigRational"/>.
        /// </summary>
        private BigInteger denominator;

        /// <summary>
        /// The numerator value of this <see cref="BigRational"/>.
        /// </summary>
        private BigInteger numerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="BigRational"/> struct.
        /// </summary>
        /// <param name="numerator">
        /// The numerator.
        /// </param>
        /// <param name="denominator">
        /// The denominator.
        /// </param>
        /// <exception cref="DivideByZeroException">
        /// If <paramref name="denominator"/> is zero.
        /// </exception>
        public BigRational(BigInteger numerator, BigInteger denominator)
        {
            if (denominator.IsZero)
            {
                throw new DivideByZeroException("The denominator of a BigRational cannot be zero.");
            }

            if (numerator.IsZero)
            {
                this.numerator = BigInteger.Zero;
                this.denominator = BigInteger.One;
            }
            else
            {
                var gcd = denominator < BigInteger.Zero
                    ? -BigInteger.GreatestCommonDivisor(numerator, denominator)
                    : BigInteger.GreatestCommonDivisor(numerator, denominator);

                this.numerator = numerator / gcd;
                this.denominator = denominator / gcd;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BigRational"/> struct.
        /// </summary>
        /// <param name="numerator">
        /// The numerator.
        /// </param>
        /// <remarks>
        /// Sets the <see cref="Denominator"/> to <see cref="BigInteger.One"/>.
        /// </remarks>
        public BigRational(BigInteger numerator)
        {
            this.numerator = numerator;
            this.denominator = BigInteger.One;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BigRational"/> struct.
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/> that holds the serialized object data.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/> that contains contextual information about the source or destination.
        /// </param>
        /// <exception cref="SerializationException">
        /// If the deserialized Numerator is less than or equal to zero,
        /// or if the deserialized numerator and denominator are not co-prime.
        /// </exception>
        private BigRational(SerializationInfo info, StreamingContext context)
        {
            var numerator = (BigInteger)info.GetValue(NumeratorName, typeof(BigInteger));
            var denominator = (BigInteger)info.GetValue(DenominatorName, typeof(BigInteger));

            if (denominator <= 0)
            {
                throw new SerializationException("Invalid denominator, denominator must positive.");
            }

            if (!BigInteger.GreatestCommonDivisor(numerator, denominator).IsOne)
            {
                throw new SerializationException(
                    "Invalid rational representation. Numerator and denominator must be coprime.");
            }

            this.numerator = numerator;
            this.denominator = denominator;
        }

        /// <summary>
        /// Gets the denominator of this <see cref = "BigRational" />.
        /// </summary>
        /// <remarks>
        /// This is currently a computed property because c# does not provide a default constructor.
        /// This ensures that a default constructed <see cref="BigRational"/> is equal to (0 / 1).
        /// </remarks>
        public BigInteger Denominator
        {
            get => this.denominator.IsZero
                ? BigInteger.One
                : this.denominator;
        }

        /// <summary>
        /// Gets the numerator of this <see cref = "BigRational"/>.
        /// </summary>
        public BigInteger Numerator
        {
            get => this.numerator;
        }

        /// <summary>
        /// Gets a number that indicates if <see cref="Numerator"/> is negative, positive, or zero.
        /// </summary>
        /// <returns>
        /// -1 if the value of the numerator is negative,
        /// 0 if the value of the numerator is zero,
        /// 1 if the value of the numerator is positive.
        /// </returns>
        public int Sign
        {
            get => this.Numerator.Sign;
        }

        /// <summary>
        /// Gets a value indicating whether the numerator is positive.
        /// </summary>
        public bool IsPositive
        {
            get => this.Numerator.Sign == 1;
        }

        /// <summary>
        /// Gets a value indicating whether the numerator is negative.
        /// </summary>
        public bool IsNegative
        {
            get => this.Numerator.Sign == -1;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="BigRational"/> is equal to zero (0 / 1).
        /// </summary>
        public bool IsZero
        {
            get => this.Numerator.IsZero;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="BigRational"/> is equal to one (1/1).
        /// </summary>
        public bool IsOne
        {
            get => this.Numerator.IsOne && this.Denominator.IsOne;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="BigRational"/> is equal to minus one (-1/1).
        /// </summary>
        public bool IsMinusOne
        {
            get => this.Numerator == BigInteger.MinusOne && this.Denominator.IsOne;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="BigRational"/> can be represented as an integer (x/1).
        /// </summary>
        public bool IsInteger
        {
            get => this.Denominator.IsOne;
        }

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
        /// Converts a <see cref="BigInteger"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="BigInteger"/> to convert.
        /// </param>
        public static implicit operator BigRational(BigInteger value)
        {
            return new BigRational(value);
        }

        /// <summary>
        /// Converts a <see cref="ulong"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="ulong"/> to convert.
        /// </param>
        public static implicit operator BigRational(ulong value)
        {
            return new BigRational(value);
        }

        /// <summary>
        /// Converts a <see cref="long"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="long"/> to convert.
        /// </param>
        public static implicit operator BigRational(long value)
        {
            return new BigRational(value);
        }

        /// <summary>
        /// Converts a <see cref="uint"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="uint"/> to convert.
        /// </param>
        public static implicit operator BigRational(uint value)
        {
            return new BigRational(value);
        }

        /// <summary>
        /// Converts a <see cref="int"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="int"/> to convert.
        /// </param>
        public static implicit operator BigRational(int value)
        {
            return new BigRational(value);
        }

        /// <summary>
        /// Converts a <see cref="ushort"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="ushort"/> to convert.
        /// </param>
        public static implicit operator BigRational(ushort value)
        {
            return new BigRational(value);
        }

        /// <summary>
        /// Converts a <see cref="short"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="short"/> to convert.
        /// </param>
        public static implicit operator BigRational(short value)
        {
            return new BigRational(value);
        }

        /// <summary>
        /// Converts a <see cref="byte"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="byte"/> to convert.
        /// </param>
        public static implicit operator BigRational(byte value)
        {
            return new BigRational(value);
        }

        /// <summary>
        /// Converts a <see cref="sbyte"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="sbyte"/> to convert.
        /// </param>
        public static implicit operator BigRational(sbyte value)
        {
            return new BigRational(value);
        }

        /// <summary>
        /// Converts a <see cref="BigRational"/> to a <see cref="double"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="BigRational"/> to convert.
        /// </param>
        /// <returns>
        /// <see cref="double.PositiveInfinity"/> if value is greater than <see cref="double.MaxValue"/>,
        /// <see cref="double.NegativeInfinity"/> if value is smaller than <see cref="double.MinValue"/>,
        /// negative zero if value is smaller than <see cref="double.Epsilon"/> and greater than 0,
        /// positive zero if value is greater than negative <see cref="double.Epsilon"/> and smaller than 0,
        /// otherwise the nearest possible double precision value is returned using
        /// bankers rounding (round to nearest, ties to even).
        /// </returns>
        public static explicit operator double(BigRational value)
        {
            throw new NotImplementedException();
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

            var rationalWhole = RoundTowardZero(value);
            var rationalScale = BigInteger.Pow(10, 28 - Digits(rationalWhole));
            var scaledFraction = (value - rationalWhole) * rationalScale;
            var scaledRounded = Round(scaledFraction).Numerator;

            return ((decimal)scaledRounded / (decimal)rationalScale) + (decimal)rationalWhole;
        }

        /// <summary>
        /// Returns a value indicating whether <paramref name="left"/> is equal to <paramref name="right"/>.
        /// </summary>
        /// <param name="left">
        /// The first value to compare.
        /// </param>
        /// <param name="right">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// true if <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        public static bool operator ==(BigRational left, BigRational right)
        {
            return left.Numerator == right.Numerator && left.Denominator == right.Denominator;
        }

        /// <summary>
        /// Returns a value indicating whether <paramref name="left"/> is unequal to <paramref name="right"/>.
        /// </summary>
        /// <param name="left">
        /// The first value to compare.
        /// </param>
        /// <param name="right">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// false if <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, true.
        /// </returns>
        public static bool operator !=(BigRational left, BigRational right)
        {
            return left.Numerator != right.Numerator || left.Denominator != right.Denominator;
        }

        /// <summary>
        /// Returns an indication whether <paramref name="left"/> is less than <paramref name="right"/>.
        /// </summary>
        /// <param name="left">
        /// The first value to compare.
        /// </param>
        /// <param name="right">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// true if <paramref name="left"/> is less than <paramref name="right"/>; otherwise, false.
        /// </returns>
        public static bool operator <(BigRational left, BigRational right)
        {
            return left.Numerator * right.Denominator < right.Numerator * left.Denominator;
        }

        /// <summary>
        /// Returns an indication whether <paramref name="left"/> is greater than or equal to <paramref name="right"/>.
        /// </summary>
        /// <param name="left">
        /// The first value to compare.
        /// </param>
        /// <param name="right">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// true if <paramref name="left"/> is greater than or equal to <paramref name="right"/>; otherwise, false.
        /// </returns>
        public static bool operator >=(BigRational left, BigRational right)
        {
            return left.Numerator * right.Denominator >= right.Numerator * left.Denominator;
        }

        /// <summary>
        /// Returns an indication whether <paramref name="left"/> is greater than <paramref name="right"/>.
        /// </summary>
        /// <param name="left">
        /// The first value to compare.
        /// </param>
        /// <param name="right">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// true if <paramref name="left"/> is greater than <paramref name="right"/>; otherwise, false.
        /// </returns>
        public static bool operator >(BigRational left, BigRational right)
        {
            return left.Numerator * right.Denominator > right.Numerator * left.Denominator;
        }

        /// <summary>
        /// Returns an indication whether <paramref name="left"/> is less than or equal to <paramref name="right"/>.
        /// </summary>
        /// <param name="left">
        /// The first value to compare.
        /// </param>
        /// <param name="right">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// true if <paramref name="left"/> is less than or equal to <paramref name="right"/>; otherwise, false.
        /// </returns>
        public static bool operator <=(BigRational left, BigRational right)
        {
            return left.Numerator * right.Denominator <= right.Numerator * left.Denominator;
        }

        /// <summary>
        /// Adds one to <paramref name="value"/>.
        /// </summary>
        /// <param name="value">
        /// The value to add one to.
        /// </param>
        /// <returns>
        /// The value of <paramref name="value"/> + (1 / 1).
        /// </returns>
        public static BigRational operator ++(BigRational value)
        {
            return new BigRational(value.Numerator + value.Denominator, value.Denominator);
        }

        /// <summary>
        /// Subtracts one from <paramref name="value"/>.
        /// </summary>
        /// <param name="value">
        /// The value to subtract one from.
        /// </param>
        /// <returns>
        /// The value of <paramref name="value"/> - (1 / 1).
        /// </returns>
        public static BigRational operator --(BigRational value)
        {
            return new BigRational(value.Numerator - value.Denominator, value.Denominator);
        }

        /// <summary>
        /// Calculates the remainder that results from division with two specified <see cref="BigRational"/> values.
        /// </summary>
        /// <param name="dividend">
        /// The value to be divided.
        /// </param>
        /// <param name="divisor">
        /// The value to divide by.
        /// </param>
        /// <returns>
        /// The remainder that results from the division.
        /// </returns>
        /// <exception cref="DivideByZeroException">
        /// If <paramref name="divisor"/> is zero (1/0).
        /// </exception>
        public static BigRational operator %(BigRational dividend, BigRational divisor)
        {
            var temp = dividend / divisor;
            return dividend - ((temp.Numerator / temp.Denominator) * divisor);
        }

        /// <summary>
        /// Negates a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The value to negate.
        /// </param>
        /// <returns>
        /// The result of multiplying <paramref name="value"/> by negative one (-1).
        /// </returns>
        public static BigRational operator -(BigRational value)
        {
            return new BigRational()
            {
                numerator = -value.numerator,
                denominator = value.denominator,
            };
        }

        /// <summary>
        /// Returns the value of the <see cref="BigRational"/> operand. (The sign of the operand is unchanged.)
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <paramref name="value"/> operand.
        /// </returns>
        public static BigRational operator +(BigRational value)
        {
            return value;
        }

        /// <summary>
        /// Multiplies two <see cref="BigRational"/> values.
        /// </summary>
        /// <param name="multiplicand">
        /// The first value to multiply.
        /// </param>
        /// <param name="multiplier">
        /// The second value to multiply.
        /// </param>
        /// <returns>
        /// The product of <paramref name="multiplicand"/> and <paramref name="multiplier"/>.
        /// </returns>
        public static BigRational operator *(BigRational multiplicand, BigRational multiplier)
        {
            return new BigRational(
                multiplicand.Numerator * multiplier.Numerator,
                multiplicand.Denominator * multiplier.Denominator);
        }

        /// <summary>
        /// Divides a <see cref="BigRational"/> value by another <see cref="BigRational"/> value.
        /// </summary>
        /// <param name="dividend">
        /// The <see cref="BigRational"/> to be divided (the dividend).
        /// </param>
        /// <param name="divisor">
        /// The <see cref="BigRational"/> to divide by (the divisor).
        /// </param>
        /// <returns>
        /// The quotient of <paramref name="dividend"/> and <paramref name="divisor"/>.
        /// </returns>
        /// <exception cref="DivideByZeroException">
        /// If <paramref name="divisor"/> is equal to zero (0/1).
        /// </exception>
        public static BigRational operator /(BigRational dividend, BigRational divisor)
        {
            return new BigRational(dividend.Numerator * divisor.Denominator, dividend.Denominator * divisor.Numerator);
        }

        /// <summary>
        /// Adds two <see cref="BigRational"/> values.
        /// </summary>
        /// <param name="augend">
        /// The first number to add (the augend).
        /// </param>
        /// <param name="addend">
        /// The first number to add (the addend).
        /// </param>
        /// <returns>
        /// The sum of <paramref name="augend"/> and <paramref name="addend"/>.
        /// </returns>
        public static BigRational operator +(BigRational augend, BigRational addend)
        {
            var leftDen = augend.Denominator;
            var rightDen = addend.Denominator;
            return new BigRational((augend.Numerator * rightDen) + (addend.Numerator * leftDen), leftDen * rightDen);
        }

        /// <summary>
        /// Subtracts a <see cref="BigRational"/> value from a <see cref="BigRational"/> value.
        /// </summary>
        /// <param name="minuend">
        /// The value to subtract from (the minuend).
        /// </param>
        /// <param name="subtrahend">
        /// The value to subtract (the subtrahend).
        /// </param>
        /// <returns>
        /// The result of subtracting <paramref name="subtrahend"/> from <paramref name="minuend"/>.
        /// </returns>
        public static BigRational operator -(BigRational minuend, BigRational subtrahend)
        {
            var leftDen = minuend.Denominator;
            var rightDen = subtrahend.Denominator;
            return new BigRational((minuend.Numerator * rightDen) - (subtrahend.Numerator * leftDen), leftDen * rightDen);
        }

        /// <summary>
        /// Calculates the absolute value of a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// A <see cref="BigRational"/> value.
        /// </param>
        /// <returns>
        /// The absolute value of <paramref name="value"/>.
        /// </returns>
        public static BigRational Abs(BigRational value)
        {
            if (value.IsNegative)
            {
                value.numerator = -value.numerator;
            }

            return value;
        }

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
        /// Returns the greater of two <see cref="BigRational"/> values.
        /// </summary>
        /// <param name="left">
        /// The first value to compare.
        /// </param>
        /// <param name="right">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// The greater of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static BigRational Max(BigRational left, BigRational right)
        {
            return left < right ? right : left;
        }

        /// <summary>
        /// Returns the lesser of two <see cref="BigRational"/> values.
        /// </summary>
        /// <param name="left">
        /// The first value to compare.
        /// </param>
        /// <param name="right">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// The greater of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static BigRational Min(BigRational left, BigRational right)
        {
            return left > right ? right : left;
        }

        /// <summary>
        /// Raises a <see cref="BigRational"/> to an <see cref="int"/> power.
        /// </summary>
        /// <param name="value">
        /// A <see cref="BigRational"/>.
        /// </param>
        /// <param name="exp">
        /// The <see cref="int"/> exponent.
        /// </param>
        /// <returns>
        /// <paramref name="value"/> raised to the power <paramref name="exp"/>.
        /// </returns>
        public static BigRational Pow(BigRational value, int exp)
        {
            if (value.IsZero)
            {
                return exp == 0
                 ? throw new ArgumentException("Cannot calculate 0 to the power zero.")
                 : One;
            }
            else if (exp == 0)
            {
                return One;
            }
            else
            {
                return exp > 0
                    ? new BigRational(
                        numerator: BigInteger.Pow(value.Numerator, exp),
                        denominator: BigInteger.Pow(value.Denominator, exp))
                    : new BigRational(
                        numerator: BigInteger.Pow(value.Denominator, -exp),
                        denominator: BigInteger.Pow(value.Numerator, -exp));
            }
        }

        /// <summary>
        /// Tries to convert the string representation of a number to its <see cref="BigRational"/> equivalent,
        /// and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="from">
        /// The string representation of a number.
        /// </param>
        /// <param name="rational">
        /// When this method returns, contains the <see cref="BigRational"/> equivalent to
        /// the number that is contained in value, or zero (0) if the conversion fails.
        /// The conversion fails if the value <paramref name="from"/> is null or is not of the correct format.
        /// This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// true if value was converted successfully; otherwise, false.
        /// </returns>
        public static bool TryParse(string from, out BigRational rational)
        {
            var s = from.Split('/');
            var length = s.Length;

            if (length == 1 && BigInteger.TryParse(from, out var bigint))
            {
                rational = new BigRational(bigint);
                return true;
            }
            else if (length == 2 && BigInteger.TryParse(s[0], out var num) && BigInteger.TryParse(s[1], out var den))
            {
                rational = new BigRational(num, den);
                return true;
            }

            rational = default;
            return false;
        }

        /// <summary>
        /// Converts the string representation of a number to its <see cref="BigRational"/> equivalent.
        /// </summary>
        /// <param name="from">
        /// A string that contains the number to convert.
        /// </param>
        /// <returns>
        /// A value that is equivalent to the number specified in the <paramref name="from"/> parameter.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="from"/> is null.
        /// </exception>
        /// <exception cref="FormatException">
        /// If <paramref name="from"/> cannot be interpreted as a <see cref="BigRational"/>.
        /// </exception>
        public static BigRational Parse(string from)
        {
            var s = from.Split('/');
            switch (s.Length)
            {
                case 1:
                    return new BigRational(BigInteger.Parse(from));
                case 2:
                    var n = BigInteger.Parse(s[0]);
                    var d = BigInteger.Parse(s[1]);
                    if (d.IsZero)
                    {
                        break;
                    }

                    return new BigRational(n, d);
            }

            throw new FormatException($"Could not parse \"{from}\" as a BigRational.");
        }

        /// <summary>
        /// Converts a BigRational to a <see cref="double"/>, rounding toward zero if the conversion is not exact.
        /// </summary>
        /// <param name="value">
        /// The <see cref="BigRational"/> to convert to a <see cref="double"/>.
        /// </param>
        /// <returns>
        /// A floating point value obtained by converting the provided rational to a double precision number,
        /// rounding toward zero.
        /// </returns>
        public static double ToDoubleTowardZero(BigRational value)
        {
            if (value.IsInteger)
            {
                return (double)value.Numerator;
            }

            bool isPositive = value.IsPositive;

            if (isPositive)
            {
                if (value > double.MaxValue)
                {
                    return double.PositiveInfinity;
                }
                else if (value < double.Epsilon)
                {
                    return 0d;
                }
            }
            else
            {
                if (value < double.MinValue)
                {
                    return double.NegativeInfinity;
                }
                else if (value > -double.Epsilon)
                {
                    return -0d;
                }
            }

            BigInteger numerator = BigInteger.Abs(value.Numerator);
            BigInteger denominator = value.Denominator;

            int numeratorExponent = MostSignificantBit(numerator);
            int denominatorExponent = MostSignificantBit(denominator);
            int unbiasedExponent = numeratorExponent - denominatorExponent;
            int biasedExponent = unbiasedExponent + 1023;

            BigRational scale = BigRational.Pow(2, unbiasedExponent);
            BigRational precision = (value / scale) - BigRational.One;
            ulong mantissa = default;
            for (int i = 1; i <= 52; ++i)
            {
                if (LongDivide(precision, BigRational.Pow(2, -i), out precision).IsOne)
                {
                    mantissa = mantissa & (0x1UL << (52 - i));
                }
            }

            DoubleULongUnion result = default;
            result.UlongValue = ((ulong)biasedExponent << 53) & mantissa;
            return isPositive ? result.DoubleValue : -result.DoubleValue;
        }

        /// <summary>
        /// Deconstructs this <see cref="BigRational"/> into a numerator and a denominator.
        /// </summary>
        /// <param name="numerator">The numerator of this <see cref="BigRational"/>.</param>
        /// <param name="denominator">The denominator of this <see cref="BigRational"/>.</param>
        public void Deconstruct(out BigInteger numerator, out BigInteger denominator)
        {
            numerator = this.Numerator;
            denominator = this.Denominator;
        }

        /// <inheritdoc/>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(NumeratorName, this.Numerator);
            info.AddValue(DenominatorName, this.Denominator);
        }

        /// <inheritdoc/>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <inheritdoc/>
        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            this = Parse(reader.ReadContentAsString());
            reader.ReadEndElement();
        }

        /// <inheritdoc/>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteValue(this.ToString());
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.Numerator}/{this.Denominator}";
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is BigRational bigRational && this.Equals(bigRational);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.Numerator.GetHashCode() * 137) + this.Denominator.GetHashCode();
            }
        }

        /// <inheritdoc />
        public bool Equals(BigRational other)
        {
            return (this.Numerator * other.Denominator).Equals(other.Numerator * this.Denominator);
        }

        /// <inheritdoc />
        public int CompareTo(BigRational other)
        {
            return (this.Numerator * other.Denominator).CompareTo(other.Numerator * this.Denominator);
        }

        /// <summary>
        /// Calculates the reciprocal of this <see cref="BigRational"/> instance
        /// (1 divided by this <see cref="BigRational"/> value).
        /// </summary>
        /// <returns>
        /// The reciprocal value.
        /// </returns>
        /// <exception cref="DivideByZeroException">
        /// If this <see cref="BigRational"/> is zero (0/1).
        /// </exception>
        public BigRational Reciprocal()
        {
            if (this.IsZero)
            {
                throw new DivideByZeroException("Cannot compute the reciprocal of zero.");
            }

            return this.IsNegative
                ? new BigRational()
                {
                    numerator = -this.denominator,
                    denominator = -this.numerator,
                }
                : new BigRational()
                {
                    numerator = this.denominator,
                    denominator = this.numerator,
                };
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
        /// Finds the number of the most significant bit of an unsigned <see cref="BigInteger"/>.
        /// </summary>
        /// <param name="rational">
        /// The integral number whos most significant bit is to be found.
        /// </param>
        /// <returns>
        /// The number of the most significant bit.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// if <paramref name="rational"/> is not greater than zero.
        /// </exception>
        internal static int MostSignificantBit(BigInteger rational)
        {
            if (rational <= BigInteger.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(rational));
            }

            var bytes = rational.ToByteArray();
            int lastIndex = bytes.Length - 1;
            int mostSignificantByte = bytes[lastIndex];
            for (int i = 7; i != 0; --i)
            {
                if ((mostSignificantByte & (0x1 << i)) != 0)
                {
                    return (8 * lastIndex) + i;
                }
            }

            return 8 * lastIndex;
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

        /// <summary>
        /// Converts this <see cref="BigRational"/> to its decimal string representation.
        /// </summary>
        /// <param name="digits">
        /// The number of digits to the rights of the decimal point.
        /// </param>
        /// <param name="mode">
        /// Specification for how to round this value if it is
        /// midway between two other numbers.
        /// </param>
        /// <param name="sep">
        /// The decimal point separator.
        /// </param>
        /// <returns>
        /// The decimal string representation of this <see cref="BigRational"/>.
        /// </returns>
        internal string ToDecimalString(int digits, RationalRounding mode, char sep = '.')
        {
            var sign = this.IsNegative ? "-" : string.Empty;
            var rounded = Round(Abs(this), digits, mode);
            var whole = Floor(rounded).Numerator;
            var fracValue = rounded - whole;
            if (fracValue.IsZero)
            {
                return sign + whole;
            }

            var scaledFrac = (fracValue * Pow(10, digits)).Numerator;
            var fracString = scaledFrac.ToString();
            var pad = new string('0', digits - fracString.Length);
            return $"{sign}{whole}{sep}{pad}{fracString}".TrimEnd('0', sep);
        }

        private static BigInteger LongDivide(BigRational value, BigRational divisor, out BigRational remainder)
        {
            BigInteger result = BigRational.FloorImpl(value / divisor);
            remainder = value - (result * divisor);
            return result;
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

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleULongUnion
        {
            [FieldOffset(0)]
            public double DoubleValue;

            [FieldOffset(0)]
            public ulong UlongValue;
        }
    }
}
