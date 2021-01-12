// <copyright file="CsBlasLevel1.rot.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra.Blas
{
    using System;
    using System.Numerics;

    internal static partial class CsBlasLevel1
    {
        public static unsafe void drot(
            nint n,
            double* x,
            nint incx,
            double* y,
            nint incy,
            double c,
            double s)
        {
            throw new NotImplementedException();
        }

        public static unsafe void zrot(
            nint n,
            Complex* x,
            nint incx,
            Complex* y,
            nint incy,
            double c,
            double s)
        {
            throw new NotImplementedException();
        }
    }
}
