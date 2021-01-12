// <copyright file="CsBlasLevel2.gerc.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra.Blas
{
    using System;

    internal static partial class CsBlasLevel2
    {
        public static unsafe void zgerc(
            BlasLayout layout,
            nint m,
            nint n,
            void* alpha,
            void* x,
            nint incx,
            void* y,
            nint incy,
            void* a,
            nint lda)
        {
            throw new NotImplementedException();
        }
    }
}
