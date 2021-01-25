// <copyright file="Vector.Builder.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.LinearAlgebra
{
    public sealed partial class Vector
    {
        /// <summary>
        /// A builder object to create vectors.
        /// </summary>
        public sealed class Builder : LinearAlgebraBuilder<Vector>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Builder"/> class.
            /// </summary>
            /// <param name="length">
            /// The lenght of the vector to build.
            /// </param>
            public Builder(int length)
                : base(MakeData(length))
            {
            }

            /// <summary>
            /// Gets the length of the vector.
            /// </summary>
            public int Length
            {
                get => this.data.Length;
            }

            /// <summary>
            /// Gets or sets the element at the provided index.
            /// </summary>
            /// <param name="i">
            /// The index of the element to access.
            /// </param>
            public double this[int i]
            {
                get => this.data[i];
                set => this.data[i] = value;
            }

            /// <inheritdoc/>
            private protected override Vector Factory(double[] data)
            {
                return new (data);
            }

            private static double[] MakeData(int length)
            {
                if (length < 1)
                {
                    throw new LinearAlgebraException("Cannot construct en empty vector");
                }

                return new double[length];
            }
        }
    }
}
