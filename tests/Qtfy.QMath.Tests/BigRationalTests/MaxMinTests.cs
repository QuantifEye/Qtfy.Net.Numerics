// <copyright file="MaxMinTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using System.Collections;
    using NUnit.Framework;

    [TestOf(typeof(BigRational))]
    public class MaxMinTests
    {
        [TestCaseSource(typeof(Cases))]
        public void Max(BigRational max, BigRational min)
        {
            Assert.AreEqual(max, BigRational.Max(min, max));
        }

        [TestCaseSource(typeof(Cases))]
        public void Min(BigRational max, BigRational min)
        {
            Assert.AreEqual(min, BigRational.Min(min, max));
        }

        private class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return Case(
                    max: new BigRational(2),
                    min: new BigRational(1));
                yield return Case(
                    max: new BigRational(2, 1),
                    min: new BigRational(1, 2));
                yield return Case(
                    max: new BigRational(3, 7),
                    min: new BigRational(2, 7));
                yield return Case(
                    max: new BigRational(1, 2),
                    min: new BigRational(-2, 1));
                yield return Case(
                    max: new BigRational(2, 7),
                    min: new BigRational(-3, 7));
                yield return Case(
                    max: new BigRational(1),
                    min: new BigRational(-2));
            }

            private static object[] Case(BigRational max, BigRational min)
            {
                return new object[] { max, min };
            }
        }
    }
}
