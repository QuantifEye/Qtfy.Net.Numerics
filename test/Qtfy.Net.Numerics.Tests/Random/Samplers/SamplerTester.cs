// <copyright file="SamplerTester.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>


namespace Qtfy.Net.Numerics.Tests.Random.Samplers
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using Qtfy.Net.Numerics.Random;

    public abstract class SamplerTester<T>
    {
        public abstract ISampler<T> GetSampler();

        public abstract IDistribution GetReferenceDistribution();

        public abstract double Mean(IEnumerable<T> sample);

        [Test]
        public void TestMean()
        {
            var referenceDistribution = this.GetReferenceDistribution();
            var expectedMean = referenceDistribution.Mean;
            var sampler = this.GetSampler();
            var actualMean = this.Mean(Enumerable.Repeat(sampler, 100000).Select(s => s.GetNext()));
            Assert.AreEqual(expectedMean, actualMean, expectedMean * 0.01);
        }
    }
}
