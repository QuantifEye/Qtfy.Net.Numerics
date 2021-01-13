// <copyright file="Matrix.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    public interface IVector<T> : IEnumerable<T>
    {
        T this[int i] { get; }
    }
}

