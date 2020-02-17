// <copyright file="MultiplicationTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using System.Collections;
    using System.Numerics;
    using NUnit.Framework;

    [TestOf(typeof(BigRational))]
    public class MultiplicationTests
    {
        [TestCaseSource(typeof(Cases))]
        public void Multiply(BigRational left, BigRational right, BigRational answer)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(answer, left * right);
                Assert.AreEqual(answer, right * left);
            });
        }

        private class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return Case(
                    left: new BigRational(1, 2),
                    right: new BigRational(1, 2),
                    answer: new BigRational(1, 4));
                yield return Case(
                    left: new BigRational(1, 2),
                    right: new BigInteger(1),
                    answer: new BigRational(1, 2));
            }

            private static object[] Case(BigRational left, BigRational right, BigRational answer)
            {
                return new object[] { left, right, answer };
            }
        }
    }
}