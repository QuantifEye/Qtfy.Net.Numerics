// <copyright file="ToStringTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using System.Collections;
    using NUnit.Framework;

    [TestOf(typeof(BigRational))]
    public class ToStringTests
    {
        [TestCaseSource(typeof(Cases))]
        public string TestToString(int numerator, int denominator)
        {
            return new BigRational(numerator, denominator).ToString();
        }

        private class Cases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new TestCaseData(1, 2).Returns("1/2");
                yield return new TestCaseData(-1, 2).Returns("-1/2");
                yield return new TestCaseData(1, -2).Returns("-1/2");
            }
        }
    }
}
