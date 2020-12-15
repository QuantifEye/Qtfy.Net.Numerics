// <copyright file="SeriesExpansionTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests
{
    using System;
    using NUnit.Framework;
    using Qtfy.Net.Numerics.BigMath;

    public class SeriesExpansionTests
    {
        [TestCase(7, 14)]
        public void EulerConstantTaylorExpansion(int numerator, int denominator)
        {
            var power = new BigRational(numerator, denominator);
            BigRational t0 = 0;
            BigRational t1 = 1;
            BigRational t2 = power;
            BigRational t3 = (power * power) / 2;
            BigRational t4 = (power * power * power) / 6;
            Assert.AreEqual(
                t0,
                SeriesExpansions.Exp(power, 0));
            Assert.AreEqual(
                t0 + t1,
                SeriesExpansions.Exp(power, 1));
            Assert.AreEqual(
                t0 + t1 + t2,
                SeriesExpansions.Exp(power, 2));
            Assert.AreEqual(
                t0 + t1 + t2 + t3,
                SeriesExpansions.Exp(power, 3));
            Assert.AreEqual(
                t0 + t1 + t2 + t3 + t4,
                SeriesExpansions.Exp(power, 4));
        }

        [TestCase(2, 23)]
        [TestCase(25, 80)]
        public void DoublePrecisionEulerConstant(double x, int terms)
        {
            var exp = Math.Exp(x);
            BigRational lower = Math.BitDecrement(exp);
            BigRational upper = Math.BitIncrement(exp);
            BigRational actual = SeriesExpansions.Exp(x, terms);
            Assert.True(lower < actual && actual < upper);
        }

        [TestCase(2, 15)]
        [TestCase(25, 197)]
        public void DoublePrecisionLog(double x, int terms)
        {
            var log = Math.Log(x);
            BigRational upper = Math.BitIncrement(log);
            BigRational lower = Math.BitDecrement(log);
            BigRational actual = SeriesExpansions.Log(x, terms);
            Assert.True(lower < actual && actual < upper);
        }

        [Test]
        public void TestExpInvalidTerms()
        {
            Assert.Throws<ArgumentException>(
                () => SeriesExpansions.Exp(0, -1));
        }

        [Test]
        public void TestLogInvalidTerms()
        {
            Assert.Throws<ArgumentException>(
                () => SeriesExpansions.Log(0, -1));
        }
    }
}
