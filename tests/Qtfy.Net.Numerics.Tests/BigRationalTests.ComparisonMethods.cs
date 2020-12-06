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

        [TestCase("-1", -1, true)]
        [TestCase("1/2", -2, false)]
        public void EqualsNegativeInteger(string rational, int integer, bool expected)
        {
            var left = BigRational.Parse(rational);
            Assert.AreEqual(expected, left.Equals((BigInteger)integer));
            Assert.AreEqual(expected, left.Equals((long)integer));
            Assert.AreEqual(expected, left.Equals((int)integer));
            Assert.AreEqual(expected, left.Equals((short)integer));
            Assert.AreEqual(expected, left.Equals((sbyte)integer));
        }

        [TestCase("1", 1, true)]
        [TestCase("1/2", 2, false)]
        public void EqualsPositiveInteger(string rational, int integer, bool expected)
        {
            var left = BigRational.Parse(rational);
            Assert.AreEqual(expected, left.Equals((BigInteger)integer));
            Assert.AreEqual(expected, left.Equals((ulong)integer));
            Assert.AreEqual(expected, left.Equals((uint)integer));
            Assert.AreEqual(expected, left.Equals((ushort)integer));
            Assert.AreEqual(expected, left.Equals((byte)integer));
            Assert.AreEqual(expected, left.Equals((ulong)integer));
            Assert.AreEqual(expected, left.Equals((uint)integer));
            Assert.AreEqual(expected, left.Equals((ushort)integer));
            Assert.AreEqual(expected, left.Equals((byte)integer));
        }

        [TestCase("1/2", "1/2", 0)]
        [TestCase("1/4", "1/2", -1)]
        [TestCase("1/2", "1/4", 1)]
        public void CompareToBigRational(string rational, string rightRational, int expected)
        {
            var left = BigRational.Parse(rational);
            var right = BigRational.Parse(rightRational);
            Assert.AreEqual(left.CompareTo(right), expected);
        }

        [TestCase("1", 1, 0)]
        [TestCase("1/2", 2, -1)]
        public void CompareToPositiveInteger(string rational, int integer, int expected)
        {
            var left = BigRational.Parse(rational);
            Assert.AreEqual(expected, left.CompareTo(integer));
            Assert.AreEqual(expected, left.CompareTo((long)integer));
            Assert.AreEqual(expected, left.CompareTo((int)integer));
            Assert.AreEqual(expected, left.CompareTo((short)integer));
            Assert.AreEqual(expected, left.CompareTo((sbyte)integer));
            Assert.AreEqual(expected, left.CompareTo((ulong)integer));
            Assert.AreEqual(expected, left.CompareTo((uint)integer));
            Assert.AreEqual(expected, left.CompareTo((ushort)integer));
            Assert.AreEqual(expected, left.CompareTo((byte)integer));
        }

        [TestCase("1", -1, 1)]
        [TestCase("1/2", -2, 1)]
        public void CompareToNegativeInteger(string rational, int integer, int expected)
        {
            var left = BigRational.Parse(rational);
            Assert.AreEqual(expected, left.CompareTo(integer));
            Assert.AreEqual(expected, left.CompareTo((long)integer));
            Assert.AreEqual(expected, left.CompareTo((int)integer));
            Assert.AreEqual(expected, left.CompareTo((short)integer));
            Assert.AreEqual(expected, left.CompareTo((sbyte)integer));
        }
    }
}