// <copyright file="BigRationalTests.FloatingPointConversion.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests
{
    using System.Numerics;
    using NUnit.Framework;

    public partial class BigRationalTests
    {
        [TestCase(0d)]
        [TestCase(1d)]
        [TestCase(2d)]
        [TestCase(-1d)]
        [TestCase(-2d)]
        [TestCase(0.5d)]
        [TestCase(-0.5d)]
        [TestCase(0.25d)]
        [TestCase(-0.25d)]
        [TestCase(0.1d)]
        [TestCase(-0.1d)]
        [TestCase(0.000000000000000000005d)]
        [TestCase(-0.000000000000000000005d)]
        [TestCase(0.000000000000000000001d)]
        [TestCase(-0.000000000000000000001d)]
        public void CastToDoubleRoundTrip(double expected)
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
    }
}