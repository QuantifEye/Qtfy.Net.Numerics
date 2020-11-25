// <copyright file="BigRational.LessThanOrEqualOperator.cs" company="QuantifEye">
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
        /// Returns an indication whether <paramref name="left"/> is less than or equal to <paramref name="right"/>.
        /// </summary>
        /// <param name="left">
        /// The first value to compare.
        /// </param>
        /// <param name="right">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// true if <paramref name="left"/> is less than or equal to <paramref name="right"/>; otherwise, false.
        /// </returns>
        public static bool operator <=(BigRational left, BigRational right)
        {
            return left.Numerator * right.Denominator <= right.Numerator * left.Denominator;
        }
    }
}