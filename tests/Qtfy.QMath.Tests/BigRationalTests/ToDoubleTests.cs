// <copyright file="ToDoubleTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using System.Numerics;
    using NUnit.Framework;

    [TestOf(typeof(BigRational))]
    public class ToDoubleTests
    {
        [TestCase(1UL, 0)]
        [TestCase(2UL, 1)]
        [TestCase(3UL, 1)]
        [TestCase(4UL, 2)]
        [TestCase(1UL << 8, 0 + 8)]
        [TestCase(2UL << 8, 1 + 8)]
        [TestCase(3UL << 8, 1 + 8)]
        [TestCase(4UL << 8, 2 + 8)]
        public void TestMostSignificantBit(ulong integral, int expected)
        {
            var actual = BigRational.MostSignificantBit(integral);
            Assert.AreEqual(actual, expected);
        }

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
    }
}