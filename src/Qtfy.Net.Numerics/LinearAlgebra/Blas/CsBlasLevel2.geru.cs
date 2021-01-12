// <copyright file="CsBlasLevel2.geru.cs" company="QuantifEye">
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
        public static unsafe void zgeru(
            BlasLayout layout,
            nint m,
            nint n,
            Complex alpha,
            Complex* x,
            nint incx,
            Complex* y,
            nint incy,
            Complex* a,
            nint lda)
        {
            throw new NotImplementedException();
        }
    }
}
