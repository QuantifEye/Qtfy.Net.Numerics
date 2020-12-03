// <copyright file="RationalRounding.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random
{
    /// <summary>
    /// An enumeration that determines how a BigRational number is rounded.
    /// </summary>
    public interface IRandomBitGenerator<T>
    {
        /// <summary>
        /// Returns a value in the closed interval [Min, Max].
        /// </summary>
        T Next();
    }
}
