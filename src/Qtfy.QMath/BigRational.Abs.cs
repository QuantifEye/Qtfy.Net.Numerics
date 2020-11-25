// <copyright file="BigRational.Abs.cs" company="QuantifEye">
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
        /// Calculates the absolute value of a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// A <see cref="BigRational"/> value.
        /// </param>
        /// <returns>
        /// The absolute value of <paramref name="value"/>.
        /// </returns>
        public static BigRational Abs(BigRational value)
        {
            return value.IsNegative ? -value : value;
        }
    }
}