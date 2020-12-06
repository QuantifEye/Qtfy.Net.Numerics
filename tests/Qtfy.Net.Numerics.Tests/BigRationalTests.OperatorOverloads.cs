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
    using System.Reflection;
    using NUnit.Framework;

    public partial class BigRationalTests
    {
        [TestCase("op_Equality")]
        [TestCase("op_Inequality")]
        [TestCase("op_LessThan")]
        [TestCase("op_LessThanOrEqual")]
        [TestCase("op_GreaterThan")]
        [TestCase("op_GreaterThanOrEqual")]
        public void TestHasComparisonOverload(string name)
        {
            AssertHasOverloads<bool>(name);
        }

        [TestCase("op_Addition")]
        [TestCase("op_Subtraction")]
        [TestCase("op_Multiply")]
        [TestCase("op_Division")]
        [TestCase("op_Modulus")]
        public void TestHasArithmeticOverload(string name)
        {
            AssertHasOverloads<BigRational>(name);
        }

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
        public void TestModulusOverloads(dynamic left, dynamic right)
        {
            AssertEqual(
                (BigRational)left % (BigRational)right,
                left % right);
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

        private static bool HasMethod<TLeft, TRight, TReturn>(string name)
        {
            var count = typeof(BigRational)
                .GetMethods(BindingFlags.Static | BindingFlags.Public)
                .Where(m => m.Name == name)
                .Where(m => m.ReturnType == typeof(TReturn))
                .Where(m => m.GetParameters().Length == 2)
                .Where(m => m.GetParameters()[0].ParameterType == typeof(TLeft))
                .Count(m => m.GetParameters()[1].ParameterType == typeof(TRight));

            return count == 1;
        }

        private static void AssertHasOverloads<TReturn>(string name)
        {
            Assert.True(HasMethod<BigRational, BigRational, TReturn>(name));
            Assert.True(HasMethod<BigRational, BigInteger, TReturn>(name));
            Assert.True(HasMethod<BigInteger, BigRational, TReturn>(name));
            Assert.True(HasMethod<BigRational, ulong, TReturn>(name));
            Assert.True(HasMethod<ulong, BigRational, TReturn>(name));
            Assert.True(HasMethod<BigRational, long, TReturn>(name));
            Assert.True(HasMethod<long, BigRational, TReturn>(name));
        }

        private class OverloadCases : IEnumerable
        {
            private static readonly IEnumerable<(BigRational rational, BigInteger integer)> UnsignedCases;

            private static readonly IEnumerable<(BigRational rational, BigInteger integer)> SignedCases;

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