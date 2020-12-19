// <copyright file="ISeedSequence.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random
{
    /// <summary>
    /// A seed sequence is constructed from integer based values and produces a requested number of
    /// integer based values.
    /// The produced values are well distributed even if the consumed values are not.
    /// It provides a way for random bit generators to set their initial state when their initial state is large
    /// and little entropy is provided to initialise that state.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the values in the generated array.
    /// </typeparam>
    public interface ISeedSequence<T>
    {
        /// <summary>
        /// Creates an array with size <paramref name="resultSize"/>
        /// based on the data that the seed sequence was constructed from.
        /// </summary>
        /// <param name="resultSize">
        /// The size of the array to return.
        /// </param>
        /// <returns>
        /// An array with size <paramref name="resultSize"/>
        /// based on the data that the seed sequence was constructed from.
        /// </returns>
        T[] Generate(int resultSize);
    }
}
