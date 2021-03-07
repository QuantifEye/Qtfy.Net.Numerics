// <copyright file="LogNormalDistributionTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests.Distributions
{
    using System;
    using NUnit.Framework;
    using Qtfy.Net.Numerics.Distributions;

    public class LogNormalDistributionTests
    {
        private static void AssertClose(double expected, double actual)
        {
            Assert.AreEqual(1d, Math.Abs(expected / actual), 1e-15);
        }

        [Test]
        public void TestMu()
        {
            var mu = 2.3;
            var distribution = new LogNormalDistribution(mu, 1);
            Assert.AreEqual(mu, distribution.Mu);
        }

        [Test]
        public void TestSigma()
        {
            var sigma = 2.3;
            var distribution = new LogNormalDistribution(1, sigma);
            Assert.AreEqual(sigma, distribution.Sigma);
        }

        [TestCase(1.5, 1.2, 9.20733086588225)]
        [TestCase(-1.5, 1.2, 0.4584060113052235)]
        public void TestMean(double mu, double sigma, double mean)
        {
            AssertClose(mean, new LogNormalDistribution(mu, sigma).Mean);
        }

        [TestCase(1.5, 1.2, 273.03430003502444)]
        [TestCase(-1.5, 1.2, 0.6767843655163925)]
        public void TestVariance(double mu, double sigma, double variance)
        {
            AssertClose(variance, new LogNormalDistribution(mu, sigma).Variance);
        }

        [TestCase(1.5, 1.2, 16.52374957553595)]
        [TestCase(-1.5, 1.2, 0.8226690498106711)]
        public void TestStandardDeviation(double mu, double sigma, double standardDeviation)
        {
            AssertClose(standardDeviation, new LogNormalDistribution(mu, sigma).StandardDeviation);
        }

        [TestCase(1.5, 1.2, 0.25, 1.9949366586042043)]
        [TestCase(1.5, 1.2, 0.50, 4.4816890703380645)]
        [TestCase(1.5, 1.2, 0.75, 10.068257975288748)]
        public void TestQuantile(double mu, double sigma, double probability, double quantile)
        {
            AssertClose(quantile, new LogNormalDistribution(mu, sigma).Quantile(probability));
        }

        [TestCase(1.5, 1.2, 1d, 0.15220757115751826)]
        [TestCase(1.5, 1.2, 2d, 0.13259539628602582)]
        [TestCase(1.5, 1.2, 5d, 0.0662144498764099)]
        public void TestDensity(double mu, double sigma, double x, double density)
        {
            AssertClose(density, new LogNormalDistribution(mu, sigma).Density(x));
        }

        [TestCase(1.5, 1.2, 1d, -1.8825100899986273)]
        [TestCase(1.5, 1.2, 2d, -2.0204529206413384)]
        [TestCase(1.5, 1.2, 10d,  -3.627505888373319)]
        public void TestDensityLn(double mu, double sigma, double x, double densityLn)
        {
            AssertClose(densityLn, new LogNormalDistribution(mu, sigma).DensityLn(x));
        }
    }
}
