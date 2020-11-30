// <copyright file="BigRationalTests.ComparisonOperators.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests
{
    using System.Numerics;
    using NUnit.Framework;

    public partial class BigRationalTests
    {
        [TestCase("1/2", "1/2", true)]
        public void EqualityBigRationalOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            Assert.AreEqual(expected, left == right);
            Assert.AreEqual(expected, right == left);
        }

        [TestCase("1/2", "1", false)]
        public void EqualityBigIntegerOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigInteger.Parse(rightString);
            Assert.AreEqual(left == right, expected);
            Assert.AreEqual(right == left, expected);
        }

        [TestCase("1/2", "1/2", false)]
        public void InequalityBigRationalOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            Assert.AreEqual(left != right, expected);
            Assert.AreEqual(right != left, expected);
        }

        [TestCase("1/2", "1", true)]
        public void InequalityBigIntegerOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigInteger.Parse(rightString);
            Assert.AreEqual(left != right, expected);
            Assert.AreEqual(right != left, expected);
        }

        [TestCase("1/2", "1/2", false)]
        [TestCase("1/4", "1/2", true)]
        public void LessThanBigRationalOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            Assert.AreEqual(left < right, expected);
            Assert.AreEqual(right > left, expected);
        }

        [TestCase("1/2", "1", true)]
        [TestCase("1/4", "1", true)]
        public void LessThanBigIntegerOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigInteger.Parse(rightString);
            Assert.AreEqual(left < right, expected);
            Assert.AreEqual(right > left, expected);
        }

        [TestCase("1/2", "1/2", false)]
        [TestCase("1/4", "1/2", false)]
        public void GreaterThanBigRationalOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            Assert.AreEqual(left > right, expected);
            Assert.AreEqual(right < left, expected);
        }

        [TestCase("1/2", "1", false)]
        [TestCase("1/4", "1", false)]
        public void GreaterThanBigIntegerOperator(string rationalString, string integerString, bool expected)
        {
            var left = BigRational.Parse(rationalString);
            var right = BigInteger.Parse(integerString);
            Assert.AreEqual(left > right, expected);
            Assert.AreEqual(right < left, expected);
        }

        [TestCase("1/2", "1/2", true)]
        [TestCase("1/4", "1/2", false)]
        public void GreaterThanOrEqualBigRationalOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            Assert.AreEqual(left >= right, expected);
            Assert.AreEqual(right <= left, expected);
        }

        [TestCase("1/2", "1", false)]
        [TestCase("1/4", "1", false)]
        public void GreaterThanOrEqualBigIntegerOperator(string rationalString, string integerString, bool expected)
        {
            var left = BigRational.Parse(rationalString);
            var right = BigInteger.Parse(integerString);
            Assert.AreEqual(left >= right, expected);
            Assert.AreEqual(right <= left, expected);
        }

        [TestCase("1/2", "1/2", true)]
        [TestCase("1/4", "1/2", true)]
        public void LessThanOrEqualBigRationalOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            Assert.AreEqual(left <= right, expected);
            Assert.AreEqual(right >= left, expected);
        }

        [TestCase("1/2", "1", true)]
        [TestCase("1/4", "1", true)]
        public void LessThanOrEqualBigIntegerOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigInteger.Parse(rightString);
            Assert.AreEqual(left <= right, expected);
            Assert.AreEqual(right >= left, expected);
        }
    }
}
