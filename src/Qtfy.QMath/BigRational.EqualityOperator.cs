// <copyright file="BigRational.EqualityOperator.cs" company="QuantifEye">
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
        /// Returns a value indicating whether <paramref name="left"/> is equal to <paramref name="right"/>.
        /// </summary>
        /// <param name="left">
        /// The first value to compare.
        /// </param>
        /// <param name="right">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// true if <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        public static bool operator ==(BigRational left, BigRational right)
        {
            return left.Numerator == right.Numerator && left.Denominator == right.Denominator;
        }

        /// <summary>
        /// Returns a value indicating whether <paramref name="left"/> is unequal to <paramref name="right"/>.
        /// </summary>
        /// <param name="left">
        /// The first value to compare.
        /// </param>
        /// <param name="right">
        /// The second value to compare.
        /// </param>
        /// <returns>
        /// false if <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, true.
        /// </returns>
        public static bool operator !=(BigRational left, BigRational right)
        {
            return left.Numerator != right.Numerator || left.Denominator != right.Denominator;
        }
    }
}