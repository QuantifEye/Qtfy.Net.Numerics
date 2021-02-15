// <copyright file="LibStdCppSeedSequenceTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests.Random.SeedSequences
{
    using System.Collections;
    using System.Diagnostics.CodeAnalysis;
    using NUnit.Framework;
    using Qtfy.Net.Numerics.Random.SeedSequences;

    public class LibStdCppSeedSequenceTests
    {
        [TestCaseSource(typeof(UIntCases))]
        public void TestUIntGenerate(uint[] seeds, uint[] expectedUInts)
        {
            var actualUInts = new uint[expectedUInts.Length];
            new LibStdCppSeedSequence(seeds).Generate(actualUInts);
            Assert.AreEqual(expectedUInts, actualUInts);
        }

        [SuppressMessage("Microsoft.Performance", "CA1812", Justification = "class is instantiated by unit testing")]
        private class UIntCases : IEnumerable
        {
            private static object[] Case(uint[] seeds, uint[] expected)
                => new object[] { seeds, expected };

            public IEnumerator GetEnumerator()
            {
                uint[] seeds = { 1, 2, 3 };
                yield return Case(
                    seeds,
                    new[]
                    {
                        4069278582U,
                        1003217515U,
                        3259405872U,
                        538510628U,
                        148169650U,
                        2686142965U,
                        4168267496U,
                        2286043007U,
                        1924303767U,
                        770742192U
                    });
                yield return Case(
                    seeds,
                    new[]
                    {
                        2039731893U,
                        260350100U,
                    });
                yield return Case(
                    seeds,
                    new[]
                    {
                        4199328558U,
                    });

                seeds = new[] { 1u, 2u, uint.MaxValue };
                yield return Case(
                    seeds,
                    new[]
                    {
                        1623217715U,
                        257752631U,
                        4289641595U,
                        2336310005U,
                        1408697347U,
                        2103514163U,
                        496557208U,
                        3728636812U,
                        2928557124U,
                        2930615858U,
                    });
                yield return Case(
                    seeds,
                    new[]
                    {
                        3652870001U,
                        3218027944U,
                    });
                yield return Case(
                    seeds,
                    new[]
                    {
                        72374954U,
                    });

                seeds = new[] { 1u };
                yield return Case(
                    seeds,
                    new[]
                    {
                        2097633565U,
                        164752946U,
                        932513510U,
                        4290747440U,
                        3808979646U,
                        274275061U,
                        2317284515U,
                        1314089838U,
                        1913647553U,
                        2039914892U,
                    });
                yield return Case(
                    seeds,
                    new[]
                    {
                        1657803123U,
                        1624008230U,
                    });
                yield return Case(
                    seeds,
                    new[]
                    {
                        1967017404U,
                    });
            }
        }
    }
}
