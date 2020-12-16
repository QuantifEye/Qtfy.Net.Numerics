// <copyright file="RationalRounding.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics
{
    /// <summary>
    /// An enumeration that determines how a BigRational number is rounded.
    /// </summary>
    public enum RationalRounding
    {
        /// <summary>
        /// Indicates that if a number is not a whole number of ticks away from zero, that it should be rounded
        /// to the nearest number that multiple of the specified tick size. If the number is exactly half way
        /// between two such numbers, the number is rounded down to the nearest number that is an even-multiple of
        /// the specified tick size.
        /// </summary>
        ToEven,

        /// <summary>
        /// Indicates that if a number is not a whole number of ticks away from zero, that it should be rounded
        /// to the nearest number that multiple of the specified tick size. If the number is exactly half way
        /// between two such numbers, the number is rounded up to the nearest number that is a multiple of
        /// the specified tick size.
        /// </summary>
        Up,

        /// <summary>
        /// Indicates that if a number is not a whole number of ticks away from zero, that it should be rounded
        /// to the nearest number that multiple of the specified tick size. If the number is exactly half way
        /// between two such numbers, the number is rounded down to the nearest number that is a multiple of
        /// the specified tick size.
        /// </summary>
        Down,

        /// <summary>
        /// Indicates that if a number is not a whole number of ticks away from zero, that it should be rounded
        /// to the nearest number that multiple of the specified tick size. If the number is exactly half way
        /// between two such numbers, the number is rounded away from zero to the nearest number that is a
        /// multiple of the specified tick size.
        /// </summary>
        AwayFromZero,

        /// <summary>
        /// Indicates that if a number is not a whole number of ticks away from zero, that it should be rounded
        /// to the nearest number that multiple of the specified tick size. If the number is exactly half way
        /// between two such numbers, the number is rounded toward zero to the nearest number that is a multiple
        /// of the specified tick size.
        /// </summary>
        TowardZero,
    }
}
