// <copyright file="UnaryOperators.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using NUnit.Framework;
    using static Qtfy.QMath.Tests.BigRationalTests.Data;

    [TestOf(typeof(BigRational))]
    public class UnaryOperators
    {
        [TestCaseSource(typeof(AllCases))]
        public void PlusOperator(int n, int d)
        {
            var rational = new BigRational(n, d);
            Assert.AreEqual(rational, +rational);
        }

        [TestCaseSource(typeof(AllCases))]
        public void MinusOperator(int n, int d)
        {
            var expected = new BigRational(-n, d);
            var actual = -new BigRational(n, d);
            Assert.AreEqual(expected, actual);
        }
    }
}
