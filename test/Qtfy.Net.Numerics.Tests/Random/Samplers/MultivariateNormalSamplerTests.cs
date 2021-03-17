// <copyright file="MultivariateNormalSamplerTests.cs" company="QuantifEye">
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

    public class MultivariateNormalSamplerTests
    {
        [Test]
        public void TestApproximateCovarianceMatrix()
        {
            Assert.Warn("test me");
        }

        [Test]
        public void TestLength()
        {
            var mean = new double[] { 0d, 0d };
            var sigma = new double[,]
            {
                { 1d, 0.5 },
                { 0.5, 1d },
            };
            var engine = MersenneTwister32Bit19937.InitGenRand(1);
            var sampler = new MultivariateNormalSampler.Builder(mean, sigma).Build(engine);
            Assert.AreEqual(2, sampler.Length);
        }

        [Test]
        public void TestInvalidMean()
        {
            var inputCovariance = new double[,]
            {
                { 1.0, 0.5 },
                { 0.5, 1.0 },
            };

            Assert.Throws<ArgumentException>(
                () => _ = new MultivariateNormalSampler.Builder(new[] { 0d }, inputCovariance));

            Assert.Throws<ArgumentException>(
                () => _ = new MultivariateNormalSampler.Builder(new[] { 0d, double.NaN }, inputCovariance));

            Assert.Throws<ArgumentNullException>(
                () => _ = new MultivariateNormalSampler.Builder(null, inputCovariance));

            Assert.Throws<ArgumentNullException>(
                () => _ = new MultivariateNormalSampler.Builder(new[] { 0d }, null));
        }

        [Test]
        public void TestConstructValid()
        {
            var covarianceMatrix = new double[,]
            {
                { 1.0, 0.5 },
                { 0.5, 1.0 },
            };

            var mean = new[] { 0.0, 0.0 };
            var engine = MersenneTwister32Bit19937.InitGenRand(1);
            Assert.DoesNotThrow(() => _ = new MultivariateNormalSampler.Builder(mean, covarianceMatrix).Build(engine));
        }
    }
}
