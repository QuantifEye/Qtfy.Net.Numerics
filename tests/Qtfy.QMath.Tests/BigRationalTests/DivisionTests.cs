// <copyright file="DivisionTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using System.Collections;
    using NUnit.Framework;

    [TestOf(typeof(BigRational))]
    public class DivisionTests
    {
        [TestCaseSource(typeof(Cases))]
        public void Divide(BigRational dividend, BigRational divisor, BigRational answer)
        {
            Assert.AreEqual(answer, dividend / divisor);
        }

        private static object[] Case(BigRational dividend, BigRational divisor, BigRational answer)
        {
            return new object[] { dividend, divisor, answer };
        }

        private class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return Case(
                    dividend: new BigRational(1, 2),
                    divisor: new BigRational(1, 2),
                    answer: new BigRational(1));
                yield return Case(
                    dividend: new BigRational(1, 2),
                    divisor: new BigRational(1),
                    answer: new BigRational(1, 2));
            }
        }
    }
}
