// <copyright file="CsBlasLevel3.gemm.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra.Blas
{
    using System;
    using System.Numerics;

    internal static partial class CsBlasLevel3
    {
        public static unsafe void dgemm(
            BlasLayout layout,
            BlasTranspose transa,
            BlasTranspose transb,
            nint m,
            nint n,
            nint k,
            double alpha,
            double* a,
            nint lda,
            double* b,
            nint ldb,
            double beta,
            double* c,
            nint ldc)
        {
            throw new NotImplementedException();
        }

        public static unsafe void zgemm(
            BlasLayout layout,
            BlasTranspose transa,
            BlasTranspose transb,
            nint m,
            nint n,
            nint k,
            Complex alpha,
            Complex* a,
            nint lda,
            Complex* b,
            nint ldb,
            Complex beta,
            Complex* c,
            nint ldc)
        {
            throw new NotImplementedException();
        }
    }
}
