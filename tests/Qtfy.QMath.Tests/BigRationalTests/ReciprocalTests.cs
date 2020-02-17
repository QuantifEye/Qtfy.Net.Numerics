// <copyright file="ReciprocalTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using System;
    using NUnit.Framework;

    [TestOf(typeof(BigRational))]
    public class ReciprocalTests
    {
        [TestCaseSource(typeof(Data.PositiveCases))]
        [TestCaseSource(typeof(Data.NegativeCases))]
        public void Reciprocal(int n1, int n2)
        {
            var rational = new BigRational(n1, n2);
            var expected = new BigRational(n2, n1);
            var actual = rational.Reciprocal();
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(Data.ZeroCases))]
        public void ReciprocalZero(int n1, int n2)
        {
            var rational = new BigRational(n1, n2);
            Assert.Throws<DivideByZeroException>(
                () => rational.Reciprocal());
        }
    }
}
