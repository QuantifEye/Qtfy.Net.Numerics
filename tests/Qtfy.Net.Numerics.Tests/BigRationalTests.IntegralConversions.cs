// <copyright file="BigRationalTests.IntegralConversions.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Tests
{
    using NUnit.Framework;

    public partial class BigRationalTests
    {
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(-1)]
        [TestCase(2)]
        [TestCase(-2)]
        public void FromSignedInteger(int value)
        {
            var expected = new BigRational(value);
            BigRationalTests.AssertEqual(expected, (BigRational)(long)value);
            BigRationalTests.AssertEqual(expected, (BigRational)(int)value);
            BigRationalTests.AssertEqual(expected, (BigRational)(short)value);
            BigRationalTests.AssertEqual(expected, (BigRational)(sbyte)value);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void FromUnsignedInteger(int value)
        {
            var expected = new BigRational(value);
            BigRationalTests.AssertEqual(expected, (BigRational)(uint)value);
            BigRationalTests.AssertEqual(expected, (BigRational)(ushort)value);
            BigRationalTests.AssertEqual(expected, (BigRational)(byte)value);
            BigRationalTests.AssertEqual(expected, (BigRational)(sbyte)value);
        }
    }
}
