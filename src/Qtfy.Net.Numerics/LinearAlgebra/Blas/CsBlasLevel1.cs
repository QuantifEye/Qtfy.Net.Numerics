// <copyright file="CsBlasLevel1.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

using System.Diagnostics.CodeAnalysis;

namespace Qtfy.Net.Numerics.LinearAlgebra.Blas
{
    using System.Diagnostics;

    [SuppressMessage("Naming Rules", "SA1300", Justification = "blas naming")]
    internal static partial class CsBlasLevel1
    {
        [Conditional("DEBUG")]
        private static void AssertValid(nint n, nint incx = 1, nint incy = 1)
        {
            Debug.Assert(n > 0, "n should not be negative");
            Debug.Assert(incx != 0, "incx should not be zero");
            Debug.Assert(incy != 0, "incy should not be zero");
        }
    }
}
