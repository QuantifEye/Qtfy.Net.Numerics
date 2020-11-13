// <copyright file="ToDoubleTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
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
    }
}