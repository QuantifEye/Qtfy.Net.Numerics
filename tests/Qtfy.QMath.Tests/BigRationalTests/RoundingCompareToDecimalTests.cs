// <copyright file="RoundingCompareToDecimalTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using System;
    using NUnit.Framework;

    /// <summary>
    /// Compares the rounding methods against that of System.Math.Round(decimal, ...)
    /// </summary>
    [TestOf(typeof(BigRational))]
    public class RoundingCompareToDecimalTests
    {
        [Test]
        public void Round()
        {
            for (var v = -2.5M; v <= 2.5M; v += 0.0001M)
            {
                Compare(
                    Math.Round(v),
                    BigRational.Round(v));
            }
        }

        [Test]
        public void RoundWithDecimals()
        {
            for (var v = -2.5M; v <= 2.5M; v += 0.0001M)
            {
                for (int d = 0; d < 4; d++)
                {
                    Compare(
                        Math.Round(v, d),
                        BigRational.Round(v, d));
                }
            }
        }

        [Test]
        public void RoundWithDecimals2()
        {
            for (int d = -4; d <= 4; d++)
            {
                var scale = TenPow(d);
                for (var v = -2.5M; v <= 2.5M; v += 0.0001M)
                {
                    Compare(
                        Math.Round(v * scale) / scale,
                        BigRational.Round(v, d));
                }
            }
        }

        [TestCase(MidpointRounding.ToEven, RationalRounding.ToEven)]
        [TestCase(MidpointRounding.AwayFromZero, RationalRounding.AwayFromZero)]
        public void RoundWithRule(MidpointRounding decimalMode, RationalRounding rationalMode)
        {
            for (var v = -2.5M; v <= 2.5M; v += 0.0001M)
            {
                Compare(
                    Math.Round(v, decimalMode),
                    BigRational.Round(v, rationalMode));
            }
        }

        [TestCase(MidpointRounding.ToEven, RationalRounding.ToEven)]
        [TestCase(MidpointRounding.AwayFromZero, RationalRounding.AwayFromZero)]
        public void RoundWithRuleWithDecimals(MidpointRounding decimalMode, RationalRounding rationalMode)
        {
            for (int d = 0; d < 4; d++)
            {
                for (var v = -2.5M; v <= 2.5M; v += 0.0001M)
                {
                    Compare(
                        Math.Round(v, d, decimalMode),
                        BigRational.Round(v, d, rationalMode));
                }
            }
        }

        [TestCase(MidpointRounding.ToEven, RationalRounding.ToEven)]
        [TestCase(MidpointRounding.AwayFromZero, RationalRounding.AwayFromZero)]
        public void RoundWithRuleWithDecimals2(MidpointRounding decimalMode, RationalRounding rationalMode)
        {
            for (int d = -4; d <= 4; d++)
            {
                var scale = TenPow(d);
                for (var v = -2.5M; v <= 2.5M; v += 0.0001M)
                {
                    Compare(
                        Math.Round(v * scale, decimalMode) / scale,
                        BigRational.Round(v, d, rationalMode));
                }
            }
        }

        private static void Compare(BigRational expected, BigRational actual)
        {
            if (expected != actual)
            {
                Assert.AreEqual(expected, actual);
            }
        }

        private static decimal TenPow(int exp)
        {
            return exp < 0
                ? 1M / (int)Math.Pow(10, -exp)
                : (int)Math.Pow(10, exp);
        }
    }
}