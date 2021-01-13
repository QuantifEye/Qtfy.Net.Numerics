// <copyright file="Matrix.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    using System.Collections.Generic;

    public interface IMatrix<T>
    {
        int RowCount {get;}

        int ColumnCount {get;}

        T this[int r, int c] { get; }
    }
}

