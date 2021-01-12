// <copyright file="CsBlasLevel1.sdot.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra.Blas
{
    internal static partial class CsBlasLevel1
    {
        public static unsafe double dsdot(
            nint n,
            double* x,
            nint incx,
            double* y,
            nint incy)
        {
            AssertValid(n);
            var result = 0d;
            while (true)
            {
                result += *y * *x;
                if (--n == 0)
                {
                    return result;
                }

                x += incx;
                y += incy;
            }
        }
    }
}
