// <copyright file="StandardNormalSamplerTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests.Random.Samplers
{
    using System;
    using NUnit.Framework;
    using Qtfy.Net.Numerics.Random.Samplers;

    public class StandardNormalSamplerTests
    {
        [Test]
        public void TestGetNext()
        {
            Assert.Warn("test me");
        }

        [Test]
        public void TestConstructInvalid()
        {
            Assert.Throws<ArgumentNullException>(
                () => _ = new StandardNormalSampler(null));
        }
    }
}
