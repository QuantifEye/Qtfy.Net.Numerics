// <copyright file="UniformBounds.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random
{
    using System;

    /// <summary>
    /// A enumeration indicating whether 0, and/or 1 should be included in the
    /// interval of possible values when generating a standard uniform variable.
    /// </summary>
    [Flags]
    public enum UniformBounds
    {
        /// <summary>
        /// The value indicating that a standard uniform variable on the interval (0, 1)
        /// should be generated.
        /// </summary>
        None = 0,

        /// <summary>
        /// The value indicating that 1 should potentially be generated
        /// when generating a standard uniform value;
        /// </summary>
        IncludeZero = 1,

        /// <summary>
        /// The value indicating that 0 should potentially be generated
        /// when generating a standard uniform value;
        /// </summary>
        IncludeOne = 1 << 1,
    }
}
