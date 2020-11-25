// <copyright file="BigRational.ModuloOperator.cs" company="QuantifEye">
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
        /// Calculates the remainder that results from division with two specified <see cref="BigRational"/> values.
        /// </summary>
        /// <param name="dividend">
        /// The value to be divided.
        /// </param>
        /// <param name="divisor">
        /// The value to divide by.
        /// </param>
        /// <returns>
        /// The remainder that results from the division.
        /// </returns>
        /// <exception cref="DivideByZeroException">
        /// If <paramref name="divisor"/> is zero (1/0).
        /// </exception>
        public static BigRational operator %(BigRational dividend, BigRational divisor)
        {
            var temp = dividend / divisor;
            return dividend - ((temp.Numerator / temp.Denominator) * divisor);
        }
    }
}