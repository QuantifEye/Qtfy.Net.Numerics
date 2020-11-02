// <copyright file="ToDoubleTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using NUnit.Framework;
    using System.Numerics;

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
        public void TestMostSignificantBit(ulong intgral, int expected)
        {
            var actual = BigRational.MostSignificantBit(intgral);
            Assert.AreEqual(actual, expected);
        }

        [TestCase(5d)]
        [TestCase(-5d)]
        [TestCase(0d)]
        public void TestToDoubleTowardZeroInt(double value)
        {
            var rational = (BigRational)value;
            var expected = value;
            var actual = BigRational.ToDoubleTowardZero(rational);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestToDoubleTowardZeroRoundTrip()
        {
            var rational = new BigRational(1, 2);
            var expected = 0.5d;
            var actual = BigRational.ToDoubleTowardZero(rational);
            Assert.AreEqual(expected, actual);
        }
    }
}