// <copyright file="UniformDiscreteSamplerTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

using Qtfy.Net.Numerics.Distributions;
using Qtfy.Net.Numerics.Random;

namespace Qtfy.Net.Numerics.Tests.Random.Samplers
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using Qtfy.Net.Numerics.Random.RandomNumberEngines;
    using Qtfy.Net.Numerics.Random.Samplers;
    using Qtfy.Net.Numerics.Random.SeedSequences;

    public class UniformDiscreteSamplerTests : IntSamplerTester
    {
        const int Min = 7;
        const int Max = 12;

        public override ISampler<int> GetSampler()
        {
            return new UniformIntSampler(Min, Max, GetEngine());
        }

        public override IDistribution GetReferenceDistribution()
        {
            return new UniformIntDistribution(Min, Max);
        }

        private static MersenneTwister32Bit19937 GetEngine()
        {
            var ss = new SeedSequence(1, 2, 3);
            return new MersenneTwister32Bit19937(ss);
        }

        private static UniformIntSampler GetSampler(int min, int max)
        {
            return new(min, max, GetEngine());
        }

        [Test]
        public void TestConstructInvalid()
        {
            Assert.Throws<ArgumentException>(
                () => _ = GetSampler(12, 7));
        }

        [Test]
        public void TestMinMax()
        {
            Assert.AreEqual(Min, GetSampler(Min, Max).Min);
            Assert.AreEqual(Max, GetSampler(Min, Max).Max);
        }

        [TestCase(7, 12)]
        [TestCase(-7, 12)]
        public void TestGetNext(int min, int max)
        {
            const int size = 100;
            ulong range = ToULong(max - min);
            var actual = Enumerable.Repeat(GetSampler(min, max), size)
                .Select(s => s.GetNext());
            var expected = Enumerable.Repeat(GetEngine(), size)
                .Select(e => min + ToLong(e.NextULong(range)));

            Assert.AreEqual(expected, actual);

            static ulong ToULong(long v)
                => v < 0
                    ? throw new ArgumentException("invalid cast", nameof(v))
                    : (ulong)v;

            static long ToLong(ulong v)
                => v > long.MaxValue
                    ? throw new ArgumentException("invalid cast", nameof(v))
                    : (long)v;
        }
    }
}
