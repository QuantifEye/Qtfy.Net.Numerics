// <copyright file="GaussianCopulaSampler.Factory.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.Samplers
{
    public partial class GaussianCopulaSampler
    {
        /// <summary>
        /// An object that is able to create <see cref="MultivariateNormalSampler"/>s with the
        /// same mean vector and covariance matrix, but with different <see cref="IRandomNumberEngine"/>s.
        /// </summary>
        public sealed class Factory : ISamplerFactory<GaussianCopulaSampler>
        {
            private readonly double[] choleskyFactor;

            private readonly int order;

            /// <summary>
            /// Initializes a new instance of the <see cref="Factory"/> class.
            /// </summary>
            /// <param name="correlationMatrix">
            /// The correlation matrix.
            /// </param>
            public Factory(double[,] correlationMatrix)
            {
                this.choleskyFactor = Impl.PackedCholeskyFactor(correlationMatrix);
                this.order = correlationMatrix.GetLength(0);
            }

            /// <inheritdoc />
            public GaussianCopulaSampler Create(IRandomNumberEngine engine)
            {
                return new (engine, this.choleskyFactor, this.order);
            }
        }
    }
}
