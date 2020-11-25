// <copyright file="BigRational.UnaryOperators.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath
{
    /// <summary>
    /// A structure that represents a rational number with an arbitrarily large numerator and denominator.
    /// </summary>
    public partial struct BigRational
    {
        /// <summary>
        /// Adds one to <paramref name="value"/>.
        /// </summary>
        /// <param name="value">
        /// The value to add one to.
        /// </param>
        /// <returns>
        /// The value of <paramref name="value"/> + (1 / 1).
        /// </returns>
        public static BigRational operator ++(BigRational value)
        {
            return new BigRational(value.Numerator + value.Denominator, value.Denominator);
        }

        /// <summary>
        /// Subtracts one from <paramref name="value"/>.
        /// </summary>
        /// <param name="value">
        /// The value to subtract one from.
        /// </param>
        /// <returns>
        /// The value of <paramref name="value"/> - (1 / 1).
        /// </returns>
        public static BigRational operator --(BigRational value)
        {
            return new BigRational(value.Numerator - value.Denominator, value.Denominator);
        }

        /// <summary>
        /// Negates a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The value to negate.
        /// </param>
        /// <returns>
        /// The result of multiplying <paramref name="value"/> by negative one (-1).
        /// </returns>
        public static BigRational operator -(BigRational value)
        {
            return new BigRational(-value.Numerator, value.Denominator);
        }

        /// <summary>
        /// Returns the value of the <see cref="BigRational"/> operand. (The sign of the operand is unchanged.)
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <returns>
        /// The <paramref name="value"/> operand.
        /// </returns>
        public static BigRational operator +(BigRational value)
        {
            return value;
        }
    }
}