// <copyright file="IncrementDecrementTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using NUnit.Framework;

    [TestOf(typeof(BigRational))]
    public class IncrementDecrementTests
    {
        [TestCaseSource(typeof(Data.AllCases))]
        public void IncrementTest(int n, int d)
        {
            var actual = new BigRational(n, d);
            var expected = actual + 1;
            Assert.AreEqual(expected, ++actual);
        }

        [TestCaseSource(typeof(Data.AllCases))]
        public void DecrementTest(int n, int d)
        {
            var actual = new BigRational(n, d);
            var expected = actual - 1;
            Assert.AreEqual(expected, --actual);
        }
    }
}
