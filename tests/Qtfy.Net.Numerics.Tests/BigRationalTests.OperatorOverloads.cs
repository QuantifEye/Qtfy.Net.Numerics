// <copyright file="BigRationalTests.OperatorOverloads.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using NUnit.Framework;

    public partial class BigRationalTests
    {
        [TestCaseSource(typeof(OverloadCases))]
        public void TestAdditionOverloads(dynamic left, dynamic right)
        {
            AssertEqual(
                (BigRational)left + (BigRational)right,
                left + right);
        }

        [TestCaseSource(typeof(OverloadCases))]
        public void TestSubtractionOverloads(dynamic left, dynamic right)
        {
            AssertEqual(
                (BigRational)left - (BigRational)right,
                left - right);
        }

        [TestCaseSource(typeof(OverloadCases))]
        public void TestMultiplicationOverloads(dynamic left, dynamic right)
        {
            AssertEqual(
                (BigRational)left * (BigRational)right,
                left * right);
        }

        [TestCaseSource(typeof(OverloadCases))]
        public void TestDivisionOverloads(dynamic left, dynamic right)
        {
            AssertEqual(
                (BigRational)left / (BigRational)right,
                left / right);
        }

        [TestCaseSource(typeof(OverloadCases))]
        public void TestEqualityOverloads(dynamic left, dynamic right)
        {
            Assert.AreEqual(
                (BigRational)left == (BigRational)right,
                left == right);
        }

        [TestCaseSource(typeof(OverloadCases))]
        public void TestInequalityOverloads(dynamic left, dynamic right)
        {
            Assert.AreEqual(
                (BigRational)left != (BigRational)right,
                left != right);
        }

        [TestCaseSource(typeof(OverloadCases))]
        public void TestLessThanOverloads(dynamic left, dynamic right)
        {
            Assert.AreEqual(
                (BigRational)left < (BigRational)right,
                left < right);
        }

        [TestCaseSource(typeof(OverloadCases))]
        public void TestGreaterThanOverloads(dynamic left, dynamic right)
        {
            Assert.AreEqual(
                (BigRational)left > (BigRational)right,
                left > right);
        }

        [TestCaseSource(typeof(OverloadCases))]
        public void TestLessThanOrEqualOverloads(dynamic left, dynamic right)
        {
            Assert.AreEqual(
                (BigRational)left <= (BigRational)right,
                left <= right);
        }

        [TestCaseSource(typeof(OverloadCases))]
        public void TestGreaterThanOrEqualOverloads(dynamic left, dynamic right)
        {
            Assert.AreEqual(
                (BigRational)left >= (BigRational)right,
                left >= right);
        }

        public class OverloadCases : IEnumerable
        {
            private static readonly (BigRational rational, BigInteger integer)[] UnsignedCases;

            private static readonly (BigRational rational, BigInteger integer)[] SignedCases;

            static OverloadCases()
            {
                var allIntegers = new BigInteger[] { -4, -3, -2, -1, 1, 2, 3, 4 };
                var positiveIntegers = new BigInteger[] { 1, 2, 3, 4 };
                var denominators = new BigInteger[] { 1, 2 };

                var positiveRationals = positiveIntegers
                    .Zip(denominators)
                    .Select(t => new BigRational(t.First, t.Second))
                    .Distinct()
                    .ToArray();

                var allRationals = allIntegers
                    .Zip(denominators)
                    .Select(t => new BigRational(t.First, t.Second))
                    .Distinct()
                    .ToArray();

                IEnumerable<(BigRational rational, BigInteger integer)> MakeCases(
                    BigRational[] rationals,
                    BigInteger[] integers)
                {
                    foreach (var rational in rationals)
                    {
                        foreach (var integer in integers)
                        {
                            yield return (rational, integer);
                        }
                    }
                }

                SignedCases = MakeCases(allRationals, allIntegers).ToArray();
                UnsignedCases = MakeCases(positiveRationals, positiveIntegers).ToArray();
            }

            public IEnumerator GetEnumerator()
            {
                foreach (var (r, i) in SignedCases)
                {
                    yield return new object[] { r, i };
                    yield return new object[] { r, (long)i };
                    yield return new object[] { (long)i, r };
                    yield return new object[] { r, (int)i };
                    yield return new object[] { (int)i, r };
                    yield return new object[] { r, (short)i };
                    yield return new object[] { (short)i, r };
                    yield return new object[] { r, (sbyte)i };
                    yield return new object[] { (sbyte)i, r };
                }

                foreach (var (r, i) in UnsignedCases)
                {
                    yield return new object[] { r, i };
                    yield return new object[] { r, (ulong)i };
                    yield return new object[] { (ulong)i, r };
                    yield return new object[] { r, (uint)i };
                    yield return new object[] { (uint)i, r };
                    yield return new object[] { r, (ushort)i };
                    yield return new object[] { (ushort)i, r };
                    yield return new object[] { r, (byte)i };
                    yield return new object[] { (byte)i, r };
                }
            }
        }
    }
}