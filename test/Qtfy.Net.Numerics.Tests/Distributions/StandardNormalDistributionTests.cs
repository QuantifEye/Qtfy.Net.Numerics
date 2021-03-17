// <copyright file="StandardNormalDistributionTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests.Distributions
{
    using NUnit.Framework;
    using Qtfy.Net.Numerics.Distributions;

    public class StandardNormalDistributionTests
    {
        [Test]
        public void TestMean()
        {
            Assert.AreEqual(0d, StandardNormalDistribution.Instance.Mean);
        }

        [Test]
        public void TestVariance()
        {
            Assert.AreEqual(1d, StandardNormalDistribution.Instance.Variance);
        }

        [Test]
        public void TestStandardDeviation()
        {
            Assert.AreEqual(1d, StandardNormalDistribution.Instance.StandardDeviation);
        }

        [TestCase(1.0, 0.8413447460685429485852d)]
        public void TestCumulativeDistributionFunction(double x, double expected)
        {
            Assert.AreEqual(expected, StandardNormalDistribution.Instance.CumulativeDistribution(x));
        }

        [TestCase(1.0, double.PositiveInfinity)]
        public void TestQuantileFunction(double x, double expected)
        {
            Assert.AreEqual(expected, StandardNormalDistribution.Instance.Quantile(x));
        }

        [TestCase(1.0, -1.41893853320467274178045451569708215806201947)]
        public void TestProbabilityDensityLnFunction(double x, double expected)
        {
            Assert.AreEqual(expected, StandardNormalDistribution.Instance.DensityLn(x));
        }

        [TestCase(1.0, 0.2419707245191433497978)]
        public void TestProbabilityDensityFunction(double x, double expected)
        {
            Assert.AreEqual(expected, StandardNormalDistribution.Instance.Density(x));
        }
    }
}
