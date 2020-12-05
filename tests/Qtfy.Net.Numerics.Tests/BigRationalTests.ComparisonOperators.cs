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
        public void TestEqualityOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            Assert.AreEqual(expected, left == right);
        }

        [TestCase("1/2", "1/2", false)]
        public void InequalityBigRationalOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            Assert.AreEqual(left != right, expected);
        }

        [TestCase("1/2", "1/2", false)]
        [TestCase("1/4", "1/2", true)]
        public void TestLessThanOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            Assert.AreEqual(right > left, expected);
        }

        [TestCase("1/2", "1/2", false)]
        [TestCase("1/4", "1/2", false)]
        public void TestGreaterThanOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            Assert.AreEqual(left > right, expected);
        }

        [TestCase("1/2", "1/2", true)]
        [TestCase("1/4", "1/2", false)]
        public void TestGreaterThanOrEqualOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            Assert.AreEqual(left >= right, expected);
        }

        [TestCase("1/2", "1/2", true)]
        [TestCase("1/4", "1/2", true)]
        public void TestLEssThanOrEqualOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            Assert.AreEqual(left <= right, expected);
        }
    }
}
