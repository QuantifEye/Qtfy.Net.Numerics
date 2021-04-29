// <copyright file="StandardUniformDistributionTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests.Distributions
{
    using System;
    using NUnit.Framework;
    using Qtfy.Net.Numerics.Distributions;

    public class StandardUniformDistributionTests
    {
        private static readonly StandardUniformDistribution Distribution = StandardUniformDistribution.Instance;

        [TestCase(1.0)]
        [TestCase(0.0)]
        [TestCase(0.5)]
        [TestCase(0.123)]
        public void TestQuantile(double p)
        {
            Assert.AreEqual(p, Distribution.Quantile(p));
        }

        [TestCase(-0.1)]
        [TestCase(1.1)]
        public void TestInvalidQuantile(double p)
        {
            Assert.Throws<ArgumentException>(
                () => _ = Distribution.Quantile(p));
        }

        [TestCase(-0.1, 0.0)]
        [TestCase(0.0, 0.0)]
        [TestCase(0.1, 0.1)]
        [TestCase(1.0, 1.0)]
        [TestCase(1.1, 1.0)]
        public void TestCumulativeDistribution(double x, double p)
        {
            Assert.AreEqual(p, Distribution.CumulativeDistribution(x));
            Assert.AreEqual(p, StandardUniformDistribution.CumulativeDistributionFunction(x));
        }

        [TestCase(0.5)]
        public void TestDensity(double x)
        {
            Assert.AreEqual(1d, Distribution.Density(x));
        }

        [TestCase(0.5)]
        public void TestDensityLn(double x)
        {
            Assert.AreEqual(0d, Distribution.DensityLn(x));
        }
    }
}
