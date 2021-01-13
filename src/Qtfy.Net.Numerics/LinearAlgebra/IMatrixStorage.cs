// <copyright file="Matrix.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    public interface IMatrixStorage<T, TThis> : IStorage<T, TThis>
        where T : struct
        where TThis : struct, IMatrixStorage<T, TThis>
    {
        T this[int r, int c] { get; set; }

        int RowCount { get; }

        int ColumnCount { get; }

        void Init(int r, int c);

        Blas.BlasLayout Layout { get; }
    }
}

