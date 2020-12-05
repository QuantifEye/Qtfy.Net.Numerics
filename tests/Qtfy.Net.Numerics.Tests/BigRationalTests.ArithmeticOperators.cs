// <copyright file="BigRationalTests.ArithmeticOperators.cs" company="QuantifEye">
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
        [TestCase("1/2", "-1/2")]
        [TestCase("-1/2", "1/2")]
        public void UnaryMinus(string inputString, string expectedString)
        {
            var rational = BigRational.Parse(inputString);
            var expected = BigRational.Parse(expectedString);
            AssertEqual(expected, -rational);
        }

        [TestCase("1/2")]
        [TestCase("-1/2")]
        public void UnaryPlus(string s)
        {
            var rational = BigRational.Parse(s);
            AssertEqual(rational, +rational);
        }

        [TestCase("1/2", "3/2")]
        public void IncrementTest(string inputString, string expectedString)
        {
            var rational = BigRational.Parse(inputString);
            var expected = BigRational.Parse(expectedString);
            AssertEqual(expected, ++rational);
        }

        [TestCase("1/2", "-1/2")]
        public void DecrementTest(string inputString, string expectedString)
        {
            var rational = BigRational.Parse(inputString);
            var expected = BigRational.Parse(expectedString);
            AssertEqual(expected, --rational);
        }

        [TestCase("1/2", "-1/2", "0")]
        [TestCase("1/2", "1/2", "1")]
        public void TestAddition(string leftString, string rightString, string expectedString)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            var expected = BigRational.Parse(expectedString);
            AssertEqual(expected, left + right);
            AssertEqual(expected, right + left);
        }

        [TestCase("1/2", "1/2", "0")]
        public void TestSubtraction(string leftString, string rightString, string expectedString)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            var expected = BigRational.Parse(expectedString);
            AssertEqual(expected, left - right);
            AssertEqual(-expected, right - left);
        }

        [TestCase("1/2", "1/2", "1/4")]
        public void TestMultiplication(string leftString, string rightString, string expectedString)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            var expected = BigRational.Parse(expectedString);
            AssertEqual(expected, left * right);
            AssertEqual(expected, right * left);
        }

        [TestCase("1/2", "1/2", "1")]
        public void TestDivision(string leftString, string rightString, string expectedString)
        {
            AssertEqual(
                BigRational.Parse(expectedString),
                BigRational.Parse(leftString) / BigRational.Parse(rightString));
        }

        [Test]
        public void TestDivideError(string leftString, string rightString)
        {
            var left = new BigRational(1, 2);
            var right = new BigRational(0);
            BigRational expected = default;
            Assert.Throws<DivideByZeroException>(
                () => expected = left / right);
        }

        [TestCase("3/2", "1", "1/2")]
        public void TestMod(string leftString, string rightString, string expectedString)
        {
            AssertEqual(
                BigRational.Parse(expectedString),
                BigRational.Parse(leftString) % BigRational.Parse(rightString));
        }

        /// <summary>
        /// Checks that mod works the same as BigInteger mod for integer values rationals.
        /// </summary>
        [TestCase(5, 3)]
        [TestCase(-5, 3)]
        [TestCase(5, -3)]
        [TestCase(-5, -3)]
        public void CheckModBigIntegerConsistency(int left, int right)
        {
            var leftInt = (BigInteger)left;
            var rightInt = (BigInteger)right;
            var expected = new BigRational(leftInt % rightInt);

            var leftRational = new BigRational(leftInt);
            var rightRational = new BigRational(rightInt);
            var actual = leftRational % rightRational;

            AssertEqual(expected, actual);
        }
    }
}