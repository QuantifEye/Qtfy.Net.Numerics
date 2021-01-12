// <copyright file="CsBlasLevel2.gemv.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra.Blas
{
    using System;
    using System.Numerics;

    internal static partial class CsBlasLevel2
    {
        public static unsafe void dgemv(
            BlasLayout layout,
            BlasTranspose trans,
            nint m,
            nint n,
            double alpha,
            double* a,
            nint lda,
            double* x,
            nint incx,
            double beta,
            double* y,
            nint incy)
        {
            throw new NotImplementedException();
        }

        public static unsafe void zgemv(
            BlasLayout layout,
            BlasTranspose trans,
            nint m,
            nint n,
            Complex alpha,
            Complex* a,
            nint lda,
            Complex* x,
            nint incx,
            Complex beta,
            Complex* y,
            nint incy)
        {
            throw new NotImplementedException();
        }
    }
}
