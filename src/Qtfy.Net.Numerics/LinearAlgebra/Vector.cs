// <copyright file="Matrix.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class Vector<T> : IVector<T>
        where T : struct
    {
        internal T[] data;

        internal Vector(T[] data)
        {
            this.data = data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return data.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public T this[int i] => this.data[i];

        public int Length => this.data.Length;
    }

    public sealed class VectorView<T> : IVector<T>
    {
        internal readonly T[] data;

        internal readonly int offset;

        internal readonly int stride;

        internal readonly int length;

        public T this[int i] => this.data[this.offset + this.stride * i];

        public VectorView(T[] data, int offset, int stride, int length)
        {
            this.data = data;
            this.offset = offset;
            this.stride = stride;
            this.length = length;
        }

        internal ref T GetPinnableReference()
        {
            return ref this.data[this.offset];
        }


        public IEnumerator<T> GetEnumerator()
        {
            var index = this.offset;
            var length = this.length;
            var data = this.data;
            var stride = this.stride;
            if (length != 0)
            {
                do
                {
                    yield return data[index];
                    index += stride;
                }
                while (--length != 0);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public static class VectorExtensions
    {
        public static double AbsoluteSum(Vector<double> v)
        {
            return ArrayMath.AbsoluteSum(v.data);
        }

        public static double AbsoluteSum(VectorView<double> v)
        {
            unsafe
            {
                var stride = v.stride;
                var length = v.length;
                fixed (double* pin = v)
                {
                    var ptr = pin;
                    var last = ptr + length * stride;
                    var total = 0d;
                    do
                    {
                        total += Math.Abs(*ptr);
                        ptr += stride;
                    }
                    while (ptr != last);
                    return total + Math.Abs(*ptr);
                }
            }
        }
    }
}
