// <copyright file="BigRationalTests.ComparisonMethods.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests
{
    using System.Numerics;
    using NUnit.Framework;

    public partial class BigRationalTests
    {
        [Test]
        public void EqualsObject()
        {
            BigRational rational = new BigRational(7);
            object obj = new BigRational(7);
            Assert.False(rational.Equals(new object()));
            Assert.True(rational.Equals(obj));
        }

        [TestCase("1/2", "1/2", true)]
        public void EqualsBigRational(string left, string right, bool expected)
        {
            Assert.AreEqual(
                expected,
                BigRational.Parse(left).Equals(BigRational.Parse(right)));
        }

        [TestCase("1", 1, true)]
        [TestCase("1/2", 2, false)]
        public void EqualsInteger(string left, int right, bool expected)
        {
            var rational = BigRational.Parse(left);
            Assert.AreEqual(expected, rational.Equals((BigInteger)right));
            Assert.AreEqual(expected, rational.Equals((long)right));
            Assert.AreEqual(expected, rational.Equals((int)right));
            Assert.AreEqual(expected, rational.Equals((short)right));
            Assert.AreEqual(expected, rational.Equals((sbyte)right));

            if (right >= 0)
            {
                Assert.AreEqual(expected, rational.Equals((ulong)right));
                Assert.AreEqual(expected, rational.Equals((uint)right));
                Assert.AreEqual(expected, rational.Equals((ushort)right));
                Assert.AreEqual(expected, rational.Equals((byte)right));
            }
        }

        [TestCase("1/2", "1/2", 0)]
        [TestCase("1/4", "1/2", -1)]
        [TestCase("1/2", "1/4", 1)]
        public void CompareToBigRational(string left, string right, int expected)
        {
            Assert.AreEqual(
                BigRational.Parse(left).CompareTo(BigRational.Parse(right)),
                expected);
        }

        [TestCase("1", 1, 0)]
        [TestCase("1/2", 2, -1)]
        public void CompareToInteger(string left, int right, int expected)
        {
            var rational = BigRational.Parse(left);
            Assert.AreEqual(expected, rational.CompareTo((BigInteger)right));
            Assert.AreEqual(expected, rational.CompareTo((long)right));
            Assert.AreEqual(expected, rational.CompareTo((int)right));
            Assert.AreEqual(expected, rational.CompareTo((short)right));
            Assert.AreEqual(expected, rational.CompareTo((sbyte)right));

            if (right >= 0)
            {
                Assert.AreEqual(expected, rational.CompareTo((ulong)right));
                Assert.AreEqual(expected, rational.CompareTo((uint)right));
                Assert.AreEqual(expected, rational.CompareTo((ushort)right));
                Assert.AreEqual(expected, rational.CompareTo((byte)right));
            }
        }
    }
}
