// <copyright file="CeilingFloorTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using System;
    using NUnit.Framework;

    [TestOf(typeof(BigRational))]
    public class CeilingFloorTests
    {
        [Test]
        public void Ceiling()
        {
            for (var i = -2.5M; i <= 2.5M; i += 0.0001M)
            {
                Assert.AreEqual(
                    (BigRational)Math.Ceiling(i),
                    BigRational.Ceiling(i));
            }
        }

        [Test]
        public void Floor()
        {
            for (var i = -2.5M; i <= 2.5M; i += 0.0001M)
            {
                Assert.AreEqual(
                    (BigRational)Math.Floor(i),
                    BigRational.Floor(i));
            }
        }
    }
}