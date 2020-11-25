// <copyright file="BigRational.Min.cs" company="QuantifEye">
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
        /// Returns the lesser of two <see cref="BigRational"/> values.
        /// </summary>
        /// <param name="left">
        /// The first value to compare.
        /// </param>
        /// <param name="right">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// The greater of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        public static BigRational Min(BigRational left, BigRational right)
        {
            return left > right ? right : left;
        }
    }
}