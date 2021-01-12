// <copyright file="CsBlasLevel3.her2k.cs" company="QuantifEye">
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
        public static unsafe void zher2k(
            BlasLayout layout,
            BlasUpperLower upperLower,
            BlasTranspose trans,
            nint n,
            nint k,
            Complex alpha,
            Complex* a,
            nint lda,
            Complex* b,
            nint ldb,
            double beta,
            Complex* c,
            nint ldc)
        {
            throw new NotImplementedException();
        }
    }
}
