// <copyright file="MersenneTwister19937Tests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using NUnit.Framework;

    public class MersenneTwister19937Tests
    {
        [TestCaseSource(typeof(InitGenRandTestCases))]
        public void InitGenRandTests(uint seed, uint[] expected)
        {
            var size = expected.Length;
            var generator = MersenneTwister19937.InitGenRand(seed);
            var actual = new uint[size];
            for (int i = 0; i < size; ++i)
            {
                actual[i] = generator.Next();
            }

            Assert.AreEqual(expected, actual);
        }

        public class InitGenRandTestCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
                => InitGenArgs().GetEnumerator();
        }

        private static IEnumerable<(uint, uint[])> InitGenArgs()
        {
            var files = Directory.GetFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Random", "Data"))
                .Where(f => f.Contains("mersenne_twister_init_genrand"))
                .ToArray();

            var seeds = files
                .Select(f => f.Split('_'))
                .Select(a => a[a.Length])
                .Select(uint.Parse)
                .ToArray();

            var values = files
                .Select(File.ReadAllLines)
                .Select(arr => arr.Select(uint.Parse).ToArray())
                .ToArray();

            return seeds.Zip(values).ToArray();
        }
    }
}