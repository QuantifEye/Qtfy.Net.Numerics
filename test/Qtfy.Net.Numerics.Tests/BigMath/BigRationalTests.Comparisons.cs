// <copyright file="BigRationalTests.ComparisonOperators.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests.BigMath
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using Qtfy.Net.Numerics.BigMath;

    public partial class BigRationalTests
    {
        [Test]
        public void EqualsObject()
        {
            BigRational rational = new BigRational(7);
            object obj = new BigRational(7);
            Assert.False(rational.Equals(new object()));
            Assert.True(rational.Equals(obj));
        }

        [TestCaseSource(typeof(EqualCases))]
        public void EqualityOperatorTrue(BigRational left, BigRational right)
        {
            Assert.True(left == right);
        }

        [TestCaseSource(typeof(UnequalCases))]
        public void EqualityOperatorFalse(BigRational left, BigRational right)
        {
            Assert.False(left == right);
        }

        [TestCaseSource(typeof(UnequalCases))]
        public void InequalityOperatorTrue(BigRational left, BigRational right)
        {
            Assert.True(left != right);
        }

        [TestCaseSource(typeof(EqualCases))]
        public void InequalityOperatorFalse(BigRational left, BigRational right)
        {
            Assert.False(left != right);
        }

        [TestCaseSource(typeof(LessThanCases))]
        public void LessThanOperatorTrue(BigRational smaller, BigRational greater)
        {
            Assert.True(smaller < greater);
        }

        [TestCaseSource(typeof(LessThanCases))]
        [TestCaseSource(typeof(EqualCases))]
        public void LessThanOperatorFalse(BigRational smallerOrSame, BigRational greaterOrSame)
        {
            Assert.False(greaterOrSame < smallerOrSame);
        }

        [TestCaseSource(typeof(LessThanCases))]
        public void GreaterThanOperatorTrue(BigRational smaller, BigRational greater)
        {
            Assert.True(greater > smaller);
        }

        [TestCaseSource(typeof(LessThanCases))]
        [TestCaseSource(typeof(EqualCases))]
        public void GreaterThanOperatorFalse(BigRational smallerOrSame, BigRational greaterOrSame)
        {
            Assert.False(smallerOrSame > greaterOrSame);
        }

        [TestCaseSource(typeof(LessThanCases))]
        [TestCaseSource(typeof(EqualCases))]
        public void GreaterThanOrEqualOperatorTrue(BigRational smallerOrSame, BigRational greaterOrSame)
        {
            Assert.True(greaterOrSame >= smallerOrSame);
        }

        [TestCaseSource(typeof(LessThanCases))]
        public void GreaterThanOrEqualOperatorFalse(BigRational smaller, BigRational greater)
        {
            Assert.False(smaller >= greater);
        }

        [TestCaseSource(typeof(LessThanCases))]
        [TestCaseSource(typeof(EqualCases))]
        public void LessThanOrEqualOperatorTrue(BigRational smallerOrSame, BigRational greaterOrSame)
        {
            Assert.True(smallerOrSame <= greaterOrSame);
        }

        [TestCaseSource(typeof(LessThanCases))]
        public void LessThanOrEqualOperatorFalse(BigRational smaller, BigRational greater)
        {
            Assert.False(greater <= smaller);
        }



        private class ComparisonCases
        {
            private protected static readonly IEnumerable<object[]> LessThanCaseValues = new[]
            {
                new object[] { new BigRational(3, 2), new BigRational(5, 2) },
                new object[] { new BigRational(-3, 2), new BigRational(5, 2) },
                new object[] { new BigRational(-5, 2), new BigRational(-3, 2) },
            };

            private protected static readonly IEnumerable<object[]> UnequalCaseValues = LessThanCaseValues
                .Concat(LessThanCaseValues.Select(arr => new[] { arr[1], arr[0] }))
                .ToArray();

            private protected static readonly IEnumerable<object[]> EqualCaseValues = new[]
            {
                new object[] { new BigRational(5, 2), new BigRational(5, 2) },
                new object[] { new BigRational(-5, 2), new BigRational(-5, 2) },
            };
        }

        private class LessThanCases : ComparisonCases, IEnumerable
        {
            public IEnumerator GetEnumerator()
                => LessThanCaseValues.GetEnumerator();
        }

        private class UnequalCases : ComparisonCases, IEnumerable
        {
            public IEnumerator GetEnumerator()
                => UnequalCaseValues.GetEnumerator();
        }

        private class EqualCases : ComparisonCases, IEnumerable
        {
            public IEnumerator GetEnumerator()
                => EqualCaseValues.GetEnumerator();
        }
    }
}
