// <copyright file="ConvertFromBigRationalTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using NUnit.Framework;

    [TestOf(typeof(BigRational))]
    public class ConvertFromBigRationalTests
    {
        [Test]
        public void ToDecimal()
        {
            for (var decimalValue = -2.5M; decimalValue <= 2.5M; decimalValue += 0.0001M)
            {
                BigRational rational = decimalValue;
                Assert.AreEqual(decimalValue, (decimal)rational);
            }
        }

        [Test]
        public void ToDecimalWithRounding1()
        {
            var rational = new BigRational(2, 3);
            var expected = 0.666_666_666_666_666_666_666_666_666_7M;
            Assert.AreEqual(expected, (decimal)rational);
        }

        [Test]
        public void ToDecimalWithRounding2()
        {
            var rational = new BigRational(-2, 3);
            var expected = -0.666_666_666_666_666_666_666_666_666_7M;
            Assert.AreEqual(expected, (decimal)rational);
        }

        public void ToDecimalWithRounding3()
        {
            var rational = new BigRational(1, 3);
            var expected = 0.333_333_333_333_333_333_333_333_333_3M;
            Assert.AreEqual(expected, (decimal)rational);
        }

        public void ToDecimalWithRounding4()
        {
            var rational = new BigRational(-1, 3);
            var expected = -0.333_333_333_333_333_333_333_333_333_3M;
            Assert.AreEqual(expected, (decimal)rational);
        }

        [Test]
        public void ToDecimalWithRounding5()
        {
            var val = 0.000_000_000_000_000_000_000_000_000_5M;
            var actual = (decimal)((BigRational)val / 10);
            Assert.AreEqual(0M, actual);
        }

        [Test]
        public void ToDecimalWithRounding6()
        {
            var val = -0.000_000_000_000_000_000_000_000_000_5M;
            var actual = -(decimal)((BigRational)val / 10);
            Assert.AreEqual(0M, actual);
        }

        [Test]
        public void ToDecimalWithRounding7()
        {
            var val = 0.000_000_000_000_000_000_000_000_001_5M;
            var exp = 0.000_000_000_000_000_000_000_000_000_2M;
            var actual = (decimal)((BigRational)val / 10);
            Assert.AreEqual(exp, actual);
        }

        [Test]
        public void ToDecimalWithRounding8()
        {
            var val = -0.000_000_000_000_000_000_000_000_001_5M;
            var exp = -0.000_000_000_000_000_000_000_000_000_2M;
            var actual = (decimal)((BigRational)val / 10);
            Assert.AreEqual(exp, actual);
        }
    }
}
