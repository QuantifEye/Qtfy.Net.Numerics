// <copyright file="UniformIntDistributionTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests.Distributions
{
    using System;
    using NUnit.Framework;
    using Qtfy.Net.Numerics.Distributions;

    public class UniformIntDistributionTests
    {
        private const int Min = 1;
        private const int Max = 3;

        private static void AssertClose(double expected, double actual)
        {
            Assert.AreEqual(1d, Math.Abs(expected / actual), 1e-15);
        }

        [Test]
        public void TestConstructInvalid()
        {
            Assert.Throws<ArgumentException>(() => _ = new UniformIntDistribution(2, 1));
        }

        [Test]
        public void TestMin()
        {
            Assert.AreEqual(Min, new UniformIntDistribution(Min, Max).Min);
        }

        [Test]
        public void TestMax()
        {
            Assert.AreEqual(Max, new UniformIntDistribution(Min, Max).Max);
        }

        [TestCase(1, 3, 0.6666666666666666)]
        public void TestVariance(int min, int max, double variance)
        {
            AssertClose(variance, new UniformIntDistribution(min, max).Variance);
        }

        [TestCase(1, 3, 0.816496580927726)]
        public void TestStandardDeviation(int min, int max, double expected)
        {
            AssertClose(expected, new UniformIntDistribution(min, max).StandardDeviation);
        }

        [TestCase(1, 3, 0.5, 2)]
        [TestCase(1, 3, 0.45, 2)]
        [TestCase(1, 3, 1d / 3d, 1)]
        [TestCase(1, 3, 0.25, 1)]
        public void TestQuantile(int min, int max, double probability, int expected)
        {
            AssertClose(expected, new UniformIntDistribution(min, max).Quantile(probability));
        }

        [TestCase(1, 3, 2, 0.3333333333333333)]
        public void TestProbability(int min, int max, int x, double expected)
        {
            AssertClose(expected, new UniformIntDistribution(min, max).Probability(x));
        }

        [TestCase(1, 3, 0, 0.0)]
        [TestCase(1, 3, 4, 0.0)]
        public void TestProbabilityLimits(int min, int max, int x, double expected)
        {
            Assert.AreEqual(expected, new UniformIntDistribution(min, max).Probability(x));
        }

        [TestCase(1, 3, 2, -1.0986122886681098)]
        public void TestProbabilityLn(int min, int max, int x, double expected)
        {
            AssertClose(expected, new UniformIntDistribution(min, max).ProbabilityLn(x));
        }

        [TestCase(1, 3, 0, double.NegativeInfinity)]
        [TestCase(1, 3, 4, double.NegativeInfinity)]
        public void TestProbabilityLnLimits(int min, int max, int x, double expected)
        {
            Assert.AreEqual(expected, new UniformIntDistribution(min, max).ProbabilityLn(x));
        }

        [TestCase(1, 3, 2, 0.6666666666666666)]
        public void TestCumulativeDistribution(int min, int max, double x, double expected)
        {
            AssertClose(expected, new UniformIntDistribution(min, max).CumulativeDistribution(x));
        }
    }
}
