// <copyright file="BigRationalTests.ComparisonMethods.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests
{
    using System.Numerics;
    using NUnit.Framework;

    public partial class BigRationalTests
    {
        public void EqualsObject()
        {
            BigRational rational = new BigRational(7);
            object obj = new BigRational(7);
            Assert.False(rational.Equals(new object()));
            Assert.True(rational.Equals(obj));
        }

        [TestCase("1/2", "1/2", true)]
        public void EqualsBigRational(string leftRational, string rightRational, bool expected)
        {
            var left = BigRational.Parse(leftRational);
            var right = BigRational.Parse(rightRational);
            Assert.AreEqual(left.Equals(right), expected);
        }

        [TestCase("1", "1", true)]
        [TestCase("1/2", "2", false)]
        public void EqualsSignedIntegral(string leftRational, string rightInteger, bool expected)
        {
            var left = BigRational.Parse(leftRational);
            var right = BigInteger.Parse(rightInteger);
            Assert.AreEqual(expected, left.Equals(right));

            Assert.AreEqual(expected, left.Equals((long)right));
            Assert.AreEqual(expected, left.Equals((int)right));
            Assert.AreEqual(expected, left.Equals((short)right));
            Assert.AreEqual(expected, left.Equals((sbyte)right));
        }

        [TestCase("1", "1", true)]
        [TestCase("1/2", "2", false)]
        public void EqualsUnsignedIntegral(string leftRational, string rightInteger, bool expected)
        {
            var left = BigRational.Parse(leftRational);
            var right = BigInteger.Parse(rightInteger);
            Assert.AreEqual(expected, left.Equals(right));

            Assert.AreEqual(expected, left.Equals((ulong)right));
            Assert.AreEqual(expected, left.Equals((uint)right));
            Assert.AreEqual(expected, left.Equals((ushort)right));
            Assert.AreEqual(expected, left.Equals((byte)right));
        }

        [TestCase("1/2", "1/2", 0)]
        [TestCase("1/4", "1/2", -1)]
        [TestCase("1/2", "1/4", 1)]
        public void CompareToBigRational(string leftRational, string rightRational, int expected)
        {
            var left = BigRational.Parse(leftRational);
            var right = BigRational.Parse(rightRational);
            Assert.AreEqual(left.CompareTo(right), expected);
        }

        [TestCase("1", "1", 0)]
        [TestCase("1/2", "2", -1)]
        public void CompareToSignedIntegral(string leftRational, string rightInteger, int expected)
        {
            var left = BigRational.Parse(leftRational);
            var right = BigInteger.Parse(rightInteger);
            Assert.AreEqual(expected, left.CompareTo(right));

            Assert.AreEqual(expected, left.CompareTo((long)right));
            Assert.AreEqual(expected, left.CompareTo((int)right));
            Assert.AreEqual(expected, left.CompareTo((short)right));
            Assert.AreEqual(expected, left.CompareTo((sbyte)right));
        }

        [TestCase("1", "1", 0)]
        [TestCase("1/2", "2", -1)]
        public void CompareToUnsignedIntegral(string leftRational, string rightInteger, int expected)
        {
            var left = BigRational.Parse(leftRational);
            var right = BigInteger.Parse(rightInteger);
            Assert.AreEqual(expected, left.CompareTo(right));

            Assert.AreEqual(expected, left.CompareTo((ulong)right));
            Assert.AreEqual(expected, left.CompareTo((uint)right));
            Assert.AreEqual(expected, left.CompareTo((ushort)right));
            Assert.AreEqual(expected, left.CompareTo((byte)right));
        }
    }
}
