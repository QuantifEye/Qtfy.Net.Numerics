// <copyright file="ConstantsTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using System.Numerics;
    using NUnit.Framework;

    [TestOf(typeof(BigRational))]
    public class ConstantsTests
    {
        [Test]
        public void Zero()
        {
            var rational = BigRational.Zero;
            Assert.AreEqual(BigInteger.Zero, rational.Numerator);
            Assert.AreEqual(BigInteger.One, rational.Denominator);
        }

        [Test]
        public void One()
        {
            var rational = BigRational.One;
            Assert.AreEqual(BigInteger.One, rational.Numerator);
            Assert.AreEqual(BigInteger.One, rational.Denominator);
        }

        [Test]
        public void MinusOne()
        {
            var rational = BigRational.MinusOne;
            Assert.AreEqual(BigInteger.MinusOne, rational.Numerator);
            Assert.AreEqual(BigInteger.One, rational.Denominator);
        }

        [Test]
        public void Half()
        {
            var rational = BigRational.Half;
            Assert.AreEqual((BigInteger)1, rational.Numerator);
            Assert.AreEqual((BigInteger)2, rational.Denominator);
        }
    }
}
