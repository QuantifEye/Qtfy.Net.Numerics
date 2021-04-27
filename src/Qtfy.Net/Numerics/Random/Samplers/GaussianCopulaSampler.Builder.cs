// <copyright file="GaussianCopulaSampler.Builder.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.Samplers
{
    using System;

    public sealed partial class GaussianCopulaSampler
    {
        /// <summary>
        /// An object that is able to create <see cref="MultivariateNormalSampler"/>s with the
        /// same mean vector and covariance matrix, but with different <see cref="IRandomNumberEngine"/>s.
        /// </summary>
        public sealed class Builder : ISamplerFactory<GaussianCopulaSampler>
        {
            private readonly double[] choleskyFactor;

            private readonly int order;

            /// <summary>
            /// Initializes a new instance of the <see cref="Builder"/> class.
            /// </summary>
            /// <param name="correlationMatrix">
            /// The correlation matrix.
            /// </param>
            public Builder(double[,] correlationMatrix)
            {
                if (correlationMatrix is null)
                {
                    throw new ArgumentNullException(nameof(correlationMatrix));
                }

                this.choleskyFactor = Impl.PackedCholeskyFactorCorrelationMatrix(correlationMatrix);
                this.order = correlationMatrix.GetLength(0);
            }

            /// <inheritdoc />
            public GaussianCopulaSampler Build(IRandomNumberEngine engine)
            {
                return new (engine, this.choleskyFactor, this.order);
            }
        }
    }
}
