// <copyright file="ComparisonTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using System.Collections;
    using NUnit.Framework;

    [TestOf(typeof(BigRational))]
    public class ComparisonTests
    {
        [TestCaseSource(typeof(EqualCases))]
        public void EqualOperatorTrue(BigRational left, BigRational right)
        {
            Assert.True(left == right);
            Assert.True(right == left);
            Assert.False(left != right);
            Assert.False(right != left);

            Assert.True(left >= right);
            Assert.True(right >= left);
            Assert.True(left <= right);
            Assert.True(right <= left);

            Assert.False(left > right);
            Assert.False(right > left);
            Assert.False(left < right);
            Assert.False(right < left);
        }

        [TestCaseSource(typeof(LessThanCases))]
        public void EqualOperatorFalse(BigRational left, BigRational right)
        {
            Assert.False(left == right);
            Assert.False(right == left);
            Assert.True(left != right);
            Assert.True(right != left);
        }

        [TestCaseSource(typeof(EqualCases))]
        public void IEquatableTrue(BigRational left, BigRational right)
        {
            Assert.True(left.Equals(right));
            Assert.True(right.Equals(left));
        }

        [TestCaseSource(typeof(LessThanCases))]
        public void IEquatableFalse(BigRational left, BigRational right)
        {
            Assert.False(left.Equals(right));
            Assert.False(right.Equals(left));
        }

        [TestCaseSource(typeof(EqualCases))]
        public void IComparableZero(BigRational left, BigRational right)
        {
            Assert.Zero(left.CompareTo(right));
            Assert.Zero(right.CompareTo(left));
        }

        [TestCaseSource(typeof(LessThanCases))]
        public void IComparableNotZero(BigRational left, BigRational right)
        {
            Assert.NotZero(left.CompareTo(right));
            Assert.NotZero(right.CompareTo(left));
        }

        [TestCaseSource(typeof(LessThanCases))]
        public void IComparableTest(BigRational smaller, BigRational greater)
        {
            Assert.AreEqual(1.CompareTo(2), smaller.CompareTo(greater));
            Assert.AreEqual(2.CompareTo(1), greater.CompareTo(smaller));
        }

        [TestCaseSource(typeof(LessThanCases))]
        public void LessThan(BigRational smaller, BigRational greater)
        {
            Assert.True(smaller < greater);
            Assert.False(greater < smaller);
        }

        [TestCaseSource(typeof(LessThanCases))]
        public void GreaterThan(BigRational smaller, BigRational greater)
        {
            Assert.True(greater > smaller);
            Assert.False(smaller > greater);
        }

        [TestCaseSource(typeof(LessThanCases))]
        public void GreaterThanOrEqual(BigRational smaller, BigRational greater)
        {
            Assert.True(greater >= smaller);
            Assert.False(smaller >= greater);
        }

        [TestCaseSource(typeof(LessThanCases))]
        public void LessThanOrEqual(BigRational smaller, BigRational greater)
        {
            Assert.True(smaller <= greater);
            Assert.False(greater <= smaller);
        }

        private class LessThanCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return Case(
                    smaller: new BigRational(1, 2),
                    greater: new BigRational(2, 2));
                yield return Case(
                    smaller: new BigRational(1, 1),
                    greater: new BigRational(2));
            }

            private static object[] Case(BigRational smaller, BigRational greater)
            {
                return new object[] { smaller, greater };
            }
        }

        private class EqualCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return Case(
                    left: new BigRational(2, 2),
                    right: new BigRational(4, 4));
                yield return Case(
                    left: new BigRational(1, 2),
                    right: new BigRational(2, 4));
            }

            private static object[] Case(BigRational left, BigRational right)
            {
                return new object[] { left, right };
            }
        }
    }
}
