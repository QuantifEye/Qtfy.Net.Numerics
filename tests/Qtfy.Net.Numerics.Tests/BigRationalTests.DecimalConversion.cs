// <copyright file="BigRationalTests.DecimalConversion.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests
{
    using NUnit.Framework;

    public partial class BigRationalTests
    {
        [TestCase("0.125", "1/8")]
        [TestCase("0.0125", "1/80")]
        [TestCase("-0.125", "-1/8")]
        [TestCase("-0.0125", "-1/80")]
        public void DecimalToRational(string decimalString, string expectedString)
        {
            AssertEqual(
                BigRational.Parse(expectedString),
                (BigRational)decimal.Parse(decimalString));
        }

        [TestCase("1/8", "0.125")]
        [TestCase("1/80", "0.0125")]
        [TestCase("-1/8", "-0.125")]
        [TestCase("-1/80", "-0.0125")]
        public void RationalToDecimalExact(string rationalString, string decimalString)
        {
            var rational = BigRational.Parse(rationalString);
            var expected = decimal.Parse(decimalString);
            AssertEqual(expected, (decimal)rational);
        }

        [TestCase("2/3", "0.666_666_666_666_666_666_666_666_666_7")]
        [TestCase("-2/3", "-0.666_666_666_666_666_666_666_666_666_7")]
        [TestCase("1/3", "0.333_333_333_333_333_333_333_333_333_3")]
        [TestCase("-1/3", "-0.333_333_333_333_333_333_333_333_333_3")]
        public void RationalToDecimalWithRounding(string rationalString, string expectedString)
        {
            var rational = BigRational.Parse(rationalString);
            var expected = decimal.Parse(expectedString);
            Assert.AreEqual(expected, (decimal)rational);
        }

        [TestCase("0.000_000_000_000_000_000_000_000_000_5", "0")]
        [TestCase("0.000_000_000_000_000_000_000_000_001_5", "0.000_000_000_000_000_000_000_000_000_2")]
        [TestCase("0.000_000_000_000_000_000_000_000_002_5", "0.000_000_000_000_000_000_000_000_000_2")]
        [TestCase("-0.000_000_000_000_000_000_000_000_000_5", "0")]
        [TestCase("-0.000_000_000_000_000_000_000_000_001_5", "-0.000_000_000_000_000_000_000_000_000_2")]
        [TestCase("-0.000_000_000_000_000_000_000_000_002_5", "-0.000_000_000_000_000_000_000_000_000_2")]
        public void ToDecimalWithRounding5(string leftString, string rightString)
        {
            var rational = (BigRational)decimal.Parse(leftString);
            var actual = (decimal)(rational / 10);
            var expected = decimal.Parse(rightString);
            Assert.AreEqual(expected, actual);
        }
    }
}
