// <copyright file="CsBlasLevel2.syr.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra.Blas
{
    using System;

    internal static partial class CsBlasLevel2
    {
        public static unsafe void dsyr(
            BlasLayout layout,
            BlasUpperLower upperLower,
            nint n,
            double alpha,
            double* x,
            nint incx,
            double* a,
            nint lda)
        {
            throw new NotImplementedException();
        }
    }
}
