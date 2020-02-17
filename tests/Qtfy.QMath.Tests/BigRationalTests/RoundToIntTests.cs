// <copyright file="RoundToIntTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using System.Collections;
    using System.Numerics;
    using NUnit.Framework;

    [TestOf(typeof(BigRational))]
    public class RoundToIntTests
    {
        [TestCaseSource(typeof(RoundUpCases))]
        [TestCaseSource(typeof(RoundCases))]
        public void RoundUpImpl(BigInteger rounded, BigRational unRounded)
        {
            Assert.AreEqual(rounded, BigRational.RoundUp(unRounded));
        }

        [TestCaseSource(typeof(RoundDownCases))]
        [TestCaseSource(typeof(RoundCases))]
        public void RoundDown(BigInteger rounded, BigRational unRounded)
        {
            Assert.AreEqual(rounded, BigRational.RoundDown(unRounded));
        }

        [TestCaseSource(typeof(RoundAwayFromZeroCases))]
        [TestCaseSource(typeof(RoundCases))]
        public void RoundAwayFromZero(BigInteger rounded, BigRational unRounded)
        {
            Assert.AreEqual(rounded, BigRational.RoundAwayFromZero(unRounded));
        }

        [TestCaseSource(typeof(RoundToEvenCases))]
        [TestCaseSource(typeof(RoundCases))]
        public void RoundToEven(BigInteger rounded, BigRational unRounded)
        {
            Assert.AreEqual(rounded, BigRational.RoundToEven(unRounded));
        }

        [TestCaseSource(typeof(RoundTowardZeroCases))]
        [TestCaseSource(typeof(RoundCases))]
        public void RoundTowardZero(BigInteger rounded, BigRational unRounded)
        {
            Assert.AreEqual(rounded, BigRational.RoundTowardZero(unRounded));
        }

        private static object[] Case(BigInteger rounded, BigRational unRounded)
        {
            return new object[] { rounded, unRounded };
        }

        public class RoundCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return Case(0, 0.49M);
                yield return Case(1, 0.51M);
                yield return Case(1, 1.49M);
                yield return Case(2, 1.51M);
                yield return Case(0, -0.49M);
                yield return Case(-1, -0.51M);
                yield return Case(-1, -1.49M);
                yield return Case(-2, -1.51M);
            }
        }

        private class RoundToEvenCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return Case(0, 0.50M);
                yield return Case(2, 1.50M);
                yield return Case(0, -0.50M);
                yield return Case(-2, -1.50M);
            }
        }

        private class RoundTowardZeroCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return Case(0, 0.50M);
                yield return Case(1, 1.50M);
                yield return Case(0, -0.50M);
                yield return Case(-1, -1.50M);
            }
        }

        private class RoundAwayFromZeroCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return Case(1, 0.50M);
                yield return Case(2, 1.50M);
                yield return Case(-1, -0.50M);
                yield return Case(-2, -1.50M);
            }
        }

        private class RoundDownCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return Case(0, 0.50M);
                yield return Case(1, 1.50M);
                yield return Case(-1, -0.50M);
                yield return Case(-2, -1.50M);
            }
        }

        private class RoundUpCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return Case(1, 0.50M);
                yield return Case(2, 1.50M);
                yield return Case(0, -0.50M);
                yield return Case(-1, -1.50M);
            }
        }
    }
}