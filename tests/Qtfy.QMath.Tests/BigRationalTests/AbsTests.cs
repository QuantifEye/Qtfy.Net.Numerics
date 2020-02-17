// <copyright file="AbsTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using System;
    using NUnit.Framework;
    using static Qtfy.QMath.Tests.BigRationalTests.Data;

    [TestOf(typeof(BigRational))]
    public class AbsTests
    {
        [TestCaseSource(typeof(AllCases))]
        public void Abs(int n, int d)
        {
            var rational = new BigRational(n, d);
            var actual = BigRational.Abs(rational);
            var expected = new BigRational(Math.Abs(n), Math.Abs(d));
            Assert.AreEqual(expected, actual);
        }
    }
}
