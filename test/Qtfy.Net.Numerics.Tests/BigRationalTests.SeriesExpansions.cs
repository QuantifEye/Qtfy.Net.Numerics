// <copyright file="BigRationalTests.SeriesExpansions.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests
{
    using System;
    using NUnit.Framework;

    public partial class BigRationalTests
    {
        [TestCase(7, 14)]
        public void EulerConstantTaylorExpansion(int numerator, int denominator)
        {
            var power = new BigRational(numerator, denominator);
            Assert.AreEqual(
                new BigRational(0),
                BigRational.Exp(power, 0));
            Assert.AreEqual(
                new BigRational(1),
                BigRational.Exp(power, 1));
            Assert.AreEqual(
                1 + power,
                BigRational.Exp(power, 2));
            Assert.AreEqual(
                1 + power,
                BigRational.Exp(power, 2));
            Assert.AreEqual(
                1 + power + ((power * power) / 2),
                BigRational.Exp(power, 3));
            Assert.AreEqual(
                1 + power + ((power * power) / 2) + ((power * power * power) / 6),
                BigRational.Exp(power, 4));
        }

        [TestCase(2)]
        [TestCase(100.5)]
        public void DoublePrecisionEulerConstant(double x)
        {
            var exp = Math.Exp(x);
            BigRational lower = Math.BitDecrement(exp);
            BigRational upper = Math.BitIncrement(exp);
            BigRational actual = BigRational.Exp(x, 500);
            Assert.True(actual < upper);
            Assert.True(actual > lower);
        }

        [TestCase(2)]
        [TestCase(100.5)]
        public void DoublePrecisionLog(double x)
        {
            var log = Math.Log(x);
            BigRational upper = Math.BitIncrement(log);
            BigRational lower = Math.BitDecrement(log);
            BigRational actual = BigRational.Log(x, 1000);
            Assert.True(actual < upper);
            Assert.True(actual > lower);
        }
    }
}
