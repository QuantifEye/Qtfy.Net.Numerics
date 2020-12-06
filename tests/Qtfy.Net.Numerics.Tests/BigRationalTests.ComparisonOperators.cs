// <copyright file="BigRationalTests.ComparisonOperators.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests
{
    using NUnit.Framework;

    public partial class BigRationalTests
    {
        [TestCase("1/2", "1/2", true)]
        public void TestEqualityOperator(string left, string right, bool expected)
        {
            Assert.AreEqual(
                expected,
                BigRational.Parse(left) == BigRational.Parse(right));
        }

        [TestCase("1/2", "1/2", false)]
        public void InequalityBigRationalOperator(string left, string right, bool expected)
        {
            Assert.AreEqual(
                expected,
                BigRational.Parse(left) != BigRational.Parse(right));
        }

        [TestCase("1/2", "1/2", false)]
        [TestCase("1/4", "1/2", true)]
        public void TestLessThanOperator(string left, string right, bool expected)
        {
            Assert.AreEqual(
                expected,
                BigRational.Parse(left) < BigRational.Parse(right));
        }

        [TestCase("1/2", "1/2", false)]
        [TestCase("1/4", "1/2", false)]
        public void TestGreaterThanOperator(string left, string right, bool expected)
        {
            Assert.AreEqual(
                expected,
                BigRational.Parse(left) > BigRational.Parse(right));
        }

        [TestCase("1/2", "1/2", true)]
        [TestCase("1/4", "1/2", false)]
        public void TestGreaterThanOrEqualOperator(string left, string right, bool expected)
        {
            Assert.AreEqual(
                expected,
                BigRational.Parse(left) >= BigRational.Parse(right));
        }

        [TestCase("1/2", "1/2", true)]
        [TestCase("1/4", "1/2", true)]
        public void TestLessThanOrEqualOperator(string left, string right, bool expected)
        {
            Assert.AreEqual(
                expected,
                BigRational.Parse(left) <= BigRational.Parse(right));
        }
    }
}
