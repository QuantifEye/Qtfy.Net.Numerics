// <copyright file="ConvertToBigRationalTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using System.Collections;
    using System.Numerics;
    using NUnit.Framework;

    [TestOf(typeof(BigRational))]
    public class ConvertToBigRationalTests
    {
        [TestCase("0.125", 1, 8)]
        [TestCase("0.0125", 1, 80)]
        [TestCase("-0.125", -1, 8)]
        [TestCase("-0.0125", -1, 80)]
        public void FromDecimal(string dec, int numerator, int denominator)
        {
            var actual = (BigRational)decimal.Parse(dec);
            var expected = new BigRational(numerator, denominator);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0.125d, 1, 8)]
        [TestCase(0.25d, 1, 4)]
        [TestCase(-0.125d, -1, 8)]
        [TestCase(-0.25d, -1, 4)]
        public void FromDouble(double value, int numerator, int denominator)
        {
            var actual = (BigRational)value;
            var expected = new BigRational(numerator, denominator);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0.125f, 1, 8)]
        [TestCase(0.25f, 1, 4)]
        [TestCase(-0.125f, -1, 8)]
        [TestCase(-0.25f, -1, 4)]
        public void FromFloat(float value, int numerator, int denominator)
        {
            var actual = (BigRational)value;
            var expected = new BigRational(numerator, denominator);
            Assert.AreEqual(expected, actual);
        }

        [TestOf(typeof(Cases))]
        public void FromBigInteger(int value)
        {
            var expected = new BigRational(value);
            var actual = (BigRational)(BigInteger)value;
            Assert.AreEqual(expected, actual);
        }

        [TestOf(typeof(Cases))]
        public void FromUInt64(int value)
        {
            var expected = new BigRational(value);
            var actual = (BigRational)(ulong)value;
            Assert.AreEqual(expected, actual);
        }

        [TestOf(typeof(Cases))]
        public void FromUInt32(int value)
        {
            var expected = new BigRational(value);
            var actual = (BigRational)(uint)value;
            Assert.AreEqual(expected, actual);
        }

        [TestOf(typeof(Cases))]
        public void FromUInt16(int value)
        {
            var expected = new BigRational(value);
            var actual = (BigRational)(ushort)value;
            Assert.AreEqual(expected, actual);
        }

        [TestOf(typeof(Cases))]
        public void FromByte(int value)
        {
            var expected = new BigRational(value);
            var actual = (BigRational)(byte)value;
            Assert.AreEqual(expected, actual);
        }

        [TestOf(typeof(Cases))]
        public void FromInt64(int value)
        {
            var expected = new BigRational(value);
            var actual = (BigRational)(long)value;
            Assert.AreEqual(expected, actual);
        }

        [TestOf(typeof(Cases))]
        public void FromInt32(int value)
        {
            var expected = new BigRational(value);
            var actual = (BigRational)value;
            Assert.AreEqual(expected, actual);
        }

        [TestOf(typeof(Cases))]
        public void FromInt16(int value)
        {
            var expected = new BigRational(value);
            var actual = (BigRational)(short)value;
            Assert.AreEqual(expected, actual);
        }

        [TestOf(typeof(Cases))]
        public void FromSByte(int value)
        {
            var expected = new BigRational(value);
            var actual = (BigRational)(sbyte)value;
            Assert.AreEqual(expected, actual);
        }

        private class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return 1;
                yield return -1;
                yield return 0;
                yield return 2;
                yield return -2;
            }
        }
    }
}
