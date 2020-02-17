// <copyright file="LogTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.SeriesExpansionsTests
{
    using System;
    using NUnit.Framework;

    public class LogTests
    {
        [TestCase(2)]
        [TestCase(100.5)]
        public void TestLog(double x)
        {
            var log = Math.Log(x);
            BigRational upper = log.Increment();
            BigRational lower = log.Decrement();
            BigRational actual = SeriesExpansions.Log(x, 1000);
            Assert.True(actual < upper);
            Assert.True(actual > lower);
        }
    }
}
