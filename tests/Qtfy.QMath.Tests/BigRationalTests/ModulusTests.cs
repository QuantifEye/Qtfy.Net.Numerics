// <copyright file="ModulusTests.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath.Tests.BigRationalTests
{
    using System.Collections;
    using NUnit.Framework;

    [TestOf(typeof(BigRational))]
    public class ModulusTests
    {
        public void Modulus(BigRational dividend, BigRational divisor, BigRational modulus)
        {
            Assert.AreEqual(modulus, dividend % divisor);
        }

        public class ModulusCases : IEnumerable
        {
            public static object[] Case(
                BigRational dividend,
                BigRational divisor,
                BigRational modulus)
            {
                return new object[] { dividend, divisor, modulus };
            }

            public IEnumerator GetEnumerator()
            {
                yield return Case(
                    dividend: new BigRational(5, 2),
                    divisor: new BigRational(3, 2),
                    modulus: new BigRational(1));
            }
        }
    }
}
