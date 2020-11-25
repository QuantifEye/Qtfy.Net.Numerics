// <copyright file="BigRational.ToString.cs" company="QuantifEye">
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
        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{this.Numerator}/{this.Denominator}";
        }

        /// <summary>
        /// Converts the numeric value of the current <see cref="BigRational"/> object to
        /// its equivalent string representation by using the specified format.
        /// </summary>
        /// <param name="format">
        /// A standard or custom numeric format string.
        /// </param>
        /// <returns>
        /// The string representation of the current BigInteger value in the format specified by the format parameter.
        /// </returns>
        /// <exception cref="FormatException">
        /// format is not a valid format string.
        /// </exception>
        public string ToString(string format)
        {
            return $"{this.Numerator.ToString(format)}/{this.Denominator.ToString(format)}";
        }
    }
}