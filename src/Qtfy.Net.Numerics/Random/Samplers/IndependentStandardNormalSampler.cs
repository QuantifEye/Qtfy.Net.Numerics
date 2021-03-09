// <copyright file="IndependentStandardNormalSampler.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.Samplers
{
    /// <summary>
    /// A sampler that generates arrays of uncorrelated standard normal variables.
    /// </summary>
    public class IndependentStandardNormalSampler : ISampler<double[]>
    {
        private readonly StandardNormalSampler standardNormalSampler;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndependentStandardNormalSampler"/> class.
        /// </summary>
        /// <param name="engine">
        /// The underlying random number engine.
        /// </param>
        /// <param name="length">
        /// The length of the arrays that will be generated.
        /// </param>
        public IndependentStandardNormalSampler(IRandomNumberEngine engine, int length)
        {
            this.Length = length;
            this.standardNormalSampler = new StandardNormalSampler(engine);
        }

        /// <summary>
        /// Gets the length of the arrays that will be generated.
        /// </summary>
        public int Length { get; }

        /// <inheritdoc />
        public double[] GetNext()
        {
            var result = new double[this.Length];
            this.standardNormalSampler.Fill(result);
            return result;
        }
    }
}
