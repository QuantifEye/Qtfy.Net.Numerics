// <copyright file="BigRational.Parse.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.QMath
{
    using System;
    using System.Numerics;

    /// <summary>
    /// A structure that represents a rational number with an arbitrarily large numerator and denominator.
    /// </summary>
    public partial struct BigRational
    {
        /// <summary>
        /// Tries to convert the string representation of a number to its <see cref="BigRational"/> equivalent,
        /// and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <param name="from">
        /// The string representation of a number.
        /// </param>
        /// <param name="rational">
        /// When this method returns, contains the <see cref="BigRational"/> equivalent to
        /// the number that is contained in value, or zero (0) if the conversion fails.
        /// The conversion fails if the value <paramref name="from"/> is null or is not of the correct format.
        /// This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// true if value was converted successfully; otherwise, false.
        /// </returns>
        public static bool TryParse(string from, out BigRational rational)
        {
            var s = from.Split('/');
            var length = s.Length;

            if (length == 1 && BigInteger.TryParse(from, out var bigint))
            {
                rational = new BigRational(bigint);
                return true;
            }

            if (length == 2 && BigInteger.TryParse(s[0], out var num) && BigInteger.TryParse(s[1], out var den))
            {
                rational = new BigRational(num, den);
                return true;
            }

            rational = default;
            return false;
        }

        /// <summary>
        /// Converts the string representation of a number to its <see cref="BigRational"/> equivalent.
        /// </summary>
        /// <param name="from">
        /// A string that contains the number to convert.
        /// </param>
        /// <returns>
        /// A value that is equivalent to the number specified in the <paramref name="from"/> parameter.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// If <paramref name="from"/> is null.
        /// </exception>
        /// <exception cref="FormatException">
        /// If <paramref name="from"/> cannot be interpreted as a <see cref="BigRational"/>.
        /// </exception>
        public static BigRational Parse(string from)
        {
            var s = from.Split('/');
            switch (s.Length)
            {
                case 1:
                    return new BigRational(BigInteger.Parse(from));
                case 2:
                    var n = BigInteger.Parse(s[0]);
                    var d = BigInteger.Parse(s[1]);
                    if (d.IsZero)
                    {
                        break;
                    }

                    return new BigRational(n, d);
            }

            throw new FormatException($"Could not parse \"{from}\" as a BigRational.");
        }
    }
}