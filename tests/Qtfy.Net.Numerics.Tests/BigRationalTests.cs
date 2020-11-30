// <copyright file="BigRationalTests.cs" company="QuantifEye">
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
        public static void AssertCanonical(BigRational rational)
        {
            Assert.True(rational.Denominator > BigInteger.Zero);
            var n = BigInteger.Abs(rational.Numerator);
            var d = BigInteger.Abs(rational.Denominator);
            var gcd = BigInteger.GreatestCommonDivisor(n, d);
            Assert.AreEqual(n, n / gcd);
            Assert.AreEqual(d, d / gcd);
        }

        public static void AssertEqual(BigRational left, BigRational right)
        {
            BigRationalTests.AssertCanonical(left);
            BigRationalTests.AssertCanonical(right);
            Assert.AreEqual(left.Numerator, right.Numerator);
            Assert.AreEqual(left.Denominator, right.Denominator);
        }

        public static void AssertEqual(BigRational left, BigInteger right)
        {
            AssertCanonical(left);
            Assert.AreEqual(left.Numerator, right);
            Assert.AreEqual(left.Denominator, BigInteger.One);
        }

        public static void AssertEqual(BigInteger left, BigRational right)
        {
            BigRationalTests.AssertEqual(right, left);
        }

        /// <summary>
        /// Test that the default initialized <see cref="BigRational"/> is equal to (0/1).
        /// </summary>
        [Test]
        public void DefaultInitialize()
        {
            BigRational rational = default;
            AssertCanonical(rational);
            Assert.AreEqual(BigInteger.Zero, rational.Numerator);
            Assert.AreEqual(BigInteger.One, rational.Denominator);
        }

        /// <summary>
        /// Test that a <see cref="BigRational"/> is constructed correctly from only a numerator.
        /// </summary>
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(-1)]
        [TestCase(-2)]
        public void ConstructFromNumerator(int numerator)
        {
            var rational = new BigRational((BigInteger)numerator);
            AssertCanonical(rational);
            Assert.AreEqual((BigInteger)numerator, rational.Numerator);
            Assert.AreEqual(BigInteger.One, rational.Denominator);
        }

        /// <summary>
        /// Tests that a positive <see cref="BigRational"/> has a positive numerator and a positive denominator.
        /// </summary>
        [TestCase(1, 2, 1, 2)]
        [TestCase(-1, -2, 1, 2)]
        [TestCase(-1, 2, -1, 2)]
        [TestCase(1, -2, -1, 2)]

        [TestCase(2, 4, 1, 2)]
        [TestCase(-2, -4, 1, 2)]
        [TestCase(-2, 4, -1, 2)]
        [TestCase(2, -4, -1, 2)]

        [TestCase(2, 1, 2, 1)]
        [TestCase(-2, -1, 2, 1)]
        [TestCase(-2, 1, -2, 1)]
        [TestCase(2, -1, -2, 1)]

        [TestCase(4, 2, 2, 1)]
        [TestCase(-4, -2, 2, 1)]
        [TestCase(-4, 2, -2, 1)]
        [TestCase(4, -2, -2, 1)]
        public void Construct(int n1, int d1, int n2, int d2)
        {
            var rational = new BigRational(n1, d1);
            AssertCanonical(rational);
            Assert.AreEqual(rational.Numerator, (BigInteger)n2);
            Assert.AreEqual(rational.Denominator, (BigInteger)d2);
        }

        /// <summary>
        /// Tests that the constructor throws a <see cref="DivideByZeroException"/> if constructed with
        /// a zero denominator.
        /// </summary>
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(-1)]
        [TestCase(-2)]
        public void ConstructInvalid(int numerator)
        {
            Assert.Throws<DivideByZeroException>(
                () => new BigRational(numerator, 0));
        }

        [TestCase("1/2", 1)]
        [TestCase("-1/2", -1)]
        [TestCase("0/1", 0)]
        public void Sign(string value, int expected)
        {
            Assert.AreEqual(expected, BigRational.Parse(value).Sign);
        }

        [TestCase("1/2", true)]
        public void IsPositive(string value, bool expected)
        {
            Assert.AreEqual(expected, BigRational.Parse(value).IsPositive);
        }

        [TestCase("1/2", false)]
        public void IsNegative(string value, bool expected)
        {
            Assert.AreEqual(expected, BigRational.Parse(value).IsNegative);
        }

        [TestCase("1/2", false)]
        public void IsZero(string value, bool expected)
        {
            Assert.AreEqual(expected, BigRational.Parse(value).IsZero);
        }

        [TestCase("1/2", false)]
        public void IsOne(string value, bool expected)
        {
            Assert.AreEqual(expected, BigRational.Parse(value).IsOne);
        }

        [TestCase("1/2", false)]
        public void IsMinusOne(string value, bool expected)
        {
            Assert.AreEqual(expected, BigRational.Parse(value).IsMinusOne);
        }

        [TestCase("1/2", false)]
        [TestCase("1", true)]
        public void IsInteger(string value, bool expected)
        {
            Assert.AreEqual(expected, BigRational.Parse(value).IsInteger);
        }

        [Test]
        public void Deconstruct()
        {
            var (n, d) = new BigRational(7, 3);
            Assert.AreEqual((BigInteger)7, n);
            Assert.AreEqual((BigInteger)3, d);
        }

        [TestCase("1/2", "1/2")]
        [TestCase("-1/2", "1/2")]
        public void Abs(string actualString, string expectedString)
        {
            var actual = BigRational.Abs(BigRational.Parse(actualString));
            var expected = BigRational.Parse(expectedString);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2)]
        [TestCase(-1, 2)]
        public void Reciprocal(int n1, int n2)
        {
            var rational = new BigRational(n1, n2);
            var expected = new BigRational(n2, n1);
            var actual = rational.Reciprocal();
            AssertEqual(expected, actual);
        }

        [Test]
        public void ReciprocalZero()
        {
            var rational = new BigRational(0, 1);
            Assert.Throws<DivideByZeroException>(
                () => rational.Reciprocal());
        }

        [TestCase("1/2", "1/4")]
        public void MinAndMax(string max, string min)
        {
            BigRational maximum = BigRational.Parse(max);
            BigRational minimum = BigRational.Parse(min);
            BigRationalTests.AssertEqual(maximum, BigRational.Max(maximum, minimum));
            BigRationalTests.AssertEqual(maximum, BigRational.Max(minimum, maximum));
            BigRationalTests.AssertEqual(minimum, BigRational.Min(maximum, minimum));
            BigRationalTests.AssertEqual(minimum, BigRational.Min(minimum, maximum));
        }

        [TestCase("1/1", 1, "1/1")]
        [TestCase("1/1", 0, "1/1")]
        public void Pow(string value, int power, string result)
        {
            BigRational rational = BigRational.Parse(value);
            BigRational expected = BigRational.Parse(result);
            BigRationalTests.AssertEqual(expected, BigRational.Pow(rational, power));
        }

        [Test]
        public void PowError()
        {
            Assert.Throws<ArgumentException>(
                () => BigRational.Pow(0, 0));
        }

        [TestCase(1, 2, "1/2")]
        public void TestToString(int numerator, int denominator, string expected)
        {
            Assert.AreEqual(expected, new BigRational(numerator, denominator).ToString());
        }

        [TestCase("123/456", 123, 456)]
        [TestCase("123", 123, 1)]
        public void TestParseSuccessful(string from, int numerator, int denominator)
        {
            var expected = new BigRational(numerator, denominator);
            var actual = BigRational.Parse(from);
            BigRationalTests.AssertEqual(expected, actual);
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