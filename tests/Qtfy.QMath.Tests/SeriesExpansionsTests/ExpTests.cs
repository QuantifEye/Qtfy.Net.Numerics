// <copyright file="ExpTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.SeriesExpansionsTests
{
    using System;
    using NUnit.Framework;

    public class ExpTests
    {
        [TestCase(7, 14)]
        public void TestExpansion(int numerator, int denominator)
        {
            var power = new BigRational(numerator, denominator);
            Assert.AreEqual(
                BigRational.Zero,
                SeriesExpansions.Exp(power, 0));
            Assert.AreEqual(
                BigRational.One,
                SeriesExpansions.Exp(power, 1));
            Assert.AreEqual(
                1 + power,
                SeriesExpansions.Exp(power, 2));
            Assert.AreEqual(
                1 + power,
                SeriesExpansions.Exp(power, 2));
            Assert.AreEqual(
                1 + power + ((power * power) / 2),
                SeriesExpansions.Exp(power, 3));
            Assert.AreEqual(
                1 + power + ((power * power) / 2) + ((power * power * power) / 6),
                SeriesExpansions.Exp(power, 4));
        }

        [TestCase(2)]
        [TestCase(100.5)]
        public void TestExp(double x)
        {
            var exp = Math.Exp(x);
            BigRational lower = Math.BitDecrement(exp);
            BigRational upper = Math.BitIncrement(exp);
            BigRational actual = SeriesExpansions.Exp(x, 500);
            Assert.True(actual < upper);
            Assert.True(actual > lower);
        }
    }
}
