// <copyright file="GaussianCopulaSamplerTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests.Random.Samplers
{
    using System;
    using NUnit.Framework;
    using Qtfy.Net.Numerics.Random.RandomNumberEngines;
    using Qtfy.Net.Numerics.Random.Samplers;

    public class GaussianCopulaSamplerTests
    {
        [Test]
        public void TestLength()
        {
            var sigma = new[,]
            {
                { 1d, 0.5 },
                { 0.5, 1d },
            };
            var engine = MersenneTwister32Bit19937.InitGenRand(1);
            var sampler = new GaussianCopulaSampler.Builder(sigma).Build(engine);
            Assert.AreEqual(2, sampler.Length);
        }

        [Test]
        public void TestConstructWithNull()
        {
            Assert.Throws<ArgumentNullException>(
                () => _ = new GaussianCopulaSampler.Builder(null));
        }

        [Test]
        public void TestGetNext()
        {
            Assert.Warn("test me");
        }
    }
}
