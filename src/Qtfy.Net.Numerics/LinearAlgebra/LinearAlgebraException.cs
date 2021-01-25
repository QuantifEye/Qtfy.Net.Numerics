// <copyright file="LinearAlgebraException.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    using System;

    /// <summary>
    /// An exception that expresses that an error in linear algebra logix has occured.
    /// </summary>
    public class LinearAlgebraException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinearAlgebraException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message to construct this exception with.
        /// </param>
        /// <param name="innerException">
        /// The inner exception that caused this exception.
        /// </param>
        public LinearAlgebraException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LinearAlgebraException"/> class.
        /// </summary>
        public LinearAlgebraException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LinearAlgebraException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message describing the exception.
        /// </param>
        public LinearAlgebraException(string message)
            : base(message)
        {
        }
    }
}
