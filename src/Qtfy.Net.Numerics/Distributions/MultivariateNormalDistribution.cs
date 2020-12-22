// <copyright file="MultivariateNormalDistribution.cs" company="QuantifEye">
// Copyright (c) QuantifEye. All rights reserved.
// Licensed under the Apache 2.0 license.
// See LICENSE.txt file in the project root for full license information.
// </copyright>

namespace Qtfy.Net.Numerics.Distributions
{
    /// <summary>
    /// The multivariate normal distribution.
    /// </summary>
    public class MultivariateNormalDistribution : IDistribution<double[]>
    {
        /// <inheritdoc />
        public double CDF(double[] x)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public double[] InverseCDF(double p)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public double PDF(double[] x)
        {
            throw new System.NotImplementedException();
        }
    }
}
