// <copyright file="CsBlasLevel2.tpmv.cs" company="QuantifEye">
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
        public static unsafe void dtpmv(
            BlasLayout layout,
            BlasUpperLower upperLower,
            BlasTranspose trans,
            BlasDiagonal diag,
            nint n,
            double* ap,
            double* x,
            nint incx)
        {
            throw new NotImplementedException();
        }

        public static unsafe void ztpmv(
            BlasLayout layout,
            BlasUpperLower upperLower,
            BlasTranspose trans,
            BlasDiagonal diag,
            nint n,
            Complex* ap,
            Complex* x,
            nint incx)
        {
            throw new NotImplementedException();
        }
    }
}
