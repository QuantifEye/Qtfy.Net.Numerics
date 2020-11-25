// <copyright file="BigRational.Division.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath
{
    using System;

    /// <summary>
    /// A structure that represents a rational number with an arbitrarily large numerator and denominator.
    /// </summary>
    public partial struct BigRational
    {
        /// <summary>
        /// Divides a <see cref="BigRational"/> value by another <see cref="BigRational"/> value.
        /// </summary>
        /// <param name="dividend">
        /// The <see cref="BigRational"/> to be divided (the dividend).
        /// </param>
        /// <param name="divisor">
        /// The <see cref="BigRational"/> to divide by (the divisor).
        /// </param>
        /// <returns>
        /// The quotient of <paramref name="dividend"/> and <paramref name="divisor"/>.
        /// </returns>
        /// <exception cref="DivideByZeroException">
        /// If <paramref name="divisor"/> is equal to zero (0/1).
        /// </exception>
        public static BigRational operator /(BigRational dividend, BigRational divisor)
        {
            return new BigRational(dividend.Numerator * divisor.Denominator, dividend.Denominator * divisor.Numerator);
        }
    }
}