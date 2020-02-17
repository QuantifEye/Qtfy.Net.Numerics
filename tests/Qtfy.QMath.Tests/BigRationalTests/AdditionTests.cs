// <copyright file="AdditionTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using System.Collections;
    using System.Numerics;
    using NUnit.Framework;

    [TestOf(typeof(BigRational))]
    public class AdditionTests
    {
        [TestCaseSource(typeof(Cases))]
        public void Add(BigRational left, BigRational right, BigRational answer)
        {
            Assert.AreEqual(answer, left + right);
            Assert.AreEqual(answer, right + left);
        }

        private class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return Case(0.5M, 0.5M, 1.0M);
                yield return Case(
                    left: new BigRational(24, 25),
                    right: new BigRational(1, 25),
                    sum: new BigRational(1));
                yield return Case(
                    left: new BigRational(24, 25),
                    right: new BigRational(6, 25),
                    sum: new BigRational(30, 25));
                yield return Case(
                    left: new BigRational(-1, 2),
                    right: new BigRational(1, 2),
                    sum: new BigRational(0));
                yield return Case(
                    left: new BigRational(-24, 25),
                    right: new BigRational(1, 25),
                    sum: new BigRational(-23, 25));
                yield return Case(
                    left: new BigRational(-24, 25),
                    right: new BigRational(6, 25),
                    sum: new BigRational(-18, 25));
                yield return Case(
                   left: new BigRational(1, 2),
                   right: new BigInteger(1),
                   sum: new BigRational(3, 2));
                yield return Case(
                    left: new BigRational(1, 2),
                    right: new BigInteger(-1),
                    sum: new BigRational(-1, 2));
                yield return Case(
                    left: new BigRational(-1, 2),
                    right: new BigInteger(1),
                    sum: new BigRational(1, 2));
                yield return Case(
                    left: new BigRational(-1, 2),
                    right: new BigInteger(-1),
                    sum: new BigRational(-3, 2));
                yield return Case(
                    left: new BigInteger(1),
                    right: new BigRational(1),
                    sum: new BigRational(2));
            }

            private static object[] Case(BigRational left, BigRational right, BigRational sum)
            {
                return new object[] { left, right, sum };
            }
        }
    }
}