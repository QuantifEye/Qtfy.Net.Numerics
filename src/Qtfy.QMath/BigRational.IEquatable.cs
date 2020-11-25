// <copyright file="BigRational.IEquatable.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath
{
    using System;

    /// <summary>
    /// A structure that represents a rational number with an arbitrarily large numerator and denominator.
    /// </summary>
    public partial struct BigRational : IEquatable<BigRational>
    {
        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is BigRational bigRational && this.Equals(bigRational);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (this.Numerator.GetHashCode() * 137) + this.Denominator.GetHashCode();
            }
        }

        /// <inheritdoc />
        public bool Equals(BigRational other)
        {
            return (this.Numerator * other.Denominator).Equals(other.Numerator * this.Denominator);
        }
    }
}