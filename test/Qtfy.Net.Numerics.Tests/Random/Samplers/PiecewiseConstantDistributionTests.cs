// <copyright file="PiecewiseConstantDistributionTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests.Random.Samplers
{
    using NUnit.Framework;
    using Qtfy.Net.Numerics.Distributions;

    public class PiecewiseConstantDistributionTests
    {
        [Test]
        public void TestCumulativeDistribution()
        {
            var boundaries = new[] { 1d, 2d, 3d };
            var weights = new[] { 1d, 1d };
            var dist = PiecewiseConstantDistribution.Create(boundaries, weights);

            Assert.AreEqual(0, dist.CumulativeDistribution(-1d));
            Assert.AreEqual(0, dist.CumulativeDistribution(1d));
            Assert.AreEqual(0.5, dist.CumulativeDistribution(2d));
            Assert.AreEqual(1.0, dist.CumulativeDistribution(3.0));
            Assert.AreEqual(1.0, dist.CumulativeDistribution(4.0));
            Assert.AreEqual(0.75, dist.CumulativeDistribution(2.5));
            Assert.AreEqual(0.25, dist.CumulativeDistribution(1.5));
        }

        [Test]
        public void TestQuantile()
        {
            var boundaries = new[] { 1d, 2d, 3d };
            var weights = new[] { 1d, 1d };
            var dist = PiecewiseConstantDistribution.Create(boundaries, weights);

            Assert.AreEqual(1, dist.Quantile(0d));
            Assert.AreEqual(2, dist.Quantile(0.5));
            Assert.AreEqual(3, dist.Quantile(1d));

            Assert.AreEqual(1.5, dist.Quantile(0.25));
            Assert.AreEqual(2.5, dist.Quantile(0.75));
        }
    }
}
