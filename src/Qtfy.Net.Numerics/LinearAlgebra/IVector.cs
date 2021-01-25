// <copyright file="IVector.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    /// <summary>
    /// The interface all for linear algebra vectors.
    /// </summary>
    public interface IVector
    {
        /// <summary>
        /// Gets the length of the vector.
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Gets the value at the provided index.
        /// </summary>
        /// <param name="i">
        /// The index of the element to access.
        /// </param>
        double this[int i] { get; }
    }
}
