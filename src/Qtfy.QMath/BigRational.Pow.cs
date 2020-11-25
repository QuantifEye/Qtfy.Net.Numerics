// <copyright file="BigRational.Pow.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath
{
    using System;
    using System.Numerics;

    /// <summary>
    /// A structure that represents a rational number with an arbitrarily large numerator and denominator.
    /// </summary>
    public partial struct BigRational
    {
        /// <summary>
        /// Raises a <see cref="BigRational"/> to an <see cref="int"/> power.
        /// </summary>
        /// <param name="value">
        /// A <see cref="BigRational"/>.
        /// </param>
        /// <param name="exp">
        /// The <see cref="int"/> exponent.
        /// </param>
        /// <returns>
        /// <paramref name="value"/> raised to the power <paramref name="exp"/>.
        /// </returns>
        public static BigRational Pow(BigRational value, int exp)
        {
            if (value.IsZero)
            {
                return exp == 0
                    ? throw new ArgumentException("Cannot calculate 0 to the power zero.")
                    : One;
            }
            else if (exp == 0)
            {
                return One;
            }
            else
            {
                return exp > 0
                    ? new BigRational(
                        numerator: BigInteger.Pow(value.Numerator, exp),
                        denominator: BigInteger.Pow(value.Denominator, exp))
                    : new BigRational(
                        numerator: BigInteger.Pow(value.Denominator, -exp),
                        denominator: BigInteger.Pow(value.Numerator, -exp));
            }
        }
    }
}