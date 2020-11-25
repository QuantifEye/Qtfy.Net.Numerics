// <copyright file="BigRational.Addition.cs" company="QuantifEye">
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
        /// Adds two <see cref="BigRational"/> values.
        /// </summary>
        /// <param name="augend">
        /// The first number to add (the augend).
        /// </param>
        /// <param name="addend">
        /// The first number to add (the addend).
        /// </param>
        /// <returns>
        /// The sum of <paramref name="augend"/> and <paramref name="addend"/>.
        /// </returns>
        public static BigRational operator +(BigRational augend, BigRational addend)
        {
            var leftDen = augend.Denominator;
            var rightDen = addend.Denominator;
            return new BigRational((augend.Numerator * rightDen) + (addend.Numerator * leftDen), leftDen * rightDen);
        }
    }
}