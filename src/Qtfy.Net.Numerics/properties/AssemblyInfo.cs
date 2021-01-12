// <copyright file="AssemblyInfo.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

using System;
using System.Diagnostics.CodeAnalysis;

[assembly: CLSCompliant(false)]
[assembly: SuppressMessage(
    "Naming Rules",
    "SA1300",
    Justification = "names stick as closely as possible to native blas methods",
    Target = "~N:Qtfy.Net.Numerics.LinearAlgebra.Blas")]
