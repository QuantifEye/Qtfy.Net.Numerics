// <copyright file="MultivariateNormalSampler.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Random.Samplers
{
    /// <summary>
    /// A multivariate normal (gaussian) sampler.
    /// </summary>
    public sealed partial class MultivariateNormalSampler : ISampler<double[]>
    {
        /// <summary>
        /// Array of mean values.
        /// </summary>
        private readonly double[] mean;

        /// <summary>
        /// Internal array of buffer variables.
        /// </summary>
        private readonly double[] buffer;

        /// <summary>
        /// Cholesky factorization defining joint distribution.
        /// </summary>
        private readonly double[] choleskyFactor;

        /// <summary>
        /// The standard normal sampler used internally for sampling.
        /// </summary>
        private readonly StandardNormalSampler standardNormalSampler;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Qtfy.Net.Numerics.Random.Samplers.MultivariateNormalSampler"/> class.
        /// </summary>
        /// <param name="engine">
        /// The simulation engine to be used for sampling.
        /// </param>
        /// <param name="mean">
        /// The mean values of the variables to be generated simultaneously.
        /// </param>
        /// <param name="choleskyFactor">
        /// The Cholesky factorization of a matrix defining the desired joint distribution.
        /// </param>
        private MultivariateNormalSampler(IRandomNumberEngine engine, double[] mean, double[] choleskyFactor)
        {
            this.Length = mean.Length;
            this.mean = mean;
            this.choleskyFactor = choleskyFactor;
            this.standardNormalSampler = new StandardNormalSampler(engine);
            this.buffer = new double[this.mean.Length];
        }

        /// <summary>
        /// Gets the length of the arrays <see cref="GetNext"/> returns.
        /// </summary>
        public int Length { get; }

        /// <inheritdoc />
        public double[] GetNext()
        {
            var size = this.Length;
            var result = new double[size];
            var normals = this.buffer;
            this.standardNormalSampler.Fill(normals);
            unsafe
            {
                fixed (double* fPin = this.choleskyFactor, nPin = normals, mPin = this.mean, rPin = result)
                {
                    MultiplyAdd(fPin, nPin, mPin, rPin, rPin + size);
                }
            }

            return result;
        }

        /// <summary>
        /// Helper function for generating next random variable.
        /// </summary>
        /// <param name="factor">
        /// The factor.
        /// </param>
        /// <param name="normals">
        /// The normals.
        /// </param>
        /// <param name="mean">
        /// The mean.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        /// <param name="resultEnd">
        /// The result end.
        /// </param>
        private static unsafe void MultiplyAdd(
            double* factor,
            double* normals,
            double* mean,
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

                *result = total + *mean;
                ++mean;
            }
            while (++result != resultEnd);
        }
    }
}
