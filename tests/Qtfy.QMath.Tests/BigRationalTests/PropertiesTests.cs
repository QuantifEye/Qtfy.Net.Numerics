// <copyright file="PropertiesTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using NUnit.Framework;
    using static Qtfy.QMath.Tests.BigRationalTests.Data;

    /// <summary>
    /// This class does not try to test the Numerator or denominator properties as they are
    /// tested when testing the constructors.
    /// </summary>
    [TestOf(typeof(BigRational))]
    public class PropertiesTests
    {
        [TestCaseSource(typeof(ZeroCases))]
        public void IsZeroTrue(int num, int den)
        {
            Assert.True(new BigRational(num, den).IsZero);
        }

        [TestCaseSource(typeof(NegativeCases))]
        [TestCaseSource(typeof(PositiveCases))]
        public void IsZeroFalse(int num, int den)
        {
            Assert.False(new BigRational(num, den).IsZero);
        }

        [TestCaseSource(typeof(IsMinusOneCases))]
        public void IsMinusOneTrue(int numerator, int denominator)
        {
            Assert.True(new BigRational(numerator, denominator).IsMinusOne);
        }

        [TestCaseSource(typeof(NotMinusOneCases))]
        public void IsMinusOneFalse(int numerator, int denominator)
        {
            Assert.False(new BigRational(numerator, denominator).IsMinusOne);
        }

        [TestCaseSource(typeof(IsOneCases))]
        public void IsOneTrue(int numerator, int denominator)
        {
            Assert.True(new BigRational(numerator, denominator).IsOne);
        }

        [TestCaseSource(typeof(NotOneCases))]
        public void IsOneFalse(int numerator, int denominator)
        {
            Assert.False(new BigRational(numerator, denominator).IsOne);
        }

        [TestCaseSource(typeof(PositiveCases))]
        public void IsPositiveTrue(int num, int den)
        {
            Assert.True(new BigRational(num, den).IsPositive);
        }

        [TestCaseSource(typeof(ZeroCases))]
        [TestCaseSource(typeof(NegativeCases))]
        public void IsPositiveFalse(int num, int den)
        {
            Assert.False(new BigRational(num, den).IsPositive);
        }

        [TestCaseSource(typeof(NegativeCases))]
        public void IsNegativeTrue(int num, int den)
        {
            Assert.True(new BigRational(num, den).IsNegative);
        }

        [TestCaseSource(typeof(ZeroCases))]
        [TestCaseSource(typeof(PositiveCases))]
        public void IsNegativeFalse(int num, int den)
        {
            Assert.False(new BigRational(num, den).IsNegative);
        }

        [TestCaseSource(typeof(IsIntegerCases))]
        public void IsIntegerTrue(int num, int den)
        {
            var rational = new BigRational(num, den);
            Assert.True(rational.IsInteger);
        }

        [TestCaseSource(typeof(NotIntegerCases))]
        public void IsIntegerFalse(int num, int den)
        {
            var rational = new BigRational(num, den);
            Assert.False(rational.IsInteger);
        }

        [TestCaseSource(typeof(PositiveCases))]
        public void SignPositive(int num, int den)
        {
            Assert.AreEqual(1, new BigRational(num, den).Sign);
        }

        [TestCaseSource(typeof(NegativeCases))]
        public void SignNegative(int num, int den)
        {
            Assert.AreEqual(-1, new BigRational(num, den).Sign);
        }

        [TestCaseSource(typeof(ZeroCases))]
        public void SignZero(int num, int den)
        {
            Assert.AreEqual(0, new BigRational(num, den).Sign);
        }
    }
}
