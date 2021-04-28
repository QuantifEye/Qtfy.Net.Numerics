// <copyright file="SamplerExtensions.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random
{
    using System;

    /// <summary>
    /// A collection of extension methods for samplers.
    /// </summary>
    public static class SamplerExtensions
    {
        /// <summary>
        /// Draws <paramref name="n"/> values from the sampler and returns them as an array.
        /// </summary>
        /// <param name="sampler">
        /// The sampler to draw observations from.
        /// </param>
        /// <param name="n">
        /// The number of observations to draw.
        /// </param>
        /// <typeparam name="T">
        /// The type of the values that are sampled.
        /// </typeparam>
        /// <returns>
        /// An array containing <paramref name="n"/> observations drawn from sampler.
        /// </returns>
        public static T[] GetNext<T>(this ISampler<T> sampler, int n)
        {
            if (sampler is null)
            {
                throw new ArgumentNullException(nameof(sampler));
            }

            var result = new T[n];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = sampler.GetNext();
            }

            return result;
        }
    }
}
