// <copyright file="BigRational.Subtraction.cs" company="QuantifEye">
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
        /// Subtracts a <see cref="BigRational"/> value from a <see cref="BigRational"/> value.
        /// </summary>
        /// <param name="minuend">
        /// The value to subtract from (the minuend).
        /// </param>
        /// <param name="subtrahend">
        /// The value to subtract (the subtrahend).
        /// </param>
        /// <returns>
        /// The result of subtracting <paramref name="subtrahend"/> from <paramref name="minuend"/>.
        /// </returns>
        public static BigRational operator -(BigRational minuend, BigRational subtrahend)
        {
            var leftDen = minuend.Denominator;
            var rightDen = subtrahend.Denominator;
            return new BigRational((minuend.Numerator * rightDen) - (subtrahend.Numerator * leftDen), leftDen * rightDen);
        }
    }
}