// <copyright file="Matrix.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    public sealed class CovarianceMatrix<T>
    {
        internal readonly T[,] data;

        protected CovarianceMatrix(T[,] data)
        {
            this.data = data;
            this.RowCount = data.GetLength(0);
            this.ColumnCount = data.GetLength(1);
        }

        public int RowCount { get; }

        public int ColumnCount { get; }

        public T this[int r, int c]
        {
            get => this.data[r, c];
        }

        public sealed class Builder
        {
            private T[,] data;

            private T[] diagonal;

            private readonly int size;

            public Builder(int size)
            {
                this.size = size;
                this.data = new T[size, size];
            }

            public T this[int r, int c]
            {
                get
                {
                    return this.data[r, c];
                }
                set
                {
                    if (r == c)
                    {
                        this.diagonal[r] = value;
                    }
                    this.data[r, c] = value;
                    this.data[c, r] = value;
                }
            }
        }
    }

}
