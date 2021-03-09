// <copyright file="MultivariateNormalSampler.Factory.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.Samplers
{
    using System;

    public partial class MultivariateNormalSampler
    {
        /// <summary>
        /// An object that is able to create <see cref="MultivariateNormalSampler"/>s with the
        /// same mean vector and covariance matrix, but with different <see cref="IRandomNumberEngine"/>s.
        /// </summary>
        public class Factory : ISamplerFactory<MultivariateNormalSampler>
        {
            private readonly double[] mean;

            private readonly double[] choleskyFactor;

            /// <summary>
            /// Initializes a new instance of the <see cref="Factory"/> class.
            /// </summary>
            /// <param name="mean">
            /// The mean vector of the reference multivariate normal distribution.
            /// </param>
            /// <param name="covarianceMatrix">
            /// The covariance matrix of the reference multivariate normal distribution.
            /// </param>
            /// <exception cref="ArgumentNullException">
            /// If <paramref name="mean"/> is null.
            /// </exception>
            /// <exception cref="ArgumentException">
            /// If <paramref name="covarianceMatrix"/> is null.
            /// </exception>
            public Factory(double[] mean, double[,] covarianceMatrix)
            {
                var factor = Impl.PackedCholeskyFactor(covarianceMatrix);

                if (mean is null)
                {
                    throw new ArgumentNullException(nameof(mean));
                }

                if (mean.Length != factor.GetLength(0))
                {
                    throw new ArgumentException("mean must have length equal to number of rows of square covariance");
                }

                this.choleskyFactor = factor;
                this.mean = mean.Copy();
            }

            /// <inheritdoc />
            public MultivariateNormalSampler Create(IRandomNumberEngine engine)
            {
                return new (engine, this.mean, this.choleskyFactor);
            }
        }
    }
}
