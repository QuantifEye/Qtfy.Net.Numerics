// <copyright file="CsBlasLevel2.hpmv.cs" company="QuantifEye">
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
        public static unsafe void zhpmv(
            BlasLayout layout,
            BlasUpperLower upperLower,
            nint n,
            Complex alpha,
            Complex* ap,
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
