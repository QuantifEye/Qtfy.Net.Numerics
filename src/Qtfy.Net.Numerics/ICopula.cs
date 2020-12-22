// <copyright file="ICopula.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics
{
    /// <summary>
    /// A interface to implementations of copulas.
    /// </summary>
    public interface ICopula
    {
        double CDF(double[] x);
    }
}
