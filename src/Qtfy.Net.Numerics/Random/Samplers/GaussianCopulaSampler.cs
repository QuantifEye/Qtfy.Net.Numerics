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
    public partial class GaussianCopulaSampler : ISampler<double[]>
    {
        private readonly double[] choleskyFactor;

        private readonly double[] buffer;

        private readonly int order;

        private readonly StandardNormalSampler standardNormalSampler;

        private GaussianCopulaSampler(IRandomNumberEngine engine, double[] choleskyFactor, int order)
        {
            this.buffer = new double[order];
            this.order = order;
            this.choleskyFactor = choleskyFactor;
            this.standardNormalSampler = new StandardNormalSampler(engine);
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
                fixed (double* factorPin = this.choleskyFactor)
                {
                    var resultEnd = resultPin + this.order;
                    GetNextImpl(standardNormalsPin, factorPin, resultPin, resultEnd);
                    StandardNormalCdfInPlace(resultPin, resultEnd);
                }
            }

            return result;
        }

        private static unsafe void GetNextImpl(
            double* standardNormals,
            double* factor,
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
                total = *z * *factor;
                while (++z != zEnd)
                {
                    ++factor;
                    total += *z * *factor;
                }

                *result = total;
            }
            while (++result != resultEnd);
        }

        private static unsafe void StandardNormalCdfInPlace(double* result, double* resultEnd)
        {
            var standardNormalDist = StandardNormalDistribution.Instance;
            do
            {
                *result = standardNormalDist.CumulativeDistribution(*result);
            }
            while (++result != resultEnd);
        }
    }
}
