// <copyright file="BigRational.FromIntegral.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath
{
    using System.Numerics;

    /// <summary>
    /// A structure that represents a rational number with an arbitrarily large numerator and denominator.
    /// </summary>
    public partial struct BigRational
    {
        /// <summary>
        /// Converts a <see cref="BigInteger"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="BigInteger"/> to convert.
        /// </param>
        public static implicit operator BigRational(BigInteger value)
        {
            return new BigRational(value);
        }

        /// <summary>
        /// Converts a <see cref="ulong"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="ulong"/> to convert.
        /// </param>
        public static implicit operator BigRational(ulong value)
        {
            return new BigRational(value);
        }

        /// <summary>
        /// Converts a <see cref="long"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="long"/> to convert.
        /// </param>
        public static implicit operator BigRational(long value)
        {
            return new BigRational(value);
        }

        /// <summary>
        /// Converts a <see cref="uint"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="uint"/> to convert.
        /// </param>
        public static implicit operator BigRational(uint value)
        {
            return new BigRational(value);
        }

        /// <summary>
        /// Converts a <see cref="int"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="int"/> to convert.
        /// </param>
        public static implicit operator BigRational(int value)
        {
            return new BigRational(value);
        }

        /// <summary>
        /// Converts a <see cref="ushort"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="ushort"/> to convert.
        /// </param>
        public static implicit operator BigRational(ushort value)
        {
            return new BigRational(value);
        }

        /// <summary>
        /// Converts a <see cref="short"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="short"/> to convert.
        /// </param>
        public static implicit operator BigRational(short value)
        {
            return new BigRational(value);
        }

        /// <summary>
        /// Converts a <see cref="byte"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="byte"/> to convert.
        /// </param>
        public static implicit operator BigRational(byte value)
        {
            return new BigRational(value);
        }

        /// <summary>
        /// Converts a <see cref="sbyte"/> to a <see cref="BigRational"/>.
        /// </summary>
        /// <param name="value">
        /// The <see cref="sbyte"/> to convert.
        /// </param>
        public static implicit operator BigRational(sbyte value)
        {
            return new BigRational(value);
        }
    }
}