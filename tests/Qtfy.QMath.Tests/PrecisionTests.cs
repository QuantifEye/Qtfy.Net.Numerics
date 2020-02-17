// <copyright file="PrecisionTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests
{
    using NUnit.Framework;

    [TestOf(typeof(Qtfy.QMath.Precision))]
    public class PrecisionTests
    {
        [Test]
        public void TestDecrement()
        {
            Assert.AreEqual(0d, double.Epsilon.Decrement());
        }

        [Test]
        public void TestIncrement()
        {
            Assert.AreEqual(0d, (-double.Epsilon).Increment());
        }

        [Test]
        public void TestIncrementZero()
        {
            Assert.AreEqual(double.Epsilon, 0d.Increment());
        }

        [Test]
        public void TestDecrementZero()
        {
            Assert.AreEqual(-double.Epsilon, 0d.Decrement());
        }
    }
}
