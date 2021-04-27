// <copyright file="ISamplerFactory.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random
{
    /// <summary>
    /// An object used to create Samplers with identical distributions, but with different
    /// random number engines.
    /// </summary>
    /// <typeparam name="TSampler">
    /// The type of the sampler that this object creates.
    /// </typeparam>
    public interface ISamplerFactory<TSampler>
    {
        /// <summary>
        /// Creates a new sampler with the provided random number engine.
        /// </summary>
        /// <param name="engine">
        /// The random number engine.
        /// </param>
        /// <returns>
        /// A new sampler.
        /// </returns>
        TSampler Build(IRandomNumberEngine engine);
    }
}
