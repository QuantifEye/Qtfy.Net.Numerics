// <copyright file="InverseTransformSampler.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.Samplers
{
    using System;

    /// <summary>
    /// An inverse transform random number generator.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the values generated by the sampler.
    /// </typeparam>
    public sealed class InverseTransformSampler<T> : ISampler<T>
    {
        private readonly IRandomNumberEngine engine;

        /// <summary>
        /// Initializes a new instance of the <see cref="InverseTransformSampler{T}"/> class.
        /// </summary>
        /// <param name="engine">
        /// The random number engine.
        /// </param>
        /// <param name="distribution">
        /// The reference distribution.
        /// </param>
        public InverseTransformSampler(IRandomNumberEngine engine, IDistribution<T> distribution)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));
            this.Distribution = distribution ?? throw new ArgumentNullException(nameof(distribution));
        }

        /// <summary>
        /// Gets the distribution of the numbers that are generated.
        /// </summary>
        public IDistribution<T> Distribution { get; }

        /// <inheritdoc />
        public T GetNext()
        {
            return this.Distribution.Quantile(this.engine.NextStandardUniform());
        }
    }
}