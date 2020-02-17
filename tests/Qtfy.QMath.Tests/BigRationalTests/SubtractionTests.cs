// <copyright file="SubtractionTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using System.Collections;
    using System.Numerics;
    using NUnit.Framework;

    [TestOf(typeof(BigRational))]
    public class SubtractionTests
    {
        [TestCaseSource(typeof(Cases))]
        public void Subtract(BigRational left, BigRational right, BigRational answer)
        {
            Assert.AreEqual(answer, left - right);
        }

        private class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return Case(
                    left: new BigRational(1, 2),
                    right: new BigRational(1, 2),
                    answer: new BigRational(0));
                yield return Case(
                    left: new BigRational(1, 2),
                    right: new BigInteger(1),
                    answer: new BigRational(-1, 2));
            }

            private static object[] Case(BigRational left, BigRational right, BigRational answer)
            {
                return new object[] { left, right, answer };
            }
        }
    }
}