// <copyright file="Matrix.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    using System;

    public struct DenseVectorStorage<T> : IVectorStorage<T, DenseVectorStorage<T>>
        where T : struct
    {
        public T[] data;

        public DenseVectorStorage(T[] data)
        {
            this.data = data;
        }

        public T this[int i]
        {
            get => this.data[i];
            set => this.data[i] = value;
        }

        public int Length => this.data.Length;

        public T AbsoluteSum()
        {
            throw new NotImplementedException();
        }

        public DenseVectorStorage<T> Copy()
        {
            return new DenseVectorStorage<T>((T[])this.data.Clone());
        }

        public void Init(int length)
        {
            this.data = new T[length];
        }
    }
}

