// <copyright file="InverseTransformSamplerTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests.Random.Samplers
{
    using System;
    using NUnit.Framework;
    using Qtfy.Net.Numerics.Distributions;
    using Qtfy.Net.Numerics.Random.RandomNumberEngines;
    using Qtfy.Net.Numerics.Random.Samplers;

    public class InverseTransformSamplerTests
    {
        [Test]
        public void TestConstructInvalid()
        {
            var engine = MersenneTwister32Bit19937.InitGenRand(1);
            var distribution = new NormalDistribution(1, 1);
            Assert.Throws<ArgumentNullException>(
                () => _ = new InverseTransformSampler<double>(engine, null));
            Assert.Throws<ArgumentNullException>(
                () => _ = new InverseTransformSampler<double>(null, distribution));
        }
    }
}
