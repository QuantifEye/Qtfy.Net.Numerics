// <copyright file="UniformRealDistributionTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests.Distributions
{
    using System;
    using NUnit.Framework;
    using Qtfy.Net.Numerics.Distributions;

    public class UniformRealDistributionTests
    {
        private const double Min = 1.5;

        private const double Max = 3.75;

        private static void AssertClose(double expected, double actual)
        {
            Assert.AreEqual(1d, Math.Abs(expected / actual), 1e-15);
        }

        [Test]
        public void TestMin()
        {
            Assert.AreEqual(Min, new UniformRealDistribution(Min, Max).Min);
        }

        [Test]
        public void TestMax()
        {
            Assert.AreEqual(Max, new UniformRealDistribution(Min, Max).Max);
        }

        [TestCase(1.5, 3.75, 2.625)]
        public void TestMean(double min, double max, double mean)
        {
            AssertClose(mean, new UniformRealDistribution(min, max).Mean);
        }

        [TestCase(1.5, 3.75, 0.421875)]
        public void TestVariance(double min, double max, double variance)
        {
            AssertClose(variance, new UniformRealDistribution(min, max).Variance);
        }

        [TestCase(1.5, 3.75, 0.649519052838329)]
        public void TestStandardDeviation(double min, double max, double standardDeviation)
        {
            AssertClose(standardDeviation, new UniformRealDistribution(min, max).StandardDeviation);
        }


        [TestCase(1.5, 3.75, 0.5, 2.625)]
        public void TestQuantile(double min, double max, double probability, double quantile)
        {
            AssertClose(quantile, new UniformRealDistribution(min, max).Quantile(probability));
        }

        [TestCase(1.5, 3.75, 2.5, 0.4444444444444444)]
        public void TestDensity(double min, double max, double x, double density)
        {
            AssertClose(density, new UniformRealDistribution(min, max).Density(x));
        }

        [TestCase(1.5, 3.75, 2.5, -0.8109302162163288)]
        public void TestDensityLn(double min, double max, double x, double densityLn)
        {
            AssertClose(densityLn, new UniformRealDistribution(min, max).DensityLn(x));
        }
    }
}
