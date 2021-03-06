// <copyright file="ArrayMathTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    public class ArrayMathTests
    {
        [Test]
        public void TestClone()
        {
            int[] array = { 1, 2, 3 };
            var copy = array.Copy();
            Assert.AreEqual(array, copy);
            Assert.AreNotSame(copy, array);
        }

        [Test]
        public void TestAddConstant()
        {
            double[] array = { 1, 2, 3 };
            double[] expected = { 3, 4, 5 };
            var actual = ArrayMath.Add(array, 2d);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestAddArrays()
        {
            double[] left = { 1, 4, 234 };
            double[] right = { 23, 5467, 12 };
            Assert.AreEqual(
                ArrayMath.Add(left, right),
                left.Zip(right).Select(p => p.First + p.Second).ToArray());
        }

        [Test]
        public void TestAddArraysInvalidLength()
        {
            double[] left = { 1, 4, 234 };
            double[] right = { 23, 5467 };
            Assert.Throws<ArgumentException>(() => ArrayMath.Add(left, right));
        }

        [Test]
        public void TestSubtractConstant()
        {
            double[] array = { 1, 2, 3 };
            Assert.AreEqual(
                array.Select(x => x - 2).ToArray(),
                ArrayMath.Subtract(array, 2d));
        }

        [Test]
        public void TestSubtractArrays()
        {
            double[] left = { 1, 4, 234 };
            double[] right = { 23, 5467, 12 };
            Assert.AreEqual(
                left.Zip(right).Select(p => p.First - p.Second).ToArray(),
                ArrayMath.Subtract(left, right));
        }

        [Test]
        public void TestSubtractArraysInvalidLength()
        {
            double[] left = { 1, 4, 234 };
            double[] right = { 23, 5467 };
            Assert.Throws<ArgumentException>(() => ArrayMath.Subtract(left, right));
        }

        [TestCase(2d)]
        public void TestMultiplyConstant(double constant)
        {
            double[] array = { 1, 2, 3 };
            Assert.AreEqual(
                array.Select(x => x * constant).ToArray(),
                ArrayMath.Multiply(array, constant));
        }

        [Test]
        public void TestMultiplyArrays()
        {
            double[] left = { 1, 4, 234 };
            double[] right = { 23, 5467, 12 };
            Assert.AreEqual(
                left.Zip(right).Select(p => p.First * p.Second).ToArray(),
                ArrayMath.Multiply(left, right));
        }

        [Test]
        public void TestMultiplyArraysInvalidLength()
        {
            double[] left = { 1, 4, 234 };
            double[] right = { 23, 5467 };
            Assert.Throws<ArgumentException>(() => ArrayMath.Multiply(left, right));
        }
    }
}
