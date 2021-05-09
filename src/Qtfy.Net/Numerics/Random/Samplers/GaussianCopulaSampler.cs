// <copyright file="GaussianCopulaSampler.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.Samplers
{
    using Qtfy.Net.Numerics.Distributions;

    /// <summary>
    /// A gaussian copula sampler. That is a sampler that uses a correlation matrix
    /// to generate correlated uniform[0, 1] variables.
    /// </summary>
    public sealed partial class GaussianCopulaSampler : ISampler<double[]>
    {
        /// <summary>
        /// The Cholesky factorization representing the joint distribution to sample from.
        /// </summary>
        private readonly double[] choleskyFactor;

        /// <summary>
        /// Internal buffer array.
        /// </summary>
        private readonly double[] buffer;

        /// <summary>
        /// The standard normal sampler used internally.
        /// </summary>
        private readonly StandardNormalSampler standardNormalSampler;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Qtfy.Net.Numerics.Random.Samplers.GaussianCopulaSampler"/> class.
        /// </summary>
        /// <param name="engine">
        /// The random number engine.
        /// </param>
        /// <param name="choleskyFactor">
        /// The Cholesky factorization of the correlation matrix.
        /// </param>
        /// <param name="order">
        /// The order variable.
        /// </param>
        private GaussianCopulaSampler(IRandomNumberEngine engine, double[] choleskyFactor, int order)
        {
            this.buffer = new double[order];
            this.Length = order;
            this.choleskyFactor = choleskyFactor;
            this.standardNormalSampler = new StandardNormalSampler(engine);
        }

        /// <summary>
        /// Gets the length of the arrays <see cref="GetNext"/> returns.
        /// </summary>
        public int Length { get; }

        /// <inheritdoc />
        public double[] GetNext()
        {
            var resultSize = this.Length;
            var result = new double[resultSize];
            var normals = this.buffer;
            this.standardNormalSampler.Fill(normals);
            unsafe
            {
                fixed (double* fPin = this.choleskyFactor, nPin = normals, rPin = result)
                {
                    var r = rPin;
                    var rEnd = rPin + resultSize;
                    Multiply(fPin, nPin, rPin, rEnd);
                    do
                    {
                        *r = StandardNormalDistribution.CumulativeDistributionFunction(*r);
                    }
                    while (++r != rEnd);
                }
            }

            return result;
        }

        /// <summary>
        /// Helper function for generation of next random number.
        /// </summary>
        /// <param name="factor">
        /// The factor.
        /// </param>
        /// <param name="normals">
        /// The normals.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        /// <param name="resultEnd">
        /// The result end.
        /// </param>
        private static unsafe void Multiply(
            double* factor,
            double* normals,
            double* result,
            double* resultEnd)
        {
            double* z;
            var zEnd = normals;
            double total;
            do
            {
                z = normals;
                ++zEnd;
                total = *z * *factor;
                ++factor;
                while (++z != zEnd)
                {
                    total += *z * *factor;
                    ++factor;
                }

                *result = total;
            }
            while (++result != resultEnd);
        }
    }
}
