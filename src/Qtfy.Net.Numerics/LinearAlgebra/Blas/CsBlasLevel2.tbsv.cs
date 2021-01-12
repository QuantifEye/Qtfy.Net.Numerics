// <copyright file="CsBlasLevel2.tbsv.cs" company="QuantifEye">
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
        public static unsafe void dtbsv(
            BlasLayout layout,
            BlasUpperLower upperLower,
            BlasTranspose trans,
            BlasDiagonal diag,
            nint n,
            nint k,
            double* a,
            nint lda,
            double* x,
            nint incx)
        {
            throw new NotImplementedException();
        }

        public static unsafe void ztbsv(
            BlasLayout layout,
            BlasUpperLower upperLower,
            BlasTranspose trans,
            BlasDiagonal diag,
            nint n,
            nint k,
            Complex* a,
            nint lda,
            Complex* x,
            nint incx)
        {
            throw new NotImplementedException();
        }
    }
}
