// <copyright file="CsBlasLevel1.scal.cs" company="QuantifEye">
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
        public static unsafe void dscal(
            nint n,
            double a,
            double* x,
            nint incx)
        {
            throw new NotImplementedException();
        }

        public static unsafe void zscal(
            nint n,
            Complex* a,
            Complex* x,
            nint incx)
        {
            throw new NotImplementedException();
        }

        public static unsafe void zdscal(
            nint n,
            double a,
            Complex* x,
            nint incx)
        {
            throw new NotImplementedException();
        }
    }
}
