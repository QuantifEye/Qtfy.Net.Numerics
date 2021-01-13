// <copyright file="Matrix.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    public interface IVectorStorage<T, TThis> : IStorage<T, TThis>
        where T : struct
        where TThis : struct, IVectorStorage<T, TThis>
    {
        T this[int i] { get; set; }

        int Length { get; }

        void Init(int length);
    }
}

