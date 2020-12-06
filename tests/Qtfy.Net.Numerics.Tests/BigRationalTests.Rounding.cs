// <copyright file="BigRationalTests.Rounding.cs" company="QuantifEye">
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
        [TestCase("1/2", "1")]
        [TestCase("-1/2", "0")]
        [TestCase("1", "1")]
        [TestCase("-1", "-1")]
        public void Ceiling(string input, string expected)
        {
            AssertEqual(
                BigRational.Ceiling(BigRational.Parse(input)),
                BigRational.Parse(expected));
        }

        [TestCase("1/6", "1/3", "1/3")]
        [TestCase("3/6", "1/3", "2/3")]
        [TestCase("2/6", "1/3", "1/3")]
        public void CeilingWithTick(string input, string tick, string expected)
        {
            AssertEqual(
                BigRational.Ceiling(BigRational.Parse(input), BigRational.Parse(tick)),
                BigRational.Parse(expected));
        }

        [TestCase("3/2", 1)]
        [TestCase("-3/2", -2)]
        [TestCase("1", 1)]
        [TestCase("-1", -1)]
        public void Floor(string rational, int rounded)
        {
            AssertEqual(
                BigRational.Floor(BigRational.Parse(rational)),
                new BigInteger(rounded));
        }

        [TestCase("1/6", "1/3", "0")]
        [TestCase("3/6", "1/3", "1/3")]
        [TestCase("2/6", "1/3", "1/3")]
        [TestCase("-1/6", "1/3", "-1/3")]
        [TestCase("-3/6", "1/3", "-2/3")]
        [TestCase("-2/6", "1/3", "-1/3")]
        public void FloorWithTick(string input, string tick, string expected)
        {
            AssertEqual(
                BigRational.Floor(BigRational.Parse(input), BigRational.Parse(tick)),
                BigRational.Parse(expected));
        }

        [TestCase("1/6", "1/3", RationalRounding.Down, "0/3")]
        [TestCase("3/6", "1/3", RationalRounding.Down, "1/3")]
        [TestCase("1/6", "1/3", RationalRounding.Up, "1/3")]
        [TestCase("3/6", "1/3", RationalRounding.Up, "2/3")]
        [TestCase("1/6", "1/3", RationalRounding.TowardZero, "0/3")]
        [TestCase("3/6", "1/3", RationalRounding.TowardZero, "1/3")]
        [TestCase("1/6", "1/3", RationalRounding.AwayFromZero, "1/3")]
        [TestCase("3/6", "1/3", RationalRounding.AwayFromZero, "2/3")]
        [TestCase("1/6", "1/3", RationalRounding.ToEven, "0/3")]
        [TestCase("3/6", "1/3", RationalRounding.ToEven, "2/3")]
        [TestCase("-1/6", "1/3", RationalRounding.Down, "-1/3")]
        [TestCase("-3/6", "1/3", RationalRounding.Down, "-2/3")]
        [TestCase("-1/6", "1/3", RationalRounding.Up, "0/3")]
        [TestCase("-3/6", "1/3", RationalRounding.Up, "-1/3")]
        [TestCase("-1/6", "1/3", RationalRounding.TowardZero, "0/3")]
        [TestCase("-3/6", "1/3", RationalRounding.TowardZero, "-1/3")]
        [TestCase("-1/6", "1/3", RationalRounding.AwayFromZero, "-1/3")]
        [TestCase("-3/6", "1/3", RationalRounding.AwayFromZero, "-2/3")]
        [TestCase("-1/6", "1/3", RationalRounding.ToEven, "0/3")]
        [TestCase("-3/6", "1/3", RationalRounding.ToEven, "-2/3")]
        public void TestRoundToTickAtMidPoint(string unrounded, string tick, RationalRounding mode, string expected)
        {
            AssertEqual(
                BigRational.RoundToTick(BigRational.Parse(unrounded), BigRational.Parse(tick), mode),
                BigRational.Parse(expected));
        }

        [TestCase(RationalRounding.Down)]
        [TestCase(RationalRounding.Up)]
        [TestCase(RationalRounding.ToEven)]
        [TestCase(RationalRounding.TowardZero)]
        [TestCase(RationalRounding.AwayFromZero)]
        public void TestRoundToTickNotAtMidPoint(RationalRounding mode)
        {
            const int range = 6;
            var epsilon = new BigRational(1, 12);
            var tick = new BigRational(1, 3);
            var max = range * tick;
            var min = -range * tick;
            for (BigRational rational = min; rational <= max; rational += tick)
            {
                AssertEqual(rational, BigRational.RoundToTick(rational + epsilon, tick, mode));
                AssertEqual(rational, BigRational.RoundToTick(rational - epsilon, tick, mode));
            }
        }

        [Test]
        public void RoundToTickWithModeError()
        {
            Assert.Throws<ArgumentException>(() =>
                BigRational.RoundToTick(1, new BigRational(1, 2), (RationalRounding)100));
        }

        [Test]
        public void RoundToTickWithTickError()
        {
            Assert.Throws<ArgumentException>(() => BigRational.RoundToTick(1, new BigRational(-1, 2), default));
        }

        [TestCase("1/2", RationalRounding.Down, 0)]
        [TestCase("-1/2", RationalRounding.Down, -1)]
        [TestCase("1/2", RationalRounding.Up, 1)]
        [TestCase("-1/2", RationalRounding.Up, 0)]
        [TestCase("1/2", RationalRounding.TowardZero, 0)]
        [TestCase("-1/2", RationalRounding.TowardZero, 0)]
        [TestCase("1/2", RationalRounding.AwayFromZero, 1)]
        [TestCase("-1/2", RationalRounding.AwayFromZero, -1)]
        [TestCase("1/2", RationalRounding.ToEven, 0)]
        [TestCase("-1/2", RationalRounding.ToEven, 0)]
        public void RoundToIntAtMidPoint(string rational, RationalRounding mode, int rounded)
        {
            Assert.AreEqual(
                BigRational.RoundToInt(BigRational.Parse(rational), mode),
                new BigInteger(rounded));
        }

        [TestCase(RationalRounding.Down)]
        [TestCase(RationalRounding.Up)]
        [TestCase(RationalRounding.ToEven)]
        [TestCase(RationalRounding.TowardZero)]
        [TestCase(RationalRounding.AwayFromZero)]
        public void RoundToIntNotAtMidPoint(RationalRounding mode)
        {
            const int range = 3;
            var epsilon = new BigRational(1, 3);
            for (BigRational rational = -range; rational <= range; ++rational)
            {
                AssertEqual(rational, BigRational.RoundToInt(rational + epsilon, mode));
                AssertEqual(rational, BigRational.RoundToInt(rational - epsilon, mode));
            }
        }

        [Test]
        public void RoundToIntModeError()
        {
            Assert.Throws<ArgumentException>(() => BigRational.RoundToInt(1, (RationalRounding)100));
        }
    }
}