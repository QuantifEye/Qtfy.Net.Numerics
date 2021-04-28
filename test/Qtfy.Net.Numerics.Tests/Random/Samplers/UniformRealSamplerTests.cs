// <copyright file="UniformRealSamplerTests.cs" company="QuantifEye">
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

    public class UniformRealSamplerTests
    {
        private const double Min = 0.5;

        private const double Max = 1.5;

        private static UniformRealSampler GetSampler(double min, double max)
        {
            var engine = MersenneTwister32Bit19937.InitGenRand(1);
            return new UniformRealSampler(engine, min, max);
        }

        [Test]
        public void TestGetNext()
        {
            Assert.Warn("test me");
        }

        [Test]
        public void TestProperties()
        {
            var sampler = new UniformRealSampler(MersenneTwister32Bit19937.InitGenRand(1), Min, Max);
            Assert.AreEqual(Min, sampler.Min);
            Assert.AreEqual(Max, sampler.Max);
        }

        [Test]
        public void TestConstructInvalidEngine()
        {
            Assert.Throws<ArgumentNullException>(
                () => _ = new UniformRealSampler(null, 5d, 10d));
        }

        private static void TestInvalidConstruction<TException>(double min, double max)
            where TException : Exception
            => Assert.Throws<TException>(() => _ = GetSampler(min, max));

        [TestCase(double.NegativeInfinity)]
        [TestCase(double.PositiveInfinity)]
        [TestCase(double.NaN)]
        public void TestInvalidDoubleInput(double invalidValue)
        {
            TestInvalidConstruction<ArgumentException>(invalidValue, 1d);
            TestInvalidConstruction<ArgumentException>(1d, invalidValue);
        }

        [Test]
        public void TestMinGreaterThanMax()
        {
            Assert.Throws<ArgumentException>(
                () => _ = GetSampler(Max, Min));
        }
    }
}
