// <copyright file="ConstructorTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using System;
    using System.Collections;
    using System.Numerics;
    using NUnit.Framework;

    [TestOf(typeof(BigRational))]
    public class ConstructorTests
    {
        /// <summary>
        /// Test that the default initialized <see cref="BigRational"/> is equal to (0/1).
        /// </summary>
        [Test]
        public void DefaultInitialize()
        {
            BigRational rational = default;
            Assert.AreEqual(BigInteger.Zero, rational.Numerator);
            Assert.AreEqual(BigInteger.One, rational.Denominator);
            Assert.AreEqual(BigRational.Zero, rational);
        }

        /// <summary>
        /// Test that a <see cref="BigRational"/> is constructed correctly from only a numerator.
        /// </summary>
        [TestCaseSource(typeof(NumeratorCases))]
        public void ConstructFromNumerator(int numerator)
        {
            var rational = new BigRational(numerator);
            Assert.Multiple(() =>
            {
                Assert.AreEqual((BigInteger)numerator, rational.Numerator);
                Assert.AreEqual(BigInteger.One, rational.Denominator);
            });
        }

        /// <summary>
        /// Tests that the constructor throws a <see cref="DivideByZeroException"/> if constructed with
        /// a zero denominator.
        /// </summary>
        [TestCaseSource(typeof(NumeratorCases))]
        public void ConstructInvalid(int numerator)
        {
            Assert.Throws<DivideByZeroException>(
                () => new BigRational(numerator, 0));
        }

        /// <summary>
        /// Tests that all validly constructed <see cref="BigRational"/>s have co-prime numerator and denominators.
        /// </summary>
        [TestCaseSource(typeof(PositiveCases))]
        [TestCaseSource(typeof(NegativeCases))]
        [TestCaseSource(typeof(ZeroCases))]
        public void IsCoPrime(int numerator, int denominator)
        {
            var rational = new BigRational(numerator, denominator);
            var one = BigInteger.One;
            var gcd = BigInteger.GreatestCommonDivisor(rational.Numerator, rational.Denominator);
            Assert.AreEqual(one, gcd);
        }

        /// <summary>
        /// Tests that a positive <see cref="BigRational"/> has a positive numerator and a positive denominator.
        /// </summary>
        [TestCaseSource(typeof(PositiveCases))]
        public void ConstructPositive(int numerator, int denominator)
        {
            var rational = new BigRational(numerator, denominator);
            Assert.True(rational.Numerator > 0);
            Assert.True(rational.Denominator > 0);
        }

        /// <summary>
        /// Tests that a negative <see cref="BigRational"/> has a negative numerator and a positive denominator.
        /// </summary>
        [TestCaseSource(typeof(NegativeCases))]
        public void ConstructNegative(int numerator, int denominator)
        {
            var rational = new BigRational(numerator, denominator);
            Assert.True(rational.Numerator < 0);
            Assert.True(rational.Denominator > 0);
        }

        /// <summary>
        /// Tests that a zero <see cref="BigRational"/> is represented as 0/1
        /// </summary>
        [TestCaseSource(typeof(ZeroCases))]
        public void ConstructZero(int numerator, int denominator)
        {
            var rational = new BigRational(numerator, denominator);
            Assert.AreEqual(BigInteger.Zero, rational.Numerator);
            Assert.AreEqual(BigInteger.One, rational.Denominator);
        }

        /// <summary>
        /// The test cases used to construct valid zero <see cref="BigRational"/> objects.
        /// </summary>
        private class ZeroCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                for (var d = 1; d < 10; d++)
                {
                    yield return new object[] { 0, -d };
                    yield return new object[] { 0, d };
                }
            }
        }

        /// <summary>
        /// The test cases used to construct valid negative <see cref="BigRational"/> objects.
        /// </summary>
        private class NegativeCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                for (var n = 1; n <= 10; n++)
                {
                    for (var d = 1; d <= 10; d++)
                    {
                        yield return new object[] { -n, d };
                        yield return new object[] { n, -d };
                    }
                }
            }
        }

        /// <summary>
        /// The test cases used to construct valid positive <see cref="BigRational"/> objects.
        /// </summary>
        private class PositiveCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                for (var n = 1; n <= 10; n++)
                {
                    for (var d = 1; d <= 10; d++)
                    {
                        yield return new object[] { -n, -d };
                        yield return new object[] { n, d };
                    }
                }
            }
        }

        /// <summary>
        /// The test cases used to construct a valid <see cref="BigRational"/> from only a numerator.
        /// </summary>
        private class NumeratorCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                var size = 31;
                for (var i = -size; i <= size; i++)
                {
                    yield return i;
                }
            }
        }
    }
}