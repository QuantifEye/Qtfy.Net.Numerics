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

        [TestCase("3/2", "1")]
        [TestCase("-3/2", "-2")]
        [TestCase("1", "1")]
        [TestCase("-1", "-1")]
        public void Floor(string input, string expected)
        {
            AssertEqual(
                BigRational.Floor(BigRational.Parse(input)),
                BigRational.Parse(expected));
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

        [TestCase("1/6", "1/3", RationalRounding.Down, "0")]
        [TestCase("-1/6", "1/3", RationalRounding.Down, "-1/3")]
        [TestCase("1/6", "1/3", RationalRounding.Up, "1/3")]
        [TestCase("-1/6", "1/3", RationalRounding.Up, "0")]
        [TestCase("1/6", "1/3", RationalRounding.TowardZero, "0")]
        [TestCase("-1/6", "1/3", RationalRounding.TowardZero, "0")]
        [TestCase("1/6", "1/3", RationalRounding.AwayFromZero, "1/3")]
        [TestCase("-1/6", "1/3", RationalRounding.AwayFromZero, "-1/3")]
        [TestCase("1/6", "1/3", RationalRounding.ToEven, "0")]
        [TestCase("2/6", "1/3", RationalRounding.ToEven, "1/3")]
        [TestCase("3/6", "1/3", RationalRounding.ToEven, "2/3")]
        public void RoundToTick(string unrounded, string tick, RationalRounding mode, string expected)
        {
            AssertEqual(
                BigRational.RoundToTick(BigRational.Parse(unrounded), BigRational.Parse(tick), mode),
                BigRational.Parse(expected));
        }

        [Test]
        public void RoundToTickModeError()
        {
            Assert.Throws<ArgumentException>(() => BigRational.RoundToTick(1, new BigRational(1, 2), (RationalRounding)100));
        }

        [Test]
        public void RoundToTickTickError()
        {
            Assert.Throws<ArgumentException>(() => BigRational.RoundToTick(1, new BigRational(-1, 2), default));
        }

        [TestCase("1/2", RationalRounding.Down, "0")]
        [TestCase("3/2", RationalRounding.Down, "1")]
        [TestCase("-1/2", RationalRounding.Down, "-1")]
        [TestCase("-3/2", RationalRounding.Down, "-2")]

        [TestCase("1/2", RationalRounding.Up, "1")]
        [TestCase("3/2", RationalRounding.Up, "2")]
        [TestCase("-1/2", RationalRounding.Up, "0")]
        [TestCase("-3/2", RationalRounding.Up, "-1")]

        [TestCase("1/2", RationalRounding.TowardZero, "0")]
        [TestCase("3/2", RationalRounding.TowardZero, "1")]
        [TestCase("-1/2", RationalRounding.TowardZero, "0")]
        [TestCase("-3/2", RationalRounding.TowardZero, "-1")]

        [TestCase("1/2", RationalRounding.AwayFromZero, "1")]
        [TestCase("3/2", RationalRounding.AwayFromZero, "2")]
        [TestCase("-1/2", RationalRounding.AwayFromZero, "-1")]
        [TestCase("-3/2", RationalRounding.AwayFromZero, "-2")]

        [TestCase("1/2", RationalRounding.ToEven, "0")]
        [TestCase("3/2", RationalRounding.ToEven, "2")]
        [TestCase("-1/2", RationalRounding.ToEven, "0")]
        [TestCase("-3/2", RationalRounding.ToEven, "-2")]
        public void RoundToIntMidPoint(string unroundedString, RationalRounding mode, string roundedString)
        {
            AssertEqual(
                BigRational.RoundToInt(BigRational.Parse(unroundedString), mode),
                BigRational.Parse(roundedString));
        }

        [TestCase("1/3", "0")]
        [TestCase("2/3", "1")]
        [TestCase("-1/3", "0")]
        [TestCase("-2/3", "-1")]
        [TestCase("0", "0")]
        [TestCase("1", "1")]
        [TestCase("-1", "-1")]
        [TestCase("2", "2")]
        [TestCase("-2", "-2")]
        public void RoundToIntNotMidPoint(string unroundedString, string roundedString)
        {
            var unrounded = BigRational.Parse(unroundedString);
            var rounded = BigInteger.Parse(roundedString);
            var modes = (RationalRounding[])Enum.GetValues(typeof(RationalRounding));
            foreach (var mode in modes)
            {
                Assert.AreEqual(
                    BigRational.RoundToInt(unrounded, mode),
                    rounded);
            }
        }

        [Test]
        public void RoundToIntModeError()
        {
            Assert.Throws<ArgumentException>(() => BigRational.RoundToInt(1, (RationalRounding)100));
        }
    }
}