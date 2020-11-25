// <copyright file="BigRational.Reciprocal.cs" company="QuantifEye">
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
        /// Calculates the reciprocal of this <see cref="BigRational"/> instance
        /// (1 divided by this <see cref="BigRational"/> value).
        /// </summary>
        /// <returns>
        /// The reciprocal value.
        /// </returns>
        /// <exception cref="DivideByZeroException">
        /// If this <see cref="BigRational"/> is zero (0/1).
        /// </exception>
        public BigRational Reciprocal()
        {
            if (this.IsZero)
            {
                throw new DivideByZeroException("Cannot compute the reciprocal of zero.");
            }

            return this.IsNegative
                ? new BigRational(-this.denominator, -this.numerator)
                : new BigRational(this.denominator, this.numerator);
        }
    }
}