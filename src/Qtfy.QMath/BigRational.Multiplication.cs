// <copyright file="BigRational.Multiplication.cs" company="QuantifEye">
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
        /// Multiplies two <see cref="BigRational"/> values.
        /// </summary>
        /// <param name="multiplicand">
        /// The first value to multiply.
        /// </param>
        /// <param name="multiplier">
        /// The second value to multiply.
        /// </param>
        /// <returns>
        /// The product of <paramref name="multiplicand"/> and <paramref name="multiplier"/>.
        /// </returns>
        public static BigRational operator *(BigRational multiplicand, BigRational multiplier)
        {
            return new BigRational(
                multiplicand.Numerator * multiplier.Numerator,
                multiplicand.Denominator * multiplier.Denominator);
        }
    }
}