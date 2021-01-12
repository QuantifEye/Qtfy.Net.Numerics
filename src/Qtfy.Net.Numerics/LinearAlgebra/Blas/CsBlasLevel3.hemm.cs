// <copyright file="CsBlasLevel3.hemm.cs" company="QuantifEye">
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
        public static unsafe void zhemm(
            BlasLayout layout,
            BlasSide side,
            BlasUpperLower upperLower,
            nint m,
            nint n,
            Complex alpha,
            Complex* a,
            nint lda,
            Complex* b,
            nint ldb,
            Complex beta,
            Complex* c,
            nint ldc)
        {
            throw new NotImplementedException();
        }
    }
}
