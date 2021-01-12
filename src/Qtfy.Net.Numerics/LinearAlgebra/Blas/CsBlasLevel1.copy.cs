// <copyright file="CsBlasLevel1.copy.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra.Blas
{
    using System.Numerics;

    internal static partial class CsBlasLevel1
    {
        public static unsafe void dcopy(
            nint n,
            double* x,
            nint incx,
            double* y,
            nint incy)
        {
            AssertValid(n);
            while (true)
            {
                *y = *x;
                if (--n == 0)
                {
                    return;
                }

                x += incx;
                y += incy;
            }
        }

        public static unsafe void zcopy(
            nint n,
            Complex* x,
            nint incx,
            Complex* y,
            nint incy)
        {
            AssertValid(n);
            while (true)
            {
                *y = *x;
                if (--n == 0)
                {
                    return;
                }

                x += incx;
                y += incy;
            }
        }
    }
}
