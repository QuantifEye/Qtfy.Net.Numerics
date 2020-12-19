// <copyright file="UniformUintGeneratorTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests.Random.BitGenerators
{
    using System.Collections;
    using System.Diagnostics.CodeAnalysis;
    using NUnit.Framework;
    using Qtfy.Net.Numerics.Random;
    using Qtfy.Net.Numerics.Random.BitGenerators;
    using Qtfy.Net.Numerics.Random.DistributionGenerators;
    using Qtfy.Net.Numerics.Random.SeedSequences;

    public class UniformUintGeneratorTests
    {
        private static void TestGenerator(IDistributionGenerator<uint> generator, uint[] expected)
        {
            uint[] actual = new uint[expected.Length];
            for (int i = 0; i < actual.Length; ++i)
            {
                actual[i] = generator.GetNext();
            }

            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(typeof(Cases))]
        public void TestsUniformUIntDistributionGenerator(
            ISeedSequence<uint> seedSequence,
            uint min,
            uint max,
            uint[] expected)
        {
            var generator = new MersenneTwister19937(seedSequence);
            var distributionGenerator = new UniformUIntGenerator(generator, min, max);
            TestGenerator(distributionGenerator, expected);
        }

        [SuppressMessage("Microsoft.Performance", "CA1812", Justification = "class is instantiated by unit testing")]
        private class Cases : IEnumerable
        {
            private static object[] Case(ISeedSequence<uint> seedSequence, uint min, uint max, uint[] expected)
                => new object[] { seedSequence, min, max, expected };

            public IEnumerator GetEnumerator()
            {
                var seedSequence = new LibStdCppSeedSequence(1, 2, 3);
                yield return Case(
                    seedSequence: seedSequence,
                    min: 1,
                    max: 10,
                    expected: new uint[]
                    {
                        4,
                        2,
                        2,
                        10,
                        7,
                        7,
                        10,
                        7,
                        3,
                        2,
                    });
            }
        }
    }
}
