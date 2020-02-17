// <copyright file="PowTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using System.Collections;
    using NUnit.Framework;

    [TestOf(typeof(BigRational))]
    public class PowTests
    {
        [TestCaseSource(typeof(Cases))]
        public void Pow(BigRational rational, int power, BigRational expected)
        {
            Assert.AreEqual(expected, BigRational.Pow(rational, power));
        }

        private static object[] Case(BigRational rational, int power, BigRational expected)
        {
            return new object[] { rational, power, expected };
        }

        private class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return Case(
                    rational: new BigRational(2),
                    power: 2,
                    expected: new BigRational(4, 1));
                yield return Case(
                    rational: new BigRational(2),
                    power: -2,
                    expected: new BigRational(1, 4));
            }
        }
    }
}
