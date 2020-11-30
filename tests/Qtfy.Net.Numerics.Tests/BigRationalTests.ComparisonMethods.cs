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
        [TestCase("1/2", "1/2", true)]
        public void EqualsBigRational(string leftRational, string rightRational, bool expected)
        {
            var r1 = BigRational.Parse(leftRational);
            var r2 = BigRational.Parse(rightRational);
            Assert.AreEqual(r1.Equals(r2), expected);
        }

        [TestCase("1", "1", true)]
        [TestCase("1/2", "2", false)]
        public void EqualsSignedIntegral(string leftRational, string rightInteger, bool expected)
        {
            var r1 = BigRational.Parse(leftRational);
            var r2 = BigInteger.Parse(rightInteger);
            Assert.AreEqual(expected, r1.Equals(r2));

            Assert.AreEqual(expected, r1.Equals((long)r2));
            Assert.AreEqual(expected, r1.Equals((int)r2));
            Assert.AreEqual(expected, r1.Equals((short)r2));
            Assert.AreEqual(expected, r1.Equals((sbyte)r2));
        }

        [TestCase("1", "1", true)]
        [TestCase("1/2", "2", false)]
        public void EqualsUnsignedIntegral(string leftRational, string rightInteger, bool expected)
        {
            var r1 = BigRational.Parse(leftRational);
            var r2 = BigInteger.Parse(rightInteger);
            Assert.AreEqual(expected, r1.Equals(r2));

            Assert.AreEqual(expected, r1.Equals((ulong)r2));
            Assert.AreEqual(expected, r1.Equals((uint)r2));
            Assert.AreEqual(expected, r1.Equals((ushort)r2));
            Assert.AreEqual(expected, r1.Equals((byte)r2));
        }

        [TestCase("1/2", "1/2", 0)]
        [TestCase("1/4", "1/2", -1)]
        [TestCase("1/2", "1/4", 1)]
        public void ComparableBigRational(string leftRational, string rightRational, int expected)
        {
            var r1 = BigRational.Parse(leftRational);
            var r2 = BigRational.Parse(rightRational);
            Assert.AreEqual(r1.CompareTo(r2), expected);
        }

        [TestCase("1", "1", 0)]
        [TestCase("1/2", "2", -1)]
        public void CompareToSignedIntegral(string leftRational, string rightInteger, int expected)
        {
            var r1 = BigRational.Parse(leftRational);
            var r2 = BigInteger.Parse(rightInteger);
            Assert.AreEqual(expected, r1.CompareTo(r2));

            Assert.AreEqual(expected, r1.CompareTo((long)r2));
            Assert.AreEqual(expected, r1.CompareTo((int)r2));
            Assert.AreEqual(expected, r1.CompareTo((short)r2));
            Assert.AreEqual(expected, r1.CompareTo((sbyte)r2));
        }

        [TestCase("1", "1", 0)]
        [TestCase("1/2", "2", -1)]
        public void CompareToUnsignedIntegral(string leftRational, string rightInteger, int expected)
        {
            var r1 = BigRational.Parse(leftRational);
            var r2 = BigInteger.Parse(rightInteger);
            Assert.AreEqual(expected, r1.CompareTo(r2));

            Assert.AreEqual(expected, r1.CompareTo((ulong)r2));
            Assert.AreEqual(expected, r1.CompareTo((uint)r2));
            Assert.AreEqual(expected, r1.CompareTo((ushort)r2));
            Assert.AreEqual(expected, r1.CompareTo((byte)r2));
        }
    }
}
