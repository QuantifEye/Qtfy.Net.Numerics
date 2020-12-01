// <copyright file="BigRationalTests.FloatingPointConversion.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests
{
    using System;
    using System.Numerics;
    using NUnit.Framework;

    public partial class BigRationalTests
    {
        [TestCase(0.125d, 1, 8)]
        [TestCase(0.25d, 1, 4)]
        [TestCase(-0.125d, -1, 8)]
        [TestCase(-0.25d, -1, 4)]
        public void FromDouble(double value, int numerator, int denominator)
        {
            var actual = (BigRational)value;
            var expected = new BigRational(numerator, denominator);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0.125f, 1, 8)]
        [TestCase(0.25f, 1, 4)]
        [TestCase(-0.125f, -1, 8)]
        [TestCase(-0.25f, -1, 4)]
        public void FromFloat(float value, int numerator, int denominator)
        {
            var actual = (BigRational)value;
            var expected = new BigRational(numerator, denominator);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0d)]
        [TestCase(1d)]
        [TestCase(2d)]
        [TestCase(-1d)]
        [TestCase(-2d)]
        [TestCase(0.5d)]
        [TestCase(-0.5d)]
        [TestCase(0.000000000000000000005d)]
        [TestCase(-0.000000000000000000005d)]
        [TestCase(0.000000000000000000001d)]
        [TestCase(-0.000000000000000000001d)]
        public void CastToDoubleRoundTrip(double expected)
        {
            var actual = (double)(BigRational)expected;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0f)]
        [TestCase(1f)]
        [TestCase(2f)]
        [TestCase(-1f)]
        [TestCase(-2f)]
        [TestCase(0.5f)]
        [TestCase(-0.5f)]
        [TestCase(0.000000000000000000005f)]
        [TestCase(-0.000000000000000000005f)]
        [TestCase(0.000000000000000000001f)]
        [TestCase(-0.000000000000000000001f)]
        public void CastToFloatRoundTrip(double expected)
        {
            var actual = (double)(BigRational)expected;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1.0000000000000002, 4)]
        [TestCase(1.0000000000000002, 3)]
        [TestCase(1d, 2)]
        [TestCase(1d, 1)]
        [TestCase(1d, 0)]
        [TestCase(1d, -1)]
        [TestCase(0.99999999999999989, -2)]
        [TestCase(0.99999999999999978, -3)]
        [TestCase(0.99999999999999978, -4)]
        public void CastToDoubleRounding(double expected, int shift)
        {
            var two54 = BigInteger.Pow(2, 54);
            Assert.AreEqual(expected, (double)new BigRational(two54 + shift, two54));
        }

        [Test]
        public void CastToDoubleOverflow()
        {
            BigRational doubleMax = double.MaxValue;
            BigRational positiveOverflowValue = doubleMax * doubleMax;
            BigRational negativeOverflowValue = -positiveOverflowValue;
            AssertBitEqual(double.PositiveInfinity, (double)positiveOverflowValue);
            AssertBitEqual(double.NegativeInfinity, (double)negativeOverflowValue);
        }

        [Test]
        public void CastToDoubleUnderflow()
        {
            BigRational doubleEpsilon = double.Epsilon;
            BigRational positiveUnderflow = doubleEpsilon * doubleEpsilon;
            BigRational negativeUnderflow = -positiveUnderflow;
            AssertBitEqual(0.0d, (double)positiveUnderflow);
            AssertBitEqual(-0.0d, (double)negativeUnderflow);
        }

        [Test]
        public void CastToFloatOverflow()
        {
            BigRational floatMax = float.MaxValue;
            BigRational positiveOverflowValue = floatMax * floatMax;
            BigRational negativeOverflowValue = -positiveOverflowValue;
            AssertBitEqual(float.PositiveInfinity, (float)positiveOverflowValue);
            AssertBitEqual(float.NegativeInfinity, (float)negativeOverflowValue);
        }

        [Test]
        public void CastToFloatUnderflow()
        {
            BigRational floatEpsilon = float.Epsilon;
            BigRational positiveUnderflow = floatEpsilon * floatEpsilon;
            BigRational negativeUnderflow = -positiveUnderflow;
            AssertBitEqual(0.0f, (float)positiveUnderflow);
            AssertBitEqual(-0.0f, (float)negativeUnderflow);
        }

        private static void AssertBitEqual(double left, double right)
        {
            Assert.AreEqual(BitConverter.DoubleToInt64Bits(left), BitConverter.DoubleToInt64Bits(right));
        }
    }
}