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

        [TestCase("2/3", "0.6666666666666666666666666667")]
        [TestCase("-2/3", "-0.6666666666666666666666666667")]
        [TestCase("1/3", "0.3333333333333333333333333333")]
        [TestCase("-1/3", "-0.3333333333333333333333333333")]
        public void RationalToDecimalWithRecurringDigit(string rationalString, string expectedString)
        {
            var rational = BigRational.Parse(rationalString);
            var expected = decimal.Parse(expectedString);
            Assert.AreEqual(expected, (decimal)rational);
        }

        [TestCase("0.0000000000000000000000000005", "0")]
        [TestCase("0.0000000000000000000000000015", "0.0000000000000000000000000002")]
        [TestCase("0.0000000000000000000000000025", "0.0000000000000000000000000002")]
        [TestCase("-0.0000000000000000000000000005", "0")]
        [TestCase("-0.0000000000000000000000000015", "-0.0000000000000000000000000002")]
        [TestCase("-0.0000000000000000000000000025", "-0.0000000000000000000000000002")]
        public void RationalToDecimalWithRounding(string leftString, string rightString)
        {
            var rational = (BigRational)decimal.Parse(leftString);
            var actual = (decimal)(rational / 10);
            var expected = decimal.Parse(rightString);
            Assert.AreEqual(expected, actual);
        }
    }
}
