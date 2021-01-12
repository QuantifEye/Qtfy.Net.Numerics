// <copyright file = "CsBlasLevel1.asum.cs" company = "QuantifEye" >
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra.Blas
{
    using System.Numerics;
    using static System.Math;

    internal static partial class CsBlasLevel1
    {
        internal static unsafe double dasum(nint n, double* x, nint incx)
        {
            AssertValid(n, incx);
            var result = 0d;
            var last = x + (n * incx);
            do
            {
                result += Abs(*x);
                x += incx;
            }
            while (x != last);
            return result + Abs(*x);
        }

        internal static unsafe double dzasum(nint n, Complex* x, nint incx)
        {
            AssertValid(n, incx);
            var result = 0d;
            var last = x + (n * incx);
            do
            {
                result += (*x).Magnitude;
                x += incx;
            }
            while (x != last);
            return result + (*x).Magnitude;
        }
    }
}
