// <copyright file="IRandomBitGenerator.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license. See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random
{
    /// <summary>
    /// An interface for objects able to generate integral values that have random bits.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value generated.
    /// </typeparam>
    public interface IRandomBitGenerator<T>
    {
        /// <summary>
        /// Gets an integral value in the closed interval [T.Min, T.Max].
        /// </summary>
        /// <returns>
        /// An integral value in the closed interval [T.Min, T.Max].
        /// </returns>
        T Next();
    }
}
