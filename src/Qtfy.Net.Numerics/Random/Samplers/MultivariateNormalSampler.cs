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
    public partial class MultivariateNormalSampler : ISampler<double[]>
    {
        private readonly double[] mean;

        private readonly double[] buffer;

        private readonly double[] squareRoot;

        private readonly StandardNormalSampler standardNormalSampler;

        private readonly int order;

        private MultivariateNormalSampler(
            IRandomNumberEngine engine,
            double[] mean,
            double[] squareRoot)
        {
            this.order = mean.Length;
            this.mean = mean;
            this.squareRoot = squareRoot;
            this.standardNormalSampler = new StandardNormalSampler(engine);
            this.buffer = new double[this.mean.Length];
        }

        /// <inheritdoc />
        public double[] GetNext()
        {
            var result = new double[this.order];
            var standardNormals = this.buffer;
            this.standardNormalSampler.Fill(standardNormals);
            unsafe
            {
                fixed (double* resultPin = result)
                fixed (double* standardNormalsPin = standardNormals)
                fixed (double* squareRootPin = this.squareRoot)
                fixed (double* meanPin = this.mean)
                {
                    GetNextImpl(standardNormalsPin, meanPin, squareRootPin, resultPin, resultPin + this.order);
                }
            }

            return result;
        }

        private static unsafe void GetNextImpl(
            double* standardNormals,
            double* mean,
            double* squareRoot,
            double* result,
            double* resultEnd)
        {
            double* z;
            double* zEnd = standardNormals;
            double total;
            do
            {
                z = standardNormals;
                ++zEnd;
                total = *z * *squareRoot;
                while (++z != zEnd)
                {
                    ++squareRoot;
                    total += *z * *squareRoot;
                }

                *result = total + *mean;
                ++mean;
            }
            while (++result != resultEnd);
        }
    }
}
