// <copyright file="SpecialFunctionsTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests
{
    using NUnit.Framework;

    public class SpecialFunctionsTests
    {
        [TestCase(1.5)]
        [TestCase(-1.5)]
        public void TestErfInvOutOfRange(double value)
        {
            Assert.IsNaN(SpecialFunctions.ErfInv(value));
        }
    }
}
