// <copyright file="CsBlasLevel3.syrk.cs" company="QuantifEye">
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
        public static unsafe void dsyrk(
            BlasLayout layout,
            BlasUpperLower upperLower,
            BlasTranspose trans,
            nint n,
            nint k,
            double alpha,
            double* a,
            nint lda,
            double beta,
            double* c,
            nint ldc)
        {
            throw new NotImplementedException();
        }

        public static unsafe void zsyrk(
            BlasLayout layout,
            BlasUpperLower upperLower,
            BlasTranspose trans,
            nint n,
            nint k,
            Complex alpha,
            Complex* a,
            nint lda,
            Complex beta,
            Complex* c,
            nint ldc)
        {
            throw new NotImplementedException();
        }
    }
}
