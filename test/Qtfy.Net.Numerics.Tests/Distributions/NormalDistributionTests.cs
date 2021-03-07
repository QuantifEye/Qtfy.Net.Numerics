// <copyright file="NormalDistributionTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

using System;

namespace Qtfy.Net.Numerics.Tests.Distributions
{
    using NUnit.Framework;
    using Qtfy.Net.Numerics.Distributions;

    public class NormalDistributionTests
    {
        private static void AssertClose(double expected, double actual)
        {
            Assert.AreEqual(1d, Math.Abs(expected / actual), 1e-15);
        }

        [Test]
        public void TestMu()
        {
            var mu = 2.3;
            var distribution = new NormalDistribution(mu, 1);
            Assert.AreEqual(mu, distribution.Mu);
        }

        [Test]
        public void TestSigma()
        {
            var sigma = 2.3;
            var distribution = new NormalDistribution(1, sigma);
            Assert.AreEqual(sigma, distribution.Sigma);
            Assert.AreEqual(sigma, distribution.StandardDeviation);
            Assert.AreEqual(sigma * sigma, distribution.Variance);
        }

        [TestCase(1, 1, 1)]
        public void TestMean(double mu, double sigma, double variance)
        {
            Assert.AreEqual(mu, new NormalDistribution(mu, sigma).Mean);
        }

        [TestCase(1.5, 1.2, 0.5, 1.5)]
        public void TestQuantile(double mu, double sigma, double probability, double quantile)
        {
            AssertClose(quantile, new NormalDistribution(mu, sigma).Quantile(probability));
        }

        [TestCase(1.5, 1.2, 2, 0.30481030534500203)]
        public void TestDensity(double mu, double sigma, double x, double density)
        {
            AssertClose(density, new NormalDistribution(mu, sigma).Density(x));
        }

        [TestCase(1.5, 1.2, 10, -26.18806564555419)]
        public void TestDensityLn(double mu, double sigma, double x, double densityLn)
        {
            AssertClose(densityLn, new NormalDistribution(mu, sigma).DensityLn(x));
        }
    }
}
