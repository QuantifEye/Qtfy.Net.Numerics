// <copyright file="CsBlasLevel2.spmv.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra.Blas
{
    using System;

    internal static partial class CsBlasLevel2
    {
        public static unsafe void dspmv(
            BlasLayout layout,
            BlasUpperLower upperLower,
            nint n,
            double alpha,
            double* ap,
            double* x,
            nint incx,
            double beta,
            double* y,
            nint incy)
        {
            throw new NotImplementedException();
        }
    }
}
