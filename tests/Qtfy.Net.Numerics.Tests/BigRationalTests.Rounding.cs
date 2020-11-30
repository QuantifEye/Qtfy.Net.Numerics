// <copyright file="BigRationalTests.Rounding.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests
{
    using System.Collections;
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
        public void CeilingTick(string input, string tick, string expected)
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
        public void FloorTick(string input, string tick, string expected)
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
    }
}