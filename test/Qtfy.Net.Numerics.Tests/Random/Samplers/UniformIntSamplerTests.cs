// <copyright file="UniformIntSamplerTests.cs" company="QuantifEye">
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
    using Qtfy.Net.Numerics.Random.SeedSequences;

    public class UniformIntSamplerTests
    {
        private const int Min = 7;

        private const int Max = 12;

        private static MersenneTwister32Bit19937 GetEngine()
        {
            var ss = new SeedSequence(1, 2, 3);
            return new MersenneTwister32Bit19937(ss);
        }

        private static UniformIntSampler GetSampler(int min, int max)
        {
            return new (GetEngine(), min, max);
        }

        [Test]
        public void TestConstructInvalid()
        {
            Assert.Throws<ArgumentException>(
                () => _ = GetSampler(12, 7));

            Assert.Throws<ArgumentNullException>(
                () => _ = new UniformIntSampler(null, 1, 2));
        }

        [Test]
        public void TestMinMax()
        {
            Assert.AreEqual(Min, GetSampler(Min, Max).Min);
            Assert.AreEqual(Max, GetSampler(Min, Max).Max);
        }

        [Test]
        public void TestGetNext()
        {
            Assert.Warn("test me");
        }
    }
}
