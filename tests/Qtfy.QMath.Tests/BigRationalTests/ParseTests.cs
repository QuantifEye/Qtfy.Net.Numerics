// <copyright file="ParseTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using System;
    using NUnit.Framework;

    [TestOf(typeof(BigRational))]
    public class ParseTests
    {
        [TestCase("123/456", 123, 456)]
        [TestCase("123", 123, 1)]
        public void TestParseSuccessful(string from, int numerator, int denominator)
        {
            var expected = new BigRational(numerator, denominator);
            var actual = BigRational.Parse(from);
            Assert.AreEqual(expected, actual);
        }

        [TestCase("xyz")]
        [TestCase("123/0")]
        public void TestParseUnsuccessful(string from)
        {
            Assert.Throws<FormatException>(
                () => BigRational.Parse(from));
        }

        [TestCase("123/456", 123, 456, true)]
        [TestCase("xyz", 0, 0, false)]
        public void TestTryParse(string from, int numerator, int denominator, bool expectedSuccess)
        {
            BigRational expectedRational = expectedSuccess
                ? new BigRational(numerator, denominator)
                : default;

            var actualSuccess = BigRational.TryParse(from, out var actualRational);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedSuccess, actualSuccess);
                Assert.AreEqual(expectedRational, actualRational);
            });
        }
    }
}
