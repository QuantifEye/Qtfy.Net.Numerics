// <copyright file="BigRationalTests.DecimalConversion.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests
{
    using System;
    using System.Globalization;
    using System.Numerics;
    using NUnit.Framework;

    public partial class BigRationalTests
    {
        private static decimal ParseDecimal(string str)
        {
            return decimal.Parse(str, CultureInfo.InvariantCulture);
        }

        [TestCase("0.125", "1/8")]
        [TestCase("0.0125", "1/80")]
        [TestCase("-0.125", "-1/8")]
        [TestCase("-0.0125", "-1/80")]
        public void DecimalToRational(string dec, string expected)
        {
            AssertEqual(
                BigRational.Parse(expected),
                (BigRational)ParseDecimal(dec));
        }

        [TestCase("1005/10", "100.5")]
        [TestCase("80", "80")]
        [TestCase("1/8", "0.125")]
        [TestCase("1/80", "0.0125")]
        [TestCase("-1/8", "-0.125")]
        [TestCase("-1/80", "-0.0125")]
        [TestCase("-1", "-1")]
        [TestCase("1", "1")]
        [TestCase("2", "2")]
        public void RationalToDecimalExact(string rational, string expected)
        {
            AssertEqual(
                ParseDecimal(expected),
                (decimal)BigRational.Parse(rational));
        }

        [TestCase("2/3", "0.6666666666666666666666666667")]
        [TestCase("-2/3", "-0.6666666666666666666666666667")]
        [TestCase("1/3", "0.3333333333333333333333333333")]
        [TestCase("-1/3", "-0.3333333333333333333333333333")]
        public void RationalToDecimalWithRecurringDigit(string rational, string expected)
        {
            Assert.AreEqual(
                ParseDecimal(expected),
                (decimal)BigRational.Parse(rational));
        }

        [TestCase("0.0000000000000000000000000005", "0")]
        [TestCase("0.0000000000000000000000000015", "0.0000000000000000000000000002")]
        [TestCase("0.0000000000000000000000000025", "0.0000000000000000000000000002")]
        [TestCase("-0.0000000000000000000000000005", "0")]
        [TestCase("-0.0000000000000000000000000015", "-0.0000000000000000000000000002")]
        [TestCase("-0.0000000000000000000000000025", "-0.0000000000000000000000000002")]
        public void RationalToDecimalWithRounding(string rationalAsDecimal, string expected)
        {
            var r = (BigRational)ParseDecimal(rationalAsDecimal);
            var actual = (decimal)(r / 10);
            Assert.AreEqual(
                ParseDecimal(expected),
                actual);
        }

        [Test]
        public void TestToDecimalOutOfRange()
        {
            decimal dummy;
            BigRational rational = BigInteger.Pow(10, 30);
            Assert.Throws<OverflowException>(
                () => dummy = (decimal)rational);

            BigRational negative = -rational;
            Assert.Throws<OverflowException>(
                () => dummy = (decimal)negative);
        }
    }
}
