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
        public void EqualitySignedIntegerOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigInteger.Parse(rightString);
            Assert.AreEqual(left == right, expected);
            Assert.AreEqual(right == left, expected);

            Assert.AreEqual(left == (long)right, expected);
            Assert.AreEqual((long)right == left, expected);
            Assert.AreEqual(left == (int)right, expected);
            Assert.AreEqual((int)right == left, expected);
            Assert.AreEqual(left == (short)right, expected);
            Assert.AreEqual((short)right == left, expected);
            Assert.AreEqual(left == (sbyte)right, expected);
            Assert.AreEqual((sbyte)right == left, expected);
        }

        [TestCase("1/2", "1", false)]
        public void EqualityUnsignedIntegerOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigInteger.Parse(rightString);
            Assert.AreEqual(left == right, expected);
            Assert.AreEqual(right == left, expected);

            Assert.AreEqual(left == (ulong)right, expected);
            Assert.AreEqual((ulong)right == left, expected);
            Assert.AreEqual(left == (uint)right, expected);
            Assert.AreEqual((uint)right == left, expected);
            Assert.AreEqual(left == (ushort)right, expected);
            Assert.AreEqual((ushort)right == left, expected);
            Assert.AreEqual(left == (byte)right, expected);
            Assert.AreEqual((byte)right == left, expected);
        }

        [TestCase("1/2", "1/2", false)]
        public void InequalityBigRationalOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            Assert.AreEqual(left != right, expected);
            Assert.AreEqual(right != left, expected);
        }

        [TestCase("1/2", "1", false)]
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

        [TestCase("1/2", "1", false)]
        [TestCase("1/4", "1", true)]
        public void LessThanBigIntegerOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigInteger.Parse(rightString);
            Assert.AreEqual(left < right, expected);
            Assert.AreEqual(right > left, expected);
        }

        [TestCase("1/2", "1/2", false)]
        [TestCase("1/4", "1/2", true)]
        public void GreaterThanBigRationalOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            Assert.AreEqual(left > right, expected);
            Assert.AreEqual(right < left, expected);
        }

        [TestCase("1/2", "1/2", false)]
        [TestCase("1/4", "1/2", true)]
        public void GreaterThanBigIntegerOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            Assert.AreEqual(left > right, expected);
            Assert.AreEqual(right < left, expected);
        }

        [TestCase("1/2", "1/2", false)]
        [TestCase("1/4", "1/2", true)]
        public void GreaterThanOrEqualBigRationalOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            Assert.AreEqual(left >= right, expected);
            Assert.AreEqual(right <= left, expected);
        }

        [TestCase("1/2", "1/2", false)]
        [TestCase("1/4", "1/2", true)]
        public void GreaterThanOrEqualBigIntegerOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            Assert.AreEqual(left >= right, expected);
            Assert.AreEqual(right <= left, expected);
        }

        [TestCase("1/2", "1/2", false)]
        [TestCase("1/4", "1/2", true)]
        public void LessThanOrEqualBigRationalOperator(string leftString, string rightString, bool expected)
        {
            var left = BigRational.Parse(leftString);
            var right = BigRational.Parse(rightString);
            Assert.AreEqual(left <= right, expected);
            Assert.AreEqual(right >= left, expected);
        }

        [TestCase("1/2", "1", false)]
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
